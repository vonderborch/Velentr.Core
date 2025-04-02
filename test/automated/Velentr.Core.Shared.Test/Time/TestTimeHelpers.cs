using Velentr.Core.Time;

namespace Velentr.Core.Test.Time;

[TestFixture]
public class TestTimeHelpers
{
    [Test]
    public void TestElapsedMilliSeconds_ValidTimes()
    {
        var startTime = new TimeSpan(0, 0, 1);
        var endTime = new TimeSpan(0, 0, 2);
        var result = TimeHelpers.ElapsedMilliSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(1000));
    }

    [Test]
    public void TestElapsedMilliSeconds_StartTimeMinValue()
    {
        var startTime = TimeSpan.MinValue;
        var endTime = new TimeSpan(0, 0, 2);
        var result = TimeHelpers.ElapsedMilliSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(2000));
    }

    [Test]
    public void TestElapsedMilliSeconds_EndTimeBeforeStartTime()
    {
        var startTime = new TimeSpan(0, 0, 2);
        var endTime = new TimeSpan(0, 0, 1);
        var result = TimeHelpers.ElapsedMilliSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(1000));
    }

    [Test]
    public void TestElapsedSeconds_ValidTimes()
    {
        var startTime = new TimeSpan(0, 0, 1);
        var endTime = new TimeSpan(0, 0, 2);
        var result = TimeHelpers.ElapsedSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void TestElapsedSeconds_StartTimeMinValue()
    {
        var startTime = TimeSpan.MinValue;
        var endTime = new TimeSpan(0, 0, 2);
        var result = TimeHelpers.ElapsedSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void TestElapsedSeconds_EndTimeBeforeStartTime()
    {
        var startTime = new TimeSpan(0, 0, 2);
        var endTime = new TimeSpan(0, 0, 1);
        var result = TimeHelpers.ElapsedSeconds(startTime, endTime);
        Assert.That(result, Is.EqualTo(1));
    }
}