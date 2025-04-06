using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Velentr.Core.UnitConversion.Heat;

/// <summary>
/// Represents a temperature value in a specific temperature scale.
/// </summary>
[DebuggerDisplay("{Value} {Scale}")]
public struct Temperature : IEquatable<Temperature>
{
    [JsonIgnore]
    private double temperature;
    
    [JsonIgnore]
    private TemperatureScale scale;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Temperature"/> struct.
    /// </summary>
    /// <param name="value">The temperature value.</param>
    /// <param name="scale">The temperature scale.</param>
    /// <param name="fromScale">The original temperature scale, if different from the target scale.</param>
    [JsonConstructor]
    public Temperature(double value, TemperatureScale scale, TemperatureScale? fromScale = null)
    {
        if (fromScale == null)
        {
            fromScale = scale;
        }

        if (fromScale == scale)
        {
            this.temperature = value;
        }
        else
        {
            this.temperature = scale.FromCelsius(fromScale?.ToCelsius(value) ?? value);
        }
        this.scale = scale;
    }
    
    /// <summary>
    /// Gets or sets the temperature value.
    /// </summary>
    [JsonPropertyName("value")]
    public double Value
    {
        get => temperature;
        set => temperature = value;
    }
    
    /// <summary>
    /// Gets the temperature scale.
    /// </summary>
    [JsonPropertyName("scale")]
    public TemperatureScale Scale
    {
        get => scale;
    }
    
    /// <summary>
    /// Converts the temperature to the specified scale.
    /// </summary>
    /// <param name="toScale">The target temperature scale.</param>
    /// <returns>The temperature value in the target scale.</returns>
    public double InScale(TemperatureScale toScale)
    {
        return toScale.FromCelsius(this.scale.ToCelsius(this.temperature));
    }
    
    /// <summary>
    /// Converts the temperature to the specified scale and returns a new <see cref="Temperature"/> instance.
    /// </summary>
    /// <param name="toScale">The target temperature scale.</param>
    /// <returns>A new <see cref="Temperature"/> instance in the target scale.</returns>
    public Temperature ToScale(TemperatureScale toScale)
    {
        double asCelsius = InScale(TemperatureScale.Celsius);
        double asTargetScale = toScale.FromCelsius(asCelsius);
        return new Temperature(asTargetScale, toScale);
    }
    
    /// <summary>
    /// Determines whether two <see cref="Temperature"/> instances are equal.
    /// </summary>
    /// <param name="a">The first <see cref="Temperature"/> instance.</param>
    /// <param name="b">The second <see cref="Temperature"/> instance.</param>
    /// <returns>true if the instances are equal; otherwise, false.</returns>
    public static bool operator ==(Temperature a, Temperature b)
    {
        return a.scale == b.scale && a.temperature == b.temperature;
    }
    
    /// <summary>
    /// Determines whether two <see cref="Temperature"/> instances are not equal.
    /// </summary>
    /// <param name="a">The first <see cref="Temperature"/> instance.</param>
    /// <param name="b">The second <see cref="Temperature"/> instance.</param>
    /// <returns>true if the instances are not equal; otherwise, false.</returns>
    public static bool operator !=(Temperature a, Temperature b)
    {
        return !(a == b);
    }
    
    /// <summary>
    /// Determines whether one <see cref="Temperature"/> instance is less than another.
    /// </summary>
    /// <param name="a">The first <see cref="Temperature"/> instance.</param>
    /// <param name="b">The second <see cref="Temperature"/> instance.</param>
    /// <returns>true if the first instance is less than the second; otherwise, false.</returns>
    public static bool operator <(Temperature a, Temperature b)
    {
        return a.InScale(b.scale) < b.InScale(a.scale);
    }
    
    /// <summary>
    /// Determines whether one <see cref="Temperature"/> instance is greater than another.
    /// </summary>
    /// <param name="a">The first <see cref="Temperature"/> instance.</param>
    /// <param name="b">The second <see cref="Temperature"/> instance.</param>
    /// <returns>true if the first instance is greater than the second; otherwise, false.</returns>
    public static bool operator >(Temperature a, Temperature b)
    {
        return a.InScale(b.scale) > b.InScale(a.scale);
    }
    
