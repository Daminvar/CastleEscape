using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

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
        [NonSerialized]
        private Image overworldTexture;
        private const string PLAYER_BATTLE_TEXTURE = "guy";
        [NonSerialized]
        private Image battleTexture;

        private int xPos;
        private int yPos;
        private Directions direction;

        private IntRect sourceRectangle;
        private int currentSpriteY;
        private int currentSpriteX;
        private int spriteWidth;
        private int spriteHeight;
        private string chosenAttack;

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

                else if (value == 0)
                    health = 0;

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
                if (mana >= maxMana)
                    mana = maxMana;
                else if (value == 0)
                    mana = 0;
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
        public Player(int xPos, int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;

            LoadTexture();

            // the level 1 attributes of a player
            level = 1;
            exp = 0;
            maxHealth = 60;
            health = 60;
            defense = 1;
            speed = 100;
            attack = 1000;
            maxMana = 10;
            mana = 10;
            magicAtk = 8;
            currentSpriteY = 2;
            currentSpriteX = 1;
            spriteHeight = 40;
            spriteWidth = 35;
            exptolevel = 20;
            accuracy = 0;
            gold = 1000;

            items = new List<Item>();
        }


        public void LoadTexture()
        {
            overworldTexture = ContentManager.LoadImage(PLAYER_OW_TEXTURE);
            battleTexture = ContentManager.LoadImage(PLAYER_BATTLE_TEXTURE);
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

        public void DrawForOverworld(RenderWindow window, DrawableMap map, int x, int y)
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

			var playerSprite = new Sprite(overworldTexture);
			playerSprite.Position = new Vector2(x - 3 + xPos * map.TileSize - modX, y - 8 + yPos * map.TileSize - modY);
			int sourceX = currentSpriteX * spriteWidth;
			int sourceY = currentSpriteY * spriteHeight;
			playerSprite.SubRect = new IntRect(sourceX, sourceY, sourceX + spriteWidth, sourceY + spriteHeight);
			window.Draw(playerSprite);
        }

        public void DrawForBattle(RenderWindow window, int x, int y)
        {
            var sprite = new Sprite(battleTexture);
            sprite.Position = new Vector2(x, y);
            window.Draw(sprite);
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
            Random rgen = new Random();
            int didHit = rgen.Next(1, 101);
            int newHealth = enemy.Health;

            if (didHit <= accuracy)
            {
                if (accuracy == 100)
                {
                    if ((int)((attack / 2) - enemy.Defense) > 0)
                    {
                        newHealth -= ((int)((attack / 2) - enemy.Defense));
                    }
                }

                else if (accuracy == 80)
                {
                    if ((int)(attack - enemy.Defense) > 0)
                    {
                        newHealth -= (attack - enemy.Defense);
                    }
                }
                else if (accuracy == 55)
                {
                    if (((attack * 2) - enemy.Defense) > 0)
                    {
                        newHealth -= ((attack * 2) - enemy.Defense);
                    }
                }

                else if (accuracy == 99)
                {
                    if ((magicAtk - enemy.Defense) > 0 && magicAtk >= 2)
                    {
                        newHealth -= rgen.Next(2, magicAtk + 1) - enemy.Defense;
                    }
                }
                else if (accuracy == 98)
                {
                    if ((magicAtk - enemy.Defense) > 0 && magicAtk >= 6)
                    {
                        newHealth -= rgen.Next(4, magicAtk - 1) - enemy.Defense;
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
