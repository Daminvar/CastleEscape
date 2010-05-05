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
            Enemy en = new Enemy(new Image("Content\\ghostie.png"));
            Player pl = new Player(0, 0);

            StateManager.PushState(new Battle(new Image("Content\\test-battle-background.png"), pl, en, true));
        }

        public override void Draw(RenderWindow window)
        {
        }
    }
}
