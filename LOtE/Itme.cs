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
    class Itme
    {
        //Имя вещи
        public String Name { get; set; }
        //ID
        public int ID { get; set; }
        //Прочность
        public int strength { get; set; }
        //Текстура
        protected Texture2D texture;
        //Флаг на выпадние в мир
        public bool DropOrNo { get; set; }
        //Далее описаны координаты и Rectangle при выпадении в мир.
        private Rectangle rectangle;
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
        public int X
        {
            get
            {
                return rectangle.X;
            }
            set
            {
                rectangle.X = value;
            }
        }
        public int Y
        {
            get
            {
                return rectangle.Y;
            }
            set
            {
                rectangle.Y = value;
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
        //public Itme(Texture2D texture, Rectangle rectangle, Position position)
        //{
        //    Texture = texture;
        //    this.rectangle = rectangle;
        //    X = position.X;
        //    Y = position.Y;
        //}
        public void SetPosition(Position position)
        {
            X = position.X;
            Y = position.Y;
        }
    }
}
