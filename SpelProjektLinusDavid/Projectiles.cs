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
        public float speed = 10, damage;

        public Projectiles()
        {

            position = new Vector2(750 / 2, 500 / 2);
            velocity = new Vector2(0, 0);
            hitbox = new Rectangle();
        }

        public Projectiles(float playerPositionX, float playerPositionY, float directionX, float directionY, float currWeapon)
        {
            Vector2 playerPosition = new Vector2(playerPositionX,playerPositionY);
            position = playerPosition;
            velocity = new Vector2(directionX, directionY);
            velocity.Normalize();
            velocity *= speed;

            damage = currWeapon;
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
            
            // TODO: Kulor borde förstöras när dom rör sig utanför!
            //if (position.X > 750)
            //{
            //    velocity *= -1;
            //}
        }
    }
}
