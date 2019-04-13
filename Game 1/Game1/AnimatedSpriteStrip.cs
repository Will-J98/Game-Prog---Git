#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion



// AnimatedSpriteStrip.  This class  handles the animation and drawing of a 2D animation
// based on a single imported texture, which is a single horizontal strip of 
// sequential images (cells). AnimatedSprite expects the cells of the sprite strip to be 
// square; the class then calculates the number of cells in the strip based ion the strip's pixel height
// and length 


class AnimatedSpriteStrip
{
    // the action make, for multiple actions
    public String myName;
    // The tiled image from which we animate
    public Texture2D myCellsTexture;

    // Duration of time to show each frame.
    private float myFrameTime;

    //  is it looping... probably!
    // Non looping ones are for "one-shot" events such as explosions etc
    private bool myIsLooping;

    // The amount of time in seconds that the current frame has been shown for.
    private float elapsedFrameTime;

    // The number of frames in this animation
    private int numberOfFrames;

    // The actual cell being addressed at this GameTime (0... numCells-1) 
    private int currentFrameIndex;

    // counts from 0 to everupwards as the object lives on
    private int totalFramesPlayed;

    public float scale = 0.35f;


    // NEW stuff for the User Input examples
    public float XPos;
    public float YPos;
    public Vector2 SpritePosition;
    private SpriteEffects mySpriteEffects;
    private float myDrawingDepth;
    public float health;



    public AnimatedSpriteStrip(Texture2D texture, int numFrames, float frameTime, bool isLooping)
    {
        myCellsTexture = texture;
        myFrameTime = frameTime;
        myIsLooping = isLooping;
        numberOfFrames = numFrames;
        elapsedFrameTime = 0.0f;
        currentFrameIndex = 0;
        totalFramesPlayed = 0;

        XPos = 0f;
        YPos = 0f;

        mySpriteEffects = SpriteEffects.None;
        myDrawingDepth = 0.5f;
    }


    public void setName(string name)
    {
        myName = name;
    }

    // returns the centre of each cell
    public Vector2 Origin()
    {
        return new Vector2((myCellsTexture.Width / numberOfFrames * 2.0f), myCellsTexture.Height * 2.0f);
    }


    public void setSpriteEffect(SpriteEffects effect)
    {
        mySpriteEffects = effect;

    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {


        // Process passing time. ElapsedGameTime returns the amount of time elapsed since the last Update
        elapsedFrameTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (elapsedFrameTime > myFrameTime)
        {
            // Advance the frame index; looping or clamping as appropriate.
            totalFramesPlayed++;

            if (myIsLooping)
            {
                currentFrameIndex = totalFramesPlayed % numberOfFrames;
            }
            else
            {
                // freezes on the last frame
                currentFrameIndex = Math.Min(totalFramesPlayed, numberOfFrames - 1);

            }

            elapsedFrameTime = 0.0f;
        }

        // Calculate the source rectangle of the current frame
        int cellWidth = (int)myCellsTexture.Width / numberOfFrames;
        int cellHeight = myCellsTexture.Height;
        int leftMostPixel = currentFrameIndex * cellWidth;
        Rectangle sourceRect = new Rectangle(leftMostPixel, 0, cellWidth, cellHeight);

        // Draw the current frame.
        // (bigTexture, posOnScreen, sourceRect in big texture, col, rotation, origin, scale, effect, depth)
        Vector2 orig = Origin();
        Vector2 myPosition;
        myPosition.X = (float)XPos;
        myPosition.Y = (float)YPos;

        SpritePosition = new Vector2(XPos, YPos);
        spriteBatch.Draw(myCellsTexture, myPosition, sourceRect, Color.White, 0.0f, new Vector2(), scale, mySpriteEffects, 0.5f);
    }


}


