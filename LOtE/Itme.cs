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
        private int number;
        public bool StuckOrNot;
        public int PersID;
        //Имя вещи
        public String Name { get; set; }
        //ID предмета
        public int ID { get; set; }
        //глобальный ID предмета
        public int GlobalID { get; set; }
        public string TextID { get; set; }
        //Текстура
        protected Texture2D texture;
        //Флаг на выпадние в мир
        public bool DropOrNo { get; set; } = true;
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
        public int XWorld
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
        public int YWorld
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
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (StuckOrNot == true)
                {
                    if ((number + value) < 64)
                        number = value;
                }
                else number = 1;
            }
        }
        // Конструктор предмета
        public Itme(Texture2D texture, Rectangle rectangle, String name, int number, int persID)
        {
            Texture = texture;
            this.rectangle = Rectangle;
            Name = name;
            Number = number;
        }
        public Itme() { }
        public void SetPosition(Position position)
        {
            X = position.X;
            Y = position.Y;
        }

    }
}
