using System.Globalization;
using Velentr.Core.Mathematics.FixedPoint;

namespace Velentr.Core.Test.Mathematics.FixedPoint;

[TestFixture]
public class TestFp2
{
    [Test]
    public void TestToString()
    {
        FP2 value = new() { RawValue = 12345 };
        Assert.That(value.ToString(), Is.EqualTo("96.45"));
    }

    [Test]
    public void TestToString_FromDouble()
    {
        FP2 value = FP2.CreateFromDouble(3.57);
        Assert.That(value.ToString(), Is.EqualTo("3.57"));
        value += 1;
        Assert.That(value.ToString(), Is.EqualTo("4.57"));
        value += 1.8d;
        Assert.That(value.ToString(), Is.EqualTo("6.37"));
        value += 55.01d;
        Assert.That(value.ToString(), Is.EqualTo("61.38"));
    }

    [Test]
    public void TestToString_FromDoubleWeird()
    {
        FP2 value = FP2.CreateFromDouble(7d / 3);
        Assert.That(value.ToString(), Is.EqualTo("2.34"));
        value += 1;
        Assert.That(value.ToString(), Is.EqualTo("3.34"));
        value += 1.5d;
        Assert.That(value.ToString(), Is.EqualTo("4.84"));
        value += 56.04d;
        Assert.That(value.ToString(), Is.EqualTo("60.88"));
    }

    [Test]
    public void TestCreateFromDouble()
    {
        FP2 value = FP2.CreateFromDouble(3.57);
        Assert.That(value.RawValue, Is.EqualTo(457));
    }

    [Test]
    public void TestCreateFromFloat()
    {
        FP2 value = FP2.CreateFromFloat(3.57f);
        Assert.That(value.RawValue, Is.EqualTo(456));
    }

    [Test]
    public void TestToDouble()
    {
        FP2 value = new() { RawValue = 12345 };
        Assert.That(value.ToDouble(), Is.EqualTo(96.445).Within(0.001));
    }

    [Test]
    public void TestToFloat()
    {
        FP2 value = new() { RawValue = 12345 };
        Assert.That(value.ToFloat(), Is.EqualTo(96.445f).Within(0.001f));
    }

    [Test]
    public void TestAddition()
    {
        FP2 value1 = new() { RawValue = 12345 };
        FP2 value2 = new() { RawValue = 67890 };
        FP2 result = value1 + value2;
        Assert.That(result.RawValue, Is.EqualTo(80235));
    }

    [Test]
    public void TestSubtraction()
    {
        FP2 value1 = new() { RawValue = 67890 };
        FP2 value2 = new() { RawValue = 12345 };
        FP2 result = value1 - value2;
        Assert.That(result.RawValue, Is.EqualTo(55545));
    }

    [Test]
    public void TestMultiplication()
    {
        FP2 value1 = new() { RawValue = 12345 };
        FP2 value2 = new() { RawValue = 2 << FP2.Shift };
        FP2 result = value1 * value2;
        Assert.That(result.RawValue, Is.EqualTo(24690));
    }

    [Test]
    public void TestDivision()
    {
        FP2 value1 = new() { RawValue = 24690 };
        FP2 value2 = new() { RawValue = 2 << FP2.Shift };
        FP2 result = value1 / value2;
        Assert.That(result.RawValue, Is.EqualTo(12345));
    }

    [Test]
    public void TestParse()
    {
        FP2 value = FP2.Parse("3.57", CultureInfo.InvariantCulture);
        Assert.That(value.RawValue, Is.EqualTo(457));
    }

    [Test]
    public void TestTryParse()
    {
        var success = FP2.TryParse("3.57", CultureInfo.InvariantCulture, out FP2 value);
        Assert.That(success, Is.True);
        Assert.That(value.RawValue, Is.EqualTo(457));
    }

    [Test]
    public void TestBounds()
    {
        Assert.That(FP2.MaxValue.ToString(), Is.EqualTo("72057594037927936.00"));
        Assert.That(FP2.MinValue.ToString(), Is.EqualTo("-72057594037927936.00"));
    }
}
