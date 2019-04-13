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
    Single_Sprite backgroundOne = new Single_Sprite();
    Single_Sprite backgroundTwo = new Single_Sprite();
    Single_Sprite backgroundThree = new Single_Sprite();
    Single_Sprite backgroundFour = new Single_Sprite();
    Single_Sprite backgroundFive = new Single_Sprite();
    Single_Sprite backgroundSix = new Single_Sprite();
    Single_Sprite backgroundSeven = new Single_Sprite();
    Single_Sprite backgroundEight = new Single_Sprite();
    Single_Sprite backgroundNine = new Single_Sprite();
    Single_Sprite backgroundTen = new Single_Sprite();




    public Single_Sprite bottomFloor = new Single_Sprite();
    public Single_Sprite bottomFloorTwo = new Single_Sprite();
    public Single_Sprite bottomFloorThree = new Single_Sprite();
    public Single_Sprite bottomFloorFour = new Single_Sprite();
    public Single_Sprite bottomFloorFive = new Single_Sprite();
    public Single_Sprite bottomFloorSix = new Single_Sprite();
    public Single_Sprite bottomFloorSeven = new Single_Sprite();
    public Single_Sprite bottomFloorEight = new Single_Sprite();

    public Single_Sprite platformOne = new Single_Sprite();
    public Single_Sprite platformTwo = new Single_Sprite();
    public Single_Sprite platformThree = new Single_Sprite();
    public Single_Sprite platformFour = new Single_Sprite();
    public Single_Sprite platformFive = new Single_Sprite();
    public Single_Sprite platformSix = new Single_Sprite();
    public Single_Sprite platformSeven = new Single_Sprite();
    public Single_Sprite platformEight = new Single_Sprite();
    public Single_Sprite platformNine = new Single_Sprite();
    public Single_Sprite platformTen = new Single_Sprite();
    public Single_Sprite platformEleven = new Single_Sprite();
    public Single_Sprite platformTwelve = new Single_Sprite();
    public Single_Sprite platform13 = new Single_Sprite();
    public Single_Sprite platform14 = new Single_Sprite();
    public Single_Sprite platform15 = new Single_Sprite();
    public Single_Sprite platform16 = new Single_Sprite();
    public Single_Sprite platform17 = new Single_Sprite();
    public Single_Sprite platform18 = new Single_Sprite();

    Single_Sprite redSquare1;
    Single_Sprite redSquare2;
    Single_Sprite redSquare3;
    Single_Sprite redSquare4;
    #endregion

    

    //List<Single_Sprite> floors = new List<Single_Sprite>();
    public List<Platform> platforms = new List<Platform>();


    public void Initialize()
    {
        backgroundOne.Scale = 0.6f;
        backgroundTwo.Scale = 0.6f;
        backgroundThree.Scale = 0.6f;
        backgroundFour.Scale = 0.6f;
        backgroundFive.Scale = 0.6f;
        backgroundSix.Scale = 0.6f;
        backgroundSeven.Scale = 0.6f;
        backgroundEight.Scale = 0.6f;
        backgroundNine.Scale = 0.6f;
        backgroundTen.Scale = 0.6f;


        bottomFloor.Scale = 0.7f;
        bottomFloorTwo.Scale = 0.7f;
        bottomFloorThree.Scale = 0.7f;
        bottomFloorFour.Scale = 0.7f;
        bottomFloorFive.Scale = 0.7f;
        bottomFloorSix.Scale = 0.7f;
        bottomFloorSeven.Scale = 0.7f;
        bottomFloorEight.Scale = 0.7f;

        redSquare1 = new Single_Sprite();
        redSquare2 = new Single_Sprite();
        redSquare3 = new Single_Sprite();
        redSquare4 = new Single_Sprite();

        platformOne.Scale = 0.5f;
        platformTwo.Scale = 0.5f;
        platformThree.Scale = 0.5f;
        platformFour.Scale = 0.5f;
        platformFive.Scale = 0.5f;
        platformSix.Scale = 0.5f;
        platformSeven.Scale = 0.5f;
        platformEight.Scale = 0.5f;
        platformNine.Scale = 0.5f;
        platformTen.Scale = 0.5f;
        platformEleven.Scale = 0.5f;
        platformTwelve.Scale = 0.5f;
        platform13.Scale = 0.5f;
        platform14.Scale = 0.5f;
        platform15.Scale = 0.5f;
       

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

        backgroundSix.LoadContent(theContentManager, "BG");
        backgroundSix.Position = new Vector2(backgroundFive.Position.X + backgroundFive.Size.Width, 0);

        backgroundSeven.LoadContent(theContentManager, "BG");
        backgroundSeven.Position = new Vector2(backgroundSix.Position.X + backgroundSix.Size.Width, 0);

        backgroundEight.LoadContent(theContentManager, "BG");
        backgroundEight.Position = new Vector2(backgroundSeven.Position.X + backgroundSeven.Size.Width, 0);

        backgroundNine.LoadContent(theContentManager, "BG");
        backgroundNine.Position = new Vector2(backgroundEight.Position.X + backgroundEight.Size.Width, 0);

        backgroundTen.LoadContent(theContentManager, "BG");
        backgroundTen.Position = new Vector2(backgroundNine.Position.X + backgroundNine.Size.Width, 0);



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
        platformTwo.Position = new Vector2(700, 270);

        platformThree.LoadContent(theContentManager, "Floating platform");
        platformThree.Position = new Vector2(1000, 385);

        platformFour.LoadContent(theContentManager, "Floating platform");
        platformFour.Position = new Vector2(1600, 385);

        platformFive.LoadContent(theContentManager, "LongPlat");
        platformFive.Position = new Vector2(1900, 270);

        platformSix.LoadContent(theContentManager, "Floating platform");
        platformSix.Position = new Vector2(2400, 385);

        platformSeven.LoadContent(theContentManager, "Floating platform");
        platformSeven.Position = new Vector2(2900, 385);

        platformEight.LoadContent(theContentManager, "Floating platform");
        platformEight.Position = new Vector2(3100, 270);

        platformNine.LoadContent(theContentManager, "Floating platform");
        platformNine.Position = new Vector2(3400, 385);

        platformTen.LoadContent(theContentManager, "Floating platform");
        platformTen.Position = new Vector2(4500, 385);

        platformEleven.LoadContent(theContentManager, "LongPlat");
        platformEleven.Position = new Vector2(4800, 270);

        platformTwelve.LoadContent(theContentManager, "Floating platform");
        platformTwelve.Position = new Vector2(5300, 385);

        platform13.LoadContent(theContentManager, "Floating platform");
        platform13.Position = new Vector2(5900, 385);

        platform14.LoadContent(theContentManager, "LongPlat");
        platform14.Position = new Vector2(6200, 270);

        platform15.LoadContent(theContentManager, "Floating platform");
        platform15.Position = new Vector2(6600, 385);

       

        #endregion

        redSquare1.LoadContent(theContentManager, "RedSquare");
        redSquare1.Position = new Vector2(platformOne.BoundingBox.X, platformOne.BoundingBox.Y);

        redSquare2.LoadContent(theContentManager, "RedSquare");
        redSquare2.Position = new Vector2(platformOne.BoundingBox.X + platformOne.BoundingBox.Width, platformOne.BoundingBox.Y);

        redSquare3.LoadContent(theContentManager, "RedSquare");
        redSquare3.Position = new Vector2(platformOne.BoundingBox.X, platformOne.BoundingBox.Y + platformOne.BoundingBox.Height);

        redSquare4.LoadContent(theContentManager, "RedSquare");
        redSquare4.Position = new Vector2(platformOne.BoundingBox.X + platformOne.BoundingBox.Width, platformOne.BoundingBox.Y + platformOne.BoundingBox.Height);


    }


    public void drawLevel(SpriteBatch spriteBatch)
    {
        backgroundOne.Draw(spriteBatch);
        backgroundTwo.Draw(spriteBatch);
        backgroundThree.Draw(spriteBatch);
        backgroundFour.Draw(spriteBatch);
        backgroundFive.Draw(spriteBatch);
        backgroundSix.Draw(spriteBatch);
        backgroundSeven.Draw(spriteBatch);
        backgroundEight.Draw(spriteBatch);
        backgroundNine.Draw(spriteBatch);
        backgroundTen.Draw(spriteBatch);

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
        platformEight.Draw(spriteBatch);
        platformNine.Draw(spriteBatch);
        platformTen.Draw(spriteBatch);
        platformEleven.Draw(spriteBatch);
        platformTwelve.Draw(spriteBatch);
        platform13.Draw(spriteBatch);
        platform14.Draw(spriteBatch);
        platform15.Draw(spriteBatch);
        




        //redSquare1.Draw(spriteBatch);
        //redSquare2.Draw(spriteBatch);
        //redSquare3.Draw(spriteBatch);
        //redSquare4.Draw(spriteBatch);
    }



}