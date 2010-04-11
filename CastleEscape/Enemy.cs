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
    class Enemy : IBattleCharacter
    {
        // speed varies on type of enemy
        private int speed;
        private int attack;
        private int health;
        private int defense;

        Texture2D enemyTexture;



        public Enemy(Texture2D tx)
        {
            enemyTexture = tx;
        }

        public int Health
        {
            get { return health; }
            set { health = value; }

        }

        public int Defense
        {
            get { return defense; }
            set { defense = value; }

        }

        public int Speed
        {
            get { return speed; }
        }

        public int HealthAfterCombat(IBattleCharacter player)
        {
            int newHealth = player.Health;
            if (player.Defense < attack)
            {
                newHealth -= attack - player.Defense;
            }

            return newHealth;
        }

        //Checks if enemy is dead
        public bool IsDead()
        {
            return health <= 0;
        }

        public void DrawForBattle(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(enemyTexture, new Vector2(x, y), Color.White);
        }
    }
}
