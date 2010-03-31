using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleEscape
{
    /// <summary>
    /// For events.
    /// </summary>
    class Flags
    {
        private static Dictionary<string, bool> flags = new Dictionary<string,bool>();

        public static bool GetFlag(string flagName)
        {
            try
            {
                return flags[flagName];
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public static void SetFlag(string flagName)
        {
            flags[flagName] = true;
        }
    }
}
