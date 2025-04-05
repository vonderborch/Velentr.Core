using System;
using System.Globalization;
using NUnit.Framework;
using Velentr.Core.Mathematics.FixedPoint;

namespace Velentr.Core.Test.Mathematics.FixedPoint;

[TestFixture]
public class TestFixedPointPrecision6
{
    [Test]
    public void TestToString()
    {
        var value = new FixedPointPrecision6 { RawValue = 12345 };
        Assert.That(value.ToString(), Is.EqualTo("0.011773"));
    }
        
    [Test]
    public void TestToString_FromDouble()
    {
        var value = FixedPointPrecision6.CreateFromDouble(3.005723);
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
        var value = FixedPointPrecision6.CreateFromDouble(7d / 3);
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
        var value = FixedPointPrecision6.CreateFromDouble(3.005723);
        Assert.That(value.RawValue, Is.EqualTo(3151729));
    }

    [Test]
    public void TestCreateFromFloat()
    {
        var value = FixedPointPrecision6.CreateFromFloat(3.005723f);
        Assert.That(value.RawValue, Is.EqualTo(3151729));
    }

    [Test]
    public void TestToDouble()
    {
        var value = new FixedPointPrecision6 { RawValue = 12345 };
        Assert.That(value.ToDouble(), Is.EqualTo(0.011773).Within(0.000001));
    }

    [Test]
    public void TestToFloat()
    {
        var value = new FixedPointPrecision6 { RawValue = 12345 };
        Assert.That(value.ToFloat(), Is.EqualTo(0.011773f).Within(0.000001f));
    }

    [Test]
    public void TestAddition()
    {
        var value1 = new FixedPointPrecision6 { RawValue = 12345 };
        var value2 = new FixedPointPrecision6 { RawValue = 67890 };
        var result = value1 + value2;
        Assert.That(result.RawValue, Is.EqualTo(80235));
    }

    [Test]
    public void TestSubtraction()
    {
        var value1 = new FixedPointPrecision6 { RawValue = 67890 };
        var value2 = new FixedPointPrecision6 { RawValue = 12345 };
        var result = value1 - value2;
        Assert.That(result.RawValue, Is.EqualTo(55545));
    }

    [Test]
    public void TestMultiplication()
    {
        var value1 = new FixedPointPrecision6 { RawValue = 12345 };
        var value2 = new FixedPointPrecision6 { RawValue = 2 << FixedPointPrecision6.Shift };
        var result = value1 * value2;
        Assert.That(result.RawValue, Is.EqualTo(24690));
    }

    [Test]
    public void TestDivision()
    {
        var value1 = new FixedPointPrecision6 { RawValue = 24690 };
        var value2 = new FixedPointPrecision6 { RawValue = 2 << FixedPointPrecision6.Shift };
        var result = value1 / value2;
        Assert.That(result.RawValue, Is.EqualTo(12345));
    }

    [Test]
    public void TestParse()
    {
        var value = FixedPointPrecision6.Parse("3.005723", CultureInfo.InvariantCulture);
        Assert.That(value.RawValue, Is.EqualTo(3151729));
    }

    [Test]
    public void TestTryParse()
    {
        var success = FixedPointPrecision6.TryParse("3.005723", CultureInfo.InvariantCulture, out var value);
        Assert.That(success, Is.True);
        Assert.That(value.RawValue, Is.EqualTo(3151729));
    }

    [Test]
    public void TestBounds()
    {
        Assert.That(FixedPointPrecision6.MaxValue.ToString(), Is.EqualTo("8796093022208.000000"));
        Assert.That(FixedPointPrecision6.MinValue.ToString(), Is.EqualTo("-8796093022208.000000"));
    }
}