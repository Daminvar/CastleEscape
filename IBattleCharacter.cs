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

        bool IsDead();

        void DrawForBattle(RenderWindow window, int x, int y);
    }
}
