using Microsoft.Xna.Framework;

namespace Velentr.Core;

/// <summary>
/// Represents an object that can be updated over time.
/// </summary>
public interface IUpdateable
{
    /// <summary>
    /// Updates the object using the specified <see cref="GameTime"/>.
    /// </summary>
    /// <param name="gameTime">The <see cref="GameTime"/> containing the elapsed time since the last update.</param>
    void Update(GameTime gameTime);
}
