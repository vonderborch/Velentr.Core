using NUnit.Framework;
using System.Numerics;
using Velentr.Core.Mathematics;

namespace Velentr.Core.Test.Mathematics;

[TestFixture]
public class TestMaths
{
    [Test]
    public void TestCircularClamp()
    {
        Assert.That(Maths<int>.CircularClamp(1, 0, 10), Is.EqualTo(1));
        Assert.That(Maths<int>.CircularClamp(10, 0, 10), Is.EqualTo(0));
        Assert.That(Maths<int>.CircularClamp(-5, 0, 10), Is.EqualTo(5));
    }

    [Test]
    public void TestClamp()
    {
        Assert.That(Maths<int>.Clamp(5, 0, 10), Is.EqualTo(5));
        Assert.That(Maths<int>.Clamp(-5, 0, 10), Is.EqualTo(0));
        Assert.That(Maths<int>.Clamp(15, 0, 10), Is.EqualTo(10));
    }

    [Test]
    public void TestDeltaClamp()
    {
        Assert.That(Maths<int>.DeltaClamp(15, 10, -5, 5, 0, 10), Is.EqualTo(10));
        Assert.That(Maths<int>.DeltaClamp(-5, 0, -5, 5, 0, 10), Is.EqualTo(0));
        Assert.That(Maths<int>.DeltaClamp(20, 10, -5, 5, 0, 10), Is.EqualTo(10));
    }

    [Test]
    public void TestMaximum()
    {
        Assert.That(Maths<int>.Maximum(1, 5, 10, 3), Is.EqualTo(10));
        Assert.That(Maths<int>.Maximum(20, 15, 10, 5), Is.EqualTo(20));
    }

    [Test]
    public void TestMinimum()
    {
        Assert.That(Maths<int>.Minimum(1, 5, 10, 3), Is.EqualTo(1));
        Assert.That(Maths<int>.Minimum(20, 15, 10, 5), Is.EqualTo(5));
    }

    [Test]
    public void TestMinMaxDelta()
    {
        Assert.That(Maths<int>.MinMaxDelta(1, 5, 10, 3), Is.EqualTo(9));
        Assert.That(Maths<int>.MinMaxDelta(20, 5, 10, 5), Is.EqualTo(15));
    }
}