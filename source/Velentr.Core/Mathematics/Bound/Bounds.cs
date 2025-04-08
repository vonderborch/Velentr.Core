using System.Diagnostics;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Velentr.Core.Mathematics.Bound;

/// <summary>
///     Represents a range with a minimum and maximum value.
/// </summary>
/// <typeparam name="T">The type of the values, which must implement <see cref="INumber{T}" />.</typeparam>
[DebuggerDisplay("{ToString()}")]
public struct Bounds<T> : IEquatable<Bounds<T>> where T : INumber<T>
{
    [JsonIgnore] private T maximum;

    [JsonIgnore] private T minimum;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Bounds{T}" /> struct with the specified parent bounds.
    /// </summary>
    /// <param name="parent">The parent bounds to copy.</param>
    public Bounds(Bounds<T> parent)
    {
        this.minimum = parent.Minimum;
        this.maximum = parent.Maximum;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Bounds{T}" /> struct with the specified minimum and maximum values.
    /// </summary>
    /// <param name="minimum">The minimum value.</param>
    /// <param name="maximum">The maximum value.</param>
    [JsonConstructor]
    public Bounds(T minimum, T maximum)
    {
        this.minimum = minimum;
        this.maximum = maximum;
        if (this.maximum < this.minimum)
        {
            (this.minimum, this.maximum) = (this.maximum, this.minimum);
        }
    }

    /// <summary>
    ///     Gets or sets the maximum value.
    /// </summary>
    [JsonPropertyName("maximum")]
    public T Maximum
    {
        get => this.maximum;
        set
        {
            this.maximum = value;
            if (this.maximum < this.minimum)
            {
                (this.minimum, this.maximum) = (this.maximum, this.minimum);
            }
        }
    }

    /// <summary>
    ///     Gets or sets the minimum value.
    /// </summary>
    [JsonPropertyName("minimum")]
    public T Minimum
    {
        get => this.minimum;
        set
        {
            this.minimum = value;
            if (this.maximum < this.minimum)
            {
                (this.minimum, this.maximum) = (this.maximum, this.minimum);
            }
        }
    }

    /// <summary>
    ///     Determines whether two <see cref="Bounds{T}" /> instances are not equal.
    /// </summary>
    /// <param name="left">The left bounds.</param>
    /// <param name="right">The right bounds.</param>
    /// <returns><c>true</c> if the bounds are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Bounds<T> left, Bounds<T> right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    ///     Determines whether two <see cref="Bounds{T}" /> instances are equal.
    /// </summary>
    /// <param name="left">The left bounds.</param>
    /// <param name="right">The right bounds.</param>
    /// <returns><c>true</c> if the bounds are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Bounds<T> left, Bounds<T> right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Clamps the specified value within the bounds, wrapping around if necessary.
    /// </summary>
    /// <param name="value">The value to clamp.</param>
    /// <returns>The clamped value.</returns>
    public T CircularClampValue(T value)
    {
        T output = Maths<T>.CircularClamp(value, this.minimum, this.maximum);
        return output;
    }

    /// <summary>
    ///     Clamps the specified value within the bounds.
    /// </summary>
    /// <param name="value">The value to clamp.</param>
    /// <returns>The clamped value.</returns>
    public T ClampValue(T value)
    {
        T output = Maths<T>.Clamp(value, this.minimum, this.maximum);
        return output;
    }

    /// <summary>
    ///     Determines whether the specified object is equal to the current bounds.
    /// </summary>
    /// <param name="obj">The object to compare with the current bounds.</param>
    /// <returns><c>true</c> if the specified object is equal to the current bounds; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is Bounds<T> other)
        {
            return this.Minimum.Equals(other.Minimum) && this.Maximum.Equals(other.Maximum);
        }

        return false;
    }

    /// <summary>
    ///     Returns a hash code for the current bounds.
    /// </summary>
    /// <returns>A hash code for the current bounds.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Minimum, this.Maximum);
    }

    /// <summary>
    ///     Returns a string that represents the current bounds.
    /// </summary>
    /// <returns>A string that represents the current bounds.</returns>
    public override string ToString()
    {
        return $"({this.Minimum} -> {this.Maximum})";
    }

    /// <summary>
    ///     Compares this instance with another <see cref="Bounds{T}" /> instance for equality.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>True if equals, False otherwise.</returns>
    public bool Equals(Bounds<T> other)
    {
        return EqualityComparer<T>.Default.Equals(this.maximum, other.maximum) &&
               EqualityComparer<T>.Default.Equals(this.minimum, other.minimum);
    }
}
