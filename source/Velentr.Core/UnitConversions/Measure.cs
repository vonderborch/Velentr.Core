using System.Text.Json.Serialization;

namespace Velentr.Core.UnitConversions;

public struct Measure<TUnit> where TUnit : Enum
{
    [JsonIgnore]
    private double value;

    internal Measure(double value, IMeasurementSystem system, TUnit unit)
    {
        this.value = value;
        this.MeasurementSystemName = system.ScaleName;
        this.System = system;
        this.Unit = unit;
        this.MeasurementUnit = Measurements.GetUnit(unit);
    }
    
    [JsonConstructor]
    private Measure(double value, string system, TUnit unit, string measurementType)
    {
        this.value = value;
        this.MeasurementSystemName = system;
        this.System = Measurements.GetMeasurementSystem(measurementType, system);
        this.Unit = unit;
        this.MeasurementUnit = Measurements.GetUnit(unit);
    }
    
    internal Measure(Measure<TUnit> parent) : this(parent.value, parent.System, parent.Unit)
    {
    }
    
    [JsonPropertyName("value")]
    public double Value => this.value;
    
    [JsonPropertyName("value")]
    public string MeasurementSystemName { get; }
    
    [JsonIgnore]
    public IMeasurementSystem System { get; }
    
    [JsonPropertyName("unit")]
    public TUnit Unit { get; }
    
    [JsonIgnore]
    public IMeasurementUnit MeasurementUnit { get; }
    
    [JsonPropertyName("measurementType")]
    public string MeasurementType => this.System.MeasurementType;

    public Measure<TUnit> ConvertTo(TUnit unit)
    {
        var targetUnit = Measurements.GetUnit(this.Unit);

        if (targetUnit.Unit == (object)Unit)
        {
            return new Measure<TUnit>(this.value, System, Unit);
        }

        var asBaseValue = MeasurementUnit.SingletonInstance.ToBaseUnit(value);
        var asTargetValue = targetUnit.SingletonInstance.FromBaseUnit(asBaseValue);
        return new Measure<TUnit>(asTargetValue, System, unit);
    }
    
    public override string ToString()
    {
        return string.Format(this.MeasurementUnit.MeasurementStringFormat, this.value, this.MeasurementUnit.Name, this.MeasurementUnit.Abbreviation);
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Measure<TUnit> other)
        {
            if (other.System.Scale == System.Scale)
            {
                var asBaseValue = MeasurementUnit.SingletonInstance.ToBaseUnit(value);
                var asOtherBaseValue = other.MeasurementUnit.SingletonInstance.ToBaseUnit(other.value);
                return asBaseValue.Equals(asOtherBaseValue);
            }
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(this.value, this.Unit);
    }
    
    public static bool operator ==(Measure<TUnit> left, Measure<TUnit> right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(Measure<TUnit> left, Measure<TUnit> right)
    {
        return !left.Equals(right);
    }
    
    public static bool operator <(Measure<TUnit> left, Measure<TUnit> right)
    {
        if (left.System.Scale == right.System.Scale)
        {
            var asBaseValue = left.MeasurementUnit.SingletonInstance.ToBaseUnit(left.value);
            var asOtherBaseValue = right.MeasurementUnit.SingletonInstance.ToBaseUnit(right.value);
            return asBaseValue < asOtherBaseValue;
        }
        throw new InvalidOperationException("Cannot compare measures from different scales.");
    }
    
    
    
    public static implicit operator double(Measure<TUnit> measure)
    {
        return measure.value;
    }
    
    public static implicit operator Measure<TUnit>(double value)
    {
        return new Measure<TUnit>(value, Measurements.GetMeasurementSystem(typeof(TUnit).Name, typeof(TUnit).Name), (TUnit)Enum.ToObject(typeof(TUnit), 0));
    }
    
    
    
}
