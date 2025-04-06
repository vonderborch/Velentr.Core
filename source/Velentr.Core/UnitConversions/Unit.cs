namespace Velentr.Core.UnitConversions;

public abstract class Unit
{
    public abstract double ToBaseUnit(double value);
    
    public abstract double FromBaseUnit(double value);
}
