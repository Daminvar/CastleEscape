using System;
using System.Collections.Generic;
using System.IO;
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
    class ScriptableMap
    {
        private const string MAP_DIRECTORY = "..\\..\\..\\Content\\maps\\";

        protected Game game;
        protected TMXMap tmxMap;
        protected List<NPE> NPEs;

        private string scriptFilename;
        private string eastMapFilename, westMapFilename, northMapFilename, southMapFilename;
        private string tmxMapFilename;
        private string mapName;

        /// <summary>
        /// The width of the map in tiles.
        /// </summary>
        public int MapWidth
        {
            get { return tmxMap.MapWidth; }
        }

        /// <summary>
        /// The height of the map in tiles.
        /// </summary>
        public int MapHeight
        {
            get { return tmxMap.MapHeight; }
        }

        /// <summary>
        /// The size of the individual tiles (in pixels).
        /// </summary>
        public int TileSize
        {
            get { return tmxMap.TileSize; }
        }

        /// <summary>
        /// The name of the current map.
        /// </summary>
        public string MapName
        {
            get { return mapName; }
        }

        public enum Directions
        {
            North, South, East, West
        }

        public ScriptableMap(Game game)
        {
            this.game = game;
            tmxMap = new TMXMap();
        }

        /// <summary>
        /// Loads a map from a file.
        /// </summary>
        /// <param name="filename">The filename</param>
        public void LoadMap(string filename)
        {
            loadMapAndScript(filename);
        }

        private void loadMapAndScript(string filename)
        {
            parseScriptFile(filename);
            tmxMap.ParseTMXFile(MAP_DIRECTORY + tmxMapFilename);
        }

        /// <summary>
        /// Changes the map by loading the correct map
        /// file for the specified direction.
        /// </summary>
        /// <param name="direction">The direction to use</param>
        public void ChangeMap(Directions direction)
        {
            string filename = null;
            if (direction == Directions.East) filename = eastMapFilename;
            if (direction == Directions.West) filename = westMapFilename;
            if (direction == Directions.North) filename = northMapFilename;
            if (direction == Directions.South) filename = southMapFilename;

            if (filename != null)
            {
                loadMapAndScript(filename);
            }
        }

        /// <summary>
        /// Returns the NPE at the specified location
        /// </summary>
        /// <returns>The NPE, or null if there isn't one at that position.</returns>
        public NPE GetNPEAt(int x, int y)
        {
            foreach (var entity in NPEs)
            {
                if (x == entity.XPos && y == entity.YPos)
                    return entity;
            }
            return null;
        }

        /// <summary>
        /// Tests to see if there is a collision
        /// at the specified coordinates.
        /// </summary>
        /// <returns>"true" if there's a collision, "false" otherwise.</returns>
        public bool IsCollisionAt(int x, int y)
        {
            if (tmxMap.IsCollisionAt(x, y))
                return true;
            foreach (var entity in NPEs)
            {
                if (x == entity.XPos && y == entity.YPos)
                    return true;
            }
            return false;
        }

        private void parseScriptFile(string filename)
        {
            //Clear map script information
            mapName = "<name not set>";
            eastMapFilename = null;
            westMapFilename = null;
            northMapFilename = null;
            southMapFilename = null;
            tmxMapFilename = null;

            scriptFilename = filename;

            //Empty NPE list
            NPEs = new List<NPE>();

            var engine = new Jint.JintEngine();
            engine.DisableSecurity(); //Needed so the scripts can call methods on NPE objects.
            engine.SetDebugMode(true);
            engine.SetFunction("name", new Action<string>(setMapName));
            engine.SetFunction("east", new Action<string>(setEastMapfile));
            engine.SetFunction("west", new Action<string>(setWestMapfile));
            engine.SetFunction("north", new Action<string>(setNorthMapfile));
            engine.SetFunction("south", new Action<string>(setSouthMapfile));
            engine.SetFunction("mapfile", new Action<string>(setTmxMapfile));
            engine.SetFunction("newNPE", new Func<NPE>(newNPE));
            engine.SetFunction("addNPE", new Action<NPE>(addNPE));
            engine.SetFunction("getFlag", new Func<string, bool>(getFlag));
            engine.SetFunction("setFlag", new Action<string>(setFlag));
            engine.SetFunction("dialogue", new Action<string>(dialogue));
            engine.SetFunction("save", new Action<Player>(save));
            engine.Run(File.ReadAllText(MAP_DIRECTORY + filename));
        }

        private void setMapName(string name)
        {
            mapName = name;
        }

        private void setEastMapfile(string filename)
        {
            eastMapFilename = filename;
        }

        private void setWestMapfile(string filename)
        {
            westMapFilename = filename;
        }

        private void setNorthMapfile(string filename)
        {
            northMapFilename = filename;
        }

        private void setSouthMapfile(string filename)
        {
            southMapFilename = filename;
        }

        private void setTmxMapfile(string filename)
        {
            tmxMapFilename = filename;
        }

        private void addNPE(NPE newNPE)
        {
            NPEs.Add(newNPE);
        }

        private bool getFlag(string flag)
        {
            return Flags.GetFlag(flag);
        }

        private void setFlag(string flag)
        {
            Flags.SetFlag(flag);
        }

        private NPE newNPE()
        {
            return new NPE(game);
        }

        private void dialogue(string text)
        {
            StateManager.PushState(new Dialogue(game, text));
        }

        private void save(Player player)
        {
            GameData.Save(scriptFilename, player);
        }
    }
}
