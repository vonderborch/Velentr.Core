using System.Numerics;

namespace Velentr.Core.Mathematics;

/// <summary>
///     Provides mathematical helper methods for floating-point operations.
/// </summary>
/// <typeparam name="T">The floating-point type.</typeparam>
public static class FloatingMaths<T> where T : IFloatingPoint<T>
{
    private static readonly T TwoFiftyFive = T.CreateChecked(255);

    private static readonly T DefaultMaxDifference = T.CreateChecked(0.0001);

    /// <summary>
    ///     Determines if two floating-point numbers are approximately equal within a specified maximum difference.
    /// </summary>
    /// <param name="a">The first floating-point number.</param>
    /// <param name="b">The second floating-point number.</param>
    /// <returns>True if the numbers are approximately equal, otherwise false.</returns>
    public static bool ApproximatelyEqual(T a, T b)
    {
        return ApproximatelyEqual(a, b, DefaultMaxDifference);
    }

    /// <summary>
    ///     Determines if two floating-point numbers are approximately equal within a specified maximum difference.
    /// </summary>
    /// <param name="a">The first floating-point number.</param>
    /// <param name="b">The second floating-point number.</param>
    /// <param name="maxDifference">The maximum allowable difference between the two numbers.</param>
    /// <returns>True if the numbers are approximately equal, otherwise false.</returns>
    public static bool ApproximatelyEqual(T a, T b, T maxDifference)
    {
        T? difference = T.Abs(a - b);
        return difference <= maxDifference;
    }

    /// <summary>
    ///     Converts a byte value to a percentage represented as a floating-point number.
    /// </summary>
    /// <param name="value">The byte value to convert.</param>
    /// <returns>The percentage representation of the byte value.</returns>
    public static T ByteToPercentage(byte value)
    {
        return T.One / TwoFiftyFive * T.CreateChecked(value);
    }

    /// <summary>
    ///     Determines if a floating-point number is negative zero within a specified maximum difference.
    /// </summary>
    /// <param name="x">The floating-point number to check.</param>
    /// <returns>True if the number is negative zero, otherwise false.</returns>
    public static bool IsNegativeZero(T x)
    {
        return ApproximatelyEqual(x, T.Zero, DefaultMaxDifference) && T.IsNegativeInfinity(T.One / x);
    }

    /// <summary>
    ///     Determines if a floating-point number is negative zero within a specified maximum difference.
    /// </summary>
    /// <param name="x">The floating-point number to check.</param>
    /// <param name="maxDifference">The maximum allowable difference to consider the number as zero.</param>
    /// <returns>True if the number is negative zero, otherwise false.</returns>
    public static bool IsNegativeZero(T x, T maxDifference)
    {
        return ApproximatelyEqual(x, T.Zero, maxDifference) && T.IsNegativeInfinity(T.One / x);
    }

    /// <summary>
    ///     Converts a percentage represented as a floating-point number to a byte value.
    /// </summary>
    /// <param name="value">The percentage value to convert.</param>
    /// <returns>The byte representation of the percentage value.</returns>
    public static byte PercentageToByte(T value)
    {
        T actualValue = T.Round(value * TwoFiftyFive);
        if (actualValue >= TwoFiftyFive)
        {
            return byte.MaxValue;
        }

        if (actualValue <= T.Zero)
        {
            return byte.MinValue;
        }

        var final = byte.CreateChecked(actualValue);
        return final;
    }
}
