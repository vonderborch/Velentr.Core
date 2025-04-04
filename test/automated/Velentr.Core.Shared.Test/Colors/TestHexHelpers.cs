using NUnit.Framework;
using Velentr.Core.Colors;

namespace Velentr.Core.Test.Colors;

[TestFixture]
public class TestHexHelpers
{
    [Test]
    public void TestBytesConvertHexToRgb_ValidHex()
    {
        string hex = "#FF5733";
        byte red, green, blue;
        HexHelpers.ConvertHexToRgb(hex, out red, out green, out blue);
        Assert.That(red, Is.EqualTo(255));
        Assert.That(green, Is.EqualTo(87));
        Assert.That(blue, Is.EqualTo(51));
    }

    [Test]
    public void TestBytesConvertHexToRgb_InvalidHex()
    {
        string hex = "#ZZZZZZ";
        byte red, green, blue;
        Assert.Throws<FormatException>(() => HexHelpers.ConvertHexToRgb(hex, out red, out green, out blue));
    }

    [Test]
    public void TestBytesConvertHexToRgb_EmptyString()
    {
        string hex = "";
        byte red, green, blue;
        Assert.Throws<ArgumentException>(() => HexHelpers.ConvertHexToRgb(hex, out red, out green, out blue));
    }
    [Test]
    public void TestConvertHexToRgbBytes_ValidHex()
    {
        string hex = "#FF5733";
        var (red, green, blue) = HexHelpers.ConvertHexToRgbBytes(hex);
        Assert.That(red, Is.EqualTo(255));
        Assert.That(green, Is.EqualTo(87));
        Assert.That(blue, Is.EqualTo(51));
    }

    [Test]
    public void TestConvertHexToRgbBytes_InvalidHex()
    {
        string hex = "#ZZZZZZ";
        Assert.Throws<FormatException>(() => HexHelpers.ConvertHexToRgbBytes(hex));
    }

    [Test]
    public void TestConvertHexToRgbBytes_EmptyString()
    {
        string hex = "";
        Assert.Throws<ArgumentException>(() => HexHelpers.ConvertHexToRgbBytes(hex));
    }
    [Test]
    public void TestDoubleConvertHexToRgb_ValidHex()
    {
        string hex = "#FF5733";
        double red, green, blue;
        HexHelpers.ConvertHexToRgb(hex, out red, out green, out blue);
        Assert.That(red, Is.EqualTo(1.0).Within(0.01));
        Assert.That(green, Is.EqualTo(0.34).Within(0.01));
        Assert.That(blue, Is.EqualTo(0.2).Within(0.01));
    }

    [Test]
    public void TestDoubleConvertHexToRgb_InvalidHex()
    {
        string hex = "#ZZZZZZ";
        double red, green, blue;
        Assert.Throws<FormatException>(() => HexHelpers.ConvertHexToRgb(hex, out red, out green, out blue));
    }

    [Test]
    public void TestDoubleConvertHexToRgb_EmptyString()
    {
        string hex = "";
        double red, green, blue;
        Assert.Throws<ArgumentException>(() => HexHelpers.ConvertHexToRgb(hex, out red, out green, out blue));
    }
    [Test]
    public void TestConvertHexToRgb_ValidHex()
    {
        string hex = "#FF5733";
        double red, green, blue;
        HexHelpers.ConvertHexToRgb(hex, out red, out green, out blue);
        Assert.That(red, Is.EqualTo(1.0).Within(0.01));
        Assert.That(green, Is.EqualTo(0.34).Within(0.01));
        Assert.That(blue, Is.EqualTo(0.2).Within(0.01));
    }

    [Test]
    public void TestConvertHexToRgb_InvalidHex()
    {
        string hex = "#ZZZZZZ";
        double red, green, blue;
        Assert.Throws<FormatException>(() => HexHelpers.ConvertHexToRgb(hex, out red, out green, out blue));
    }

    [Test]
    public void TestConvertHexToRgb_EmptyString()
    {
        string hex = "";
        double red, green, blue;
        Assert.Throws<ArgumentException>(() => HexHelpers.ConvertHexToRgb(hex, out red, out green, out blue));
    }
    [Test]
    public void TestByteConvertRgbToHex_ValidRgb()
    {
        byte red = 255, green = 87, blue = 51;
        string hex;
        HexHelpers.ConvertRgbToHex(red, green, blue, out hex);
        Assert.That(hex, Is.EqualTo("#FF5733"));
    }

