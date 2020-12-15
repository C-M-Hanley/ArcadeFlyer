using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeFlyer2D
{
    class Player : Sprite
    {
        private ArcadeFlyerGame root;

        public float movementSpeed = 6.0f;

        public Timer projectileCoolDown;

        public Vector2 projectileVelocity;

        public Player(ArcadeFlyerGame root, Vector2 position) : base(position)
        {
            this.root = root;
            this.position = position;
            this.SpriteWidth = 100.0f;

            projectileCoolDown = new Timer(0.5f);

            LoadContent();
        }

        public void LoadContent()
        {
            this.SpriteImage = root.Content.Load<Texture2D>("Mandalorian");
        }

        private void HandleInput(KeyboardState currentKeyboardState)
        {
            bool upKeyPressed = currentKeyboardState.IsKeyDown(Keys.Up);
            bool downKeyPressed = currentKeyboardState.IsKeyDown(Keys.Down);
            bool leftKeyPressed = currentKeyboardState.IsKeyDown(Keys.Left);
            bool rightKeyPressed = currentKeyboardState.IsKeyDown(Keys.Right);
            bool spaceKeyPressed = currentKeyboardState.IsKeyDown(Keys.Space);

            if (currentKeyboardState.IsKeyDown(Keys.M))
            {
                movementSpeed = movementSpeed = 40;
                projectileCoolDown = projectileCoolDown = new Timer(0.05f);
                SpriteWidth = SpriteWidth = 20;
                SpriteImage = SpriteImage = root.Content.Load<Texture2D>("Mandalorian");
            }

            if (upKeyPressed)
            {
                position.Y -= movementSpeed;
            }

            if (downKeyPressed)
            {
                position.Y += movementSpeed;
            }

            if (leftKeyPressed)
            {
                position.X -= movementSpeed;
            }

            if (rightKeyPressed)
            {
                position.X += movementSpeed;
            }

            if (spaceKeyPressed && !projectileCoolDown.Active)
            {
                Vector2 projectilePosition;
                Vector2 projectileVelocity;

                projectilePosition = new Vector2(position.X + (SpriteWidth / 2), position.Y + (SpriteHeight / 2));
                projectileVelocity = new Vector2(10.0f, 0.0f);
                root.FireProjectile(projectilePosition, projectileVelocity, ProjectileType.Player);
                projectileCoolDown.StartTimer();
            }
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            HandleInput(currentKeyboardState);

            projectileCoolDown.Update(gameTime);
        }
    }
}