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
    /// It's a store! You can buy things here!
    /// 
    /// Author(s):
    ///         Allyson Sadwin
    /// </summary>
    class Store : State
    {
        public const int XPOS = 10;
        public const int YPOS = 40;
        public const int STORE_WIDTH = 640;
        public const int STORE_HEIGHT = 420;
        private Player player;
        private Item[] storeInventory;
        private Texture2D storeTexture;
        private SpriteFont spriteFont;
        private TextMenu textInventory;
        private bool canExit;

        public Store(Game game, Player pl, Item[] items)
            : base(game)
        {
            player = pl;
            storeInventory = items;
            storeTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            storeTexture.SetData<Color>(new Color[] { new Color(Color.Gray, 255) });
            spriteFont = game.Content.Load<SpriteFont>("inventory-list-font");
            textInventory = new TextMenu(spriteFont, this.getItemNames(storeInventory));
            canExit = false;
        }

        private string[] getItemNames(Item[] items)
        {
            string[] itemNames = new string[storeInventory.Length];
            for (int i = 0; i < items.Length; i++)
            {
                itemNames[i] = storeInventory[i].ToString() + "  Cost: " + storeInventory[i].Cost + " gold";
            }

            return itemNames;
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
            textInventory = new TextMenu(spriteFont, this.getItemNames(storeInventory));
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState kbState = Keyboard.GetState();

            if (kbState.IsKeyUp(Keys.Escape))
            {
                canExit = true;
            }

            if (storeInventory.Length != 0)
            {
                textInventory.Update(gameTime, kbState);
                if (textInventory.IsFinished)
                {
                    Item buyItem = storeInventory[textInventory.SelectedOption];
                    if (player.Gold >= buyItem.Cost)
                    {
                        player.Gold -= buyItem.Cost;
                        player.Items.Add(buyItem);
                        StateManager.PushState(new Dialogue(game, "You bought " + buyItem.Name + " for " + buyItem.Cost + " gold!"));
                    }
                    else
                    {
                        StateManager.PushState(new Dialogue(game, "You don't have enough gold for that!"));
                    }
                }
            }

            if (canExit == false)
            {
                return;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(storeTexture, new Rectangle(XPOS, YPOS, STORE_WIDTH, STORE_HEIGHT), Color.White);
            spriteBatch.DrawString(spriteFont, "Welcome to the store.", new Vector2(XPOS + 10, YPOS + 5), Color.White);
            spriteBatch.DrawString(spriteFont, "Current gold: " + player.Gold, new Vector2(XPOS + 440, YPOS + 5), Color.White);
            for (int i = 0; i < storeInventory.Length; i++)
            {
                textInventory.Draw(spriteBatch, XPOS + 10, YPOS + 30);
            }

            spriteBatch.Draw(storeTexture, new Rectangle(XPOS + STORE_WIDTH + 10, YPOS, 200, STORE_HEIGHT), Color.Gray);
            spriteBatch.DrawString(spriteFont, "Inventory", new Vector2(XPOS + STORE_WIDTH + 45, YPOS + 5), Color.Wheat);

            for(int i = 0; i < player.Items.Count; i++)
            {
                spriteBatch.DrawString(spriteFont, player.Items[i].Name, new Vector2(XPOS + STORE_WIDTH + 20, YPOS + 5 + ((i+1) * 14)), Color.White);
            }


        }
    }
}
