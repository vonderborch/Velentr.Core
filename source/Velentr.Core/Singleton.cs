namespace Velentr.Core;

/// <summary>
/// Interface for defining a singleton pattern in a generic manner.
/// Implementing types must provide a static instance of themselves.
/// </summary>
/// <typeparam name="TSelf">The type of the singleton instance.</typeparam>
public interface ISingleton<out TSelf> where TSelf : ISingleton<TSelf>
{
    /// <summary>
    /// Provides access to the singleton instance of the class.
    /// </summary>
    TSelf SingletonInstance { get; }
}

/// <summary>
/// Abstract base class for implementing the singleton pattern in a generic manner.
/// Provides a static Instance property to access the single instance of the derived type.
/// </summary>
/// <typeparam name="TSelf">The type of the singleton instance.</typeparam>
public abstract class Singleton<TSelf> where TSelf : Singleton<TSelf>
{
    private static readonly Lazy<TSelf> Lazy = new(() => (Activator.CreateInstance(typeof(TSelf), true) as TSelf)!);

    /// <summary>
    /// Provides access to the singleton instance of the class.
    /// </summary>
    /// <returns>The singleton instance.</returns>
    public static TSelf Instance => Lazy.Value;
}
