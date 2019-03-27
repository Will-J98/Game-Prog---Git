using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
class Single_Sprite
{
    public Vector2 Position = new Vector2(0, 0);
    private Texture2D mSpriteTexture;
    public Rectangle Size;
    public float Scale = 1.0f;
    internal int Top;

    public Rectangle BoundingBox
    {
        get
        {
            return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                (int)(mSpriteTexture.Width * Scale),
                (int)(mSpriteTexture.Height * Scale));
        }
    }

    public Rectangle TopLine
    {
        get
        {
            return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                (int)(mSpriteTexture.Width * Scale),
                1);
        }
    }


    public void LoadContent(ContentManager theContentManager, string theAssetName)
    {
        mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
        Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));

    }

    public void Draw(SpriteBatch theSpriteBatch)
    {
        theSpriteBatch.Draw(mSpriteTexture, Position,
              new Rectangle(0,0, mSpriteTexture.Width, mSpriteTexture.Height), Color.White, //change bounding to get textures back
              0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
    }


}





