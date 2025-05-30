using System.Text.Json;
using System.Text.Json.Serialization;

namespace Velentr.Core.JsonConverters;

/// <summary>
///     A factory for JSON converters that delegates conversion decisions and creation to a centralized registry of
///     converter factories.
/// </summary>
public class RegisteredJsonConverterFactory : JsonConverterFactory
{
    /// <summary>
    ///     Determines whether any registered converter factory can convert the specified type.
    /// </summary>
    /// <param name="typeToConvert">The type to check for conversion support.</param>
    /// <returns>True if at least one converter factory can handle the specified type; otherwise, false.</returns>
    public override bool CanConvert(Type typeToConvert)
    {
        return JsonConverterFactoryRegister.CanConvert(typeToConvert);
    }

    /// <summary>
    ///     Creates a JSON converter for the specified type using registered converter factories.
    /// </summary>
    /// <param name="typeToConvert">The type for which to create the converter.</param>
    /// <param name="options">The JSON serialization options to use.</param>
    /// <returns>The created JSON converter instance.</returns>
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonConverterFactoryRegister.CreateConverter(typeToConvert, options);
    }
}
