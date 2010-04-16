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
    class TestItemState : State
    {
        public TestItemState(Game game) : base(game)
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
            var player = new Player(game, 0, 0);
            player.Items.Add(new Item("Bottle of Mead", "A delicious bottle of mead. HP+50,MP+80", 50, 80));
            player.Items.Add(new Item("Can of Soda", "A delicious can of soda. HP+50,MP+80", 50, 80));

            StateManager.PushState(new ItemState(game, player));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
