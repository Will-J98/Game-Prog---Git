using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    private Texture2D heroRunCells;
    private InputHandler input;
    ScrollBackground myBackground = new ScrollBackground();




    // The AnimatedSpriteStrip class is not part of XNA but has been written by Simon Schofield
    // to help with the animation of animated sprites and can be found in the 
    // solution explorer
    private AnimatedSpriteStripManager myHero = new AnimatedSpriteStripManager(10);

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        graphics.PreferredBackBufferWidth = 768;
        graphics.PreferredBackBufferHeight = 576;
        Content.RootDirectory = "Content";



        // The InputHandler class is not part of XNA but has been written by Simon Schofield to help
        // parse user input. The class casn be found in the Solution Explorer
        input = new InputHandler();

    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
        myBackground.Initialize();
       

        base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);

            
        myBackground.LoadBackground(Content);

       

        AnimatedSpriteStrip myHeroRunning = new AnimatedSpriteStrip(Content.Load<Texture2D>("HeroRun"), 10, 0.1f, true);
        AnimatedSpriteStrip myHeroJumping = new AnimatedSpriteStrip(Content.Load<Texture2D>("HeroJump"), 11, 0.1f, true);
        AnimatedSpriteStrip myHeroIdle = new AnimatedSpriteStrip(Content.Load<Texture2D>("Idle"), 1, 0.1f, true);
        myHeroRunning.setName("run");
        myHeroJumping.setName("jump");
        myHeroIdle.setName("idle");
        myHero.addAnimatedSpriteStrip(myHeroRunning);
        myHero.addAnimatedSpriteStrip(myHeroJumping);
        myHero.addAnimatedSpriteStrip(myHeroIdle);
        myHero.XPos = 200;
        myHero.YPos = 200;

        // TODO: use this.Content to load your game content here
    }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// all content.
    /// </summary>
    protected override void UnloadContent()
    {
        // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
        // Allows the game to exit
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();
        input.Update();

        myBackground.updateBackground(gameTime);

        if (input.IsKeyDown(Keys.Left))
        {
            myHero.setCurrentAction("run");
            myHero.XPos -= 4;
            myHero.setCurrentDirection("left");
        }
        else if (input.HasReleasedKey(Keys.Left))
        {
            myHero.setCurrentAction("idle");
        }

        if (input.IsKeyDown(Keys.Right))
        {
            myHero.setCurrentAction("run");
            myHero.XPos += 4;
            myHero.setCurrentDirection("right");
        }
        else if (input.HasReleasedKey(Keys.Right))
        {
            myHero.setCurrentAction("idle");
            Console.WriteLine(myHero.currentActionName);
        }

        if (input.WasKeyPressed(Keys.Space))
        {
            myHero.YPos -= 40;
            myHero.setCurrentAction("jump");
        }
        else if (input.HasReleasedKey(Keys.Space))
        {
            Console.WriteLine("Space Released");
            myHero.YPos += 40;
            Console.WriteLine(myHero.YPos);
        }
        if (input.IsKeyDown(Keys.RightShift))
        {
            myHero.setCurrentAction("idle");

        }
        else
        {

            myHero.setCurrentAction("run");

        }




        base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);


        // Draw the sprite.
        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
        myBackground.drawBackground(spriteBatch);
        myHero.Draw(gameTime, spriteBatch);


        spriteBatch.End();

        base.Draw(gameTime);
    }
}
