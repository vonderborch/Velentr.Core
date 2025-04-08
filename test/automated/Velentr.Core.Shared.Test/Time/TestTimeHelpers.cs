using Velentr.Core.Time;

namespace Velentr.Core.Test.Time;

[TestFixture]
public class TestTimeHelpers
{
    [Test]
    public void TestElapsedMilliSeconds_ValidTimes()
    {
        TimeSpan startTime = new(0, 0, 1);
        TimeSpan endTime = new(0, 0, 2);
        var result = TimeHelpers.ElapsedMilliSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(1000));
    }

    [Test]
    public void TestElapsedMilliSeconds_StartTimeMinValue()
    {
        TimeSpan startTime = TimeSpan.MinValue;
        TimeSpan endTime = new(0, 0, 2);
        var result = TimeHelpers.ElapsedMilliSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(2000));
    }

    [Test]
    public void TestElapsedMilliSeconds_EndTimeBeforeStartTime()
    {
        TimeSpan startTime = new(0, 0, 2);
        TimeSpan endTime = new(0, 0, 1);
        var result = TimeHelpers.ElapsedMilliSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(1000));
    }

    [Test]
    public void TestElapsedSeconds_ValidTimes()
    {
        TimeSpan startTime = new(0, 0, 1);
        TimeSpan endTime = new(0, 0, 2);
        var result = TimeHelpers.ElapsedSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void TestElapsedSeconds_StartTimeMinValue()
    {
        TimeSpan startTime = TimeSpan.MinValue;
        TimeSpan endTime = new(0, 0, 2);
        var result = TimeHelpers.ElapsedSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void TestElapsedSeconds_EndTimeBeforeStartTime()
    {
        TimeSpan startTime = new(0, 0, 2);
        TimeSpan endTime = new(0, 0, 1);
        var result = TimeHelpers.ElapsedSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(1));
    }
}
