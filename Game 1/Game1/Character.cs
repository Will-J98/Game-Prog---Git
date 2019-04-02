using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Character
{
 
    public InputHandler input;
    public int kHealth = 100;
    public float startY, jumpspeed;
    public bool is_grounded;
    int velocityX = 10;
    const float GRAVITY = 9.0f;
    public int velocityY;
    public int score = 0;
    public bool isAttacking = false;
    Single_Sprite redsquare1 = new Single_Sprite();
    Single_Sprite redsquare2 = new Single_Sprite();
    Single_Sprite redsquare3 = new Single_Sprite();
    Single_Sprite redsquare4 = new Single_Sprite();
       
    private AnimatedSpriteStripManager myKnight = new AnimatedSpriteStripManager(10);

   //public int YVel
   // {
   //     get { return velocityY; }
   //     set { velocityY = value; }
   // }

    public int knightHealth
    {
        get { return kHealth; }
    }


    public Rectangle BoundingBox
    {
        get
        {
            return new Rectangle(
                (int)myKnight.XPos,
                (int)myKnight.YPos,
                (int)myKnight.GetBox().X,
                (int)myKnight.GetBox().Y);
        }
    }

    public Rectangle CollisionLine
    {
        get
        {
            return new Rectangle(
                (int)(myKnight.XPos),
                (int)(myKnight.YPos + myKnight.GetBox().Y),
                (int)(myKnight.GetBox().X),
                10);

        }
    }

    public void LoadSqaures(ContentManager thecontentmanager)
    {
        redsquare1.LoadContent(thecontentmanager, "RedSquare");
        redsquare1.Position = new Vector2(myKnight.XPos, myKnight.YPos);
        Console.WriteLine(redsquare1.Position);

        redsquare2.LoadContent(thecontentmanager, "RedSquare");
        redsquare2.Position = new Vector2(myKnight.XPos + myKnight.GetBox().X, myKnight.YPos);

        redsquare3.LoadContent(thecontentmanager, "RedSquare");
        redsquare3.Position = new Vector2(myKnight.XPos, myKnight.YPos + myKnight.GetBox().Y);

        redsquare4.LoadContent(thecontentmanager, "RedSquare");
        redsquare4.Position = new Vector2(myKnight.XPos + myKnight.GetBox().X, myKnight.YPos + myKnight.GetBox().Y);
    }
    public void squareUpdate()
    {
        redsquare1.Position = new Vector2(myKnight.XPos, myKnight.YPos);
        redsquare2.Position = new Vector2(myKnight.XPos + myKnight.GetBox().X, myKnight.YPos);
        redsquare3.Position = new Vector2(myKnight.XPos, myKnight.YPos + myKnight.GetBox().Y);
        redsquare4.Position = new Vector2(myKnight.XPos + myKnight.GetBox().X, myKnight.YPos + myKnight.GetBox().Y);

    }

    public Character(InputHandler _input)
    {
        input = _input;
    }

    public Vector2 knightPos()
    {
        return new Vector2(myKnight.XPos, myKnight.YPos);
    }

    public void LoadKnight(ContentManager Content)
    {

        AnimatedSpriteStrip myKnightRunning = new AnimatedSpriteStrip(Content.Load<Texture2D>("KnightRun"), 10, 0.1f, true);
        AnimatedSpriteStrip myKnightJumping = new AnimatedSpriteStrip(Content.Load<Texture2D>("KnightJump"), 10, 0.1f, true);
        AnimatedSpriteStrip myKnightIdle = new AnimatedSpriteStrip(Content.Load<Texture2D>("KnightIdle"), 10, 0.1f, true);
        AnimatedSpriteStrip myKnightAttack = new AnimatedSpriteStrip(Content.Load<Texture2D>("KnightAttack"), 9, 0.1f, true);
        myKnightRunning.setName("run");
        myKnightJumping.setName("jump");
        myKnightIdle.setName("idle");
        myKnightAttack.setName("attack");
        myKnight.addAnimatedSpriteStrip(myKnightRunning);
        myKnight.addAnimatedSpriteStrip(myKnightJumping);
        myKnight.addAnimatedSpriteStrip(myKnightIdle);
        myKnight.addAnimatedSpriteStrip(myKnightAttack);
        myKnight.XPos = 200;
        myKnight.YPos = 0;
        //knightPos.Y = myKnight.YPos;
        //knightPos.X = myKnight.XPos;
        
        startY = myKnight.YPos;
        jumpspeed = 0;
        is_grounded = true;
    }

    public void updateKnight(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (input.IsKeyDown(Keys.Left))
        {
            //Console.WriteLine("moving left");
            myKnight.setCurrentAction("run");
            myKnight.XPos -= velocityX;
            myKnight.setCurrentDirection("left");
        }else if(input.HasReleasedKey(Keys.Left))
        {
            myKnight.setCurrentAction("idle");
        }

        if (input.IsKeyDown(Keys.Right))
        {
            //Console.WriteLine("moving right");
            myKnight.setCurrentAction("run");
            myKnight.XPos += velocityX;
            //knightPos.X += 4;
            
            myKnight.setCurrentDirection("right");
        }
        else if (input.HasReleasedKey(Keys.Right))
        {
            myKnight.setCurrentAction("idle");
            Console.WriteLine(myKnight.currentActionName);
        }
        if(input.IsKeyDown(Keys.Down))
        {
            myKnight.YPos += 4;
        }
        if(input.IsKeyDown(Keys.Up))
        {
            myKnight.YPos -= 10; // required amount to get out of box
        }


        velocityY = (int)(GRAVITY * jumpspeed);
        myKnight.YPos += velocityY;
        jumpspeed = 1;

        if (input.WasKeyPressed(Keys.Space) && is_grounded == true)
        {
            myKnight.YPos -= 10;
            jumpspeed = -20;
        }
    }
    public bool attacking()
    {
        if (isAttacking == false && input.WasKeyPressed(Keys.X))
        {
            myKnight.setCurrentAction("attack");
            isAttacking = true;
            myKnight.setCurrentAction("run");
            return true;
        }
        else return false;
    }

    public void knightDraw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        myKnight.Draw(gameTime, spriteBatch);
        redsquare1.Draw(spriteBatch);
        redsquare2.Draw(spriteBatch);
        redsquare3.Draw(spriteBatch);
        redsquare4.Draw(spriteBatch);
    }

}

