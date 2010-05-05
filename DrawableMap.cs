using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    /// <summary>
    /// A scriptable map that can be drawn to the screen.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class DrawableMap : ScriptableMap
    {
        private const string TILESET_RESOURCE_NAME = "tileset";

        private Image tileset;

        public DrawableMap()
            : base()
        {
            tileset = new Image("Content\\" + TILESET_RESOURCE_NAME);
        }

        /// <summary>
        /// Renders the base of the map (everything below the player)
        /// at the specified coordinates.
        /// </summary>
        public void DrawBase(RenderWindow window, int xPos, int yPos)
        {
            drawLayers(tmxMap.BaseLayers, window, xPos, yPos);
            foreach (var npe in NPEs)
                npe.DrawBase(window, this, xPos, yPos);
        }

        /// <summary>
        /// Renders the top of the map (everything above the player)
        /// at the specified coordinates.
        /// </summary>
        public void DrawTop(RenderWindow window, int xPos, int yPos)
        {
            foreach (var npe in NPEs)
                npe.DrawTop(window, this, xPos, yPos);
            drawLayers(tmxMap.TopLayers, window, xPos, yPos);
        }

        private void drawLayers(List<int[][]> layers, RenderWindow window, int xPos, int yPos)
        {
			var tileSprite = new Sprite(tileset);
            int tilesize = tmxMap.TileSize;
            int rowSize = (int)tileset.Width / tilesize;

            for (int z = 0; z < layers.Count; z++)
            {
                for (int y = 0; y < layers[0].Length; y++)
                {
                    for (int x = 0; x < layers[0][0].Length; x++)
                    {
                        int tileID = layers[z][y][x];
                        if (tileID == -1)
                            continue;
						int tileX = (tileID % rowSize) * tilesize;
						int tileY = (tileID / rowSize) * tilesize;
						tileSprite.SubRect = new IntRect(tileX, tileY, tileX + tilesize, tileY + tilesize);
						tileSprite.Position = new Vector2(xPos + x * tilesize, yPos + y * tilesize);
                        window.Draw(tileSprite);
                    }
                }
            }
        }
    }
}
