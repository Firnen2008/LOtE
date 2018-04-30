using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LOtE
{
    class Gui
    {
        protected Texture2D texture;
        private Rectangle rectangle;
        private SpriteFont font;
        private int xForFont;
        private int yForFont;

        public Container GuiContainer { get; set; }
        public string Text { get; set; }

        /// <summary>
        /// Координаты размещения шрифта в GuiContainer
        /// </summary>
        public int XForFont
        {
            get
            {
                return xForFont;
            }
            set
            {
                xForFont = (((GuiContainer.Width.X2 - GuiContainer.Width.X1) / 2) + GuiContainer.Width.X1) + value;
            }
        }
        public int YForFont
        {
            get
            {
                return yForFont;
            }
            set
            {
                yForFont = (((GuiContainer.Height.X2 - GuiContainer.Height.X1) / 2) + GuiContainer.Height.X1) + value;
            }
        }

        /// <summary>
        /// Координаты размещения текстуры в GuiContainer
        /// </summary>
        public int XForTexture
        {
            get
            {
                return rectangle.X;
            }
            set
            {
                rectangle.X = (((GuiContainer.Width.X2 - GuiContainer.Width.X1) / 2) + GuiContainer.Width.X1) + value;
            }
        }

        public int YForTexture
        {
            get
            {
                return rectangle.Y;
            }
            set
            {
                rectangle.Y = (((GuiContainer.Height.X2 - GuiContainer.Height.X1) / 2) + GuiContainer.Height.X1) + value;
            }
        }
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
        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
            set
            {
                rectangle = value;
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
        public void SetFont(SpriteFont font , string text)
        {
            Font = font;
            Text = text;
        }

        /// <summary>
        /// Метод отрисовки Gui (включает отрисовку текстуры и текста относительно GuiContainer)
        /// </summary>
        public void DrowGui(GameTime gametime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw( Texture, Rectangle, Color.Gray );
            spriteBatch.DrawString(Font, Text, new Vector2((float)XForFont, (float)YForFont), Color.White);
        }

    }
}
