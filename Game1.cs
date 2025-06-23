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
    private Vector2 _playerPosition;
    private Vector2 _treePosition;
    private GameTime _oldGameTime;

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
        _playerSprite = _playSpriteFront;
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)
        )
            Exit();

        if (Keyboard.GetState().IsKeyDown(Keys.Z) || Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            _playerPosition.Y -= 5;
            _playerSprite = _playSpriteBack;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            _playerPosition.Y += 5;
            _playerSprite = _playSpriteFront;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            _playerPosition.X += 5;
            _playerSprite = _playSpriteRight;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Q) || Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            _playerPosition.X -= 5;
            _playerSprite = _playSpriteLeft;
        }

        if (
            Keyboard.GetState().IsKeyDown(Keys.Z) && Keyboard.GetState().IsKeyDown(Keys.LeftShift)
            || Keyboard.GetState().IsKeyDown(Keys.Up)
                && Keyboard.GetState().IsKeyDown(Keys.LeftShift)
        )
        {
            _playerPosition.Y -= 8;
        }
        else if (
            Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.LeftShift)
            || Keyboard.GetState().IsKeyDown(Keys.Down)
                && Keyboard.GetState().IsKeyDown(Keys.LeftShift)
        )
        {
            _playerPosition.Y += 8;
        }
        if (
            Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.LeftShift)
            || Keyboard.GetState().IsKeyDown(Keys.Right)
                && Keyboard.GetState().IsKeyDown(Keys.LeftShift)
        )
        {
            _playerPosition.X += 8;
        }
        else if (
            Keyboard.GetState().IsKeyDown(Keys.Q) && Keyboard.GetState().IsKeyDown(Keys.LeftShift)
            || Keyboard.GetState().IsKeyDown(Keys.Left)
                && Keyboard.GetState().IsKeyDown(Keys.LeftShift)
        )
        {
            _playerPosition.X -= 8;
        }

        _oldGameTime = gameTime;

        System.Diagnostics.Debug.WriteLine(gameTime.ElapsedGameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();

        System.Console.WriteLine(_playerPosition.Y);
        System.Console.WriteLine(_treePosition.Y);

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
