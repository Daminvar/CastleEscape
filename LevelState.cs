using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

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
        private Font font;
        Image combatColor;
        private int pointsLeft;
        private string chosenStat;
        private bool increaseStats;
        private Font fontLevelUp;
        private Font fontLevel;

        private static string[] choices = { "Attack", "Defense", "Magic Attack", "Speed" };
        //Health and mana will go up each level everytime

        public LevelState(Player player)
            : base()
        {
            this.play = player;
            font = Font.DefaultFont; //TODO
            fontLevelUp = Font.DefaultFont; //TODO
            fontLevel = Font.DefaultFont; //TODO
            tMenu = new TextMenu(font, choices);
            transparent = true;
            increaseStats = true;
            combatColor = new Image(1, 1, Color.Black); //TODO
            pointsLeft = 0;
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
                while (play.Exp >= play.ExpToLevel)
                {
                    play.MaxHealth += 5;
                    play.Health += 5;
                    play.MaxMana += 5;
                    play.Mana += 5;
                    play.Level += 1;

                    play.Exp = play.Exp - play.ExpToLevel;
                    play.ExpToLevel = (int)(play.ExpToLevel + (10 * 1.5));
                    pointsLeft += 5;
                }
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

        public override void Draw(RenderWindow window)
        {
            Rectangle recLevel = new Rectangle(145, 15, 370, 400);
            spriteBatch.Draw(combatColor, recLevel, Color.White);
            tMenu.Draw(spriteBatch, 190, 190, Color.White);
            spriteBatch.DrawString(font, play.Attack +
                                         "\n" + play.Defense +
                                         "\n" + play.MagicAtk +
                                         "\n" + play.Speed,
                                         new Vector2(385f, 195f), Color.White);
            spriteBatch.DrawString(font, "Level up points left: " + pointsLeft,
                new Vector2(200f, 315f), Color.White);
            spriteBatch.DrawString(fontLevel, "Level: " + play.Level,
                new Vector2(255f, 130f), Color.White);
            if (pointsLeft == 0)
            {
                spriteBatch.DrawString(font, "Press Z to exit.",
                    new Vector2(235f, 360f), Color.White);
            }
            spriteBatch.DrawString(fontLevelUp, "LEVEL UP!", new Vector2(165f, 20f), Color.WhiteSmoke);
        }
    }
}
