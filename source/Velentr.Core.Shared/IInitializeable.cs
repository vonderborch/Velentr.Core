namespace Velentr.Core;

/// <summary>
///     Represents an object that can be initialized and uninitialized.
/// </summary>
public interface IInitializeable
{
    /// <summary>
    ///     Initializes the object, preparing it for use.
    /// </summary>
    void Initialize();

    /// <summary>
    ///     Uninitializes the object, releasing any resources or resetting its state.
    /// </summary>
    void Uninitialize();
}
