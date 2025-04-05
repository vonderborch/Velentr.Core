using NUnit.Framework;
using System.Numerics;
using Velentr.Core.Mathematics.Numerics;

namespace Velentr.Core.Test.Mathematics.Numerics;

[TestFixture]
public class TestNumericExtensions
{
    [Test]
    public void TestToCircularBoundedNumber()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        var circularBoundedNumber = boundedNumber.ToCircularBoundedNumber();
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(7));
        Assert.That(circularBoundedNumber.Minimum, Is.EqualTo(5));
        Assert.That(circularBoundedNumber.Maximum, Is.EqualTo(10));
    }

    [Test]
    public void TestToBoundedNumber()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(7, 5, 10);
        var boundedNumber = circularBoundedNumber.ToBoundedNumber();
        Assert.That(boundedNumber.Value, Is.EqualTo(7));
        Assert.That(boundedNumber.Minimum, Is.EqualTo(5));
        Assert.That(boundedNumber.Maximum, Is.EqualTo(10));
    }
}