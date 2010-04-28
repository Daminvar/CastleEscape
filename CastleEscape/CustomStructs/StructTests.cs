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

            //Test matt's dictionary
            MattDataStruct<string, int> hash = new MattDataStruct<string, int>();
            hash.add("anything", 5);
            hash.add("something", 10);
            hash.add("food", 10);
            Console.WriteLine( hash["anything"]);
            Console.WriteLine(hash["something"]);
            Console.WriteLine(hash["food"]);


        }
    }
}
