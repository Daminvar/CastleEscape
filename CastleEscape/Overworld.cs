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

        private const float TILE_SIZE = 32.0f;
        Player playerObj;
        Map mappy;
        // npes

        int timer;


        public override void Initialize()
        {
            playerObj = new Player(0, 0, game.Content.Load<Texture2D>("ghostie"), game);
            mappy = new Map(game);
            mappy.LoadMap("testmap.tmx");
            timer = 0;
        }

        public override void Pause()
        {
            // stops music and stuff to prepare to go to a new state
        }

        public override void Resume()
        {
            // resumes everything when returning to the overworld state
        }

        public override void Update()
        {
            // checks for updates
            HandleInput();

            timer++;
        }

        public void HandleInput()
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
                            timer = 0;
                        }
                    }
                }
                else if (kbState.IsKeyDown(Keys.Right))
                {
                    if (playerObj.X + 1 < mappy.MapWidth)
                    {
                        if (mappy.IsCollisionAt(playerObj.X + 1, playerObj.Y) == false)
                        {
                            playerObj.Move(1, 0);
                            timer = 0;
                        }
                    }
                }
                else if (kbState.IsKeyDown(Keys.Up))
                {
                    if (playerObj.Y - 1 >= 0)
                    {
                        if (mappy.IsCollisionAt(playerObj.X, playerObj.Y - 1) == false)
                        {
                            playerObj.Move(0, -1);
                            timer = 0;
                        }
                    }
                }
                else if (kbState.IsKeyDown(Keys.Down))
                {
                    if (playerObj.Y + 1 < mappy.MapHeight)
                    {
                        if (mappy.IsCollisionAt(playerObj.X, playerObj.Y + 1) == false)
                        {
                            playerObj.Move(0, 1);
                            timer = 0;
                        }
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // draws player, tells map to draw itself
            //playerObj.DrawForOverworld(spriteBatch);
            mappy.DrawBase(spriteBatch, 0, 0);

            Vector2 v2 = new Vector2((float)playerObj.X * TILE_SIZE, (float)playerObj.Y * TILE_SIZE);

            spriteBatch.Draw(playerObj.Texture, v2, Color.White);

            mappy.DrawTop(spriteBatch, 0, 0);
        }
    }
}
