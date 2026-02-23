using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace A4_2DAnimation;

public class Monkey
{
    private Texture2D _bodyTexture;
    private Texture2D _leftArmTexture;
    private Texture2D _rightArmTexture;
    private Texture2D _leftLegTexture;
    private Texture2D _rightLegTexture;

    private Vector2 _position;
    private Color _tint;
    private float _scale;
    private float _climbSpeed;
    private float _climbDirection = -1; // -1 = up, 1 = down
    private bool _mirrored;

    private float _armRotation;
    private float _legRotation;
    private float _horizontalSway;
    private float _elapsedTime;
    private float deltaTime;

    private float _startY;
    private float _topY;

    // Tunable animation parameters
    private float _swayAmount = 5.0f;
    private float _armSwingRange = 0.35f;
    private float _legSwingRange = 0.22f;
    private float _swingSpeed = 6.0f;

    public Monkey(
        Texture2D body,
        Texture2D leftArm,
        Texture2D rightArm,
        Texture2D leftLeg,
        Texture2D rightLeg,
        Vector2 position,
        Color tint,
        float scale,
        float climbSpeed,
        bool mirrored,
        int screenWidth,
        int screenHeight)
    {
        _bodyTexture = body;
        _leftArmTexture = leftArm;
        _rightArmTexture = rightArm;
        _leftLegTexture = leftLeg;
        _rightLegTexture = rightLeg;
        _position = position;
        _tint = tint;
        _scale = scale;
        _climbSpeed = climbSpeed;
        _mirrored = mirrored;
        _startY = position.Y;
        _topY = 50f;
    }

    public void Update(GameTime gameTime)
    {
        deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _elapsedTime += deltaTime;

        // Climb up and down (reverse direction at top and bottom)
        _position.Y += _climbDirection * _climbSpeed * deltaTime;

        if (_position.Y < _topY)
        {
            _climbDirection = 1;
        }
        else if (_position.Y > _startY)
        {
            _climbDirection = -1;
        }

        // Horizontal sway (flip direction if mirrored)
        float mirrorSign = _mirrored ? -1f : 1f;
        _horizontalSway = (float)Math.Sin(_elapsedTime * 2) * _swayAmount * mirrorSign;

        // Arms and legs swing for climbing motion
        _armRotation = (float)Math.Sin(_elapsedTime * _swingSpeed) * _armSwingRange;
        _legRotation = (float)Math.Sin(_elapsedTime * _swingSpeed) * _legSwingRange;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Matrix rootMatrix = Matrix.CreateScale(_scale) *
                            Matrix.CreateTranslation(
                                _position.X + _horizontalSway,
                                _position.Y,
                                0);

        spriteBatch.Begin(transformMatrix: rootMatrix);

        SpriteEffects bodyFlip = _mirrored ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

        // Arm pivot at top-center (shoulder)
        Vector2 armOrigin = new Vector2(55, 10);
        // Leg pivot at top-center (hip)
        Vector2 legOrigin = new Vector2(40, 10);

        // Right leg 
        Vector2 rightLegPos = new Vector2(-30f, 60f);
        spriteBatch.Draw(
            _rightLegTexture,
            rightLegPos,
            null,
            _tint,
            _legRotation,
            legOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f);

        // Left leg 
        Vector2 leftLegPos = new Vector2(30f, 60f);
        spriteBatch.Draw(
            _leftLegTexture,
            leftLegPos,
            null,
            _tint,
            -_legRotation,
            legOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f);

        // Right arm 
        Vector2 rightArmPos = new Vector2(-35f, -15f);
        spriteBatch.Draw(
            _rightArmTexture,
            rightArmPos,
            null,
            _tint,
            _armRotation,
            armOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f);

        // Left arm 
        Vector2 leftArmPos = new Vector2(55f, 15f);
        spriteBatch.Draw(
            _leftArmTexture,
            leftArmPos,
            null,
            _tint,
            -_armRotation,
            armOrigin,
            1.0f,
            SpriteEffects.None,
            0.0f);

        // Body
        Vector2 bodyOrigin = new Vector2(103, 79);
        spriteBatch.Draw(
            _bodyTexture,
            Vector2.Zero,
            null,
            _tint,
            0f,
            bodyOrigin,
            1.0f,
            bodyFlip,
            0.0f);

        spriteBatch.End();
    }
}