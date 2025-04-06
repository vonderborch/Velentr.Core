namespace Velentr.Core.UnitConversions.ComputerBits.Bits;

[UnitsAttribute<BitScale>(name: "Bit", abbreviation: "b", unit: BitScale.Bit, measurementStringFormat: "{0} {1}")]
public class Bit : Unit
{
    public override double ToBaseUnit(double value)
    {
        return value;
    }

    public override double FromBaseUnit(double value)
    {
        return value;
    }
}
