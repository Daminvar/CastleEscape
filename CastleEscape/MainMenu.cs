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
    class MainMenu : State
    {
        private const int DEFAULT_XPOS = 520;
        private const int STARTING_YPOS = 250;
        private static string[] options = {
            "New Game",
            "Load Game",
            "About",
            "Exit",
        };

        private SpriteFont font;
        private Texture2D background;
        private int selectedOption = 0;
        private float defaultSpacing;
        private float selectedSpacing;
        private bool canMove;

        public MainMenu(Game game) : base(game) { }

        public override void Initialize()
        {
            font = game.Content.Load<SpriteFont>("main menu font");
            background = game.Content.Load<Texture2D>("main menu background");
            defaultSpacing = font.Spacing;
            canMove = true;
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        public override void Update(GameTime gameTime)
        {
            selectedSpacing = (float)(defaultSpacing + Math.Sin(Math.Log(gameTime.TotalGameTime.Milliseconds)) * 5);
            handleInput();
        }

        private void handleInput()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Enter))
            {
                if (options[selectedOption] == "Exit")
                    StateManager.PopState();
            }

            if (state.IsKeyUp(Keys.Up) && state.IsKeyUp(Keys.Down))
                canMove = true;
            if (!canMove)
                return;
            if (state.IsKeyDown(Keys.Up))
            {
                selectedOption = (selectedOption - 1) % options.Length;
                canMove = false;
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                selectedOption = (selectedOption + 1) % options.Length;
                canMove = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            for (int i = 0; i < options.Length; i++)
            {
                var pos = new Vector2(DEFAULT_XPOS, STARTING_YPOS + i * font.LineSpacing);
                if (i == selectedOption)
                {
                    pos.X += 2 * selectedSpacing;
                    font.Spacing = selectedSpacing;
                }
                else
                    font.Spacing = defaultSpacing;
                spriteBatch.DrawString(font, options[i], pos, Color.Black);
            }
        }
    }
}
