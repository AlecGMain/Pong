using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame22
{
    class Ball    
    {
        public Texture2D Image;
        public Vector2 Position;
        Color Color;
        public int Speedx;
        int Speedy;
        public Rectangle hitbox;

        

        public Ball(Texture2D image, Vector2 position, Color color, int speedx, int speedy)
        {
            Image = image;
            Position = position;
            Color = color;
            Speedx = speedx;
            Speedy = speedy;
            hitbox = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, Color);
        }
        public void Update(Viewport vp)
        {
            Position.X += Speedx;
            Position.Y += Speedy;
            hitbox.X = (int)Position.X;
            hitbox.Y = (int)Position.Y;

            if (Position.X <= 0)
            {
                Speedx *= -1;
            }
            if (Position.X >= vp.Width - Image.Width)
            {
                Speedx *= -1;
            }
            if (Position.Y <= 0)
            {
                Speedy *= -1;
            }
            if (Position.Y >= vp.Height - Image.Height)
            {
                Speedy *= -1;
            }
           // TODO: Add your update logic here


        }
    }
     
}
