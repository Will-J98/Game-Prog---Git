using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

class GameLevel
{
    #region initSprites
    Single_Sprite backgroundOne;
    Single_Sprite backgroundTwo;
    Single_Sprite backgroundThree;
    Single_Sprite backgroundFour;
    Single_Sprite backgroundFive;
  
    public Single_Sprite bottomFloor;
    public Single_Sprite bottomFloorTwo;
    public Single_Sprite bottomFloorThree;
    public Single_Sprite bottomFloorFour;
    public Single_Sprite bottomFloorFive;
    public Single_Sprite bottomFloorSix;
    public Single_Sprite bottomFloorSeven;
    public Single_Sprite bottomFloorEight;

    public Single_Sprite platformOne;
    public Single_Sprite platformTwo;
    public Single_Sprite platformThree;
    public Single_Sprite platformFour;
    public Single_Sprite platformFive;
    public Single_Sprite platformSix;
    public Single_Sprite platformSeven;

    Single_Sprite redSquare1;
    Single_Sprite redSquare2;
    Single_Sprite redSquare3;
    Single_Sprite redSquare4;
    int i;
    Vector2 scrollSpeed = new Vector2 (160,0);
    Vector2 Direction = new Vector2(-1, 0);
    Vector2 Position = new Vector2(0, 0);
    #endregion

    

    //List<Single_Sprite> floors = new List<Single_Sprite>();
    //List<Single_Sprite> platforms = new List<Single_Sprite>();


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

        bottomFloor = new Single_Sprite();
        bottomFloor.Scale = 0.7f;
        bottomFloorTwo = new Single_Sprite();
        bottomFloorTwo.Scale = 0.7f;
        bottomFloorThree = new Single_Sprite();
        bottomFloorThree.Scale = 0.7f;
        bottomFloorFour = new Single_Sprite();
        bottomFloorFour.Scale = 0.7f;
        bottomFloorFive = new Single_Sprite();
        bottomFloorFive.Scale = 0.7f;
        bottomFloorSix = new Single_Sprite();
        bottomFloorSix.Scale = 0.7f;
        bottomFloorSeven = new Single_Sprite();
        bottomFloorSeven.Scale = 0.7f;
        bottomFloorEight = new Single_Sprite();
        bottomFloorEight.Scale = 0.7f;

        redSquare1 = new Single_Sprite();
        redSquare2 = new Single_Sprite();
        redSquare3 = new Single_Sprite();
        redSquare4 = new Single_Sprite();


        platformOne = new Single_Sprite();
        platformOne.Scale = 0.5f;

        platformTwo = new Single_Sprite();
        platformTwo.Scale = 0.5f;

        platformThree = new Single_Sprite();
        platformThree.Scale = 0.5f;

        platformFour = new Single_Sprite();
        platformFour.Scale = 0.5f;

        platformFive = new Single_Sprite();
        platformFive.Scale = 0.5f;

        platformSix = new Single_Sprite();
        platformSix.Scale = 0.5f;

