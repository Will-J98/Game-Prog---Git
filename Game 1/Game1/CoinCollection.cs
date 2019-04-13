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

            
            coinList[i].Position = new Vector2(xCoin, 300);
            Console.WriteLine("coin number " + i + " at position " + coinList[i].Position);  
        }

        //Console.WriteLine("Coin 0" + coinList[0].Position);
        coinList[10].Position = new Vector2(450, 300);
        coinList[9].Position = new Vector2(1650, 325);
        coinList[8].Position = new Vector2(2450, 300);
        coinList[7].Position = new Vector2(3200, 200);
        coinList[6].Position = new Vector2(4000, 108);
        coinList[5].Position = new Vector2(4950, 225);
        coinList[4].Position = new Vector2(5400, 200);
        coinList[3].Position = new Vector2(6400, 175);
        coinList[2].Position = new Vector2(5800, 400);
        coinList[1].Position = new Vector2(6900, 400);
        coinList[0].Position = new Vector2(10000,500);
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