    [Test]
    public void TestByteConvertRgbToHex_MinRgb()
    {
        byte red = 0, green = 0, blue = 0;
        string hex;
        HexHelpers.ConvertRgbToHex(red, green, blue, out hex);
        Assert.That(hex, Is.EqualTo("#000000"));
    }

    [Test]
    public void TestByteConvertRgbToHex_MaxRgb()
    {
        byte red = 255, green = 255, blue = 255;
        string hex;
        HexHelpers.ConvertRgbToHex(red, green, blue, out hex);
        Assert.That(hex, Is.EqualTo("#FFFFFF"));
    }

    [Test]
    public void TestByteConvertRgbToHex_MixedRgb()
    {
        byte red = 123, green = 45, blue = 67;
        string hex;
        HexHelpers.ConvertRgbToHex(red, green, blue, out hex);
        Assert.That(hex, Is.EqualTo("#7B2D43"));
    }
    [Test]
    public void TestGetBytesConvertRgbToHex_ValidRgb()
    {
        byte red = 255, green = 87, blue = 51;
        string hex = HexHelpers.ConvertRgbToHex(red, green, blue);
        Assert.That(hex, Is.EqualTo("#FF5733"));
    }

    [Test]
    public void TestGetBytesConvertRgbToHex_MinRgb()
    {
        byte red = 0, green = 0, blue = 0;
        string hex = HexHelpers.ConvertRgbToHex(red, green, blue);
        Assert.That(hex, Is.EqualTo("#000000"));
    }

    [Test]
    public void TestGetBytesConvertRgbToHex_MaxRgb()
    {
        byte red = 255, green = 255, blue = 255;
        string hex = HexHelpers.ConvertRgbToHex(red, green, blue);
        Assert.That(hex, Is.EqualTo("#FFFFFF"));
    }

    [Test]
    public void TestGetBytesConvertRgbToHex_MixedRgb()
    {
        byte red = 123, green = 45, blue = 67;
        string hex = HexHelpers.ConvertRgbToHex(red, green, blue);
        Assert.That(hex, Is.EqualTo("#7B2D43"));
    }
    [Test]
    public void TestDoubleConvertRgbToHex_ValidRgb()
    {
        double red = 1.0, green = 0.34, blue = 0.2;
        string hex;
        HexHelpers.ConvertRgbToHex(red, green, blue, out hex);
        Assert.That(hex, Is.EqualTo("#FF5733"));
    }

    [Test]
    public void TestDoubleConvertRgbToHex_MinRgb()
    {
        double red = 0.0, green = 0.0, blue = 0.0;
        string hex;
        HexHelpers.ConvertRgbToHex(red, green, blue, out hex);
        Assert.That(hex, Is.EqualTo("#000000"));
    }

    [Test]
    public void TestDoubleConvertRgbToHex_MaxRgb()
    {
        double red = 1.0, green = 1.0, blue = 1.0;
        string hex;
        HexHelpers.ConvertRgbToHex(red, green, blue, out hex);
        Assert.That(hex, Is.EqualTo("#FFFFFF"));
    }

    [Test]
    public void TestDoubleConvertRgbToHex_MixedRgb()
    {
        double red = 0.482, green = 0.176, blue = 0.263;
        string hex;
        HexHelpers.ConvertRgbToHex(red, green, blue, out hex);
        Assert.That(hex, Is.EqualTo("#7B2D43"));
    }
    [Test]
    public void TestGetDoubleConvertRgbToHex_ValidRgb()
    {
        double red = 1.0, green = 0.34, blue = 0.2;
        string hex = HexHelpers.ConvertRgbToHex(red, green, blue);
        Assert.That(hex, Is.EqualTo("#FF5733"));
    }

    [Test]
    public void TestGetDoubleConvertRgbToHex_MinRgb()
    {
        double red = 0.0, green = 0.0, blue = 0.0;
        string hex = HexHelpers.ConvertRgbToHex(red, green, blue);
        Assert.That(hex, Is.EqualTo("#000000"));
    }

    [Test]
    public void TestGetDoubleConvertRgbToHex_MaxRgb()
    {
        double red = 1.0, green = 1.0, blue = 1.0;
        string hex = HexHelpers.ConvertRgbToHex(red, green, blue);
        Assert.That(hex, Is.EqualTo("#FFFFFF"));
    }

    [Test]
    public void TestGetDoubleConvertRgbToHex_MixedRgb()
    {
        double red = 0.482, green = 0.176, blue = 0.263;
        string hex = HexHelpers.ConvertRgbToHex(red, green, blue);
        Assert.That(hex, Is.EqualTo("#7B2D43"));
    }
}