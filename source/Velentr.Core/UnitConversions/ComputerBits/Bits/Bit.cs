namespace Velentr.Core.UnitConversions.ComputerBits.Bits;

/// <summary>
/// Represents the Bit unit of measurement.
/// </summary>
public class Bit : Singleton<Bit>, IComputerBit
{
    /// <summary>
    /// Gets the name of the unit.
    /// </summary>
    public string Name => "Bit";

    /// <summary>
    /// Gets the abbreviation of the unit.
    /// </summary>
    public string Abbreviation => "b";
    
    /// <summary>
    /// Gets the format string for displaying the measurement.
    /// </summary>
    public string MeasurementStringFormat => "{0} {1}";
    
    /// <summary>
    /// Gets the scale type of the unit.
    /// </summary>
    public Type Scale => typeof(BitScale);

    /// <summary>
    /// Gets the unit name.
    /// </summary>
    public string UnitName => "Bit";
    
    /// <summary>
    /// Gets a value indicating whether this unit is the base unit in the scale.
    /// </summary>
    public bool IsBaseUnitInScale => true;

    /// <summary>
    /// Gets the base size of the unit.
    /// </summary>
    public int BaseSize => ComputerBitConstants.BitBaseSize;

    /// <summary>
    /// Converts the specified value to the base unit.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value in the base unit.</returns>
    public double ToBaseUnit(double value)
    {
        return value;
    }

    /// <summary>
    /// Converts the specified value from the base unit.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value from the base unit.</returns>
    public double FromBaseUnit(double value)
    {
        return value;
    }

    /// <summary>
    /// Gets the singleton instance of the Bit unit.
    /// </summary>
    public IMeasurementUnit SingletonInstance => Instance;
}

