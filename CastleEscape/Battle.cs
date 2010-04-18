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
        private string chosenAttack;
        // boolean to see who attacks first. if player, true. if enemy, false.
        bool playersTurn;
        bool hasRun;
        // can the player run?
        bool canRun;
        TextMenu tMenu;

        private static string[] choices = { "Light Punch", "Double Punch", "Pummel", "Soul Cannon MP-1", "Mind Break MP-2", "Item", "Run" };

        // constructor
        public Battle(Game game, Texture2D bgTex, Player p, Enemy e, bool run)
            : base(game)
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
            hasRun = false;
            CalculateSpeed();
        }

        public override void Pause()
        {

        }

        public override void Resume()
        {
            if (en.IsDead() || hasRun)
                StateManager.PopState();
            else if (play.IsDead())
            {
                StateManager.PopAllStates();
                StateManager.PushState(new MainMenu(game));
            }

        }

        // Sees who attacks first in a battle
        public void CalculateSpeed()
        {
            if (play.Speed > en.Speed)
            {
                playersTurn = true;
            }
            else if (play.Speed < en.Speed)
            {
                playersTurn = false;
            }
            else
            {
                // randomly generate who attacks first if the speeds are equal.
                Random rgen = new Random();
                int first = rgen.Next(1, 3);

                if (first == 1)
                {
                    playersTurn = false;
                }
                else
                {
                    playersTurn = true;
                }
            }
        }


        public override void Update(GameTime gameTime)
        {
            string status = "";
            chosenAttack = null;
            tMenu.Update(gameTime, Keyboard.GetState());
            handleInput(gameTime);

            if (playersTurn)
            {
                if (!en.IsDead() && !play.IsDead() && chosenAttack != null)
                {
                    if (chosenAttack == "Light Punch" || chosenAttack == "Double Punch" || chosenAttack == "Pummel")
                    {
                        play.getAccuracy(chosenAttack);
                        int tempDmg = play.HealthAfterCombat(en);
                        status += "||||Your attack : " + chosenAttack + " did " + (en.Health - tempDmg) + " damage";
                        en.Health = tempDmg;
                        playersTurn = false;
                    }
                    else if (chosenAttack == "Soul Cannon")
                    {
                        if (play.Mana < 1)
                            status += "||||You don't have enough mana for that attack!";
                        else
                        {
                            play.getAccuracy(chosenAttack);
                            int tempDmg = play.HealthAfterCombat(en);
                            status += "||||Your attack : " + chosenAttack + " did " + (en.Health - tempDmg) + " damage";
                            en.Health = tempDmg;
                            playersTurn = false;
                        }
                    }
                    else if (chosenAttack == "Mind Break")
                    {
                        if (play.Mana < 2)
                            status += "||||You don't have enough mana for that attack!";
                        else
                        {
                            play.getAccuracy(chosenAttack);
                            int tempDmg = play.HealthAfterCombat(en);
                            status += "||||Your attack : " + chosenAttack + " did " + (en.Health - tempDmg) + " damage";
                            en.Health = tempDmg;
                            playersTurn = false;
                        }
                    }
                    else if (chosenAttack == "Run")
                    {
                        Random rgen = new Random();
                        int chance = rgen.Next(1, 10);
                        if (chance < 4)
                        {
                            status += "||||Run failed!";
                            playersTurn = false;
                        }
                        else
                        {
                            status += "||||You ran away!";
                            hasRun = true;
                        }
                    }
                    else if (chosenAttack == "Item")
                    {
                        playersTurn = false;
                        StateManager.PushState(new ItemState(game, play));
                        chosenAttack = null;
                        return;
                    }
                    chosenAttack = null;
                }
                
                //If you slay enemy monster
                if (en.IsDead())
                {
                    status += "||||You have slain " + en.Name;

                }

                tMenu.IsFinished = false;
            }
            if (!en.IsDead() && !playersTurn)
            {
                int tempDmg = en.HealthAfterCombat(play);
                status += "||||Enemy did : " + (play.Health - tempDmg) + " damage";
                play.Health = tempDmg;

                playersTurn = true;
                tMenu.IsFinished = false;

                // If enemy monster kills you
                if (play.IsDead())
                {
                    status += "||||You have been killed";
                }
            }

            if (status != "")
                StateManager.PushState(new Dialogue(game, status.Remove(0, 4)));
        }

        private void handleInput(GameTime gametime)
        {
            string selectedChoice = null;
            if (!tMenu.IsFinished)
                return;

            selectedChoice = choices[tMenu.SelectedOption];

            //"Light Punch","Double-Punch","Pummel", "Soul Cannon","Mind Break","Item", "Run" };
            //Sets the chosen attack based on what the player selected
            if (selectedChoice == ("Light Punch"))
                chosenAttack = "Light Punch";

            else if (selectedChoice == ("Double Punch"))
                chosenAttack = "Double Punch";

            else if (selectedChoice == ("Pummel"))
                chosenAttack = "Pummel";

            else if (selectedChoice == ("Soul Cannon MP-1"))
                chosenAttack = "Soul Cannon";

            else if (selectedChoice == ("Mind Break MP-2"))
                chosenAttack = "Mind Break";

            else if (selectedChoice == ("Item"))
                chosenAttack = "Item";

            else if (selectedChoice == ("Run"))
                chosenAttack = "Run";
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
            Rectangle rec = new Rectangle(17, 20, 220, 380);
            spriteBatch.Draw(combatColor, rec, Color.White);

            //Draws health,mana and divider
            spriteBatch.DrawString(font, "HP: " + play.Health + "/" + play.MaxHealth +
                                        "\nMP: " + play.Mana + "/" + play.MaxMana +
                                        "\n______________",
              new Vector2(30.0f, (float)((game.GraphicsDevice.Viewport.Height * 7 / 100))), Color.Black);
            spriteBatch.DrawString(font, en.Name + "\nHP: " + en.Health, new Vector2(600, (game.GraphicsDevice.Viewport.Height * 20 / 100) + 30), Color.White);
            //Combat Menu
            tMenu.Draw(spriteBatch, 29, 110);
        }
    }
}
