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
    class WinState : State
    {
        Texture2D background;
        bool canPressZ;

        public WinState(Game game)
            : base(game)
        {
            background = game.Content.Load<Texture2D>("win-game");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 1;
            MediaPlayer.Play(game.Content.Load<Song>("win-song"));
            canPressZ = false;
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            if (state.IsKeyUp(Keys.Z))
                canPressZ = true;
            if (state.IsKeyDown(Keys.Z) && canPressZ)
                StateManager.PopState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
        }
    }
}
