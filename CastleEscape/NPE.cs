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
    class NPE : IOverworldEntity
    {
        private Action interactFunc;

        public void DrawForOverworld(SpriteBatch spriteBatch)
        {
            //TODO
        }

        public void SetInteractFunc(Action func)
        {
            interactFunc = func;
        }

        public void Interact()
        {
        }
    }
}
