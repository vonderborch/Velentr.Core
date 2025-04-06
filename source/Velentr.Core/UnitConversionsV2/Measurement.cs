using System.Diagnostics;

namespace Velentr.Core.UnitConversionsV2;

[DebuggerDisplay("{Value} {Unit.Abbreviation}")]
public struct Measurement<T> : IMeasurementSystem<T> where T : Enum
{
    public double Value;

    public readonly UnitOfMeasurementTypes UnitType;
    
    public readonly IUnit<T> Unit { get; }
    
    public readonly MeasurementSystem<T> MeasurementSystem;
}
