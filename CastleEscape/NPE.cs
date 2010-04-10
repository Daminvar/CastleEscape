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
    /// Represents a non-player entity.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class NPE : IOverworldEntity
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

        public void DrawForOverworld(SpriteBatch spriteBatch, DrawableMap map, int x, int y)
        {
            spriteBatch.Draw(texture,
                new Vector2(x + xPos * map.TileSize, y + yPos * map.TileSize), Color.White);
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
            interactFunc(player);
        }
    }
}
