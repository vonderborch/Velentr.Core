namespace Velentr.Core.UnitConversions.ComputerBits.Bytes;

/// <summary>
/// Represents the byte measurement system.
/// </summary>
public class ByteSystem : Singleton<ByteSystem>, IMeasurementSystem
{
    /// <summary>
    /// Gets the type of the measurement.
    /// </summary>
    public string MeasurementType => MeasurementTypes.ComputerBits.ToString();

    /// <summary>
    /// Gets the type of the scale.
    /// </summary>
    public Type Scale => typeof(ByteScale);

    /// <summary>
    /// Converts a value from the base unit to the metric base unit.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value in metric base units.</returns>
    public double ToMetricBaseUnitFromBaseUnit(double value)
    {
        return value / 8;
    }

    /// <summary>
    /// Gets the singleton instance of the measurement system.
    /// </summary>
    public IMeasurementSystem SingletonInstance => Instance;
}
