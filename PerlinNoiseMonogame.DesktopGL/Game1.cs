using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleTiles;
using NoiseFunction;
using System;

namespace PerlinNoiseMonogame.DesktopGL
{
    public class Game1 : Game
    {
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        const int map_width = 100;
        const int map_height = 100;
        const int width = 1024;
        const int height = 800;
        const int tile_size = 128;
        const int octaveCount = 5;
        Texture2D water;
        Texture2D sand;
        Texture2D grass;
        Texture2D[] tiles;
        Texture2D[][] images;
        float zoom;

        public Game1()
        {
            zoom = 0.2f;
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = width,
                PreferredBackBufferHeight = height
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            water = Content.Load<Texture2D>("water");
            var ground = Content.Load <Texture2D>("ground");
            tiles = LoadTiles.Load(ground, 128, 128);
            sand = tiles[0];
            grass = tiles[8];
            GenerateMap();
        }

        private void GenerateMap()
        {
            PerlinNoise perlin = new PerlinNoise();
            var contrast = new CubicCurve();
            for (int x=0;x<map_width;x++)
            {
                images = new Texture2D[map_width][];

                for (int y=0;y<map_height;y++)
                {
                    var n = perlin.GetPoint(x * 0.1, y * 0.1);
                    // images[x][y] = 
                }
            }
        }

        private Texture2D ChooseTile(double noise)
        {
            switch (noise)
            {
                case double n when (n >= 0 && n <= 0.3):
                    return water;
                case double n when (n > 0.3 && n <= 0.45 ):
                    return sand;
                default:
                    return grass;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            for(int x=0; x < tilesX(); x++)
            {
                for (int y = 0; y < tilesY(); y++)
                {
                    spriteBatch.Draw(images[x][y], new Vector2(x*tile_size*zoom, y*tile_size*zoom), null, color: Color.White, 0, Vector2.Zero, scale: new Vector2(zoom, zoom), SpriteEffects.None, 0 );
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private int tilesX()
        {
            var count = Math.Ceiling( width / (tile_size * zoom)) + 1;
            return (int) Math.Min(count, map_width);
        }

        private int tilesY()
        {
            var count = Math.Ceiling(height / (tile_size * zoom)) + 1;
            return (int)Math.Min(count, map_height);
        }
    }
}
