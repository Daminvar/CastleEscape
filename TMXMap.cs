using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;

namespace CastleEscape
{
    /// <summary>
    /// A map for the Tiled map format.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class TMXMap
    {
        private List<int[][]> baseLayers;
        private List<int[][]> topLayers;
        private List<Rectangle> collisionRects;
        private int mapWidth;
        private int mapHeight;
        private int tilesize;

        public List<int[][]> BaseLayers
        {
            get { return baseLayers; }
        }

        public List<int[][]> TopLayers
        {
            get { return topLayers; }
        }

        public List<Rectangle> CollisionRects
        {
            get { return collisionRects; }
        }

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

        /// <summary>
        /// Parses a TMX map.
        /// </summary>
        /// <param name="filename">The path to the map.</param>
        public void ParseTMXFile(string filename)
        {
            var reader = new XmlDocument();
            reader.Load(filename);
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
        /// Checks to see if there's a collision at the specified location.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <returns>"true" if there's a collision--"false" otherwise.</returns>
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
