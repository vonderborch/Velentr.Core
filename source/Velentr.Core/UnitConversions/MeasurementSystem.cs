using System.Reflection;

namespace Velentr.Core.UnitConversions;

public abstract class MeasurementSystem
{
    public string ScaleName { get; }
    
    public MeasurementTypes MeasurementType { get; }
    
    public bool IsMetricScale { get; }
    public Type ScaleType { get; }
    
    protected readonly Dictionary<string, object> NameToTypeMapping;
    
    protected readonly Dictionary<object, string> TypeToNameMapping;

    protected readonly Dictionary<object, MeasurementUnit> Units;

    protected internal MeasurementSystem(string scaleName, MeasurementTypes measurementType, Type scaleType, bool isMetricScale)
    {
        this.ScaleName = scaleName;
        this.MeasurementType = measurementType;
        this.IsMetricScale = isMetricScale;
        this.ScaleType = scaleType;
        
        this.NameToTypeMapping = new();
        this.TypeToNameMapping = new();
        this.Units = new();

        var measurementUnitType = typeof(MeasurementUnitAttribute);
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var assemblyTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.IsDefined(measurementUnitType) && t.IsSubclassOf(typeof(MeasurementUnit))).ToList();

        foreach (var unit in assemblyTypes)
        {
            MeasurementUnitAttribute unitInfo = (MeasurementUnitAttribute)unit.GetCustomAttribute(measurementUnitType, false)!;
            if (unitInfo.Scale != this.ScaleType)
            {
                continue;
            }
            
            if (this.TypeToNameMapping.ContainsKey(unitInfo.Unit))
            {
                throw new Exception($"Duplicate unit type found: {unitInfo.Unit}");
            }
            if (this.NameToTypeMapping.ContainsKey(unitInfo.Name))
            {
                throw new Exception($"Duplicate unit name found: {unitInfo.Name}");
            }
            if (unitInfo.Scale != this.ScaleType)
            {
                throw new Exception($"Unit scale type mismatch: {unitInfo.Scale} != {this.ScaleType}");
            }
            
            NameToTypeMapping.Add(unitInfo.Name, unitInfo.Unit);
            TypeToNameMapping.Add(unitInfo.Unit, unitInfo.Name);
            
            MeasurementUnit measurementUnitInstance = (MeasurementUnit)Activator.CreateInstance(unit, unitInfo.Name, unitInfo.Abbreviation, unitInfo.MeasurementStringFormat)!;
            this.Units[unitInfo.Unit] = measurementUnitInstance;
        }
    }

    public double ToBaseUnit(double value, object unit)
    {
        return this.Units[unit].ToBaseUnit(value);
    }
    
    public double FromBaseUnit(double value, object unit)
    {
        return this.Units[unit].FromBaseUnit(value);
    }
    
    public abstract double ToMetricBaseUnitFromBaseUnit(double value);
}
