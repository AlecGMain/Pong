using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame22
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Viewport vp;
        bool dittoWins;
        bool minionWins;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Paddle ditto;
        Paddle hairy_yellow_guy;
        Ball epic;
        Ball poop;
        //To get something on the screen: Texture2D, Vector2, Color 
        //Texture2D image;
        //Vector2 position;
        //Color color;

        SpriteFont font;
        SpriteFont win;
        int scoreLeft = 0;
        int scoreRight = 0;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1200;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use Content.Load to load your game content here
            ditto = new Paddle(Content.Load<Texture2D>("ditto"), new Vector2(0, 50), Color.White);
            hairy_yellow_guy = new Paddle(Content.Load<Texture2D>("saf"), new Vector2(GraphicsDevice.Viewport.Width - 248, 700), Color.White);
            epic = new Ball(Content.Load<Texture2D>("Awesome_fae_guy"), new Vector2(1000, 500), Color.White, 20, 20);
            poop = new Ball(Content.Load<Texture2D>("Button"), new Vector2(300, 600), Color.White, 10, 10);

            font = Content.Load<SpriteFont>("SpriteFont1");
            win = Content.Load<SpriteFont>("SpriteFont2");
        }


        protected override void Update(GameTime gameTime)
        {
             vp = GraphicsDevice.Viewport;
            ditto.Update(vp, Keys.W, Keys.S, Keys.Left, Keys.Right, 631, 554);
            hairy_yellow_guy.Update(vp, Keys.Up, Keys.Down, Keys.A, Keys.D, 248, 364);
            epic.Update(vp);
            if (epic.hitbox.Intersects(ditto.hitbox))
            {

                epic.Speedx = Math.Abs(epic.Speedx);
            }

            if (epic.hitbox.Intersects(hairy_yellow_guy.hitbox))
            {
                epic.Speedx = -Math.Abs(epic.Speedx);
            }
            if (epic.Position.X <= 0 )
            {
                epic.Position = new Vector2(vp.Width / 2, vp.Height / 2);
                scoreRight++;
            }
            if(epic.Position.X >= vp.Width - epic.Image.Width)
            {
                epic.Position = new Vector2(vp.Width / 2, vp.Height / 2);
                scoreLeft++;
            }
            if(scoreLeft >= 10)
            {
                dittoWins = true;
                
            }
            if(scoreRight >= 10)
            {
                minionWins = true;
            }
                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            ditto.Draw(spriteBatch);
            hairy_yellow_guy.Draw(spriteBatch);
            epic.Draw(spriteBatch);

            string rightScoreText = $"Score: {scoreRight}";
            spriteBatch.DrawString(font, $"Score: {scoreLeft}", Vector2.Zero, Color.Cyan);
            spriteBatch.DrawString(font, rightScoreText, new Vector2(GraphicsDevice.Viewport.Width - font.MeasureString(rightScoreText).X, 0), Color.HotPink);
            if (dittoWins == true)
            {
                spriteBatch.DrawString(win, "DITTO WINS!", new Vector2(500, 300),  Color.GreenYellow);
                
            }
            else if(minionWins)
            {
                spriteBatch.DrawString(win, "MINION DUDE WINS!", new Vector2(vp.Width / 2, vp.Height / 2), Color.GreenYellow);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
