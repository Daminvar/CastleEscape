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
    /// A state for viewing and using items.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class ItemState : State
    {
        private const int XPOS = 100;
        private const int YPOS = 50;
        private const int WIDTH = 500;
        private const int HEIGHT = 400;
        private Player player;
        private Image background;
        private SpriteFont font;
        private TextMenu menu;
        private bool canPressEscape;
        private bool oneTimeUse;

        public ItemState(Player player, bool oneTimeUse)
            : base()
        {
            this.player = player;
            background = new Image(1, 1, Color.Black); //TODO
            font = Font.DefaultFont; //TODO
            //The menu is only needed if the player has items.
            if (player.Items.Count > 0)
                menu = new TextMenu(game.Content.Load<SpriteFont>("inventory-list-font"), getStringOfPlayerItems());
            canPressEscape = false;
            transparent = true;
            this.oneTimeUse = oneTimeUse;
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
            if (player.Items.Count > 0)
                menu = new TextMenu(Font.DefaultFont, getStringOfPlayerItems());
            if (oneTimeUse)
                StateManager.PopState();
        }

        public override void Update(Clock clock, Input input)
        {
            if (!input.IsKeyDown(KeyCode.Escape))
                canPressEscape = true;

            if (player.Items.Count > 0)
            {
                menu.Update(clock, input);
                if (menu.IsFinished)
                {
                    //Use the selected item
                    Item itemToUse = player.Items[menu.SelectedOption];
                    player.Health += itemToUse.HealthBonus;
                    player.Mana += itemToUse.ManaBonus;
                    player.Items.RemoveAt(menu.SelectedOption);
                    StateManager.PushState(new Dialogue(game, "You used a " + itemToUse.Name + "!"));
                }
            }

            if (!canPressEscape)
                return;

            if (input.IsKeyDown(KeyCode.Escape))
                StateManager.PopState();
        }

        public override void Draw(RenderWindow window)
        {
			var bgSprite = new Sprite(background);
			bgSprite.Position = new Vector2(XPOS, YPOS);
			bgSprite.Scale = new Vector2(WIDTH, HEIGHT);
			window.Draw(bgSprite);
			var header = new String2D("Inventory - Press 'Esc' to quit.", font);
			header.Position = new Vector2(XPOS + 5, YPOS + 5);
			header.Color = Color.White;
            window.Draw(header);
            if (player.Items.Count > 0)
                menu.Draw(window, XPOS + 5, YPOS + 30, Color.White);
            else
			{
				var errorText = new Sprite("You don't have any items!", font);
				errorText.Position = new Vector2(XPOS + 5, YPOS + 50);
				errorText.Color = Color.White;
                menu.Draw(errorText);
			}
        }
    }
}
