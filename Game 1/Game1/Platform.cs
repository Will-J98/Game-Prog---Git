using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Platform
{
    Texture2D texture;
    Vector2 position;
    public Rectangle TopLine;
    double scale;

    public Platform(Texture2D newTexture, Vector2 newPosition, double mScale)
    {
        texture = newTexture;
        position = newPosition;
        scale = mScale;

        TopLine = new Rectangle((int)position.X, (int)position.Y,
            (int)(texture.Width * scale), 5);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, TopLine, Color.White);
    }
}

