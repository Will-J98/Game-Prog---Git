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
    Character knight;
    float knightDistanceX;
    float knightDistanceY;
    public bool isAlive = true;
    public bool isInRange = false;
    double attackDelay = 0;
    int distanceTrav;

    public Enemy(Character _knight)
    {
        knight = _knight;
    }

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
        AnimatedSpriteStrip enemyRunning = new AnimatedSpriteStrip(content.Load<Texture2D>("NinjaRun"), 10, 0.1f, true);
        AnimatedSpriteStrip enemyIdle = new AnimatedSpriteStrip(content.Load<Texture2D>("NinjaIdle"), 10, 0.1f, true);
        AnimatedSpriteStrip enemyAttack = new AnimatedSpriteStrip(content.Load<Texture2D>("NinjaAttack"), 9, 0.1f, true);

        enemyRunning.setName("run");
        enemyIdle.setName("idle");
        enemyAttack.setName("attack");
        enemy.addAnimatedSpriteStrip(enemyRunning);
        enemy.addAnimatedSpriteStrip(enemyIdle);
        enemy.addAnimatedSpriteStrip(enemyAttack);
        enemy.XPos = 2000;
        enemy.YPos = 420;
        xVelocity = 3;
        eHealth = 100;
    }

    public void Update(GameTime gameTime2)
    {
        if (isAlive == true)
        {
            distanceTrav = 0;
            patrolling();
            knightDistanceX = knight.knightPos().X - enemy.XPos;
            //knightDistanceY = knight.knightPos().Y - enemy.YPos;
            if (knightDistanceX >= -250 && knightDistanceX <= 250)
            {
                Console.WriteLine("Following");
                following();
            }
            else
            {
                patrolling();
                Console.WriteLine("Patrolling");
            }
            if (knightDistanceX >= -50 && knightDistanceX <= 50)
            {
                //Console.WriteLine("Attacking");
                isInRange = true;
                enemyAttacking(gameTime2);
            }
            //Console.WriteLine(distanceTrav);
        }       
        
    }

    public void patrolling()
    {
        enemy.setCurrentAction("run");
        enemy.XPos += xVelocity * direction;
        distanceTrav += 1;
        if (enemy.XPos == 800)
        {
            enemy.setCurrentDirection("right");
            direction = 1;
            //distanceTrav += 1;

        }
        else if (enemy.XPos == 1400)
        {
            enemy.setCurrentDirection("left");
            direction = -1;
            //distanceTrav -= 1;
        }
    }

    public void following()
    {
        if (knightDistanceX < -1)
        {
            enemy.setCurrentDirection("left");
            direction = -1;
        }

        else if (knightDistanceX > 1)
        {
            enemy.setCurrentDirection("right");
            direction = 1;
        }

        else if (knightDistanceX == 0)
            direction = 0;
    }

    public void enemyAttacking(GameTime gameTime)
    {
        
        //knight.kHealth -= 20;
        attackDelay += gameTime.ElapsedGameTime.TotalSeconds;
        if (attackDelay > 1.0)
        {
            enemy.setCurrentAction("attack");
            knight.kHealth -= 20;
            attackDelay = 0;
        }
    }


    public void enemyDraw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if(isAlive == true)
        {
            enemy.Draw(gameTime, spriteBatch);
        }
       
       
    }

}

