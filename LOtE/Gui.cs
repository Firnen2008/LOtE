using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LOtE
{
    class Gui
    {
        protected Texture2D texture;
        private Rectangle rectangleTexture;
        private SpriteFont font;

        public Container GuiContainer { get; set; }
        public string Text { get; set; }
        public Vector2 cordFont;

        /// <summary>
        /// Координаты размещения текстуры в GuiContainer
        /// </summary>

        public SpriteFont Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
        }
        public Texture2D Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }
        public Rectangle RectangleTexture
        {
            get
            {
                return rectangleTexture;
            }
            set
            {
                rectangleTexture = value;
            }
        }

        /// <summary>
        /// Установка текстуры Gui вне конструктора
        /// </summary>
        public void SetTexture(Texture2D texture)
        {
            Texture = texture;
        }
        /// <summary>
        /// Установка текстуры шрифта и текста Gui вне конструктора
        /// </summary>
        public void SetFont(SpriteFont font, string text)
        {
            Font = font;
            Text = text;
        }
        /// <summary>
        /// Конструктор для текста и картинки
        /// </summary>
        public Gui(Texture2D texture, Container container, int textureX, int textureY, SpriteFont font, string text, int fontX, int fontY)
        {
            Texture = texture;
            GuiContainer = container;
            rectangleTexture.X = ((((container.Width.X2 - container.Width.X1) / 2) + container.Width.X1) - (container.Width.X2 - container.Width.X1) / 2) + textureX;
            rectangleTexture.Y = ((((container.Height.X2 - container.Height.X1) / 2) + container.Height.X1) - (container.Height.X2 - container.Height.X1) / 2) + textureY;
            rectangleTexture.Width = container.Width.X2 - container.Width.X1;
            rectangleTexture.Height = container.Height.X2 - container.Height.X1;
            Font = font;
            Text = text;
            cordFont.X = ((((container.Width.X2 - container.Width.X1) / 2) + container.Width.X1) - (container.Width.X2 - container.Width.X1) / 2) + fontX;
            cordFont.Y = ((((container.Height.X2 - container.Height.X1) / 2) + container.Height.X1) - (container.Height.X2 - container.Height.X1) / 2) + fontY;
        }
        /// <summary>
        /// Конструктор для текста
        /// </summary>
        public Gui(Container container, SpriteFont font, string text, int fontX, int fontY)//для отрисовки только текста 
        {
            GuiContainer = container;
            Font = font;
            Text = text;
            cordFont.X = ((((container.Width.X2 - container.Width.X1) / 2) + container.Width.X1) - (container.Width.X2 - container.Width.X1) / 2) + fontX;
            cordFont.Y = ((((container.Height.X2 - container.Height.X1) / 2) + container.Height.X1) - (container.Height.X2 - container.Height.X1) / 2) + fontY;
        }
        /// <summary>
        /// Метод отрисовки Gui (включает отрисовку текстуры и текста относительно GuiContainer)
        /// </summary>
        public void DrowMainGui(GameTime gametime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, RectangleTexture, Color.Gray);
            spriteBatch.DrawString(Font, Text, cordFont, Color.White);
        }
        /// <summary>
        /// Метод отрисовки Текста без картинки (включает отрисовку текста относительно GuiContainer)
        /// </summary>
        public void DrowTGui(GameTime gametime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Text, cordFont, Color.White);
        }

    }
}