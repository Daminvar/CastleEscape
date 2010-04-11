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
    class ItemState : State
    {
        private const int XPOS = 100;
        private const int YPOS = 50;
        private const int WIDTH = 500;
        private const int HEIGHT = 400;
        private Player player;
        private Texture2D texture;
        private SpriteFont font;
        private TextMenu menu;

        public ItemState(Game game, Player player)
            : base(game)
        {
            this.player = player;
            texture = new Texture2D(game.GraphicsDevice, 1, 1);
            texture.SetData<Color>(new Color[] { new Color(Color.Black, 150) });
            font = game.Content.Load<SpriteFont>("inventory-header-font");
            menu = new TextMenu(game.Content.Load<SpriteFont>("inventory-list-font"), getStringOfPlayerItems());
        }

        private string[] getStringOfPlayerItems()
        {
            string[] playerItems = new string[player.Items.Count];
            for (int i = 0; i < player.Items.Count; i++)
                playerItems[i] = player.Items[i].ToString();
            return playerItems;
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }

        public override void Update(GameTime gameTime)
        {
            menu.Update(gameTime, Keyboard.GetState());
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(XPOS, YPOS, WIDTH, HEIGHT), Color.White);
            spriteBatch.DrawString(font, "Inventory", new Vector2(XPOS + 5, YPOS + 5), Color.White);
            menu.Draw(spriteBatch, XPOS + 5, YPOS + 30);
        }
    }
}
