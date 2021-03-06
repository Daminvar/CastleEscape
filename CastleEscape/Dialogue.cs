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
    /// The dialogue state.
    /// 
    ///     Authors:
    ///         Allyson Sadwin :)
    /// </summary>
    class Dialogue : State
    {
        // create necessary attributes
        private string message;
        private int height;
        private Texture2D bgColor;
        private SpriteFont font;
        private string[] mArray;
        private bool canMove;
        private List<string> mList;
        
        /// <summary>
        /// The Dialogue constructor - takes 2 parameters
        /// </summary>
        /// <param name="text">The message that will be displayed</param>
        /// <param name="game">The current game</param>
        public Dialogue(Game game, string text) : base(game)
        {
            // the text that it will display
            message = text;
            bgColor = new Texture2D(game.GraphicsDevice, 1, 1);
            bgColor.SetData<Color>(new Color[] { new Color(Color.Black, 200) });
            font = game.Content.Load<SpriteFont>("dialogue-font");
            transparent = true;

            // get the height that the dialogue box will be - 1/4th of the screen size
            height = game.GraphicsDevice.Viewport.Height / 4;

            // this is so the dialogue box doesn't instantly close
            canMove = false;

            // implement a list for the different lines
            mList = new List<string>();

            // create an array of each line from the message
            mArray = message.Split('|');

            // populate the list with the elements in the array
            for (int i = 0; i < mArray.Length; i++)
            {
                // if the line is not too long, add it to the mList list
                if (font.MeasureString(mArray[i]).X < game.GraphicsDevice.Viewport.Width - 32)
                {
                    mList.Add(mArray[i]);
                }
                // if the line is too long, split it up by words.
                else
                {
                    string longLine = mArray[i];
                    string[] longLineArr = longLine.Split(' ');
                    string msg = null;
                    for (int j = 0; j < longLineArr.Length; j++)
                    {
                        // if the next word + the current string is longer than the width we set, add the current string to the message list
                        if (font.MeasureString(longLineArr[j] + " " + msg).X > game.GraphicsDevice.Viewport.Width - 64)
                        {
                            mList.Add(msg);
                            msg = null;
                        }
                        // this is so we don't start with a space.
                        if (j == 0)
                        {
                            msg = longLineArr[j];
                        }
                        // add the next word to the string
                        else
                        {
                            msg += " " + longLineArr[j];
                        }
                    }
                    // if you've reached the end of the array and there are still words left, add the current string to the mList.
                    if (msg != null)
                    {
                        mList.Add(msg);
                    }
                }
            }
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        /// <summary>
        /// Checks to see if the space key is down. If it is, the first element of the List is removed.
        /// Holding down the space key sets canMove to false. Releasing sets canMove to true.
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public override void Update(GameTime gameTime)
        {
            // Check for keyboard input
            if (canMove)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Z))
                {
                    if (mList.Count <= 4)
                    {
                        StateManager.PopState();
                        return;
                    }
                    // remove the first element of the list, making the dialogue move up by one line.
                    mList.RemoveRange(0,4);
                    canMove = false;
                }
            }

            // if the space key is up, then set canMove to true again so you can go to the next line.
            if (Keyboard.GetState().IsKeyUp(Keys.Z))
            {
                canMove = true;
            }
        }

        /// <summary>
        /// Draws the textbox and four lines of text to the screen.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            // draws only the first four lines of the array
            Rectangle rc = new Rectangle(0, game.GraphicsDevice.Viewport.Height * 3 / 4, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            spriteBatch.Draw(bgColor, rc, Color.White);
            
            for (int i = 0; i < 4 && i < mList.Count; i++)
            {
                spriteBatch.DrawString(font, mList[i], new Vector2(32.0f, (float)((game.GraphicsDevice.Viewport.Height * 3 / 4) + 10) + 5 + font.LineSpacing * i), Color.White);
            }
        }
    }
}
