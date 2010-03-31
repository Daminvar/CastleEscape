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

        int timer;
        bool canPressZ;

        // create a counter for steps
        int pedometer;


        public override void Initialize()
        {
            playerObj = new Player(0, 0, game.Content.Load<Texture2D>("ghostie"));
            mappy = new Map(game);
            mappy.LoadMap("testmap.js");
            timer = 0;
            canPressZ = false;
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

            if (kbState.IsKeyUp(Keys.Z))
                canPressZ = true;

            if (canPressZ && kbState.IsKeyDown(Keys.Z))
            {
                NPE entity = null;
                if (playerObj.Direction == Player.Directions.East)
                    entity = mappy.GetNPEAt(playerObj.XPos + 1, playerObj.YPos);
                else if (playerObj.Direction == Player.Directions.West)
                    entity = mappy.GetNPEAt(playerObj.XPos - 1, playerObj.YPos);
                else if (playerObj.Direction == Player.Directions.North)
                    entity = mappy.GetNPEAt(playerObj.XPos, playerObj.YPos - 1);
                else if (playerObj.Direction == Player.Directions.South)
                    entity = mappy.GetNPEAt(playerObj.XPos, playerObj.YPos + 1);

                if (entity != null)
                    entity.Interact();
                canPressZ = false;
            }

            if (timer >= 15)
            {
                if (kbState.IsKeyDown(Keys.Left))
                {
                    playerObj.Direction = Player.Directions.West;
                    if (playerObj.XPos - 1 >= 0)
                    {
                        if (mappy.IsCollisionAt(playerObj.XPos - 1, playerObj.YPos) == false)
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
                    playerObj.Direction = Player.Directions.East;
                    if (playerObj.XPos + 1 < mappy.MapWidth)
                    {
                        if (mappy.IsCollisionAt(playerObj.XPos + 1, playerObj.YPos) == false)
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
                    playerObj.Direction = Player.Directions.North;
                    if (playerObj.YPos - 1 >= 0)
                    {
                        if (mappy.IsCollisionAt(playerObj.XPos, playerObj.YPos - 1) == false)
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
                    playerObj.Direction = Player.Directions.South;
                    if (playerObj.YPos + 1 < mappy.MapHeight)
                    {
                        if (mappy.IsCollisionAt(playerObj.XPos, playerObj.YPos + 1) == false)
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
            playerObj.DrawForOverworld(spriteBatch, mappy, 0, 0);
            mappy.DrawTop(spriteBatch, 0, 0);
        }
    }
}
