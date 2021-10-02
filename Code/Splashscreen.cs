using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleCityTanks
{
  public 
  static class Splashscreen
  {
    public static Texture2D Background { get; set; }
    //   public static int Multiplication { get; set; }
    static int yPositionOfBackground = 128;
//    static private int repeats = 0;
    static private int backgroundWidth;// = Background.Bounds.Width;
    static private int backgroundHeight;// = Background.Bounds.Height;
    static private bool isMove = true;

    static public void MeasureSizeOfTexture()
    {
      backgroundWidth = Background.Bounds.Width;
      backgroundHeight = Background.Bounds.Height;
    }
    static public void Draw(SpriteBatch spriteBatch, int multiplication)
    {
      //      spriteBatch.Draw(Background, new Vector2(0, repeats), Color.White);
      backgroundWidth = Background.Bounds.Width;
      backgroundHeight = Background.Bounds.Height;
      spriteBatch.Draw(Background, new Rectangle(new Point(0, yPositionOfBackground * multiplication), new Point(backgroundWidth * multiplication, backgroundHeight * multiplication)), Color.White);
    }

    static public void Update()
    {
      if (isMove == true)
      {
        if (yPositionOfBackground > 0)
        {
          yPositionOfBackground--;
        } else
        {
          isMove = false;
        }
//        repeats = 0;
      } else
      {
        
      }
    }
  }
}
