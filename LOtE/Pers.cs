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
        private SpriteEffects effect;
        public Line currentFrame;
        public Line spriteSize;

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
                case Direction.Left:
                    X -= speed;
                    effect = SpriteEffects.FlipVertically;
                    break;
                case Direction.Up:
                    Y -= speed;
                    break;
                case Direction.Right:
                    X += speed;
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
