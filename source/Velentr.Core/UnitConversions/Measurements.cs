using System.Reflection;

namespace Velentr.Core.UnitConversions;

public static class Measurements
{
    private static Dictionary<MeasurementTypes, string> metricSystems;
    
    private static Dictionary<MeasurementTypes, Dictionary<string, MeasurementSystem>> measurementSystems;

    private static Dictionary<Type, Tuple<MeasurementTypes, string>> measurementUnitMapping;
    
    static Measurements()
    {
        metricSystems = new();
        measurementUnitMapping = new();
        measurementSystems = new();
        foreach (var measurementType in Enum.GetValues(typeof(MeasurementTypes)).Cast < MeasurementTypes())
        {
            measurementSystems[measurementType] = new();
        }
        
        // Look for all measurement systems
        var measurementUnitType = typeof(MeasurementUnitAttribute);
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var assemblyTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.IsDefined(measurementUnitType, false) && t.IsSubclassOf(typeof(MeasurementSystem))).ToList();
        
        foreach (var assemblyType in assemblyTypes)
        {
            var systemInfo = (MeasurementSystemAttribute)assemblyType.GetCustomAttribute(MeasurementSystemAttribute, false)!;
            if (systemInfo.IsMetricScale)
            {
                if (metricSystems.ContainsKey(systemInfo.MeasurementType))
                {
                    throw new Exception($"Duplicate metric system found: {systemInfo.ScaleName}");
                }
                metricSystems.Add(systemInfo.MeasurementType, systemInfo.ScaleName);
            }
            
            
            metricSystems[measurementType] = scaleName;
        }
        
        // Validate we have one metric system for each measurement type we have
        
    }

    public static MeasurementSystem GetMeasurementSystem(MeasurementTypes type, string name)
    {
        if (measurementSystems.TryGetValue(type, out var systems))
        {
            if (systems.TryGetValue(name, out var system))
            {
                return system;
            }
        }
        
        throw new ArgumentException($"Measurement system '{name}' not found for type '{type}'.");
    }

    public static Measure<TUnit> GetMeasurementFromValue<TUnit>(double value, TUnit unit) where TUnit : Enum
    {
        if (!measurementUnitMapping.TryGetValue(typeof(TUnit), out var measurementType))
        {
            throw new ArgumentException($"Measurement unit '{typeof(TUnit)}' not found.");
        }
        
        var type = measurementType.Item1;
        var name = measurementType.Item2;
        var measurementSystem = GetMeasurementSystem(type, name);
        
        return new Measure<TUnit>(value, measurementSystem, unit);
    }
}
