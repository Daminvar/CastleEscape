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
    /// 
    /// Author: Dennis Honeyman
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
        private const int DEFAULT_YPOS = 200;
        private static string[] options = {
            "New Game",
            "Load Game",
            "About",
            "Exit",
        };

        private SpriteFont font;
        private Texture2D background;
        private TextMenu menu;

        public MainMenu(Game game)
            : base(game)
        {
            font = game.Content.Load<SpriteFont>("main-menu-font");
            background = game.Content.Load<Texture2D>("main-menu-background");
            menu = new TextMenu(font, options);
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
            menu.IsFinished = false;
        }

        public override void Update(GameTime gameTime)
        {
            menu.Update(gameTime, Keyboard.GetState());

            if (!menu.IsFinished)
                return;

            string selectedOption = options[menu.SelectedOption];

            if (selectedOption == "New Game")
            {
                //dungeon_1
                Flags.SetAllFlags(new Dictionary<string, bool>());
                var player = new Player(game, 2, 9);
                var map = new DrawableMap(game);
                map.LoadMap("dungeon_1.js");
                StateManager.PushState(new Overworld(game, player, map));
                StateManager.PushState(new Dialogue(game, "Jordan: ...Ugh... (Wh... where am I...? So... hungry...)|???: <What? How are you still conscious?!>|Jordan: (Woah! Where is that voice coming from?!)|???: <You've been lying here without food for a week! I was sure you'd be dead by now!!>|Jordan: W-who's there?|Ludovic: <I'm Ludovic, a demon, and I've taken over your body. I kind of was hoping you were a bit more DEAD, though...>|Jordan: Gee, thanks...|Ludovic: <You don't have to talk aloud, you know. I can hear your thoughts. Plus, you're making that guard over there suspicious. Anyway, we have to get out of this castle.>|Jordan: (What is going on here?!)"));
            }
            else if (selectedOption == "Load Game")
            {
                object[] saveFile = GameData.Load();

                if (saveFile == null)
                {
                    StateManager.PushState(new Dialogue(game, "Save file could not be loaded."));
                    return;
                }

                var player = (Player)saveFile[0];
                player.LoadTexture(game);
                Flags.SetAllFlags((Dictionary<string, bool>)saveFile[2]);
                var map = new DrawableMap(game);
                map.LoadMap((string)saveFile[1]);
                StateManager.PushState(new Overworld(game, player, map));
            }
            else if (selectedOption == "About")
            {
                StateManager.PushState(new AboutState(game));
            }
            else if (selectedOption == "Exit")
                StateManager.PopState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            menu.Draw(spriteBatch, DEFAULT_XPOS, DEFAULT_YPOS, Color.Black);
        }
    }
}
