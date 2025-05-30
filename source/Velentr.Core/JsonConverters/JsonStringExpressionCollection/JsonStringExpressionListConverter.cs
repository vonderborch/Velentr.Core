using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Velentr.Core.Json;

namespace Velentr.Core.JsonConverters.JsonStringExpressionCollection;

/// <summary>
///     Converts a list of expressions of type TDelegate to and from JSON representations.
/// </summary>
/// <typeparam name="TDelegate">The delegate type for the expressions.</typeparam>
public class JsonStringExpressionListConverter<TDelegate> : JsonConverter<List<Expression<TDelegate>>>
    where TDelegate : Delegate
{
    /// <summary>
    ///     Reads a list of expressions from JSON.
    /// </summary>
    /// <param name="reader">The reader to read from.</param>
    /// <param name="typeToConvert">The type being converted.</param>
    /// <param name="options">The serialization options.</param>
    /// <returns>The deserialized list of expressions.</returns>
    /// <exception cref="JsonException">If the JSON is not an array or the serialized expression is empty.</exception>
    public override List<Expression<TDelegate>> Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        List<Expression<TDelegate>> list = new();
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException();
        }

        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            var json = reader.GetString();
            if (string.IsNullOrEmpty(json))
            {
                throw new JsonException("Serialized expression cannot be null or empty.");
            }

            list.Add(ExpressionSerializer<TDelegate>.DeserializeExpression(json));
        }

        return list;
    }

    /// <summary>
    ///     Serializes a list of expressions into JSON format as Base64 encoded strings.
    /// </summary>
    /// <param name="writer">The writer to write the serialized data to.</param>
    /// <param name="value">The list of expressions to serialize.</param>
    /// <param name="options">The serialization options.</param>
    public override void Write(Utf8JsonWriter writer, List<Expression<TDelegate>> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (Expression<TDelegate> expr in value)
        {
            var json = ExpressionSerializer<TDelegate>.SerializeExpression(expr);
            writer.WriteStringValue(json);
        }

        writer.WriteEndArray();
    }
}
