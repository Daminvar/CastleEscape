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
    class Player : IOverworldEntity, IBattleCharacter
    {
        // create a sprite for that
        //private Vector2 position;
        private Texture2D texture;

        private int x;
        private int y;

        // player attributes
        private int speed;
        private int health;
        private int attack;
        private int defense;
        private int level;
        private int exp;
        private int mana;
        private int magicAtk;

        // attribute for move accuracy
        private int accuracy;

        public int Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        // I didn't know how else to make it draw itself correctly without making a constant for tilesize. I don't really think 
        // there's a need for a Map object in the Player class, but if you think differently, feel free to change it.
        private const int TILE_SIZE = 32;

        /// <summary>
        /// The Player constructor
        /// </summary>
        /// <param name="xPos">The starting x-position</param>
        /// <param name="yPos">The starting y-position</param>
        /// <param name="tx">The character image</param>
        public Player(int xPos, int yPos, Texture2D tx)
        {
            x = xPos;
            y = yPos;
            texture = tx;

            // the level 1 attributes of a player
            level = 1;
            exp = 0;
            health = 60;
            defense = 1;
            speed = 2;
            attack = 10;
            mana = 10;
            magicAtk = 8;

            accuracy = 100;
        }

        public Texture2D Texture
        {
            get { return texture; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        /// <summary>
        /// Moves the character.
        /// </summary>
        /// <param name="x2">The number of spaces to be moved in the X direction. Positive moves right, negative moves left.</param>
        /// <param name="y2">The number of spaces to be moved in the Y direction. Positive moves down, negative moves up.</param>
        public void Move(int x2, int y2)
        {
            x += x2;
            y += y2;
        }

        public void DrawForOverworld(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2((float)x * TILE_SIZE, (float)y * TILE_SIZE), Color.White);
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
