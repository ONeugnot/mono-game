using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace mono_game;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _playSpriteFront;
    private Texture2D _playSpriteBack;
    private Texture2D _playSpriteLeft;
    private Texture2D _playSpriteRight;
    private Texture2D _playSpriteTree;
    private Texture2D _playerSprite;
    private Texture2D _spritePelouse;
    private Vector2 _playerPosition;
    private Vector2 _treePosition;
    private uint[,] _tableau =
    {
        { 0, 1, 0, 0, 1 },
        { 1, 1, 0, 0, 1 },
    };

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _playerPosition = new Vector2(
            _graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight / 2
        );

        _treePosition = new Vector2(
            _graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight / 2
        );

        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _playSpriteFront = Content.Load<Texture2D>("sprite-face");
        _playSpriteBack = Content.Load<Texture2D>("sprite-back");
        _playSpriteLeft = Content.Load<Texture2D>("sprite-left-profil");
        _playSpriteRight = Content.Load<Texture2D>("sprite-right-profil");
        _playSpriteTree = Content.Load<Texture2D>("sprite-trees");
        _spritePelouse = Content.Load<Texture2D>("sprite-pelouse");
        _playerSprite = _playSpriteFront;
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();

        float speed = 5f;

        if (keyboardState.IsKeyDown(Keys.LeftShift))
        {
            speed = 7f;
        }

        if (keyboardState.IsKeyDown(Keys.Z) || keyboardState.IsKeyDown(Keys.Up))
        {
            _playerPosition.Y -= speed;
            _playerSprite = _playSpriteBack;
        }
        else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
        {
            _playerPosition.Y += speed;
            _playerSprite = _playSpriteFront;
        }

        if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
        {
            _playerPosition.X += speed;
            _playerSprite = _playSpriteRight;
        }
        else if (keyboardState.IsKeyDown(Keys.Q) || keyboardState.IsKeyDown(Keys.Left))
        {
            _playerPosition.X -= speed;
            _playerSprite = _playSpriteLeft;
        }
        int screenWidth = _graphics.PreferredBackBufferWidth;
        int screenHeight = _graphics.PreferredBackBufferHeight;

        float spriteWidth = _playerSprite.Width * 2;
        float spriteHeight = _playerSprite.Height * 2;

        _playerPosition.X = MathHelper.Clamp(
            _playerPosition.X,
            spriteWidth / 2,
            screenWidth - spriteWidth / 2
        );
        _playerPosition.Y = MathHelper.Clamp(
            _playerPosition.Y,
            spriteHeight / 2,
            screenHeight - spriteHeight / 2
        );

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Green);
        _spriteBatch.Begin();
        for (uint y = 0; y < _tableau.GetLength(0); y++)
        {
            for (uint j = 0; j < _tableau.GetLength(1); j++)
            {
                if (_tableau[y, j] == 0)
                {
                    _spriteBatch.Draw(_spritePelouse, new Vector2(j * 32, y * 32));
                }
            }
        }

        if (
            _playerPosition.Y + _playerSprite.Height / 2
            >= _treePosition.Y + _playSpriteTree.Height / 2
        )
        {
            _spriteBatch.Draw(
                _playSpriteTree,
                _treePosition,
                null,
                Color.White,
                0f,
                new Vector2(_playSpriteTree.Width / 2, _playSpriteTree.Height / 2),
                Vector2.Multiply(Vector2.One, 2f),
                SpriteEffects.None,
                0f
            );
            _spriteBatch.Draw(
                _playerSprite,
                _playerPosition,
                null,
                Color.White,
                0f,
                new Vector2(_playerSprite.Width / 2, _playerSprite.Height / 2),
                Vector2.Multiply(Vector2.One, 2f),
                SpriteEffects.None,
                0f
            );
        }
        else
        {
            _spriteBatch.Draw(
                _playerSprite,
                _playerPosition,
                null,
                Color.White,
                0f,
                new Vector2(_playerSprite.Width / 2, _playerSprite.Height / 2),
                Vector2.Multiply(Vector2.One, 2f),
                SpriteEffects.None,
                0f
            );
            _spriteBatch.Draw(
                _playSpriteTree,
                _treePosition,
                null,
                Color.White,
                0f,
                new Vector2(_playSpriteTree.Width / 2, _playSpriteTree.Height / 2),
                Vector2.Multiply(Vector2.One, 2f),
                SpriteEffects.None,
                0f
            );
        }
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
