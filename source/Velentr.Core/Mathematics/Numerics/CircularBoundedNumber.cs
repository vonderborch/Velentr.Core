using System.Diagnostics;
using System.Numerics;
using System.Text.Json.Serialization;
using Velentr.Core.Mathematics.Bound;

namespace Velentr.Core.Mathematics.Numerics;

/// <summary>
///     Represents a number that is bounded by a minimum and maximum value, with circular clamping.
/// </summary>
/// <typeparam name="T">The type of the number, which must implement <see cref="INumber{T}" />.</typeparam>
[DebuggerDisplay("{ToString()}")]
public struct CircularBoundedNumber<T> : IEquatable<CircularBoundedNumber<T>> where T : INumber<T>
{
    [JsonIgnore] private Bounds<T> range;

    [JsonIgnore] private T value;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CircularBoundedNumber{T}" /> struct with the specified value, minimum,
    ///     and maximum.
    /// </summary>
    /// <param name="value">The initial value.</param>
    /// <param name="minimum">The minimum bound.</param>
    /// <param name="maximum">The maximum bound.</param>
    [JsonConstructor]
    public CircularBoundedNumber(T value, T minimum, T maximum)
    {
        this.range = new Bounds<T>(minimum, maximum);
        this.value = this.range.CircularClampValue(value);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="CircularBoundedNumber{T}" /> struct by copying another instance.
    /// </summary>
    /// <param name="parent">The instance to copy.</param>
    public CircularBoundedNumber(CircularBoundedNumber<T> parent) : this(parent.Value, parent.Minimum, parent.Maximum)
    {
    }

    /// <summary>
    ///     Gets or sets the maximum bound.
    /// </summary>
    [JsonPropertyName("maximum")]
    public T Maximum
    {
        get => this.range.Maximum;
        set
        {
            this.range.Maximum = value;
            this.Value = this.value;
        }
    }

    /// <summary>
    ///     Gets or sets the minimum bound.
    /// </summary>
    [JsonPropertyName("minimum")]
    public T Minimum
    {
        get => this.range.Minimum;
        set
        {
            this.range.Minimum = value;
            this.Value = this.value;
        }
    }

    /// <summary>
    ///     Gets or sets the value, clamping it within the bounds circularly.
    /// </summary>
    [JsonPropertyName("value")]
    public T Value
    {
        get => this.value;
        set => this.value = this.range.CircularClampValue(value);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="CircularBoundedNumber{T}" /> to its underlying value.
    /// </summary>
    /// <param name="number">The circular bounded number.</param>
    public static implicit operator T(CircularBoundedNumber<T> number)
    {
        return number.Value;
    }

    /// <summary>
    ///     Determines whether a <see cref="CircularBoundedNumber{T}" /> instance and a value are not equal.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the instances are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(CircularBoundedNumber<T> left, T right)
    {
        return !left.value.Equals(right);
    }

    /// <summary>
    ///     Adds a value to a <see cref="CircularBoundedNumber{T}" /> instance.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <param name="right">The value to add.</param>
    /// <returns>A new <see cref="CircularBoundedNumber{T}" /> instance with the added value.</returns>
    public static CircularBoundedNumber<T> operator +(CircularBoundedNumber<T> left, T right)
    {
        return new CircularBoundedNumber<T>(left.Value + right, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Subtracts a value from a <see cref="CircularBoundedNumber{T}" /> instance.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <param name="right">The value to subtract.</param>
    /// <returns>A new <see cref="CircularBoundedNumber{T}" /> instance with the subtracted value.</returns>
    public static CircularBoundedNumber<T> operator -(CircularBoundedNumber<T> left, T right)
    {
        return new CircularBoundedNumber<T>(left.Value - right, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Multiplies a <see cref="CircularBoundedNumber{T}" /> instance by a value.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <param name="right">The value to multiply by.</param>
    /// <returns>A new <see cref="CircularBoundedNumber{T}" /> instance with the multiplied value.</returns>
    public static CircularBoundedNumber<T> operator *(CircularBoundedNumber<T> left, T right)
    {
        return new CircularBoundedNumber<T>(left.Value * right, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Divides a <see cref="CircularBoundedNumber{T}" /> instance by a value.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <param name="right">The value to divide by.</param>
    /// <returns>A new <see cref="CircularBoundedNumber{T}" /> instance with the divided value.</returns>
    public static CircularBoundedNumber<T> operator /(CircularBoundedNumber<T> left, T right)
    {
        return new CircularBoundedNumber<T>(left.Value / right, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Computes the remainder of the division of the value of the current instance by a specified value.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <param name="right">The value to divide by.</param>
    /// <returns>A new <see cref="CircularBoundedNumber{T}" /> instance with the remainder of the division.</returns>
    public static CircularBoundedNumber<T> operator %(CircularBoundedNumber<T> left, T right)
    {
        return new CircularBoundedNumber<T>(left.Value % right, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Increments the value of a <see cref="CircularBoundedNumber{T}" /> instance by one.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <returns>A new <see cref="CircularBoundedNumber{T}" /> instance with the incremented value.</returns>
    public static CircularBoundedNumber<T> operator ++(CircularBoundedNumber<T> left)
    {
        return new CircularBoundedNumber<T>(left.Value + T.One, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Decrements the value of a <see cref="CircularBoundedNumber{T}" /> instance by one.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <returns>A new <see cref="CircularBoundedNumber{T}" /> instance with the decremented value.</returns>
    public static CircularBoundedNumber<T> operator --(CircularBoundedNumber<T> left)
    {
        return new CircularBoundedNumber<T>(left.Value - T.One, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Determines whether a <see cref="CircularBoundedNumber{T}" /> instance is greater than or equal to a value.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the circular bounded number is greater than or equal to the value; otherwise, <c>false</c>.</returns>
    public static bool operator >=(CircularBoundedNumber<T> left, T right)
    {
        return left.value.CompareTo(right) >= 0;
    }

    /// <summary>
    ///     Determines whether a <see cref="CircularBoundedNumber{T}" /> instance is less than or equal to a value.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the circular bounded number is less than or equal to the value; otherwise, <c>false</c>.</returns>
    public static bool operator <=(CircularBoundedNumber<T> left, T right)
    {
        return left.value.CompareTo(right) <= 0;
    }

    /// <summary>
    ///     Determines whether a <see cref="CircularBoundedNumber{T}" /> instance is greater than a value.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the circular bounded number is greater than the value; otherwise, <c>false</c>.</returns>
    public static bool operator >(CircularBoundedNumber<T> left, T right)
    {
        return left.value.CompareTo(right) > 0;
    }

    /// <summary>
    ///     Determines whether a <see cref="CircularBoundedNumber{T}" /> instance is less than a value.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the circular bounded number is less than the value; otherwise, <c>false</c>.</returns>
    public static bool operator <(CircularBoundedNumber<T> left, T right)
    {
        return left.value.CompareTo(right) < 0;
    }

    /// <summary>
    ///     Determines whether a <see cref="CircularBoundedNumber{T}" /> instance and a value are equal.
    /// </summary>
    /// <param name="left">The circular bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the instances are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(CircularBoundedNumber<T> left, T right)
    {
        return left.value.Equals(right);
    }

    /// <summary>
    ///     Creates a new instance of the <see cref="CircularBoundedNumber{T}" /> struct that is a copy of the current
    ///     instance.
    /// </summary>
    /// <returns>A new instance of the <see cref="CircularBoundedNumber{T}" /> struct.</returns>
    public CircularBoundedNumber<T> Clone()
    {
        return new CircularBoundedNumber<T>(this);
    }

    /// <summary>
    ///     Determines whether the specified object is equal to the current instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns><c>true</c> if the specified object is equal to the current instance; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        return obj is CircularBoundedNumber<T> number &&
               number.Value == this.Value &&
               number.Minimum == this.Minimum &&
               number.Maximum == this.Maximum;
    }

    /// <summary>
    ///     Returns a hash code for the current instance.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.range, this.value);
    }

    /// <summary>
    ///     Returns a string that represents the current instance.
    /// </summary>
    /// <returns>A string that represents the current instance.</returns>
    public override string ToString()
    {
        return $"{this.range.Minimum} <= {this.value} <= {this.range.Maximum} (circular)";
    }

    /// <summary>
    ///     Determines whether the specified <see cref="CircularBoundedNumber{T}" /> is equal to the current instance.
    /// </summary>
    /// <param name="other">The <see cref="CircularBoundedNumber{T}" /> to compare with the current instance.</param>
    /// <returns>
    ///     <c>true</c> if the specified <see cref="CircularBoundedNumber{T}" /> is equal to the current instance;
    ///     otherwise, <c>false</c>.
    /// </returns>
    public bool Equals(CircularBoundedNumber<T> other)
    {
        return this.range.Equals(other.range) && EqualityComparer<T>.Default.Equals(this.value, other.value);
    }
}
