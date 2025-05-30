using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Velentr.Core.Json;

namespace Velentr.Core.JsonConverters.JsonStringExpression;

/// <summary>
///     A custom JSON converter for serializing and deserializing LINQ expression trees to and from JSON string
///     representations.
/// </summary>
/// <typeparam name="T">
///     The delegate type representing the signature of the LINQ expression.
///     Must inherit from <see cref="Delegate" />.
/// </typeparam>
public class JsonStringExpressionConverter<T> : JsonConverter<Expression<T>> where T : Delegate
{
    /// <summary>
    ///     Reads and deserializes a JSON string into a LINQ <see cref="Expression{TDelegate}" /> object.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader" /> reading the JSON input.</param>
    /// <param name="typeToConvert">
    ///     The expected type of the object to be deserialized. Must match
    ///     <see cref="Expression{TDelegate}" />.
    /// </param>
    /// <param name="options">The <see cref="JsonSerializerOptions" /> used for serialization or deserialization.</param>
    /// <returns>The deserialized <see cref="Expression{TDelegate}" /> object.</returns>
    /// <exception cref="JsonException">Thrown when the JSON string is null or empty.</exception>
    public override Expression<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var serializedExpression = reader.GetString();
        if (string.IsNullOrEmpty(serializedExpression))
        {
            throw new JsonException("Serialized expression cannot be null or empty.");
        }

        return ExpressionSerializer<T>.DeserializeExpression(serializedExpression);
    }

    /// <summary>
    ///     Serializes a LINQ <see cref="Expression{TDelegate}" /> object into a JSON string.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter" /> used to write the JSON output.</param>
    /// <param name="value">The <see cref="Expression{TDelegate}" /> object to serialize.</param>
    /// <param name="options">The <see cref="JsonSerializerOptions" /> used for serialization.</param>
    public override void Write(Utf8JsonWriter writer, Expression<T> value, JsonSerializerOptions options)
    {
        var serializedExpression = ExpressionSerializer<T>.SerializeExpression(value);
        writer.WriteStringValue(serializedExpression);
    }
}
