using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeFlyer2D
{
    class Boss : Sprite
    {
        private ArcadeFlyerGame root;

        public Timer projectileCoolDown;
        public Vector2 velocity;

        public Boss(ArcadeFlyerGame root, Vector2 position) : base(position)
        {
            this.root = root;
            this.position = position;
            this.SpriteWidth = 800.0f;
            this.velocity = new Vector2(-1.0f, 1.0f);
            this.projectileCoolDown = new Timer(0.05f);

            LoadContent();
        }

        public void LoadContent()
        {
            this.SpriteImage = root.Content.Load<Texture2D>("Deathstar");
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            if (position.Y < 0 || position.Y > (root.ScreenHeight - SpriteHeight))
            {
                velocity.Y *= -1;
            }
            projectileCoolDown.Update(gameTime);

            if (!projectileCoolDown.Active)
            {
            projectileCoolDown.StartTimer();    
            Vector2 projectilePosition = new Vector2(position.X, position.Y + SpriteHeight / 2);
            Vector2 projectileVelocity = new Vector2(-5.0f, 0.0f);

            root.FireProjectile(projectilePosition, projectileVelocity, ProjectileType.Enemy);
            
            }
        }
    }
}