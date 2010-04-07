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
    /// Will draw a pause state 
    /// 
    /// 
    /// Authors:
    ///         Matt Munns
    /// </summary>
    class PauseState : State
    {
        private string message;
        private Texture2D bgcolor;
        private int height;
        private bool canPressEscape;
        


        private SpriteFont font;

        public PauseState(Game game)
            : base(game)
        {

            //pause = new PauseState(game);
            bgcolor = new Texture2D(game.GraphicsDevice, 1, 1);
            bgcolor.SetData<Color>(new Color[] { new Color(Color.Black, 200) });
            transparent = true;
            height = game.GraphicsDevice.Viewport.Height;
            font = game.Content.Load<SpriteFont>("dialogue-font");
            message = "               Paused   \n Hit 'Escape Key' to unpause";
           canPressEscape = false;

            
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyUp(Keys.Escape))
            {
                canPressEscape = true;
                
                return;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) && canPressEscape)
            {
                StateManager.PopState();

            }
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rc = new Rectangle(0, game.GraphicsDevice.Viewport.Height * 25/100, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            
            spriteBatch.Draw(bgcolor, rc, Color.White);
            spriteBatch.DrawString(font,message, new Vector2(200.0f, (float) ((game.GraphicsDevice.Viewport.Height * 40/100) + 75)),Color.White);


        }

        public override void Resume()
        {
        }

        public override void Pause()
        {
        }
    }
}
