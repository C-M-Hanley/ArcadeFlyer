using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeFlyer2D
{
    class Enemy : Sprite
    {
        private ArcadeFlyerGame root;

        private Timer projectileCoolDown;
        private Vector2 velocity;

        public Enemy(ArcadeFlyerGame root, Vector2 position) : base(position)
        {
            this.root = root;
            this.position = position;
            this.SpriteWidth = 200.0f;
            this.velocity = new Vector2(-3.0f, 7.0f);
            this.projectileCoolDown = new Timer(1.0f);

            LoadContent();
        }

        public void LoadContent()
        {
            this.SpriteImage = root.Content.Load<Texture2D>("Starship");
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