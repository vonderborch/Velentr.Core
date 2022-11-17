using System;

namespace Velentr.Core.Helpers.General
{
    /// <summary>
    ///     Helpers used when attempting to dispose of objects.
    /// </summary>
    public static class DisposingHelpers
    {
        /// <summary>
        ///     Dispose if possible.
        /// </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="obj">  The object. </param>
        public static void DisposeIfPossible<T>(T obj)
        {
            if (obj is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
