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
    /// <summary>
    /// An interface for entities that can be drawn on the overworld.
    /// </summary>
    interface IOverworldEntity
    {
        void DrawForOverworld(SpriteBatch spriteBatch, DrawableMap map, int x, int y);
        int XPos { get; }
        int YPos { get; }
    }


}
