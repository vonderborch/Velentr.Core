namespace Velentr.Core.UnitConversions;
    
/// <summary>
/// Represents a unit of measurement.
/// </summary>
public interface IMeasurementUnit : ISingleton<IMeasurementUnit>
{
    /// <summary>
    /// Gets the name of the unit.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the abbreviation of the unit.
    /// </summary>
    string Abbreviation { get; }

    /// <summary>
    /// Gets the format string for displaying the measurement.
    /// </summary>
    string MeasurementStringFormat { get; }

    /// <summary>
    /// Gets the type of the scale associated with the unit.
    /// </summary>
    Type Scale { get; }

    /// <summary>
    /// Gets the name of the unit as defined in the scale.
    /// </summary>
    string UnitName { get; }

    /// <summary>
    /// Indicates whether the unit is the base unit in its scale.
    /// </summary>
    public bool IsBaseUnitInScale => false;

    /// <summary>
    /// Gets the unit as an enum value.
    /// </summary>
    object Unit => Enum.Parse(this.Scale, this.UnitName);

    /// <summary>
    /// Converts a value to the base unit of the scale.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value in the base unit.</returns>
    double ToBaseUnit(double value);

    /// <summary>
    /// Converts a value from the base unit of the scale.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value from the base unit.</returns>
    double FromBaseUnit(double value);
}
