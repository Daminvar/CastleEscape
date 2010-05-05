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
    /// Tests the map state.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class TestMapState : State
    {
        private DrawableMap map;

        public TestMapState(Game game) : base(game)
        {
            map = new DrawableMap(game);
            map.LoadMap("testmap.js");
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                StateManager.PopState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            map.DrawBase(spriteBatch, 0, 0);
            map.DrawTop(spriteBatch, 0, 0);
        }
    }
}
