
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpelProjektLinusDavid
{
    class Enemies
    {
        public Vector2 position, velocity;
        public Texture2D spriteSheet, sprite;
        public float speed = 3;
        Rectangle hitbox;

        Rectangle sourceRectangle;



        public void Update(Vector2 playerPosition) 
        {
            velocity = playerPosition - position;
            velocity.Normalize();
            velocity *= speed;
            position += velocity;
        }

        public void Draw()
        {

        }
    }
}
