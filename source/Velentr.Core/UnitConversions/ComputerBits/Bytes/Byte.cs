namespace Velentr.Core.UnitConversions.ComputerBits.Bytes;

[MeasurementUnit(name: "Byte", abbreviation: "B", scale: typeof(ByteScale), unit: "Byte", measurementStringFormat: "{0} {1}")]
public class Byte : MeasurementUnit
{
    protected internal Byte(string name, string abbreviation, string measurementStringFormat) : base(name, abbreviation, measurementStringFormat)
    {
    }
    
    public override double ToBaseUnit(double value)
    {
        return value;
    }

    public override double FromBaseUnit(double value)
    {
        return value;
    }
}
