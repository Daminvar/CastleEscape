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
    class StateManager
    {
        private static List<State> states;

        /// <summary>
        /// Initialize the state manager
        /// </summary>
        public static void Initialize()
        {
            states = new List<State>();
        }

        /// <summary>
        /// Updates the top state. Called every frame.
        /// </summary>
        public static void Update()
        {
            if (states.Count != 0)
                states[states.Count - 1].Update();
        }

        /// <summary>
        /// Draws the top state.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch object to use for drawing.</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (states.Count != 0)
                states[states.Count - 1].Draw(spriteBatch);
        }

        /// <summary>
        /// Adds a new state.
        /// </summary>
        /// <param name="newState"></param>
        public static void PushState(State newState)
        {
            if (states.Count != 0)
                states[states.Count - 1].Pause();

            newState.Initialize();
            states.Add(newState);
        }

        /// <summary>
        /// Removes the top state.
        /// </summary>
        public static void PopState()
        {
            states.RemoveAt(states.Count - 1);
            if (states.Count != 0)
                states[states.Count - 1].Resume();
        }

        public static bool IsEmpty()
        {
            return states.Count == 0;
        }
    }
}
