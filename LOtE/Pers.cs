using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LOtE
{
    class Pers
    {
        protected Texture2D texture;
        protected Texture2D shieldTexture;
        private int frameWidth;
        private int frameHeight;
        public SpriteEffects effect;
        public Line currentFrame;
        public Line spriteSize;
        public int ID;
        public string textID;
        private bool animationFlag = false;
        private int animationaccount = 0;

        public Line CurrentFrame
        {
            get
            {
                return currentFrame;
            }
            set
            {
                currentFrame = value;
            }
        }
        public Line SpriteSize
        {
            get
            {
                return spriteSize;
            }
            set
            {
                spriteSize = value;
            }
        }

        public int FrameWidth
        {
            get
            {
                return frameWidth;
            }
            set
            {
                frameWidth = value;
            }
        }
        public int FrameHeight
        {
            get
            {
                return frameHeight;
            }
            set
            {
                frameHeight = value;
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
        public States Direction { get; set; }
        public PersDirection PersDirection { get; set; }

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
        public Pers(Texture2D texture, Rectangle rectangle, int frameWidth, int frameHeight, Line currentFrame, Line spriteSize, int id)
        {
            Texture = texture;
            this.rectangle = rectangle;
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            CurrentFrame = currentFrame;
            SpriteSize = spriteSize;
            ID = id;
            textID = "pers" + ID;
    }
        public Pers(Texture2D texture, Rectangle rectangle, Position position)
        {
            Texture = texture;
            this.rectangle = rectangle;
            X = position.X;
            Y = position.Y;
        }
        ///<summary>
        ///Анимация проигрывания спрайтов персонажа
        ///</summary>
        ///<param name="size">количество спрайтов</param>
        ///<param name="start">столбец</param>
        ///<param name="row">строка</param>
        public void Animation(int size, int start, int row) 
        {
            //if (animationFlag = false)
            //{
            //    currentFrame.X1 = start - 1;
            //    currentFrame.X2 = row;
            //    animationFlag = true;
            //}
            ++currentFrame.X1;
            ++animationaccount;
            if (animationaccount >= size)
            {
                currentFrame.X1 = start-1;
                animationaccount = 0;
                animationFlag = false;
            }
            if (currentFrame.X1 >= spriteSize.X1)
            {
                currentFrame.X1 = start-1;
                ++currentFrame.X2;
                if (currentFrame.X2 >= spriteSize.X2)
                    currentFrame.X2 = 0;
            }
        }
        ///<summary>
        ///Задание координат X,Y персонажа
        ///</summary>
        public void SetPosition(Position position)
        {
            X = position.X;
            Y = position.Y;
        }
        ///<summary>
        ///Метод отрисовки персонажа
        ///</summary>
        public void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, rectangle, Color.White);
        }
        ///<summary>
        ///Метод управление движением персонажа с помощью wasd
        ///</summary>
        ///Правил код CreaHaGame
        public void Move(int speed, MouseState Mstate)
        {

            switch (Direction)
            {
                //для ходьбы по диагонали
                case States.LeftUp:
                    X -= speed;
                    Y -= speed;
                    effect = (Mstate.X > X) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                    //effect = SpriteEffects.None;//FlipHorizontally
                    break;
                case States.UpRight:
                    Y -= speed;
                    X += speed;
                    effect = (Mstate.X > X) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                    //effect = SpriteEffects.FlipHorizontally;
                    break;
                case States.RightDown:
                    Y += speed;
                    X += speed;
                    effect = (Mstate.X > X) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                    //effect = SpriteEffects.FlipHorizontally;
                    break;
                case States.DownLeft:
                    Y += speed;
                    X -= speed;
                    effect = (Mstate.X > X) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                    //effect = SpriteEffects.None;
                    break;

                case States.Left:
                    X -= speed;
                    effect = (Mstate.X > X) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                    //effect = SpriteEffects.None;
                    break;
                case States.Up:
                    Y -= speed;
                    break;
                case States.Right:
                    X += speed;
                    effect = (Mstate.X > X) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                    //effect = SpriteEffects.FlipHorizontally;
                    break;
                case States.Down:
                    Y += speed;
                    break;
                case States.Stop:
                    Y = Y;
                    X = X;
                    break;
            }
            //=========================================================================================================================================================

        }
    }
}
