using System.Numerics;

namespace Velentr.Core.Threading;

/// <summary>
///     Various atomic operations.
/// </summary>
public class AtomicOperations
{
    /// <summary>
    ///     Compares and swaps the value at the reference location with the new value if the value at the reference location
    ///     is equal to the expected value.
    /// </summary>
    /// <param name="valueReference">The reference location for the value we want to set to the new value.</param>
    /// <param name="newValue">The new value we want.</param>
    /// <param name="expectedValueAtValueReference">The value we expect at the reference location.</param>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <returns>True if we swapped the values, False if we did not.</returns>
    public static bool CompareAndSwap<T>(ref T valueReference, T newValue, T expectedValueAtValueReference)
    {
        T originalValue = Interlocked.CompareExchange(ref valueReference, newValue, expectedValueAtValueReference);
        return EqualityComparer<T>.Default.Equals(originalValue, expectedValueAtValueReference);
    }

    /// <summary>
    ///     Compares and swaps the value at the reference location with the new value if the value at the reference location
    ///     is equal to the expected value.
    /// </summary>
    /// <param name="valueReference">The reference location for the value we want to set to the new value.</param>
    /// <param name="newValue">The new value we want.</param>
    /// <param name="expectedValueAtValueReference">The value we expect at the reference location.</param>
    /// <param name="originalValue">The original value at the reference location before the swap.</param>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <returns>True if we swapped the values, False if we did not.</returns>
    public static bool CompareAndSwap<T>(ref T valueReference, T newValue, T expectedValueAtValueReference,
        out T originalValue)
    {
        originalValue = Interlocked.CompareExchange(ref valueReference, newValue, expectedValueAtValueReference);
        return EqualityComparer<T>.Default.Equals(originalValue, expectedValueAtValueReference);
    }

    /// <summary>
    ///     Decrement the specified variable, ensuring it does not go below the minimum value.
    /// </summary>
    /// <param name="variable">The reference to the variable to be decremented.</param>
    /// <param name="minimum">The minimum value that the variable can take.</param>
    /// <typeparam name="T">The type of the variable, which must implement INumber.</typeparam>
    /// <returns>The original value of the variable before any modification.</returns>
    public static T Decrement<T>(ref T variable, T minimum) where T : INumber<T>
    {
        while (true)
        {
            T current = variable;
            if (current == minimum)
            {
                return current;
            }

            if (current < minimum)
            {
                // If we are already above the maximum, we should increment to get back to the minimum.
                CompareAndSwap(ref variable, minimum, current);
            }
            else if (CompareAndSwap(ref variable, current - T.One, current, out T originalValue))
            {
                return originalValue;
            }
        }
    }

    /// <summary>
    ///     Atomically increments the specified variable, but stops at the given maximum value. If the current value is equal
    ///     to or greater than the maximum, the method returns the current value without modification.
    /// </summary>
    /// <param name="variable">The reference to the variable to increment.</param>
    /// <param name="maximum">
    ///     The upper bound value; if the variable exceeds this value, it is reset to the maximum and the
    ///     method returns the original value.
    /// </param>
    /// <typeparam name="T">The type of the variable, which must implement INumber.</typeparam>
    /// <returns>
    ///     The original value of the variable before the increment, or the current value if it was already at or above
    ///     the maximum.
    /// </returns>
    public static T Increment<T>(ref T variable, T maximum) where T : INumber<T>
    {
        while (true)
        {
            T current = variable;
            if (current == maximum)
            {
                return current;
            }

            if (current > maximum)
            {
                // If we are already above the maximum, we should decrement to get back to the maximum.
                CompareAndSwap(ref variable, maximum, current);
            }
            else if (CompareAndSwap(ref variable, current + T.One, current, out T originalValue))
            {
                return originalValue;
            }
        }
    }
}
