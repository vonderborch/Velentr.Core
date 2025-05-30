using System.Linq.Expressions;
using Velentr.Core.Json;

namespace Velentr.Core.Test.Json;

[TestFixture]
public class TestExpressionSerializer
{
    [Test]
    public void TestSerializeExpression()
    {
        // Arrange
        Expression<Func<int, int>> expression = x => x + 1;

        // Act
        var serializedExpression = ExpressionSerializer<Func<int, int>>.SerializeExpression(expression);

        // Assert
        Assert.That(serializedExpression, Is.Not.Null);
        Assert.That(serializedExpression, Is.Not.Empty);
    }

    [Test]
    public void TestDeserializeExpression()
    {
        // Arrange
        Expression<Func<int, int>> expression = x => x + 1;
        var serializedExpression = ExpressionSerializer<Func<int, int>>.SerializeExpression(expression);

        // Act
        Expression<Func<int, int>> deserializedExpression =
            ExpressionSerializer<Func<int, int>>.DeserializeExpression(serializedExpression);

        // Assert
        Assert.That(deserializedExpression, Is.Not.Null);
        Assert.That(deserializedExpression.ToString(), Is.EqualTo(expression.ToString()));
    }

    [Test]
    public void TestInvalidDeserialization()
    {
        // Arrange
        var invalidSerializedExpression = "invalid_base64_string";

        // Act & Assert
        Assert.That(() => { ExpressionSerializer<Func<int, int>>.DeserializeExpression(invalidSerializedExpression); },
            Throws.Exception);
    }
}
