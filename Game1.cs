using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace monogame_3___animating
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleBrownTexture, tribbleCreamTexture, tribbleGreyTexture, tribbleOrangeTexture, epicBackground;
        Rectangle tribbleRectGrey, tribbleRectOrange, tribbleRectCream, tribbleRectBrown, window, windowBackground;
        Vector2 tribbleGreySpeed, tribbleOrangeSpeed, tribbleCreamSpeed, tribbleBrownSpeed;

        Color bgColor;
        SoundEffect tribbleNoise;

        Random generator = new Random();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bgColor = Color.White;
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            this.Window.Title = "Tribble Rave";
            _graphics.ApplyChanges();

            tribbleRectGrey = new Rectangle(300, 10, 100, 100);
            tribbleRectOrange = new Rectangle(300, 10, 100, 100);
            tribbleRectCream = new Rectangle(300, 10, 100, 100);
            tribbleRectBrown = new Rectangle(300, 10, 100, 100);

            windowBackground = new Rectangle(0, 0, 800, 600);

            tribbleGreySpeed = new Vector2(1, 0);
            tribbleOrangeSpeed = new Vector2(0, 1);
            tribbleCreamSpeed = new Vector2(1, 1);
            tribbleBrownSpeed = new Vector2(generator.Next(1, 5), generator.Next(1, 5));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");

            epicBackground = Content.Load<Texture2D>("pixilartducks");

            tribbleNoise = Content.Load<SoundEffect>("tribble_coo");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            tribbleRectGrey.X += (int)tribbleGreySpeed.X;
            if (tribbleRectGrey.Right > window.Width || tribbleRectGrey.X < 0)
            {
                tribbleGreySpeed.X *= -1;
                bgColor = Color.Goldenrod;
                tribbleNoise.Play();
            }
            tribbleRectGrey.Y += (int)tribbleGreySpeed.Y;

            tribbleRectOrange.Y += (int)tribbleOrangeSpeed.Y;
            if (tribbleRectOrange.Bottom > window.Height || tribbleRectOrange.Y < 0)
            {
                tribbleOrangeSpeed.Y *= -1;
                bgColor = Color.White;
                tribbleNoise.Play();
            }
            tribbleRectOrange.Y += (int)tribbleOrangeSpeed.Y;

            tribbleRectCream.X += (int)tribbleCreamSpeed.X;
            if (tribbleRectCream.Right > window.Width || tribbleRectCream.X < 0)
            {
                tribbleCreamSpeed.X *= -1;
                bgColor = Color.BlueViolet;
                tribbleNoise.Play();
            }
            tribbleRectCream.Y += (int)tribbleCreamSpeed.Y;
            if (tribbleRectCream.Bottom > window.Height || tribbleRectCream.Y < 0)
            {
                tribbleCreamSpeed.Y *= -1;
                bgColor = Color.SeaShell;
                tribbleNoise.Play();
            }

            tribbleRectBrown.X += (int)tribbleBrownSpeed.X;
            if (tribbleRectBrown.Right > window.Width || tribbleRectBrown.X < 0)
            {
                tribbleBrownSpeed.X *= -1;
                bgColor = Color.Aquamarine;
                tribbleNoise.Play();
            }
            tribbleRectBrown.Y += (int)tribbleBrownSpeed.Y;
            if (tribbleRectBrown.Bottom > window.Height || tribbleRectBrown.Y < 0)
            {
                tribbleBrownSpeed *= -1;
                bgColor = Color.Violet;
                tribbleNoise.Play();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(epicBackground, windowBackground, bgColor);
            _spriteBatch.Draw(tribbleGreyTexture, tribbleRectGrey, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleRectOrange, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleRectCream, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleRectBrown, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}