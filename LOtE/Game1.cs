using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Data.SQLite;
using System;
using System.IO;

namespace LOtE
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Gui MainGui;

        bool indicator1 = false;

        Vector2 position = Vector2.Zero;
        Pers pers;
        Container cont;

        KeyboardState crrKS;
        KeyboardState preKS;


        int currentTime = 0; // сколько времени прошло
        int period = 300; // период обновления в миллисекундах


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            cont = new Container(new Line(10, graphics.PreferredBackBufferWidth - 10), new Line(10, graphics.PreferredBackBufferHeight - 10), 0, 0);
        }

        protected override void Initialize()
        {
            base.Initialize();
            pers = new Pers(Content.Load<Texture2D>(@"images/pers"), new Rectangle(30, cont.Height.X2 / 2, 30, 30), 64, 64, new Line(0, 0), new Line(9, 1),1);
            MainGui = new Gui(Content.Load<Texture2D>("images/pers"), new Container(new Line(200, graphics.PreferredBackBufferWidth - 200), new Line(200, graphics.PreferredBackBufferHeight - 200), 0, 0), 0, 0, Content.Load<SpriteFont>(@"fonts/Main"), "lote", 0, 0);//@"fonts/Main"
            const string dbPath = @"gamedb.db";
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                SQLiteConnection dbConnection = new SQLiteConnection(string.Format("Data Source={0};", dbPath));
                SQLiteCommand createTablePersinfo = new SQLiteCommand("CREATE TABLE persinfo(id INTEGER NOT NULL, coordinates TEXT UNIQUE NOT NULL, name TEXT UNIQUE NOT NULL, PRIMARY KEY(id));", dbConnection);
                SQLiteCommand createTablePersitems = new SQLiteCommand("CREATE TABLE persitems(persid INTEGER, itemid INTEGER, slotid INTEGER, stuck INTEGER, strength INTEGER, damage TEXT, typeofdamage TEXT);", dbConnection);
                SQLiteCommand createLineNull = new SQLiteCommand("INSERT INTO persinfo VALUES (0, 0, 0)", dbConnection);
                SQLiteCommand comandUpdateCommand = new SQLiteCommand("UPDATE persinfo SET id = " + pers.ID + "; UPDATE persinfo SET coordinates = '0:0:0';  UPDATE persinfo SET name = 'Firnen'", dbConnection);
                SQLiteCommand createLineItme = new SQLiteCommand("INSERT INTO persitems VALUES (1, 1, 5, 64, 1200, '2:5', 'magik')", dbConnection);
                dbConnection.Open();
                createTablePersinfo.ExecuteNonQuery();
                createTablePersitems.ExecuteNonQuery();
                createLineNull.ExecuteNonQuery();
                comandUpdateCommand.ExecuteNonQuery();
                createLineItme.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            //mygui = new Gui(Content.Load<Texture2D>(@"images/BetaGui"), new Rectangle(330, cont.Height.X2 / 2, 0, 0),new Position(150,1));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            try
            {

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                { Exit(); }

                currentTime += gameTime.ElapsedGameTime.Milliseconds;

                crrKS = Keyboard.GetState();
                //управление движением персонажа
                if (preKS.IsKeyUp(Keys.S) && preKS.IsKeyUp(Keys.A) && preKS.IsKeyUp(Keys.D) && preKS.IsKeyUp(Keys.W))//Down , Left , Right , Up
                {
                    pers.Direction = States.Stop;
                    pers.PersDirection = PersDirection.Standart;
                }

                if (crrKS.IsKeyDown(Keys.A) && crrKS.IsKeyDown(Keys.W))//left && Up
                {
                    pers.Direction = States.LeftUp;
                    pers.PersDirection = PersDirection.Run;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))//Up && right
                {
                    pers.Direction = States.UpRight;
                    pers.PersDirection = PersDirection.Run;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.S))//right && down
                {
                    pers.Direction = States.RightDown;
                    pers.PersDirection = PersDirection.Run;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.A))//down && left
                {
                    pers.Direction = States.DownLeft;
                    pers.PersDirection = PersDirection.Run;
                }


                if (Keyboard.GetState().IsKeyDown(Keys.A) && !(Keyboard.GetState().IsKeyDown(Keys.W)) && !(Keyboard.GetState().IsKeyDown(Keys.S)))
                {
                    pers.Direction = States.Left;
                    pers.PersDirection = PersDirection.Run;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D) && !(Keyboard.GetState().IsKeyDown(Keys.S)) && !(Keyboard.GetState().IsKeyDown(Keys.W)))
                {
                    pers.Direction = States.Right;
                    pers.PersDirection = PersDirection.Run;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W) && !(Keyboard.GetState().IsKeyDown(Keys.A)) && !(Keyboard.GetState().IsKeyDown(Keys.D)))
                {
                    pers.Direction = States.Up;
                    pers.PersDirection = PersDirection.Run;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S) && !(Keyboard.GetState().IsKeyDown(Keys.A)) && !(Keyboard.GetState().IsKeyDown(Keys.D)))
                {
                    pers.Direction = States.Down;
                    pers.PersDirection = PersDirection.Run;
                }


                //Анимация персонажа
                if (currentTime > period-100)
                {
                    currentTime -= period-100;
                    pers.Animation(9, 1, 1);
                }
                //Скорость передвижения персонажа
                pers.Move(3);

                if (Keyboard.GetState().IsKeyDown(Keys.F11))//Тех.Клавиша для фпс
                {
                    indicator1 = !indicator1;
                }

                base.Update(gameTime);

            }
            catch (Exception msg)
            {
                Log.Write(msg);                      //Запись в лог
                Console.WriteLine(msg.ToString());   //Вывод в консоль
                //throw;
            }
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

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                MainGui.DrowMainGui(gameTime, spriteBatch);
            }

            //if (indicator1)//F11 
            //{
            //    TGui = new Gui(new Container(new Line(10, graphics.PreferredBackBufferWidth - 10), new Line(10, graphics.PreferredBackBufferHeight - 10), 0, 0), Content.Load<SpriteFont>(@"fonts/Main"), "FPS : " + fps, 0, 0);
            //    TGui.DrowTGui(gameTime, spriteBatch);
            //}


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
