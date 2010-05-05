using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    class TestStoreState : State
    {
        public TestStoreState()
            : base()
        {
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
            StateManager.PopState();
        }

        public override void Update(Clock clock, Input input)
        {
            Player pl = new Player(0, 0);
            Item[] inventory = new Item[2];
            inventory[0] = new Item("Bottle of Mead", "A delicious bottle of mead. HP+50,MP+80", 50, 80, 10);
            inventory[0].Cost = 50;
            inventory[1] = new Item("Can of Soda", "A delicious can of soda. HP+50,MP+80", 50, 80, 10);
            inventory[1].Cost = 35;

            StateManager.PushState(new Store(pl, inventory));
        }

        public override void Draw(RenderWindow window)
        {
        }
    }
}
