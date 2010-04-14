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
    /// The overworld state.
    /// 
    /// Authors: 
    ///     Dennis Honeyman
    ///     Matt Munns    
    ///     Allyson Sadwin

    /// </summary>
    class Overworld : State
    {
        Player playerObj;
        DrawableMap mappy;
        
        
        int timer;
        bool canPressZ;

        bool movingLeft;
        bool movingRight;
        bool movingUp;
        bool movingDown;

        // size of sprite = 35px by 40px
        int spriteHeight = 40;
        int spriteWidth = 35;
        private bool canPressEscape;

        // Rectangles
        Rectangle sourceRectangle;
        Rectangle destinationRectangle;

        // create a counter for steps
        int pedometer;

        HUD hud;

        public Overworld(Game game, Player player, DrawableMap map) : base(game)
        {
            playerObj = player;
            mappy = map;

            //The destination rectangle is the location where the sprite will be drawn.
            destinationRectangle = new Rectangle(0, 0, spriteWidth, spriteHeight);

            timer = 0;
            canPressZ = false;
            pedometer = 0;
            canPressEscape = false;
            movingLeft = false;
            movingRight = false;
            movingUp = false;
            movingDown = false;

            hud = new HUD(game, playerObj, mappy);
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
            handleInput(gameTime);

            timer += gameTime.ElapsedGameTime.Milliseconds;

            
        }
        
        /// <summary>
        /// Handles the keyboard input by the player to move the character sprite onscreen. Also checks for collisions.
        /// </summary>
        private void handleInput(GameTime gameTime)
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
                {
                    entity.Interact(playerObj);
                }
                canPressZ = false;
            }

            if (timer >= 200)
            {
                playerObj.ModX = 0;
                playerObj.ModY = 0;
            }

            if ( (kbState.IsKeyDown(Keys.Left) || movingLeft) && !movingRight && !movingDown && !movingUp)
                {
                    movingLeft = true;
                    movingDown = false;
                    movingRight = false;
                    movingUp = false;

                    playerObj.Direction = Player.Directions.West;

                    if (mappy.IsCollisionAt(playerObj.XPos - 1, playerObj.YPos) == false && playerObj.XPos - 1 >= 0)
                    {
                        if (timer >= 50 && timer < 100)
                        {
                            playerObj.CurrentSpriteX = 1;
                            playerObj.ModX = 8;
                        }
                        else if (timer >= 100 && timer < 150)
                        {
                            playerObj.CurrentSpriteX = 2;
                            playerObj.ModX = 16;
                        }
                            
                        else if (timer >= 150 && timer < 200)
                        {
                            playerObj.CurrentSpriteX = 1;
                            playerObj.ModX = 32;
                        }
                    }

                    if (timer >= 200)
                    {
                        playerObj.ModX = 0;
                        playerObj.CurrentSpriteX = 1;
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
                                    re = false;
                                    StateManager.PushState(new TestBattleState(game));
                                }

                                

                                timer = 0;
                            }
                        }
                        else
                        {
                            mappy.ChangeMap(ScriptableMap.Directions.West);
                            playerObj.Move(mappy.MapWidth - 1, 0);
                            timer = 0;
                        }
                        movingLeft = false;
                    }
                }
                else if ( (kbState.IsKeyDown(Keys.Right) || movingRight) && !movingLeft && !movingDown && !movingUp)
                {
                    movingLeft = false;
                    movingDown = false;
                    movingRight = true;
                    movingUp = false;

                    playerObj.Direction = Player.Directions.East;

                    if (mappy.IsCollisionAt(playerObj.XPos + 1, playerObj.YPos) == false && playerObj.XPos + 1 < mappy.MapWidth)
                    {
                        if (timer >= 50 && timer < 100)
                        {
                            playerObj.CurrentSpriteX = 2;
                            playerObj.ModX = -8;
                        }
                        else if (timer >= 100 && timer < 200)
                        {
                            playerObj.CurrentSpriteX = 2;
                            playerObj.ModX = -16;
                        }
                        else if (timer >= 150 && timer < 200)
                        {
                            playerObj.CurrentSpriteX = 0;
                            playerObj.ModX = -24;
                        }
                    }

                    if (timer >= 200)
                    {
                        playerObj.ModX = 0;
                        playerObj.CurrentSpriteX = 1;
                        movingRight = false;
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
                                    re = false;
                                    StateManager.PushState(new TestBattleState(game));
                                    // this will either push the Battle state on or call something that will.
                                    // does battling pause overworld too?
                                    //this.Pause();
                                }

                                timer = 0;
                            }
                        }
                        else
                        {
                            mappy.ChangeMap(ScriptableMap.Directions.East);
                            playerObj.Move(-(mappy.MapWidth) + 1, 0);
                            timer = 0;
                        }
                    }
                }
            else if ( (kbState.IsKeyDown(Keys.Up) || movingUp) && !movingLeft && !movingDown && !movingRight)
                {
                    movingLeft = false;
                    movingDown = false;
                    movingRight = false;
                    movingUp = true;

                    playerObj.Direction = Player.Directions.North;
                    if (mappy.IsCollisionAt(playerObj.XPos, playerObj.YPos - 1) == false && playerObj.YPos - 1 >= 0)
                    {
                        if (timer >= 50 && timer < 100)
                        {
                            playerObj.CurrentSpriteX = 2;
                            playerObj.ModY = 8;
                        }
                        else if (timer >= 100 && timer < 200)
                        {
                            playerObj.CurrentSpriteX = 1;
                            playerObj.ModY = 16;
                        }
                        else if (timer >= 150 && timer < 200)
                        {
                            playerObj.CurrentSpriteX = 0;
                            playerObj.ModY = 24;
                        }
                    }

                    if (timer >= 200)
                    {
                        playerObj.ModY = 0;
                        playerObj.CurrentSpriteX = 1;
                        movingUp = false;
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
                                    re = false;
                                    StateManager.PushState(new TestBattleState(game));
                                    // this will either push the Battle state on or call something that will.
                                    // does battling pause overworld too?
                                    //this.Pause();
                                }

                                timer = 0;
                            }
                        }
                        else
                        {
                            mappy.ChangeMap(ScriptableMap.Directions.North);
                            playerObj.Move(0, mappy.MapHeight - 1);
                            timer = 0;
                        }
                    }
                }
            else if ( (kbState.IsKeyDown(Keys.Down) || movingDown ) && !movingLeft && !movingRight && !movingUp)
                {
                    movingLeft = false;
                    movingDown = true;
                    movingRight = false;
                    movingUp = false;

                    playerObj.Direction = Player.Directions.South;

                    if (mappy.IsCollisionAt(playerObj.XPos, playerObj.YPos + 1) == false && playerObj.YPos + 1 < mappy.MapHeight)
                    {
                        if (timer >= 50 && timer < 100)
                        {
                            playerObj.CurrentSpriteX = 1;
                            playerObj.ModY = -8;
                        }
                        else if (timer >= 100 && timer < 200)
                        {
                            playerObj.CurrentSpriteX = 2;
                            playerObj.ModY = -16;
                        }
                        else if (timer >= 150 && timer < 200)
                        {
                            playerObj.CurrentSpriteX = 0;
                            playerObj.ModY = -24;
                        }
                    }

                    if (timer >= 200)
                    {
                        movingDown = false;
                        playerObj.ModY = 0;
                        playerObj.CurrentSpriteX = 1;
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
                                    re = false;
                                    StateManager.PushState(new TestBattleState(game));
                                    // this will either push the Battle state on or call something that will.
                                    // does battling pause overworld too?
                                    //this.Pause();
                                }

                                timer = 0;
                            }
                        }
                        else
                        {
                            mappy.ChangeMap(ScriptableMap.Directions.South);
                            playerObj.Move(0, -(mappy.MapHeight) + 1);
                            timer = 0;
                        }
                    }
                    
                }

                if (kbState.IsKeyUp(Keys.Escape))
                {
                    
                    canPressEscape = true;
                    return;

                }

            //Pauses the game
            if(kbState.IsKeyDown(Keys.Escape) && canPressEscape)
            {
                
                StateManager.PushState(new PauseState(game,playerObj));
                canPressEscape = false;
                return;

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
            hud.Draw(spriteBatch, mappy.MapWidth * mappy.TileSize, 0);
        }
    }
}
