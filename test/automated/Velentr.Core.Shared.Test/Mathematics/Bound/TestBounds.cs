using Velentr.Core.Mathematics.Bound;

namespace Velentr.Core.Test.Mathematics.Bound;

[TestFixture]
public class TestBounds
{
    [Test]
    public void TestBoundsInitialization()
    {
        Bounds<int> bounds = new(5, 10);
        Assert.That(bounds.Minimum, Is.EqualTo(5));
        Assert.That(bounds.Maximum, Is.EqualTo(10));
    }

    [Test]
    public void TestBoundsInitializationWithSwappedValues()
    {
        Bounds<int> bounds = new(10, 5);
        Assert.That(bounds.Minimum, Is.EqualTo(5));
        Assert.That(bounds.Maximum, Is.EqualTo(10));
    }

    [Test]
    public void TestBoundsCopyConstructor()
    {
        Bounds<int> original = new(5, 10);
        Bounds<int> copy = new(original);
        Assert.That(copy.Minimum, Is.EqualTo(5));
        Assert.That(copy.Maximum, Is.EqualTo(10));
    }

    [Test]
    public void TestSetMinimum()
    {
        Bounds<int> bounds = new(5, 10);
        bounds.Minimum = 7;
        Assert.That(bounds.Minimum, Is.EqualTo(7));
        Assert.That(bounds.Maximum, Is.EqualTo(10));
    }

    [Test]
    public void TestSetMaximum()
    {
        Bounds<int> bounds = new(5, 10);
        bounds.Maximum = 12;
        Assert.That(bounds.Minimum, Is.EqualTo(5));
        Assert.That(bounds.Maximum, Is.EqualTo(12));
    }

    [Test]
    public void TestClampValue()
    {
        Bounds<int> bounds = new(5, 10);
        Assert.That(bounds.ClampValue(4), Is.EqualTo(5));
        Assert.That(bounds.ClampValue(6), Is.EqualTo(6));
        Assert.That(bounds.ClampValue(11), Is.EqualTo(10));
    }

    [Test]
    public void TestCircularClampValue()
    {
        Bounds<int> bounds = new(5, 10);
        Assert.That(bounds.CircularClampValue(4), Is.EqualTo(9));
        Assert.That(bounds.CircularClampValue(6), Is.EqualTo(6));
        Assert.That(bounds.CircularClampValue(10), Is.EqualTo(5));
    }

    [Test]
    public void TestEquality()
    {
        Bounds<int> bounds1 = new(5, 10);
        Bounds<int> bounds2 = new(5, 10);
        Bounds<int> bounds3 = new(6, 10);
        Assert.That(bounds1 == bounds2, Is.True);
        Assert.That(bounds1 != bounds3, Is.True);
    }
}
