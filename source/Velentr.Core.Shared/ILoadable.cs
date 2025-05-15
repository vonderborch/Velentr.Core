using Microsoft.Xna.Framework.Content;

namespace Velentr.Core;

/// <summary>
///     Represents an object that can load and unload resources.
/// </summary>
public interface ILoadable
{
    /// <summary>
    ///     Loads the necessary resources using the specified <see cref="ContentManager" />.
    /// </summary>
    /// <param name="content">The <see cref="ContentManager" /> used to load resources.</param>
    void Load(ContentManager content);

    /// <summary>
    ///     Unloads the resources, releasing any associated memory or handles.
    /// </summary>
    void Unload();
}
