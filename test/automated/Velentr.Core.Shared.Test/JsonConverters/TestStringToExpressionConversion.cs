using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Velentr.Core.JsonConverters;
using Velentr.Core.JsonConverters.JsonStringExpression;

namespace Velentr.Core.Test.Velentr.Core.Shared.Test.JsonConverters;

[TestFixture]
public class TestStringToExpressionConversion
{
    // Test delegates
    private delegate int MathOperation(int a, int b);

    private delegate bool Predicate<T>(T value);

    [Test]
    public void JsonStringExpressionConverter_CanSerializeExpression()
    {
        // Arrange
        JsonStringExpressionConverter<MathOperation> converter = new();
        Expression<MathOperation> expression = (a, b) => a + b;

        // Mock a JsonWriter using a wrapper for testing
        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream);

        // Act
        converter.Write(writer, expression, new JsonSerializerOptions());
        writer.Flush();

        // Reset the stream position
        stream.Position = 0;
        using JsonDocument document = JsonDocument.Parse(stream);
        var serializedValue = document.RootElement.GetString();

        // Assert
        Assert.That(serializedValue, Is.Not.Null);
        Assert.That(serializedValue, Does.StartWith("{"));
        Assert.That(serializedValue, Does.EndWith("}"));
    }

    [Test]
    public void JsonStringExpressionConverter_ThrowsOnEmptyInput()
    {
        // Arrange
        JsonStringExpressionConverter<MathOperation> converter = new();
        var jsonBytes = Encoding.UTF8.GetBytes("\"\"");
        Utf8JsonReader jsonReader = new(jsonBytes);
        jsonReader.Read(); // Advance to the first token

        // Act & Assert
        try
        {
            converter.Read(ref jsonReader, typeof(Expression<MathOperation>), new JsonSerializerOptions());
            Assert.Fail("Expected JsonException was not thrown.");
        }
        catch (JsonException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("Serialized expression cannot be null or empty."));
        }
        catch (Exception ex)
        {
            Assert.Fail(
                $"Expected JsonException but a different exception was thrown: {ex.GetType().Name} with message: {ex.Message}");
        }
    }

    [Test]
    public void JsonStringExpressionConverterFactory_CanConvertReturnsTrueForValidTypes()
    {
        // Arrange
        JsonStringExpressionConverterFactory factory = new();

        // Act & Assert
        Assert.That(factory.CanConvert(typeof(Expression<MathOperation>)), Is.True);
        Assert.That(factory.CanConvert(typeof(Expression<Func<int, bool>>)), Is.True);
        Assert.That(factory.CanConvert(typeof(Expression<Predicate<int>>)), Is.True);
    }

    [Test]
    public void JsonStringExpressionConverterFactory_CanConvertReturnsFalseForInvalidTypes()
    {
        // Arrange
        JsonStringExpressionConverterFactory factory = new();

        // Act & Assert
        Assert.That(factory.CanConvert(typeof(string)), Is.False);
        Assert.That(factory.CanConvert(typeof(int)), Is.False);
        Assert.That(factory.CanConvert(typeof(MathOperation)), Is.False);
        Assert.That(factory.CanConvert(typeof(Expression)), Is.False);
    }

    [Test]
    public void JsonStringExpressionConverterFactory_CreateConverterReturnsValidConverter()
    {
        // Arrange
        JsonStringExpressionConverterFactory factory = new();

        // Act
        JsonConverter converter =
            factory.CreateConverter(typeof(Expression<MathOperation>), new JsonSerializerOptions());

        // Assert
        Assert.That(converter, Is.Not.Null);
        Assert.That(converter, Is.TypeOf<JsonStringExpressionConverter<MathOperation>>());
    }

    [Test]
    public void SystemTextJson_EndToEndSerialization()
    {
        // Arrange
        Expression<Func<int, int, int>> expression = (a, b) => a * b;
        JsonSerializerOptions options = new();
        options.Converters.Add(new JsonStringExpressionConverterFactory());

        TestObject testObject = new()
        {
            Name = "Test",
            ExpressionProperty = expression
        };

        // Act
        var json = JsonSerializer.Serialize(testObject, options);
        TestObject? deserialized = JsonSerializer.Deserialize<TestObject>(json, options);

        // Assert
        Assert.That(deserialized, Is.Not.Null);
        Assert.That(deserialized.Name, Is.EqualTo("Test"));
        Assert.That(deserialized.ExpressionProperty, Is.Not.Null);

        // Verify the deserialized expression produces correct results
        Func<int, int, int> originalFunc = expression.Compile();
        Func<int, int, int> deserializedFunc = deserialized.ExpressionProperty.Compile();

        Assert.That(deserializedFunc(5, 6), Is.EqualTo(originalFunc(5, 6)));
        Assert.That(deserializedFunc(7, 8), Is.EqualTo(originalFunc(7, 8)));
    }

    [Test]
    public void JsonStringExpressionConverter_ListOfExpressions()
    {
        // Arrange
        JsonSerializerOptions options = new();
        options.Converters.Add(new JsonStringExpressionConverterFactory());
        List<Expression<MathOperation>> list = new()
        {
            (a, b) => a * b,
            (a, b) => a - b
        };

        // Act
        var json = JsonSerializer.Serialize(list, options);
        List<Expression<MathOperation>>? deserialized =
            JsonSerializer.Deserialize<List<Expression<MathOperation>>>(json, options);

        // Assert
        Assert.That(deserialized, Is.Not.Null);
        Assert.That(deserialized.Count, Is.EqualTo(2));
        MathOperation mul = deserialized[0].Compile();
        MathOperation sub = deserialized[1].Compile();
        Assert.That(mul(3, 4), Is.EqualTo(12));
        Assert.That(sub(10, 5), Is.EqualTo(5));
    }

    [Test]
    public void JsonStringExpressionConverter_DictionaryOfExpressions()
    {
        // Arrange
        JsonSerializerOptions options = new();
        options.Converters.Add(new JsonStringExpressionConverterFactory());
        Dictionary<string, Expression<MathOperation>> dict = new()
        {
            ["add"] = (a, b) => a + b,
            ["max"] = (a, b) => a > b ? a : b
        };

        // Act
        var json = JsonSerializer.Serialize(dict, options);
        Dictionary<string, Expression<MathOperation>>? deserialized =
            JsonSerializer.Deserialize<Dictionary<string, Expression<MathOperation>>>(json, options);

        // Assert
        Assert.That(deserialized, Is.Not.Null);
        Assert.That(deserialized.Keys, Is.EquivalentTo(new[] { "add", "max" }));
        MathOperation add = deserialized["add"].Compile();
        MathOperation max = deserialized["max"].Compile();
        Assert.That(add(2, 3), Is.EqualTo(5));
        Assert.That(max(2, 3), Is.EqualTo(3));
    }

    [Test]
    public void JsonStringExpressionConverterDecorator_CanSerializeAndDeserializeWithCollections()
    {
        // Arrange
        JsonSerializerOptions options = new();

        TestObjectWithCollections testObject = new()
        {
            Name = "Test",
            Expressions = new List<Expression<MathOperation>>
            {
                (a, b) => a + b,
                (a, b) => a - b
            },
            ExpressionDict = new Dictionary<string, Expression<MathOperation>>
            {
                ["multiply"] = (a, b) => a * b,
                ["divide"] = (a, b) => a / b
            }
        };

        // Act
        var json = JsonSerializer.Serialize(testObject, options);
        TestObjectWithCollections? deserialized = JsonSerializer.Deserialize<TestObjectWithCollections>(json, options);

        // Assert
        Assert.That(deserialized, Is.Not.Null);
        Assert.That(deserialized.Name, Is.EqualTo("Test"));
        Assert.That(deserialized.Expressions.Count, Is.EqualTo(2));
        Assert.That(deserialized.ExpressionDict.Count, Is.EqualTo(2));

        // Verify the expressions work as expected
        MathOperation addFunc = deserialized.Expressions[0].Compile();
        MathOperation subFunc = deserialized.Expressions[1].Compile();
        MathOperation mulFunc = deserialized.ExpressionDict["multiply"].Compile();
        MathOperation divFunc = deserialized.ExpressionDict["divide"].Compile();

        Assert.That(addFunc(5, 6), Is.EqualTo(11));
        Assert.That(subFunc(10, 4), Is.EqualTo(6));
        Assert.That(mulFunc(3, 4), Is.EqualTo(12));
        Assert.That(divFunc(8, 2), Is.EqualTo(4));
    }

    private class TestObject
    {
        public Expression<Func<int, int, int>> ExpressionProperty { get; set; }
        public string Name { get; set; }
    }

    private class TestObjectWithCollections
    {
        [JsonConverter(typeof(RegisteredJsonConverterFactory))]
        public Dictionary<string, Expression<MathOperation>> ExpressionDict { get; set; } = new();

        [JsonConverter(typeof(RegisteredJsonConverterFactory))]
        public List<Expression<MathOperation>> Expressions { get; set; } = new();

        public string Name { get; set; }
    }
}