    /// <summary>
    /// Determines whether one <see cref="Temperature"/> instance is less than or equal to another.
    /// </summary>
    /// <param name="a">The first <see cref="Temperature"/> instance.</param>
    /// <param name="b">The second <see cref="Temperature"/> instance.</param>
    /// <returns>true if the first instance is less than or equal to the second; otherwise, false.</returns>
    public static bool operator <=(Temperature a, Temperature b)
    {
        return a.InScale(b.scale) <= b.InScale(a.scale);
    }
    
    /// <summary>
    /// Determines whether one <see cref="Temperature"/> instance is greater than or equal to another.
    /// </summary>
    /// <param name="a">The first <see cref="Temperature"/> instance.</param>
    /// <param name="b">The second <see cref="Temperature"/> instance.</param>
    /// <returns>true if the first instance is greater than or equal to the second; otherwise, false.</returns>
    public static bool operator >=(Temperature a, Temperature b)
    {
        return a.InScale(b.scale) >= b.InScale(a.scale);
    }
    
    /// <summary>
    /// Adds two <see cref="Temperature"/> instances.
    /// </summary>
    /// <param name="a">The first <see cref="Temperature"/> instance.</param>
    /// <param name="b">The second <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the sum.</returns>
    public static Temperature operator +(Temperature a, Temperature b)
    {
        return new Temperature(a.InScale(b.scale) + b.InScale(a.scale), a.scale);
    }
    
    /// <summary>
    /// Subtracts one <see cref="Temperature"/> instance from another.
    /// </summary>
    /// <param name="a">The first <see cref="Temperature"/> instance.</param>
    /// <param name="b">The second <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the difference.</returns>
    public static Temperature operator -(Temperature a, Temperature b)
    {
        return new Temperature(a.InScale(b.scale) - b.InScale(a.scale), a.scale);
    }
    
    /// <summary>
    /// Negates a <see cref="Temperature"/> instance.
    /// </summary>
    /// <param name="a">The <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the negation.</returns>
    public static Temperature operator -(Temperature a)
    {
        return new Temperature(-a.InScale(a.scale), a.scale);
    }
    
    /// <summary>
    /// Returns the same <see cref="Temperature"/> instance.
    /// </summary>
    /// <param name="a">The <see cref="Temperature"/> instance.</param>
    /// <returns>The same <see cref="Temperature"/> instance.</returns>
    public static Temperature operator +(Temperature a)
    {
        return new Temperature(a.InScale(a.scale), a.scale);
    }
    
    /// <summary>
    /// Divides one <see cref="Temperature"/> instance by another.
    /// </summary>
    /// <param name="a">The first <see cref="Temperature"/> instance.</param>
    /// <param name="b">The second <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the quotient.</returns>
    public static Temperature operator /(Temperature a, Temperature b)
    {
        return new Temperature(a.InScale(b.scale) / b.InScale(a.scale), a.scale);
    }
    
    /// <summary>
    /// Multiplies two <see cref="Temperature"/> instances.
    /// </summary>
    /// <param name="a">The first <see cref="Temperature"/> instance.</param>
    /// <param name="b">The second <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the product.</returns>
    public static Temperature operator *(Temperature a, Temperature b)
    {
        return new Temperature(a.InScale(b.scale) * b.InScale(a.scale), a.scale);
    }
    
    /// <summary>
    /// Multiplies a <see cref="Temperature"/> instance by a scalar.
    /// </summary>
    /// <param name="a">The <see cref="Temperature"/> instance.</param>
    /// <param name="b">The scalar value.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the product.</returns>
    public static Temperature operator *(Temperature a, double b)
    {
        return new Temperature(a.InScale(a.scale) * b, a.scale);
    }
    
    /// <summary>
    /// Divides a <see cref="Temperature"/> instance by a scalar.
    /// </summary>
    /// <param name="a">The <see cref="Temperature"/> instance.</param>
    /// <param name="b">The scalar value.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the quotient.</returns>
    public static Temperature operator /(Temperature a, double b)
    {
        return new Temperature(a.InScale(a.scale) / b, a.scale);
    }
    
    /// <summary>
    /// Multiplies a scalar by a <see cref="Temperature"/> instance.
    /// </summary>
    /// <param name="a">The scalar value.</param>
    /// <param name="b">The <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the product.</returns>
    public static Temperature operator *(double a, Temperature b)
    {
        return new Temperature(a * b.InScale(b.scale), b.scale);
    }
    
    /// <summary>
    /// Divides a scalar by a <see cref="Temperature"/> instance.
    /// </summary>
    /// <param name="a">The scalar value.</param>
    /// <param name="b">The <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the quotient.</returns>
    public static Temperature operator /(double a, Temperature b)
    {
        return new Temperature(a / b.InScale(b.scale), b.scale);
    }
    
