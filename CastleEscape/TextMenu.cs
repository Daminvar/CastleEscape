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
    /// Allows the user to select from a list of options.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class TextMenu
    {
        private SpriteFont font;
        private string[] options;
        private int selectedOption = 0;
        private float defaultSpacing;
        private float selectedSpacing;
        private bool canMove;
        private bool isFinished;

        public bool IsFinished
        {
            get { return isFinished; }
        }

        public int SelectedOption
        {
            get { return selectedOption; }
        }

        public TextMenu(SpriteFont font, string[] options)
        {
            this.options = options;
            this.font = font;
            defaultSpacing = font.Spacing;
            canMove = true;
            isFinished = false;
        }

        public void Update(GameTime gameTime, KeyboardState state)
        {
            if (!isFinished)
            {
                selectedSpacing = (float)(defaultSpacing + Math.Sin(Math.Log(gameTime.TotalGameTime.Milliseconds)) * 5);
                //selectedSpacing = (float)(defaultSpacing + Math.Sin(Math.Log(gameTime.TotalGameTime.Milliseconds)) * .7);
            }
            else
            {
                canMove = false;
                selectedSpacing = defaultSpacing;
            }

            if (state.IsKeyDown(Keys.Z))
                isFinished = true;

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

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            for (int i = 0; i < options.Length; i++)
            {
                var pos = new Vector2(x, y + i * font.LineSpacing);
                if (i == selectedOption && !isFinished)
                {
                    pos.X += 2 * selectedSpacing;
                    font.Spacing = selectedSpacing;
                }
                else
                    font.Spacing = defaultSpacing;
                spriteBatch.DrawString(font, options[i], pos, Color.Black);
            }
            font.Spacing = defaultSpacing;
        }
    }
}
