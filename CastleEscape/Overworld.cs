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

        private const float TILE_SIZE = 5.0f;
        Player playerObj;
        Map mappy;
        // npes

        public override void Initialize()
        {
            playerObj = new Player(Vector2.Zero, game.Content.Load<Texture2D>("ghostie"));
            mappy = new Map(game);
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
        }

        public void HandleInput()
        {
            // handle input
            KeyboardState kbState = Keyboard.GetState();

            if (kbState.IsKeyDown(Keys.Left))
            {
                playerObj.Move(-TILE_SIZE, 0.0f);
            }
            if (kbState.IsKeyDown(Keys.Right))
            {
                playerObj.Move(TILE_SIZE, 0.0f);
            }
            if (kbState.IsKeyDown(Keys.Up))
            {
                playerObj.Move(0.0f, -TILE_SIZE);
            }
            if (kbState.IsKeyDown(Keys.Down))
            {
                playerObj.Move(0.0f, TILE_SIZE);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // draws player, tells map to draw itself
            //playerObj.DrawForOverworld(spriteBatch);
            spriteBatch.Draw(playerObj.Texture, playerObj.Position, Color.White);
        }
    }
}
