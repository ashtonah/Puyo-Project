using System.Reflection;
using System.Runtime.ConstrainedExecution;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Puyo_Project;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;


    Texture2D PUYO_TEXTURES;

    Puyo puyo;

    const int PIXEL_WIDTH = 64;
    const int PIXEL_HEIGHT = 64;

    Vector2 pos = new Vector2(0, 0);
    Vector2 vel = new Vector2(0, 0);
    const float SPEED = 5f;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        puyo = new Puyo(PuyoColor.Red);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        PUYO_TEXTURES = Content.Load<Texture2D>("8bit_puyos");

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        KeyboardState keyState = Keyboard.GetState();

        if (keyState.IsKeyDown(Keys.Right)) {
            vel.X += SPEED;
        }
        if (keyState.IsKeyDown(Keys.Left)) {
            vel.X -= SPEED;
        }
        if (keyState.IsKeyDown(Keys.Down)) {
            vel.Y += SPEED;
        }
        if (keyState.IsKeyDown(Keys.Up)) {
            vel.Y -= SPEED;
        }

        pos += vel;
        vel.X = vel.Y = 0;


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        // TODO: Add your drawing code here
        _spriteBatch.Draw(PUYO_TEXTURES, new Rectangle((int)pos.X, (int)pos.Y, PIXEL_WIDTH, PIXEL_HEIGHT), puyo.PuyoSprite(puyo), Color.White);


        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
