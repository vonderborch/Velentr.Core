using System.Reflection;

namespace Velentr.Core.UnitConversions;

public static class Measurements
{
    private static Dictionary<string, IMeasurementSystem> metricSystems;
    
    private static Dictionary<string, Dictionary<string, IMeasurementSystem>> measurementSystemsByMeasurementTypeAndName;

    private static Dictionary<object, (IMeasurementUnit unit, IMeasurementSystem system)> measurementUnitMapping;
    
    private static Dictionary<Type, List<IMeasurementUnit>> measurementUnitsByScaleType;
    
    private static Dictionary<Type, IMeasurementUnit> baseUnitByScaleType;
    
    private static Dictionary<Type, IMeasurementSystem> measurementSystemsByScaleType;
    
    static Measurements()
    {
        metricSystems = new();
        measurementUnitMapping = new();
        measurementSystemsByMeasurementTypeAndName = new();
        measurementUnitsByScaleType = new();
        baseUnitByScaleType = new();
        measurementSystemsByScaleType = new();
        
        // Define the base types for measurement systems and units
        Type systemClassType = typeof(IMeasurementSystem);
        Type unitClassType = typeof(IMeasurementUnit);
        
        // Look for all measurement systems and units in all loaded assemblies
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        List<Type> types = assemblies.SelectMany(a => a.GetTypes()).ToList();
        List<Type> validTypes = types.Where(
            t => t is { IsClass: true, IsAbstract: false} && 
                 (t.GetInterface(systemClassType.ToString()) != null || t.GetInterface(unitClassType.ToString()) != null)
        ).ToList();
        
        // Create a mapping of measurement scales and their defined units
        List<Type> unitTypes = validTypes.Where(t => t.GetInterface(unitClassType.ToString()) != null).ToList();
        foreach (Type unitType in unitTypes)
        {
            ISingleton<IMeasurementUnit> unitSingleton = (ISingleton<IMeasurementUnit>)Activator.CreateInstance(unitType)!;
            IMeasurementUnit unit = unitSingleton.SingletonInstance;
            
            if (!measurementUnitsByScaleType.ContainsKey(unit.Scale))
            {
                measurementUnitsByScaleType[unit.Scale] = new List<IMeasurementUnit>();
            }
            measurementUnitsByScaleType[unit.Scale].Add(unit);
        }
        
        // go through the systems and add them as appropriate
        List<Type> systemTypes = validTypes.Where(t => t.GetInterface(systemClassType.ToString()) != null).ToList();
        foreach (Type systemType in systemTypes)
        {
            ISingleton<IMeasurementSystem> singleton = (ISingleton<IMeasurementSystem>)Activator.CreateInstance(systemType)!;
            IMeasurementSystem system = singleton.SingletonInstance;
            
            // register this system with the metric systems
            if (system.IsMetricScale)
            {
                if (metricSystems.ContainsKey(system.MeasurementType))
                {
                    throw new Exception($"A metric measurement system '{system.MeasurementType}' already exists!");
                }
                metricSystems.Add(system.MeasurementType, system);
            }
            
            // register the system by scale
            if (measurementSystemsByScaleType.ContainsKey(system.Scale))
            {
                throw new Exception($"A measurement system '{system.Scale}' already exists!");
            }
            measurementSystemsByScaleType[system.Scale] = system;
            
            // register this system with the measurement systems by type and name
            if (!measurementSystemsByMeasurementTypeAndName.ContainsKey(system.MeasurementType))
            {
                measurementSystemsByMeasurementTypeAndName[system.MeasurementType] = new Dictionary<string, IMeasurementSystem>();
            }
            if (measurementSystemsByMeasurementTypeAndName.ContainsKey(system.ScaleName))
            {
                throw new Exception($"A measurement system '{system.ScaleName}' already exists!");
            }
            measurementSystemsByMeasurementTypeAndName[system.MeasurementType].Add(system.ScaleName, system);
            
            // register the units associated with this system
            if (!measurementUnitsByScaleType.TryGetValue(system.Scale, out List<IMeasurementUnit> units))
            {
                throw new Exception($"No measurement units found for scale '{system.Scale}'");
            }
            
            // register the unit mapping
            measurementUnitsByScaleType[system.Scale] = units;
            var baseUnit = units.Where(x => x.IsBaseUnitInScale).ToList();
            if (baseUnit.Count != 1)
            {
                throw new Exception($"There must be exactly one base unit for the scale '{system.Scale}'");
            }
            baseUnitByScaleType[system.Scale] = baseUnit[0];
            foreach (var unit in units)
            {
                measurementUnitMapping[unit.Unit] = (unit, system);
            }
        }
    }

    public static IMeasurementSystem GetMeasurementSystem(string measurementType, string systemName)
    {
        if (!measurementSystemsByMeasurementTypeAndName.TryGetValue(measurementType, out var systems))
        {
            throw new ArgumentException($"Measurement type '{measurementType}' not found.");
        }
        if (!systems.TryGetValue(systemName, out var system))
        {
            throw new ArgumentException($"Measurement system '{systemName}' not found.");
        }
        
        return system;
    }

    public static Measure<TUnit> GetMeasurementFromValue<TUnit>(double value, TUnit unit) where TUnit : Enum
    {
        if (!measurementUnitMapping.TryGetValue(unit, out var measurementType))
        {
            throw new ArgumentException($"Measurement unit '{unit}' not found.");
        }
        
        IMeasurementSystem measurementSystem = measurementSystemsByScaleType[typeof(TUnit)];
        return new Measure<TUnit>(value, measurementSystem, unit);
    }
    
    public static IMeasurementUnit GetUnit<TUnit>(TUnit unit) where TUnit : Enum
    {
        if (!measurementUnitMapping.TryGetValue(unit, out var measurementType))
        {
            throw new ArgumentException($"Measurement unit '{unit}' not found.");
        }
        
        return measurementType.unit;
    }
}
