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
    class TestStoreState : State
    {
        public TestStoreState(Game game)
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
            Player pl = new Player(game, 0, 0);
            Item[] inventory = new Item[2];
            inventory[0] = new Item("Bottle of Mead", "A delicious bottle of mead. HP+50,MP+80", 50, 80);
            inventory[0].Cost = 50;
            inventory[1] = new Item("Can of Soda", "A delicious can of soda. HP+50,MP+80", 50, 80);
            inventory[1].Cost = 35;

            StateManager.PushState(new Store(game, pl, inventory));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
