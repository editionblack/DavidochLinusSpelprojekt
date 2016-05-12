using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;



namespace SpelProjektLinusDavid
{

    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        Texture2D bakgrund;
        float cooldown, lastShot, lastEnemy, lastHit, amountPerWave, enemyCooldown, wave, totalEnemiesCount, currentWeapon, currentWeaponDamage;
        Player player;
        Enemies enemy1;
        Projectiles bullet;
        List<Projectiles> bullets;
        List<Enemies> enemies;
        Color healthColor, bulletColor;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 750;
            graphics.PreferredBackBufferWidth = 1250;
        }

        protected override void Initialize()
        {
            player = new Player();
                enemy1 = new Enemies();
                enemies = new List<Enemies>();
                lastEnemy = 0;
            bullet = new Projectiles();
            bullets = new List<Projectiles>();
            cooldown = 500;
            enemyCooldown = 250;
            lastShot = 0;
            lastHit = 0;
            amountPerWave = 10;
            totalEnemiesCount = 0;
            wave = 1;
            currentWeapon = 1;
            healthColor = Color.Black;
            bulletColor = Color.White;
            
            //player.profession = "Vampire";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            bakgrund = Content.Load<Texture2D>("bakgrund");
            player.spriteSheet = Content.Load<Texture2D>("sprite-sheet");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");
            //enemy1.sprite = Content.Load<Texture2D>("enemy");
            
            foreach(Enemies enemy in enemies)
            {
            enemy1.sprite = Content.Load<Texture2D>("enemy");
            }
            
            foreach(Projectiles bullet in bullets)
            {
                bullet.sprite = Content.Load<Texture2D>("Bullet");
            }
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            
        }
        protected override void Update(GameTime gameTime)
        {
            lastShot += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            lastEnemy += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            lastHit += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            KeyboardState pressedKeys = Keyboard.GetState();
            
            
            #region Waving 
                for (int i = 0; i < amountPerWave; i++)
                {
                    if (lastEnemy > enemyCooldown && enemies.Count < amountPerWave && totalEnemiesCount < amountPerWave)
                    {
                        Enemies newEnemy = new Enemies();
                        newEnemy.sprite = Content.Load<Texture2D>("enemy");
                        enemies.Add(newEnemy);
                        lastEnemy = 0;
                        totalEnemiesCount++;
                        Random rnd = new Random();
                        newEnemy.position = new Vector2(rnd.Next(-2500, 2500),rnd.Next(-2500,2500));
                    }
                }
                if (totalEnemiesCount > 0 && enemies.Count == 0)
                {
                    totalEnemiesCount = 0;
                    amountPerWave += 5;
                }
            #endregion

            #region Movement
            if (pressedKeys.IsKeyDown(Keys.W))
            {
                player.velocity.Y = -player.speed;
            }
            else if (pressedKeys.IsKeyDown(Keys.S))
            {
                player.velocity.Y = player.speed;
            }
            else
                player.velocity.Y = 0;
            if (pressedKeys.IsKeyDown(Keys.D))
            {
                player.velocity.X = player.speed;
            }
            else if (pressedKeys.IsKeyDown(Keys.A))
            {
                player.velocity.X = -player.speed;
            }
            else player.velocity.X = 0;
            #endregion

            #region Bullet control
            if (currentWeapon == 1) //Gun
            {
                if (lastShot > player.gunCooldown)
                {
                    if (pressedKeys.IsKeyDown(Keys.Left))
                    {

                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, -bullet.speed, 0, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;
                    }


                    else if (pressedKeys.IsKeyDown(Keys.Right))
                    {

                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, bullet.speed, 0, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;
                    }

                    else if (pressedKeys.IsKeyDown(Keys.Up))
                    {

                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, 0, -bullet.speed, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;


                    }

                    else if (pressedKeys.IsKeyDown(Keys.Down))
                    {

                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, 0, bullet.speed, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;
                    }
                }
            }
            else if (currentWeapon == 2) //Shotgun
            {
                if (lastShot > player.gunCooldown)
                {
                    if (pressedKeys.IsKeyDown(Keys.Left))
                    {

                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, -bullet.speed, 0, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, -bullet.speed, bullet.speed / 2, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, -bullet.speed, -bullet.speed / 2, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;
                    }


                    else if (pressedKeys.IsKeyDown(Keys.Right))
                    {

                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, bullet.speed, 0, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, bullet.speed, bullet.speed / 2, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, bullet.speed, -bullet.speed / 2, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;
                    }

                    else if (pressedKeys.IsKeyDown(Keys.Up))
                    {

                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, 0, -bullet.speed, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, bullet.speed / 2, -bullet.speed, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, -bullet.speed / 2, -bullet.speed, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;


                    }

                    else if (pressedKeys.IsKeyDown(Keys.Down))
                    {

                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, 0, bullet.speed, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, bullet.speed / 2, bullet.speed, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, -bullet.speed / 2, bullet.speed, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;
                    }
                }
            }
            if (currentWeapon == 3) // Machinegun
            {
                if (lastShot > player.machinegunCooldown/2)
                {
                    Random rnd = new Random();
                    if (pressedKeys.IsKeyDown(Keys.Left))
                    {
                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, -bullet.speed, rnd.Next(-2, 3), currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;
                    }


                    else if (pressedKeys.IsKeyDown(Keys.Right))
                    {

                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, bullet.speed, rnd.Next(-2, 3), currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;
                    }

                    else if (pressedKeys.IsKeyDown(Keys.Up))
                    {

                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, rnd.Next(-2, 3), -bullet.speed, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;


                    }

                    else if (pressedKeys.IsKeyDown(Keys.Down))
                    {

                        bullet = new Projectiles(player.position.X + 10, player.position.Y + 10, rnd.Next(-2, 3), bullet.speed, currentWeaponDamage);
                        bullet.sprite = Content.Load<Texture2D>("Bullet");
                        bullets.Add(bullet);
                        lastShot = 0;
                    }
                }
            }
            if (currentWeapon == 1)
            {
                currentWeaponDamage = player.gunDamage;
            }
            if (currentWeapon == 2)
            {
                currentWeaponDamage = player.shotgunDamage;
            }
            if (currentWeapon == 3)
            {
                currentWeaponDamage = player.machinegunDamage;
            }
            #endregion

            #region Weapon control

            if (pressedKeys.IsKeyDown(Keys.D1))
            {

                currentWeapon = 1;
            }
            if (pressedKeys.IsKeyDown(Keys.D2))
            {

                currentWeapon = 2;
            }
            if (pressedKeys.IsKeyDown(Keys.D3))
            {

                currentWeapon = 3;
            }





            #endregion

            #region Progression!
            if (player.experiencePoints == 10)
            {
               
                if (player.gunCooldown > 410)
                {
                    player.gunCooldown -= 10;
                }
                player.experiencePoints = 0;
                player.level++;
            }
            #endregion

            #region Professions control

            //if(player.profession == "Vampire") 
            //{
            //    if (pressedKeys.IsKeyDown(Keys.Space) && player.health < 100 && player.manaPoints > 5)
            //    {
            //        player.health += 25;
            //        player.manaPoints -= 5;
                   
            //    }
            //}
            #endregion


            player.Update();

            foreach (Enemies enemyUpdate in enemies)
            {
                enemyUpdate.Update(player.position);
            }

            foreach (Projectiles bulletUpdate in bullets)
            {
                bulletUpdate.Update();
            }

            for (int i = 0; i < bullets.Count;i++ )
            {

                for (int j = 0; j < enemies.Count; j++ )
                {
                    
                    
                        if (bullets[i].Hitbox.Intersects(enemies[j].Hitbox))
                        {
                            
                            enemies[j].health -= bullets[i].damage;
                            bullets.RemoveAt(i);
                            player.experiencePoints++;
                            if (bullets.Count == 0)
                                goto outOfLoop; 
                            else
                                i--;
                        }
                }
            }
            outOfLoop: 

            for (int i = 0; i < enemies.Count; i++) 
            {
                if (player.Hitbox.Intersects(enemies[i].Hitbox))
                {
                    if (lastHit > cooldown)
                    {
                        player.health -= 10;
                        
                        lastHit = 0;
                    }
                }
            } 
            //if(player.distance < 5)  
            //{
            //    Färg = Color.Red;
            //}
            if (player.health == 0 || player.health < 0)
            {
                Game newGame = new Game1();
                newGame.Run();
                Environment.Exit(0);
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].health == 0 || enemies[i].health < 0)
                {
                    enemies.RemoveAt(i);
                }
            }
                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Bakgrund målas alltid ut först
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null, null);

            spriteBatch.Draw(bakgrund, Vector2.Zero, Color.White);
            //spriteBatch.Draw(enemy1.sprite, enemy1.startPoint, Color.White);

            foreach (Enemies enemy in enemies)
            {
                spriteBatch.Draw(enemy.sprite, enemy.position, Color.Red);

            }

            //spriteBatch.Draw(enemy1.sprite, enemy1.position, Color.White);

            //spriteBatch.Draw(player.spriteSheet, player.position, Color.White);
            foreach (Projectiles bullet in bullets) 
            {
                spriteBatch.Draw(bullet.sprite, bullet.position, bulletColor);
            
            }
            
            player.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(font,player.health.ToString(),new Vector2(5,75), healthColor);

            spriteBatch.DrawString(font, player.level.ToString(), new Vector2(5,125), Color.Black);
            if (player.health > 30 && player.health < 71)
            {
                healthColor = Color.Yellow;
            }
            else if (player.health == 30 || player.health < 30)
            {
                healthColor = Color.Red;
            }
            else
                healthColor = Color.Black;
            spriteBatch.End();

            base.Draw(gameTime);


            

            
        }
    }
}
