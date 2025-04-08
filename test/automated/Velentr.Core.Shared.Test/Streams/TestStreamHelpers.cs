using System.Text;
using Velentr.Core.Streams;

namespace Velentr.Core.Test.Streams;

[TestFixture]
public class TestStreamHelpers
{
    [Test]
    public void ReadStream_ShouldReturnByteArray()
    {
        // Arrange
        var expected = Encoding.UTF8.GetBytes("Hello, World!");
        using MemoryStream? stream = new(expected);

        // Act
        var result = StreamHelpers.ReadStream(stream);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ReadStream_ShouldReturnString()
    {
        // Arrange
        var expected = "Hello, World!";
        using MemoryStream? stream = new(Encoding.UTF8.GetBytes(expected));

        // Act
        var result = StreamHelpers.ReadStream(stream, Encoding.UTF8);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ReadStream_ShouldHandleEmptyStream()
    {
        // Arrange
        using MemoryStream? stream = new();

        // Act
        var result = StreamHelpers.ReadStream(stream);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void ReadStream_ShouldHandleNullStream()
    {
        // Arrange
        Stream stream = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => StreamHelpers.ReadStream(stream));
    }
}
