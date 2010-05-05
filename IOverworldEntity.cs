using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    /// <summary>
    /// An interface for entities that can be drawn on the overworld.
    /// </summary>
    interface IOverworldEntity
    {
        void DrawForOverworld(RenderWindow window, DrawableMap map, int x, int y);
        int XPos { get; }
        int YPos { get; }
    }
}
