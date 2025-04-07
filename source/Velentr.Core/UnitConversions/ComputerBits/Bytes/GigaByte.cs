namespace Velentr.Core.UnitConversions.ComputerBits.Bytes;

/// <summary>
/// Represents the Gigabyte unit of measurement.
/// </summary>
public class GigaByte : Singleton<GigaByte>, IComputerBit
{
    /// <summary>
    /// Gets the name of the unit.
    /// </summary>
    public string Name => "GigaByte";

    /// <summary>
    /// Gets the abbreviation of the unit.
    /// </summary>
    public string Abbreviation => "GB";
    
    /// <summary>
    /// Gets the format string for displaying the measurement.
    /// </summary>
    public string MeasurementStringFormat => "{0} {1}";
    
    /// <summary>
    /// Gets the scale type of the unit.
    /// </summary>
    public Type Scale => typeof(ByteScale);

    /// <summary>
    /// Gets the full name of the unit.
    /// </summary>
    public string UnitName => "Gigabyte";
    
    /// <summary>
    /// Gets a value indicating whether this unit is the base unit in the scale.
    /// </summary>
    public bool IsBaseUnitInScale => false;

    /// <summary>
    /// Gets the base size of the unit.
    /// </summary>
    public int BaseSize => ComputerBitConstants.ByteBaseSize;

    /// <summary>
    /// Gets the singleton instance of the unit.
    /// </summary>
    public IMeasurementUnit SingletonInstance => Instance;

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
}
