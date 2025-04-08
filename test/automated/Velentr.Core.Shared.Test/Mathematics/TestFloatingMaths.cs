using Velentr.Core.Mathematics;

namespace Velentr.Core.Test.Mathematics;

[TestFixture]
public class TestFloatingMaths
{
    [Test]
    public void TestApproximatelyEqual()
    {
        Assert.That(FloatingMaths<float>.ApproximatelyEqual(0.1f, 0.1f, 0.0001f), Is.True);
        Assert.That(FloatingMaths<float>.ApproximatelyEqual(0.1f, 0.2f, 0.0001f), Is.False);
    }

    [Test]
    public void TestIsNegativeZero()
    {
        Assert.That(FloatingMaths<float>.IsNegativeZero(-0.0f, 0.0001f), Is.True);
        Assert.That(FloatingMaths<float>.IsNegativeZero(0.0f, 0.0001f), Is.False);
    }

    [Test]
    public void TestByteToPercentage()
    {
        Assert.That(FloatingMaths<float>.ByteToPercentage(0), Is.EqualTo(0.0f).Within(0.01));
        Assert.That(FloatingMaths<float>.ByteToPercentage(128), Is.EqualTo(0.5f).Within(0.01));
        Assert.That(FloatingMaths<float>.ByteToPercentage(255), Is.EqualTo(1.0f).Within(0.01));
    }

    [Test]
    public void TestPercentageToByte()
    {
        Assert.That(FloatingMaths<float>.PercentageToByte(0.0f), Is.EqualTo(0));
        Assert.That(FloatingMaths<float>.PercentageToByte(0.5f), Is.EqualTo(128));
        Assert.That(FloatingMaths<float>.PercentageToByte(1.0f), Is.EqualTo(255));
    }
}
