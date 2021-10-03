using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace BattleCityTanks
{
  public enum Statement
  {
    Splashscreen,
    Game,
    GameOver,
    Pause
  }
  public enum Direction : byte
  {
    Up,
    Down,
    Left,
    Right
  }
  public enum FrameOfTank : byte
  {
    UpFirstFrame = 0,
    UpSecondFrame = 16,
    LeftFirstFrame = 32,
    LeftSecondFrame = 48,
    DownFirstFrame = 64,
    DownSecondFrame = 80,
    RightFirstFrame = 96,
    RightSecondFrame = 112
  }
  public enum TypeOfTank : byte
  {
    TypeOne = 0,
    TypeTwo = 16,
    TypeThree = 32,
    TypeFour = 48,
    TypeFive = 64,
    TypeSix = 80,
    TypeSeven = 96,
    TypeEight = 112
  }
  public class Game1 : Game
  {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Texture2D YellowTanks;
    const int OriginalWidth = 256, OriginalHeight = 224;
    public int CurrentWidth, CurrentHeight, Multiplication;
    public Statement statement = Statement.Splashscreen;



    public Game1()
    {
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;

      CurrentWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
      CurrentHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
      Debug.WriteLine(CurrentWidth.ToString() + "x" + CurrentHeight.ToString());

      if ((CurrentWidth / OriginalWidth) < (CurrentHeight / OriginalHeight))
        Multiplication = CurrentWidth / OriginalWidth;
      else
        Multiplication = CurrentHeight / OriginalHeight;

      
    }

    protected override void Initialize()
    {

      _graphics.PreferredBackBufferWidth = OriginalWidth * Multiplication;
      _graphics.PreferredBackBufferHeight = OriginalHeight * Multiplication;
      _graphics.IsFullScreen = false;
      _graphics.ApplyChanges();
      base.Initialize();
    }

    protected override void LoadContent()
    {
      _spriteBatch = new SpriteBatch(GraphicsDevice);
      Splashscreen.Background = Content.Load<Texture2D>("splashscreen");
      Splashscreen.Tank = Content.Load<Texture2D>("yellow_tanks");
      YellowTanks = Content.Load<Texture2D>("yellow_tanks");
    }

    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();

      switch (statement)
      {
        case Statement.Splashscreen:

          if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Up))
          {
            Splashscreen.ChangeItem(Splashscreen.menuItemsChangeDirection.Up);
          }

          if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Down))
          {
            Splashscreen.ChangeItem(Splashscreen.menuItemsChangeDirection.Down);
          }

          if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter))
          {
            statement = Splashscreen.SelectItem();
          }

          break;

        case Statement.Game:

          break;

        case Statement.GameOver:

          break;

        case Statement.Pause:

          break;
      }
      Splashscreen.Update();

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.Black);

      _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

      switch (statement)
      {
        case Statement.Splashscreen:
          Splashscreen.Draw(_spriteBatch, Multiplication);
          break;

        case Statement.Game:

          break;

        case Statement.GameOver:

          break;

        case Statement.Pause:

          break;
      }

      _spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
