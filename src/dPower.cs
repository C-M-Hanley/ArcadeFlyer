using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeFlyer2D
{
    class dPower : Sprite
    {
        private ArcadeFlyerGame root;

        private Timer projectileCoolDown;
        private Vector2 velocity;

        public dPower(ArcadeFlyerGame root, Vector2 position) : base(position)
        {
            this.root = root;
            this.position = position;
            this.SpriteWidth = 50.0f;
            this.velocity = new Vector2(-4.0f, 8.0f);
            this.projectileCoolDown = new Timer(1.0f);

            LoadContent();
        }

        public void LoadContent()
        {
            this.SpriteImage = root.Content.Load<Texture2D>("PowerWhite");
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