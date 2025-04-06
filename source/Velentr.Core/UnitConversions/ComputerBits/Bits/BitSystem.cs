namespace Velentr.Core.UnitConversions.ComputerBits.Bits;

[MeasurementTypeAttribute(scaleName: "Bits", measurementType: MeasurementTypes.ComputerBits, isMetricScale: true)]
public class BitSystem : MeasurementSystem<BitScale>
{

    public override double ToMetricBaseUnitFromBaseUnit(double value)
    {
        return value;
    }
}
