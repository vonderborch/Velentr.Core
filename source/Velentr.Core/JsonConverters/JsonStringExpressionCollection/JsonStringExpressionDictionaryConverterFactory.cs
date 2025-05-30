using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Velentr.Core.JsonConverters.JsonStringExpressionCollection;

/// <summary>
///     A factory for creating JSON converters that handle dictionaries with string keys and expression values.
/// </summary>
[JsonConverterFactoryRegistration]
public class JsonStringExpressionDictionaryConverterFactory : JsonConverterFactory
{
    /// <summary>
    ///     Determines whether the converter can handle the specified type.
    /// </summary>
    /// <param name="typeToConvert">The type being converted.</param>
    /// <returns>True if the type is a generic dictionary with string keys and expression values; otherwise, false.</returns>
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
        {
            return false;
        }

        Type def = typeToConvert.GetGenericTypeDefinition();
        if (def == typeof(Dictionary<,>))
        {
            Type[] args = typeToConvert.GetGenericArguments();
            return args[0] == typeof(string)
                   && args[1].IsGenericType
                   && args[1].GetGenericTypeDefinition() == typeof(Expression<>);
        }

        return false;
    }

    /// <summary>
    ///     Creates a JSON converter for dictionaries with string keys and expression values.
    /// </summary>
    /// <param name="typeToConvert">The type of dictionary to convert.</param>
    /// <param name="options">The JSON serializer options.</param>
    /// <returns>A JSON converter instance for the specified dictionary type.</returns>
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Type valueType = typeToConvert.GetGenericArguments()[1].GetGenericArguments()[0];
        Type dictConv = typeof(JsonStringExpressionDictionaryConverter<>).MakeGenericType(valueType);
        return (JsonConverter)Activator.CreateInstance(dictConv)!;
    }
}
