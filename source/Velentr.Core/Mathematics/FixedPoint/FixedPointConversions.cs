namespace Velentr.Core.Mathematics.FixedPoint;

/// <summary>
/// Provides extension methods for converting between different fixed-point number representations.
/// </summary>
/// <remarks>
/// This static class contains extension methods that enable seamless conversion between
/// fixed-point representations with different precisions (2, 4, 6, and 8 decimal places).
///
/// Each conversion method works by first converting the source fixed-point value to a
/// double as an intermediate representation, then creating a new fixed-point value of
/// the target precision from that double.
///
/// Note that conversions between different precision types may involve small rounding
/// errors due to the double-conversion process and the inherent limitations of
/// fixed-point arithmetic.
/// </remarks>
public static class FixedPointConversions
{
    /// <summary>
    /// Converts a FP2I value to a FixedPointPrecision2 value.
    /// </summary>
    /// <param name="value">The FP2I value to convert.</param>
    /// <returns>A FixedPointPrecision2 value.</returns>
    public static FP2 ToFixedPointPrecision2(this FP2I value)
    {
        return FP2.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP4 value to a FixedPointPrecision2 value.
    /// </summary>
    /// <param name="value">The FP4 value to convert.</param>
    /// <returns>A FixedPointPrecision2 value.</returns>
    public static FP2 ToFixedPointPrecision2(this FP4 value)
    {
        return FP2.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP6 value to a FixedPointPrecision2 value.
    /// </summary>
    /// <param name="value">The FP6 value to convert.</param>
    /// <returns>A FixedPointPrecision2 value.</returns>
    public static FP2 ToFixedPointPrecision2(this FP6 value)
    {
        return FP2.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP8 value to a FixedPointPrecision2 value.
    /// </summary>
    /// <param name="value">The FP8 value to convert.</param>
    /// <returns>A FixedPointPrecision2 value.</returns>
    public static FP2 ToFixedPointPrecision2(this FP8 value)
    {
        return FP2.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision2 value to a FP2I value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2 value to convert.</param>
    /// <returns>A FP2I value.</returns>
    public static FP2I ToFixedPointPrecision2I(this FP2 value)
    {
        return FP2I.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP4 value to a FP2I value.
    /// </summary>
    /// <param name="value">The FP4 value to convert.</param>
    /// <returns>A FP2I value.</returns>
    public static FP2I ToFixedPointPrecision2I(this FP4 value)
    {
        return FP2I.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP6 value to a FP2I value.
    /// </summary>
    /// <param name="value">The FP6 value to convert.</param>
    /// <returns>A FP2I value.</returns>
    public static FP2I ToFixedPointPrecision2I(this FP6 value)
    {
        return FP2I.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP8 value to a FP2I value.
    /// </summary>
    /// <param name="value">The FP8 value to convert.</param>
    /// <returns>A FP2I value.</returns>
    public static FP2I ToFixedPointPrecision2I(this FP8 value)
    {
        return FP2I.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision2 value to a FP4 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2 value to convert.</param>
    /// <returns>A FP4 value.</returns>
    public static FP4 ToFixedPointPrecision4(this FP2 value)
    {
        return FP4.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP2I value to a FP4 value.
    /// </summary>
    /// <param name="value">The FP2I value to convert.</param>
    /// <returns>A FP4 value.</returns>
    public static FP4 ToFixedPointPrecision4(this FP2I value)
    {
        return FP4.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP6 value to a FP4 value.
    /// </summary>
    /// <param name="value">The FP6 value to convert.</param>
    /// <returns>A FP4 value.</returns>
    public static FP4 ToFixedPointPrecision4(this FP6 value)
    {
        return FP4.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP8 value to a FP4 value.
    /// </summary>
    /// <param name="value">The FP8 value to convert.</param>
    /// <returns>A FP4 value.</returns>
    public static FP4 ToFixedPointPrecision4(this FP8 value)
    {
        return FP4.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision2 value to a FP6 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2 value to convert.</param>
    /// <returns>A FP6 value.</returns>
    public static FP6 ToFixedPointPrecision6(this FP2 value)
    {
        return FP6.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP2I value to a FP6 value.
    /// </summary>
    /// <param name="value">The FP2I value to convert.</param>
    /// <returns>A FP6 value.</returns>
    public static FP6 ToFixedPointPrecision6(this FP2I value)
    {
        return FP6.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP4 value to a FP6 value.
    /// </summary>
    /// <param name="value">The FP4 value to convert.</param>
    /// <returns>A FP6 value.</returns>
    public static FP6 ToFixedPointPrecision6(this FP4 value)
    {
        return FP6.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP8 value to a FP6 value.
    /// </summary>
    /// <param name="value">The FP8 value to convert.</param>
    /// <returns>A FP6 value.</returns>
    public static FP6 ToFixedPointPrecision6(this FP8 value)
    {
        return FP6.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision2 value to a FP8 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2 value to convert.</param>
    /// <returns>A FP8 value.</returns>
    public static FP8 ToFixedPointPrecision8(this FP2 value)
    {
        return FP8.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP2I value to a FP8 value.
    /// </summary>
    /// <param name="value">The FP2I value to convert.</param>
    /// <returns>A FP8 value.</returns>
    public static FP8 ToFixedPointPrecision8(this FP2I value)
    {
        return FP8.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP4 value to a FP8 value.
    /// </summary>
    /// <param name="value">The FP4 value to convert.</param>
    /// <returns>A FP8 value.</returns>
    public static FP8 ToFixedPointPrecision8(this FP4 value)
    {
        return FP8.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FP6 value to a FP8 value.
    /// </summary>
    /// <param name="value">The FP6 value to convert.</param>
    /// <returns>A FP8 value.</returns>
    public static FP8 ToFixedPointPrecision8(this FP6 value)
    {
        return FP8.CreateFromDouble(value.ToDouble());
    }
}
