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
    class HUD
    {
        private const int HEIGHT = 120;
        private const int WIDTH = 160;
        Texture2D background;
        SpriteFont font;
        Player player;
        Map map;

        public HUD(Game game, Player player, Map map)
        {
            font = game.Content.Load<SpriteFont>("hud-font");
            background = new Texture2D(game.GraphicsDevice, 1, 1);
            background.SetData<Color>(new Color[] { new Color(Color.WhiteSmoke, 100) });
            this.player = player;
            this.map = map;
        }

        public void Draw(SpriteBatch spriteBatch, int xPos, int yPos)
        {
            spriteBatch.Draw(background, new Rectangle(xPos, yPos, WIDTH, HEIGHT), Color.White);

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
