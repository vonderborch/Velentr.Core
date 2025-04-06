namespace Velentr.Core.UnitConversions;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class UnitsAttribute<TUnit> : Attribute where TUnit : Enum
{
    public Type Scale;
    
    public string Name;

    public string Abbreviation;

    public TUnit Unit;

    public string MeasurementStringFormat;
    
    public UnitsAttribute(string name, string abbreviation, TUnit unit, string measurementStringFormat)
    {
        Scale = typeof(TUnit);
        Name = name;
        Abbreviation = abbreviation;
        Unit = unit;
        MeasurementStringFormat = measurementStringFormat;
    }
}
