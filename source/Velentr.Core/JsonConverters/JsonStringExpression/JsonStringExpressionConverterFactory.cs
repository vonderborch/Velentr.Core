using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Velentr.Core.JsonConverters.JsonStringExpression;

/// <summary>
///     A factory class for creating instances of <see cref="JsonStringExpressionConverter{T}" />.
///     This factory is responsible for providing JSON converters that handle the serialization and deserialization of LINQ
///     expression trees.
/// </summary>
[JsonConverterFactoryRegistration]
public class JsonStringExpressionConverterFactory : JsonConverterFactory
{
    /// <summary>
    ///     Determines whether this factory can convert the specified type.
    /// </summary>
    /// <param name="typeToConvert">The type to evaluate for conversion compatibility.</param>
    /// <returns>
    ///     <c>true</c> if the specified type is a generic type and its generic type definition matches
    ///     <see cref="Expression{TDelegate}" />; otherwise, <c>false</c>.
    /// </returns>
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Expression<>);
    }

    /// <summary>
    ///     Creates a JSON converter for the specified type.
    /// </summary>
    /// <param name="typeToConvert">
    ///     The type of object for which a converter is to be created. Must be of type
    ///     <see cref="Expression{TDelegate}" />.
    /// </param>
    /// <param name="options">The <see cref="JsonSerializerOptions" /> used for serialization or deserialization.</param>
    /// <returns>An instance of <see cref="JsonConverter" /> for the specified type.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the type to convert is null.</exception>
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Type genericType = typeToConvert.GetGenericArguments()[0];
        Type converterType = typeof(JsonStringExpressionConverter<>).MakeGenericType(genericType);
        return (JsonConverter?)Activator.CreateInstance(converterType) ?? throw new ArgumentNullException(nameof(typeToConvert), "Could not create converter instance.");
    }
}
