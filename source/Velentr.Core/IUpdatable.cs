namespace Velentr.Core
{
    /// <summary>
    ///     Interface for objects that need an Update method.
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        ///     Updates the object.
        /// </summary>
        ///
        /// <param name="gameTime"> The game time. </param>
        void Update(GameTime gameTime);
    }
}
