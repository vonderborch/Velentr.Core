using Velentr.Core.Json;
using Velentr.Core.Strings;

namespace Velentr.Core.Test.Strings;

[TestFixture]
public class FormattingTests
{
    [Test]
    public void FormatString_ShouldReplacePlaceholders_WithParameters()
    {
        // Arrange
        var format = "Hello, {0}!";
        var expected = "Hello, World!";

        // Act
        var result = Formatting.FormatString(format, "World");

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleEscapedBraces()
    {
        // Arrange
        var format = "This is a brace: {{ and this is a placeholder: {0}";
        var expected = "This is a brace: { and this is a placeholder: value";

        // Act
        var result = Formatting.FormatString(format, "value");

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldSerializeParameter_WhenAtSymbolIsUsed()
    {
        // Arrange
        var format = "Serialized object: {@0}";
        var obj = new { Id = 1, Name = "Test" };
        var expected = $"Serialized object: {JsonHelpers.SerializeToString(obj)}";

        // Act
        var result = Formatting.FormatString(format, obj);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldThrowException_WhenInvalidParameterPosition()
    {
        // Arrange
        var format = "Invalid parameter: {1}";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Formatting.FormatString(format, "value"));
    }

    [Test]
    public void FormatString_ShouldReplaceNamedPlaceholders_WithParameters()
    {
        // Arrange
        var format = "Hello, {name}!";
        var expected = "Hello, World!";

        // Act
        var result = Formatting.FormatString(format, new { name = "World" });

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldSerializeNamedParameter_WhenAtSymbolIsUsed()
    {
        // Arrange
        var format = "Serialized object: {@name}";
        var obj = new { Id = 1, Name = "Test" };
        var expected = $"Serialized object: {JsonHelpers.SerializeToString(obj)}";

        // Act
        var result = Formatting.FormatString(format, new { name = obj });

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldReplaceMultiplePlaceholders_WithParameters()
    {
        // Arrange
        var format = "{0} + {1} = {2}";
        var expected = "1 + 2 = 3";

        // Act
        var result = Formatting.FormatString(format, 1, 2, 3);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleEmptyFormatString()
    {
        // Arrange
        var format = "";
        var expected = "";

        // Act
        var result = Formatting.FormatString(format);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleNullParameters()
    {
        // Arrange
        var format = "Value: {0}";
        var expected = "Value: ";

        // Act
        var result = Formatting.FormatString(format, null);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleMissingPlaceholders()
    {
        // Arrange
        var format = "Value: {0} {1}";
        var expected = "Value: 1 ";

        // Act
        Assert.Throws<ArgumentException>(() => Formatting.FormatString(format, 1));
    }

    [Test]
    public void FormatString_ShouldHandleExtraParameters()
    {
        // Arrange
        var format = "Value: {0}";
        var expected = "Value: 1";

        // Act
        var result = Formatting.FormatString(format, 1, 2, 3);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleEscapedPlaceholders()
    {
        // Arrange
        var format = "Escaped {{0}}";
        var expected = "Escaped {0}";

        // Act
        var result = Formatting.FormatString(format);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleNullFormatString()
    {
        // Arrange
        string format = null;

        // Act & Assert
        Assert.That(Formatting.FormatString(format), Is.EqualTo(string.Empty));
    }

    [Test]
    public void FormatString_ShouldHandleEmptyParameters()
    {
        // Arrange
        var format = "No parameters";
        var expected = "No parameters";

        // Act
        var result = Formatting.FormatString(format);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleWhitespaceFormatString()
    {
        // Arrange
        var format = "   ";
        var expected = "   ";

        // Act
        var result = Formatting.FormatString(format);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleWhitespaceParameters()
    {
        // Arrange
        var format = "Value: {0}";
        var expected = "Value:    ";

        // Act
        var result = Formatting.FormatString(format, "   ");

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleSpecialCharactersInFormatString()
    {
        // Arrange
        var format = "Special characters: !@#$%^&*()_+";
        var expected = "Special characters: !@#$%^&*()_+";

        // Act
        var result = Formatting.FormatString(format);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleSpecialCharactersInParameters()
    {
        // Arrange
        var format = "Special characters: {0}";
        var expected = "Special characters: !@#$%^&*()_+";

        // Act
        var result = Formatting.FormatString(format, "!@#$%^&*()_+");

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleLongFormatString()
    {
        // Arrange
        var format = new string('a', 10000) + "{0}";
        var expected = new string('a', 10000) + "value";

        // Act
        var result = Formatting.FormatString(format, "value");

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleLongParameter()
    {
        // Arrange
        var format = "Value: {0}";
        var longParameter = new string('a', 10000);
        var expected = "Value: " + longParameter;

        // Act
        var result = Formatting.FormatString(format, longParameter);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FormatString_ShouldHandleFormatting()
    {
        // Arrange
        var format = "Value: {0:F2}, Value2: {value2:F5}, Value: {0:F4}, DateValue: {dateValue:yyyy-MM-dd}";
        DateTime now = DateTime.Now;
        var expected = $"Value: 123.46, Value2: 123.45679, Value: 123.4568, DateValue: {now:yyyy-MM-dd}";

        // Act
        var result = Formatting.FormatString(format, 123.456789, new { value2 = 123.456789 }, 123.456789,
            new { dateValue = now });

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
