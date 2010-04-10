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
    /// Interface for battles
    /// 
    /// Authors: 
    ///         Matt Munns
    ///     
    /// </summary>
    interface IBattleCharacter
    {
        int HealthAfterCombat(IBattleCharacter character);

        int Defense { get; }
        int Health { get; set; }

        bool IsDead(int hp);

        void DrawForBattle(SpriteBatch spriteBatch, int x, int y);
    }
}
