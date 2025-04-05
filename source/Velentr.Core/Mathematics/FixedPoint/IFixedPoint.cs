using System.Numerics;

namespace Velentr.Core.Mathematics.FixedPoint;

/// <summary>
///     Interface representing a fixed-point number type.
/// </summary>
/// <typeparam name="TSelf">The type that implements the interface.</typeparam>
public interface IFixedPoint<TSelf> : INumber<TSelf> where TSelf : INumber<TSelf>
{
    /// <summary>
    /// Represents the maximum value of the fixed-point number.
    /// </summary>
    static abstract TSelf MaxValue { get; }
    
    /// <summary>
    /// Represents the minimum value of the fixed-point number.
    /// </summary>
    static abstract TSelf MinValue { get; }
    
    /// <summary>
    ///     Gets the external precision of the fixed-point number.
    /// </summary>
    static abstract ushort Precision { get; }

    /// <summary>
    ///     Gets the shift value used for fixed-point calculations.
    /// </summary>
    static abstract ushort Shift { get; }

    /// <summary>
    ///     Creates a fixed-point number from a double value.
    /// </summary>
    /// <param name="value">The double value to convert.</param>
    /// <returns>A fixed-point number representing the double value.</returns>
    static abstract TSelf CreateFromDouble(double value);

    /// <summary>
    ///     Creates a fixed-point number from a float value.
    /// </summary>
    /// <param name="value">The float value to convert.</param>
    /// <returns>A fixed-point number representing the float value.</returns>
    static abstract TSelf CreateFromFloat(float value);

    /// <summary>
    ///     Converts the fixed-point number to a double.
    /// </summary>
    /// <returns>The double representation of the fixed-point number.</returns>
    double ToDouble();

    /// <summary>
    ///     Converts the fixed-point number to a float.
    /// </summary>
    /// <returns>The float representation of the fixed-point number.</returns>
    float ToFloat();
}
