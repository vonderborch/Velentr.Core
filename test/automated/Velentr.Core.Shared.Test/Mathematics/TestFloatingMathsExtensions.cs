using Velentr.Core.Mathematics;

namespace Velentr.Core.Test.Mathematics;

[TestFixture]
public class TestFloatingMathsExtensions
{
    [Test]
    public void TestApproximatelyEqualTo_Float()
    {
        Assert.That(0.1f.ApproximatelyEqualTo(0.1f + 0.2f - 0.2f), Is.True);
        Assert.That(0.1f.ApproximatelyEqualTo(0.2f), Is.False);
    }

    [Test]
    public void TestApproximatelyEqualTo_Double()
    {
        Assert.That(0.1d.ApproximatelyEqualTo(0.1d + 0.2d - 0.2d), Is.True);
        Assert.That(0.1d.ApproximatelyEqualTo(0.2d), Is.False);
    }
}
