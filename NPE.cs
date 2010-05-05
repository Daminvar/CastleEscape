using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    /// <summary>
    /// Represents a non-player entity.
    /// 
    /// Author: Dennis Honeyman
    /// </summary>
    class NPE
    {
        private Action<Player> interactFunc;
        private Image texture;
        private int xPos, yPos;

        public NPE()
        {
        }

        public int XPos
        {
            get { return xPos; }
        }

        public int YPos
        {
            get { return yPos; }
        }

        public void DrawBase(RenderWindow window, ScriptableMap map, int x, int y)
        {
            if (texture == null)
                return;
            var baseSprite = new Sprite(texture);
            int sourceX = 0;
            int sourceY = (int)texture.Height - map.TileSize;
            baseSprite.SubRect = new IntRect(sourceX, sourceY, sourceX + map.TileSize, sourceY + map.TileSize);
            baseSprite.Position = new Vector2(x + xPos * map.TileSize, y + yPos * map.TileSize);
            window.Draw(baseSprite);
        }

        public void DrawTop(RenderWindow window, ScriptableMap map, int x, int y)
        {
            if (texture == null)
                return;
            var topSprite = new Sprite(texture);
            int renderX = x + xPos * map.TileSize;
            int renderY = (int)(y + yPos * map.TileSize - (texture.Height - map.TileSize));
            topSprite.SubRect = new IntRect(0, 0, map.TileSize, (int)(texture.Height - map.TileSize));
            topSprite.Position = new Vector2(renderX, renderY);
            window.Draw(topSprite);
        }

        public void SetPosition(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        public void SetTexture(string textureName)
        {
            texture = ContentManager.LoadImage(textureName);
        }

        public void SetInteractFunc(Action<Player> func)
        {
            interactFunc = func;
        }

        public void Interact(Player player)
        {
            var thread = new Thread(new ParameterizedThreadStart(interact));
            thread.Start(player);
        }

        private void interact(object player)
        {
            interactFunc((Player)player);
        }
    }
}
