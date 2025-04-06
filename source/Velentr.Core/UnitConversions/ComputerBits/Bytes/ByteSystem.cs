namespace Velentr.Core.UnitConversions.ComputerBits.Bytes;

[MeasurementTypeAttribute(scaleName: "Bytes", measurementType: MeasurementTypes.ComputerBits, isMetricScale: false)]
public class ByteSystem : MeasurementSystem<ByteScale>
{
    public override double ToMetricBaseUnitFromBaseUnit(double value)
    {
        return value / 8;
    }
}
