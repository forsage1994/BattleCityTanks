using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BattleCityTanks
{
  public class Game1 : Game
  {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Texture2D YellowTanks;
    const int OriginalWidth = 256, OriginalHeight = 224;
    public int CurrentWidth, CurrentHeight, Multiplication;



    public Game1()
    {
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;


    }

    protected override void Initialize()
    {
      CurrentWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
      CurrentHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

      if ((CurrentWidth / OriginalWidth) < (CurrentHeight / OriginalHeight))
        Multiplication = CurrentWidth / OriginalWidth;
      else
        Multiplication = CurrentHeight / OriginalHeight;

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
      YellowTanks = Content.Load<Texture2D>("yellow_tanks");
    }

    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();

      Splashscreen.Update();

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.Black);

      _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
      //      _spriteBatch.Draw(YellowTanks, new Rectangle(0,0,640,640), Color.White);
      Splashscreen.Draw(_spriteBatch, Multiplication);
      _spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
