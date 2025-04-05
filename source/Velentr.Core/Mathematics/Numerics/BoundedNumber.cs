using System.Diagnostics;
using System.Numerics;
using System.Text.Json.Serialization;
using Velentr.Core.Mathematics.Bound;

namespace Velentr.Core.Mathematics.Numerics;

/// <summary>
///     Represents a number that is bounded by a minimum and maximum value.
/// </summary>
/// <typeparam name="T">The type of the number, which must implement <see cref="INumber{T}" />.</typeparam>
[DebuggerDisplay("{ToString()}")]
public struct BoundedNumber<T> : IEquatable<BoundedNumber<T>> where T : INumber<T>
{
    [JsonIgnore] private Bounds<T> range;

    [JsonIgnore] private T value;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BoundedNumber{T}" /> struct with the specified value, minimum, and
    ///     maximum.
    /// </summary>
    /// <param name="value">The initial value.</param>
    /// <param name="minimum">The minimum bound.</param>
    /// <param name="maximum">The maximum bound.</param>
    [JsonConstructor]
    public BoundedNumber(T value, T minimum, T maximum)
    {
        this.range = new Bounds<T>(minimum, maximum);
        this.value = this.range.ClampValue(value);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="BoundedNumber{T}" /> struct by copying another instance.
    /// </summary>
    /// <param name="parent">The instance to copy.</param>
    public BoundedNumber(BoundedNumber<T> parent) : this(parent.Value, parent.Minimum, parent.Maximum)
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
    ///     Gets or sets the value, clamping it within the bounds.
    /// </summary>
    [JsonPropertyName("value")]
    public T Value
    {
        get => this.value;
        set => this.value = this.range.ClampValue(value);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="BoundedNumber{T}" /> to its underlying value.
    /// </summary>
    /// <param name="number">The bounded number.</param>
    public static implicit operator T(BoundedNumber<T> number)
    {
        return number.Value;
    }

    /// <summary>
    ///     Determines whether a <see cref="BoundedNumber{T}" /> instance and a value are not equal.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the instances are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(BoundedNumber<T> left, T right)
    {
        return left.Value != right;
    }

    /// <summary>
    ///     Determines whether a <see cref="BoundedNumber{T}" /> instance is less than a value.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the bounded number is less than the value; otherwise, <c>false</c>.</returns>
    public static bool operator <(BoundedNumber<T> left, T right)
    {
        return left.Value < right;
    }

    /// <summary>
    ///     Determines whether a <see cref="BoundedNumber{T}" /> instance is less than or equal to a value.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the bounded number is less than or equal to the value; otherwise, <c>false</c>.</returns>
    public static bool operator <=(BoundedNumber<T> left, T right)
    {
        return left.Value <= right;
    }

    /// <summary>
    ///     Determines whether a <see cref="BoundedNumber{T}" /> instance and a value are equal.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the instances are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(BoundedNumber<T> left, T right)
    {
        return left.Value == right;
    }

    /// <summary>
    ///     Determines whether a <see cref="BoundedNumber{T}" /> instance is greater than a value.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the bounded number is greater than the value; otherwise, <c>false</c>.</returns>
    public static bool operator >(BoundedNumber<T> left, T right)
    {
        return left.Value > right;
    }

    /// <summary>
    ///     Determines whether a <see cref="BoundedNumber{T}" /> instance is greater than or equal to a value.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <param name="right">The value.</param>
    /// <returns><c>true</c> if the bounded number is greater than or equal to the value; otherwise, <c>false</c>.</returns>
    public static bool operator >=(BoundedNumber<T> left, T right)
    {
        return left.Value >= right;
    }

    /// <summary>
    ///     Adds a value to a <see cref="BoundedNumber{T}" /> instance.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <param name="right">The value to add.</param>
    /// <returns>A new <see cref="BoundedNumber{T}" /> instance with the added value.</returns>
    public static BoundedNumber<T> operator +(BoundedNumber<T> left, T right)
    {
        return new BoundedNumber<T>(left.Value + right, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Subtracts a value from a <see cref="BoundedNumber{T}" /> instance.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <param name="right">The value to subtract.</param>
    /// <returns>A new <see cref="BoundedNumber{T}" /> instance with the subtracted value.</returns>
    public static BoundedNumber<T> operator -(BoundedNumber<T> left, T right)
    {
        return new BoundedNumber<T>(left.Value - right, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Multiplies a <see cref="BoundedNumber{T}" /> instance by a value.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <param name="right">The value to multiply by.</param>
    /// <returns>A new <see cref="BoundedNumber{T}" /> instance with the multiplied value.</returns>
    public static BoundedNumber<T> operator *(BoundedNumber<T> left, T right)
    {
        return new BoundedNumber<T>(left.Value * right, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Divides a <see cref="BoundedNumber{T}" /> instance by a value.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <param name="right">The value to divide by.</param>
    /// <returns>A new <see cref="BoundedNumber{T}" /> instance with the divided value.</returns>
    public static BoundedNumber<T> operator /(BoundedNumber<T> left, T right)
    {
        return new BoundedNumber<T>(left.Value / right, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Computes the remainder of the division of the value of the current instance by a specified value.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <param name="right">The value to divide by.</param>
    /// <returns>A new <see cref="BoundedNumber{T}" /> instance with the remainder of the division.</returns>
    public static BoundedNumber<T> operator %(BoundedNumber<T> left, T right)
    {
        return new BoundedNumber<T>(left.Value % right, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Increments a <see cref="BoundedNumber{T}" /> instance by 1.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <returns>A new <see cref="BoundedNumber{T}" /> instance with the incremented value.</returns>
    public static BoundedNumber<T> operator ++(BoundedNumber<T> left)
    {
        return new BoundedNumber<T>(left.Value + T.One, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Decrements a <see cref="BoundedNumber{T}" /> instance by 1.
    /// </summary>
    /// <param name="left">The bounded number.</param>
    /// <returns>A new <see cref="BoundedNumber{T}" /> instance with the decremented value.</returns>
    public static BoundedNumber<T> operator --(BoundedNumber<T> left)
    {
        return new BoundedNumber<T>(left.Value - T.One, left.Minimum, left.Maximum);
    }

    /// <summary>
    ///     Creates a new instance of the <see cref="BoundedNumber{T}" /> struct that is a copy of the current instance.
    /// </summary>
    /// <returns>A new instance of the <see cref="BoundedNumber{T}" /> struct.</returns>
    public BoundedNumber<T> Clone()
    {
        return new BoundedNumber<T>(this);
    }

    /// <summary>
    ///     Determines whether the specified object is equal to the current instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns><c>true</c> if the specified object is equal to the current instance; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        return obj is BoundedNumber<T> number && this.Maximum == number.Maximum && this.Minimum == number.Minimum &&
               this.Value == number.Value;
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
        return $"{this.range.Minimum} <= {this.value} <= {this.range.Maximum}";
    }

    /// <summary>
    ///     Determines whether the specified <see cref="BoundedNumber{T}" /> is equal to the current instance.
    /// </summary>
    /// <param name="other">The <see cref="BoundedNumber{T}" /> to compare with the current instance.</param>
    /// <returns>
    ///     <c>true</c> if the specified <see cref="BoundedNumber{T}" /> is equal to the current instance; otherwise,
    ///     <c>false</c>.
    /// </returns>
    public bool Equals(BoundedNumber<T> other)
    {
        return this.range.Equals(other.range) && EqualityComparer<T>.Default.Equals(this.value, other.value);
    }
}
