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
    class TestBattleState : State
    {
        public TestBattleState(Game game)
            : base(game)
        {
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
            StateManager.PopState();
        }

        public override void Update(GameTime gameTime)
        {
            Enemy en = new Enemy(game.Content.Load<Texture2D>("ghostie"));
            Player pl = new Player(game, 0, 0);

            StateManager.PushState(new Battle(game, game.Content.Load<Texture2D>("test-battle-background"), pl, en, true));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
