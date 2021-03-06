﻿using System;
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
    /// Manages the game states.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    static class StateManager
    {
        private static List<State> states;
        private static bool running;


        /// <summary>
        /// The number of states on the stack.
        /// </summary>
        public static int StackSize
        {
            get { return states.Count; }
        }

        public static bool Running
        {
            get { return running; }
            set { running = value; }
        }

        /// <summary>
        /// Initialize the state manager
        /// </summary>
        public static void Initialize()
        {
            states = new List<State>();
            running = true;
        }

        /// <summary>
        /// Updates the top state. Called every frame.
        /// </summary>
        public static void Update(GameTime gameTime)
        {
            if (!running)
                return;

            if (states.Count != 0)
                states[states.Count - 1].Update(gameTime);
        }

        /// <summary>
        /// Draws the top state.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch object to use for drawing.</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (!running)
                return;

            if (states.Count == 0)
                return;

            drawState(spriteBatch, states.Count - 1);
        }

        private static void drawState(SpriteBatch spriteBatch, int index)
        {
            if (index < 0)
                return;
            if (states[index].Transparent)
                drawState(spriteBatch, index - 1);
            states[index].Draw(spriteBatch);
        }

        /// <summary>
        /// Adds a new state.
        /// </summary>
        /// <param name="newState"></param>
        public static void PushState(State newState)
        {
            if (states.Count != 0)
                states[states.Count - 1].Pause();

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

        /// <summary>
        /// Removes all states.
        /// </summary>
        public static void PopAllStates()
        {
            states.Clear();
        }

        public static bool IsEmpty()
        {
            return states.Count == 0;
        }
    }
}
