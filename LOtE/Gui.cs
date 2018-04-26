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
        private Container container;
        private SpriteFont font;
        
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
        public void DrowGui(GameTime gametime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw( Texture, Rectangle, Color.Gray );
        }

    }
}
