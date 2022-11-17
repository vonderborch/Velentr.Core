using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Velentr.DevEnv
{
    public class TestCode
    {
        public GraphicsDevice GraphicsDevice;
        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;

        public string LIBRARY = "Velentr.Core";

        public TestCode(GraphicsDeviceManager graphics)
        {
            Graphics = graphics;

            // Class initialization code goes here
        }

        public void Initialize()
        {
            // Initialization code goes here
        }
        public void LoadContent()
        {
            // LoadContent code goes here
        }
        public void Update(GameTime gameTime)
        {
            // Update code goes here
        }
        public void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw code goes here
        }
    }
}
