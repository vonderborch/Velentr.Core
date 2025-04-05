namespace Velentr.Core.UnitConversion.Heat;

public struct TemperatureScale(string name, string abbreviation) : IUnit, IEquatable<TemperatureScale>
{
    public static readonly TemperatureScale Celsius = new("Celsius", "°C")
    {
        ToCelsius = (x) => x,
        FromCelsius = (x) => x
    };
    
    public static readonly TemperatureScale Fahrenheit = new("Fahrenheit", "°F")
    {
        ToCelsius = (x) => (x - 32) * 5d / 9,
        FromCelsius = (x) => x * 9d / 5 + 32
    };
    
    public static readonly TemperatureScale Kelvin = new("Kelvin", "K")
    {
        ToCelsius = (x) => x - 273.15d,
        FromCelsius = (x) => x + 273.15d
    };
    
    public static readonly TemperatureScale Newton = new("Newton", "°N")
    {
        ToCelsius = (x) => x * 100d / 33,
        FromCelsius = (x) => x * 33d / 100
    };
    
    public static readonly TemperatureScale Rankine = new("Rankine", "°R")
    {
        ToCelsius = (x) => (x - 491.67d) * 5d / 9,
        FromCelsius = (x) => x * 9d / 5 + 491.67d
    };
    
    public static readonly TemperatureScale Réaumur = new("Réaumur", "°Ré")
    {
        ToCelsius = (x) => x * 5d / 4,
        FromCelsius = (x) => x * 4d / 5
    };
    
    public static readonly TemperatureScale Delisle = new("Delisle", "°De")
    {
        ToCelsius = (x) => 100 - x * 2d / 3,
        FromCelsius = (x) => (100 - x) * 3d / 2
    };
    
    public static readonly TemperatureScale Rømer = new("Rømer", "°Rø")
    {
        ToCelsius = (x) => (x - 7.5d) * 40d / 21,
        FromCelsius = (x) => x * 21d / 40 + 7.5d
    };
    
    public static readonly TemperatureScale GasMark = new("Gas Mark", "Mark")
    {
        ToCelsius = (x) => x * 14d / 25 + 120,
        FromCelsius = (x) => (x - 120) * 25d / 14
    };
    
    public static readonly TemperatureScale Leiden = new("Leiden", "°L")
    {
        ToCelsius = (x) => x * 100d / 33,
        FromCelsius = (x) => x * 33d / 100
    };
    
    public static readonly TemperatureScale Planck = new("Planck", "°P")
    {
        ToCelsius = (x) => x * 1.416808 * Math.Pow(10, -32),
        FromCelsius = (x) => x / (1.416808 * Math.Pow(10, -32))
    };
    
    public static readonly TemperatureScale Wedgwood = new("Wedgwood", "°W")
    {
        ToCelsius = (x) => x * 100d / 33,
        FromCelsius = (x) => x * 33d / 100
    };
    
    public string Name { get; } = name;

    public string Abbreviation { get; } = abbreviation;

    public Func<double, double> ToCelsius;
    
    public Func<double, double> FromCelsius;

    public bool Equals(TemperatureScale other)
    {
        return this.Name == other.Name && this.Abbreviation == other.Abbreviation;
    }

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
    
    public static bool operator ==(TemperatureScale a, TemperatureScale b)
    {
        return a.Equals(b);
    }
    
    public static bool operator !=(TemperatureScale a, TemperatureScale b)
    {
        return !a.Equals(b);
    }

    public override bool Equals(object? obj)
    {
        return obj is TemperatureScale other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Name, this.Abbreviation);
    }
    
    public override string ToString()
    {
        return this.Abbreviation;
    }

    public double ToUnit(TemperatureScale unit, double value)
    {
        return unit.FromCelsius(this.ToCelsius(value));
    }
}
