using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleCityTanks
{
  public
  static class Splashscreen
  {
    public static Texture2D Background { get; set; }
    public static Texture2D Tank { get; set; }
    //   public static int Multiplication { get; set; }
    static int yPositionOfBackground = 128;
    static private int repeats = 0;
    static private int backgroundWidth;// = Background.Bounds.Width;
    static private int backgroundHeight;// = Background.Bounds.Height;
    static private bool isMove = true;
    private enum menuItems : byte
    {
      OnePlayer = 0,
      TwoPlayer = 16,
      Constructor = 32
    };
    static menuItems currentItem = menuItems.OnePlayer;
    //    static int ololo = menuItems.OnePlayer;

    public enum menuItemsChangeDirection
    {
      Up,
      Down
    }

    static private FrameOfTank currentFrame;

    static public void MeasureSizeOfTexture()
    {
      backgroundWidth = Background.Bounds.Width;
      backgroundHeight = Background.Bounds.Height;
    }
    static public void Draw(SpriteBatch spriteBatch, int multiplication)
    {
      //      spriteBatch.Draw(Background, new Vector2(0, repeats), Color.White);
      //     backgroundWidth = Background.Bounds.Width;
      //     backgroundHeight = Background.Bounds.Height;
      MeasureSizeOfTexture();
      spriteBatch.Draw(Background, new Rectangle(new Point(0, yPositionOfBackground * multiplication), new Point(backgroundWidth * multiplication, backgroundHeight * multiplication)), Color.White);
      if (isMove == false)
      {
        //        spriteBatch.Draw(Tank, new Rectangle(new Point(50, 50 + (byte)currentItem), new Point(16 * multiplication, 16 * multiplication)), Color.White);
        spriteBatch.Draw(Tank, new Rectangle(64 * multiplication, ( 122 + (byte)currentItem ) * multiplication, 16 * multiplication, 16 * multiplication), new Rectangle((int)FrameOfTank.RightFirstFrame, 0, 16, 16), Color.White);
      }
    }

    static public void Update()
    {
      repeats++;
      if (isMove == true)
      {
        if (yPositionOfBackground > 0)
        {
          yPositionOfBackground--;
        }
        else
        {
          isMove = false;
        }
        //        repeats = 0;
      }
      else
      {
        if (repeats % 50 == 0) { }
      }
    }

    static public void ChangeItem(menuItemsChangeDirection menuItemsChangeDirection)
    {
      switch (menuItemsChangeDirection)
      {
        case menuItemsChangeDirection.Up:
          switch (currentItem)
          {
            case menuItems.OnePlayer:
              currentItem = menuItems.OnePlayer;
              break;

            case menuItems.TwoPlayer:
              currentItem = menuItems.OnePlayer;
              break;

            case menuItems.Constructor:
              currentItem = menuItems.TwoPlayer;
              break;
          }
          break;

        case menuItemsChangeDirection.Down:
          switch (currentItem)
          {
            case menuItems.OnePlayer:
              currentItem = menuItems.TwoPlayer;
              break;

            case menuItems.TwoPlayer:
              currentItem = menuItems.Constructor;
              break;

            case menuItems.Constructor:
              currentItem = menuItems.Constructor;
              break;
          }
          break;
      }
    }
    static public Statement SelectItem()
    {
      Statement statement = Statement.Game;
      switch (currentItem)
      {
        case menuItems.OnePlayer:
          statement = Statement.Game;
          break;

        default:

          break;
      }
      return statement;
    }
  }
}
