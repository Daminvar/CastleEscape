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
    /// A test class to make sure Dialogue works.
    /// 
    /// Authors: ??
    /// </summary>
    class TestDialogueState : State
    {
        // You will need a Dialogue and a SpriteFont.
        private Dialogue dlog;
        private SpriteFont font;

        public TestDialogueState(Game game) : base(game)
        {
            // Initialize the dialogue by passing in a message and a game
            dlog = new Dialogue(game, "Hello out there|Does this work?|IT'S BECAUSE OF YOU THERE'S A GIANT IN OUR MIDST AND MY WIFE IS DEAD BUT IT ISN'T MY FAULT I WAS GIVEN THOSE BEANS YOU PERSUADED ME TO TRADE AWAY MY COW FOR BEANS|something else|whaaat");
            font = game.Content.Load<SpriteFont>("main menu font");
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        /// <summary>
        /// Calls the Update method in Dialogue.
        /// </summary>
        /// <param name="gameTime">The game time to be passed in</param>
        public override void Update(GameTime gameTime)
        {
            dlog.Update(gameTime);
        }

        /// <summary>
        /// Calls the Draw method in Dialogue
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to be passed in</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            dlog.Draw(spriteBatch);
        }
    }
}
