namespace Velentr.Core.UnitConversions.ComputerBits.Bits;

/// <summary>
/// Represents the GigaBit unit of measurement.
/// </summary>
public class GigaBit : Singleton<GigaBit>, IComputerBit
{
    /// <summary>
    /// Gets the name of the unit.
    /// </summary>
    public string Name => "GigaBit";

    /// <summary>
    /// Gets the abbreviation of the unit.
    /// </summary>
    public string Abbreviation => "Gb";

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
    public string UnitName => "GigaBit";

    /// <summary>
    /// Gets a value indicating whether this unit is the base unit in the scale.
    /// </summary>
    public bool IsBaseUnitInScale => false;

    /// <summary>
    /// Gets the base size of the unit.
    /// </summary>
    public int BaseSize => ComputerBitConstants.BitBaseSize;

    /// <summary>
    /// Converts the specified value to the base unit (bits).
    /// </summary>
    /// <param name="value">The value in GigaBits.</param>
    /// <returns>The value in bits.</returns>
    public double ToBaseUnit(double value)
    {
        return ((IComputerBit)this).Convert(value, true);
    }

    /// <summary>
    /// Converts the specified value from the base unit (bits) to GigaBits.
    /// </summary>
    /// <param name="value">The value in bits.</param>
    /// <returns>The value in GigaBits.</returns>
    public double FromBaseUnit(double value)
    {
        return ((IComputerBit)this).Convert(value, false);
    }

    /// <summary>
    /// Gets the singleton instance of the GigaBit unit.
    /// </summary>
    public IMeasurementUnit SingletonInstance => Instance;
}
