namespace Velentr.Core.UnitConversions;
    
/// <summary>
/// Represents a measurement system interface.
/// </summary>
public interface IMeasurementSystem : ISingleton<IMeasurementSystem>
{
    /// <summary>
    /// Gets the name of the scale.
    /// </summary>
    string ScaleName => this.Scale.Name;

    /// <summary>
    /// Gets the type of the measurement.
    /// </summary>
    string MeasurementType { get; }

    /// <summary>
    /// Indicates whether the scale is a metric scale.
    /// </summary>
    public bool IsMetricScale => false;

    /// <summary>
    /// Gets the type of the scale.
    /// </summary>
    Type Scale { get; }

    /// <summary>
    /// Converts a value from the base unit to the metric base unit.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value in metric base units.</returns>
    double ToMetricBaseUnitFromBaseUnit(double value);
}
