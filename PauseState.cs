using System;
using System.Collections.Generic;
using System.Linq;
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


        private SpriteFont font;

        public PauseState(Game game, Player player)
            : base(game)
        {
            transparent = true;
            height = game.GraphicsDevice.Viewport.Height;
            font = game.Content.Load<SpriteFont>("hud-font");
            this.player = player;

        }

        public override void Update(GameTime gameTime)
        {
            StateManager.PushState(new ItemState(game, player, false));
        }

        //Displays stats when pause state is pushed on to screen
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Attack: " + player.Attack +
                                        "\nDefense: " + player.Defense +
                                        "\nSpeed: " + player.Speed +
                                        "\nMagic Atk: " + player.MagicAtk +
                                        "\nExp: " + player.Exp + " / " + player.ExpToLevel,
                                        new Vector2(647.0f, (float)((height * 20 / 100) + 30)), Color.WhiteSmoke);
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
