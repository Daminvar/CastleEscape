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
        private const int ATTACK_RANGE = 3;
        // speed varies on type of enemy
        private string name;
        private int speed;
        private int attack;
        private int health;
        private int defense;
        private int exp;
        private Item[] items;
        private Random rand;

        Texture2D enemyTexture;
            
        public Enemy(Texture2D tx)
        {
            enemyTexture = tx;
            speed = 0;
            attack = 2;
            defense = 1;
            health = 100;
            rand = new Random();
        }

        public Enemy Clone()
        {
            var enemy = new Enemy(enemyTexture);
            enemy.name = name;
            enemy.speed = speed;
            enemy.attack = attack;
            enemy.health = health;
            enemy.defense = defense;
            enemy.exp = exp;
            enemy.Items = items != null ? (Item[])items.Clone() : null;
            return enemy;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
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
            set { health = value; }
        }

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

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

        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }

        public Item[] Items
        {
            get { return items; }
            set { items = value; }
        }

        public int HealthAfterCombat(IBattleCharacter player)
        {
            int randAttack = rand.Next(attack - ATTACK_RANGE, attack + ATTACK_RANGE + 1);
            int newHealth = player.Health;
            if (player.Defense < randAttack)
            {
                newHealth -= randAttack - player.Defense;
            }
            else
            {
                newHealth -= 1; // Always lose at least 1 HP.
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

        public override string ToString()
        {
            return string.Format("<Enemy> Name: {0}, Health: {1}, Defense: {2}, Exp: {3}", name, health, defense, exp);
        }
    }
}
