using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_3___animating
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleBrownTexture, tribbleCreamTexture, tribbleGreyTexture, tribbleOrangeTexture;
        Rectangle tribbleRectGrey, tribbleRectOrange, tribbleRectCream, window;
        Vector2 tribbleGreySpeed, tribbleOrangeSpeed, tribbleCreamSpeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            tribbleRectGrey = new Rectangle(300, 10, 100, 100);
            tribbleRectOrange = new Rectangle(300, 10, 100, 100);
            tribbleRectCream = new Rectangle(300, 10, 100, 100);


            tribbleGreySpeed = new Vector2(1, 0);
            tribbleOrangeSpeed = new Vector2(0, 1);
            tribbleCreamSpeed = new Vector2(1, 1);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
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
            }
            tribbleRectGrey.Y += (int)tribbleGreySpeed.Y;

            tribbleRectOrange.Y += (int)tribbleOrangeSpeed.Y;
            if (tribbleRectOrange.Bottom > window.Height || tribbleRectOrange.Y < 0)
            {
                tribbleOrangeSpeed.Y *= -1;
            }
            tribbleRectOrange.Y += (int)tribbleOrangeSpeed.Y;

            tribbleRectCream.X += (int)tribbleCreamSpeed.X;
            if (tribbleRectCream.Right > window.Width || tribbleRectCream.X < 0)
            {
                tribbleCreamSpeed.X *= -1;
            }
            tribbleRectCream.Y += (int)tribbleCreamSpeed.Y;
            if (tribbleRectCream.Bottom > window.Height || tribbleRectCream.Y < 0)
            {
                tribbleCreamSpeed.Y *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleGreyTexture, tribbleRectGrey, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleRectOrange, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleRectCream, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}