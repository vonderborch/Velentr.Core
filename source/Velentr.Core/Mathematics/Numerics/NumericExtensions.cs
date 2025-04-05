using System.Numerics;

namespace Velentr.Core.Mathematics.Numerics;

/// <summary>
///     Provides extension methods for converting between <see cref="BoundedNumber{T}" /> and
///     <see cref="CircularBoundedNumber{T}" />.
/// </summary>
public static class NumericExtensions
{
    /// <summary>
    ///     Converts a <see cref="CircularBoundedNumber{T}" /> to a <see cref="BoundedNumber{T}" />.
    /// </summary>
    /// <typeparam name="T">The type of the number, which must implement <see cref="INumber{T}" />.</typeparam>
    /// <param name="number">The circular bounded number to convert.</param>
    /// <returns>
    ///     A new <see cref="BoundedNumber{T}" /> instance with the same value, minimum, and maximum as the original
    ///     circular bounded number.
    /// </returns>
    public static BoundedNumber<T> ToBoundedNumber<T>(this CircularBoundedNumber<T> number) where T : INumber<T>
    {
        return new BoundedNumber<T>(number.Value, number.Minimum, number.Maximum);
    }

    /// <summary>
    ///     Converts a <see cref="BoundedNumber{T}" /> to a <see cref="CircularBoundedNumber{T}" />.
    /// </summary>
    /// <typeparam name="T">The type of the number, which must implement <see cref="INumber{TSelf}" />.</typeparam>
    /// <param name="number">The bounded number to convert.</param>
    /// <returns>
    ///     A new <see cref="CircularBoundedNumber{T}" /> instance with the same value, minimum, and maximum as the
    ///     original bounded number.
    /// </returns>
    public static CircularBoundedNumber<T> ToCircularBoundedNumber<T>(this BoundedNumber<T> number) where T : INumber<T>
    {
        return new CircularBoundedNumber<T>(number.Value, number.Minimum, number.Maximum);
    }
}
