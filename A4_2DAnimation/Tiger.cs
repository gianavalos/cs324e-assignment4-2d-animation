using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace A4_2DAnimation;

public class Tiger
{
    private Texture2D _bodyTexture;
    private Texture2D _frontLegTexture;
    private Texture2D _backLegTexture;
    private Texture2D _tailTexture;
    
    private Vector2 _position;
    private Color _tint;
    private float _scale;
    private float _walkSpeed;
    private float _walkDirection = 1;

    private float _currentScale;
    private float _legRotation;
    private  float _tailRotation;
    private float _elapsedTime;
    
    private int _screenWidth;
    private int _screenHeight;

    public Tiger(Texture2D body,
        Texture2D frontLeg,
        Texture2D backLeg,
        Texture2D tail,
        Vector2 position,
        Color tint,
        float scale,
        float walkSpeed,
        int screenWidth,
        int screenHeight)
    {
        _bodyTexture = body;
        _frontLegTexture = frontLeg;
        _backLegTexture = backLeg;
        _tailTexture = tail;
        _position = position;
        _tint = tint;
        _scale = scale;
        _walkSpeed = walkSpeed;
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;
    }

    public void Update(GameTime gameTime)
    {
        _elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        _position.X += _walkDirection * _walkSpeed;

        if (_position.X > _screenWidth - 100 || _position.X < 100)
        {
            _walkDirection *= -1;
        }
        
        _currentScale = _scale + (float)Math.Sin(_elapsedTime) * 0.05f;
        
        _legRotation = (float)Math.Sin(_elapsedTime * _walkSpeed * 5) * 0.05f;
        
        _tailRotation = (float)Math.Sin(_elapsedTime * 3) * 0.05f;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Matrix rootMatrix = Matrix.CreateScale(_currentScale) * 
                            Matrix.CreateTranslation(_position.X, _position.Y, 0);
        
        
        spriteBatch.Begin(transformMatrix: rootMatrix);
        
        Vector2 frontLeftPosition = new Vector2(10, 20);
        Vector2 legOrigin = new Vector2(_bodyTexture.Width / 2, _bodyTexture.Height / 2);
        spriteBatch.Draw(_frontLegTexture,
            frontLeftPosition,
            null,
            _tint,
            -_legRotation,
            legOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f);
        
        Vector2 backLeftPos = new Vector2(30, 20);
        Vector2 backLegOrigin = new Vector2(_bodyTexture.Width / 2, _bodyTexture.Height / 2);
        spriteBatch.Draw(_backLegTexture,
            backLeftPos,
            null,
            _tint,
            -_legRotation,
            backLegOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f);
        
        Vector2 bodyOrigin = new Vector2(_bodyTexture.Width / 2, _bodyTexture.Height / 2);
        spriteBatch.Draw(_bodyTexture,
                        Vector2.Zero,
                        null,
                        _tint,
                        0.0f,
                        bodyOrigin,
                        1.0f,
                        SpriteEffects.None,
                        0.0f);
        

        
        Vector2 frontRightPosition = new Vector2(-10, 20);
        spriteBatch.Draw(_frontLegTexture,
                        frontRightPosition,
                        null,
                        _tint,
                        -_legRotation,
                        legOrigin,
                        1.0f,
                        SpriteEffects.None,
                        0.0f);
        
        
        Vector2 backRightPos = new Vector2(0, 30);
        spriteBatch.Draw(_backLegTexture,
            backRightPos,
            null,
            _tint,
            _legRotation,
            backLegOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f);
        
        Vector2 tailPos = new Vector2(-760, 7);
        Vector2 tailOrigin = new Vector2(0, _tailTexture.Height / 2);
        spriteBatch.Draw(_tailTexture,
            tailPos,
            null,
            _tint,
            _tailRotation,
            tailOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f);
        
        spriteBatch.End();
    }
}