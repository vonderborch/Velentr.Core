using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Velentr.Debugging;

namespace Velentr.DevEnv
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private FpsTracker _frameCounter = new FpsTracker(10);
        private PerformanceTracker _performance = new PerformanceTracker(10, enableFpsTracker: true);
        private string _baseTitle = "Velentr.DevEnv";
        private string _decimals = "0.000";
        private TestCode _testCode;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this._testCode = new TestCode(this._graphics);
        }

        protected override void Initialize()
        {
            base.Initialize();
#if FNA
            var environment = "FNA";
#elif MONOGAME
            var environment = "Monogame";
#else
            var environment = "Generic";
#endif

            _baseTitle = $"{this._testCode.LIBRARY} | {environment} | FPS: {{0:{_decimals}}} | TPS: {{1:{_decimals}}} | CPU: {{2:{_decimals}}}% | Memory: {{3:{_decimals}}} MB";

            this._testCode.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            this._testCode.GraphicsDevice = GraphicsDevice;
            this._testCode.SpriteBatch = this._spriteBatch;
            this._testCode.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            _performance.Update(gameTime.ElapsedGameTime);
            this._testCode.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _frameCounter.Update(gameTime.ElapsedGameTime);
            Window.Title = string.Format(_baseTitle, _frameCounter.AverageFramesPerSecond, _performance.FpsTracker.AverageFramesPerSecond, _performance.CpuTracker.CpuPercent, _performance.MemoryTracker.MemoryUsageMb);

            this._testCode.Draw(gameTime);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
