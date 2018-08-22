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
    class GuiContainer : Gui
    {
        public Container ContainerGui { get; set; }
        /// <summary>
        /// Конструктор для текста и картинки
        /// </summary>
        public GuiContainer(Texture2D texture, Container container, int textureX, int textureY, SpriteFont font, string text, int fontX, int fontY) : base()
        {
            Texture = texture;
            ContainerGui = container;
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
        public GuiContainer(Container container, SpriteFont font, string text, int fontX, int fontY)//для отрисовки только текста 
        {
            ContainerGui = container;
            Font = font;
            Text = text;
            cordFont.X = ((((container.Width.X2 - container.Width.X1) / 2) + container.Width.X1) - (container.Width.X2 - container.Width.X1) / 2) + fontX;
            cordFont.Y = ((((container.Height.X2 - container.Height.X1) / 2) + container.Height.X1) - (container.Height.X2 - container.Height.X1) / 2) + fontY;
        }
    }
}
