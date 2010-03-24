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
    class TestMapState : State
    {
        private Map map;
        private SpriteFont font;

        public TestMapState(Game game) : base(game) { }

        public override void Initialize()
        {
            /*
            map = new Map();
            map.LoadMap("Content/maps/testmap.tmx");
            */
            font = game.Content.Load<SpriteFont>("UI_Font");
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                StateManager.PopState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Testing the state manager",
                new Vector2(200, 200), Color.Black);
        }
    }
}
