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
        Texture2D enemyTexture;

        public Enemy(Texture2D tx)
        {
            enemyTexture = tx;
        }

        public int Speed
        {
            get { return speed; }
        }

        public void Attack(int hp, int def)
        {

        }

        public bool IsDead(int hp)
        {
            return false;
        }

        public void DrawForBattle(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(enemyTexture, new Vector2(x, y), Color.White);
        }
    }
}
