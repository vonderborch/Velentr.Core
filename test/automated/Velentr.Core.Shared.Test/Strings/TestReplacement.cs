using NUnit.Framework;
using Velentr.Helpers.Strings;

namespace Velentr.Core.Test.Strings;

[TestFixture]
public class TestReplacement
{
    [Test]
    public void ReplaceAny_ShouldReplaceSingleString()
    {
        // Arrange
        string input = "Hello World";
        string replacement = "Universe";
        string[] stringsToReplace = { "World" };

        // Act
        string result = input.ReplaceAny(replacement, stringsToReplace);

        // Assert
        Assert.That(result, Is.EqualTo("Hello Universe"));
    }

    [Test]
    public void ReplaceAny_ShouldReplaceMultipleStrings()
    {
        // Arrange
        string input = "Hello World, Hello Universe";
        string replacement = "Everyone";
        string[] stringsToReplace = { "World", "Universe" };

        // Act
        string result = input.ReplaceAny(replacement, stringsToReplace);

        // Assert
        Assert.That(result, Is.EqualTo("Hello Everyone, Hello Everyone"));
    }

    [Test]
    public void ReplaceAny_ShouldHandleNoReplacements()
    {
        // Arrange
        string input = "Hello World";
        string replacement = "Everyone";
        string[] stringsToReplace = { };

        // Act
        string result = input.ReplaceAny(replacement, stringsToReplace);

        // Assert
        Assert.That(result, Is.EqualTo("Hello World"));
    }

    [Test]
    public void ReplaceAny_ShouldHandleNullInput()
    {
        // Arrange
        string input = "Everyone";
        string replacement = "Everyone";
        string[]? stringsToReplace = null;

        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => input.ReplaceAny(replacement, stringsToReplace));
    }

    [Test]
    public void ReplaceAny_ShouldHandleNullReplacement()
    {
        // Arrange
        string input = "Hello World";
        string replacement = null;
        string[] stringsToReplace = { "World" };

        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => input.ReplaceAny(replacement, stringsToReplace));
    }
}