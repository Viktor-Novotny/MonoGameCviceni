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

        private int h, w, x, y, prumer, polomer;

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_textura, new Rectangle(x, y, w, h), barva);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
