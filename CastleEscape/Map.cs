using System;
using System.Collections.Generic;
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
        private const string TILESET_RESOURCE_NAME = "tileset2";

        private List<int[][]> baseLayers;
        private List<int[][]> topLayers;
        private XmlDocument reader;
        private int width;
        private int height;
        private int tilesize;
        private Texture2D tileset;

        public enum Directions
        {
            North, South, East, West
        }

        public Map(Game game)
        {
            tileset = game.Content.Load<Texture2D>(TILESET_RESOURCE_NAME);
        }

        public void LoadMap(string filename)
        {
            reader = new XmlDocument();
            reader.Load(MAP_DIRECTORY + filename);
            LoadTMXFile();
        }

        private void LoadTMXFile()
        {
            XmlNode mapNode = reader.GetElementsByTagName("map")[0];
            width = int.Parse(mapNode.Attributes["width"].Value);
            height = int.Parse(mapNode.Attributes["height"].Value);
            tilesize = int.Parse(mapNode.Attributes["tilewidth"].Value);

            XmlNodeList layerNodes = reader.GetElementsByTagName("layer");

            //Clear baseLayers and topLayers
            baseLayers = new List<int[][]>();
            topLayers = new List<int[][]>();

            for (int i = 0; i < layerNodes.Count; i++)
            {
                string name = layerNodes[i].Attributes["name"].Value;
                XmlNode layerData = layerNodes[i].ChildNodes[0];
                if (name == "base")
                    baseLayers.Add(parseLayer(layerData));
                else if (name == "top")
                    topLayers.Add(parseLayer(layerData));
            }
        }

        private int[][] parseLayer(XmlNode layerData)
        {
            int[][] layer = new int[height][];
            for (int y = 0; y < height; y++)
            {
                layer[y] = new int[width];
                for (int x = 0; x < width; x++)
                {
                    layer[y][x] = int.Parse(layerData.ChildNodes[y * width + x].Attributes["gid"].Value);
                }
            }
            return layer;
        }

        public void ChangeMap(Directions direction)
        {
        }

        public void Update()
        {
        }

        public void DrawBase(SpriteBatch spriteBatch, int xPos, int yPos)
        {
            drawLayers(baseLayers, spriteBatch, xPos, yPos);
        }

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
                        int tileID = layers[z][y][x] - 1;
                        if (tileID == -1)
                            continue;
                        var destRect = new Rectangle(xPos + x * tilesize, yPos + y * tilesize, tilesize, tilesize);
                        var tileRect = new Rectangle((tileID % rowSize) * tilesize,
                            (tileID / rowSize) * tilesize, tilesize, tilesize);
                        spriteBatch.Draw(tileset, destRect, tileRect, Color.White);
                    }
                }
            }
        }

        public bool IsCollisionAt(int x, int y)
        {
            return false;
        }
    }
}
