using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Enemy
{
    public int eHealth = 100;
    int xVelocity = 3;
    int direction = -1;
    private AnimatedSpriteStripManager enemy = new AnimatedSpriteStripManager(10);
    Single_Sprite redsquare1 = new Single_Sprite();
    Single_Sprite redsquare2 = new Single_Sprite();
    Single_Sprite redsquare3 = new Single_Sprite();
    Single_Sprite redsquare4 = new Single_Sprite();

    public Rectangle BoundingBox
    {
        get
        {
            return new Rectangle(
                (int)enemy.XPos,
                (int)enemy.YPos,
                (int)enemy.GetBox().X,
                (int)enemy.GetBox().Y);
        }
    }

    public Rectangle visionRect
    {
        get
        {
            return new Rectangle(
                enemy.XPos,
                enemy.YPos,
                (400 * direction),
                50);
        }
    }


    public Vector2 enemyPos()
    {
        return new Vector2(enemy.XPos, enemy.YPos);
    }

    public void LoadSqaures(ContentManager thecontentmanager)
    {
        redsquare1.LoadContent(thecontentmanager, "RedSquare");
        redsquare1.Position = new Vector2(enemy.XPos, enemy.YPos);

        redsquare2.LoadContent(thecontentmanager, "RedSquare");
        redsquare2.Position = new Vector2(enemy.XPos + 400, enemy.YPos);

        redsquare3.LoadContent(thecontentmanager, "RedSquare");
        redsquare3.Position = new Vector2(enemy.XPos, enemy.YPos + 50);

        redsquare4.LoadContent(thecontentmanager, "RedSquare");
        redsquare4.Position = new Vector2(enemy.XPos + 400, enemy.YPos + enemy.YPos + 50);
    }

    public void LoadEnemy(ContentManager content)
    {
        AnimatedSpriteStrip enemyRunning = new AnimatedSpriteStrip(content.Load<Texture2D>("KnightRun"), 10, 0.1f, true);
        AnimatedSpriteStrip enemyJumping = new AnimatedSpriteStrip(content.Load<Texture2D>("KnightJump"), 10, 0.1f, true);
        AnimatedSpriteStrip enemyIdle = new AnimatedSpriteStrip(content.Load<Texture2D>("KnightIdle"), 10, 0.1f, true);
        enemyRunning.setName("run");
        enemyJumping.setName("jump");
        enemyIdle.setName("idle");
        enemy.addAnimatedSpriteStrip(enemyRunning);
        enemy.addAnimatedSpriteStrip(enemyJumping);
        enemy.addAnimatedSpriteStrip(enemyIdle);
        enemy.XPos = 500;
        enemy.YPos = 375;
    }

    public void Update()
    {
        patrolling();
        squareUpdate();
    }
    public void squareUpdate()
    {
        redsquare1.Position = new Vector2(enemy.XPos, enemy.YPos);
        redsquare2.Position = new Vector2(enemy.XPos + (400 * direction), enemy.YPos);
        redsquare3.Position = new Vector2(enemy.XPos, enemy.YPos + 50);
        redsquare4.Position = new Vector2(enemy.XPos + (400 * direction), enemy.YPos + 50);

    }

    public void patrolling()
    {
        enemy.setCurrentAction("run");
        enemy.XPos += xVelocity * direction;
        if(enemy.XPos == 800)
        {
            enemy.setCurrentDirection("left");
            direction = -1;
            
        }
        else if (enemy.XPos == 200)
        {
            enemy.setCurrentDirection("right");
            direction = 1;
        }
    }

    public void enemyDraw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        enemy.Draw(gameTime, spriteBatch);
        redsquare1.Draw(spriteBatch);
        redsquare2.Draw(spriteBatch);
        redsquare3.Draw(spriteBatch);
        redsquare4.Draw(spriteBatch);
    }





}

