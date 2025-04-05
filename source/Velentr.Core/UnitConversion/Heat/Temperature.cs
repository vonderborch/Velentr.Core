using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Velentr.Core.UnitConversion.Heat;

[DebuggerDisplay("{Value} {Unit}")]
public struct Temperature
{
    [JsonIgnore]
    private double temperature;
    
    [JsonIgnore]
    private TemperatureScale scale;
    
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
    
    [JsonPropertyName("value")]
    public double Value
    {
        get => temperature;
        set => temperature = value;
    }
    
    [JsonPropertyName("scale")]
    public TemperatureScale Scale
    {
        get => scale;
    }
    
    public double InScale(TemperatureScale toScale)
    {
        return toScale.FromCelsius(this.scale.ToCelsius(this.temperature));
    }
    
    public Temperature ToScale(TemperatureScale toScale)
    {
        return new Temperature(InScale(TemperatureScale.Celsius), toScale);
    }
    
    public static bool operator ==(Temperature a, Temperature b)
    {
        return a.scale == b.scale && a.temperature == b.temperature;
    }
    
    public static bool operator !=(Temperature a, Temperature b)
    {
        return !(a == b);
    }
    
    public static Temperature operator +(Temperature a, Temperature b)
    {
        return new Temperature(a.InScale(b.scale) + b.InScale(a.scale), a.scale);
    }
    
    public static Temperature operator -(Temperature a, Temperature b)
    {
        return new Temperature(a.InScale(b.scale) - b.InScale(a.scale), a.scale);
    }
    
    public static Temperature operator *(Temperature a, double b)
    {
        return new Temperature(a.InScale(a.scale) * b, a.scale);
    }
    
    public static Temperature operator /(Temperature a, double b)
    {
        return new Temperature(a.InScale(a.scale) / b, a.scale);
    }
    
    public static Temperature operator *(double a, Temperature b)
    {
        return new Temperature(b.InScale(b.scale) * a, b.scale);
    }
    
    public static override bool Equals(object? obj)
    {
        if (obj is Temperature other)
        {
            return this == other;
        }

        return false;
    }
}
