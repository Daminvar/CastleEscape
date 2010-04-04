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
    /// The initial state. Allows player to start a new game,
    /// load a current game, display game info, or exit.
    /// </summary>
    class MainMenu : State
    {
        /// <summary>
        /// The X coordinate of the unselected menu items.
        /// </summary>
        private const int DEFAULT_XPOS = 520;
        /// <summary>
        /// The Y coordinate of the first item on the menu.
        /// </summary>
        private const int STARTING_YPOS = 200;
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

        public MainMenu(Game game) : base(game)
        {
            font = game.Content.Load<SpriteFont>("main-menu-font");
            background = game.Content.Load<Texture2D>("main-menu-background");
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

            if (state.IsKeyDown(Keys.Z))
            {
                if (options[selectedOption] == "New Game")
                {
                    var player = new Player(game, 2, 2);
                    var map = new Map(game);
                    map.LoadMap("testmap.js");
                    StateManager.PushState(new Overworld(game, player, map));
                }
                else if (options[selectedOption] == "Load Game")
                {
                    object[] saveFile = GameData.Load();

                    var player = (Player)saveFile[0];
                    player.LoadTexture(game);
                    var map = new Map(game);
                    map.LoadMap((string)saveFile[1]);
                    Flags.SetAllFlags((Dictionary<string, bool>)saveFile[2]);
                    StateManager.PushState(new Overworld(game, player, map));
                }
                else if (options[selectedOption] == "About")
                {
                }
                else if (options[selectedOption] == "Exit")
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
