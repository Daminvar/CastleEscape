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
        private Vector2 position;
        private Texture2D texture;

        public Player(Vector2 pos, Texture2D tx)
        {
            position = pos;
            texture = tx;
        }

        public Texture2D Texture
        {
            get { return texture; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public void Move(float x, float y)
        {
            position.X += x;
            position.Y += y;
        }

        public void DrawForOverworld(SpriteBatch spriteBatch)
        {
            
        }
    }
}
