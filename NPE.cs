using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    /// <summary>
    /// Represents a non-player entity.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class NPE
    {
        private Action<Player> interactFunc;
        private Texture2D texture;
        private int xPos, yPos;
        private Game game;

        public NPE(Game game)
        {
            this.game = game;
        }

        public int XPos
        {
            get { return xPos; }
        }

        public int YPos
        {
            get { return yPos; }
        }

        public void DrawBase(SpriteBatch spriteBatch, ScriptableMap map, int x, int y)
        {
            if (texture == null)
                return;
            var sourceRect = new Rectangle(0, texture.Height - map.TileSize, map.TileSize, map.TileSize);
            var destRect = new Rectangle(x + xPos * map.TileSize, y + yPos * map.TileSize, map.TileSize, map.TileSize);
            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }

        public void DrawTop(SpriteBatch spriteBatch, ScriptableMap map, int x, int y)
        {
            if (texture == null)
                return;

            int renderX = x + xPos * map.TileSize;
            int renderY = y + yPos * map.TileSize - (texture.Height - map.TileSize);
            var sourceRect = new Rectangle(0, 0, map.TileSize, texture.Height - map.TileSize);
            var destRect = new Rectangle(renderX, renderY, map.TileSize, texture.Height - map.TileSize);
            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }

        public void SetPosition(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        public void SetTexture(string textureName)
        {
            texture = game.Content.Load<Texture2D>(textureName);
        }

        public void SetInteractFunc(Action<Player> func)
        {
            interactFunc = func;
        }

        public void Interact(Player player)
        {
            var thread = new Thread(new ParameterizedThreadStart(interact));
            thread.Start(player);
        }

        private void interact(object player)
        {
            interactFunc((Player)player);
        }
    }
}
