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
    /// <summary>
    /// Takes care of battle screen and the battle procedures
    /// 
    /// 
    /// Authors:
    ///         Allyson Sadwin
    ///         Matt Munns
    /// </summary>
    class Battle : State
    {
        Player play;
        Enemy en;
        Texture2D backgroundTexture;
        Texture2D combatColor;
        private SpriteFont font;

        // boolean to see who attacks first. if player, true. if enemy, false.
        bool attackFirst;

        // can the player run?
        bool canRun;

        TextMenu tMenu;

        private static string[] choices = { "Light Punch","Double-Punch","Pummel", "Soul Cannon","Mind Break","Item", "Run" };

        // constructor
        public Battle(Game game, Texture2D bgTex, Player p, Enemy e, bool run) : base(game)
        {
            play = p;
            en = e;
             font = game.Content.Load<SpriteFont>("Test-Font");
            tMenu = new TextMenu(font, choices);
            combatColor = new Texture2D(game.GraphicsDevice, 1, 1);
            combatColor.SetData<Color>(new Color[] { new Color(Color.Black, 150) });
            transparent = true;
            
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
            if (attackFirst)
            {
                play.Accuracy = 55;

                en.Health = play.HealthAfterCombat(en);

                if(en.IsDead())
                {
                    //enemy dies, push back on overworld?
                }
            }
            else
            {
               play.Health = en.HealthAfterCombat(play);
            }

            tMenu.Update(gameTime, Keyboard.GetState());
        }

        //Draws the combat screen
        public override void Draw(SpriteBatch spriteBatch)
        {
            //drawing background
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            
            //Player,enemy draw
            play.DrawForBattle(spriteBatch, 380, 360);
            en.DrawForBattle(spriteBatch, 590, 365);

            //Transparent rectangle that "holds" the menu
            Rectangle rec = new Rectangle(20, 20, 220, 380);
            spriteBatch.Draw(combatColor, rec, Color.White);

            //Draws health,mana and divider
            spriteBatch.DrawString(font, "HP: " + play.Health +"/"+ play.MaxHealth + 
                                        "\nMP: " + play.Mana+ "/" + play.MaxMana +
                                        "\n______________",
              new Vector2(30.0f, (float)((game.GraphicsDevice.Viewport.Height * 7 / 100) )), Color.Black);  

            //Combat Menu
            tMenu.Draw(spriteBatch,29,110);
        }
    }
}
