namespace Velentr.Core.Mathematics.Random;

/// <summary>
/// Defines the interface for a random number generator.
/// </summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
public interface IRandomGenerator<out TSelf>
{
    /// <summary>
    /// Gets a thread-safe shared random generator instance.
    /// </summary>
    static abstract TSelf SharedRandom { get; }
}
