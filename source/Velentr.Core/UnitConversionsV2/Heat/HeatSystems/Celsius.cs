namespace Velentr.Core.UnitConversionsV2.Heat.HeatSystems;

public class Celsius : Unit<Celsius, TemperatureUnits>
{
    private Celsius() : base(
        name: "Celsius",
        abbreviation:"°C",
        type: TemperatureUnits.Celsius,
        measurementType: UnitOfMeasurementTypes.Temperature,
        fromBaseUnit: x => x, 
        toBaseUnit: x => x,
        fromBaseUnitToMetricUnit: x => x
        )
    {
    }
}
