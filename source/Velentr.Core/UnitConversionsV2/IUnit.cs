namespace Velentr.Core.UnitConversionsV2;
    
/// <summary>
/// Represents a unit of measurement within a specific measurement system.
/// </summary>
/// <typeparam name="T">The type of the measurement system, constrained to Enum and IMeasurementSystem.</typeparam>
public interface IUnit<T> where T : Enum
{
    /// <summary>
    /// Gets the name of the unit of measurement.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the abbreviation of the unit of measurement.
    /// </summary>
    string Abbreviation { get; }

    /// <summary>
    /// Gets the type of the unit of measurement.
    /// </summary>
    UnitOfMeasurementTypes UnitType { get; }

    /// <summary>
    /// Gets the measurement system type of the unit.
    /// </summary>
    T Type { get; }

    /// <summary>
    /// Function to convert a value to the base unit of the measurement system.
    /// </summary>
    Func<double, double> ToBaseUnit { get; }

    /// <summary>
    /// Function to convert a value from the base unit of the measurement system.
    /// </summary>
    Func<double, double> FromBaseUnit { get; }

    /// <summary>
    /// Function to convert a value from the base unit to a metric unit.
    /// </summary>
    Func<double, double> FromBaseUnitToMetricUnit { get; }
    
    /// <summary>
    /// The format string used for displaying a measurement in this unit.
    /// Available placeholders:
    ///  - {0}: The value of the measurement.
    ///  - {1}: The unit of measure.
    ///  - {2}: The abbreviation of the unit of measure.
    /// </summary>
    string MeasurementStringFormat { get; }
}
