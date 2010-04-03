﻿using System;
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

        private int xPos;
        private int yPos;
        private Directions direction;

        private Rectangle sourceRectangle;
        private int currentSpriteY;
        private int currentSpriteX;
        private int spriteWidth;
        private int spriteHeight;

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

        /// <summary>
        /// The Player constructor
        /// </summary>
        /// <param name="xPos">The starting x-position</param>
        /// <param name="yPos">The starting y-position</param>
        /// <param name="tx">The character image</param>
        public Player(int xPos, int yPos, Texture2D tx)
        {
            this.xPos = xPos;
            this.yPos = yPos;
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
            currentSpriteY = 2;
            currentSpriteX = 0;
            spriteHeight =40;
            spriteWidth = 35;
            
            accuracy = 100;
        }

        public Texture2D Texture
        {
            get { return texture; }
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
            if (x > 0)
            {
                currentSpriteY = 1;
            }
            if (x < 0)
            {
                currentSpriteY = 3;
            }
            if (y > 0)
            {
                currentSpriteY = 2;
            }
            if (y < 0)
            {
                currentSpriteY = 0;
            }
            
            xPos += x;
            yPos += y;
        }

        public void DrawForOverworld(SpriteBatch spriteBatch, Map map, int x, int y)
        {
            sourceRectangle = new Rectangle(currentSpriteX * spriteWidth, currentSpriteY * spriteHeight, spriteWidth, spriteHeight);

            spriteBatch.Draw(texture, new Vector2(x - 2 + xPos * map.TileSize, y - 8 + yPos * map.TileSize), sourceRectangle, Color.White);
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
