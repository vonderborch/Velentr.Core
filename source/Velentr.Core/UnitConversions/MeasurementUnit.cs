namespace Velentr.Core.UnitConversions;

public abstract class MeasurementUnit
{
    public string Name { get; }
    
    public string Abbreviation { get; }
    
    public string MeasurementStringFormat { get; }
    
    protected internal MeasurementUnit(string name, string abbreviation, string measurementStringFormat)
    {
        Name = name;
        Abbreviation = abbreviation;
        MeasurementStringFormat = measurementStringFormat;
    }
    
    public abstract double ToBaseUnit(double value);
    
    public abstract double FromBaseUnit(double value);
}
