namespace Velentr.Core.UnitConversions.ComputerBits.Bits;

/// <summary>
/// Represents the PetaBit unit of measurement.
/// </summary>
public class PetaBit : Singleton<PetaBit>, IComputerBit
{
    /// <summary>
    /// Gets the name of the unit.
    /// </summary>
    public string Name => "PetaBit";

    /// <summary>
    /// Gets the abbreviation of the unit.
    /// </summary>
    public string Abbreviation => "Pb";

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
    public string UnitName => "PetaBit";

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
    /// <param name="value">The value in PetaBits.</param>
    /// <returns>The value in bits.</returns>
    public double ToBaseUnit(double value)
    {
        return ((IComputerBit)this).Convert(value, true);
    }

    /// <summary>
    /// Converts the specified value from the base unit (bits) to PetaBits.
    /// </summary>
    /// <param name="value">The value in bits.</param>
    /// <returns>The value in PetaBits.</returns>
    public double FromBaseUnit(double value)
    {
        return ((IComputerBit)this).Convert(value, false);
    }

    /// <summary>
    /// Gets the singleton instance of the PetaBit unit.
    /// </summary>
    public IMeasurementUnit SingletonInstance => Instance;
}
