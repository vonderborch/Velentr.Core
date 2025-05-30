using System.Linq.Expressions;
using Serialize.Linq.Serializers;

namespace Velentr.Core.Json;

/// <summary>
///     Provides methods for serializing and deserializing expressions into Base64 encoded strings.
/// </summary>
/// <typeparam name="T">The type of delegate representing the expression to serialize or deserialize.</typeparam>
public static class ExpressionSerializer<T> where T : Delegate
{
    // ReSharper disable once StaticMemberInGenericType
    private static readonly ExpressionSerializer Serializer = new(new JsonSerializer());

    /// <summary>
    ///     Deserializes a Base64 encoded string into an expression of type T.
    /// </summary>
    /// <param name="serializedExpression">The Base64 encoded string to deserialize.</param>
    /// <returns>The deserialized expression of type T, or null if the deserialization fails.</returns>
    public static Expression<T> DeserializeExpression(string serializedExpression)
    {
        Expression? expression = Serializer.DeserializeText(serializedExpression);
        return (Expression<T>)expression;
    }

    /// <summary>
    ///     Serializes an expression of type T into a Base64 encoded string.
    /// </summary>
    /// <param name="expression">The expression to serialize.</param>
    /// <returns>A Base64 encoded string representing the serialized expression.</returns>
    public static string SerializeExpression(Expression<T> expression)
    {
        var expressionString = Serializer.SerializeText(expression);
        return expressionString;
    }
}
