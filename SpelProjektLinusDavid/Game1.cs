using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;



namespace SpelProjektLinusDavid
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 

    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        Texture2D bakgrund;
        float cooldown, lastShot;
        Player player;
        Enemies enemy1;
        Projectiles bullet;
        List<Projectiles> bullets;
        public Game1()
        {

            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 750;
            

            
            

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            player = new Player();
            bullet = new Projectiles();
            bullets = new List<Projectiles>();
            cooldown = 500;
            lastShot = 0;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            bakgrund = Content.Load<Texture2D>("bakgrund");
            player.spriteSheet = Content.Load<Texture2D>("spritess");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            enemy1.sprite = Content.Load<Texture2D>("enemy");
            
            foreach(Projectiles bullet in bullets) {
                bullet.sprite = Content.Load<Texture2D>("Bullet");
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            lastShot += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            
            KeyboardState pressedKeys = Keyboard.GetState();
            if (pressedKeys.IsKeyDown(Keys.W))
            {
                player.velocity.Y = -5;
            }
            else if (pressedKeys.IsKeyDown(Keys.S))
            {
                player.velocity.Y = 5;
            }
            else
                player.velocity.Y = 0;
            if (pressedKeys.IsKeyDown(Keys.D))
            {
                player.velocity.X = 5;
            }
            else if (pressedKeys.IsKeyDown(Keys.A))
            {
                player.velocity.X = -5;
            }
            else player.velocity.X = 0;

            if (lastShot > cooldown)
            {
                if (pressedKeys.IsKeyDown(Keys.Left))
                {

                    bullet = new Projectiles(player.position.X+10, player.position.Y+10, -bullet.speed, 0);
                    bullet.sprite = Content.Load<Texture2D>("Bullet");
                    bullets.Add(bullet);
                    lastShot = 0;
                }
                    

                else if (pressedKeys.IsKeyDown(Keys.Right))
                {

                    bullet = new Projectiles(player.position.X+10, player.position.Y+10, bullet.speed, 0);
                    bullet.sprite = Content.Load<Texture2D>("Bullet");
                    bullets.Add(bullet);
                    lastShot = 0;
                }

                else if (pressedKeys.IsKeyDown(Keys.Up))
            {

                    bullet = new Projectiles(player.position.X+10, player.position.Y+10, 0, -bullet.speed);
                bullet.sprite = Content.Load<Texture2D>("Bullet");
                bullets.Add(bullet);
                    lastShot = 0;
            }
            
                else if (pressedKeys.IsKeyDown(Keys.Down))
                {

                    bullet = new Projectiles(player.position.X+10, player.position.Y+10, 0, bullet.speed);
                    bullet.sprite = Content.Load<Texture2D>("Bullet");
                    bullets.Add(bullet);
                    lastShot = 0;
                }
            }
            player.Update();
            enemy1.Update(player.Position);
            foreach (Projectiles bulletUpdate in bullets)
            {
                bulletUpdate.Update();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Bakgrund målas alltid ut först
            spriteBatch.Begin();

            spriteBatch.Draw(bakgrund, Vector2.Zero, Color.White);

            //spriteBatch.Draw(player.spriteSheet, player.position, Color.White);
            foreach (Projectiles bullet in bullets) 
            {
                spriteBatch.Draw(bullet.sprite, bullet.position, Color.White);
            
            }

            player.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
