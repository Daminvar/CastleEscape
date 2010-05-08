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
        private const string LEVEL_UP_SONG = "test-song"; //TODO fix!

        Player play;
        TextMenu tMenu;
        private SpriteFont font;
        Texture2D combatColor;
        private int pointsLeft;
        private string chosenStat;
        private bool increaseStats;
        private SpriteFont fontLevelUp;
        private SpriteFont fontLevel;

        private static string[] choices = { "Attack", "Defense", "Magic Attack", "Speed" };
        //Health and mana will go up each level everytime

        public LevelState(Game game, Player player)
            : base(game)
        {
            this.play = player;
            font = game.Content.Load<SpriteFont>("level-up-menu-font");
            fontLevelUp = game.Content.Load<SpriteFont>("level-up-font");
            fontLevel = game.Content.Load<SpriteFont>("level-font");
            tMenu = new TextMenu(font, choices);
            transparent = true;
            increaseStats = true;
            combatColor = new Texture2D(game.GraphicsDevice, 1, 1);
            combatColor.SetData<Color>(new Color[] { new Color(Color.Black, 200) });
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
                return;
            }
            MediaPlayer.Play(game.Content.Load<Song>(LEVEL_UP_SONG));
            MediaPlayer.Volume = 1;
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

        public override void Draw(SpriteBatch spriteBatch)
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
