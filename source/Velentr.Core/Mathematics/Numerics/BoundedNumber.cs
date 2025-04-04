using System.Diagnostics;
using System.Numerics;
using System.Text.Json.Serialization;
using Velentr.Core.Mathematics.Bound;

namespace Velentr.Core.Mathematics.Numerics;

[DebuggerDisplay("{ToString()}")]
public struct BoundedNumber<T> : IEquatable<BoundedNumber<T>> where T : INumber<T>
{
    [JsonIgnore]
    private Bounds<T> range;

    [JsonIgnore]
    private T value;

    [JsonConstructor]
    public BoundedNumber(T value, T minimum, T maximum)
    {
        this.range = new Bounds<T>(minimum, maximum);
        this.value = this.range.ClampValue(value);
    }

    public BoundedNumber(BoundedNumber<T> parent) : this(parent.Value, parent.Minimum, parent.Maximum)
    {
    }

    [JsonPropertyName("maximum")]
    public T Maximum
    {
        get => this.range.Maximum;
        set
        {
            this.range.Maximum = value;
            Value = this.value;
        }
    }

    [JsonPropertyName("minimum")]
    public T Minimum
    {
        get => this.range.Minimum;
        set
        {
            this.range.Minimum = value;
            Value = this.value;
        }
    }

    [JsonPropertyName("value")]
    public T Value
    {
        get => this.value;
        set => this.value = this.range.ClampValue(value);
    }

    public static implicit operator T(BoundedNumber<T> number)
    {
        return number.Value;
    }

    public static bool operator !=(BoundedNumber<T> left, BoundedNumber<T> right)
    {
        return !left.Equals(right);
    }
    
    public static bool operator !=(BoundedNumber<T> left, T right)
    {
        return left.Value != right;
    }

    public static bool operator <(BoundedNumber<T> left, BoundedNumber<T> right)
    {
        return left.Value < right.Value;
    }
    
    public static bool operator <(BoundedNumber<T> left, T right)
    {
        return left.Value < right;
    }

    public static bool operator <=(BoundedNumber<T> left, BoundedNumber<T> right)
    {
        return left.Value <= right.Value;
    }
    
    public static bool operator <=(BoundedNumber<T> left, T right)
    {
        return left.Value <= right;
    }

    public static bool operator ==(BoundedNumber<T> left, BoundedNumber<T> right)
    {
        return left.Equals(right);
    }
    
    public static bool operator ==(BoundedNumber<T> left, T right)
    {
        return left.Value == right;
    }

    public static bool operator >(BoundedNumber<T> left, BoundedNumber<T> right)
    {
        return left.Value > right.Value;
    }
    
    public static bool operator >(BoundedNumber<T> left, T right)
    {
        return left.Value > right;
    }

    public static bool operator >=(BoundedNumber<T> left, BoundedNumber<T> right)
    {
        return left.Value >= right.Value;
    }
    
    public static bool operator >=(BoundedNumber<T> left, T right)
    {
        return left.Value >= right;
    }

    public BoundedNumber<T> Clone()
    {
        return new BoundedNumber<T>(this);
    }

    public override bool Equals(object? obj)
    {
        return obj is BoundedNumber<T> number &&
               Maximum == number.Maximum &&
               Minimum == number.Minimum &&
               Value == number.Value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.range, this.value);
    }

    public override string ToString()
    {
        return $"{this.range.Minimum} <= {this.value} <= {this.range.Maximum}";
    }

    public bool Equals(BoundedNumber<T> other)
    {
        return this.range.Equals(other.range) && EqualityComparer<T>.Default.Equals(this.value, other.value);
    }
}
