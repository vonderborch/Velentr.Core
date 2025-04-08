using Velentr.Core.Mathematics.Numerics;

namespace Velentr.Core.Test.Mathematics.Numerics;

[TestFixture]
public class TestNumericExtensions
{
    [Test]
    public void TestToCircularBoundedNumber()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        CircularBoundedNumber<int> circularBoundedNumber = boundedNumber.ToCircularBoundedNumber();
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(7));
        Assert.That(circularBoundedNumber.Minimum, Is.EqualTo(5));
        Assert.That(circularBoundedNumber.Maximum, Is.EqualTo(10));
    }

    [Test]
    public void TestToBoundedNumber()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(7, 5, 10);
        BoundedNumber<int> boundedNumber = circularBoundedNumber.ToBoundedNumber();
        Assert.That(boundedNumber.Value, Is.EqualTo(7));
        Assert.That(boundedNumber.Minimum, Is.EqualTo(5));
        Assert.That(boundedNumber.Maximum, Is.EqualTo(10));
    }
}
