using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    class TestBattleState : State
    {
        public TestBattleState()
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
            Enemy en = new Enemy(ContentManager.LoadImage("ghostie"));
            Player pl = new Player(0, 0);

            StateManager.PushState(new Battle(ContentManager.LoadImage("test-battle-background"), pl, en, true));
        }

        public override void Draw(RenderWindow window)
        {
        }
    }
}
