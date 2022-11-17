namespace Velentr.Core
{
    /// <summary>
    ///     Interface for objects that need an Draw method.
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        ///     Draws the object.
        /// </summary>
        ///
        /// <param name="gameTime"> The game time. </param>
        void Draw(GameTime gameTime);
    }
}