        platformSeven = new Single_Sprite();
        platformSeven.Scale = 0.5f;

    }

    public void LoadLevel(ContentManager theContentManager)
    {
        #region Load Background
        backgroundOne.LoadContent(theContentManager, "BG");
        backgroundOne.Position = new Vector2(0, 0);
        
        backgroundTwo.LoadContent(theContentManager, "BG");
        backgroundTwo.Position = new Vector2(backgroundOne.Position.X + backgroundOne.Size.Width, 0);
     
        backgroundThree.LoadContent(theContentManager, "BG");
        backgroundThree.Position = new Vector2(backgroundTwo.Position.X + backgroundTwo.Size.Width, 0);

        backgroundFour.LoadContent(theContentManager, "BG");
        backgroundFour.Position = new Vector2(backgroundThree.Position.X + backgroundThree.Size.Width, 0);

        backgroundFive.LoadContent(theContentManager, "BG");
        backgroundFive.Position = new Vector2(backgroundFour.Position.X + backgroundFour.Size.Width, 0);
        #endregion

        #region Load Floor

        bottomFloor.LoadContent(theContentManager, "Bottom floor");
        bottomFloor.Position = new Vector2(0, 500);

        bottomFloorTwo.LoadContent(theContentManager, "Bottom floor");
        bottomFloorTwo.Position = new Vector2(bottomFloor.Position.X + bottomFloor.Size.Width, 500);

        bottomFloorThree.LoadContent(theContentManager, "Bottom floor");
        bottomFloorThree.Position = new Vector2(bottomFloorTwo.Position.X + bottomFloorTwo.Size.Width, 500);

        bottomFloorFour.LoadContent(theContentManager, "Bottom floor");
        bottomFloorFour.Position = new Vector2(bottomFloorThree.Position.X + bottomFloorThree.Size.Width, 500);

        bottomFloorFive.LoadContent(theContentManager, "Bottom floor");
        bottomFloorFive.Position = new Vector2(bottomFloorFour.Position.X + bottomFloorFour.Size.Width, 500);

        bottomFloorSix.LoadContent(theContentManager, "Bottom floor");
        bottomFloorSix.Position = new Vector2(bottomFloorFive.Position.X + bottomFloorFive.Size.Width, 500);

        bottomFloorSeven.LoadContent(theContentManager, "Bottom floor");
        bottomFloorSeven.Position = new Vector2(bottomFloorSix.Position.X + bottomFloorSix.Size.Width, 500);


        #endregion

        #region Load Platforms



        platformOne.LoadContent(theContentManager, "Floating platform");
        platformOne.Position = new Vector2(400, 385);

        platformTwo.LoadContent(theContentManager, "Floating platform");
        platformTwo.Position = new Vector2(650, 270);

        platformThree.LoadContent(theContentManager, "Floating platform");
        platformThree.Position = new Vector2(900, 385);

        platformFour.LoadContent(theContentManager, "Floating platform");
        platformFour.Position = new Vector2(1400, 385);

        platformFive.LoadContent(theContentManager, "Floating platform");
        platformFive.Position = new Vector2(1650, 270);

        platformSix.LoadContent(theContentManager, "Floating platform");
        platformSix.Position = new Vector2(1900, 385);

        platformSeven.LoadContent(theContentManager, "Floating platform");
        platformSeven.Position = new Vector2(400, 385);

        #endregion

        redSquare1.LoadContent(theContentManager, "RedSquare");
        redSquare1.Position = new Vector2(platformOne.BoundingBox.X, platformOne.BoundingBox.Y);

        redSquare2.LoadContent(theContentManager, "RedSquare");
        redSquare2.Position = new Vector2(platformOne.BoundingBox.X + platformOne.BoundingBox.Width, platformOne.BoundingBox.Y);

        redSquare3.LoadContent(theContentManager, "RedSquare");
        redSquare3.Position = new Vector2(platformOne.BoundingBox.X, platformOne.BoundingBox.Y + platformOne.BoundingBox.Height);

        redSquare4.LoadContent(theContentManager, "RedSquare");
        redSquare4.Position = new Vector2(platformOne.BoundingBox.X + platformOne.BoundingBox.Width, platformOne.BoundingBox.Y + platformOne.BoundingBox.Height);

        

        //Health_Bar.LoadContent(theContentManager, "HealthBar");
        //Health_Bar.Position = new Vector2(250, 100);

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

    public void drawLevel(SpriteBatch spriteBatch)
    {
        backgroundOne.Draw(spriteBatch);
        backgroundTwo.Draw(spriteBatch);
        backgroundThree.Draw(spriteBatch);
        backgroundFour.Draw(spriteBatch);
        backgroundFive.Draw(spriteBatch);

        bottomFloor.Draw(spriteBatch);
        bottomFloorTwo.Draw(spriteBatch);
        bottomFloorThree.Draw(spriteBatch);
        bottomFloorFour.Draw(spriteBatch);
        bottomFloorFive.Draw(spriteBatch);
        bottomFloorSix.Draw(spriteBatch);
        bottomFloorSeven.Draw(spriteBatch);

        platformOne.Draw(spriteBatch);
        platformTwo.Draw(spriteBatch);
        platformThree.Draw(spriteBatch);
        platformFour.Draw(spriteBatch);
        platformFive.Draw(spriteBatch);
        platformSix.Draw(spriteBatch);
        platformSeven.Draw(spriteBatch);




        redSquare1.Draw(spriteBatch);
        redSquare2.Draw(spriteBatch);
        redSquare3.Draw(spriteBatch);
        redSquare4.Draw(spriteBatch);

        //Health_Bar.Draw(spriteBatch);
    }




}

