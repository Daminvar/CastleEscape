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
    class Dialogue : State
    {
        private string message;
        private int height;
        private Texture2D bgColor;
        private SpriteFont font;
        private string[] mArray;
        private bool canMove;
        private List<string> mList;
        
        // constructor contains string with text that it will display
        public Dialogue(string text, Game game) : base(game)
        {
            // the text that it will display
            message = text;
            bgColor = game.Content.Load<Texture2D>("grey");
            font = game.Content.Load<SpriteFont>("fonts\\fixedsys");
        }

        public override void Initialize()
        {
            // get the height that the dialogue box will be
            height = game.GraphicsDevice.Viewport.Height / 4;
            canMove = true;
            mList = new List<string>();

            //Also does something, but when people talk too much I only remember some things. 
            //I think it was something about making an array, right?

            mArray = message.Split('|');

            for (int i = 0; i < mArray.Length; i++)
            {
                if (font.MeasureString(mArray[i]).X < game.GraphicsDevice.Viewport.Width - 32)
                {
                    mList.Add(mArray[i]);
                }
                else
                {
                    string longLine = mArray[i];
                    string[] longLineArr = longLine.Split(' ');
                    string msg = null;
                    for (int j = 0; j < longLineArr.Length; j++)
                    {
                        if (font.MeasureString(longLineArr[j] + " " + msg).X > game.GraphicsDevice.Viewport.Width - 32)
                        {
                            mList.Add(msg);
                            msg = null;
                        }
                        if (j == 0)
                        {
                            msg = longLineArr[j];
                        }
                        else
                        {
                            msg += " " + longLineArr[j];
                        }
                        if (j == longLineArr.Length)
                        {
                            mList.Add(msg);
                        }
                    }
                }
            }
        }

        public override void Pause()
        {
            // sits here
        }

        public override void Resume()
        {
            // la dee da
        }

        public override void Update()
        {
            // Check for keyboard input
            if (canMove)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    if (mList.Count <= 4)
                    {
                        StateManager.PopState();
                    }
                    mList.RemoveAt(0);
                    canMove = false;
                }
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                canMove = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // draws only the first four lines fo the array
            Rectangle rc = new Rectangle(0, game.GraphicsDevice.Viewport.Height * 3 / 4, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            spriteBatch.Draw(bgColor, rc, Color.White);

            for (int i = 0; i < 4 && i < mList.Count; i++)
            {
                spriteBatch.DrawString(font, mList[i], new Vector2(32.0f, (float)((game.GraphicsDevice.Viewport.Height * 3 / 4) + 24) + 5 + font.LineSpacing * i), Color.Black);
            }
        }
    }
}
