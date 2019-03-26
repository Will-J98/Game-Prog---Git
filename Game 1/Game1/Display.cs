using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

class Display
{
    SpriteFont Health;
    SpriteFont Time;
    int gTime = 60;
    
    public void LoadText(ContentManager content)
    {
        //Health = content.Load<SpriteFont>("Fonts/Health1");
        Time = content.Load<SpriteFont>("Fonts/Time");
    }

    public int updateTime(GameTime gameTime)
    {
        gTime -= gameTime.ElapsedGameTime.Seconds;
        Console.WriteLine(gTime);
        return gTime;
    }
    public void DrawText(SpriteBatch spriteBatch)
    {
        //spriteBatch.DrawString(Health, "Health: 100", new Vector2(0, 0), Color.White);
        spriteBatch.DrawString(Time, gTime.ToString(), new Vector2(334, 0), Color.White);
    }
}


