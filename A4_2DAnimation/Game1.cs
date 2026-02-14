using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace A4_2DAnimation;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _background;
    
    private Texture2D _tigerBody;
    private Texture2D _tigerFrontLeg;
    private Texture2D _tigerBackLeg;
    private Texture2D _TigerTail;
    
    private Tiger _tiger1;
    private Tiger _tiger2;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        _background = Content.Load<Texture2D>("imgs/rainforest");

        _tigerBody = Content.Load<Texture2D>("Tiger/tiger-body");
        _tigerFrontLeg = Content.Load<Texture2D>("Tiger/tiger-front-leg");
        _tigerBackLeg = Content.Load<Texture2D>("Tiger/tiger-back-leg");
        _TigerTail = Content.Load<Texture2D>("Tiger/tiger-tail");


        _tiger1 = new Tiger(
            _tigerBody,
            _tigerFrontLeg,
            _tigerBackLeg,
            _TigerTail,
            new Vector2(200, 350),
            Color.White,
            0.33f,
            2.3f,
            _graphics.PreferredBackBufferWidth,
            _graphics.PreferredBackBufferHeight);
        
        _tiger2 = new Tiger(
            _tigerBody,
            _tigerFrontLeg,
            _tigerBackLeg,
            _TigerTail,
            new Vector2(400, 325),
            Color.Orange,
            0.2f,
            -1.5f,
            _graphics.PreferredBackBufferWidth,
            _graphics.PreferredBackBufferHeight);

        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
       
        _tiger1.Update(gameTime);
        _tiger2.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        
        _spriteBatch.Draw(_background,
                        new Rectangle(0, 0,
                            _graphics.PreferredBackBufferWidth,
                            _graphics.PreferredBackBufferHeight),
                        Color.White);
        _spriteBatch.End();
        
        _tiger2.Draw(_spriteBatch);
        _tiger1.Draw(_spriteBatch);
        

        base.Draw(gameTime);
    }
}