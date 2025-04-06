namespace Velentr.Core.UnitConversions;

public abstract class MeasurementSystem<T> where T : Enum
{
    protected readonly Dictionary<string, T> nameToTypeMapping;
    
    protected readonly Dictionary<T, string> typeToNameMapping;

    protected readonly Dictionary<T, Unit> units;
    
    protected MeasurementSystem()
    {
        
    }
    
    public abstract double ToMetricBaseUnitFromBaseUnit(double value);
}
