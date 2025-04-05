using System;
using System.Globalization;
using NUnit.Framework;
using Velentr.Core.Mathematics.FixedPoint;

namespace Velentr.Core.Test.Mathematics.FixedPoint;

[TestFixture]
public class TestFixedPointPrecision2I
{
    [Test]
    public void TestToString()
    {
        var value = new FixedPointPrecision2I { RawValue = 12345 };
        Assert.That(value.ToString(), Is.EqualTo("96.45"));
    }
        
    [Test]
    public void TestToString_FromDouble()
    {
        var value = FixedPointPrecision2I.CreateFromDouble(3.57);
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
        var value = FixedPointPrecision2I.CreateFromDouble(7d / 3);
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
        var value = FixedPointPrecision2I.CreateFromDouble(3.57);
        Assert.That(value.RawValue, Is.EqualTo(457));
    }

    [Test]
    public void TestCreateFromFloat()
    {
        var value = FixedPointPrecision2I.CreateFromFloat(3.57f);
        Assert.That(value.RawValue, Is.EqualTo(456));
    }

    [Test]
    public void TestToDouble()
    {
        var value = new FixedPointPrecision2I { RawValue = 12345 };
        Assert.That(value.ToDouble(), Is.EqualTo(96.445).Within(0.001));
    }

    [Test]
    public void TestToFloat()
    {
        var value = new FixedPointPrecision2I { RawValue = 12345 };
        Assert.That(value.ToFloat(), Is.EqualTo(96.445f).Within(0.001f));
    }

    [Test]
    public void TestAddition()
    {
        var value1 = new FixedPointPrecision2I { RawValue = 12345 };
        var value2 = new FixedPointPrecision2I { RawValue = 67890 };
        var result = value1 + value2;
        Assert.That(result.RawValue, Is.EqualTo(80235));
    }

    [Test]
    public void TestSubtraction()
    {
        var value1 = new FixedPointPrecision2I { RawValue = 67890 };
        var value2 = new FixedPointPrecision2I { RawValue = 12345 };
        var result = value1 - value2;
        Assert.That(result.RawValue, Is.EqualTo(55545));
    }

    [Test]
    public void TestMultiplication()
    {
        var value1 = new FixedPointPrecision2I { RawValue = 12345 };
        var value2 = new FixedPointPrecision2I { RawValue = 2 << FixedPointPrecision2I.Shift };
        var result = value1 * value2;
        Assert.That(result.RawValue, Is.EqualTo(24690));
    }

    [Test]
    public void TestDivision()
    {
        var value1 = new FixedPointPrecision2I { RawValue = 24690 };
        var value2 = new FixedPointPrecision2I { RawValue = 2 << FixedPointPrecision2I.Shift };
        var result = value1 / value2;
        Assert.That(result.RawValue, Is.EqualTo(12345));
    }

    [Test]
    public void TestParse()
    {
        var value = FixedPointPrecision2I.Parse("3.57", CultureInfo.InvariantCulture);
        Assert.That(value.RawValue, Is.EqualTo(457));
    }

    [Test]
    public void TestTryParse()
    {
        var success = FixedPointPrecision2I.TryParse("3.57", CultureInfo.InvariantCulture, out var value);
        Assert.That(success, Is.True);
        Assert.That(value.RawValue, Is.EqualTo(457));
    }

    [Test]
    public void TestBounds()
    {
        Assert.That(FixedPointPrecision2I.MaxValue.ToString(), Is.EqualTo("16777215.99"));
        Assert.That(FixedPointPrecision2I.MinValue.ToString(), Is.EqualTo("-16777216.00"));
    }
}