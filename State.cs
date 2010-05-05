using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    /// <summary>
    /// Represents a game state.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    abstract class State
    {
        protected bool transparent;

        public State()
        {
            transparent = false;
        }

        public bool Transparent
        {
            get { return transparent; }
        }

        public abstract void Pause();
        public abstract void Resume();
        public abstract void Update(Clock clock, Input input);
        public abstract void Draw(RenderWindow window);
    }
}
