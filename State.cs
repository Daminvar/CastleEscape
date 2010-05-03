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
    /// Represents a game state.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    abstract class State
    {
        protected Game game;
        protected bool transparent;

        public State(Game game)
        {
            this.game = game;
            transparent = false;
        }

        public bool Transparent
        {
            get { return transparent; }
        }

        public abstract void Pause();
        public abstract void Resume();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
