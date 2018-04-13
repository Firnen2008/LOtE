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
            //TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 400);
            cont = new Container(new Line(10, graphics.PreferredBackBufferWidth - 10), new Line(10, graphics.PreferredBackBufferHeight - 10));
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
                Exit();

            currentTime += gameTime.ElapsedGameTime.Milliseconds;

            crrKS = Keyboard.GetState();

            if (preKS.IsKeyUp(Keys.Down) && preKS.IsKeyUp(Keys.Left) && preKS.IsKeyUp(Keys.Right) && preKS.IsKeyUp(Keys.Up))
            {
                pers.Direction = Direction.Stop;
                pers.PersDirection = PersDirection.Standart;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                pers.Direction = Direction.Left;
                pers.PersDirection = PersDirection.Run;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                pers.Direction = Direction.Right;
                pers.PersDirection = PersDirection.Run;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                pers.Direction = Direction.Up;
                pers.PersDirection = PersDirection.Run;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                pers.Direction = Direction.Down;
                pers.PersDirection = PersDirection.Run;
            }
            if (currentTime > period)
            {
                currentTime -= period;
                pers.Animation();
            }

            pers.Move(1);

            preKS = crrKS;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //spriteBatch.Draw(pers.Texture,pers.Rectangle,Color.White);

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
