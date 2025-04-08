namespace Velentr.Core.Mathematics.FixedPoint;

/// <summary>
///     Provides a set of static methods for performing mathematical operations on fixed-point numbers.
/// </summary>
/// <typeparam name="T">
///     The type of the fixed-point number, which must implement the <see cref="IFixedPoint{T}" />
///     interface.
/// </typeparam>
public static class FixedPointMath<T> where T : struct, IFixedPoint<T>
{
    /// <summary>
    ///     Returns the absolute value of a fixed-point number.
    /// </summary>
    /// <param name="value">The fixed-point number.</param>
    /// <returns>The absolute value of the fixed-point number.</returns>
    public static T Abs(T value)
    {
        return T.Abs(value);
    }

    /// <summary>
    ///     Returns the angle whose cosine is the specified number.
    /// </summary>
    /// <param name="value">A number representing a cosine, where -1 ≤ value ≤ 1.</param>
    /// <returns>An angle, measured in radians, whose cosine is the specified number.</returns>
    public static T Acos(T value)
    {
        return T.CreateFromDouble(Math.Acos(value.ToDouble()));
    }

    /// <summary>
    ///     Adds two fixed-point numbers.
    /// </summary>
    /// <param name="left">The first fixed-point number.</param>
    /// <param name="right">The second fixed-point number.</param>
    /// <returns>The sum of the two fixed-point numbers.</returns>
    public static T Add(T left, T right)
    {
        return left + right;
    }

