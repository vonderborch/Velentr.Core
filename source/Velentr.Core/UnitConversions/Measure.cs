using System.Text.Json.Serialization;

namespace Velentr.Core.UnitConversions;

public struct Measure<TUnit> where TUnit : Enum
{
    [JsonIgnore]
    private double value;

    public Measure(double value, MeasurementSystem system, TUnit unit)
    {
        this.value = value;
        this.MeasurementSystemName = system.ScaleName;
        this.System = system;
        this.Unit = unit;
    }
    
    [JsonConstructor]
    internal Measure(double value, string system, TUnit unit, MeasurementTypes measurementType)
    {
        this.value = value;
        this.MeasurementSystemName = system;
        this.System = Measurements.GetMeasurementSystem(measurementType, system);
        this.Unit = unit;
    }
    
    [JsonPropertyName("value")]
    public double Value => this.value;
    
    [JsonPropertyName("value")]
    public string MeasurementSystemName { get; }
    
    [JsonIgnore]
    public MeasurementSystem System { get; }
    
    [JsonPropertyName("unit")]
    public TUnit Unit { get; }
    
    [JsonIgnore]
    public MeasurementTypes MeasurementType => this.System.MeasurementType;
    
    [JsonPropertyName("measurementType")]
    public MeasurementTypes MeasurementTypeName => this.System.MeasurementType;
}
