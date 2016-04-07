﻿using System;
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
        public Texture2D spriteSheet, sprite;
        //public float distance;
        Rectangle hitbox;
        public float speed;
        public int health;
        
        Rectangle sourceRectangle;

        double elapsed = 0;

        public Vector2 Position
        {
            get
            {
                Vector2 center= new Vector2();
                center.X = position.X + 24;
                center.Y = position.Y + 20;
                return center;
            }
        }
        public Rectangle Hitbox
        {
            get
            {
                hitbox.X = (int)position.X;
                hitbox.Y = (int)position.Y;
                hitbox.Width = spriteSheet.Width;
                hitbox.Height = spriteSheet.Height;
                return hitbox;
            }
        }

        public Player()
        {
            position = new Vector2(500/2, 500/2);
            velocity = new Vector2(0, 0);
            hitbox = new Rectangle();
            speed = 5; 
            sourceRectangle = new Rectangle(0, 0, 48, 40);
            health = 100;
        }

        public void Update()
        {
            position += velocity;
            
            //Hur långt borta från fienden spelaren är
            // distance = Vector2.Distance(player, enemy);

            //Kant av banan

            //Höger vägg
            if (position.X + sourceRectangle.Width > 750)
            {
                position.X = 750 - sourceRectangle.Width;
            }

            // Vänster vägg
            if (position.X + sourceRectangle.Width < sourceRectangle.Width)
            {
                position.X = 0;
            }

            //Nedre vägg
            if (position.Y + sourceRectangle.Width > 500)
            {
                position.Y = 500 - sourceRectangle.Width;
            }

            //Övre vägg
            if (position.Y + sourceRectangle.Width < sourceRectangle.Width)
            {
                position.Y = 0;
            }


            #region
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

            #endregion
        }



        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsed > 150)
            {
                elapsed = 0;
                sourceRectangle.X += 50;
                if (sourceRectangle.X > 150)
                {
                    sourceRectangle.X = 0;
                }

                KeyboardState pressedKeys = Keyboard.GetState();

                if (pressedKeys.IsKeyDown(Keys.W))
                    sourceRectangle.Y = 40;
                if (pressedKeys.IsKeyDown(Keys.S))
                    sourceRectangle.Y = 0;
                if (pressedKeys.IsKeyDown(Keys.D))
                    sourceRectangle.Y = 120;
                if (pressedKeys.IsKeyDown(Keys.A))
                    sourceRectangle.Y = 80;
                else
                {

                }

            }
            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White);
        }
    }
}
