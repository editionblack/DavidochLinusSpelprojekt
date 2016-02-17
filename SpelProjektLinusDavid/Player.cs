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
            position = new Vector2(750 / 2, 500 / 2);
            velocity = new Vector2(0, 0);
            hitbox = new Rectangle();
        }

        public void Update()
        {
            position += velocity;
        }
    }
}
