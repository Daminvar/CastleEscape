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
    class AboutState : State
    {
        private Texture2D background;
        private SpriteFont font;
        private string credits;

        public AboutState(Game game)
            : base(game)
        {
            credits = "Credits - Press 'Esc' to exit"
                + "\nAuthors:"
                + "\nDennis Honeyman"
                + "\nMatt Munns"
                + "\nAllyson Sadwin"
                + "\nChristina Cruz";

            background = game.Content.Load<Texture2D>("main-menu-background");
            font = game.Content.Load<SpriteFont>("test-font");
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                StateManager.PopState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(font, credits, new Vector2(500, 100), Color.Black);
        }
    }
}
