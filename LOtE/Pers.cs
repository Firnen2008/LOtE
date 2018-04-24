using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LOtE
{
    class Pers
    {
        //public Texture2D Texture { get; set; }

        //protected Texture2D texture;
        protected Texture2D texture;
        private int frameWidth;
        private int frameHeight;
        public SpriteEffects effect;
        public Line currentFrame;
        public Line spriteSize;
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
        public Direction Direction { get; set; }
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
        public Pers(Texture2D texture, Rectangle rectangle, int frameWidth, int frameHeight, Line currentFrame, Line spriteSize)
        {
            Texture = texture;
            this.rectangle = rectangle;
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            CurrentFrame = currentFrame;
            SpriteSize = spriteSize;
        }
        public Pers(Texture2D texture, Rectangle rectangle, Position position)
        {
            Texture = texture;
            this.rectangle = rectangle;
            X = position.X;
            Y = position.Y;
        }
        public void Animation(int size, int start, int row)
        {
            if (animationFlag = false)
            {
                currentFrame.X1 = start-1;
                currentFrame.X2 = row;
                animationFlag = true;
            }
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
        public void SetPosition(Position position)
        {
            X = position.X;
            Y = position.Y;
        }
        public void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, rectangle, Color.White);
        }

        public void Move(int speed)
        {
            switch (Direction)
            {
                //для ходьбы по диагонали //правил код CreaHaGame \/
                case Direction.LeftUp:
                    X -= speed;
                    Y -= speed;
                    effect = SpriteEffects.FlipHorizontally;
                    break;
                case Direction.UpRight:
                    Y -= speed;
                    X += speed;
                    effect = SpriteEffects.None;
                    break;
                case Direction.RightDown:
                    Y += speed;
                    X += speed;
                    effect = SpriteEffects.None;
                    break;
                case Direction.DownLeft:
                    Y += speed;
                    X -= speed;
                    effect = SpriteEffects.FlipHorizontally;
                    break;// //правил код CreaHaGame         /\

                case Direction.Left:
                    X -= speed;
                    effect = SpriteEffects.FlipHorizontally;
                    break;
                case Direction.Up:
                    Y -= speed;
                    break;
                case Direction.Right:
                    X += speed;
                    effect = SpriteEffects.None;
                    break;
                case Direction.Down:
                    Y += speed;
                    break;
                case Direction.Stop:
                    Y = Y;
                    X = X;
                    break;
            }


        }
    }
}
