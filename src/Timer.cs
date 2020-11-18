using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeFlyer2D
{
    class Timer
    {
         private float endTime;

        private float currentTime;
        
        public bool Active { get; private set;}

        public bool Ready{ get {return !this.Active;}}
    
        public Timer(float totalTime)
        {
            this.endTime = totalTime;
            this.currentTime = 0.0f;
            this.Active = false;
        }

         public void StartTimer()
        {
            Active = true;
            currentTime = 0.0f;
        }

         public void Update(GameTime gameTime)
        {
            if (Active)
            {
                currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (currentTime >= endTime)
                {

                    Active = false;
                }
            }
        }
    }
}