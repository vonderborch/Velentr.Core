using Microsoft.Xna.Framework.Graphics;

namespace Velentr.Core;

/// <summary>
/// Represents an object that can be drawn to the screen.
/// </summary>
public interface IDrawable
{
    /// <summary>
    /// Draws the object using the specified <see cref="SpriteBatch"/>.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> used to render the object.</param>
    public void Draw(SpriteBatch spriteBatch);
}
