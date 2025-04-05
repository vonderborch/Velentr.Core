using System.Numerics;

namespace Velentr.Core.Mathematics.FixedPoint;

/// <summary>
///     Interface representing a base fixed-point type.
/// </summary>
/// <typeparam name="T">The type of the raw value.</typeparam>
public interface IBaseFixedPoint<T> where T : INumber<T>
{
    /// <summary>
    ///     Gets the base value representing one in the fixed-point format.
    /// </summary>
    static abstract T BaseOne { get; }

    /// <summary>
    ///     Gets the format string used for converting the fixed-point number to a string.
    /// </summary>
    static abstract string StringFormat { get; }

    /// <summary>
    ///     Gets or sets the raw value of the fixed-point number.
    /// </summary>
    T RawValue { get; set; }
}
