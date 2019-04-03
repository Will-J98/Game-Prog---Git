using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    private Texture2D heroRunCells;
    private InputHandler input;
    GameLevel myLevel = new GameLevel();
    Character Knight;
    Enemy enemy;
    Camera camera = new Camera();
    GroundCollision groundCollision;
    CoinCollection coin;
    //Display display = new Display();
    SpriteFont Health;
    SpriteFont Time;
    int gTime = 60;
    float timer;
    
    


    private Color _backgroundColour = Color.CornflowerBlue;

    //private List<Component> _gameComponents;
  


    // The AnimatedSpriteStrip class is not part of XNA but has been written by Simon Schofield
    // to help with the animation of animated sprites and can be found in the 
    // solution explorer


    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        graphics.PreferredBackBufferWidth = 768;
        graphics.PreferredBackBufferHeight = 576;
        Content.RootDirectory = "Content";



        // The InputHandler class is not part of XNA but has been written by Simon Schofield to help
        // parse user input. The class casn be found in the Solution Explorer
        input = new InputHandler();
        Knight = new Character(input);
        groundCollision = new GroundCollision(Knight, myLevel);
        coin = new CoinCollection(Knight);
        enemy = new Enemy(Knight);

    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
        IsMouseVisible = true;

        myLevel.Initialize();
        
       

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

        Health = Content.Load<SpriteFont>("Fonts/Health1");
        Time = Content.Load<SpriteFont>("Fonts/Time");
        //display.LoadText(Content);
        myLevel.LoadLevel(Content);
        Knight.LoadKnight(Content);
        Knight.LoadSqaures(Content);
        coin.LoadCoins(Content);
        enemy.LoadEnemy(Content);
        enemy.LoadSqaures(Content);
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

        Knight.squareUpdate();
        //enemy.squareUpdate();

        
        camera.Update(Knight.knightPos());

        if (groundCollision.is_Colliding() == true)
        {
            Knight.is_grounded = true;
            //Console.WriteLine("True");
        }
        if(groundCollision.is_Colliding() == false)
        {
            Knight.is_grounded = false;
        }

        Knight.updateKnight(gameTime, spriteBatch);
        enemy.Update(gameTime);
        coin.coinPickup();
        //Console.WriteLine(Knight.score);

        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        gTime -= (int)timer;
        if(timer >= 1.0F) timer = 0F;


        if (Knight.attacking() == true && enemy.isInRange == true)
        {
            enemy.eHealth -= 50;
            Knight.score += 100;
            Knight.isAttacking = false;
            Console.WriteLine(enemy.eHealth);
        }
        else Knight.isAttacking = false;
        if (enemy.eHealth == 0)
        {
            enemy.isAlive = false;
            enemy.isInRange = false;
        }
        //display.updateTime(gameTime);

        base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(_backgroundColour);


        // Draw the sprite.
        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,null,null,null,null,camera.ViewMatrix);

        myLevel.drawLevel(spriteBatch);
        Knight.knightDraw(gameTime, spriteBatch);
        enemy.enemyDraw(gameTime, spriteBatch);
        //display.DrawText(spriteBatch);
        coin.drawCoins(spriteBatch);
       
        spriteBatch.End();

        spriteBatch.Begin();

        spriteBatch.DrawString(Health, "Health: " + Knight.kHealth, new Vector2(0, 0), Color.White);
        spriteBatch.DrawString(Time, gTime.ToString(), new Vector2(334, 0), Color.White);
        spriteBatch.DrawString(Health, "Score: " + Knight.score.ToString(), new Vector2(500, 0), Color.White);

        spriteBatch.End();

        base.Draw(gameTime);
    }
}
