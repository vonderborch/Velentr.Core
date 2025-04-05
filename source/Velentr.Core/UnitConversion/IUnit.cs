namespace Velentr.Core.UnitConversion;

public interface IUnit : IEquatable<IUnit>
{
    string Name { get; }
    
    string Abbreviation { get; }
}
