using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    class TestItemState : State
    {
        public TestItemState() : base()
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
            var player = new Player(0, 0);
            player.Items.Add(new Item("Bottle of Mead", "A delicious bottle of mead. HP+50,MP+80", 50, 80, 10));
            player.Items.Add(new Item("Can of Soda", "A delicious can of soda. HP+50,MP+80", 50, 80, 10));

            StateManager.PushState(new ItemState(player, false));
        }

        public override void Draw(RenderWindow window)
        {
        }
    }
}
