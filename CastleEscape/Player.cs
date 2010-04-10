using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Represents the player.
    /// 
    /// Authors: 
    ///     Dennis Honeyman
    ///     Matt Munns
    ///     Allyson Sadwin
    ///     
    /// </summary>
    [Serializable]
    class Player : IOverworldEntity, IBattleCharacter
    {
        private const string PLAYER_OW_TEXTURE = "player-spritesheet";
        // create a sprite for that
        //private Vector2 position;
        [NonSerialized] private Texture2D overworldTexture;

        private const string PLAYER_BATTLE_TEXTURE = "orb-of-saving";
        [NonSerialized] private Texture2D battleTexture;

        private int xPos;
        private int yPos;
        private Directions direction;

        private Rectangle sourceRectangle;
        private int currentSpriteY;
        private int currentSpriteX;
        private int spriteWidth;
        private int spriteHeight;
        private int pixelX;
        private int pixelY;

        public enum Directions
        {
            North, South, East, West
        }

        public Directions Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public int CurrentSpriteX
        {
            get { return currentSpriteX; }
            set { currentSpriteX = value; }
        }

        // player attributes
        private int speed;
        private int maxHealth;
        private int health;
        private int attack;
        private int defense;
        private int level;
        private int exp;
        private int maxMana;
        private int mana;
        private int magicAtk;
        private int gold;


        private int modX;
        private int modY;

        public int ModX
        {
            get { return modX; }
            set { modX = value; }
        }

        public int ModY
        {
            get { return modY; }
            set { modY = value; }
        }

        public int PixelX
        {
            get { return pixelX; }
            set { pixelX = value; }
        }

        public int PixelY
        {
            get { return pixelY; }
            set { pixelY = value; }
        }

        // attribute for move accuracy
        private int accuracy;

        public int Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        public int MaxHealth
        {
            get { return maxHealth; }
        }

        public int Health
        {
            get { return health; }
        }

        public int MaxMana
        {
            get { return maxMana; }
        }

        public int Mana
        {
            get { return mana; }
        }

        public int Gold
        {
            get { return gold; }
        }

        public int Level
        {
            get { return level; }
        }

        public int Speed
        {
            get { return speed; }
        }

        /// <summary>
        /// The Player constructor
        /// </summary>
        /// <param name="xPos">The starting x-position</param>
        /// <param name="yPos">The starting y-position</param>
        public Player(Game game, int xPos, int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            
            LoadTexture(game);

            // the level 1 attributes of a player
            level = 1;
            exp = 0;
            maxHealth = 60;
            health = 60;
            defense = 1;
            speed = 2;
            attack = 10;
            maxMana = 10;
            mana = 10;
            magicAtk = 8;
            currentSpriteY = 2;
            currentSpriteX = 1;
            spriteHeight = 40;
            spriteWidth = 35;
            
            accuracy = 100;
            gold = 0;
        }

        public void LoadTexture(Game game)
        {
            overworldTexture = game.Content.Load<Texture2D>(PLAYER_OW_TEXTURE);
            battleTexture = game.Content.Load<Texture2D>(PLAYER_BATTLE_TEXTURE);
        }

        public int XPos
        {
            get { return xPos; }
        }

        public int YPos
        {
            get { return yPos; }
        }

        /// <summary>
        /// Moves the character.
        /// </summary>
        /// <param name="x2">The number of spaces to be moved in the X direction. Positive moves right, negative moves left.</param>
        /// <param name="y2">The number of spaces to be moved in the Y direction. Positive moves down, negative moves up.</param>
        public void Move(int x, int y)
        {
            xPos += x;
            yPos += y;

            pixelX = xPos * 32;
            pixelY = yPos * 32;
        }

        public void DrawForOverworld(SpriteBatch spriteBatch, DrawableMap map, int x, int y)
        {
            if (direction == Player.Directions.West)
            {
                currentSpriteY = 3;
            }
            else if (direction == Player.Directions.East)
            {
                currentSpriteY = 1;
            }
            else if (direction == Player.Directions.South)
            {
                currentSpriteY = 2;
            }
            else
            {
                currentSpriteY = 0;
            }
            
            sourceRectangle = new Rectangle(currentSpriteX * spriteWidth, currentSpriteY * spriteHeight, spriteWidth, spriteHeight);

            spriteBatch.Draw(overworldTexture, new Vector2(x - 3 + xPos * map.TileSize - modX, y - 8 + yPos * map.TileSize - modY), sourceRectangle, Color.White);
        }

        public void DrawForBattle(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(battleTexture, new Vector2(x, y), Color.White);
        }

        public void Attack(int enemyDef, int enemyHP)
        {
            // create a random number to see if the attack hit!
            Random rgen = new Random();
            int didHit = rgen.Next(1, 101);
            if (didHit <= accuracy)
            {
                if (accuracy == 100)
                {
                    if ((int)((attack / 2) - enemyDef) > 0)
                    {
                        enemyHP -= ((int)((attack / 2) - enemyDef));
                    }
                }
                if (accuracy == 80)
                {
                    if ((attack - enemyDef) > 0)
                    {
                        enemyHP -= (attack - enemyDef);
                    }
                }
                if (accuracy == 55)
                {
                    if (((attack * 2) - enemyDef) > 0)
                    {
                        enemyHP -= ((attack * 2) - enemyDef);
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the Player is dead
        /// </summary>
        /// <param name="hp">The Player's current HP.</param>
        /// <returns>True if the Player is dead; false if not.</returns>
        public bool IsDead(int hp)
        {
            if (hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
