using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LOtE
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Vector2 position = Vector2.Zero;
        Pers pers;
        Container cont;

        KeyboardState crrKS;
        KeyboardState preKS;

        int currentTime = 0; // сколько времени прошло
        int period = 50; // период обновления в миллисекундах

        float fps = 60;

        float Fps
        {
            get
            {
                return fps;
            }
            set
            {
                if (fps + 50 > 1200)
                {
                    fps = 1200;
                }
                else
                {
                    fps = value;
                }
            }
        }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            cont = new Container(new Line(10, graphics.PreferredBackBufferWidth - 10), new Line(10, graphics.PreferredBackBufferHeight - 10), 0, 0);
            
        }

        protected override void Initialize()
        {
            base.Initialize();
            pers = new Pers(Content.Load<Texture2D>(@"images/pers"), new Rectangle(30, cont.Height.X2 / 2, 30, 30), 149, 150, new Line(0, 0), new Line(8, 1));
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            { Exit(); }

            currentTime += gameTime.ElapsedGameTime.Milliseconds;

            crrKS = Keyboard.GetState();
            //управление движением персонажа
            if (preKS.IsKeyUp(Keys.S) && preKS.IsKeyUp(Keys.A) && preKS.IsKeyUp(Keys.D) && preKS.IsKeyUp(Keys.W))//Down , Left , Right , Up
            {
                pers.Direction = Direction.Stop;
                pers.PersDirection = PersDirection.Standart;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.W))//left && Up
            {
                pers.Direction = Direction.LeftUp;
                pers.PersDirection = PersDirection.Run;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))//Up && right
            {
                pers.Direction = Direction.UpRight;
                pers.PersDirection = PersDirection.Run;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.S))//right && down
            {
                pers.Direction = Direction.RightDown;
                pers.PersDirection = PersDirection.Run;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.A))//down && left
            {
                pers.Direction = Direction.DownLeft;
                pers.PersDirection = PersDirection.Run;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.A) && !(Keyboard.GetState().IsKeyDown(Keys.W)) && !(Keyboard.GetState().IsKeyDown(Keys.S)))
            {
                pers.Direction = Direction.Left;
                pers.PersDirection = PersDirection.Run;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) && !(Keyboard.GetState().IsKeyDown(Keys.S)) && !(Keyboard.GetState().IsKeyDown(Keys.W)))
            {
                pers.Direction = Direction.Right;
                pers.PersDirection = PersDirection.Run;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && !(Keyboard.GetState().IsKeyDown(Keys.A)) && !(Keyboard.GetState().IsKeyDown(Keys.D)))
            {
                pers.Direction = Direction.Up;
                pers.PersDirection = PersDirection.Run;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && !(Keyboard.GetState().IsKeyDown(Keys.A)) && !(Keyboard.GetState().IsKeyDown(Keys.D)))
            {
                pers.Direction = Direction.Down;
                pers.PersDirection = PersDirection.Run;
            }

            //Анимация персонажа
            if (currentTime > period)
            {
                currentTime -= period;
                pers.Animation(3,1,1);
            }
            //Скорость передвижения персонажа
            pers.Move(3);

            preKS = crrKS;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //spriteBatch.Draw(pers.Texture,pers.Rectangle,Color.White);
        //Отрисовка персонажа     
            spriteBatch.Draw(pers.Texture, new Vector2(pers.X, pers.Y),
   new Rectangle(pers.currentFrame.X1 * pers.FrameWidth,
       pers.currentFrame.X2 * pers.FrameHeight,
       pers.FrameWidth, pers.FrameHeight),
   Color.White, 0, Vector2.Zero,
   1, pers.effect, 0);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
