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

        public TestMapState(Game game) : base(game) { }

        public override void Initialize()
        {
            map = new Map(game);
            map.LoadMap("testmap.tmx");
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
