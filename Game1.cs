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
    private Texture2D _spriteGrass;
    private Texture2D _spritePlante1;
    private Vector2 _playerPosition;
    private Vector2 _treePosition;
    private KeyboardState _previousKeyboardState;
    private int[,] _tableau = new int[25, 25]
    {
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
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
        _spritePelouse = Content.Load<Texture2D>("sprite-pel");
        _spriteGrass = Content.Load<Texture2D>("sprite-grass");
        _spritePlante1 = Content.Load<Texture2D>("sprite-plante1");
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

        int x = (int)_playerPosition.X / 32;
        int y = (int)_playerPosition.Y / 32;

        if (keyboardState.IsKeyDown(Keys.E) && !_previousKeyboardState.IsKeyDown(Keys.E))
        {
            if (x >= 0 && x < _tableau.GetLength(1) && y >= 0 && y < _tableau.GetLength(0))
            {
                if (_tableau[y, x] == 1)
                {
                    _tableau[y, x] = 0;
                }
                else if (_tableau[y, x] == 0)
                {
                    _tableau[y, x] = 2;
                }
                else if (_tableau[y, x] == 2)
                {
                    _tableau[y, x] = 1;
                }
            }
        }

        // Enregistre l’état du clavier pour la frame suivante
        _previousKeyboardState = keyboardState;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Green);
        _spriteBatch.Begin();

        for (int y = 0; y < _tableau.GetLength(0); y++)
        {
            for (int x = 0; x < _tableau.GetLength(1); x++)
            {
                int valeur = _tableau[y, x];

                if (valeur == 0)
                {
                    _spriteBatch.Draw(_spriteGrass, new Vector2(x * 32, y * 32), Color.White);
                }
                else if (valeur == 1)
                {
                    _spriteBatch.Draw(_spritePelouse, new Vector2(x * 32, y * 32), Color.White);
                }
                else if (valeur == 2)
                {
                    _spriteBatch.Draw(_spriteGrass, new Vector2(x * 32, y * 32), Color.White);
                    _spriteBatch.Draw(_spritePlante1, new Vector2(x * 32, y * 32), Color.White);
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
                new Vector2(2f, 2f),
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
                new Vector2(2f, 2f),
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
                new Vector2(2f, 2f),
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
                new Vector2(2f, 2f),
                SpriteEffects.None,
                0f
            );
        }
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
