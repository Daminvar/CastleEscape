using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

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
        private Image bgColor;
        private Font font;
        private string[] mArray;
        private bool canMove;
        private List<string> mList;
        
        /// <summary>
        /// The Dialogue constructor - takes 2 parameters
        /// </summary>
        /// <param name="text">The message that will be displayed</param>
        /// <param name="game">The current game</param>
        public Dialogue(string text) : base()
        {
            // the text that it will display
            message = text;
            bgColor = new Image(1, 1, new Color(150, 150, 150, 150));
            font = Font.DefaultFont; //TODO fix
            transparent = true;

            // get the height that the dialogue box will be - 1/4th of the screen size
            height = 480 / 4; //TODO

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
                if (mArray[i].Length * font.CharacterSize < 800 - 32) //TODO fix
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
                        if ((longLineArr[j] + " " + msg).Length * font.CharacterSize > 800 - 64) //TODO fix
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
        public override void Update(Clock clock, Input input)
        {
            // Check for keyboard input
            if (canMove)
            {
                if (input.IsKeyDown(KeyCode.Z))
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

            // if Z is up, then set canMove to true again so you can go to the next line.
            if (!input.IsKeyDown(KeyCode.Z))
            {
                canMove = true;
            }
        }

        /// <summary>
        /// Draws the textbox and four lines of text to the screen.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch</param>
        public override void Draw(RenderWindow window)
        {
            // draws only the first four lines of the array
			var boxSprite = new Sprite(bgColor);
            boxSprite.Position = new Vector2(0, window.Height * 3 / 4);
			boxSprite.Scale = new Vector2(window.Width, window.Height - window.Height * 3 / 4);
            window.Draw(boxSprite);
            
            for (int i = 0; i < 4 && i < mList.Count; i++)
            {
				var str = new String2D(mList[i], font);
				str.Position = new Vector2(32.0f, (float)((480 * 3 / 4) + 10) + 5 + font.CharacterSize * i); //TODO fix
				window.Draw(str);
            }
        }
    }
}
