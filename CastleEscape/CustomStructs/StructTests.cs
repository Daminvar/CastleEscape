using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleEscape.CustomStructs
{
    class StructTests
    {
        /// <summary>
        /// For testing.
        /// </summary>
        public static void Main(string[] args)
        {
            // Test DennisArray
            Random rand = new Random();
            var array = new DennisArray<int>();
            for (int i = 0; i < 30; i++)
                array.Add(rand.Next());
            Console.WriteLine(array.Count);
            Console.WriteLine(array);
            for (int i = 0; i < 25; i++)
                array.Remove(0);
            Console.WriteLine(array.Count);
            Console.WriteLine(array);
        }
    }
}
