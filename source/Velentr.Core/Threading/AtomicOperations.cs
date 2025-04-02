using System.Numerics;

namespace Velentr.Core.Threading;

/// <summary>
/// Various atomic operations.
/// </summary>
public class AtomicOperations
{
    /// <summary>
    /// Compares and swaps the value at the reference location with the new value if the value at the reference location
    /// is equal to the expected value.
    /// </summary>
    /// <param name="valueReference">The reference location for the value we want to set to the new value.</param>
    /// <param name="newValue">The new value we want.</param>
    /// <param name="expectedValueAtValueReference">The value we expect at the reference location.</param>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <returns>True if we swapped the values, False if we did not.</returns>
    public static bool CAS<T>(ref T valueReference, T newValue, T expectedValueAtValueReference) where T : struct, INumber<T>
    {
        return expectedValueAtValueReference.Equals(Interlocked.CompareExchange(ref valueReference, newValue, expectedValueAtValueReference));
    }
}