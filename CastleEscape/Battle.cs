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
    class Battle : State
    {
        Player play;
        Enemy en;
        Texture2D backgroundTexture;

        // boolean to see who attacks first. if player, true. if enemy, false.
        bool attackFirst;

        // can the player run?
        bool canRun;
        
        // constructor
        public Battle(Game game, Texture2D bgTex, Player p, Enemy e, bool run) : base(game)
        {
            play = p;
            en = e;

            canRun = run;

            backgroundTexture = bgTex;
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        // Sees who attacks first in a battle
        public void CalculateSpeed()
        {
            if (play.Speed > en.Speed)
            {
                attackFirst = true;
            }
            else if (play.Speed < en.Speed)
            {
                attackFirst = false;
            }
            else
            {
                // randomly generate who attacks first if the speeds are equal.
                Random rgen = new Random();
                int first = rgen.Next(1, 3);

                if (first == 1)
                {
                    attackFirst = false;
                }
                else
                {
                    attackFirst = true;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            play.DrawForBattle(spriteBatch, 200, 200);
            en.DrawForBattle(spriteBatch, 400, 200);
        }
    }
}
