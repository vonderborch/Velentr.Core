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
    /// Converts a FixedPointPrecision2I value to a FixedPointPrecision2 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2I value to convert.</param>
    /// <returns>A FixedPointPrecision2 value.</returns>
    public static FixedPointPrecision2 ToFixedPointPrecision2(this FixedPointPrecision2I value)
    {
        return FixedPointPrecision2.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision4 value to a FixedPointPrecision2 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision4 value to convert.</param>
    /// <returns>A FixedPointPrecision2 value.</returns>
    public static FixedPointPrecision2 ToFixedPointPrecision2(this FixedPointPrecision4 value)
    {
        return FixedPointPrecision2.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision6 value to a FixedPointPrecision2 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision6 value to convert.</param>
    /// <returns>A FixedPointPrecision2 value.</returns>
    public static FixedPointPrecision2 ToFixedPointPrecision2(this FixedPointPrecision6 value)
    {
        return FixedPointPrecision2.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision8 value to a FixedPointPrecision2 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision8 value to convert.</param>
    /// <returns>A FixedPointPrecision2 value.</returns>
    public static FixedPointPrecision2 ToFixedPointPrecision2(this FixedPointPrecision8 value)
    {
        return FixedPointPrecision2.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision2 value to a FixedPointPrecision2I value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2 value to convert.</param>
    /// <returns>A FixedPointPrecision2I value.</returns>
    public static FixedPointPrecision2I ToFixedPointPrecision2I(this FixedPointPrecision2 value)
    {
        return FixedPointPrecision2I.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision4 value to a FixedPointPrecision2I value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision4 value to convert.</param>
    /// <returns>A FixedPointPrecision2I value.</returns>
    public static FixedPointPrecision2I ToFixedPointPrecision2I(this FixedPointPrecision4 value)
    {
        return FixedPointPrecision2I.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision6 value to a FixedPointPrecision2I value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision6 value to convert.</param>
    /// <returns>A FixedPointPrecision2I value.</returns>
    public static FixedPointPrecision2I ToFixedPointPrecision2I(this FixedPointPrecision6 value)
    {
        return FixedPointPrecision2I.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision8 value to a FixedPointPrecision2I value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision8 value to convert.</param>
    /// <returns>A FixedPointPrecision2I value.</returns>
    public static FixedPointPrecision2I ToFixedPointPrecision2I(this FixedPointPrecision8 value)
    {
        return FixedPointPrecision2I.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision2 value to a FixedPointPrecision4 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2 value to convert.</param>
    /// <returns>A FixedPointPrecision4 value.</returns>
    public static FixedPointPrecision4 ToFixedPointPrecision4(this FixedPointPrecision2 value)
    {
        return FixedPointPrecision4.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision2I value to a FixedPointPrecision4 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2I value to convert.</param>
    /// <returns>A FixedPointPrecision4 value.</returns>
    public static FixedPointPrecision4 ToFixedPointPrecision4(this FixedPointPrecision2I value)
    {
        return FixedPointPrecision4.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision6 value to a FixedPointPrecision4 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision6 value to convert.</param>
    /// <returns>A FixedPointPrecision4 value.</returns>
    public static FixedPointPrecision4 ToFixedPointPrecision4(this FixedPointPrecision6 value)
    {
        return FixedPointPrecision4.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision8 value to a FixedPointPrecision4 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision8 value to convert.</param>
    /// <returns>A FixedPointPrecision4 value.</returns>
    public static FixedPointPrecision4 ToFixedPointPrecision4(this FixedPointPrecision8 value)
    {
        return FixedPointPrecision4.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision2 value to a FixedPointPrecision6 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2 value to convert.</param>
    /// <returns>A FixedPointPrecision6 value.</returns>
    public static FixedPointPrecision6 ToFixedPointPrecision6(this FixedPointPrecision2 value)
    {
        return FixedPointPrecision6.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision2I value to a FixedPointPrecision6 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2I value to convert.</param>
    /// <returns>A FixedPointPrecision6 value.</returns>
    public static FixedPointPrecision6 ToFixedPointPrecision6(this FixedPointPrecision2I value)
    {
        return FixedPointPrecision6.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision4 value to a FixedPointPrecision6 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision4 value to convert.</param>
    /// <returns>A FixedPointPrecision6 value.</returns>
    public static FixedPointPrecision6 ToFixedPointPrecision6(this FixedPointPrecision4 value)
    {
        return FixedPointPrecision6.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision8 value to a FixedPointPrecision6 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision8 value to convert.</param>
    /// <returns>A FixedPointPrecision6 value.</returns>
    public static FixedPointPrecision6 ToFixedPointPrecision6(this FixedPointPrecision8 value)
    {
        return FixedPointPrecision6.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision2 value to a FixedPointPrecision8 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2 value to convert.</param>
    /// <returns>A FixedPointPrecision8 value.</returns>
    public static FixedPointPrecision8 ToFixedPointPrecision8(this FixedPointPrecision2 value)
    {
        return FixedPointPrecision8.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision2I value to a FixedPointPrecision8 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision2I value to convert.</param>
    /// <returns>A FixedPointPrecision8 value.</returns>
    public static FixedPointPrecision8 ToFixedPointPrecision8(this FixedPointPrecision2I value)
    {
        return FixedPointPrecision8.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision4 value to a FixedPointPrecision8 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision4 value to convert.</param>
    /// <returns>A FixedPointPrecision8 value.</returns>
    public static FixedPointPrecision8 ToFixedPointPrecision8(this FixedPointPrecision4 value)
    {
        return FixedPointPrecision8.CreateFromDouble(value.ToDouble());
    }

    /// <summary>
    /// Converts a FixedPointPrecision6 value to a FixedPointPrecision8 value.
    /// </summary>
    /// <param name="value">The FixedPointPrecision6 value to convert.</param>
    /// <returns>A FixedPointPrecision8 value.</returns>
    public static FixedPointPrecision8 ToFixedPointPrecision8(this FixedPointPrecision6 value)
    {
        return FixedPointPrecision8.CreateFromDouble(value.ToDouble());
    }
}
