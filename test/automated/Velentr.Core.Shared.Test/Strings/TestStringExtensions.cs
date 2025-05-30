using Velentr.Core.Strings;

namespace Velentr.Core.Test.Strings;

[TestFixture]
public class TestStringExtensions
{
    // IsNullOrEmpty tests
    [Test]
    public void IsNullOrEmpty_Null_ReturnsTrue()
    {
        string? value = null;
        Assert.That(value.IsNullOrEmpty(), Is.True);
    }

    [Test]
    public void IsNullOrEmpty_EmptyString_ReturnsTrue()
    {
        var value = "";
        Assert.That(value.IsNullOrEmpty(), Is.True);
    }

    [Test]
    public void IsNullOrEmpty_NonEmptyString_ReturnsFalse()
    {
        var value = "test";
        Assert.That(value.IsNullOrEmpty(), Is.False);
    }

    // IsNullOrWhiteSpace tests
    [Test]
    public void IsNullOrWhiteSpace_Null_ReturnsTrue()
    {
        string? value = null;
        Assert.That(value.IsNullOrWhiteSpace(), Is.True);
    }

    [Test]
    public void IsNullOrWhiteSpace_EmptyString_ReturnsTrue()
    {
        var value = "";
        Assert.That(value.IsNullOrWhiteSpace(), Is.True);
    }

    [Test]
    public void IsNullOrWhiteSpace_WhitespaceOnly_ReturnsTrue()
    {
        var value = "   \t\n";
        Assert.That(value.IsNullOrWhiteSpace(), Is.True);
    }

    [Test]
    public void IsNullOrWhiteSpace_NonWhitespaceString_ReturnsFalse()
    {
        var value = "test";
        Assert.That(value.IsNullOrWhiteSpace(), Is.False);
    }

    // Join extension tests (separator.Join(values))
    [Test]
    public void Join_WithSeparatorExtension_ReturnsJoinedString()
    {
        var values = new[] { "a", "b", "c" };
        var separator = "-";
        var result = separator.Join(values);
        Assert.That(result, Is.EqualTo("a-b-c"));
    }

    // Join extension tests (values.Join(separator))
    [Test]
    public void Join_WithEnumerableExtension_ReturnsJoinedString()
    {
        List<int> values = new() { 1, 2, 3 };
        var separator = "|";
        var result = values.Join(separator);
        Assert.That(result, Is.EqualTo("1|2|3"));
    }

    [Test]
    public void Join_EmptyCollection_ReturnsEmptyString()
    {
        var values = Array.Empty<string>();
        var separator = ",";
        Assert.That(separator.Join(values), Is.EqualTo(string.Empty));
        Assert.That(values.Join(separator), Is.EqualTo(string.Empty));
    }

    [Test]
    public void Join_NullCollection_ThrowsArgumentNullException()
    {
        List<string>? values = null;
        var separator = ",";
        Assert.That(() => separator.Join(values!), Throws.TypeOf<ArgumentNullException>());
        Assert.That(() => values!.Join(separator), Throws.TypeOf<ArgumentNullException>());
    }
}