    /// <summary>
    ///     Returns the angle whose sine is the specified number.
    /// </summary>
    /// <param name="value">A number representing a sine, where -1 ≤ value ≤ 1.</param>
    /// <returns>An angle, measured in radians, whose sine is the specified number.</returns>
    public static T Asin(T value)
    {
        return T.CreateFromDouble(Math.Asin(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the angle whose tangent is the specified number.
    /// </summary>
    /// <param name="value">A number representing a tangent.</param>
    /// <returns>An angle, measured in radians, whose tangent is the specified number.</returns>
    public static T Atan(T value)
    {
        return T.CreateFromDouble(Math.Atan(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the angle whose tangent is the quotient of two specified numbers.
    /// </summary>
    /// <param name="y">The y coordinate of a point.</param>
    /// <param name="x">The x coordinate of a point.</param>
    /// <returns>An angle, measured in radians, whose tangent is the quotient of y and x.</returns>
    public static T Atan2(T y, T x)
    {
        return T.CreateFromDouble(Math.Atan2(y.ToDouble(), x.ToDouble()));
    }

    /// <summary>
    ///     Rounds a fixed-point number up to the nearest integer.
    /// </summary>
    /// <param name="value">The fixed-point number to round up.</param>
    /// <returns>The smallest integer greater than or equal to the specified fixed-point number.</returns>
    public static T Ceiling(T value)
    {
        return T.CreateFromDouble(Math.Ceiling(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the cosine of the specified angle.
    /// </summary>
    /// <param name="value">An angle, measured in radians.</param>
    /// <returns>The cosine of the specified angle.</returns>
    public static T Cos(T value)
    {
        return T.CreateFromDouble(Math.Cos(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the hyperbolic cosine of the specified angle.
    /// </summary>
    /// <param name="value">An angle, measured in radians.</param>
    /// <returns>The hyperbolic cosine of the specified angle.</returns>
    public static T Cosh(T value)
    {
        return T.CreateFromDouble(Math.Cosh(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the value of the specified fixed-point number raised to the power of 3.
    /// </summary>
    /// <param name="value">The fixed-point number to be cubed.</param>
    /// <returns>The value of the specified fixed-point number raised to the power of 3.</returns>
    public static T Cube(T value)
    {
        return value * value * value;
    }

    /// <summary>
    ///     Divides the first fixed-point number by the second.
    /// </summary>
    /// <param name="left">The first fixed-point number.</param>
    /// <param name="right">The second fixed-point number.</param>
    /// <returns>The quotient of the two fixed-point numbers.</returns>
    public static T Divide(T left, T right)
    {
        return left / right;
    }

    /// <summary>
    ///     Returns e raised to the specified power.
    /// </summary>
    /// <param name="value">A fixed-point number specifying a power.</param>
    /// <returns>e raised to the power of the specified fixed-point number.</returns>
    public static T Exp(T value)
    {
        return T.CreateFromDouble(Math.Exp(value.ToDouble()));
    }

    /// <summary>
    ///     Rounds a fixed-point number down to the nearest integer.
    /// </summary>
    /// <param name="value">The fixed-point number to round down.</param>
    /// <returns>The largest integer less than or equal to the specified fixed-point number.</returns>
    public static T Floor(T value)
    {
        return T.CreateFromDouble(Math.Floor(value.ToDouble()));
    }

    /// <summary>
    ///     Determines whether the specified fixed-point number is negative.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is negative; otherwise, false.</returns>
    public static bool IsNegative(T value)
    {
        return T.IsNegative(value);
    }

    /// <summary>
    ///     Determines whether the specified fixed-point number is positive.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is positive; otherwise, false.</returns>
    public static bool IsPositive(T value)
    {
        return T.IsPositive(value);
    }

    /// <summary>
    ///     Determines whether the specified fixed-point number is zero.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is zero; otherwise, false.</returns>
    public static bool IsZero(T value)
    {
        return T.IsZero(value);
    }

    /// <summary>
    ///     Returns the natural (base e) logarithm of a specified fixed-point number.
    /// </summary>
    /// <param name="value">The fixed-point number whose logarithm is to be found.</param>
    /// <returns>The natural logarithm of the specified fixed-point number.</returns>
    public static T Log(T value)
    {
        return T.CreateFromDouble(Math.Log(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the logarithm of a specified fixed-point number in a specified base.
    /// </summary>
    /// <param name="value">The fixed-point number whose logarithm is to be found.</param>
    /// <param name="baseValue">The base of the logarithm.</param>
    /// <returns>The logarithm of the specified fixed-point number in the specified base.</returns>
    public static T Log(T value, T baseValue)
    {
        return T.CreateFromDouble(Math.Log(value.ToDouble(), baseValue.ToDouble()));
    }

    /// <summary>
    ///     Returns the base 10 logarithm of a specified fixed-point number.
    /// </summary>
    /// <param name="value">The fixed-point number whose logarithm is to be found.</param>
    /// <returns>The base 10 logarithm of the specified fixed-point number.</returns>
    public static T Log10(T value)
    {
        return T.CreateFromDouble(Math.Log10(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the natural logarithm of one plus a specified fixed-point number.
    /// </summary>
    /// <param name="value">The fixed-point number whose logarithm is to be found.</param>
    /// <returns>The natural logarithm of 1 plus the specified fixed-point number.</returns>
    public static T Log1p(T value)
    {
        return T.CreateFromDouble(Math.Log(1) + value.ToDouble());
    }

    /// <summary>
    ///     Returns the base 2 logarithm of a specified fixed-point number.
    /// </summary>
    /// <param name="value">The fixed-point number whose logarithm is to be found.</param>
    /// <returns>The base 2 logarithm of the specified fixed-point number.</returns>
    public static T Log2(T value)
    {
        return T.CreateFromDouble(Math.Log2(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the larger of two fixed-point numbers.
    /// </summary>
    /// <param name="x">The first fixed-point number.</param>
    /// <param name="y">The second fixed-point number.</param>
    /// <returns>The larger of the two fixed-point numbers.</returns>
    public static T Max(T x, T y)
    {
        return x > y ? x : y;
    }

    /// <summary>
    ///     Returns the maximum value from a set of fixed-point numbers.
    /// </summary>
    /// <param name="values">The set of fixed-point numbers.</param>
    /// <returns>The maximum value from the set of fixed-point numbers.</returns>
    public static T Maximum(params T[] values)
    {
        T max = values[0];
        for (var i = 1; i < values.Length; i++)
        {
            if (values[i] > max)
            {
                max = values[i];
            }
        }

        return max;
    }

    /// <summary>
    ///     Compares two fixed-point numbers and returns the larger magnitude.
    /// </summary>
    /// <param name="x">The first fixed-point number.</param>
    /// <param name="y">The second fixed-point number.</param>
    /// <returns>The fixed-point number with the larger magnitude.</returns>
    public static T MaxMagnitude(T x, T y)
    {
        return T.MaxMagnitude(x, y);
    }

    /// <summary>
    ///     Returns the smaller of two fixed-point numbers.
    /// </summary>
    /// <param name="x">The first fixed-point number.</param>
    /// <param name="y">The second fixed-point number.</param>
    /// <returns>The smaller of the two fixed-point numbers.</returns>
    public static T Min(T x, T y)
    {
        return x < y ? x : y;
    }

    /// <summary>
    ///     Returns the minimum value from a set of fixed-point numbers.
    /// </summary>
    /// <param name="values">The set of fixed-point numbers.</param>
    /// <returns>The minimum value from the set of fixed-point numbers.</returns>
    public static T Minimum(params T[] values)
    {
        T min = values[0];
        for (var i = 1; i < values.Length; i++)
        {
            if (values[i] < min)
            {
                min = values[i];
            }
        }

        return min;
    }

    /// <summary>
    ///     Compares two fixed-point numbers and returns the smaller magnitude.
    /// </summary>
    /// <param name="x">The first fixed-point number.</param>
    /// <param name="y">The second fixed-point number.</param>
    /// <returns>The fixed-point number with the smaller magnitude.</returns>
    public static T MinMagnitude(T x, T y)
    {
        return T.MinMagnitude(x, y);
    }

    /// <summary>
    ///     Multiplies two fixed-point numbers.
    /// </summary>
    /// <param name="left">The first fixed-point number.</param>
    /// <param name="right">The second fixed-point number.</param>
    /// <returns>The product of the two fixed-point numbers.</returns>
    public static T Multiply(T left, T right)
    {
        return left * right;
    }

    /// <summary>
    ///     Returns a specified fixed-point number raised to the specified power.
    /// </summary>
    /// <param name="value">The fixed-point number to be raised to a power.</param>
    /// <param name="exponent">The power to raise the fixed-point number to.</param>
    /// <returns>The fixed-point number raised to the specified power.</returns>
    public static T Pow(T value, T exponent)
    {
        return T.CreateFromDouble(Math.Pow(value.ToDouble(), exponent.ToDouble()));
    }

    /// <summary>
    ///     Returns the value of the specified fixed-point number raised to the power of 10.
    /// </summary>
    /// <param name="value">The fixed-point number to be raised to the power of 10.</param>
    /// <returns>The value of the specified fixed-point number raised to the power of 10.</returns>
    public static T Pow10(T value)
    {
        return T.CreateFromDouble(Math.Pow(10, value.ToDouble()));
    }

    /// <summary>
    ///     Returns the value of the specified fixed-point number raised to the power of pi.
    /// </summary>
    /// <param name="value">The fixed-point number to be raised to the power of pi.</param>
    /// <returns>The value of the specified fixed-point number raised to the power of pi.</returns>
    public static T PowPi(T value)
    {
        return T.CreateFromDouble(Math.Pow(Math.PI, value.ToDouble()));
    }

    /// <summary>
    ///     Rounds a fixed-point number to the nearest integer.
    /// </summary>
    /// <param name="value">The fixed-point number to round.</param>
    /// <returns>The integer nearest to the specified fixed-point number.</returns>
    public static T Round(T value)
    {
        return T.CreateFromDouble(Math.Round(value.ToDouble()));
    }

    /// <summary>
    ///     Rounds a fixed-point number to a specified number of fractional digits.
    /// </summary>
    /// <param name="value">The fixed-point number to round.</param>
    /// <param name="digits">The number of fractional digits to round to.</param>
    /// <returns>The fixed-point number rounded to the specified number of fractional digits.</returns>
    public static T Round(T value, int digits)
    {
        return T.CreateFromDouble(Math.Round(value.ToDouble(), digits));
    }

    /// <summary>
    ///     Returns the sine of the specified angle.
    /// </summary>
    /// <param name="value">An angle, measured in radians.</param>
    /// <returns>The sine of the specified angle.</returns>
    public static T Sin(T value)
    {
        return T.CreateFromDouble(Math.Sin(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the hyperbolic sine of the specified angle.
    /// </summary>
    /// <param name="value">An angle, measured in radians.</param>
    /// <returns>The hyperbolic sine of the specified angle.</returns>
    public static T Sinh(T value)
    {
        return T.CreateFromDouble(Math.Sinh(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the square root of a fixed-point number.
    /// </summary>
    /// <param name="value">The fixed-point number.</param>
    /// <returns>The square root of the fixed-point number.</returns>
    public static T Sqrt(T value)
    {
        return T.CreateFromDouble(Math.Sqrt(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the value of the specified fixed-point number raised to the power of 2.
    /// </summary>
    /// <param name="value">The fixed-point number to be squared.</param>
    /// <returns>The value of the specified fixed-point number raised to the power of 2.</returns>
    public static T Square(T value)
    {
        return value * value;
    }

    /// <summary>
    ///     Subtracts the second fixed-point number from the first.
    /// </summary>
    /// <param name="left">The first fixed-point number.</param>
    /// <param name="right">The second fixed-point number.</param>
    /// <returns>The difference between the two fixed-point numbers.</returns>
    public static T Subtract(T left, T right)
    {
        return left - right;
    }

    /// <summary>
    ///     Sums a set of fixed-point numbers.
    /// </summary>
    /// <param name="values">The fixed-point numbers to sum.</param>
    /// <returns>The sum of the fixed-point numbers.</returns>
    public static T Sum(params T[] values)
    {
        T sum = values[0];
        for (var i = 1; i < values.Length; i++)
        {
            sum += values[i];
        }

        return sum;
    }

    /// <summary>
    ///     Returns the tangent of the specified angle.
    /// </summary>
    /// <param name="value">An angle, measured in radians.</param>
    /// <returns>The tangent of the specified angle.</returns>
    public static T Tan(T value)
    {
        return T.CreateFromDouble(Math.Tan(value.ToDouble()));
    }

    /// <summary>
    ///     Returns the hyperbolic tangent of the specified angle.
    /// </summary>
    /// <param name="value">An angle, measured in radians.</param>
    /// <returns>The hyperbolic tangent of the specified angle.</returns>
    public static T Tanh(T value)
    {
        return T.CreateFromDouble(Math.Tanh(value.ToDouble()));
    }
}
