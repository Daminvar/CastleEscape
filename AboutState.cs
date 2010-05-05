using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    class AboutState : State
    {
        private Image background;
        private Font font;
        private string credits;

        public AboutState()
            : base()
        {
            credits = "Credits - Press 'Esc' to exit"
                + "\nAuthors:"
                + "\nDennis Honeyman"
                + "\nMatt Munns"
                + "\nAllyson Sadwin"
                + "\nChristina Cruz";

            background = ContentManager.LoadImage("main-menu-background");
            font = Font.DefaultFont; //TODO fix
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        public override void Update(Clock clock, Input input)
        {
            if (input.IsKeyDown(KeyCode.Escape))
                StateManager.PopState();
        }

        public override void Draw(RenderWindow window)
        {
			var bgSprite = new Sprite(background);
			var text = new String2D(credits, font);
			text.Position = new Vector2(500, 100);
			window.Draw(bgSprite);
			window.Draw(text);
        }
    }
}
