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
    class Player : IOverworldEntity
    {
        // create a sprite for that
        //private Vector2 position;
        private Texture2D texture;

        private int x;
        private int y;
        private Map map;

        public Player(int xPos, int yPos, Texture2D tx)
        {
            x = xPos;
            y = yPos;
            texture = tx;
        }

        public Texture2D Texture
        {
            get { return texture; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public void Move(int x2, int y2)
        {
            x += x2;
            y += y2;
        }

        public void DrawForOverworld(SpriteBatch spriteBatch)
        {
            
        }
    }
}
