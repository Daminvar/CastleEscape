using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    /// <summary>
    /// Will draw a pause state 
    /// !!!!!!!!!!!!!!!
    /// CHANGE THE FONT !!
    /// !!!!!!!!!!!!
    /// 
    /// Authors:
    ///         Matt Munns
    /// </summary>
    class PauseState : State
    {
        private int height;
        Player player;


        private Font font;

        public PauseState(Player player)
            : base()
        {
            transparent = true;
            height = 480; //TODO fix
            font = Font.DefaultFont; //TODO fix
            this.player = player;

        }

        public override void Update(Clock clock, Input input)
        {
            StateManager.PushState(new ItemState(player, false));
        }

        //Displays stats when pause state is pushed on to screen
        public override void Draw(RenderWindow window)
        {
            var pauseString = new String2D("Attack: " + player.Attack +
                                        "\nDefense: " + player.Defense +
                                        "\nSpeed: " + player.Speed +
                                        "\nMagic Atk: " + player.MagicAtk +
                                        "\nExp: " + player.Exp + " / " + player.ExpToLevel, font);
            pauseString.Position = new Vector2(647.0f, (height * 20 / 100) + 30);
            pauseString.Color = Color.White;
        }

        public override void Resume()
        {
            StateManager.PopState();
        }

        public override void Pause()
        {
        }
    }
}
