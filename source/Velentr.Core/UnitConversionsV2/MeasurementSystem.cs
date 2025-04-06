using Velentr.Core.UnitConversions;

namespace Velentr.Core.UnitConversionsV2;

public record MeasurementSystem<T> where T : Enum
{
    public required string Name;

    public required UnitOfMeasurementTypes Type;

    public required T DefaultUnit;

    public required Dictionary<T, MeasurementUnit> Units;
    
    public MeasurementSystem(string name, UnitOfMeasurementTypes type, T defaultUnit, Dictionary<T, MeasurementUnit> units)
    {
        this.Name = name;
        this.Type = type;
        this.DefaultUnit = defaultUnit;
        this.Units = units;
        
        object? unitsAttribute = typeof(T).GetCustomAttributes(typeof(MeasurementUnitAttribute<>), false).FirstOrDefault();
        if (unitsAttribute == null)
        {
            throw new ArgumentException($"The enum {typeof(T).Name} must have the UnitsAttribute attribute.");
        }
    }
    
    public Measure ConvertToBaseUnit(double value, T unit)
    {
        if (this.Units.TryGetValue(unit, out var unitOfMeasure))
        {
            Measure newMeasure = new();
            return unitOfMeasure.ToBaseUnit(value);
        }
        throw new ArgumentException($"Unit {unit} not found in measurement system {this.Name}.");
    }
    
    public Measure ConvertFromBaseUnit(double value, T unit)
    {
        if (this.Units.TryGetValue(unit, out var unitOfMeasure))
        {
            return unitOfMeasure.FromBaseUnit(value);
        }
        throw new ArgumentException($"Unit {unit} not found in measurement system {this.Name}.");
    }
    
    public Measure ConvertFromBaseUnitToMetricUnit(double value, T unit)
    {
        if (this.Units.TryGetValue(unit, out var unitOfMeasure))
        {
            return unitOfMeasure.FromBaseUnitToMetricUnit(value);
        }
        throw new ArgumentException($"Unit {unit} not found in measurement system {this.Name}.");
    }
}
