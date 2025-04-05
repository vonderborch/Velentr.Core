using Velentr.Core.Strings;

namespace Velentr.Core.Test.Strings;

[TestFixture]
public class TestSplitting
{
    [Test]
    public void TestSplitByChunkSize_ValidString()
    {
        var result = "abcdefghij".SplitByChunkSize(3);
        Assert.That(result, Is.EquivalentTo(new List<string> { "abc", "def", "ghi", "j" }));
    }

    [Test]
    public void TestSplitByChunkSize_ChunkSizeGreaterThanStringLength()
    {
        var result = "abc".SplitByChunkSize(5);
        Assert.That(result, Is.EquivalentTo(new List<string> { "abc" }));
    }

    [Test]
    public void TestSplitByChunkSize_ChunkSizeLessThanOne()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
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
        var result = "".SplitByChunkSize(3);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void TestSplitByChunkSize_SingleCharacterString()
    {
        var result = "a".SplitByChunkSize(1);
        Assert.That(result, Is.EquivalentTo(new List<string> { "a" }));
    }

    [Test]
    public void TestSplitByNewLines()
    {
        var result = "line1\r\nline2\nline3\rline4".SplitByNewLines();
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1", "line2", "line3", "line4" }));
    }

    [Test]
    public void TestSplitByNewLines_EmptyString()
    {
        var result = "".SplitByNewLines();
        Assert.That(result, Is.EquivalentTo(new List<string> { "" }));
    }

    [Test]
    public void TestSplitByNewLines_SingleLineString()
    {
        var result = "line1".SplitByNewLines();
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1" }));
    }

    [Test]
    public void TestSplitByNewLines_MultipleNewLines()
    {
        var result = "line1\n\nline2\r\n\r\nline3\r\rline4".SplitByNewLines();
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1", "", "line2", "", "line3", "", "line4" }));
    }
        
    [Test]
    public void TestSplitStringByChunkSize_ValidString()
    {
        var result = Splitting.SplitStringByChunkSize("abcdefghij", 3);
        Assert.That(result, Is.EquivalentTo(new List<string> { "abc", "def", "ghi", "j" }));
    }

    [Test]
    public void TestSplitStringByChunkSize_ChunkSizeGreaterThanStringLength()
    {
        var result = Splitting.SplitStringByChunkSize("abc", 5);
        Assert.That(result, Is.EquivalentTo(new List<string> { "abc" }));
    }

    [Test]
    public void TestSplitStringByChunkSize_ChunkSizeLessThanOne()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
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
        var result = Splitting.SplitStringByChunkSize("", 3);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void TestSplitStringByChunkSize_SingleCharacterString()
    {
        var result = Splitting.SplitStringByChunkSize("a", 1);
        Assert.That(result, Is.EquivalentTo(new List<string> { "a" }));
    }

    [Test]
    public void TestSplitStringByChunkSize_ChunkSizeEqualToStringLength()
    {
        var result = Splitting.SplitStringByChunkSize("abcd", 4);
        Assert.That(result, Is.EquivalentTo(new List<string> { "abcd" }));
    }

    [Test]
    public void TestSplitStringByChunkSize_ChunkSizeOne()
    {
        var result = Splitting.SplitStringByChunkSize("abcd", 1);
        Assert.That(result, Is.EquivalentTo(new List<string> { "a", "b", "c", "d" }));
    }
    [Test]
    public void TestSplitStringByNewLines_ValidString()
    {
        var result = Splitting.SplitStringByNewLines("line1\r\nline2\nline3\rline4");
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1", "line2", "line3", "line4" }));
    }

    [Test]
    public void TestSplitStringByNewLines_EmptyString()
    {
        var result = Splitting.SplitStringByNewLines("");
        Assert.That(result, Is.EquivalentTo(new List<string> { "" }));
    }

    [Test]
    public void TestSplitStringByNewLines_SingleLineString()
    {
        var result = Splitting.SplitStringByNewLines("line1");
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1" }));
    }

    [Test]
    public void TestSplitStringByNewLines_MultipleNewLines()
    {
        var result = Splitting.SplitStringByNewLines("line1\n\nline2\r\n\r\nline3\r\rline4");
        Assert.That(result, Is.EquivalentTo(new List<string> { "line1", "", "line2", "", "line3", "", "line4" }));
    }

    [Test]
    public void TestSplitStringByNewLines_OnlyNewLines()
    {
        var result = Splitting.SplitStringByNewLines("\n\r\n\r");
        Assert.That(result, Is.EquivalentTo(new List<string> { "", "", "", "" }));
    }
}