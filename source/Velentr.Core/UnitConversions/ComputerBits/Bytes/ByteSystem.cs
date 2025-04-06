namespace Velentr.Core.UnitConversions.ComputerBits.Bytes;

[MeasurementSystem(scaleName: "Bytes", measurementType: MeasurementTypes.ComputerBits, scale: typeof(ByteScale), isMetricScale: false)]
public class ByteSystem : MeasurementSystem
{
    protected internal ByteSystem(string name, MeasurementTypes measurementType, bool isMetricScale) : base(name, measurementType, isMetricScale)
    {
    }
    
    public override double ToMetricBaseUnitFromBaseUnit(double value)
    {
        return value / 8;
    }
}
