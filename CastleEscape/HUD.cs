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
    /// The HUD for the Overworld state. Displays basic player information
    /// and the name of the current room.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class HUD
    {
        private const int HEIGHT = 120;
        private const int WIDTH = 160;
        Texture2D background;
        SpriteFont font;
        Player player;
        ScriptableMap map;
        int screenSize;
        
        public HUD(Game game, Player player, ScriptableMap map)
        {
            font = game.Content.Load<SpriteFont>("hud-font");
            background = new Texture2D(game.GraphicsDevice, 1, 1);
            background.SetData<Color>(new Color[] { new Color(100, 100, 100) });
            this.player = player;
            this.map = map;
            screenSize = game.GraphicsDevice.Viewport.Height;
        }

        /// <summary>
        /// Draws the HUD.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to use.</param>
        /// <param name="xPos">The X coordinate to draw at.</param>
        /// <param name="yPos">The Y coordinate to draw at.</param>
        public void Draw(SpriteBatch spriteBatch, int xPos, int yPos)
        {
            spriteBatch.Draw(background, new Rectangle(xPos, yPos, WIDTH, HEIGHT), Color.White);
            spriteBatch.Draw(background, new Rectangle(xPos, HEIGHT, WIDTH, screenSize - HEIGHT), Color.Black);

            string[] stats = new string[] {
                 string.Format("HP: {0}/{1}", player.Health, player.MaxHealth),
                 string.Format("MP: {0}/{1}", player.Mana, player.MaxMana),
                 string.Format("Gold: {0}", player.Gold),
                 string.Format("Level: {0}", player.Level),
                 map.MapName,
             };

            for (int i = 0; i < stats.Length; i++)
            {
                var pos = new Vector2(xPos + 5, yPos + i * font.LineSpacing + 5);
                spriteBatch.DrawString(font, stats[i], pos, Color.White);
            }
        }
    }
}
