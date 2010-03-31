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


        public override void Initialize()
        {
            playerObj = new Player(0, 0, game.Content.Load<Texture2D>("ghostie"));
            mappy = new Map(game);
            mappy.LoadMap("testmap.js");
            timer = 0;
            canPressZ = false;
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            // draws player, tells map to draw itself
            //playerObj.DrawForOverworld(spriteBatch);
            mappy.DrawBase(spriteBatch, 0, 0);

            Vector2 v2 = new Vector2(playerObj.XPos * mappy.TileSize, playerObj.YPos * mappy.TileSize);

            spriteBatch.Draw(playerObj.Texture, v2, Color.White);

            mappy.DrawTop(spriteBatch, 0, 0);
        }
    }
}
