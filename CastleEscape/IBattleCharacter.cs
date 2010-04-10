using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        void AttackDmg(int defense, int hp);

        bool IsDead(int hp);
        
    }
}
