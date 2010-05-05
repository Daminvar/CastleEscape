using System;
using System.Collections.Generic;
using System.Text;

namespace CastleEscape
{
    /// <summary>
    /// For events.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class Flags
    {
        private static Dictionary<string, bool> flags = new Dictionary<string, bool>();

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

        /// <summary>
        /// For saving.
        /// </summary>
        /// <returns>The dictionary of flags</returns>
        public static Dictionary<string, bool> GetAllFlags()
        {
            return flags;
        }

        /// <summary>
        /// For loading.
        /// </summary>
        /// <param name="dict">The dictionary of flags.</param>
        public static void SetAllFlags(Dictionary<string, bool> dict)
        {
            flags = dict;
        }
    }
}
