namespace Velentr.Core.UnitConversions.ComputerBits.Bits;

/// <summary>
/// Represents the system for computer bit measurements.
/// </summary>
public class BitSystem : Singleton<BitSystem>, IMeasurementSystem
{
    /// <summary>
    /// Gets the type of measurement.
    /// </summary>
    public string MeasurementType => MeasurementTypes.ComputerBits.ToString();

    /// <summary>
    /// Gets the scale type of the measurement system.
    /// </summary>
    public Type Scale => typeof(BitScale);
    
    /// <summary>
    /// Gets a value indicating whether the scale is metric.
    /// </summary>
    public bool IsMetricScale => true;

    /// <summary>
    /// Converts the specified value to the metric base unit from the base unit.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value in the metric base unit.</returns>
    public double ToMetricBaseUnitFromBaseUnit(double value)
    {
        return value;
    }

    /// <summary>
    /// Gets the singleton instance of the BitSystem.
    /// </summary>
    public IMeasurementSystem SingletonInstance => Instance;
}

