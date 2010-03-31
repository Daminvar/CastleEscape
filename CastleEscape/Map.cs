using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace CastleEscape
{
    class Map
    {
        private const string MAP_DIRECTORY = "..\\..\\..\\Content\\maps\\";
        private const string TILESET_RESOURCE_NAME = "tileset";

        private Game game;
        private List<int[][]> baseLayers;
        private List<int[][]> topLayers;
        private int mapWidth;
        private int mapHeight;
        private int tilesize;
        private Texture2D tileset;
        private List<Rectangle> collisionRects;
        private string eastMapFilename, westMapFilename, northMapFilename, southMapFilename;
        private string tmxMapFilename;
        

        public int MapWidth
        {
            get { return mapWidth; }
        }

        public int MapHeight
        {
            get { return mapHeight; }
        }

        public int TileSize
        {
            get { return tilesize; }
        }

        public enum Directions
        {
            North, South, East, West
        }

        public Map(Game game)
        {
            this.game = game;
            tileset = game.Content.Load<Texture2D>(TILESET_RESOURCE_NAME);
        }

        /// <summary>
        /// Loads a map from a file.
        /// </summary>
        /// <param name="filename">The filename</param>
        public void LoadMap(string filename)
        {
            parseScriptFile(filename);
            parseTMXFile();
        }

        private void parseScriptFile(string filename)
        {
            //Clear neighboring room and mapfile strings
            eastMapFilename = null;
            westMapFilename = null;
            northMapFilename = null;
            southMapFilename = null;
            tmxMapFilename = null;

            var engine = new Jint.JintEngine();
            engine.DisableSecurity();
            engine.SetFunction("east", new Action<string>(setEastMapfile));
            engine.SetFunction("west", new Action<string>(setWestMapfile));
            engine.SetFunction("north", new Action<string>(setNorthMapfile));
            engine.SetFunction("south", new Action<string>(setSouthMapfile));
            engine.SetFunction("mapfile", new Action<string>(setTmxMapfile));
            engine.Run(File.ReadAllText(MAP_DIRECTORY + filename));
        }

        private void setEastMapfile(string filename)
        {
            eastMapFilename = filename;
        }

        private void setWestMapfile(string filename)
        {
            westMapFilename = filename;
        }

        private void setNorthMapfile(string filename)
        {
            northMapFilename = filename;
        }

        private void setSouthMapfile(string filename)
        {
            southMapFilename = filename;
        }

        private void setTmxMapfile(string filename)
        {
            tmxMapFilename = filename;
        }

        private void parseTMXFile()
        {
            var reader = new XmlDocument();
            reader.Load(MAP_DIRECTORY + tmxMapFilename);
            XmlNode mapNode = reader.GetElementsByTagName("map")[0];
            mapWidth = int.Parse(mapNode.Attributes["width"].Value);
            mapHeight = int.Parse(mapNode.Attributes["height"].Value);
            tilesize = int.Parse(mapNode.Attributes["tilewidth"].Value);

            XmlNodeList layerNodes = reader.GetElementsByTagName("layer");

            //Clear layer and collision data
            baseLayers = new List<int[][]>();
            topLayers = new List<int[][]>();
            collisionRects = new List<Rectangle>();

            //Get layer data
            for (int i = 0; i < layerNodes.Count; i++)
            {
                string name = layerNodes[i].Attributes["name"].Value;
                XmlNode layerData = layerNodes[i].ChildNodes[0];
                if (name == "base")
                    baseLayers.Add(parseLayer(layerData));
                else if (name == "top")
                    topLayers.Add(parseLayer(layerData));
            }

            //Get collision data
            XmlNode collisionNode = reader.GetElementsByTagName("objectgroup")[0];
            XmlNodeList collisionRectNodes = collisionNode.ChildNodes;
            for (int i = 0; i < collisionRectNodes.Count; i++)
            {
                XmlAttributeCollection attributes = collisionRectNodes[i].Attributes;
                int xPos = int.Parse(attributes["x"].Value);
                int yPos = int.Parse(attributes["y"].Value);
                int width = int.Parse(attributes["width"].Value);
                int height = int.Parse(attributes["height"].Value);
                collisionRects.Add(new Rectangle(xPos, yPos, width, height));
            }
        }

        private int[][] parseLayer(XmlNode layerData)
        {
            int[][] layer = new int[mapHeight][];
            for (int y = 0; y < mapHeight; y++)
            {
                layer[y] = new int[mapWidth];
                for (int x = 0; x < mapWidth; x++)
                {
                    layer[y][x] = int.Parse(layerData.ChildNodes[y * mapWidth + x].Attributes["gid"].Value) - 1;
                }
            }
            return layer;
        }

        /// <summary>
        /// Changes the map by loading the correct map
        /// file for the specified direction.
        /// </summary>
        /// <param name="direction">The direction to use</param>
        public void ChangeMap(Directions direction)
        {
            string filename = null;
            if (direction == Directions.East) filename = eastMapFilename;
            if (direction == Directions.West) filename = westMapFilename;
            if (direction == Directions.North) filename = northMapFilename;
            if (direction == Directions.South) filename = southMapFilename;

            if (filename != null)
            {
                parseScriptFile(filename);
                parseTMXFile();
            }
        }

        /// <summary>
        /// Renders the base of the map (everything below the player)
        /// at the specified coordinates.
        /// </summary>
        public void DrawBase(SpriteBatch spriteBatch, int xPos, int yPos)
        {
            drawLayers(baseLayers, spriteBatch, xPos, yPos);
        }

        /// <summary>
        /// Renders the top of the map (everything above the player)
        /// at the specified coordinates.
        /// </summary>
        public void DrawTop(SpriteBatch spriteBatch, int xPos, int yPos)
        {
            drawLayers(topLayers, spriteBatch, xPos, yPos);
        }

        private void drawLayers(List<int[][]> layers, SpriteBatch spriteBatch, int xPos, int yPos)
        {
            int rowSize = tileset.Width / tilesize;

            for (int z = 0; z < layers.Count; z++)
            {
                for (int y = 0; y < layers[0].Length; y++)
                {
                    for (int x = 0; x < layers[0][0].Length; x++)
                    {
                        int tileID = layers[z][y][x];
                        if (tileID == -1)
                            continue;
                        var destRect = new Rectangle(xPos + x * tilesize,
                            yPos + y * tilesize, tilesize, tilesize);
                        var tileRect = new Rectangle((tileID % rowSize) * tilesize,
                            (tileID / rowSize) * tilesize, tilesize, tilesize);
                        spriteBatch.Draw(tileset, destRect, tileRect, Color.White);
                    }
                }
            }
        }

        /// <summary>
        /// Tests to see if there is a collision
        /// at the specified coordinates.
        /// </summary>
        /// <returns>"true" if there's a collision, "false" otherwise.</returns>
        public bool IsCollisionAt(int x, int y)
        {
            foreach (var rect in collisionRects)
            {
                if (rect.Intersects(new Rectangle(x * tilesize, y * tilesize, tilesize, tilesize)))
                    return true;
            }
            return false;
        }
    }
}
