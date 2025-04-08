using System.Globalization;
using Velentr.Core.Mathematics.FixedPoint;

namespace Velentr.Core.Test.Mathematics.FixedPoint;

[TestFixture]
public class TestFp6
{
    [Test]
    public void TestToString()
    {
        FP6 value = new() { RawValue = 12345 };
        Assert.That(value.ToString(), Is.EqualTo("0.011773"));
    }

    [Test]
    public void TestToString_FromDouble()
    {
        FP6 value = FP6.CreateFromDouble(3.005723);
        Assert.That(value.ToString(), Is.EqualTo("3.005723"));
        value += 1;
        Assert.That(value.ToString(), Is.EqualTo("4.005723"));
        value += 1.5d;
        Assert.That(value.ToString(), Is.EqualTo("5.505723"));
        value += 55.001d;
        Assert.That(value.ToString(), Is.EqualTo("60.506723"));
        value += 3.0001d;
        Assert.That(value.ToString(), Is.EqualTo("63.506824"));
        value += 3.000004d;
        Assert.That(value.ToString(), Is.EqualTo("66.506827"));
    }

    [Test]
    public void TestToString_FromDoubleWeird()
    {
        FP6 value = FP6.CreateFromDouble(7d / 3);
        Assert.That(value.ToString(), Is.EqualTo("2.333333"));
        value += 1;
        Assert.That(value.ToString(), Is.EqualTo("3.333333"));
        value += 1.5d;
        Assert.That(value.ToString(), Is.EqualTo("4.833333"));
        value += 56.001d;
        Assert.That(value.ToString(), Is.EqualTo("60.834333"));
        value += 3.0001d;
        Assert.That(value.ToString(), Is.EqualTo("63.834434"));
        value += 3.000001d;
        Assert.That(value.ToString(), Is.EqualTo("66.834435"));
    }

    [Test]
    public void TestCreateFromDouble()
    {
        FP6 value = FP6.CreateFromDouble(3.005723);
        Assert.That(value.RawValue, Is.EqualTo(3151729));
    }

    [Test]
    public void TestCreateFromFloat()
    {
        FP6 value = FP6.CreateFromFloat(3.005723f);
        Assert.That(value.RawValue, Is.EqualTo(3151729));
    }

    [Test]
    public void TestToDouble()
    {
        FP6 value = new() { RawValue = 12345 };
        Assert.That(value.ToDouble(), Is.EqualTo(0.011773).Within(0.000001));
    }

    [Test]
    public void TestToFloat()
    {
        FP6 value = new() { RawValue = 12345 };
        Assert.That(value.ToFloat(), Is.EqualTo(0.011773f).Within(0.000001f));
    }

    [Test]
    public void TestAddition()
    {
        FP6 value1 = new() { RawValue = 12345 };
        FP6 value2 = new() { RawValue = 67890 };
        FP6 result = value1 + value2;
        Assert.That(result.RawValue, Is.EqualTo(80235));
    }

    [Test]
    public void TestSubtraction()
    {
        FP6 value1 = new() { RawValue = 67890 };
        FP6 value2 = new() { RawValue = 12345 };
        FP6 result = value1 - value2;
        Assert.That(result.RawValue, Is.EqualTo(55545));
    }

    [Test]
    public void TestMultiplication()
    {
        FP6 value1 = new() { RawValue = 12345 };
        FP6 value2 = new() { RawValue = 2 << FP6.Shift };
        FP6 result = value1 * value2;
        Assert.That(result.RawValue, Is.EqualTo(24690));
    }

    [Test]
    public void TestDivision()
    {
        FP6 value1 = new() { RawValue = 24690 };
        FP6 value2 = new() { RawValue = 2 << FP6.Shift };
        FP6 result = value1 / value2;
        Assert.That(result.RawValue, Is.EqualTo(12345));
    }

    [Test]
    public void TestParse()
    {
        FP6 value = FP6.Parse("3.005723", CultureInfo.InvariantCulture);
        Assert.That(value.RawValue, Is.EqualTo(3151729));
    }

    [Test]
    public void TestTryParse()
    {
        var success = FP6.TryParse("3.005723", CultureInfo.InvariantCulture, out FP6 value);
        Assert.That(success, Is.True);
        Assert.That(value.RawValue, Is.EqualTo(3151729));
    }

    [Test]
    public void TestBounds()
    {
        Assert.That(FP6.MaxValue.ToString(), Is.EqualTo("8796093022208.000000"));
        Assert.That(FP6.MinValue.ToString(), Is.EqualTo("-8796093022208.000000"));
    }
}
