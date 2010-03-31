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
        private Directions direction;

        public enum Directions
        {
            North, South, East, West
        }

        public Directions Direction
        {
            get { return direction; }
            set { direction = value; }
        }

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

        public int XPos
        {
            get { return x; }
        }

        public int YPos
        {
            get { return y; }
        }

        public void Move(int x2, int y2)
        {
            x += x2;
            y += y2;
        }

        public void DrawForOverworld(SpriteBatch spriteBatch, Map map, int x, int y)
        {
            
        }
    }
}
