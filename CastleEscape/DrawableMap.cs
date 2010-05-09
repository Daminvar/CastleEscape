using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// <summary>
    /// A scriptable map that can be drawn to the screen.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class DrawableMap : ScriptableMap
    {
        private const string TILESET_RESOURCE_NAME = "tileset";

        private Texture2D tileset;

        public DrawableMap(Game game)
            : base(game)
        {
            tileset = game.Content.Load<Texture2D>(TILESET_RESOURCE_NAME);
        }

        /// <summary>
        /// Renders the base of the map (everything below the player)
        /// at the specified coordinates.
        /// </summary>
        public void DrawBase(SpriteBatch spriteBatch, int xPos, int yPos)
        {
            lock (scriptLock)
            {
                drawLayers(tmxMap.BaseLayers, spriteBatch, xPos, yPos);
                foreach (var npe in NPEs)
                    npe.DrawBase(spriteBatch, this, xPos, yPos);
            }
        }

        /// <summary>
        /// Renders the top of the map (everything above the player)
        /// at the specified coordinates.
        /// </summary>
        public void DrawTop(SpriteBatch spriteBatch, int xPos, int yPos)
        {
            lock (scriptLock)
            {
                foreach (var npe in NPEs)
                    npe.DrawTop(spriteBatch, this, xPos, yPos);
                drawLayers(tmxMap.TopLayers, spriteBatch, xPos, yPos);
            }
        }

        private void drawLayers(List<int[][]> layers, SpriteBatch spriteBatch, int xPos, int yPos)
        {
            int tilesize = tmxMap.TileSize;
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
    }
}
