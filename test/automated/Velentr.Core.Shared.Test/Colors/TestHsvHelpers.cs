using NUnit.Framework;
using Velentr.Core.Colors;

namespace Velentr.Core.Test.Velentr.Core.Shared.Test.Colors;

[TestFixture]
public class TestHsvHelpers
{
    [Test]
    public void TestConvertHsvToRgb_ValidHsv()
    {
        int hue = 30;
        double saturation = 1.0, value = 1.0;
        HsvHelpers.ConvertHsvToRgb(hue, saturation, value, out double red, out double green, out double blue);
        Assert.That(red, Is.EqualTo(1.0).Within(0.01));
        Assert.That(green, Is.EqualTo(0.5).Within(0.01));
        Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void TestConvertHsvToRgb_MinHsv()
    {
        int hue = 0;
        double saturation = 0.0, value = 0.0;
        HsvHelpers.ConvertHsvToRgb(hue, saturation, value, out double red, out double green, out double blue);
        Assert.That(red, Is.EqualTo(0.0).Within(0.01));
        Assert.That(green, Is.EqualTo(0.0).Within(0.01));
        Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void TestConvertHsvToRgb_MaxHsv()
    {
        int hue = 360;
        double saturation = 1.0, value = 1.0;
        HsvHelpers.ConvertHsvToRgb(hue, saturation, value, out double red, out double green, out double blue);
        Assert.That(red, Is.EqualTo(1.0).Within(0.01));
        Assert.That(green, Is.EqualTo(0.0).Within(0.01));
        Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void TestConvertHsvToRgb_MixedHsv()
    {
        int hue = 180;
        double saturation = 0.5, value = 0.5;
        HsvHelpers.ConvertHsvToRgb(hue, saturation, value, out double red, out double green, out double blue);
        Assert.That(red, Is.EqualTo(0.25).Within(0.01));
        Assert.That(green, Is.EqualTo(0.5).Within(0.01));
        Assert.That(blue, Is.EqualTo(0.5).Within(0.01));
    }
    
    
    [Test]
    public void TestConvertHsvToRgbBytes_ValidHsv()
    {
        int hue = 30;
        double saturation = 1.0, value = 1.0;
        HsvHelpers.ConvertHsvToRgb(hue, saturation, value, out byte red, out byte green, out byte blue);
        Assert.That(red, Is.EqualTo(255));
        Assert.That(green, Is.EqualTo(128));
        Assert.That(blue, Is.EqualTo(0));
    }

    [Test]
    public void TestConvertHsvToRgbBytes_MinHsv()
    {
        int hue = 0;
        double saturation = 0.0, value = 0.0;
        HsvHelpers.ConvertHsvToRgb(hue, saturation, value, out byte red, out byte green, out byte blue);
        Assert.That(red, Is.EqualTo(0));
        Assert.That(green, Is.EqualTo(0));
        Assert.That(blue, Is.EqualTo(0));
    }

    [Test]
    public void TestConvertHsvToRgbBytes_MaxHsv()
    {
        int hue = 360;
        double saturation = 1.0, value = 1.0;
        HsvHelpers.ConvertHsvToRgb(hue, saturation, value, out byte red, out byte green, out byte blue);
        Assert.That(red, Is.EqualTo(255));
        Assert.That(green, Is.EqualTo(0));
        Assert.That(blue, Is.EqualTo(0));
    }

    [Test]
    public void TestConvertHsvToRgbBytes_MixedHsv()
    {
        int hue = 180;
        double saturation = 0.5, value = 0.5;
        HsvHelpers.ConvertHsvToRgb(hue, saturation, value, out byte red, out byte green, out byte blue);
        Assert.That(red, Is.EqualTo(64));
        Assert.That(green, Is.EqualTo(128));
        Assert.That(blue, Is.EqualTo(128));
    }
    
    
    [Test]
    public void TestGetDoublesConvertHsvToRgb_ValidHsv()
    {
        int hue = 30;
        double saturation = 1.0, value = 1.0;
        (double red, double green, double blue) = HsvHelpers.ConvertHsvToRgb(hue, saturation, value);
        Assert.That(red, Is.EqualTo(1.0).Within(0.01));
        Assert.That(green, Is.EqualTo(0.5).Within(0.01));
        Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void TestGetDoublesConvertHsvToRgb_MinHsv()
    {
        int hue = 0;
        double saturation = 0.0, value = 0.0;
        (double red, double green, double blue) = HsvHelpers.ConvertHsvToRgb(hue, saturation, value);
        Assert.That(red, Is.EqualTo(0.0).Within(0.01));
        Assert.That(green, Is.EqualTo(0.0).Within(0.01));
        Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void TestGetDoublesConvertHsvToRgb_MaxHsv()
    {
        int hue = 360;
        double saturation = 1.0, value = 1.0;
        (double red, double green, double blue) = HsvHelpers.ConvertHsvToRgb(hue, saturation, value);
        Assert.That(red, Is.EqualTo(1.0).Within(0.01));
        Assert.That(green, Is.EqualTo(0.0).Within(0.01));
        Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void TestGetDoublesConvertHsvToRgb_MixedHsv()
    {
        int hue = 180;
        double saturation = 0.5, value = 0.5;
        (double red, double green, double blue) = HsvHelpers.ConvertHsvToRgb(hue, saturation, value);
        Assert.That(red, Is.EqualTo(0.25).Within(0.01));
        Assert.That(green, Is.EqualTo(0.5).Within(0.01));
        Assert.That(blue, Is.EqualTo(0.5).Within(0.01));
    }
    [Test]
    public void TestConvertHsvToRgbGetBytes_ValidHsv()
    {
        double hue = 30;
        double saturation = 1.0, value = 1.0;
        (byte red, byte green, byte blue) = HsvHelpers.ConvertHsvToRgbBytes(hue, saturation, value);
        Assert.That(red, Is.EqualTo(255));
        Assert.That(green, Is.EqualTo(128));
        Assert.That(blue, Is.EqualTo(0));
    }

    [Test]
    public void TestConvertHsvToRgbGetBytes_MinHsv()
    {
        double hue = 0;
        double saturation = 0.0, value = 0.0;
        (byte red, byte green, byte blue) = HsvHelpers.ConvertHsvToRgbBytes(hue, saturation, value);
        Assert.That(red, Is.EqualTo(0));
        Assert.That(green, Is.EqualTo(0));
        Assert.That(blue, Is.EqualTo(0));
    }

    [Test]
    public void TestConvertHsvToRgbGetBytes_MaxHsv()
    {
        double hue = 360;
        double saturation = 1.0, value = 1.0;
        (byte red, byte green, byte blue) = HsvHelpers.ConvertHsvToRgbBytes(hue, saturation, value);
        Assert.That(red, Is.EqualTo(255));
        Assert.That(green, Is.EqualTo(0));
        Assert.That(blue, Is.EqualTo(0));
    }

    [Test]
    public void TestConvertHsvToRgbGetBytes_MixedHsv()
    {
        double hue = 180;
        double saturation = 0.5, value = 0.5;
        (byte red, byte green, byte blue) = HsvHelpers.ConvertHsvToRgbBytes(hue, saturation, value);
        Assert.That(red, Is.EqualTo(64));
        Assert.That(green, Is.EqualTo(128));
        Assert.That(blue, Is.EqualTo(128));
    }
    
    [Test]
    public void TestConvertRgbToHsv_ValidRgb()
    {
        byte red = 255, green = 128, blue = 0;
        HsvHelpers.ConvertRgbToHsv(red, green, blue, out double hue, out double saturation, out double value);
        Assert.That(hue, Is.EqualTo(30.118).Within(0.01));
        Assert.That(saturation, Is.EqualTo(1.0).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsv_MinRgb()
    {
        byte red = 0, green = 0, blue = 0;
        HsvHelpers.ConvertRgbToHsv(red, green, blue, out double hue, out double saturation, out double value);
        Assert.That(hue, Is.EqualTo(0).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
        Assert.That(value, Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsv_MaxRgb()
    {
        byte red = 255, green = 255, blue = 255;
        HsvHelpers.ConvertRgbToHsv(red, green, blue, out double hue, out double saturation, out double value);
        Assert.That(hue, Is.EqualTo(0).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsv_MixedRgb()
    {
        byte red = 128, green = 255, blue = 128;
        HsvHelpers.ConvertRgbToHsv(red, green, blue, out double hue, out double saturation, out double value);
        Assert.That(hue, Is.EqualTo(120).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.5).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }
    [Test]
    public void TestConvertRgbToHsvDoubles_ValidRgb()
    {
        double red = 1.0, green = 0.5, blue = 0.0;
        HsvHelpers.ConvertRgbToHsv(red, green, blue, out double hue, out double saturation, out double value);
        Assert.That(hue, Is.EqualTo(30).Within(0.01));
        Assert.That(saturation, Is.EqualTo(1.0).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsvDoubles_MinRgb()
    {
        double red = 0.0, green = 0.0, blue = 0.0;
        HsvHelpers.ConvertRgbToHsv(red, green, blue, out double hue, out double saturation, out double value);
        Assert.That(hue, Is.EqualTo(0).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
        Assert.That(value, Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsvDoubles_MaxRgb()
    {
        double red = 1.0, green = 1.0, blue = 1.0;
        HsvHelpers.ConvertRgbToHsv(red, green, blue, out double hue, out double saturation, out double value);
        Assert.That(hue, Is.EqualTo(0).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsvDoubles_MixedRgb()
    {
        double red = 0.5, green = 1.0, blue = 0.5;
        HsvHelpers.ConvertRgbToHsv(red, green, blue, out double hue, out double saturation, out double value);
        Assert.That(hue, Is.EqualTo(120).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.5).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }
    
    [Test]
    public void TestConvertRgbToHsvDoublesDoubles_ValidRgb()
    {
        double red = 1.0, green = 0.5, blue = 0.0;
        (double hue, double saturation, double value) = HsvHelpers.ConvertRgbToHsv(red, green, blue);
        Assert.That(hue, Is.EqualTo(30).Within(0.01));
        Assert.That(saturation, Is.EqualTo(1.0).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsvDoublesDoubles_MinRgb()
    {
        double red = 0.0, green = 0.0, blue = 0.0;
        (double hue, double saturation, double value) = HsvHelpers.ConvertRgbToHsv(red, green, blue);
        Assert.That(hue, Is.EqualTo(0).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
        Assert.That(value, Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsvDoublesDoubles_MaxRgb()
    {
        double red = 1.0, green = 1.0, blue = 1.0;
        (double hue, double saturation, double value) = HsvHelpers.ConvertRgbToHsv(red, green, blue);
        Assert.That(hue, Is.EqualTo(0).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsvDoublesDoubles_MixedRgb()
    {
        double red = 0.5, green = 1.0, blue = 0.5;
        (double hue, double saturation, double value) = HsvHelpers.ConvertRgbToHsv(red, green, blue);
        Assert.That(hue, Is.EqualTo(120).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.5).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }
    [Test]
    public void TestConvertRgbToHsvBytes_ValidRgb()
    {
        byte red = 255, green = 128, blue = 0;
        (double hue, double saturation, double value) = HsvHelpers.ConvertRgbToHsv(red, green, blue);
        Assert.That(hue, Is.EqualTo(30.118).Within(0.01));
        Assert.That(saturation, Is.EqualTo(1.0).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsvBytes_MinRgb()
    {
        byte red = 0, green = 0, blue = 0;
        (double hue, double saturation, double value) = HsvHelpers.ConvertRgbToHsv(red, green, blue);
        Assert.That(hue, Is.EqualTo(0).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
        Assert.That(value, Is.EqualTo(0.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsvBytes_MaxRgb()
    {
        byte red = 255, green = 255, blue = 255;
        (double hue, double saturation, double value) = HsvHelpers.ConvertRgbToHsv(red, green, blue);
        Assert.That(hue, Is.EqualTo(0).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }

    [Test]
    public void TestConvertRgbToHsvBytes_MixedRgb()
    {
        byte red = 128, green = 255, blue = 128;
        (double hue, double saturation, double value) = HsvHelpers.ConvertRgbToHsv(red, green, blue);
        Assert.That(hue, Is.EqualTo(120).Within(0.01));
        Assert.That(saturation, Is.EqualTo(0.5).Within(0.01));
        Assert.That(value, Is.EqualTo(1.0).Within(0.01));
    }
}