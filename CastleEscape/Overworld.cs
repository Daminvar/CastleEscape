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
    class Overworld : State
    {
        public Overworld(Game game) : base(game) { }

        Player playerObj;
        Map mappy;
        // npes

        int timer;

        // create a counter for steps
        int pedometer;


        public override void Initialize()
        {
            playerObj = new Player(0, 0, game.Content.Load<Texture2D>("ghostie"));
            mappy = new Map(game);
            mappy.LoadMap("testmap.tmx");
            timer = 0;
            pedometer = 0;
        }

        public override void Pause()
        {
            // stops music and stuff to prepare to go to a new state
        }

        public override void Resume()
        {
            // resumes everything when returning to the overworld state
        }

        public override void Update(GameTime gameTime)
        {
            // checks for updates
            handleInput();

            timer++;
        }
        
        /// <summary>
        /// Handles the keyboard input by the player to move the character sprite onscreen. Also checks for collisions.
        /// </summary>
        private void handleInput()
        {
            // handle input
            KeyboardState kbState = Keyboard.GetState();

            if (timer >= 15)
            {
                if (kbState.IsKeyDown(Keys.Left))
                {
                    if (playerObj.X - 1 >= 0)
                    {
                        if (mappy.IsCollisionAt(playerObj.X - 1, playerObj.Y) == false)
                        {
                            playerObj.Move(-1, 0);
                            pedometer++;

                            // check for a random encounter!
                            bool re = this.RandomEncounter(pedometer);
                            if (re)
                            {
                                Console.WriteLine("Battle!");
                                pedometer = 0;

                                // this will either push the Battle state on or call something that will.
                                // does battling pause overworld too?
                                //this.Pause();
                            }

                            timer = 0;
                        }
                    }
                    else
                    {
                        mappy.ChangeMap(Map.Directions.West);
                        playerObj.Move(mappy.MapWidth - 1, 0);
                        timer = 0;
                    }
                }
                else if (kbState.IsKeyDown(Keys.Right))
                {
                    if (playerObj.X + 1 < mappy.MapWidth)
                    {
                        if (mappy.IsCollisionAt(playerObj.X + 1, playerObj.Y) == false)
                        {
                            playerObj.Move(1, 0);
                            pedometer++;

                            // check for a random encounter!
                            bool re = this.RandomEncounter(pedometer);
                            if (re)
                            {
                                Console.WriteLine("Battle!");
                                pedometer = 0;

                                // this will either push the Battle state on or call something that will.
                                // does battling pause overworld too?
                                //this.Pause();
                            }

                            timer = 0;
                        }
                    }
                    else
                    {
                        mappy.ChangeMap(Map.Directions.East);
                        playerObj.Move(-(mappy.MapWidth) + 1, 0);
                        timer = 0;
                    }
                }
                else if (kbState.IsKeyDown(Keys.Up))
                {
                    if (playerObj.Y - 1 >= 0)
                    {
                        if (mappy.IsCollisionAt(playerObj.X, playerObj.Y - 1) == false)
                        {
                            playerObj.Move(0, -1);
                            pedometer++;

                            // check for a random encounter!
                            bool re = this.RandomEncounter(pedometer);
                            if (re)
                            {
                                Console.WriteLine("Battle!");
                                pedometer = 0;
                                // this will either push the Battle state on or call something that will.
                                // does battling pause overworld too?
                                //this.Pause();
                            }

                            timer = 0;
                        }
                    }
                    else
                    {
                        mappy.ChangeMap(Map.Directions.North);
                        playerObj.Move(0, mappy.MapHeight - 1);
                        timer = 0;
                    }
                }
                else if (kbState.IsKeyDown(Keys.Down))
                {
                    if (playerObj.Y + 1 < mappy.MapHeight)
                    {
                        if (mappy.IsCollisionAt(playerObj.X, playerObj.Y + 1) == false)
                        {
                            playerObj.Move(0, 1);
                            pedometer++;

                            // check for a random encounter!
                            bool re = this.RandomEncounter(pedometer);
                            if (re)
                            {
                                Console.WriteLine("Battle!");
                                pedometer = 0;

                                // this will either push the Battle state on or call something that will.
                                // does battling pause overworld too?
                                //this.Pause();
                            }

                            timer = 0;
                        }
                    }
                    else
                    {
                        mappy.ChangeMap(Map.Directions.South);
                        playerObj.Move(0, -(mappy.MapHeight) + 1);
                        timer = 0;
                    }
                }
            }
        }

        // This checks to see if a battle will start!
        // you can move this code if you don't think it belongs here~
        public bool RandomEncounter(int steps)
        {
            // create a random number generator
            Random rng = new Random();

            int rdmNum = rng.Next(1, 21);

            if (rdmNum < (int)(5 * (steps / 6) ^ 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public override void Draw(SpriteBatch spriteBatch)
        {
            // draws player, tells map to draw itself
            mappy.DrawBase(spriteBatch, 0, 0);
            playerObj.DrawForOverworld(spriteBatch);

            //Vector2 v2 = new Vector2(playerObj.X * mappy.TileSize, playerObj.Y * mappy.TileSize);

            //spriteBatch.Draw(playerObj.Texture, v2, Color.White);

            mappy.DrawTop(spriteBatch, 0, 0);
        }
    }
}