    /// <summary>
    /// Increments a <see cref="Temperature"/> instance by 1.
    /// </summary>
    /// <param name="a">The <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the incremented value.</returns>
    public static Temperature operator ++(Temperature a)
    {
        return new Temperature(a.InScale(a.scale) + 1, a.scale);
    }
    
    /// <summary>
    /// Decrements a <see cref="Temperature"/> instance by 1.
    /// </summary>
    /// <param name="a">The <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the decremented value.</returns>
    public static Temperature operator --(Temperature a)
    {
        return new Temperature(a.InScale(a.scale) - 1, a.scale);
    }
    
    /// <summary>
    /// Adds a scalar to a <see cref="Temperature"/> instance.
    /// </summary>
    /// <param name="a">The <see cref="Temperature"/> instance.</param>
    /// <param name="b">The scalar value.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the sum.</returns>
    public static Temperature operator +(Temperature a, double b)
    {
        return new Temperature(a.InScale(a.scale) + b, a.scale);
    }
    
    /// <summary>
    /// Subtracts a scalar from a <see cref="Temperature"/> instance.
    /// </summary>
    /// <param name="a">The <see cref="Temperature"/> instance.</param>
    /// <param name="b">The scalar value.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the difference.</returns>
    public static Temperature operator -(Temperature a, double b)
    {
        return new Temperature(a.InScale(a.scale) - b, a.scale);
    }
    
    /// <summary>
    /// Adds a scalar to a <see cref="Temperature"/> instance.
    /// </summary>
    /// <param name="a">The scalar value.</param>
    /// <param name="b">The <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the sum.</returns>
    public static Temperature operator +(double a, Temperature b)
    {
        return new Temperature(a + b.InScale(b.scale), b.scale);
    }
    
    /// <summary>
    /// Subtracts a <see cref="Temperature"/> instance from a scalar.
    /// </summary>
    /// <param name="a">The scalar value.</param>
    /// <param name="b">The <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the difference.</returns>
    public static Temperature operator -(double a, Temperature b)
    {
        return new Temperature(a - b.InScale(b.scale), b.scale);
    }
    
    /// <summary>
    /// Computes the remainder of dividing one <see cref="Temperature"/> instance by another.
    /// </summary>
    /// <param name="a">The first <see cref="Temperature"/> instance.</param>
    /// <param name="b">The second <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the remainder.</returns>
    public static Temperature operator %(Temperature a, Temperature b)
    {
        return new Temperature(a.InScale(b.scale) % b.InScale(a.scale), a.scale);
    }
    
    /// <summary>
    /// Computes the remainder of dividing a <see cref="Temperature"/> instance by a scalar.
    /// </summary>
    /// <param name="a">The <see cref="Temperature"/> instance.</param>
    /// <param name="b">The scalar value.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the remainder.</returns>
    public static Temperature operator %(Temperature a, double b)
    {
        return new Temperature(a.InScale(a.scale) % b, a.scale);
    }
    
    /// <summary>
    /// Computes the remainder of dividing a scalar by a <see cref="Temperature"/> instance.
    /// </summary>
    /// <param name="a">The scalar value.</param>
    /// <param name="b">The <see cref="Temperature"/> instance.</param>
    /// <returns>A new <see cref="Temperature"/> instance representing the remainder.</returns>
    public static Temperature operator %(double a, Temperature b)
    {
        return new Temperature(a % b.InScale(b.scale), b.scale);
    }
    
    /// <summary>
    /// Determines whether the specified object is equal to the current <see cref="Temperature"/> instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current <see cref="Temperature"/> instance.</param>
    /// <returns>true if the specified object is equal to the current <see cref="Temperature"/> instance; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is Temperature other)
        {
            return this == other;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified <see cref="Temperature"/> instance is equal to the current <see cref="Temperature"/> instance.
    /// </summary>
    /// <param name="other">The <see cref="Temperature"/> instance to compare with the current <see cref="Temperature"/> instance.</param>
    /// <returns>true if the specified <see cref="Temperature"/> instance is equal to the current <see cref="Temperature"/> instance; otherwise, false.</returns>
    public bool Equals(Temperature other)
    {
        return this.temperature.Equals(other.temperature) && this.scale.Equals(other.scale);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current <see cref="Temperature"/> instance.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.temperature, this.scale);
    }
}
