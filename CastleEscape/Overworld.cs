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
        Rectangle destinationRectangle;

        // create a counter for steps
        int pedometer;

        HUD hud;

        public Overworld(Game game, Player player, DrawableMap map)
            : base(game)
        {
            playerObj = player;
            mappy = map;

            if (mappy.OverworldMusic != null)
                MediaPlayer.Play(mappy.OverworldMusic);

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
        }

        public override void Resume()
        {
            canPressEscape = false;
            canPressZ = false;
            MediaPlayer.Volume = 1;
            MediaPlayer.IsRepeating = true;
            if (MediaPlayer.Queue.ActiveSong != mappy.OverworldMusic)
                MediaPlayer.Play(mappy.OverworldMusic);
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

            if (timer >= 200)
            {
                playerObj.ModX = 0;
                playerObj.ModY = 0;
            }

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

            if ((kbState.IsKeyDown(Keys.Left) || movingLeft) && !movingRight && !movingDown && !movingUp)
            {
                playerObj.Direction = Player.Directions.West;

                if (timer <= 150)
                {
                    movingLeft = true;
                }
                else
                {
                    movingLeft = false;
                }
                movingDown = false;
                movingRight = false;
                movingUp = false;

                if (mappy.IsCollisionAt(playerObj.XPos, playerObj.YPos) == false && playerObj.XPos >= 0)
                {
                    if (timer >= 50 && timer < 100)
                    {
                        playerObj.CurrentSpriteX = 1;
                        playerObj.ModX = -16;
                    }
                    else if (timer >= 100 && timer < 150)
                    {
                        playerObj.CurrentSpriteX = 0;
                        playerObj.ModX = -8;
                    }
                    else if (timer >= 150 && timer < 200)
                    {
                        playerObj.CurrentSpriteX = 1;
                        playerObj.ModX = 0;

                        pedometer++;

                        this.StartBattle(pedometer);
                    }
                }

                if (timer >= 200)
                {
                    if (mappy.IsCollisionAt(playerObj.XPos - 1, playerObj.YPos) == false)
                    {
                        playerObj.ModX = -24;
                        playerObj.CurrentSpriteX = 2;
                        movingLeft = true;
                    }
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
                        if (mappy.ChangeMap(ScriptableMap.Directions.West))
                        {
                            playerObj.Move(mappy.MapWidth - 1, 0);
                            timer = 0;
                        }
                        else
                        {
                            playerObj.ModX = 0;
                            movingLeft = false;
                            playerObj.CurrentSpriteX = 1;
                        }
                    }
                }
            }
            else if ((kbState.IsKeyDown(Keys.Right) || movingRight) && !movingLeft && !movingDown && !movingUp)
            {
                playerObj.Direction = Player.Directions.East;

                if (timer <= 150)
                {
                    movingRight = true;
                }
                else
                {
                    movingRight = false;
                }
                movingLeft = false;
                movingDown = false;
                movingUp = false;

                if (mappy.IsCollisionAt(playerObj.XPos, playerObj.YPos) == false && playerObj.XPos < mappy.MapWidth)
                {
                    if (timer >= 50 && timer < 100)
                    {
                        playerObj.CurrentSpriteX = 1;
                        playerObj.ModX = 16;
                    }
                    else if (timer >= 100 && timer < 150)
                    {
                        playerObj.CurrentSpriteX = 0;
                        playerObj.ModX = 8;
                    }
                    else if (timer >= 150 && timer < 200)
                    {
                        playerObj.CurrentSpriteX = 1;
                        playerObj.ModX = 0;

                        pedometer++;

                        this.StartBattle(pedometer);

                    }
                }

                if (timer >= 200)
                {
                    if (mappy.IsCollisionAt(playerObj.XPos + 1, playerObj.YPos) == false)
                    {
                        playerObj.ModX = 24;
                        playerObj.CurrentSpriteX = 2;
                        movingRight = true;
                    }
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
                        if (mappy.ChangeMap(ScriptableMap.Directions.East))
                        {
                            playerObj.Move(-(mappy.MapWidth) + 1, 0);
                            timer = 0;
                        }
                        else
                        {
                            playerObj.ModX = 0;
                            movingRight = false;
                            playerObj.CurrentSpriteX = 1;
                        }
                    }
                }
            }
            else if ((kbState.IsKeyDown(Keys.Up) || movingUp) && !movingLeft && !movingDown && !movingRight)
            {
                movingLeft = false;
                movingDown = false;
                movingRight = false;
                if (timer <= 150)
                {
                    movingUp = true;
                }
                else
                {
                    movingUp = false;
                }

                playerObj.Direction = Player.Directions.North;
                if (mappy.IsCollisionAt(playerObj.XPos, playerObj.YPos) == false && playerObj.YPos >= 0)
                {
                    if (timer >= 50 && timer < 100)
                    {
                        playerObj.CurrentSpriteX = 1;
                        playerObj.ModY = -16;
                    }
                    else if (timer >= 100 && timer < 150)
                    {
                        playerObj.CurrentSpriteX = 0;
                        playerObj.ModY = -8;
                    }
                    else if (timer >= 150 && timer < 200)
                    {
                        playerObj.CurrentSpriteX = 1;
                        playerObj.ModY = 0;

                        pedometer++;

                        this.StartBattle(pedometer);
                    }
                }

                if (timer >= 200)
                {
                    if (mappy.IsCollisionAt(playerObj.XPos, playerObj.YPos - 1) == false)
                    {
                        playerObj.ModY = -24;
                        playerObj.CurrentSpriteX = 2;
                        movingUp = true;
                    }
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
                        if (mappy.ChangeMap(ScriptableMap.Directions.North))
                        {
                            playerObj.Move(0, mappy.MapHeight - 1);
                            timer = 0;
                        }
                        else
                        {
                            playerObj.ModY = 0;
                            movingUp = false;
                            playerObj.CurrentSpriteX = 1;
                        }
                    }
                }
            }
            else if ((kbState.IsKeyDown(Keys.Down) || movingDown) && !movingLeft && !movingRight && !movingUp)
            {
                if (timer <= 150)
                {
                    movingDown = true;
                }
                else
                {
                    movingDown = false;
                }

                movingLeft = false;
                movingRight = false;
                movingUp = false;

                playerObj.Direction = Player.Directions.South;

                if (mappy.IsCollisionAt(playerObj.XPos, playerObj.YPos) == false && playerObj.YPos < mappy.MapHeight)
                {
                    if (timer >= 50 && timer < 100)
                    {
                        playerObj.CurrentSpriteX = 1;
                        playerObj.ModY = 16;
                    }
                    else if (timer >= 100 && timer < 150)
                    {
                        playerObj.CurrentSpriteX = 0;
                        playerObj.ModY = 8;
                    }
                    else if (timer >= 150 && timer < 200)
                    {
                        playerObj.CurrentSpriteX = 1;
                        playerObj.ModY = 0;
                        pedometer++;

                        this.StartBattle(pedometer);
                    }
                }

                if (timer >= 200)
                {
                    if (mappy.IsCollisionAt(playerObj.XPos, playerObj.YPos + 1) == false)
                    {
                        playerObj.ModY = 24;
                        playerObj.CurrentSpriteX = 2;
                        movingDown = true;
                    }
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
                        if (mappy.ChangeMap(ScriptableMap.Directions.South))
                        {
                            playerObj.Move(0, -(mappy.MapHeight) + 1);
                            timer = 0;
                        }
                        else
                        {
                            playerObj.ModY = 0;
                            movingDown = false;
                            playerObj.CurrentSpriteX = 1;
                        }
                    }
                }

            }

            if (kbState.IsKeyUp(Keys.Escape))
            {
                canPressEscape = true;
                return;
            }

            //Pauses the game
            if (kbState.IsKeyDown(Keys.Escape) && canPressEscape)
            {

                StateManager.PushState(new PauseState(game, playerObj));
                return;
            }
        }

        // This checks to see if a battle will start!
        public bool RandomEncounter(int steps)
        {
            // create a random number generator
            Random rng = new Random();

            int rdmNum = rng.Next(1, 1501);

            if (rdmNum < steps)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Check to see if a battle will start
        public void StartBattle(int ped)
        {
            pedometer = ped;

            bool re = this.RandomEncounter(pedometer);
            if (re)
            {
                Enemy currentEnemy = mappy.GetRandomEncounter();
                if (currentEnemy != null)
                {
                    StateManager.PushState(new Battle(game, mappy.BattleTexture, mappy.RandomBattleMusic, playerObj, currentEnemy, true));
                }
                pedometer = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            // draws player, tells map to draw itself
            mappy.DrawBase(spriteBatch, 0, 0);
            playerObj.DrawForOverworld(spriteBatch, mappy, 0, 0);
            mappy.DrawTop(spriteBatch, 0, 0);
            hud.Draw(spriteBatch, mappy.MapWidth * mappy.TileSize, 0);
        }
    }
}
