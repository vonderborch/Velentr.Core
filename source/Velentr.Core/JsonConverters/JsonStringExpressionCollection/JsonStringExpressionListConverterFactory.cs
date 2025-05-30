using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Velentr.Core.JsonConverters.JsonStringExpressionCollection;

/// <summary>
///     A factory class for converting JSON to and from lists of expressions.
///     This converter supports types that are generic lists or ILists of Expression objects,
///     allowing serialization and deserialization of expression collections into JSON strings.
/// </summary>
[JsonConverterFactoryRegistration]
public class JsonStringExpressionListConverterFactory : JsonConverterFactory
{
    /// <summary>
    ///     Determines whether this converter can convert the specified type.
    /// </summary>
    /// <param name="typeToConvert">The type to check.</param>
    /// <returns>true if the converter can handle the type; otherwise, false.</returns>
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
        {
            return false;
        }

        Type def = typeToConvert.GetGenericTypeDefinition();
        if (def == typeof(List<>) || def == typeof(IList<>))
        {
            Type item = typeToConvert.GetGenericArguments()[0];
            return item.IsGenericType && item.GetGenericTypeDefinition() == typeof(Expression<>);
        }

        return false;
    }

    /// <summary>
    ///     Creates a JSON converter for the specified type.
    /// </summary>
    /// <param name="typeToConvert">The type for which to create a converter.</param>
    /// <param name="options">The serialization options to use.</param>
    /// <returns>A JSON converter for the specified type, or null if unsupported.</returns>
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Type def = typeToConvert.GetGenericTypeDefinition();
        if (def == typeof(List<>) || def == typeof(IList<>))
        {
            Type exprType = typeToConvert.GetGenericArguments()[0].GetGenericArguments()[0];
            Type convType = typeof(JsonStringExpressionListConverter<>).MakeGenericType(exprType);
            return (JsonConverter)Activator.CreateInstance(convType)!;
        }

        return null; // If the type is not supported, return null
    }
}
