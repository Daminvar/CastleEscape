using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    /// <summary>
    /// A test class to make sure Dialogue works.
    /// 
    /// Authors: ??
    ///     Allyson Sadwin
    /// </summary>
    class TestDialogueState : State
    {
        // You will need a Dialogue and a SpriteFont.
        private Dialogue dlog;
        private Font font;

        public TestDialogueState() : base()
        {
            // Initialize the dialogue by passing in a message and a game
            dlog = new Dialogue("Hello out there|Does this work?|IT'S BECAUSE OF YOU THERE'S A GIANT IN OUR MIDST AND MY WIFE IS DEAD BUT IT ISN'T MY FAULT I WAS GIVEN THOSE BEANS YOU PERSUADED ME TO TRADE AWAY MY COW FOR BEANS|something else|whaaat");
            font = Font.DefaultFont; //TODO fix
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
        public override void Update(Clock clock, Input input)
        {
            dlog.Update(clock, input);
        }

        /// <summary>
        /// Calls the Draw method in Dialogue
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to be passed in</param>
        public override void Draw(RenderWindow window)
        {
            dlog.Draw(window);
        }
    }
}
