using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    /// <summary>
    /// Takes care of battle screen and the battle procedures
    /// 
    /// Authors:
    ///         Allyson Sadwin
    ///         Matt Munns
    /// </summary>
    class Battle : State
    {
        Player play;
        Enemy en;
        Image backgroundTexture;
        Image combatColor;
        private Font font;
        private string chosenAttack;
        // boolean to see who attacks first. if player, true. if enemy, false.
        bool playersTurn;
        bool hasRun;
        // can the player run?
        bool canRun;
        TextMenu tMenu;
        int currentItemCount;
        Random rgen;

        private static string[] choices = { "Light Punch", "Double Punch", "Pummel", "Soul Cannon MP-1", "Mind Break MP-2", "Item", "Run" };

        // constructor
        public Battle(Image bgTex, Player p, Enemy e, bool run)
            : base()
        {
            StateManager.PushState(new LevelState(p));

            play = p;
            en = e;
            font = Font.DefaultFont;
            //TODO fix
            tMenu = new TextMenu(font, choices);
            combatColor = new Image(1, 1, new Color(100, 100, 100, 150));
            transparent = true;
            rgen = new Random();

            canRun = run;

            backgroundTexture = bgTex;
            hasRun = false;
            currentItemCount = play.Items.Count;
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
                StateManager.PushState(new MainMenu());
            }

            if (currentItemCount != play.Items.Count)
            {
                playersTurn = false;
                // player used an item
                currentItemCount = play.Items.Count;
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


        public override void Update(Clock clock, Input input)
        {
            string status = "";
            chosenAttack = null;
            tMenu.Update(clock, input);
            handleInput();

            if (playersTurn)
            {
                if (!en.IsDead() && !play.IsDead() && chosenAttack != null)
                {
                    if (chosenAttack == "Light Punch" || chosenAttack == "Double Punch" || chosenAttack == "Pummel")
                    {
                        play.getAccuracy(chosenAttack);
                        int tempDmg = play.HealthAfterCombat(en);
                        if (tempDmg == -1)
                        {
                            status += "||||Your attack missed!";
                        }
                        else
                        {
                            status += "||||Your attack : " + chosenAttack + " did " + (en.Health - tempDmg) + " damage";
                            en.Health = tempDmg;
                        }
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
                            if (tempDmg == -1)
                            {
                                status += "||||Your attack missed!";
                            }
                            else
                            {
                                status += "||||Your attack : " + chosenAttack + " did " + (en.Health - tempDmg) + " damage";
                                en.Health = tempDmg;
                            }
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
                            if (tempDmg == -1)
                            {
                                status += "||||Your attack missed!";
                            }
                            else
                            {
                                status += "||||Your attack : " + chosenAttack + " did " + (en.Health - tempDmg) + " damage";
                                en.Health = tempDmg;
                            }
                            playersTurn = false;
                        }
                    }
                    else if (chosenAttack == "Run")
                    {
                        if (canRun)
                        {
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
                        else
                        {
                            status += "||||You can't run from this fight!";
                        }
                    }
                    else if (chosenAttack == "Item")
                    {
                        currentItemCount = play.Items.Count;
                        tMenu.IsFinished = false;
                        StateManager.PushState(new ItemState(play, true));
                        chosenAttack = null;
                        return;
                    }
                    chosenAttack = null;
                }

                //If you slay enemy monster
                if (en.IsDead())
                {
                    play.Exp += en.Exp;
                    int gold = rgen.Next(0, en.Attack);
                    status += string.Format("||||You have slain {0}. You gain {1} exp. You got {2} gold.", en.Name, en.Exp, gold);
                    play.Gold += gold;
                    if (en.Items != null)
                    {
                        int itemIndex = rgen.Next(0, en.Items.Length + 20);
                        if (itemIndex < en.Items.Length)
                        {
                            status += string.Format("||||You found a {0}!", en.Items[itemIndex].Name);
                            play.Items.Add(en.Items[itemIndex]);
                        }
                    }
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
                StateManager.PushState(new Dialogue(status.Remove(0, 4)));
        }

        private void handleInput()
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
        public override void Draw(RenderWindow window)
        {
            //drawing background
            var bgSprite = new Sprite(backgroundTexture);
            window.Draw(bgSprite);

            //Player,enemy draw
            play.DrawForBattle(window, 380, 300);
            en.DrawForBattle(window, 590, 365);

            var combatBoxSprite = new Sprite(combatColor);
            combatBoxSprite.Scale = new Vector2(203, 360);
            combatBoxSprite.Position = new Vector2(17, 20);
            window.Draw(combatBoxSprite);

            string[] displayStrings = { string.Format("HP: {0}/{1}", play.Health, play.MaxHealth), string.Format("MP: {0}/{1}", play.Mana, play.MaxMana), string.Format("______________") };

            for (int i = 0; i < displayStrings.Length; i++)
            {
                var str = new String2D(displayStrings[i]);
                str.Color = Color.Black;
                str.Position = new Vector2(30, 30);
                window.Draw(str);
            }

            //spriteBatch.DrawString(font, en.Name + "\nHP: " + en.Health, new Vector2(600, (game.GraphicsDevice.Viewport.Height * 20 / 100) + 30), Color.White);
            //Combat Menu
            tMenu.Draw(window, 29, 110, Color.Black);
        }
    }
}
