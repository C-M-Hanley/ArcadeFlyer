using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeFlyer2D
{
    class sPower : Sprite
    {
        private ArcadeFlyerGame root;

        private Timer projectileCoolDown;
        private Vector2 velocity;

        public sPower(ArcadeFlyerGame root, Vector2 position) : base(position)
        {
            this.root = root;
            this.position = position;
            this.SpriteWidth = 50.0f;
            this.velocity = new Vector2(-6.0f, 10.0f);
            this.projectileCoolDown = new Timer(10.0f);

            LoadContent();
        }

        public void LoadContent()
        {
            this.SpriteImage = root.Content.Load<Texture2D>("PowerUp");
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            if (position.Y < 0 || position.Y > (root.ScreenHeight - SpriteHeight))
            {
                velocity.Y *= -1;
            }
            projectileCoolDown.Update(gameTime);

        }
    }
}