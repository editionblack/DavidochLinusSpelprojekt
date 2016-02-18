using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SpelProjektLinusDavid
{
    class Projectiles
    {
        public Vector2 position, velocity;
        public Texture2D sprite;
        public float speed = 10;
        
        public Projectiles() {

            position = new Vector2(750/2, 500 / 2);
            velocity = new Vector2(0, 0);
            hitbox = new Rectangle();
        }

        public Projectiles(float playerPositionX, float playerPositionY, float directionX, float directionY)
        {
            Vector2 playerPosition = new Vector2(playerPositionX,playerPositionY);
            position = playerPosition;
            velocity = new Vector2(directionX, directionY);
            
        }

        public void Bullets(float velocityX, float velocityY)
        {
            position = new Vector2(50, 50);
            velocity = new Vector2(velocityX, velocityY);
            hitbox = new Rectangle();
        }

        Rectangle hitbox;

        public Rectangle Hitbox 
        {
            get
            {
                hitbox.X = (int)position.X;
                hitbox.Y = (int)position.Y;
                hitbox.Width = sprite.Width;
                hitbox.Height = sprite.Height;
                return hitbox;
            }

        }
        public void Update()
        {
            position += velocity;
        }
    }
}
