using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

class ScrollBackground
{
    Single_Sprite backgroundOne;
    Single_Sprite backgroundTwo;
    Single_Sprite backgroundThree;
    Single_Sprite backgroundFour;
    Single_Sprite backgroundFive;
    Vector2 scrollSpeed = new Vector2 (160,0);
    Vector2 Direction = new Vector2(-1, 0);
    Vector2 Position = new Vector2(0, 0);

    public ScrollBackground()
    {
        
    }

    public void Initialize()
    {
        backgroundOne = new Single_Sprite();
        backgroundOne.Scale = 0.6f;
        backgroundTwo = new Single_Sprite();
        backgroundTwo.Scale = 0.6f;
        backgroundThree = new Single_Sprite();
        backgroundThree.Scale = 0.6f;
        backgroundFour = new Single_Sprite();
        backgroundFour.Scale = 0.6f;
        backgroundFive = new Single_Sprite();
        backgroundFive.Scale = 0.6f;
    }

    public void LoadBackground(ContentManager theContentManager)
    {
        backgroundOne.LoadContent(theContentManager, "BG");
        //backgroundOne.Scale = 0.6f;
        backgroundOne.Position = new Vector2(0, 0);
        
        backgroundTwo.LoadContent(theContentManager, "BG");
        //backgroundTwo.Scale = 0.6f;
        backgroundTwo.Position = new Vector2(backgroundOne.Position.X + backgroundOne.Size.Width, 0);
     
        backgroundThree.LoadContent(theContentManager, "BG");
        //backgroundThree.Scale = 0.6f;
        backgroundThree.Position = new Vector2(backgroundTwo.Position.X + backgroundTwo.Size.Width, 0);

        backgroundFour.LoadContent(theContentManager, "BG");
        //backgroundFour.Scale = 0.6f;
        backgroundFour.Position = new Vector2(backgroundThree.Position.X + backgroundThree.Size.Width, 0);

        backgroundFive.LoadContent(theContentManager, "BG");
        //backgroundFive.Scale = 0.6f;
        backgroundFive.Position = new Vector2(backgroundFour.Position.X + backgroundFour.Size.Width, 0);

    }

    public void updateBackground(GameTime theGameTime)
    {
        if (backgroundOne.Position.X < -backgroundOne.Size.Width)
        {
            backgroundOne.Position.X = backgroundThree.Position.X + backgroundThree.Size.Width;
        }

        if (backgroundTwo.Position.X < -backgroundTwo.Size.Width)
        {
            backgroundTwo.Position.X = backgroundOne.Position.X + backgroundOne.Size.Width;
        }

        if (backgroundThree.Position.X < -backgroundThree.Size.Width)
        {
            backgroundThree.Position.X = backgroundTwo.Position.X + backgroundTwo.Size.Width;
        }
        if (backgroundFour.Position.X < -backgroundFour.Size.Width)
        {
            backgroundFour.Position.X = backgroundThree.Position.X + backgroundThree.Size.Width;
        }

        if (backgroundFive.Position.X < -backgroundFive.Size.Width)
        {
            backgroundFive.Position.X = backgroundFour.Position.X + backgroundFour.Size.Width;
        }

        Direction = new Vector2(-1, 0);
        scrollSpeed = new Vector2(160, 0);

        backgroundOne.Position += Direction * scrollSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
        backgroundTwo.Position += Direction * scrollSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
        backgroundThree.Position += Direction * scrollSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
        backgroundFour.Position += Direction * scrollSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
        backgroundFive.Position += Direction * scrollSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
    }

    public void drawBackground(SpriteBatch spriteBatch)
    {
        backgroundOne.Draw(spriteBatch);
        backgroundTwo.Draw(spriteBatch);
        backgroundThree.Draw(spriteBatch);
        backgroundFour.Draw(spriteBatch);
        backgroundFive.Draw(spriteBatch);
    }

       

        
}

