using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CastleEscape
{
    /// <summary>
    /// Used for saving and loading games.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class GameData
    {
        private const string SAVE_FILE_LOCATION = "save.bin";
        /// <summary>
        /// Saves using the .NET serialization libraries
        /// Saved file is an array containing...
        /// [player object, current map, flags]
        /// </summary>
        /// <param name="currentMapName"></param>
        /// <param name="player"></param>
        public static void Save(string currentMapName, Player player)
        {
            var saveFile = new object[] {
                player, currentMapName, Flags.GetAllFlags(),
            };
            var formatter = new BinaryFormatter();
            var stream = new FileStream(SAVE_FILE_LOCATION, FileMode.Create);
            formatter.Serialize(stream, saveFile);
            stream.Close();
        }

        public static object[] Load()
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(SAVE_FILE_LOCATION, FileMode.Open);
            return (object[])formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
