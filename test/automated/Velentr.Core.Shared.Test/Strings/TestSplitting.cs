using Velentr.Core.Strings;

namespace Velentr.Core.Test.Strings;

[TestFixture]
public class TestSplitting
{
    [Test]
    public void TestSplitByChunkSize_ValidString()
    {
        IEnumerable<string>? result = "abcdefghij".SplitByChunkSize(3);
        Assert.That(result, Is.EquivalentTo(new List<string> { "abc", "def", "ghi", "j" }));
    }

    [Test]
    public void TestSplitByChunkSize_ChunkSizeGreaterThanStringLength()
    {
        IEnumerable<string>? result = "abc".SplitByChunkSize(5);
        Assert.That(result, Is.EquivalentTo(new List<string> { "abc" }));
    }

    [Test]
    public void TestSplitByChunkSize_ChunkSizeLessThanOne()
    {
        ArgumentOutOfRangeException? ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            foreach (var _ in "abc".SplitByChunkSize(0))
            {
                throw new Exception("failed test");
            }
        });
        Assert.That(ex.ParamName, Is.EqualTo("chunkSize"));
    }

    [Test]
    public void TestSplitByChunkSize_EmptyString()
    {
        IEnumerable<string>? result = "".SplitByChunkSize(3);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void TestSplitByChunkSize_SingleCharacterString()
    {
        IEnumerable<string>? result = "a".SplitByChunkSize(1);
        Assert.That(result, Is.EquivalentTo(new List<string> { "a" }));
    }

    [Test]
    public void TestSplitByNewLines()
    {
        IEnumerable<string>? result = "line1\r\nline2\nline3\rline4".SplitByNewLines();
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1", "line2", "line3", "line4" }));
    }

    [Test]
    public void TestSplitByNewLines_EmptyString()
    {
        IEnumerable<string>? result = "".SplitByNewLines();
        Assert.That(result, Is.EquivalentTo(new List<string> { "" }));
    }

    [Test]
    public void TestSplitByNewLines_SingleLineString()
    {
        IEnumerable<string>? result = "line1".SplitByNewLines();
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1" }));
    }

    [Test]
    public void TestSplitByNewLines_MultipleNewLines()
    {
        IEnumerable<string>? result = "line1\n\nline2\r\n\r\nline3\r\rline4".SplitByNewLines();
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1", "", "line2", "", "line3", "", "line4" }));
    }

    [Test]
    public void TestSplitStringByChunkSize_ValidString()
    {
        IEnumerable<string>? result = Splitting.SplitStringByChunkSize("abcdefghij", 3);
        Assert.That(result, Is.EquivalentTo(new List<string> { "abc", "def", "ghi", "j" }));
    }

    [Test]
    public void TestSplitStringByChunkSize_ChunkSizeGreaterThanStringLength()
    {
        IEnumerable<string>? result = Splitting.SplitStringByChunkSize("abc", 5);
        Assert.That(result, Is.EquivalentTo(new List<string> { "abc" }));
    }

    [Test]
    public void TestSplitStringByChunkSize_ChunkSizeLessThanOne()
    {
        ArgumentOutOfRangeException? ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            foreach (var _ in Splitting.SplitStringByChunkSize("abc", 0))
            {
                throw new Exception("failed test");
            }
        });
        Assert.That(ex.ParamName, Is.EqualTo("chunkSize"));
    }

    [Test]
    public void TestSplitStringByChunkSize_EmptyString()
    {
        IEnumerable<string>? result = Splitting.SplitStringByChunkSize("", 3);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void TestSplitStringByChunkSize_SingleCharacterString()
    {
        IEnumerable<string>? result = Splitting.SplitStringByChunkSize("a", 1);
        Assert.That(result, Is.EquivalentTo(new List<string> { "a" }));
    }

    [Test]
    public void TestSplitStringByChunkSize_ChunkSizeEqualToStringLength()
    {
        IEnumerable<string>? result = Splitting.SplitStringByChunkSize("abcd", 4);
        Assert.That(result, Is.EquivalentTo(new List<string> { "abcd" }));
    }

    [Test]
    public void TestSplitStringByChunkSize_ChunkSizeOne()
    {
        IEnumerable<string>? result = Splitting.SplitStringByChunkSize("abcd", 1);
        Assert.That(result, Is.EquivalentTo(new List<string> { "a", "b", "c", "d" }));
    }

    [Test]
    public void TestSplitStringByNewLines_ValidString()
    {
        IEnumerable<string>? result = Splitting.SplitStringByNewLines("line1\r\nline2\nline3\rline4");
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1", "line2", "line3", "line4" }));
    }

    [Test]
    public void TestSplitStringByNewLines_EmptyString()
    {
        IEnumerable<string>? result = Splitting.SplitStringByNewLines("");
        Assert.That(result, Is.EquivalentTo(new List<string> { "" }));
    }

    [Test]
    public void TestSplitStringByNewLines_SingleLineString()
    {
        IEnumerable<string>? result = Splitting.SplitStringByNewLines("line1");
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1" }));
    }

    [Test]
    public void TestSplitStringByNewLines_MultipleNewLines()
    {
        IEnumerable<string>? result = Splitting.SplitStringByNewLines("line1\n\nline2\r\n\r\nline3\r\rline4");
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1", "", "line2", "", "line3", "", "line4" }));
    }

    [Test]
    public void TestSplitStringByNewLines_OnlyNewLines()
    {
        IEnumerable<string>? result = Splitting.SplitStringByNewLines("\n\r\n\r");
        Assert.That(result, Is.EquivalentTo(new List<string> { "", "", "", "" }));
    }
}
