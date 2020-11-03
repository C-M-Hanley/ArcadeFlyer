﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace ArcadeFlyer2D
{
    // The Game itself
    class ArcadeFlyerGame : Game
    {
        // Graphics Manager
        private GraphicsDeviceManager graphics;

        // Sprite Drawer
        private SpriteBatch spriteBatch;


        private Player player;

        private Enemy enemy;

        private List<Projectile> projectiles;

        private Texture2D playerProjectileSprite;

        private int screenWidth = 1600;
        public int ScreenWidth
        {
            get { return screenWidth; }
            set { screenWidth = ScreenWidth; }
        }

        private int screenHeight = 900;
        public int ScreenHeight
        {
            get { return screenHeight; }
            set { screenHeight = value; }
        }
        
        
        // Initalized the game
        public ArcadeFlyerGame()
        {
            // Get the graphics
            graphics = new GraphicsDeviceManager(this);

            // Set the height and width
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            // Set up the directory containing the assets
            Content.RootDirectory = "Content";

            // Make mouse visible
            IsMouseVisible = true;

            Vector2 posistion = new Vector2(0.0f, 0.0f);
            player = new Player(this, posistion);
            enemy = new Enemy(this, new Vector2(screenWidth, 0));
            projectiles = new List<Projectile>();
        }
        // Initialize
        protected override void Initialize()
        {
            base.Initialize();
        }

        // Load the content for the game, called automatically on start
        protected override void LoadContent()
        {
            // playerImage = Content.Load<Texture2D>("MainChar");
            // Create the sprite batch
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerProjectileSprite= Content.Load<Texture2D>("PlayerFire");
        }

        // Called every frame
        protected override void Update(GameTime gameTime)
        {   
            player.Update(gameTime);
            enemy.Update(gameTime);

            // Update base game
            base.Update(gameTime);

            foreach (Projectile p in projectiles)
            {
                p.Update();
            }
        }

        // Draw everything in the game
        protected override void Draw(GameTime gameTime)
        {
            // First clear the screen
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            // drawing happens here
            // Rectangle playerDestinationRect = new Rectangle(0,0,playerImage.Width, playerImage.Height);
            
            // spriteBatch.Draw(playerImage, playerDestinationRect, Color.White);

            player.Draw(gameTime, spriteBatch);
            enemy.Draw(gameTime, spriteBatch);
            foreach (Projectile p in projectiles)
            {
                p.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        public void FireProjectile(Vector2 position, Vector2 velocity)
        {
            Projectile firedProjectile = new Projectile(position, velocity, playerProjectileSprite);
            
            projectiles.Add(firedProjectile);
        }
    }
}
