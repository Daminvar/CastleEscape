using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    class Enemy : IBattleCharacter
    {
        // speed varies on type of enemy
        private string name;
        private int speed;
        private int attack;
        private int health;
        private int defense;
        private int exp;
        private Item[] items;

        Image enemyTexture;

        public Enemy(Image tx)
        {
            enemyTexture = tx;
            speed = 0;
            attack = 2;
            defense = 1;
            health = 100;
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

        public void DrawForBattle(RenderWindow window, int x, int y)
        {
			var sprite = new Sprite(enemyTexture);
			sprite.Position = new Vector2(x, y);
			window.Draw(sprite);
        }

        public override string ToString()
        {
            return string.Format("<Enemy> Name: {0}, Health: {1}, Defense: {2}, Exp: {3}", name, health, defense, exp);
        }
    }
}
