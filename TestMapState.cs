using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    /// <summary>
    /// Tests the map state.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class TestMapState : State
    {
        private DrawableMap map;

        public TestMapState() : base()
        {
            map = new DrawableMap();
            map.LoadMap("testmap.js");
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        public override void Update(Clock clock, Input input)
        {
            if (input.IsKeyDown(KeyCode.Escape))
                StateManager.PopState();
        }

        public override void Draw(RenderWindow window)
        {
            map.DrawBase(window, 0, 0);
            map.DrawTop(window, 0, 0);
        }
    }
}
