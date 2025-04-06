namespace Velentr.Core.UnitConversion.Heat;

/// <summary>
/// Represents a temperature scale and provides methods to convert to and from Celsius.
/// </summary>
public struct TemperatureScale(string name, string abbreviation) : IUnit, IEquatable<TemperatureScale>
{
    /// <summary>
    /// Represents the Celsius temperature scale.
    /// </summary>
    public static readonly TemperatureScale Celsius = new("Celsius", "°C")
    {
        ToCelsius = (x) => x,
        FromCelsius = (x) => x
    };
    
    /// <summary>
    /// Represents the Fahrenheit temperature scale.
    /// </summary>
    public static readonly TemperatureScale Fahrenheit = new("Fahrenheit", "°F")
    {
        ToCelsius = (x) => (x - 32) * 5d / 9,
        FromCelsius = (x) => x * 9d / 5 + 32
    };
    
    /// <summary>
    /// Represents the Kelvin temperature scale.
    /// </summary>
    public static readonly TemperatureScale Kelvin = new("Kelvin", "K")
    {
        ToCelsius = (x) => x - 273.15d,
        FromCelsius = (x) => x + 273.15d
    };
    
    /// <summary>
    /// Represents the Newton temperature scale.
    /// </summary>
    public static readonly TemperatureScale Newton = new("Newton", "°N")
    {
        ToCelsius = (x) => x * 100d / 33,
        FromCelsius = (x) => x * 33d / 100
    };
    
    /// <summary>
    /// Represents the Rankine temperature scale.
    /// </summary>
    public static readonly TemperatureScale Rankine = new("Rankine", "°R")
    {
        ToCelsius = (x) => (x - 491.67d) * 5d / 9,
        FromCelsius = (x) => x * 9d / 5 + 491.67d
    };
    
    /// <summary>
    /// Represents the Réaumur temperature scale.
    /// </summary>
    public static readonly TemperatureScale Réaumur = new("Réaumur", "°Ré")
    {
        ToCelsius = (x) => x * 5d / 4,
        FromCelsius = (x) => x * 4d / 5
    };
    
    /// <summary>
    /// Represents the Delisle temperature scale.
    /// </summary>
    public static readonly TemperatureScale Delisle = new("Delisle", "°De")
    {
        ToCelsius = (x) => 100 - x * 2d / 3,
        FromCelsius = (x) => (100 - x) * 3d / 2
    };
    
    /// <summary>
    /// Represents the Rømer temperature scale.
    /// </summary>
    public static readonly TemperatureScale Rømer = new("Rømer", "°Rø")
    {
        ToCelsius = (x) => (x - 7.5d) * 40d / 21,
        FromCelsius = (x) => x * 21d / 40 + 7.5d
    };
    
    /// <summary>
    /// Represents the Gas Mark temperature scale.
    /// </summary>
    public static readonly TemperatureScale GasMark = new("Gas Mark", "Mark")
    {
        ToCelsius = (x) => x * 14d / 25 + 120,
        FromCelsius = (x) => (x - 120) * 25d / 14
    };
    
    /// <summary>
    /// Represents the Leiden temperature scale.
    /// </summary>
    public static readonly TemperatureScale Leiden = new("Leiden", "°L")
    {
        ToCelsius = (x) => x * 100d / 33,
        FromCelsius = (x) => x * 33d / 100
    };
    
    /// <summary>
    /// Represents the Planck temperature scale.
    /// </summary>
    public static readonly TemperatureScale Planck = new("Planck", "°P")
    {
        ToCelsius = (x) => x * 1.416808 * Math.Pow(10, -32),
        FromCelsius = (x) => x / (1.416808 * Math.Pow(10, -32))
    };
    
    /// <summary>
    /// Represents the Wedgwood temperature scale.
    /// </summary>
    public static readonly TemperatureScale Wedgwood = new("Wedgwood", "°W")
    {
        ToCelsius = (x) => x * 100d / 33,
        FromCelsius = (x) => x * 33d / 100
    };
    
    /// <summary>
    /// Gets the name of the temperature scale.
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// Gets the abbreviation of the temperature scale.
    /// </summary>
    public string Abbreviation { get; } = abbreviation;

    /// <summary>
    /// Function to convert a value from this scale to Celsius.
    /// </summary>
    public Func<double, double> ToCelsius;
    
    /// <summary>
    /// Function to convert a value from Celsius to this scale.
    /// </summary>
    public Func<double, double> FromCelsius;

    /// <summary>
    /// Determines whether the specified TemperatureScale is equal to the current TemperatureScale.
    /// </summary>
    /// <param name="other">The TemperatureScale to compare with the current TemperatureScale.</param>
    /// <returns>true if the specified TemperatureScale is equal to the current TemperatureScale; otherwise, false.</returns>
    public bool Equals(TemperatureScale other)
    {
        return this.Name == other.Name && this.Abbreviation == other.Abbreviation;
    }

    /// <summary>
    /// Determines whether the specified IUnit is equal to the current TemperatureScale.
    /// </summary>
    /// <param name="other">The IUnit to compare with the current TemperatureScale.</param>
    /// <returns>true if the specified IUnit is equal to the current TemperatureScale; otherwise, false.</returns>
    public bool Equals(IUnit? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other is TemperatureScale otherByteUnit)
        {
            return Equals(otherByteUnit);
        }

        return false;
    }
    
    /// <summary>
    /// Determines whether two specified instances of TemperatureScale are equal.
    /// </summary>
    /// <param name="a">The first TemperatureScale to compare.</param>
    /// <param name="b">The second TemperatureScale to compare.</param>
    /// <returns>true if a and b represent the same TemperatureScale; otherwise, false.</returns>
    public static bool operator ==(TemperatureScale a, TemperatureScale b)
    {
        return a.Equals(b);
    }
    
    /// <summary>
    /// Determines whether two specified instances of TemperatureScale are not equal.
    /// </summary>
    /// <param name="a">The first TemperatureScale to compare.</param>
    /// <param name="b">The second TemperatureScale to compare.</param>
    /// <returns>true if a and b do not represent the same TemperatureScale; otherwise, false.</returns>
    public static bool operator !=(TemperatureScale a, TemperatureScale b)
    {
        return !a.Equals(b);
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current TemperatureScale.
    /// </summary>
    /// <param name="obj">The object to compare with the current TemperatureScale.</param>
    /// <returns>true if the specified object is equal to the current TemperatureScale; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        return obj is TemperatureScale other && Equals(other);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current TemperatureScale.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Name, this.Abbreviation);
    }
    
    /// <summary>
    /// Returns a string that represents the current TemperatureScale.
    /// </summary>
    /// <returns>A string that represents the current TemperatureScale.</returns>
    public override string ToString()
    {
        return this.Abbreviation;
    }

    /// <summary>
    /// Converts a value from this scale to another specified temperature scale.
    /// </summary>
    /// <param name="unit">The target temperature scale.</param>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value in the target temperature scale.</returns>
    public double ToUnit(TemperatureScale unit, double value)
    {
        return unit.FromCelsius(this.ToCelsius(value));
    }
}

