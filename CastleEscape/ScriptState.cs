using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    class ScriptState : State
    {
        private Thread scriptThread;

        public ScriptState(Game game, Thread thread)
            : base(game)
        {
            scriptThread = thread;
            transparent = true;
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (!scriptThread.IsAlive)
                StateManager.PopState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
