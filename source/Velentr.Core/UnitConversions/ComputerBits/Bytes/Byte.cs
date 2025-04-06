namespace Velentr.Core.UnitConversions.ComputerBits.Bytes;

[UnitsAttribute<ByteScale>(name: "Byte", abbreviation: "B", unit: ByteScale.Byte, measurementStringFormat: "{0} {1}")]
public class Byte : Unit
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
