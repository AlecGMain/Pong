using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame22
{
    class Sprite
    {
        public Texture2D Image;
        public Vector2 Position;
        Color Color;
        public Rectangle hitbox;

        public Sprite(Texture2D image, Vector2 position, Color color)
        {
            Image = image;
            Position = position;
            Color = color;
            hitbox = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, Color);
        }
        public void Update( Viewport vp, Keys up, Keys down, Keys left, Keys right, int width, int height)
        {
            hitbox.X = (int)Position.X;
            hitbox.Y = (int)Position.Y;
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(up) && Position.Y >= 0)
            {
                Position.Y-=10;
            }
            if (ks.IsKeyDown(down) && Position.Y <= vp.Height - Image.Height)
            {
                Position.Y+=10;
            }   
        }
    }
}
