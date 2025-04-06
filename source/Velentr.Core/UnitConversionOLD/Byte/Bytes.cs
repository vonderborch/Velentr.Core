using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Velentr.Core.UnitConversion.Byte;

/// <summary>
///     Represents a quantity of bytes with a specific unit and base size.
/// </summary>
[DebuggerDisplay("{Value} {Unit}")]
public struct Bytes : IEquatable<Bytes>
{
    [JsonIgnore] private ulong value;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Bytes" /> struct.
    /// </summary>
    /// <param name="value">The value in the specified unit.</param>
    /// <param name="unit">The unit of the value.</param>
    /// <param name="baseSize">The base size for unit conversion (default is 1024).</param>
    public Bytes(ulong value, ByteUnits unit, ushort baseSize = 1024)
    {
        this.value = value;
        this.Unit = unit;
        this.BaseSize = baseSize;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Bytes" /> struct from another instance.
    /// </summary>
    /// <param name="bytes">The instance to copy.</param>
    public Bytes(Bytes bytes) : this(bytes.value, bytes.Unit, bytes.BaseSize)
    {
    }

    /// <summary>
    ///     Gets the unit of the value.
    /// </summary>
    [JsonPropertyName("unit")]
    [field: JsonIgnore]
    public ByteUnits Unit { get; private set; }

    /// <summary>
    ///     Gets the base size for unit conversion.
    /// </summary>
    [JsonPropertyName("baseSize")]
    [field: JsonIgnore]
    public ushort BaseSize { get; }

    /// <summary>
    ///     Gets or sets the value in bytes.
    /// </summary>
    [JsonPropertyName("value")]
    public ulong Value
    {
        get => this.value;
        set
        {
            this.value = value;
            this.Unit = ByteUnits.Byte;
        }
    }

    /// <summary>
    ///     Converts the value to the specified unit.
    /// </summary>
    /// <param name="unit">The unit to convert to.</param>
    /// <returns>The value in the specified unit.</returns>
    public ulong AsUnit(ByteUnits unit)
    {
        if (this.Unit.Equals(unit))
        {
            return this.value;
        }

        var unitDifference = unit - this.Unit;
        var factor = Math.Pow(this.BaseSize, Math.Abs(unitDifference));

        return unitDifference > 0
            ? (ulong)(this.value / factor)
            : (ulong)(this.value * factor);
    }

    /// <summary>
    ///     Converts the instance to the specified unit.
    /// </summary>
    /// <param name="unit">The unit to convert to.</param>
    /// <returns>A new instance of <see cref="Bytes" /> in the specified unit.</returns>
    public Bytes ToUnit(ByteUnits unit)
    {
        return new Bytes(AsUnit(unit), unit, this.BaseSize);
    }

    /// <summary>
    ///     Returns a string representation of the instance.
    /// </summary>
    /// <returns>A string representation of the instance.</returns>
    public override string ToString()
    {
        return $"{this.value} {this.Unit}";
    }

    /// <summary>
    ///     Adds two <see cref="Bytes" /> instances.
    /// </summary>
    /// <param name="a">The first instance.</param>
    /// <param name="b">The second instance.</param>
    /// <returns>The sum of the two instances.</returns>
    public static Bytes operator +(Bytes a, Bytes b)
    {
        Bytes actualB = a.Unit == b.Unit ? b : b.ToUnit(a.Unit);
        return new Bytes(a.value + actualB.value, a.Unit, a.BaseSize);
    }

    /// <summary>
    ///     Subtracts one <see cref="Bytes" /> instance from another.
    /// </summary>
    /// <param name="a">The first instance.</param>
    /// <param name="b">The second instance.</param>
    /// <returns>The difference of the two instances.</returns>
    public static Bytes operator -(Bytes a, Bytes b)
    {
        Bytes actualB = a.Unit == b.Unit ? b : b.ToUnit(a.Unit);
        return new Bytes(a.value - actualB.value, a.Unit, a.BaseSize);
    }

    /// <summary>
    ///     Multiplies two <see cref="Bytes" /> instances.
    /// </summary>
    /// <param name="a">The first instance.</param>
    /// <param name="b">The second instance.</param>
    /// <returns>The product of the two instances.</returns>
    public static Bytes operator *(Bytes a, Bytes b)
    {
        Bytes actualB = a.Unit == b.Unit ? b : b.ToUnit(a.Unit);
        return new Bytes(a.value * actualB.value, a.Unit, a.BaseSize);
    }

    /// <summary>
    ///     Divides one <see cref="Bytes" /> instance by another.
    /// </summary>
    /// <param name="a">The first instance.</param>
    /// <param name="b">The second instance.</param>
    /// <returns>The quotient of the two instances.</returns>
    public static Bytes operator /(Bytes a, Bytes b)
    {
        Bytes actualB = a.Unit == b.Unit ? b : b.ToUnit(a.Unit);
        return new Bytes(a.value / actualB.value, a.Unit, a.BaseSize);
    }

    /// <summary>
    ///     Computes the remainder of dividing one <see cref="Bytes" /> instance by another.
    /// </summary>
    /// <param name="a">The first instance.</param>
    /// <param name="b">The second instance.</param>
    /// <returns>The remainder of the division.</returns>
    public static Bytes operator %(Bytes a, Bytes b)
    {
        Bytes actualB = a.Unit == b.Unit ? b : b.ToUnit(a.Unit);
        return new Bytes(a.value % actualB.value, a.Unit, a.BaseSize);
    }

    /// <summary>
    ///     Increments the value by one byte.
    /// </summary>
    /// <param name="a">The instance to increment.</param>
    /// <returns>The incremented instance.</returns>
    public static Bytes operator ++(Bytes a)
    {
        return new Bytes(a.value + 1, a.Unit, a.BaseSize);
    }

    /// <summary>
    ///     Decrements the value by one byte.
    /// </summary>
    /// <param name="a">The instance to decrement.</param>
    /// <returns>The decremented instance.</returns>
    public static Bytes operator --(Bytes a)
    {
        return new Bytes(a.value - 1, a.Unit, a.BaseSize);
    }

    /// <summary>
    ///     Determines whether two <see cref="Bytes" /> instances are equal.
    /// </summary>
    /// <param name="a">The first instance.</param>
    /// <param name="b">The second instance.</param>
    /// <returns><c>true</c> if the instances are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Bytes a, Bytes b)
    {
        return a.Equals(b);
    }

    /// <summary>
    ///     Determines whether two <see cref="Bytes" /> instances are not equal.
    /// </summary>
    /// <param name="a">The first instance.</param>
    /// <param name="b">The second instance.</param>
    /// <returns><c>true</c> if the instances are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Bytes a, Bytes b)
    {
        return !a.Equals(b);
    }

    /// <summary>
    ///     Determines whether one <see cref="Bytes" /> instance is less than another.
    /// </summary>
    /// <param name="a">The first instance.</param>
    /// <param name="b">The second instance.</param>
    /// <returns><c>true</c> if the first instance is less than the second; otherwise, <c>false</c>.</returns>
    public static bool operator <(Bytes a, Bytes b)
    {
        Bytes actualB = a.Unit == b.Unit ? b : b.ToUnit(a.Unit);
        return a.value < actualB.value;
    }

    /// <summary>
    ///     Determines whether one <see cref="Bytes" /> instance is greater than another.
    /// </summary>
    /// <param name="a">The first instance.</param>
    /// <param name="b">The second instance.</param>
    /// <returns><c>true</c> if the first instance is greater than the second; otherwise, <c>false</c>.</returns>
    public static bool operator >(Bytes a, Bytes b)
    {
        Bytes actualB = a.Unit == b.Unit ? b : b.ToUnit(a.Unit);
        return a.value > actualB.value;
    }

    /// <summary>
    ///     Determines whether one <see cref="Bytes" /> instance is less than or equal to another.
    /// </summary>
    /// <param name="a">The first instance.</param>
    /// <param name="b">The second instance.</param>
    /// <returns><c>true</c> if the first instance is less than or equal to the second; otherwise, <c>false</c>.</returns>
    public static bool operator <=(Bytes a, Bytes b)
    {
        Bytes actualB = a.Unit == b.Unit ? b : b.ToUnit(a.Unit);
        return a.value <= actualB.value;
    }

    /// <summary>
    ///     Determines whether one <see cref="Bytes" /> instance is greater than or equal to another.
    /// </summary>
    /// <param name="a">The first instance.</param>
    /// <param name="b">The second instance.</param>
    /// <returns><c>true</c> if the first instance is greater than or equal to the second; otherwise, <c>false</c>.</returns>
    public static bool operator >=(Bytes a, Bytes b)
    {
        Bytes actualB = a.Unit == b.Unit ? b : b.ToUnit(a.Unit);
        return a.value >= actualB.value;
    }

    /// <summary>
    ///     Determines whether the current instance is equal to another instance of <see cref="Bytes" />.
    /// </summary>
    /// <param name="other">The other instance to compare to.</param>
    /// <returns><c>true</c> if the instances are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(Bytes other)
    {
        return this.Unit == other.Unit && this.value == other.value && this.BaseSize == other.BaseSize;
    }

    /// <summary>
    ///     Determines whether the current instance is equal to another object.
    /// </summary>
    /// <param name="obj">The object to compare to.</param>
    /// <returns>
    ///     <c>true</c> if the object is a <see cref="Bytes" /> instance and is equal to the current instance; otherwise,
    ///     <c>false</c>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return obj is Bytes other && Equals(other);
    }

    /// <summary>
    ///     Returns a hash code for the current instance.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Unit, this.value, this.BaseSize);
    }
}
