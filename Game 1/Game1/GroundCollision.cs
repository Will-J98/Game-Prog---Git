using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

class GroundCollision
{
    Character knight;
    GameLevel lvl;

    public GroundCollision(Character _knight, GameLevel _lvl)
    {
        knight = _knight;
        lvl = _lvl;
    }
  
    public bool is_Colliding()
    {
        if(lvl.bottomFloor.BoundingBox.Intersects(knight.BoundingBox))
        {
            knight.velocityY = 0;
            return true;
        }
        else if(lvl.bottomFloorTwo.BoundingBox.Intersects(knight.BoundingBox))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.bottomFloorThree.BoundingBox.Intersects(knight.BoundingBox))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.bottomFloorFour.BoundingBox.Intersects(knight.BoundingBox))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.bottomFloorFive.BoundingBox.Intersects(knight.BoundingBox))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.bottomFloorSix.BoundingBox.Intersects(knight.BoundingBox))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.bottomFloorSeven.BoundingBox.Intersects(knight.BoundingBox))
        {
            knight.velocityY = 0;
            return true;
        }
        else if(lvl.platformOne.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if(lvl.platformTwo.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platformThree.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platformFour.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platformFive.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platformSix.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platformSeven.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platformEight.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platformNine.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platformTen.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platformEleven.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platformTwelve.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platform13.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platform14.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        else if (lvl.platform15.TopLine.Intersects(knight.CollisionLine))
        {
            knight.velocityY = 0;
            return true;
        }
        return false;
    }

    

}
//static class RectangleHelper
//{
//    const int penMargin = 5;
//    public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
//    {
//        return (r1.Bottom >= r2.Top - penMargin &&
//            r1.Bottom <= r2.Top &&
//            r1.Right >= r2.Left + 5 &&
//            r1.Left <= r2.Right - 5);
//    }

//}


    
