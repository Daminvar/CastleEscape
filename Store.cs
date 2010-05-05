using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;

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
        private Image storeTexture;
        private Image background;
        private Font spriteFont;
        private TextMenu textInventory;

        public Store(Player pl, Item[] items)
            : base()
        {
            player = pl;
            storeInventory = items;
            storeTexture = new Image(1, 1, new Color(200, 200, 200, 155));
            background = new Image("store-bg");
            spriteFont = Font.DefaultFont; //TODO fix
            textInventory = new TextMenu(spriteFont, this.getItemNames(storeInventory));
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

        public override void Update(Clock clock, Input input)
        {
            if (input.IsKeyDown(KeyCode.Escape))
                StateManager.PopState();

            if (storeInventory.Length != 0)
            {
                textInventory.Update(clock, input);
                if (textInventory.IsFinished)
                {
                    Item buyItem = storeInventory[textInventory.SelectedOption];
                    if (player.Gold >= buyItem.Cost)
                    {
                        player.Gold -= buyItem.Cost;
                        player.Items.Add(buyItem);
                        StateManager.PushState(new Dialogue("You bought " + buyItem.Name + " for " + buyItem.Cost + " gold!"));
                    }
                    else
                    {
                        StateManager.PushState(new Dialogue("You don't have enough gold for that!"));
                    }
                }
            }
        }

        public override void Draw(RenderWindow window)
        {
            var bgSprite = new Sprite(background);
            bgSprite.Scale = new Vector2(800, 480);
            window.Draw(bgSprite);
            var storeSprite = new Sprite(storeTexture);
            storeSprite.Position = new Vector2(XPOS, YPOS);
            storeSprite.Scale = new Vector2(STORE_WIDTH, STORE_HEIGHT);
            storeSprite.Color = new Color(200, 200, 200, 200);
            window.Draw(storeSprite);

            var header = new String2D("Welcome to the store. Press 'Esc' to quit.", spriteFont);
            header.Position = new Vector2(XPOS + 10, YPOS + 5);
            window.Draw(header);
            var curGold = new String2D("Current gold: " + player.Gold, spriteFont);
            curGold.Position = new Vector2(XPOS + 440, YPOS + 5);
            window.Draw(curGold);
            for (int i = 0; i < storeInventory.Length; i++)
            {
                textInventory.Draw(window, XPOS + 10, YPOS + 30, Color.White);
            }

            storeSprite.Position = new Vector2(XPOS + STORE_WIDTH + 10, YPOS);
            storeSprite.Scale = new Vector2(200, STORE_HEIGHT);
            storeSprite.Color = new Color(200, 200, 200, 180);
            window.Draw(storeSprite);

            var inventoryHeader = new String2D("Inventory", spriteFont);
            inventoryHeader.Position = new Vector2(XPOS + STORE_WIDTH + 45, YPOS + 5);
            inventoryHeader.Color = Color.Yellow;
            window.Draw(inventoryHeader);

            for (int i = 0; i < player.Items.Count; i++)
            {
                var itemString = new String2D(player.Items[i].Name, spriteFont);
                itemString.Position = new Vector2(XPOS + STORE_WIDTH + 20, YPOS + 5 + ((i + 1) * 14));
                window.Draw(itemString);
            }
        }
    }
}
