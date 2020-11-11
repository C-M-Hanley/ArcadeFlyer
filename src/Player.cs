using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeFlyer2D
{
    class Player : Sprite
    {
        private ArcadeFlyerGame root;

        private float movementSpeed = 4.0f;

         private Timer projectileCoolDown;

        public Player(ArcadeFlyerGame root, Vector2 position) : base(position)
        {
            this.root = root;
            this.position = position;
            this.SpriteWidth = 128.0f;

            projectileCoolDown = new Timer(0.5f);

            LoadContent();
        }

        public void LoadContent()
        {
            this.SpriteImage = root.Content.Load<Texture2D>("MainChar");
        }

        private void HandleInput(KeyboardState currentKeyboardState)
        {
            bool upKeyPressed = currentKeyboardState.IsKeyDown(Keys.Up);
            bool downKeyPressed = currentKeyboardState.IsKeyDown(Keys.Down);
            bool leftKeyPressed = currentKeyboardState.IsKeyDown(Keys.Left);
            bool rightKeyPressed = currentKeyboardState.IsKeyDown(Keys.Right);
            bool spaceKeyPressed = currentKeyboardState.IsKeyDown(Keys.Space); 
              

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