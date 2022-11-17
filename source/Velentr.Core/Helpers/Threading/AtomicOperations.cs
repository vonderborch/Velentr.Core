using System.Threading;

namespace Velentr.Core.Helpers.Threading
{
    /// <summary>
    ///     Various atomic actions, useful for lock-free programming.
    /// </summary>
    public static class AtomicOperations
    {
        /// <summary>
        ///     Compare and Swap.
        /// </summary>
        /// <typeparam name="T">    . </typeparam>
        /// <param name="location">     [in,out] The location. </param>
        /// <param name="newValue">     The new value. </param>
        /// <param name="comparand">    The comparand. </param>
        /// <returns>
        ///     Whether the CAS operation was a success.
        /// </returns>
        public static bool CAS<T>(ref T location, T newValue, T comparand) where T : class
        {
            return comparand == Interlocked.CompareExchange(ref location, newValue, comparand);
        }

        /// <summary>
        ///     Compare and Swap.
        /// </summary>
        /// <param name="location">     [in,out] The location. </param>
        /// <param name="newValue">     The new value. </param>
        /// <param name="comparand">    The comparand. </param>
        /// <returns>
        ///     Whether the CAS operation was a success.
        /// </returns>
        public static bool CAS(ref int location, int newValue, int comparand)
        {
            return comparand == Interlocked.CompareExchange(ref location, newValue, comparand);
        }

        /// <summary>
        ///     Compare and Swap.
        /// </summary>
        /// <param name="location">     [in,out] The location. </param>
        /// <param name="newValue">     The new value. </param>
        /// <param name="comparand">    The comparand. </param>
        /// <returns>
        ///     Whether the CAS operation was a success.
        /// </returns>
        public static bool CAS(ref long location, long newValue, long comparand)
        {
            return comparand == Interlocked.CompareExchange(ref location, newValue, comparand);
        }
    }
}
