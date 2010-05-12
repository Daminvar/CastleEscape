using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// A map that has an associated script.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class ScriptableMap
    {
        private delegate Item NewItemDelegate(string name, string description, double healthBonus, double manaBonus, double cost);
        private delegate Enemy NewEnemyDelegate(string textureName, string enemyName, double health,
            double attack, double defense, double speed, double exp, ArrayList items);
        private const string MAP_DIRECTORY = "Content\\maps\\";

        protected Game game;
        protected TMXMap tmxMap;
        protected List<NPE> NPEs;
        protected object scriptLock = new object();

        private string scriptFilename;
        private string eastMapFilename, westMapFilename, northMapFilename, southMapFilename;
        private string tmxMapFilename;
        private string mapName;
        private Texture2D battleTexture;
        private Song overworldMusic;
        private Song randomBattleMusic;
        private List<Enemy> randomEncounters;
        private Random rand;

        /// <summary>
        /// The width of the map in tiles.
        /// </summary>
        public int MapWidth
        {
            get
            {
                lock (scriptLock)
                    return tmxMap.MapWidth;
            }
        }

        /// <summary>
        /// The height of the map in tiles.
        /// </summary>
        public int MapHeight
        {
            get
            {
                lock (scriptLock)
                    return tmxMap.MapHeight;
            }
        }

        /// <summary>
        /// The size of the individual tiles (in pixels).
        /// </summary>
        public int TileSize
        {
            get
            {
                lock (scriptLock)
                    return tmxMap.TileSize;
            }
        }

        /// <summary>
        /// The name of the current map.
        /// </summary>
        public string MapName
        {
            get
            {
                lock (scriptLock)
                    return mapName;
            }
        }

        public Texture2D BattleTexture
        {
            get
            {
                lock (scriptLock)
                    return battleTexture;
            }
        }

        public Song OverworldMusic
        {
            get
            {
                lock (scriptLock)
                    return overworldMusic;
            }
        }

        public Song RandomBattleMusic
        {
            get
            {
                lock (scriptLock)
                    return randomBattleMusic;
            }
        }

        public enum Directions
        {
            North, South, East, West
        }

        public ScriptableMap(Game game)
        {
            this.game = game;
            tmxMap = new TMXMap();
            rand = new Random();
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
            lock (scriptLock)
            {
                parseScriptFile(filename);
                tmxMap.ParseTMXFile(MAP_DIRECTORY + tmxMapFilename);
            }
        }

        /// <summary>
        /// Reloads the current map.
        /// </summary>
        public void ReloadMap()
        {
            loadMapAndScript(scriptFilename);
        }

        /// <summary>
        /// Changes the map by loading the correct map
        /// file for the specified direction.
        /// </summary>
        /// <param name="direction">The direction to use</param>
        public bool ChangeMap(Directions direction)
        {
            string filename = null;
            if (direction == Directions.East) filename = eastMapFilename;
            if (direction == Directions.West) filename = westMapFilename;
            if (direction == Directions.North) filename = northMapFilename;
            if (direction == Directions.South) filename = southMapFilename;

            if (filename != null)
            {
                loadMapAndScript(filename);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the NPE at the specified location
        /// </summary>
        /// <returns>The NPE, or null if there isn't one at that position.</returns>
        public NPE GetNPEAt(int x, int y)
        {
            foreach (var npe in NPEs)
            {
                if (x == npe.XPos && y == npe.YPos)
                    return npe;
            }
            return null;
        }

        public Enemy GetRandomEncounter()
        {
            if (randomEncounters.Count <= 0)
                return null;

            return randomEncounters[rand.Next(0, randomEncounters.Count)].Clone();
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
            foreach (var npe in NPEs)
            {
                if (x == npe.XPos && y == npe.YPos)
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

            //Empty NPE and random encounter lists
            NPEs = new List<NPE>();
            randomEncounters = new List<Enemy>();

            //Clear battle and music attributes
            battleTexture = null;
            overworldMusic = null;
            randomBattleMusic = null;

            var engine = new Jint.JintEngine();
            engine.DisableSecurity(); //Needed so the scripts can call methods on NPE objects.
            engine.SetDebugMode(true);
            engine.SetFunction("name", new Action<string>(js_setMapName));
            engine.SetFunction("battleTexture", new Action<string>(js_setBattleTexture));
            engine.SetFunction("east", new Action<string>(js_setEastMapfile));
            engine.SetFunction("west", new Action<string>(js_setWestMapfile));
            engine.SetFunction("north", new Action<string>(js_setNorthMapfile));
            engine.SetFunction("south", new Action<string>(js_setSouthMapfile));
            engine.SetFunction("mapfile", new Action<string>(js_setTmxMapfile));
            engine.SetFunction("newNPE", new Func<NPE>(js_newNPE));
            engine.SetFunction("addNPE", new Action<NPE>(js_addNPE));
            engine.SetFunction("getFlag", new Func<string, bool>(js_getFlag));
            engine.SetFunction("setFlag", new Action<string>(js_setFlag));
            engine.SetFunction("dialogue", new Action<string>(js_dialogue));
            engine.SetFunction("reloadMap", new Action(ReloadMap));
            engine.SetFunction("save", new Action<Player>(js_save));
            engine.SetFunction("newItem", new NewItemDelegate(js_newItem));
            engine.SetFunction("addRandomEncounter", new Action<Enemy>(js_addRandomEncounter));
            engine.SetFunction("newEnemy", new NewEnemyDelegate(js_newEnemy));
            engine.SetFunction("battle", new Action<Player, Enemy, string>(js_battle));
            engine.SetFunction("store", new Action<Player, ArrayList>(js_store));
            engine.SetFunction("overworldMusic", new Action<string>(js_overworldMusic));
            engine.SetFunction("randomBattleMusic", new Action<string>(js_randomBattleMusic));
            engine.SetFunction("win", new Action(js_win));
            engine.Run(File.ReadAllText(MAP_DIRECTORY + filename));
        }

        private void js_setMapName(string name)
        {
            mapName = name;
        }

        private void js_setBattleTexture(string textureName)
        {
            battleTexture = game.Content.Load<Texture2D>(textureName);
        }

        private void js_setEastMapfile(string filename)
        {
            eastMapFilename = filename;
        }

        private void js_setWestMapfile(string filename)
        {
            westMapFilename = filename;
        }

        private void js_setNorthMapfile(string filename)
        {
            northMapFilename = filename;
        }

        private void js_setSouthMapfile(string filename)
        {
            southMapFilename = filename;
        }

        private void js_setTmxMapfile(string filename)
        {
            tmxMapFilename = filename;
        }

        private void js_addNPE(NPE newNPE)
        {
            NPEs.Add(newNPE);
        }

        private bool js_getFlag(string flag)
        {
            return Flags.GetFlag(flag);
        }

        private void js_setFlag(string flag)
        {
            Flags.SetFlag(flag);
        }

        private NPE js_newNPE()
        {
            return new NPE(game);
        }

        private void js_dialogue(string text)
        {
            StateManager.Running = false;
            int currentStackSize = StateManager.StackSize;
            StateManager.PushState(new Dialogue(game, text));
            StateManager.Running = true;
            while (currentStackSize != StateManager.StackSize && currentStackSize != 0)
            {
            }
        }

        private void js_save(Player player)
        {
            player.Health = player.MaxHealth;
            player.Mana = player.MaxMana;
            GameData.Save(scriptFilename, player);
        }

        private Item js_newItem(string itemName, string description, double healthBonus, double manaBonus, double cost)
        {
            return new Item(itemName, description, (int)healthBonus, (int)manaBonus, (int)cost);
        }

        private Enemy js_newEnemy(string textureName, string enemyName, double health,
            double attack, double defense, double speed, double exp, ArrayList items)
        {
            var enemy = new Enemy(game.Content.Load<Texture2D>(textureName));
            enemy.Name = enemyName;
            enemy.Health = (int)health;
            enemy.Speed = (int)speed;
            enemy.Attack = (int)attack;
            enemy.Defense = (int)defense;
            enemy.Exp = (int)exp;
            enemy.Items = createItemArray(items);
            return enemy;
        }

        private void js_addRandomEncounter(Enemy enemy)
        {
            randomEncounters.Add(enemy);
        }

        private void js_battle(Player player, Enemy enemy, string song)
        {
            StateManager.Running = false;
            int currentStackSize = StateManager.StackSize;
            Song battleSong = game.Content.Load<Song>(song);
            StateManager.PushState(new Battle(game, battleTexture, battleSong, player, enemy, false));
            StateManager.Running = true;
            while (currentStackSize != StateManager.StackSize && currentStackSize != 0)
            {
            }
            if (player.IsDead())
                Thread.CurrentThread.Abort();
        }

        private void js_store(Player player, ArrayList itemsArrayList)
        {
            StateManager.Running = false;
            int currentStackSize = StateManager.StackSize;
            Item[] items = null;
            if (itemsArrayList != null)
                items = createItemArray(itemsArrayList);
            StateManager.PushState(new Store(game, player, items));
            StateManager.Running = true;
            while (currentStackSize != StateManager.StackSize && currentStackSize != 0)
            {
            }
        }

        private Item[] createItemArray(ArrayList itemArrayList)
        {
            if (itemArrayList == null)
                return null;
            Item[] items = new Item[itemArrayList.Count];
            for (int i = 0; i < items.Length; i++)
                items[i] = (Item)itemArrayList[i];
            return items;
        }

        private void js_overworldMusic(string song)
        {
            try
            {
                overworldMusic = game.Content.Load<Song>(song);
            }
            catch (Exception)
            {
            }
        }

        private void js_randomBattleMusic(string song)
        {
            try
            {
                randomBattleMusic = game.Content.Load<Song>(song);
            }
            catch (Exception)
            {
            }
        }

        private void js_win()
        {
            StateManager.Running = false;
            StateManager.PopAllStates();
            StateManager.PushState(new MainMenu(game));
            StateManager.PushState(new WinState(game));
            StateManager.Running = true;
        }
    }
}
