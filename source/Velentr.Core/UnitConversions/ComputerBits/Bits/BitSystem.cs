namespace Velentr.Core.UnitConversions.ComputerBits.Bits;

[MeasurementSystem(scaleName: "Bits", measurementType: MeasurementTypes.ComputerBits, scale: typeof(BitScale), isMetricScale: true)]
public class BitSystem : MeasurementSystem
{
    protected internal BitSystem(string name, MeasurementTypes measurementType, bool isMetricScale) : base(name, measurementType, isMetricScale)
    {
    }

    public override double ToMetricBaseUnitFromBaseUnit(double value)
    {
        return value;
    }
}
