namespace Velentr.Core.UnitConversions;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class MeasurementUnitAttribute : Attribute
{
    public Type Scale;
    
    public string Name;

    public string Abbreviation;

    public string UnitName;

    public object Unit;

    public string MeasurementStringFormat;
    
    public MeasurementUnitAttribute(string name, string abbreviation, Type scale, string unit, string measurementStringFormat)
    {
        Scale = scale;
        Name = name;
        Abbreviation = abbreviation;
        UnitName = unit;
        Unit = Enum.Parse(scale, unit);
        MeasurementStringFormat = measurementStringFormat;
    }
    
    
}
