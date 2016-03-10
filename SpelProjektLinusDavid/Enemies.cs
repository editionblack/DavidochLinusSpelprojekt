
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpelProjektLinusDavid
{
    /// <summary>
    /// TRYCK PÅ "K" FÖR ATT SPAWNA FIENDER, JAG HAR FÖRSÖKT ATT KUNNA SPAWNA FLERA, WITHOUT SUCCESS :(
    /// </summary>
    class Enemies
    {
        public Vector2 position, velocity;
        public Texture2D spriteSheet, sprite;
        public float speed = 3;
        Rectangle hitbox;


        Rectangle sourceRectangle;

        public Vector2 Position
        {
            get
            {
                Vector2 center = new Vector2();
                center.X = position.X + 24;
                center.Y = position.Y + 20;
                return center;
            }
        }

        public Vector2 startPoint = new Vector2(50,50);

        public void Update(Vector2 playerPosition) 
        {
            velocity = playerPosition - position;
            velocity.Normalize();
            velocity *= speed;
            position += velocity;

            //Vector2.Distance()        THIS IS WHAT WE USE FOR HITBOX, IT I GENIUS MODE I PROMISE
        }
        
        
        
        //public void Draw()
        //{

        //}

        //internal void Update()
        //{
        //}
    }
}
