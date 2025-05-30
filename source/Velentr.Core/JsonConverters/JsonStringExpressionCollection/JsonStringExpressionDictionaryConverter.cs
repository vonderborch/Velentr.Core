using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Velentr.Core.Json;

namespace Velentr.Core.JsonConverters.JsonStringExpressionCollection;

/// <summary>
///     A JSON converter for serializing and deserializing dictionaries of expressions into string representations.
/// </summary>
/// <typeparam name="TDelegate">The delegate type of the expressions in the dictionary.</typeparam>
public class
    JsonStringExpressionDictionaryConverter<TDelegate> : JsonConverter<Dictionary<string, Expression<TDelegate>>>
    where TDelegate : Delegate
{
    /// <summary>
    ///     Deserializes a JSON object into a dictionary of expressions.
    /// </summary>
    /// <param name="reader">The reader to read JSON from.</param>
    /// <param name="typeToConvert">The type of the dictionary to convert.</param>
    /// <param name="options">The serialization options.</param>
    /// <returns>A dictionary of strings to expressions.</returns>
    /// <exception cref="JsonException">Thrown when the JSON is not a start object or the serialized expression is invalid.</exception>
    public override Dictionary<string, Expression<TDelegate>> Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        Dictionary<string, Expression<TDelegate>> dict = new();
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
        {
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                continue;
            }

            var key = reader.GetString()!;
            reader.Read(); // move to value
            var json = reader.GetString();
            if (string.IsNullOrEmpty(json))
            {
                throw new JsonException("Serialized expression cannot be null or empty.");
            }

            dict[key] = ExpressionSerializer<TDelegate>.DeserializeExpression(json);
        }

        return dict;
    }

    /// <summary>
    ///     Serializes a dictionary of expressions into JSON format.
    /// </summary>
    /// <param name="writer">The writer to write JSON to.</param>
    /// <param name="value">The dictionary of strings to expressions to serialize.</param>
    /// <param name="options">The serialization options.</param>
    public override void Write(Utf8JsonWriter writer, Dictionary<string, Expression<TDelegate>> value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        foreach (KeyValuePair<string, Expression<TDelegate>> kvp in value)
        {
            writer.WritePropertyName(kvp.Key);
            var json = ExpressionSerializer<TDelegate>.SerializeExpression(kvp.Value);
            writer.WriteStringValue(json);
        }

        writer.WriteEndObject();
    }
}
