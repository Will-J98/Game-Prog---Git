﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    private InputHandler input;
    Single_Sprite backDrop = new Single_Sprite();
    GameLevel myLevel = new GameLevel();
    Character Knight;
    Enemy enemy;
    Camera camera = new Camera();
    GroundCollision groundCollision;
    CoinCollection coin;
    Single_Sprite flag = new Single_Sprite();
    SpriteFont Health;
    SpriteFont Time;
    SpriteFont BigText;
    int gTime = 60;
    float timer;
    bool gameOver = false;
    bool canAddScore = true;


    private Color _backgroundColour = Color.CornflowerBlue;

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
        BigText = Content.Load<SpriteFont>("Fonts/BigText");
        backDrop.LoadContent(Content, "greytile");
        backDrop.Scale = 2.0f;
        myLevel.LoadLevel(Content);
        Knight.LoadKnight(Content);
        //Knight.LoadSqaures(Content);
        coin.LoadCoins(Content);
        enemy.LoadEnemy(Content);
        //enemy.LoadSqaures(Content);

        flag.LoadContent(Content, "new flag");
        flag.Position = new Vector2(7000, 430);
        flag.Scale = 0.5f;
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

        if (Knight.BoundingBox.Intersects(flag.BoundingBox) && canAddScore == true)
        {
            Knight.score += gTime * 100;
            canAddScore = false;
            gameOver = true;
            
        }

        if(gTime == 0 || Knight.kHealth == 0)
        {
            gameOver = true;
        }
        //Console.WriteLine(Knight.knightPos().X);
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
        flag.Draw(spriteBatch);
       
        spriteBatch.End();

        spriteBatch.Begin();

        spriteBatch.DrawString(Health, "Health: " + Knight.kHealth, new Vector2(0, 0), Color.White);
        spriteBatch.DrawString(Time, gTime.ToString(), new Vector2(334, 0), Color.White);
        spriteBatch.DrawString(Health, "Score: " + Knight.score.ToString(), new Vector2(500, 0), Color.White);

        if(gameOver == true)
        {
            backDrop.Draw(spriteBatch);
            spriteBatch.DrawString(BigText, "Your final score is: " + Knight.score.ToString(), new Vector2(75,250), Color.IndianRed);
            spriteBatch.DrawString(BigText, "GameOver", new Vector2(200, 50), Color.IndianRed);
        }


        spriteBatch.End();

        base.Draw(gameTime);
    }
}
