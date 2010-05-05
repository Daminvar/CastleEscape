using System;
using System.Collections.Generic;
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

        public override void Update(Clock clock, Input input)
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

            tMenu.Update(clock, input);
            if (tMenu.IsFinished)
            {
                handleInput();
                statIncrease(chosenStat);
                tMenu.IsFinished = false;
            }

            if (pointsLeft < 0)
            {
                StateManager.PopState();
            }
        }

        private void handleInput()
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
            var bgSprite = new Sprite(combatColor);
            bgSprite.Position = new Vector2(145, 15);
            bgSprite.Scale = new Vector2(370, 400);
            window.Draw(bgSprite);
            tMenu.Draw(window, 190, 190, Color.White);
            var statsString = new String2D(play.Attack +
                                         "\n" + play.Defense +
                                         "\n" + play.MagicAtk +
                                         "\n" + play.Speed, font);
            statsString.Position = new Vector2(385, 195);
            window.Draw(statsString);
            var pointsLeftString = new String2D("Level up points left: " + pointsLeft, font);
            pointsLeftString.Position = new Vector2(200, 315);
            window.Draw(pointsLeftString);
            var levelString = new String2D("Level: " + play.Level);
            levelString.Position = new Vector2(255, 130);
            window.Draw(levelString);
            if (pointsLeft == 0)
            {
                var pressZ = new String2D("Press Z to exit.", font);
                pressZ.Position = new Vector2(235, 360);
            }
            var levelUpString = new String2D("LEVEL UP!", fontLevelUp);
            levelUpString.Position = new Vector2(165, 20);
            window.Draw(levelUpString);
        }
    }
}
