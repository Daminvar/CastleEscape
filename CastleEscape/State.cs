using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleEscape
{
    abstract class State
    {
        abstract void Initialize();
        abstract void Pause();
        abstract void Resume();
        abstract void Update();
        abstract void Draw();
    }
}
