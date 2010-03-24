using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CastleEscape
{
    class Map
    {
        private const string MAP_DIRECTORY = "..\\..\\..\\Content\\maps\\";

        private int[][][] groundLayers;
        private int[][][] topLayers;
        private XmlDocument reader;
        private int width;
        private int height;

        public enum Directions
        {
            North, South, East, West
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

            XmlNodeList layerNodes = reader.GetElementsByTagName("layer");

            int numberOfGroundLayers = 0;
            int numberOfTopLayers = 0;

            for (int i = 0; i < layerNodes.Count; i++)
            {
                string name = layerNodes[i].Attributes["name"].Value;
                if (name == "bottom")
                    numberOfGroundLayers++;
                else if (name == "top")
                    numberOfTopLayers++;
            }

            groundLayers = new int[numberOfGroundLayers][][];
            topLayers = new int[numberOfTopLayers][][];

            int groundIndex = 0;
            int topIndex = 0;

            for (int i = 0; i < layerNodes.Count; i++)
            {
                string name = layerNodes[i].Attributes["name"].Value;
                XmlNode layerData = layerNodes[i].ChildNodes[0];

                if (name == "bottom")
                {
                    groundLayers[groundIndex] = parseLayer(layerData);
                    groundIndex++;
                }
                else if (name == "top")
                {
                    topLayers[topIndex] = parseLayer(layerData);
                    topIndex++;
                }
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

        public void DrawBase()
        {
        }

        public void DrawTop()
        {
        }

        public bool IsCollisionAt(int x, int y)
        {
            return false;
        }
    }
}
