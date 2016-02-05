using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpelProjektLinusDavid
{
    class SpelClass1
    {
        public Vector2 position, velocity;
        public Texture2D sprite;


        public void Update()
        {
            position += velocity;

            if (position.X + sprite.Width / 2 > 900)
            {
                position.X = 0;
            }

            if (position.X + sprite.Width / 2 < 0)
            {
                position.X = 900 - sprite.Width / 2;
            }

            if (position.Y + sprite.Width / 2 > 600)
            {
                position.Y = 0;
            }

            if (position.Y + sprite.Width / 2 < 0)
            {
                position.Y = 600 - sprite.Width / 2;
            }
        }
    }
}
