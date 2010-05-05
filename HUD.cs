using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

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
        Image background;
        Font font;
        Player player;
        ScriptableMap map;
        int screenSize;
        
        public HUD(Player player, ScriptableMap map)
        {
            font = Font.DefaultFont; //TODO fix
            background = new Image(1, 1, new Color(100, 100, 100, 100));
            this.player = player;
            this.map = map;
            screenSize = 480; //TODO fix
        }

        /// <summary>
        /// Draws the HUD.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to use.</param>
        /// <param name="xPos">The X coordinate to draw at.</param>
        /// <param name="yPos">The Y coordinate to draw at.</param>
        public void Draw(RenderWindow window, int xPos, int yPos)
        {
			var bgSprite = new Sprite(background);
			bgSprite.Position = new Vector2(xPos, yPos);
			bgSprite.Scale = new Vector2(WIDTH, HEIGHT);
			window.Draw(bgSprite);
			bgSprite.Position = new Vector2(xPos, HEIGHT);
			bgSprite.Scale = new Vector2(WIDTH, screenSize - HEIGHT);
			window.Draw(bgSprite);

            string[] stats = new string[] {
                 string.Format("HP: {0}/{1}", player.Health, player.MaxHealth),
                 string.Format("MP: {0}/{1}", player.Mana, player.MaxMana),
                 string.Format("Gold: {0}", player.Gold),
                 string.Format("Level: {0}", player.Level),
                 map.MapName,
             };

            for (int i = 0; i < stats.Length; i++)
            {
				var statString = new String2D(stats[i], font);
                statString.Position = new Vector2(xPos + 5, yPos + i * font.LineSpacing + 5);
                window.Draw(statString);
            }
        }
    }
}
