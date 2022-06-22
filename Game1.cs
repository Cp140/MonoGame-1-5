using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_1_5
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D gameScreenTexture;

        Texture2D introScreenTexture;

        Texture2D gameOverTexture;

        Texture2D tribbleGreyTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;

        private MouseState mouseState;

        Screen currentScreen;

        enum Screen
        {
            Intro,
            PackMan,
            Outtro
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Lesson 3 - Animation Part 1";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 500;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tribbleGreyRect = new Rectangle(0, 225, 50, 50);
            tribbleGreySpeed = new Vector2(2, 0);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("PacRight");
            introScreenTexture = Content.Load<Texture2D>("IntroScreen1");
            gameScreenTexture = Content.Load<Texture2D>("GameScreen");
            gameOverTexture = Content.Load<Texture2D>("GameOver");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            mouseState = Mouse.GetState();



            ///
            ///draws intro screen
            ///
            if (currentScreen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    currentScreen = Screen.PackMan;


            }
            ///
            /// Draws Tribble Yard
            ///
            else if (currentScreen == Screen.PackMan)
            {
                


                tribbleGreyRect.X += (int)tribbleGreySpeed.X;
                tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;

                if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth || tribbleGreyRect.X < 0)
                    tribbleGreySpeed.X *= -1;
                if (tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleGreyRect.Top < 0)
                    tribbleGreySpeed.Y *= -1;

                // TODO: Add your update logic here

                if (mouseState.RightButton == ButtonState.Pressed)
                    currentScreen = Screen.Outtro;

                base.Update(gameTime);
            }
        }


        protected override void Draw(GameTime gameTime)
        {


            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (currentScreen == Screen.Intro)
            {
                _spriteBatch.Draw(introScreenTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);

            }
            else if (currentScreen == Screen.PackMan)
            {
                _spriteBatch.Draw(gameScreenTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);

                _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            }
            else if (currentScreen == Screen.Outtro)
            {
                _spriteBatch.Draw(gameOverTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);

            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
