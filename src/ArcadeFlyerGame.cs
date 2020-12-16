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

        private SpriteBatch spriteBatch;

        private SpriteFont textFont;

        public int life = 3;

        private int score = 0;


        private bool gameOver = false;
        private Player player;


        private List<Power> powers;
        private Timer powerCreationTimer;


        // private Enemy enemy;
        private List<Enemy> enemies;

        private Timer enemyCreationTimer;

        private List<NoPower> nopowers;

        private Timer nopowerCreationTimer;

        private List<sPower> spowers;

        private Timer spowerCreationTimer;

        private List<smPower> smpowers;

        private Timer smpowerCreationTimer;

        private List<bPower> bpowers;

        private Timer bpowerCreationTimer;

        private List<dPower> dpowers;

        private Timer dpowerCreationTimer;

        private List<zPower> zpowers;

        private Timer zpowerCreationTimer;

        private List<Boss> bosses;

        private Timer bossCreationTimer;
        private Texture2D bossProjectileSprite;

        private List<Projectile> projectiles;

        private Texture2D playerProjectileSprite;

        private Texture2D enemyProjectileSprite;

        private Texture2D background;


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

            textFont = Content.Load<SpriteFont>("Score");

            // Make mouse visible
            IsMouseVisible = true;

            Vector2 posistion = new Vector2(0.0f, 0.0f);
            player = new Player(this, posistion);


            enemies = new List<Enemy>();

            enemies.Add(new Enemy(this, new Vector2(screenWidth, 0)));

            enemyCreationTimer = new Timer(3.0f);
            enemyCreationTimer.StartTimer();

            nopowers = new List<NoPower>();

            nopowers.Add(new NoPower(this, new Vector2(screenWidth, 0)));

            nopowerCreationTimer = new Timer(17.0f);
            nopowerCreationTimer.StartTimer();

            spowers = new List<sPower>();

            spowers.Add(new sPower(this, new Vector2(screenWidth, 0)));

            spowerCreationTimer = new Timer(15.0f);
            spowerCreationTimer.StartTimer();

            smpowers = new List<smPower>();

            smpowers.Add(new smPower(this, new Vector2(screenWidth, 0)));

            smpowerCreationTimer = new Timer(15.0f);
            smpowerCreationTimer.StartTimer();

            bpowers = new List<bPower>();

            bpowers.Add(new bPower(this, new Vector2(screenWidth, 0)));

            bpowerCreationTimer = new Timer(15.0f);
            bpowerCreationTimer.StartTimer();

            dpowers = new List<dPower>();

            dpowers.Add(new dPower(this, new Vector2(screenWidth, 0)));

            dpowerCreationTimer = new Timer(15.0f);
            dpowerCreationTimer.StartTimer();
            
            zpowerCreationTimer = new Timer(15.0f);
            zpowerCreationTimer.StartTimer();

            zpowers = new List<zPower>();

            zpowers.Add(new zPower(this, new Vector2(screenWidth, 0)));

            enemyCreationTimer = new Timer(3.0f);
            enemyCreationTimer.StartTimer();

            bosses = new List<Boss>();

            bosses.Add(new Boss(this, new Vector2(screenWidth, 0)));

            bossCreationTimer = new Timer(30.0f);
            bossCreationTimer.StartTimer();

            powers = new List<Power>();

            powers.Add(new Power(this, new Vector2(screenWidth, 0)));

            powerCreationTimer = new Timer(20.0f);
            powerCreationTimer.StartTimer();



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
            playerProjectileSprite = Content.Load<Texture2D>("Fire");
            enemyProjectileSprite = Content.Load<Texture2D>("Laser");
            background = Content.Load<Texture2D>("Space");
        }

        // Called every frame
        protected override void Update(GameTime gameTime)
        {

            if (gameOver)
            {
                // Return early, don't do anything else
                return;
            }

            player.Update(gameTime);

            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
            }

            for (int nopower = nopowers.Count - 1; nopower >= 0; nopower--)
            {
                NoPower p = nopowers[nopower];
                p.Update(gameTime);

                if (player.Overlaps(p))
                {
                    nopowers.Remove(p);
                    //power effects here.
                    player.movementSpeed = player.movementSpeed - 7;
                    player.projectileCoolDown = player.projectileCoolDown = new Timer(0.7f);

                    if (player.movementSpeed <= -4)
                    {
                        player.movementSpeed = -4;
                    }
                }
            }

            for (int spower = spowers.Count - 1; spower >= 0; spower--)
            {
                sPower p = spowers[spower];
                p.Update(gameTime);
            foreach (Boss boss in bosses)
                    {
                        foreach (Projectile x in projectiles)
                    {
                        if (player.Overlaps(p))
                        {
                            player.projectileVelocity = player.projectileVelocity = new Vector2(-90000.0f, -10.0f);
                        }
                    }
                        
                if (player.Overlaps(p))
                {
                    spowers.Remove(p);
                    //power effects here.
                    player.movementSpeed = player.movementSpeed + 3;
                    player.projectileCoolDown = player.projectileCoolDown = new Timer(0.3f);
                    
                    life = life + 1;
                    // player.projectileVelocity = player.projectileVelocity = new Vector2(90000.0f, -10.0f);
                    
                    if (player.movementSpeed >= 20)
                    {
                        player.movementSpeed = 20;
                    }
                }
            }
            }

            for (int bpower = bpowers.Count - 1; bpower >= 0; bpower--)
            {
                bPower p = bpowers[bpower];
                p.Update(gameTime);

                if (player.Overlaps(p))
                {
                    foreach (Boss boss in bosses)
                    {
                    foreach (Enemy enemy in enemies)
                    {
                        enemy.Update(gameTime);

                        bpowers.Remove(p);
                        //power effects here.
                        player.SpriteWidth = player.SpriteWidth - 15;
                        enemy.SpriteWidth = enemy.SpriteWidth - 75;
                        player.SpriteImage = player.SpriteImage = Content.Load<Texture2D>("Mandalorian");
                        

                        if (player.SpriteWidth <= 20)
                        {
                            player.SpriteWidth = 20;
                        }

                        if (enemy.SpriteWidth <= 0)
                        {
                            enemy.SpriteWidth = 0;
                        }

                        if (boss.SpriteWidth <= 0 && player.Overlaps(boss))
                        {
                            bosses.Remove(boss); 
                        }

                        if (player.Overlaps(boss) && boss.SpriteWidth >= 1) 
                        {
                        life = 0;
                        
                        }
                         if(life <= 0)
                        {
                            life = life = 0;
                        }
                        if (life < 1)
                        {
                            // End the game
                            gameOver = true;
                        }
                    }
                    }
                }
            }

            for (int dpower = dpowers.Count - 1; dpower >= 0; dpower--)
            {
                dPower p = dpowers[dpower];
                p.Update(gameTime);
                foreach (Boss boss in bosses)
                {
                    if (player.Overlaps(p))
                    {
                        dpowers.Remove(p);
                        boss.velocity = boss.velocity = new Vector2(-1.0f, 0.0f);
                        boss.projectileCoolDown = boss.projectileCoolDown = new Timer(0.05f);
                        boss.SpriteWidth = boss.SpriteWidth - 100;
                    }
                    
                    if (boss.SpriteWidth <= 0)
                    {
                        boss.projectileCoolDown = boss.projectileCoolDown = new Timer(1000000.0f);
                        boss.SpriteWidth = 0;
                        boss.velocity = boss.velocity = new Vector2(0f, 1000.0f);
                    }
                }
            }

            for (int zpower = zpowers.Count - 1; zpower >= 0; zpower--)
            {
                zPower p = zpowers[zpower];
                p.Update(gameTime);
                foreach (Boss boss in bosses)
                {
                    if (player.Overlaps(p))
                    {
                        zpowers.Remove(p);
                        boss.velocity = boss.velocity = new Vector2(-2.0f, 3.0f);
                        boss.projectileCoolDown = boss.projectileCoolDown = new Timer(0.05f);
                        boss.SpriteWidth = boss.SpriteWidth + 100;
                    }
                    
                    if (boss.SpriteWidth <= 0)
                    {
                        boss.projectileCoolDown = boss.projectileCoolDown = new Timer(1000000.0f);
                        boss.SpriteWidth = 0;
                        boss.velocity = boss.velocity = new Vector2(0f, 1000.0f); 
                    }
                }
            }

            for (int smpower = smpowers.Count - 1; smpower >= 0; smpower--)
            {
                smPower p = smpowers[smpower];
                p.Update(gameTime);

                if (player.Overlaps(p))
                {
                    foreach (Enemy enemy in enemies)
                    {
                        enemy.Update(gameTime);

                        smpowers.Remove(p);
                        //power effects here.
                        player.SpriteWidth = player.SpriteWidth + 15;
                        enemy.SpriteWidth = enemy.SpriteWidth + 55;

                        player.SpriteImage = player.SpriteImage = Content.Load<Texture2D>("Yoda");

                        if (player.SpriteWidth >= 200)
                        {
                            player.SpriteWidth = 200;
                        }
                    }
                }
            }

            foreach (Boss boss in bosses)
            {

                boss.Update(gameTime);
                foreach (Projectile projectile in projectiles)
                {

                    projectile.Update();

                    bool isplayerProjectile = projectile.ProjectileType == ProjectileType.Player;
                    bool isenemyProjectile = projectile.ProjectileType == ProjectileType.Enemy;
                    // !isplayerProjectile && player.Overlaps(p)

                    if (isplayerProjectile && projectile.Overlaps(boss))
                    {
                        boss.SpriteWidth = boss.SpriteWidth - 30;

                        if (boss.SpriteWidth <= 0)
                        {
                            boss.projectileCoolDown = boss.projectileCoolDown = new Timer(10000.0f);
                            boss.SpriteWidth = 0;
                        }

                        if (boss.SpriteWidth <= 0 && player.Overlaps(boss))
                        {
                            bosses.Remove(boss);
                        }

                    }

                    if (boss.Overlaps(player) && boss.SpriteWidth >= 1)
                    {
                        life = life = 0;
                        if(life <= 0)
                        {
                            life = life = 0;
                        }

                        if (life < 1)
                        {
                            // End the game
                            gameOver = true;
                        }
                    }
                }
            }


            // for (int power = powers.Count - 1; power >= 0; power--)
            // {
            //     Projectile z = projectiles[power];
            //     z.Update();

            //     Power p = powers[power];
            //     p.Update(gameTime);

            //     bool isenemyProjectile = z.ProjectileType == ProjectileType.Enemy;

            //     {

            //         if (player.Overlaps(p))
            //         {
            //             projectiles.Remove(z);
            //             //power effects here.

            //         }
            //     }

            // if (player.Overlaps(p))
            // {
            //     powers.Remove(p);
            //     //power effects here.
            //     player.movementSpeed = player.movementSpeed + 3;

            //     if (player.movementSpeed >= 20)
            //     {
            //         player.movementSpeed = 20;
            //     }
            // }
            // }



            for (int i = projectiles.Count - 1; i >= 0; i--)
            {

                Projectile p = projectiles[i];
                p.Update();

                bool isplayerProjectile = p.ProjectileType == ProjectileType.Player;

                bool isenemyProjectile = p.ProjectileType == ProjectileType.Enemy;
                for (int enemy = enemies.Count - 1; enemy >= 0; enemy--)
                {

                    Enemy e = enemies[enemy];
                    if (e.Overlaps(player))
                    {
                        life = life - 3;
                        enemies.Remove(e);
                        if(life <= 0)
                        {
                            life = life = 0;
                        }
                        if (life < 1)
                        {
                            // End the game
                            gameOver = true;
                        }
                    }



                    for (int power = powers.Count - 1; power >= 0; power--)
                    {

                        Power o = powers[power];
                        o.Update(gameTime);



                        if (o.Overlaps(player))
                        {
                            projectiles.Remove(p);
                            enemies.Remove(e);
                            i = 0;
                        }



                        // if (player.Overlaps(p))
                        // {
                        //     powers.Remove(p);
                        //     //power effects here.
                        //     player.movementSpeed = player.movementSpeed + 3;

                        //     if (player.movementSpeed >= 20)
                        //     {
                        //         player.movementSpeed = 20;
                        //     }
                        // }
                    }
                }


                if (!isplayerProjectile && player.Overlaps(p))
                {
                    projectiles.Remove(p);

                    life--;

                    if(life <= 0)
                        {
                            life = life = 0;
                        }

                    if (life < 1)
                    {
                        // End the game
                        gameOver = true;
                    }
                }
                else if (isplayerProjectile)
                {

                    for (int a = 0; a < i; a++)
                    {
                        Projectile other = projectiles[a];

                        if (other.ProjectileType == ProjectileType.Player)
                        {
                            continue;
                        }

                        if (other.Overlaps(p))
                        {
                            projectiles.Remove(p);
                            projectiles.Remove(other);
                            a--;
                            i--;
                        }
                    }

                    for (int x = enemies.Count - 1; x >= 0; x--)
                    {

                        Enemy e = enemies[x];

                        if (e.Overlaps(p))
                        {
                            projectiles.Remove(p);

                            enemies.Remove(e);

                            score++;
                        }

                    }
                }
            }

            if (enemyCreationTimer.Ready)
            {
                enemies.Add(new Enemy(this, new Vector2(screenWidth, 0.0f)));

                enemyCreationTimer.StartTimer();
            }

            if (nopowerCreationTimer.Ready)
            {
                nopowers.Add(new NoPower(this, new Vector2(screenWidth, 0.0f)));

                nopowerCreationTimer.StartTimer();
            }

            if (spowerCreationTimer.Ready)
            {
                spowers.Add(new sPower(this, new Vector2(screenWidth, 0.0f)));

                spowerCreationTimer.StartTimer();
            }

            if (smpowerCreationTimer.Ready)
            {
                smpowers.Add(new smPower(this, new Vector2(screenWidth, 0.0f)));

                smpowerCreationTimer.StartTimer();
            }

            if (bpowerCreationTimer.Ready)
            {
                bpowers.Add(new bPower(this, new Vector2(screenWidth, 0.0f)));

                bpowerCreationTimer.StartTimer();
            }

            if (dpowerCreationTimer.Ready)
            {
                dpowers.Add(new dPower(this, new Vector2(screenWidth, 0.0f)));

                dpowerCreationTimer.StartTimer();
            }

            if (zpowerCreationTimer.Ready)
            {
                zpowers.Add(new zPower(this, new Vector2(screenWidth, 0.0f)));

                zpowerCreationTimer.StartTimer();
            }

            if (bossCreationTimer.Ready)
            {
                bosses.Add(new Boss(this, new Vector2(screenWidth, 0.0f)));

                bossCreationTimer.StartTimer();
            }

            if (powerCreationTimer.Ready)
            {
                powers.Add(new Power(this, new Vector2(screenWidth, 0.0f)));

                powerCreationTimer.StartTimer();
            }

            enemyCreationTimer.Update(gameTime);

            nopowerCreationTimer.Update(gameTime);

            spowerCreationTimer.Update(gameTime);

            smpowerCreationTimer.Update(gameTime);

            bpowerCreationTimer.Update(gameTime);

            dpowerCreationTimer.Update(gameTime);

            zpowerCreationTimer.Update(gameTime);

            bossCreationTimer.Update(gameTime);

            powerCreationTimer.Update(gameTime);
            // Update base game
            base.Update(gameTime);

        }



        // Draw everything in the game
        protected override void Draw(GameTime gameTime)
        {

            if (gameOver)
            {
                GraphicsDevice.Clear(Color.Black);


                spriteBatch.Begin();


                Vector2 textPosition = new Vector2(screenWidth / 2, screenHeight / 2);

                spriteBatch.DrawString(textFont, $"Game Over :(\nFinal Score: {score}\nLife: {life}", textPosition, Color.White);

                spriteBatch.End();

                return;
            }


            // First clear the screen
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            // drawing happens here
            // Rectangle playerDestinationRect = new Rectangle(0,0,playerImage.Width, playerImage.Height);

            // spriteBatch.Draw(playerImage, playerDestinationRect, Color.White);
            Rectangle screenSize = new Rectangle(0, 0, ScreenWidth, screenHeight);
            spriteBatch.Draw(background, screenSize, Color.White);
            player.Draw(gameTime, spriteBatch);

            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(gameTime, spriteBatch);
                // spriteBatch.DrawString(textFont, $"                                                                                   ESize: {enemy.SpriteWidth}", Vector2.Zero, Color.Black);
            }

            foreach (NoPower nopower in nopowers)
            {
                nopower.Draw(gameTime, spriteBatch);
            }

            foreach (sPower spower in spowers)
            {
                spower.Draw(gameTime, spriteBatch);
            }

            foreach (smPower smpower in smpowers)
            {
                smpower.Draw(gameTime, spriteBatch);
            }

            foreach (bPower bpower in bpowers)
            {
                bpower.Draw(gameTime, spriteBatch);
            }

            foreach (dPower dpower in dpowers)
            {
                dpower.Draw(gameTime, spriteBatch);
            }

            foreach (zPower zpower in zpowers)
            {
                zpower.Draw(gameTime, spriteBatch);
            }

            foreach (Boss boss in bosses)
            {
                boss.Draw(gameTime, spriteBatch);
            }

            foreach (Power power in powers)
            {
                power.Draw(gameTime, spriteBatch);
            }


            foreach (Projectile p in projectiles)
            {
                p.Draw(gameTime, spriteBatch);
            }

             spriteBatch.DrawString(textFont, $"Life: {life}  Score: {score}  Size: %{player.SpriteWidth}  Speed:{player.movementSpeed}", Vector2.Zero, Color.Black);

            // spriteBatch.Draw(winter);
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
            // shotsFired += 1;
            Projectile firedProjectile = new Projectile(position, velocity, projectileTexture, projectileType);
            projectiles.Add(firedProjectile);
        }
    }
}
