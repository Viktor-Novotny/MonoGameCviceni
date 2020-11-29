using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameCviceni
{
    public class Demo : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int _sirkaOkna = 800;
        private int _vyskaOkna = 600;

        private Texture2D _textura;

        private int h, w, x, y, prumer, polomer, rychlost;
        public MouseState kurzor;

        private Color barva;

        public Demo()
        {
            _graphics = new GraphicsDeviceManager(this);
            Window.Title = "MonoGame";
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = _sirkaOkna;
            _graphics.PreferredBackBufferHeight = _vyskaOkna;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            prumer = 100;
            polomer = prumer / 2;
            barva = Color.White;

            w = 100;
            h = 100;
            x = _sirkaOkna / 2 - w / 2;
            y = _vyskaOkna / 2 - h / 2;

            Color[] pixely = new Color[prumer * prumer];

            for (int i = 0; i < prumer; i++)
            {
                for (int j = 0; j < prumer; j++)
                {
                    if (Math.Sqrt(Math.Pow(j - polomer, 2) + Math.Pow(i - polomer, 2)) < polomer)
                    {
                        pixely[100 * i + j] = barva;
                    }
                    else
                    {
                        pixely[100 * i + j] = Color.Transparent;
                    }
                }
            }

            _textura = new Texture2D(GraphicsDevice, prumer, prumer);
            _textura.SetData(pixely);


        }

        protected override void Update(GameTime gameTime)
        {

            rychlost = 0;
            kurzor = Mouse.GetState();


            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (x >= _sirkaOkna - prumer)
            {
                x = _sirkaOkna - prumer;
            }
            if (x <= 0)
            {
                x = 0;
            }
            if (y >= _vyskaOkna - prumer)
            {
                y = _vyskaOkna - prumer;
            }
            if (y <= 0)
            {
                y = 0;
            }


            if (kurzor.X - 200 < x + prumer && kurzor.X + 200 > x && kurzor.Y - 200 < y + prumer && kurzor.Y + 200 > y)
            {
                rychlost = 1;

                barva = Color.LightGray;
            }
            else
            {
                rychlost = 0;

                barva = Color.Gray;
            }
            if (kurzor.X > x && kurzor.X < x + w && kurzor.Y > y && kurzor.Y < y + h)
            {
                rychlost = 0;

                barva = Color.Black;
            }

            if (rychlost != 0)
            {
                if (kurzor.X < x && kurzor.X > x - 200 && x < _sirkaOkna - prumer)
                {
                    x += rychlost;

                    if (kurzor.X < x && kurzor.X > x - 100)
                    {
                        rychlost = 5;

                        x += rychlost;
                        if (kurzor.X < x && kurzor.X > x - 50)
                        {
                            rychlost = 10;

                            x += rychlost;
                        }
                    }
                }
                if (kurzor.X < x + prumer + 200 && kurzor.X > x + prumer && x > 0)
                {
                    x -= rychlost;
                    if (kurzor.X < x + prumer + 100 && kurzor.X > x + prumer)
                    {
                        rychlost = 5;

                        x -= rychlost;
                        if (kurzor.X < x + prumer + 50 && kurzor.X > x + prumer)
                        {
                            rychlost = 10;

                            x -= rychlost;
                        }
                    }
                }
                if (kurzor.Y < y && kurzor.Y > y - 200 && y < _vyskaOkna - prumer)
                {
                    y += rychlost;

                    if (kurzor.Y < y && kurzor.Y > y - 100)
                    {
                        rychlost = 5;

                        y += rychlost;
                        if (kurzor.Y < y && kurzor.Y > y - 50)
                        {
                            rychlost = 10;

                            y += rychlost;
                        }
                    }
                }
                if (kurzor.Y < y + prumer + 200 && kurzor.Y > y + prumer && y > 0)
                {
                    y -= rychlost;
                    if (kurzor.Y < y + prumer + 100 && kurzor.Y > y + prumer)
                    {
                        rychlost = 5;

                        y -= rychlost;
                        if (kurzor.Y < y + prumer + 50 && kurzor.Y > y + prumer)
                        {
                            rychlost = 10;

                            y -= rychlost;
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_textura, new Rectangle(x, y, w, h), barva);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
