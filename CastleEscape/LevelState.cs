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
    /// This class will handle the player leveling
    /// and allow them to increase their stats
    /// </summary>
    class LevelState : State
    {
        Player play;
        TextMenu tMenu;
        private SpriteFont font;
        Texture2D combatColor;
        private int pointsLeft;
        private string chosenStat;
        private bool increaseStats;

        private static string[] choices = { "Attack", "Defense", "Magic Attack", "Speed" };
        //Health and mana will go up each level everytime

        public LevelState(Game game, Player player) : base(game)
        {
            this.play = player;
            font = game.Content.Load<SpriteFont>("Test-Font");
            tMenu = new TextMenu(font, choices);
            transparent = true;
            combatColor = new Texture2D(game.GraphicsDevice, 1, 1);
            combatColor.SetData<Color>(new Color[] { new Color(Color.Black, 150)});
            pointsLeft = 5;
            increaseStats = true;
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
            if (play.Exp < play.ExpToLevel)
            {
                StateManager.PopState();
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (increaseStats)
            {
                play.MaxHealth += 5;
                play.Health += 5;
                play.MaxMana += 5;
                play.Mana += 5;
                play.Level += 1;
                increaseStats = false;
            }

            tMenu.Update(gameTime, Keyboard.GetState());
            if (tMenu.IsFinished)
            {
                handleInput(gameTime);
                statIncrease(chosenStat);
                tMenu.IsFinished = false;
            }

            if (pointsLeft < 0)
            {
                play.Exp = (play.Exp - play.ExpToLevel);
                play.ExpToLevel = (int)(play.ExpToLevel + (10 * 1.5));
                
                StateManager.PopState();
            }
        }

        private void handleInput(GameTime gametime)
        {
            string selectedStat = null;

            if (!tMenu.IsFinished)
                return;

            selectedStat = choices[tMenu.SelectedOption];

            if (selectedStat == "Attack")
                chosenStat = "Attack";

            else if (selectedStat == "Defense")
                chosenStat = "Defense";

            else if (selectedStat == "Magic Attack")
                chosenStat = "Magic Attack";

            else if (selectedStat == "Speed")
                chosenStat = "Speed";
        }
        private void statIncrease(string stat)
        {
            if (pointsLeft != 0)
            {
                if (stat == "Attack")
                    play.Attack++;

                else if (stat == "Defense")
                    play.Defense++;

                else if (stat == "Magic Attack")
                    play.MagicAtk++;

                else if (stat == "Speed")
                    play.Speed++;
            }

            pointsLeft--;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rec = new Rectangle(225, 75, 350, 300);
            spriteBatch.Draw(combatColor, rec, Color.White);

            tMenu.Draw(spriteBatch, 275, 100, Color.White);

            spriteBatch.DrawString(font, play.Attack +
                                         "\n" + play.Defense +
                                         "\n" + play.MagicAtk +
                                          "\n" + play.Speed,
              new Vector2(470f, 100f), Color.White);
            spriteBatch.DrawString(font, "Level up points left: " + pointsLeft,
                new Vector2(290f, 250f), Color.White);

            if (pointsLeft == 0)
            {
                spriteBatch.DrawString(font, "Press Z to exit.",
                    new Vector2(290f, 300f), Color.White);
            }

        }
        



    }
}
