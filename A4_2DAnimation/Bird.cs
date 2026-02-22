using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace A4_2DAnimation;

public class Bird
{
    private Texture2D _bodyTexture;
    private Texture2D _frontWingTexture;
    private Texture2D _backWingTexture;

    private Vector2 _position;
    private Color _tint;
    private float _scale;
    private float _flySpeed;
    private float _flyDirection = 1;
    
    private float _bankAngle; // tilt of whole bird
    private float _wingRotation; // flap angle
    private float _verticalOffset; // bobbing
    private float _elapsedTime;
    
    private int _screenWidth;
    private float deltaTime;

    private float _bobbingAmount = 10.0f;
    private float _bankAmount = 0.5f;
    private float _flapRange = 0.1f;

    public Bird(
        Texture2D body,
        Texture2D frontWing,
        Texture2D backWing,
        Vector2 position,
        Color tint,
        float scale,
        float flySpeed,
        int screenWidth,
        int screenHeight)
    {
        _bodyTexture = body;
        _frontWingTexture = frontWing;
        _backWingTexture = backWing;
        _position = position;
        _tint = tint;
        _scale = scale;
        _flySpeed = flySpeed;
        _screenWidth = screenWidth;
    }

    public void Update(GameTime gameTime)
    {
        deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _elapsedTime += deltaTime;

        if (_position.X > _screenWidth - 100 || _position.X < 100)
        {
            _flyDirection *= -1;
        }
        
        // fly horizontally
        _position.X += _flyDirection * _flySpeed * deltaTime;
        // bobbing
        _verticalOffset = (float)Math.Sin(_elapsedTime * 2) * _bobbingAmount;
        // banking
        _bankAngle = (float)Math.Cos(_elapsedTime * 2) * _bankAmount;
        // flapping
        _wingRotation = (float)Math.Sin(_elapsedTime * 10) * _flapRange;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Matrix rootMatrix = Matrix.CreateScale(_scale) *
                            Matrix.CreateRotationZ(_bankAngle) *
                            Matrix.CreateTranslation(_position.X,
                                _position.Y + _verticalOffset, 0);
        
        spriteBatch.Begin(transformMatrix: rootMatrix);
        Vector2 wingOrigin = new Vector2(0, _frontWingTexture.Height / 2);
        
        // Draw Back Wing
        Vector2 backWingPosition = new Vector2(-50f, 20f);
        spriteBatch.Draw(
            _backWingTexture,
            backWingPosition,
            null,
            _tint,
            _wingRotation,
            wingOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f);
        
        // Draw body
        Vector2 bodyOrigin = new Vector2(_bodyTexture.Width / 2, _bodyTexture.Height / 2);
        spriteBatch.Draw(
            _bodyTexture,
            Vector2.Zero,
            null,
            _tint,
            0f,
            bodyOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f);
        
        // Draw Front Wing
        Vector2 frontWingPosition = new Vector2(-100f, -50f);
        spriteBatch.Draw(
            _frontWingTexture,
            frontWingPosition,
            null,
            _tint,
            -_wingRotation,
            wingOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f);
        
        spriteBatch.End();
    }
}