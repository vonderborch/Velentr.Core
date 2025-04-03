namespace Velentr.Core.General;

/// <summary>
///     Provides helper methods for disposing objects.
/// </summary>
public static class DisposingHelpers
{
    /// <summary>
    ///     Disposes the specified object if it implements <see cref="IDisposable" />.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to dispose.</param>
    public static void DisposeIfPossible<T>(T obj)
    {
        var disposable = obj as IDisposable;
        disposable?.Dispose();
    }


    /// <summary>
    ///     Disposes the specified object if it implements <see cref="IDisposable" />.
    /// </summary>
    /// <param name="obj">The object to dispose.</param>
    public static void DisposeIfPossible(this object obj)
    {
        var disposable = obj as IDisposable;
        disposable?.Dispose();
    }
}
