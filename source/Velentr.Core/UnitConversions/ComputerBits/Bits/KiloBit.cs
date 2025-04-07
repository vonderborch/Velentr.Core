namespace Velentr.Core.UnitConversions.ComputerBits.Bits;

/// <summary>
/// Represents the KiloBit unit of measurement.
/// </summary>
public class KiloBit : Singleton<KiloBit>, IComputerBit
{
    /// <summary>
    /// Gets the name of the unit.
    /// </summary>
    public string Name => "KiloBit";

    /// <summary>
    /// Gets the abbreviation of the unit.
    /// </summary>
    public string Abbreviation => "Kb";
    
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
    public string UnitName => "KiloBit";
    
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
        return ((IComputerBit)this).Convert(value, true);
    }

    /// <summary>
    /// Converts the specified value from the base unit.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted value from the base unit.</returns>
    public double FromBaseUnit(double value)
    {
        return ((IComputerBit)this).Convert(value, false);
    }

    /// <summary>
    /// Gets the singleton instance of the KiloBit unit.
    /// </summary>
    public IMeasurementUnit SingletonInstance => Instance;
}
