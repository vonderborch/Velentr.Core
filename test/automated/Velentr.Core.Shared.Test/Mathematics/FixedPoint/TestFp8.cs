using System.Globalization;
using Velentr.Core.Mathematics.FixedPoint;

namespace Velentr.Core.Test.Mathematics.FixedPoint;

[TestFixture]
public class TestFp8
{
    [Test]
    public void TestToString()
    {
        FP8 value = new() { RawValue = 12345234 };
        Assert.That(value.ToString(), Is.EqualTo("0.09197916"));
    }

    [Test]
    public void TestToString_FromDouble()
    {
        FP8 value = FP8.CreateFromDouble(3.00572341);
        Assert.That(value.ToString(), Is.EqualTo("3.00572341"));
        value += 1;
        Assert.That(value.ToString(), Is.EqualTo("4.00572341"));
        value += 1.5d;
        Assert.That(value.ToString(), Is.EqualTo("5.50572341"));
        value += 55.001d;
        Assert.That(value.ToString(), Is.EqualTo("60.50672341"));
        value += 3.0001d;
        Assert.That(value.ToString(), Is.EqualTo("63.50682341"));
        value += 3.000001d;
        Assert.That(value.ToString(), Is.EqualTo("66.50682441"));
        value += 3.00000001d;
        Assert.That(value.ToString(), Is.EqualTo("69.50682442"));
    }

    [Test]
    public void TestToString_FromDoubleWeird()
    {
        FP8 value = FP8.CreateFromDouble(7d / 3);
        Assert.That(value.ToString(), Is.EqualTo("2.33333334"));
        value += 1;
        Assert.That(value.ToString(), Is.EqualTo("3.33333334"));
    }

    [Test]
    public void TestCreateFromDouble()
    {
        FP8 value = FP8.CreateFromDouble(3.00572341);
        Assert.That(value.RawValue, Is.EqualTo(403421367));
    }

    [Test]
    public void TestCreateFromFloat()
    {
        FP8 value = FP8.CreateFromFloat(3.00572341f);
        Assert.That(value.RawValue, Is.EqualTo(403421376));
    }

    [Test]
    public void TestToDouble()
    {
        FP8 value = new() { RawValue = 12345234234 };
        Assert.That(value.ToDouble(), Is.EqualTo(91.97916265).Within(0.00000001));
    }

    [Test]
    public void TestToFloat()
    {
        FP8 value = new() { RawValue = 12345234 };
        Assert.That(value.ToFloat(), Is.EqualTo(0.0919791609f).Within(0.00000001f));
    }

    [Test]
    public void TestAddition()
    {
        FP8 value1 = new() { RawValue = 12345234 };
        FP8 value2 = new() { RawValue = 67890 };
        FP8 result = value1 + value2;
        Assert.That(result.RawValue, Is.EqualTo(12413124));
    }

    [Test]
    public void TestSubtraction()
    {
        FP8 value1 = new() { RawValue = 67890 };
        FP8 value2 = new() { RawValue = 12345234 };
        FP8 result = value1 - value2;
        Assert.That(result.RawValue, Is.EqualTo(-12277344));
    }

    [Test]
    public void TestMultiplication()
    {
        FP8 value1 = new() { RawValue = 12345234 };
        FP8 value2 = new() { RawValue = 2 << FP8.Shift };
        FP8 result = value1 * value2;
        Assert.That(result.RawValue, Is.EqualTo(24690468));
    }

    [Test]
    public void TestDivision()
    {
        FP8 value1 = new() { RawValue = 24690 };
        FP8 value2 = new() { RawValue = 2 << FP8.Shift };
        FP8 result = value1 / value2;
        Assert.That(result.RawValue, Is.EqualTo(12345));
    }

    [Test]
    public void TestParse()
    {
        FP8 value = FP8.Parse("3.00572341", CultureInfo.InvariantCulture);
        Assert.That(value.RawValue, Is.EqualTo(403421367));
    }

    [Test]
    public void TestTryParse()
    {
        var success = FP8.TryParse("3.00572341", CultureInfo.InvariantCulture, out FP8 value);
        Assert.That(success, Is.True);
        Assert.That(value.RawValue, Is.EqualTo(403421367));
    }

    [Test]
    public void TestBounds()
    {
        Assert.That(FP8.MaxValue.ToString(), Is.EqualTo("68719476736.00000000"));
        Assert.That(FP8.MinValue.ToString(), Is.EqualTo("-68719476736.00000000"));
    }
}
