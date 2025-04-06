using NUnit.Framework;
using Velentr.Core.Mathematics.FixedPoint;

namespace Velentr.Core.Test.Mathematics.FixedPoint;

[TestFixture]
public class FixedPointMathTests
{
    [Test]
    public void AddTest()
    {
        var a = FP2.CreateFromDouble(1.23);
        var b = FP2.CreateFromDouble(4.56);
        var result = FixedPointMath<FP2>.Add(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(5.79).Within(0.01));
    }

    [Test]
    public void SubtractTest()
    {
        var a = FP2.CreateFromDouble(5.79);
        var b = FP2.CreateFromDouble(1.23);
        var result = FixedPointMath<FP2>.Subtract(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(4.56).Within(0.01));
    }

    [Test]
    public void MultiplyTest()
    {
        var a = FP2.CreateFromDouble(1.23);
        var b = FP2.CreateFromDouble(4.56);
        var result = FixedPointMath<FP2>.Multiply(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(5.60).Within(0.01));
    }

    [Test]
    public void DivideTest()
    {
        var a = FP2.CreateFromDouble(5.60);
        var b = FP2.CreateFromDouble(1.23);
        var result = FixedPointMath<FP2>.Divide(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(4.56).Within(0.01));
    }

    [Test]
    public void AbsTest()
    {
        var a = FP2.CreateFromDouble(-1.23);
        var result = FixedPointMath<FP2>.Abs(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.23).Within(0.01));
    }

    [Test]
    public void IsZeroTest()
    {
        var a = FP2.CreateFromDouble(0.0);
        var result = FixedPointMath<FP2>.IsZero(a);
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsPositiveTest()
    {
        var a = FP2.CreateFromDouble(1.23);
        var result = FixedPointMath<FP2>.IsPositive(a);
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsNegativeTest()
    {
        var a = FP2.CreateFromDouble(-1.23);
        var result = FixedPointMath<FP2>.IsNegative(a);
        Assert.That(result, Is.True);
    }

    [Test]
    public void MaxTest()
    {
        var a = FP2.CreateFromDouble(1.23);
        var b = FP2.CreateFromDouble(4.56);
        var result = FixedPointMath<FP2>.Max(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(4.56).Within(0.01));
    }

    [Test]
    public void MinTest()
    {
        var a = FP2.CreateFromDouble(1.23);
        var b = FP2.CreateFromDouble(4.56);
        var result = FixedPointMath<FP2>.Min(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(1.23).Within(0.01));
    }

    [Test]
    public void SqrtTest()
    {
        var a = FP2.CreateFromDouble(4.0);
        var result = FixedPointMath<FP2>.Sqrt(a);
        Assert.That(result.ToDouble(), Is.EqualTo(2.0).Within(0.01));
    }

    [Test]
    public void PowTest()
    {
        var a = FP2.CreateFromDouble(2.0);
        var b = FP2.CreateFromDouble(3.0);
        var result = FixedPointMath<FP2>.Pow(a, b);
        Assert.That(result.ToDouble(), Is.EqualTo(8.0).Within(0.01));
    }

    [Test]
    public void LogTest()
    {
        var a = FP2.CreateFromDouble(Math.E);
        var result = FixedPointMath<FP2>.Log(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void ExpTest()
    {
        var a = FP2.CreateFromDouble(1.0);
        var result = FixedPointMath<FP2>.Exp(a);
        Assert.That(result.ToDouble(), Is.EqualTo(Math.E).Within(0.01));
    }

    [Test]
    public void SinTest()
    {
        var a = FP2.CreateFromDouble(Math.PI / 2);
        var result = FixedPointMath<FP2>.Sin(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void CosTest()
    {
        var a = FP2.CreateFromDouble(0.0);
        var result = FixedPointMath<FP2>.Cos(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void TanTest()
    {
        var a = FP2.CreateFromDouble(Math.PI / 4);
        var result = FixedPointMath<FP2>.Tan(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void AsinTest()
    {
        var a = FP2.CreateFromDouble(1.0);
        var result = FixedPointMath<FP2>.Asin(a);
        Assert.That(result.ToDouble(), Is.EqualTo(Math.PI / 2).Within(0.01));
    }

    [Test]
    public void AcosTest()
    {
        var a = FP2.CreateFromDouble(1.0);
        var result = FixedPointMath<FP2>.Acos(a);
        Assert.That(result.ToDouble(), Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void AtanTest()
    {
        var a = FP2.CreateFromDouble(1.0);
        var result = FixedPointMath<FP2>.Atan(a);
        Assert.That(result.ToDouble(), Is.EqualTo(Math.PI / 4).Within(0.01));
    }

    [Test]
    public void Atan2Test()
    {
        var y = FP2.CreateFromDouble(1.0);
        var x = FP2.CreateFromDouble(1.0);
        var result = FixedPointMath<FP2>.Atan2(y, x);
        Assert.That(result.ToDouble(), Is.EqualTo(Math.PI / 4).Within(0.01));
    }

    [Test]
    public void RoundTest()
    {
        var a = FP2.CreateFromDouble(1.234);
        var result = FixedPointMath<FP2>.Round(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void FloorTest()
    {
        var a = FP2.CreateFromDouble(1.234);
        var result = FixedPointMath<FP2>.Floor(a);
        Assert.That(result.ToDouble(), Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void CeilingTest()
    {
        var a = FP2.CreateFromDouble(1.234);
        var result = FixedPointMath<FP2>.Ceiling(a);
        Assert.That(result.ToDouble(), Is.EqualTo(2.0).Within(0.01));
    }
}
