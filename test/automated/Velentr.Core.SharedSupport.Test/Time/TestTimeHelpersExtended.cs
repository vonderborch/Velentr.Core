using Microsoft.Xna.Framework;
using Velentr.Core.Time;

namespace Velentr.Core.Test.Time;

[TestFixture]
public class TestTimeHelpersExtended
{
    [Test]
    public void ElapsedMilliSeconds_ShouldReturnCorrectValue()
    {
        // Arrange
        var startTime = TimeSpan.FromMilliseconds(1000);
        var endTime = new GameTime(TimeSpan.Zero, TimeSpan.FromMilliseconds(2000));

        // Act
        var result = TimeHelpersExtended.ElapsedMilliSeconds(startTime, endTime);

        // Assert
        Assert.That(result, Is.EqualTo(1000));
    }

    [Test]
    public void ElapsedSeconds_ShouldReturnCorrectValue()
    {
        // Arrange
        var startTime = TimeSpan.FromSeconds(1);
        var endTime = new GameTime(TimeSpan.Zero, TimeSpan.FromSeconds(2));

        // Act
        var result = TimeHelpersExtended.ElapsedSeconds(startTime, endTime);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void ElapsedMilliSeconds_ShouldHandleZeroElapsedTime()
    {
        // Arrange
        var startTime = TimeSpan.FromMilliseconds(1000);
        var endTime = new GameTime(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

        // Act
        var result = TimeHelpersExtended.ElapsedMilliSeconds(startTime, endTime);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void ElapsedSeconds_ShouldHandleZeroElapsedTime()
    {
        // Arrange
        var startTime = TimeSpan.FromSeconds(1);
        var endTime = new GameTime(TimeSpan.Zero, TimeSpan.FromSeconds(1));

        // Act
        var result = TimeHelpersExtended.ElapsedSeconds(startTime, endTime);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void ElapsedMilliSeconds_ShouldHandleNegativeElapsedTime()
    {
        // Arrange
        var startTime = TimeSpan.FromMilliseconds(2000);
        var endTime = new GameTime(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

        // Act
        var result = TimeHelpersExtended.ElapsedMilliSeconds(startTime, endTime);

        // Assert
        Assert.That(result, Is.EqualTo(1000.0d));
    }

    [Test]
    public void ElapsedSeconds_ShouldHandleNegativeElapsedTime()
    {
        // Arrange
        var startTime = TimeSpan.FromSeconds(2);
        var endTime = new GameTime(TimeSpan.Zero, TimeSpan.FromSeconds(1));

        // Act
        var result = TimeHelpersExtended.ElapsedSeconds(startTime, endTime);

        // Assert
        Assert.That(result, Is.EqualTo(1d));
    }
}