using Microsoft.Xna.Framework;
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

        // private Enemy enemy;
        private List<Enemy> enemies;

        private Timer enemyCreationTimer;

        private List<Projectile> projectiles;

        private Texture2D playerProjectileSprite;

        private Texture2D enemyProjectileSprite;

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
            

            enemies = new List<Enemy>();

            enemies.Add(new Enemy(this, new Vector2(screenWidth, 0)));
            
            enemyCreationTimer = new Timer(3.0f);
            enemyCreationTimer.StartTimer();

            
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
            playerProjectileSprite = Content.Load<Texture2D>("Arrows");
            enemyProjectileSprite = Content.Load<Texture2D>("Yoda");
        }

        // Called every frame
        protected override void Update(GameTime gameTime)
        {   
            player.Update(gameTime);

            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
            }


            // Update base game
            base.Update(gameTime);

            for (int i = projectiles.Count - 1; i >= 0; i--)
            {

                Projectile p = projectiles[i];
                p.Update();

                Projectile g = projectiles[i];
                g.Update();

                bool isplayerProjectile = p.ProjectileType == ProjectileType.Player;

                bool isenemyProjectile = g.ProjectileType == ProjectileType.Enemy;

                if (!isplayerProjectile && player.Overlaps(p))
                {
                    projectiles.Remove(p);
                }
                else if (isplayerProjectile)
            
            // for (int q = projectiles.Count - 1; q >= 0; q--)
            // {
            //     Projectile g = projectiles[q];
            //     g.Update();

            //     bool isenemyProjectile = g.ProjectileType == ProjectileType.Enemy;
                
                // if (!isplayerProjectile && g.Overlaps(g))
                // {
                //     projectiles.Remove(p);
                //     projectiles.Remove(g);
                // }


                    for (int x = enemies.Count - 1; x >= 0; x--)
                    {
                        Enemy e = enemies[x];

                        if (e.Overlaps(p))
                        {
                            projectiles.Remove(p);
                            
                            enemies.Remove(e);
                        }

                        // else if(g.Overlaps(p))
                        // {
                        //     projectiles.Remove(p);
                            
                        //     projectiles.Remove(g);
                        // }
                    }
                }

                 if (enemyCreationTimer.Ready)
                {
                    enemies.Add(new Enemy(this, new Vector2(screenWidth, 0.0f)));

                    enemyCreationTimer.StartTimer();
                }

                enemyCreationTimer.Update(gameTime);

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
           
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(gameTime, spriteBatch);
            }


            foreach (Projectile p in projectiles)
            {
                p.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        public void FireProjectile(Vector2 position, Vector2 velocity, ProjectileType projectileType)
        {

            Texture2D projectileTexture;
            
            if (projectileType == ProjectileType.Player)
            {
                projectileTexture = playerProjectileSprite;
            }
            else
            {
                projectileTexture = enemyProjectileSprite;
            }

            Projectile firedProjectile = new Projectile(position, velocity, projectileTexture, projectileType);
            projectiles.Add(firedProjectile);
        }
    }
}
