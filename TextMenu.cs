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
    /// Allows the user to select from a list of options.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class TextMenu
    {
        private Font font;
        private string[] options;
        private int selectedOption = 0;
        private float defaultStretch;
        private float selectedStretch;
        private bool canMove;
        private bool isFinished;
        private bool canPressZ;

        public bool IsFinished
        {
            get { return isFinished; }
            set { isFinished = value; }
        }

        public int SelectedOption
        {
            get { return selectedOption; }
        }

        public string[] Options
        {
            get { return options; }
            set { options = value; }
        }

        public TextMenu(Font font, string[] options)
        {
            this.options = options;
            this.font = font;
            defaultStretch = 1;
            canMove = false;
            isFinished = false;
            canPressZ = false;
        }

        public void Update(Clock clock, Input input)
        {
            if (!isFinished)
            {
                selectedStretch = (float)(defaultStretch + Math.Sin(clock.TotalTime.Second * 20));
                selectedStretch = selectedStretch / options[selectedOption].Length;
            }
            else
            {
                canMove = false;
                selectedStretch = defaultStretch;
                return;
            }

            if (state.IsKeyUp(Keys.Z))
                canPressZ = true;

            if (canPressZ && state.IsKeyDown(Keys.Z))
            {
                isFinished = true;
                canPressZ = false;
                selectedStretch = defaultStretch;
            }

            if (state.IsKeyUp(Keys.Up) && state.IsKeyUp(Keys.Down))
                canMove = true;
            if (!canMove)
                return;
            if (state.IsKeyDown(Keys.Up))
            {
                selectedOption = selectedOption > 0 ? selectedOption - 1 : options.Length - 1;
                canMove = false;
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                selectedOption = (selectedOption + 1) % options.Length;
                canMove = false;
            }
        }

        public void Draw(RenderWindow window, int x, int y, Color textColor)
        {
            for (int i = 0; i < options.Length; i++)
            {
				var optionText = new String2D(options[i], font);
                var pos = new Vector2(x, y + i * font.CharacterSize);
                if (i == selectedOption && !isFinished)
                {
                    pos.X += 2 * selectedStretch;
                    optionText.Scale = new Vector2(selectedStretch, 0);
                }
				optionText.Position = pos;
				optionText.Color = textColor;
				window.Draw(optionText);
            }
        }
    }
}
