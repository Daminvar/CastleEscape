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
    class TestDialogueState : State
    {
        private Dialogue dlog;
        private SpriteFont font;

        public TestDialogueState(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            dlog = new Dialogue("Hello out there|Does this work?|IT'S BECAUSE OF YOU THERE'S A GIANT IN OUR MIDST AND MY WIFE IS DEAD BUT IT ISN'T MY FAULT I WAS GIVEN THOSE BEANS YOU PERSUADED ME TO TRADE AWAY MY COW FOR BEANS|something else|whaaat", game);
            font = game.Content.Load<SpriteFont>("fonts\\fixedsys");
            dlog.Initialize();

        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        public override void Update()
        {
            dlog.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            dlog.Draw(spriteBatch);
        }
    }
}
