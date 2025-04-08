using Velentr.Core.Mathematics.FixedPoint;

namespace Velentr.Core.Test.Mathematics.FixedPoint;

[TestFixture]
public class FixedPointMathTests
{
    [Test]
    public void AddTest()
    {
        FP2 a = FP2.CreateFromDouble(1.23);
        FP2 b = FP2.CreateFromDouble(4.56);
        FP2 result = FixedPointMath<FP2>.Add(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(5.79).Within(0.01));
    }

    [Test]
    public void SubtractTest()
    {
        FP2 a = FP2.CreateFromDouble(5.79);
        FP2 b = FP2.CreateFromDouble(1.23);
        FP2 result = FixedPointMath<FP2>.Subtract(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(4.56).Within(0.01));
    }

    [Test]
    public void MultiplyTest()
    {
        FP2 a = FP2.CreateFromDouble(1.23);
        FP2 b = FP2.CreateFromDouble(4.56);
        FP2 result = FixedPointMath<FP2>.Multiply(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(5.60).Within(0.01));
    }

    [Test]
    public void DivideTest()
    {
        FP2 a = FP2.CreateFromDouble(5.60);
        FP2 b = FP2.CreateFromDouble(1.23);
        FP2 result = FixedPointMath<FP2>.Divide(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(4.56).Within(0.01));
    }

    [Test]
    public void AbsTest()
    {
        FP2 a = FP2.CreateFromDouble(-1.23);
        FP2 result = FixedPointMath<FP2>.Abs(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.23).Within(0.01));
    }

    [Test]
    public void IsZeroTest()
    {
        FP2 a = FP2.CreateFromDouble(0.0);
        var result = FixedPointMath<FP2>.IsZero(a);
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsPositiveTest()
    {
        FP2 a = FP2.CreateFromDouble(1.23);
        var result = FixedPointMath<FP2>.IsPositive(a);
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsNegativeTest()
    {
        FP2 a = FP2.CreateFromDouble(-1.23);
        var result = FixedPointMath<FP2>.IsNegative(a);
        Assert.That(result, Is.True);
    }

    [Test]
    public void MaxTest()
    {
        FP2 a = FP2.CreateFromDouble(1.23);
        FP2 b = FP2.CreateFromDouble(4.56);
        FP2 result = FixedPointMath<FP2>.Max(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(4.56).Within(0.01));
    }

    [Test]
    public void MinTest()
    {
        FP2 a = FP2.CreateFromDouble(1.23);
        FP2 b = FP2.CreateFromDouble(4.56);
        FP2 result = FixedPointMath<FP2>.Min(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(1.23).Within(0.01));
    }

    [Test]
    public void SqrtTest()
    {
        FP2 a = FP2.CreateFromDouble(4.0);
        FP2 result = FixedPointMath<FP2>.Sqrt(a);
        Assert.That(result.ToDouble(), Is.EqualTo(2.0).Within(0.01));
    }

    [Test]
    public void PowTest()
    {
        FP2 a = FP2.CreateFromDouble(2.0);
        FP2 b = FP2.CreateFromDouble(3.0);
        FP2 result = FixedPointMath<FP2>.Pow(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(8.0).Within(0.01));
    }

    [Test]
    public void LogTest()
    {
        FP2 a = FP2.CreateFromDouble(Math.E);
        FP2 result = FixedPointMath<FP2>.Log(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void ExpTest()
    {
        FP2 a = FP2.CreateFromDouble(1.0);
        FP2 result = FixedPointMath<FP2>.Exp(a);
        Assert.That(result.ToDouble(), Is.EqualTo(Math.E).Within(0.01));
    }

    [Test]
    public void SinTest()
    {
        FP2 a = FP2.CreateFromDouble(Math.PI / 2);
        FP2 result = FixedPointMath<FP2>.Sin(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void CosTest()
    {
        FP2 a = FP2.CreateFromDouble(0.0);
        FP2 result = FixedPointMath<FP2>.Cos(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void TanTest()
    {
        FP2 a = FP2.CreateFromDouble(Math.PI / 4);
        FP2 result = FixedPointMath<FP2>.Tan(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void AsinTest()
    {
        FP2 a = FP2.CreateFromDouble(1.0);
        FP2 result = FixedPointMath<FP2>.Asin(a);
        Assert.That(result.ToDouble(), Is.EqualTo(Math.PI / 2).Within(0.01));
    }

    [Test]
    public void AcosTest()
    {
        FP2 a = FP2.CreateFromDouble(1.0);
        FP2 result = FixedPointMath<FP2>.Acos(a);
        Assert.That(result.ToDouble(), Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void AtanTest()
    {
        FP2 a = FP2.CreateFromDouble(1.0);
        FP2 result = FixedPointMath<FP2>.Atan(a);
        Assert.That(result.ToDouble(), Is.EqualTo(Math.PI / 4).Within(0.01));
    }

    [Test]
    public void Atan2Test()
    {
        FP2 y = FP2.CreateFromDouble(1.0);
        FP2 x = FP2.CreateFromDouble(1.0);
        FP2 result = FixedPointMath<FP2>.Atan2(y, x);
        Assert.That(result.ToDouble(), Is.EqualTo(Math.PI / 4).Within(0.01));
    }

    [Test]
    public void RoundTest()
    {
        FP2 a = FP2.CreateFromDouble(1.234);
        FP2 result = FixedPointMath<FP2>.Round(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void FloorTest()
    {
        FP2 a = FP2.CreateFromDouble(1.234);
        FP2 result = FixedPointMath<FP2>.Floor(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void CeilingTest()
    {
        FP2 a = FP2.CreateFromDouble(1.234);
        FP2 result = FixedPointMath<FP2>.Ceiling(a);
        Assert.That(result.ToDouble(), Is.EqualTo(2.0).Within(0.01));
    }
}
