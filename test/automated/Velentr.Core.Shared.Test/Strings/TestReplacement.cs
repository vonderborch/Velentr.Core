using Velentr.Core.Strings;

namespace Velentr.Core.Test.Strings;

[TestFixture]
public class TestReplacement
{
    [Test]
    public void ReplaceAny_ShouldReplaceSingleString()
    {
        // Arrange
        var input = "Hello World";
        var replacement = "Universe";
        string[] stringsToReplace = { "World" };

        // Act
        var result = input.ReplaceAny(replacement, stringsToReplace);

        // Assert
        Assert.That(result, Is.EqualTo("Hello Universe"));
    }

    [Test]
    public void ReplaceAny_ShouldReplaceMultipleStrings()
    {
        // Arrange
        var input = "Hello World, Hello Universe";
        var replacement = "Everyone";
        string[] stringsToReplace = { "World", "Universe" };

        // Act
        var result = input.ReplaceAny(replacement, stringsToReplace);

        // Assert
        Assert.That(result, Is.EqualTo("Hello Everyone, Hello Everyone"));
    }

    [Test]
    public void ReplaceAny_ShouldHandleNoReplacements()
    {
        // Arrange
        var input = "Hello World";
        var replacement = "Everyone";
        string[] stringsToReplace = { };

        // Act
        var result = input.ReplaceAny(replacement, stringsToReplace);

        // Assert
        Assert.That(result, Is.EqualTo("Hello World"));
    }

    [Test]
    public void ReplaceAny_ShouldHandleNullInput()
    {
        // Arrange
        var input = "Everyone";
        var replacement = "Everyone";
        string[]? stringsToReplace = null;

        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => input.ReplaceAny(replacement, stringsToReplace));
    }

    [Test]
    public void ReplaceAny_ShouldHandleNullReplacement()
    {
        // Arrange
        var input = "Hello World";
        string replacement = null;
        string[] stringsToReplace = { "World" };

        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => input.ReplaceAny(replacement, stringsToReplace));
    }
}
