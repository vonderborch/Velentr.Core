using System;
using System.Globalization;
using NUnit.Framework;
using Velentr.Core.Mathematics.FixedPoint;

namespace Velentr.Core.Test.Mathematics.FixedPoint;

[TestFixture]
public class TestFixedPointPrecision4
{
    [Test]
    public void TestToString()
    {
        var value = new FixedPointPrecision4 { RawValue = 12345 };
        Assert.That(value.ToString(), Is.EqualTo("0.7535"));
    }
        
    [Test]
    public void TestToString_FromDouble()
    {
        var value = FixedPointPrecision4.CreateFromDouble(3.0057);
        Assert.That(value.ToString(), Is.EqualTo("3.0057"));
        value += 1;
        Assert.That(value.ToString(), Is.EqualTo("4.0057"));
        value += 1.5d;
        Assert.That(value.ToString(), Is.EqualTo("5.5057"));
        value += 55.001d;
        Assert.That(value.ToString(), Is.EqualTo("60.5067"));
        value += 3.0001d;
        Assert.That(value.ToString(), Is.EqualTo("63.5068"));
    }
        
    [Test]
    public void TestToString_FromDoubleWeird()
    {
        var value = FixedPointPrecision4.CreateFromDouble(7d / 3);
        Assert.That(value.ToString(), Is.EqualTo("2.3333"));
        value += 1;
        Assert.That(value.ToString(), Is.EqualTo("3.3333"));
        value += 1.5d;
        Assert.That(value.ToString(), Is.EqualTo("4.8333"));
        value += 56.001d;
        Assert.That(value.ToString(), Is.EqualTo("60.8343"));
        value += 3.0001d;
        Assert.That(value.ToString(), Is.EqualTo("63.8344"));
    }

    [Test]
    public void TestCreateFromDouble()
    {
        var value = FixedPointPrecision4.CreateFromDouble(3.0057);
        Assert.That(value.RawValue, Is.EqualTo(49245));
    }

    [Test]
    public void TestCreateFromFloat()
    {
        var value = FixedPointPrecision4.CreateFromFloat(3.0057f);
        Assert.That(value.RawValue, Is.EqualTo(49245));
    }

    [Test]
    public void TestToDouble()
    {
        var value = new FixedPointPrecision4 { RawValue = 12345 };
        Assert.That(value.ToDouble(), Is.EqualTo(0.7535).Within(0.0001));
    }

    [Test]
    public void TestToFloat()
    {
        var value = new FixedPointPrecision4 { RawValue = 12345 };
        Assert.That(value.ToFloat(), Is.EqualTo(0.7535f).Within(0.0001f));
    }

    [Test]
    public void TestAddition()
    {
        var value1 = new FixedPointPrecision4 { RawValue = 12345 };
        var value2 = new FixedPointPrecision4 { RawValue = 67890 };
        var result = value1 + value2;
        Assert.That(result.RawValue, Is.EqualTo(80235));
    }

    [Test]
    public void TestSubtraction()
    {
        var value1 = new FixedPointPrecision4 { RawValue = 67890 };
        var value2 = new FixedPointPrecision4 { RawValue = 12345 };
        var result = value1 - value2;
        Assert.That(result.RawValue, Is.EqualTo(55545));
    }

    [Test]
    public void TestMultiplication()
    {
        var value1 = new FixedPointPrecision4 { RawValue = 12345 };
        var value2 = new FixedPointPrecision4 { RawValue = 2 << FixedPointPrecision4.Shift };
        var result = value1 * value2;
        Assert.That(result.RawValue, Is.EqualTo(24690));
    }

    [Test]
    public void TestDivision()
    {
        var value1 = new FixedPointPrecision4 { RawValue = 24690 };
        var value2 = new FixedPointPrecision4 { RawValue = 2 << FixedPointPrecision4.Shift };
        var result = value1 / value2;
        Assert.That(result.RawValue, Is.EqualTo(12345));
    }

    [Test]
    public void TestParse()
    {
        var value = FixedPointPrecision4.Parse("3.0057", CultureInfo.InvariantCulture);
        Assert.That(value.RawValue, Is.EqualTo(49245));
    }

    [Test]
    public void TestTryParse()
    {
        var success = FixedPointPrecision4.TryParse("3.0057", CultureInfo.InvariantCulture, out var value);
        Assert.That(success, Is.True);
        Assert.That(value.RawValue, Is.EqualTo(49245));
    }

    [Test]
    public void TestBounds()
    {
        Assert.That(FixedPointPrecision4.MaxValue.ToString(), Is.EqualTo("562949953421312.0000"));
        Assert.That(FixedPointPrecision4.MinValue.ToString(), Is.EqualTo("-562949953421312.0000"));
    }
}