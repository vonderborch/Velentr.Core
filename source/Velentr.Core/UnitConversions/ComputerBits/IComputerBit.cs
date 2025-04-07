namespace Velentr.Core.UnitConversions.ComputerBits;
    
/// <summary>
/// Represents a computer bit unit of measurement.
/// </summary>
public interface IComputerBit : IMeasurementUnit
{
    /// <summary>
    /// Gets the power of the unit.
    /// </summary>
    public int Power => (int)this.Unit;

    /// <summary>
    /// Gets the base size of the unit.
    /// </summary>
    int BaseSize { get; }

    /// <summary>
    /// Gets the factor for conversion based on the base size and power.
    /// </summary>
    public double Factor => Math.Pow(BaseSize, Power);

    /// <summary>
    /// Converts a value to or from the base unit.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="toBaseUnit">Indicates whether to convert to the base unit.</param>
    /// <returns>The converted value.</returns>
    public double Convert(double value, bool toBaseUnit)
    {
        if (Power == 1)
        {
            return value;
        }
        return toBaseUnit
            ? value * Factor
            : value / Factor;
    }
}
