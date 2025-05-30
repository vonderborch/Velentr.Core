using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Velentr.Core.JsonConverters;

/// <summary>
///     Provides a registry for JSON converter factories used in serializing and deserializing types.
///     This class serves as a central point for registering and retrieving converter factories
///     that handle custom type conversions for JSON serialization. Registered factories can be
///     queried to determine if they support a particular type, and used to create converters
///     when needed.
/// </summary>
internal static class JsonConverterFactoryRegister
{
    private static readonly List<JsonConverterFactory> Factories;

    private static readonly Dictionary<Type, JsonConverterFactory> FactoryCache;

    /// <summary>
    ///     Provides a mechanism for registering and managing JSON converter factories.
    /// </summary>
    static JsonConverterFactoryRegister()
    {
        Factories = new List<JsonConverterFactory>();
        FactoryCache = new Dictionary<Type, JsonConverterFactory>();

        // Register all converter factories that have the registration attribute
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (Assembly assembly in assemblies)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(typeof(JsonConverterFactory)) &&
                    type.GetCustomAttributes(typeof(JsonConverterFactoryRegistrationAttribute), false).Any())
                {
                    JsonConverterFactory factory = (JsonConverterFactory)Activator.CreateInstance(type)!;
                    Factories.Add(factory);
                }
            }
        }
    }

    /// <summary>
    ///     Checks if any registered converter factory can convert the specified type.
    /// </summary>
    /// <param name="typeToConvert">The type to check for conversion support.</param>
    /// <returns>True if at least one converter factory can handle the specified type; otherwise, false.</returns>
    public static bool CanConvert(Type typeToConvert)
    {
        if (FactoryCache.ContainsKey(typeToConvert))
        {
            return true;
        }

        JsonConverterFactory? cachedFactory = Factories.FirstOrDefault(factory => factory.CanConvert(typeToConvert));
        if (cachedFactory != null)
        {
            FactoryCache[typeToConvert] = cachedFactory;
        }

        return cachedFactory != null;
    }

    /// <summary>
    ///     Creates a JSON converter for the specified type using the registered converter factories.
    /// </summary>
    /// <param name="typeToConvert">The type for which to create the converter.</param>
    /// <param name="options">The JSON serialization options to use.</param>
    /// <returns>The created JSON converter instance.</returns>
    public static JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (FactoryCache.TryGetValue(typeToConvert, out JsonConverterFactory? cachedFactory))
        {
            return cachedFactory.CreateConverter(typeToConvert, options);
        }

        JsonConverterFactory? factory = Factories.FirstOrDefault(f => f.CanConvert(typeToConvert));
        FactoryCache[typeToConvert] = factory ??
                                      throw new InvalidOperationException(
                                          $"No converter factory registered for type {typeToConvert.FullName}");
        return factory.CreateConverter(typeToConvert, options);
    }

    /// <summary>
    ///     Registers a converter factory with the class so that it can be used by other methods.
    /// </summary>
    /// <param name="factory">The converter factory to register.</param>
    public static void RegisterType(JsonConverterFactory factory)
    {
        Factories.Add(factory);
    }
}
