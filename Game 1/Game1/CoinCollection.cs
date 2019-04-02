using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class CoinCollection
{
    Single_Sprite coins = new Single_Sprite();
    Character knight;
    int i;
    //public Vector2 coinPosition = new Vector2();
    Random r = new Random();

    public List<Single_Sprite> coinList = new List<Single_Sprite>();

    public void LoadCoins(ContentManager content)
    {
        

        //coins.LoadContent(content, "Idle");
        //coins.Position = new Vector2(500, 300);
        for (i = 0; i < 11; i++)
        {
            coinList.Add(new Single_Sprite());
            coinList[i].LoadContent(content, "coin");
            coinList[i].Scale = 0.35f;
            int xCoin = r.Next(0, 500);
            //if(coinList.Count() == 1)
            //{
            //    coinList[i].Position = new Vector2(300, 300);
            //}
            //else
            //{
            //    int xCoin = r.Next((int)coinList[i-1].Position.X, (int)coinList[i - 1].Position.X + 200);
            //    int yCoin = r.Next(0, 500);
            //    coinList[i].Position = new Vector2(xCoin, yCoin);
            //}

            
            coinList[i].Position = new Vector2(xCoin, 300);
            Console.WriteLine("coin number " + i + " at position " + coinList[i].Position);  
        }

        //Console.WriteLine("Coin 0" + coinList[0].Position);
        coinList[10].Position = new Vector2(700, 175);
        coinList[0].Position = new Vector2(5000, 300);
    }

    public CoinCollection(Character _knight)
    {
        knight = _knight;
    }

    public void drawCoins(SpriteBatch spriteBatch)
    {
        coinList[i -1].Draw(spriteBatch);
    }

    public void coinPickup()
    {
        if(coinList[i-1].BoundingBox.Intersects(knight.BoundingBox))
        {
            knight.score += 100;
            coinList.RemoveAt(i-1);
            i--;
        }
    }
}

