using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

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

        private Font font;
        private Image background;
        private TextMenu menu;

        public MainMenu()
            : base()
        {
            font = Font.DefaultFont; //TODO fix
            background = ContentManager.LoadImage("main-menu-background");
            menu = new TextMenu(font, options);
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
            menu.IsFinished = false;
        }

        public override void Update(Clock clock, Input input)
        {
            menu.Update(clock, input);

            if (!menu.IsFinished)
                return;

            string selectedOption = options[menu.SelectedOption];

            if (selectedOption == "New Game")
            {
                Flags.SetAllFlags(new Dictionary<string, bool>());
                var player = new Player(0, 9);
                var map = new DrawableMap();
                map.LoadMap("dungeon_1.js");
                StateManager.PushState(new Overworld(player, map));
                StateManager.PushState(new Dialogue("Jordan: ...Ugh...|(Wh... where am I...?)|(So... hungry...)||???: What? How are you still conscious?!||Jordan: (Woah! Where is that voice coming from?!)||???: You've been lying here without food for a week! I was sure you'd be dead by now!!||Jordan: Who's there?|Ludovic: I'm Ludovic, a demon, and I've taken over your body.|I kind of was hoping you were a bit more DEAD, though...||Jordan: Gee, thanks...|Ludovic: You don't have to talk aloud, you know. I can hear your thoughts. And that guard over there is looking suspicious.|Anyway, we have to get out of this castle.||Jordan: (What is going on here?!)"));
            }
            else if (selectedOption == "Load Game")
            {
                object[] saveFile = GameData.Load();

                if (saveFile == null)
                {
                    StateManager.PushState(new Dialogue("Save file could not be loaded."));
                    return;
                }

                var player = (Player)saveFile[0];
                player.LoadTexture();
                Flags.SetAllFlags((Dictionary<string, bool>)saveFile[2]);
                var map = new DrawableMap();
                map.LoadMap((string)saveFile[1]);
                StateManager.PushState(new Overworld(player, map));
            }
            else if (selectedOption == "About")
            {
                StateManager.PushState(new AboutState());
            }
            else if (selectedOption == "Exit")
                StateManager.PopState();
        }

        public override void Draw(RenderWindow window)
        {
            var bgSprite = new Sprite(background);
            window.Draw(bgSprite);
            menu.Draw(window, DEFAULT_XPOS, DEFAULT_YPOS, Color.Black);
        }
    }
}
