using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpelProjektLinusDavid
{
    class Player
    {
        public Vector2 position, velocity;
        public Texture2D sprite;

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

        public Player()
        {
            position = new Vector2(500/2, 500/2);
            velocity = new Vector2(0, 0);
            hitbox = new Rectangle();
        }

        public void Update()
        {
            position += velocity;


            //Kant av banan

            //Höger vägg
            if (position.X + sprite.Width > 750)
            {
                position.X = 750 - sprite.Width;
            }

            // Vänster vägg
            if (position.X + sprite.Width < sprite.Width)
            {
                position.X = 0;
            }

            //Nedre vägg
            if (position.Y + sprite.Width > 500)
            {
                position.Y = 500 - sprite.Width;
            }

            //Övre vägg
            if (position.Y + sprite.Width < sprite.Width)
            {
                position.Y = 0;
            }

            //Hur kollision
            //if (position.X + sprite.Width > 73)
            //{
            //    position.X = 73;
            //}

            //if (position.X + sprite.Width < 18)
            //{
            //    position.X = 18;
            //}

            //if (position.Y + sprite.Width > 30)
            //{
            //    position.Y = 30;
            //}

            //if (position.Y + sprite.Width / 2 < 0)
            //{
            //    position.Y = 500 - sprite.Width / 2;
            //}

        }
    }
}
