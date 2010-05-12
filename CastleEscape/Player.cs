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
        private const int ATTACK_RANGE = 1;
        private const string PLAYER_OW_TEXTURE = "player-spritesheet";
        [NonSerialized]
        private Texture2D overworldTexture;
        private const string PLAYER_BATTLE_TEXTURE = "guy";
        [NonSerialized]
        private Texture2D battleTexture;

        private int xPos;
        private int yPos;
        private Directions direction;

        private Rectangle sourceRectangle;
        private int currentSpriteY;
        private int currentSpriteX;
        private int spriteWidth;
        private int spriteHeight;
        private string chosenAttack;
        private Random rand;

        private List<Item> items;

        public List<Item> Items
        {
            get { return items; }
        }

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
        private int maxMana;
        private int mana;
        private int magicAtk;
        private int gold;
        private int exp;
        private int exptolevel;
        private int accuracy;

        private int modX;
        private int modY;

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int Defense
        {
            get { return defense; }
            set { defense = value; }

        }
        public int MagicAtk
        {
            get { return magicAtk; }
            set { magicAtk = value; }
        }

        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }

        public int ExpToLevel
        {
            get { return exptolevel; }
            set { exptolevel = value; }
        }

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

        public int Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }

        public int Health
        {
            get
            {
                if (health <= 0)
                    return 0;

                else
                    return health;
            }

            set
            {

                if (value >= maxHealth)
                    health = maxHealth;

                else
                    health = value;

            }
        }

        public int MaxMana
        {
            get { return maxMana; }
            set { maxMana = value; }
        }

        public int Mana
        {
            get
            {
                if (mana <= 0)
                    return 0;
                else
                    return mana;
            }
            set
            {
                if (value >= maxMana)
                    mana = maxMana;
                else
                    mana = value;
            }
        }

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
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
            maxHealth = 100;
            health = 100;
            defense = 1;
            speed = 1;
            attack = 30;
            maxMana = 20;
            mana = 20;
            magicAtk = 20;
            currentSpriteY = 2;
            currentSpriteX = 1;
            spriteHeight = 40;
            spriteWidth = 35;
            exptolevel = 20;
            accuracy = 0;
            gold = 0;

            items = new List<Item>();
            rand = new Random();
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

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void getAccuracy(string attackType)
        {
            chosenAttack = attackType;

            if (chosenAttack == ("Light Punch"))
                accuracy = 100;

            else if (chosenAttack == ("Double Punch"))
                accuracy = 80;
            else if (chosenAttack == ("Pummel"))
                accuracy = 55;
            else if (chosenAttack == ("Soul Cannon"))
            {

                accuracy = 99;
                mana -= 1;

            }
            else if (chosenAttack == ("Mind Break"))
            {
                accuracy = 98;
                mana -= 2;
            }
        }

        public int HealthAfterCombat(IBattleCharacter enemy)
        {
            // create a random number to see if the attack hit!
            int randAttack = rand.Next(attack - ATTACK_RANGE, attack + ATTACK_RANGE + 1);
            int didHit = rand.Next(1, 101);
            int newHealth = enemy.Health;

            if (didHit <= accuracy)
            {
                if (accuracy == 100)
                {
                    if ((int)((randAttack / 2) - enemy.Defense) > 0)
                    {
                        newHealth -= ((int)((randAttack / 2) - enemy.Defense));
                    }
                }

                else if (accuracy == 80)
                {
                    if ((int)(randAttack - enemy.Defense) > 0)
                    {
                        newHealth -= (randAttack - enemy.Defense);
                    }
                }
                else if (accuracy == 55)
                {
                    if (((randAttack * 2) - enemy.Defense) > 0)
                    {
                        newHealth -= ((randAttack * 2) - enemy.Defense);
                    }
                }

                else if (accuracy == 99)
                {
                    if ((magicAtk - enemy.Defense) > 0 && magicAtk >= 2)
                    {
                        newHealth -= magicAtk - enemy.Defense;
                    }
                }
                else if (accuracy == 98)
                {
                    if ((magicAtk - enemy.Defense) > 0 && magicAtk >= 6)
                    {
                        newHealth -= magicAtk + 5 - enemy.Defense;
                    }
                }

                if (newHealth < 0)
                {
                    newHealth = 0;
                }

            }
            else
            {
                return -1;
            }
            
            return newHealth;
        }

        /// <summary>
        /// Checks if the Player is dead
        /// </summary>
        /// <returns>True if the Player is dead; false if not.</returns>
        public bool IsDead()
        {
            return health <= 0;
        }
    }
}
