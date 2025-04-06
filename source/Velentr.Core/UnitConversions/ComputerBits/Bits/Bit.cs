namespace Velentr.Core.UnitConversions.ComputerBits.Bits;

[MeasurementUnit(name: "Bit", abbreviation: "b", scale: typeof(BitScale), unit: "Bit", measurementStringFormat: "{0} {1}")]
public class Bit : MeasurementUnit
{
    protected internal Bit(string name, string abbreviation, string measurementStringFormat) : base(name, abbreviation, measurementStringFormat)
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
