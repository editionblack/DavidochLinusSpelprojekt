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
        public Texture2D spriteSheet;
        //public float distance;
        Rectangle hitbox;
        public float speed = 5;
        public int health, gunCooldown, experiencePoints, level, manaPoints, machinegunCooldown;
        //public string profession; 

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
                hitbox.Width = 48;
                hitbox.Height = 60;
                return hitbox;
            }
        }

        public Player()
        {
            position = new Vector2(500/2, 500/2);
            velocity = new Vector2(0, 0);
            hitbox = new Rectangle();
            speed = 5;
            health = 100;
            //manaPoints = 0;
            gunCooldown = 750;
            machinegunCooldown = 250;
            experiencePoints = 0;
            level = 1;
           // profession = "Blank";
            sourceRectangle = new Rectangle(0, 0, 48, 60);
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


            #region Bullshit
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

            if (elapsed > 90)
            {
                elapsed = 0;
                sourceRectangle.X += 64; //deras bredd
                if (sourceRectangle.X > 620) //bildens bredd
                {
                    sourceRectangle.X = 0;
                }

                KeyboardState pressedKeys = Keyboard.GetState();
                bool lastPressedKeyW, lastPressedKeyS, lastPressedKeyD, lastPressedKeyA;

                if (pressedKeys.IsKeyDown(Keys.W))
                {
                    sourceRectangle.Y = 388;
                    lastPressedKeyW = true;
                }
                else if (pressedKeys.IsKeyDown(Keys.S))
                {
                    sourceRectangle.Y = 263;
                    lastPressedKeyS = true;
                }
                else if (pressedKeys.IsKeyDown(Keys.D))
                {
                    sourceRectangle.Y = 456;
                    lastPressedKeyD = true;
                }
                else if (pressedKeys.IsKeyDown(Keys.A))
                {
                    sourceRectangle.Y = 328;
                    lastPressedKeyA = true;
                }
                else
                {
                    if (lastPressedKeyS = true)
                    {
                        sourceRectangle.Y = 7;
                        sourceRectangle.X = 0;
                    }
                    else if (lastPressedKeyA = true)
                    {
                    sourceRectangle.Y = 80;
                        sourceRectangle.X = 0;
                    }
                    else if (lastPressedKeyW = true)
                    {
                        sourceRectangle.Y = 145;
                        sourceRectangle.X = 0;
                    }
                    else if (lastPressedKeyD = true)
                    {
                        sourceRectangle.Y = 210;
                        sourceRectangle.X = 0;
                    }
                }

            }
            spriteBatch.Draw(spriteSheet, position, sourceRectangle, Color.White);
        }
    }
}
