using System.Diagnostics;

namespace Velentr.Core.UnitConversionsV2;

[DebuggerDisplay("{Name} ({Abbreviation})")]
public abstract class Unit<TSelf, T> : IUnit<T> where T : struct, IMeasurementSystem<T>
    where TSelf : class
{
    /// <summary>
    /// The name of the unit of measure.
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// The abbreviation of the unit of measure.
    /// </summary>
    public readonly string Abbreviation;

    /// <summary>
    /// The type of the unit of measure.
    /// </summary>
    public readonly UnitOfMeasurementTypes MeasurementType;

    public readonly T Type;

    /// <summary>
    /// Function to convert a value to the base unit of the measurement system.
    /// </summary>
    public readonly Func<double, double> ToBaseUnit;
    
    /// <summary>
    /// Function to convert a value from the base unit of the measurement system.
    /// </summary>
    public readonly Func<double, double> FromBaseUnit;

    /// <summary>
    /// Function to convert a value from the base unit to a metric unit.
    /// </summary>
    public readonly Func<double, double> FromBaseUnitToMetricUnit;

    /// <summary>
    /// The format string used for displaying a measurement in this unit.
    /// Available placeholders:
    ///  - {0}: The value of the measurement.
    ///  - {1}: The unit of measure.
    ///  - {2}: The abbreviation of the unit of measure.
    /// </summary>
    public string MeasurementStringFormat = "{0} {2}";
    
    /// <summary>
    /// The instance of the unit of measure.
    /// </summary>
    protected static readonly Lazy<TSelf> Instance = new(() => (TSelf)Activator.CreateInstance(typeof(TSelf), true)!);

    protected Unit(string name,
        string abbreviation,
        T type,
        UnitOfMeasurementTypes measurementType,
        Func<double, double> toBaseUnit,
        Func<double, double> fromBaseUnit,
        Func<double, double> fromBaseUnitToMetricUnit)
    {
        this.Name = name;
        this.Abbreviation = abbreviation;
        this.Type = type;
        this.MeasurementType = measurementType;
        this.ToBaseUnit = toBaseUnit;
        this.FromBaseUnit = fromBaseUnit;
        this.FromBaseUnitToMetricUnit = fromBaseUnitToMetricUnit;
    }
    
    /// <summary>
    /// The instance of the unit of measure.
    /// </summary>
    public static TSelf OfMeasure => Instance.Value;

    /// <summary>
    /// Returns a string representation of the unit of measure.
    /// </summary>
    /// <returns>A string representing the unit of measure.</returns>
    public override string ToString()
    {
        return $"{this.Name} ({this.Abbreviation})";
    }

    /// <summary>
    /// Returns a hash code for the unit of measure.
    /// </summary>
    /// <returns>A hash code for the unit of measure.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Name, this.Abbreviation, this.Type, this.MeasurementType, this.ToBaseUnit, this.FromBaseUnit, this.FromBaseUnitToMetricUnit);
    }
}
