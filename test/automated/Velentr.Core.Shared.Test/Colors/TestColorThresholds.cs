using Velentr.Core.Colors;

namespace Velentr.Core.Test.Colors;

public class TestColorThresholds
{
    [Test]
    public void TestHexMeetsMinRgbThreshold_AllValuesEqualThreshold()
    {
        var hex = "#666666";
        var alpha = 0.4;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestHexMeetsMinRgbThreshold_AllValuesMeetThreshold()
    {
        var hex = "#808080";
        var alpha = 0.5;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestHexMeetsMinRgbThreshold_AlphaDoesNotMeetThreshold()
    {
        var hex = "#808080";
        var alpha = 0.3;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestHexMeetsMinRgbThreshold_BlueDoesNotMeetThreshold()
    {
        var hex = "#80804D";
        var alpha = 0.5;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestHexMeetsMinRgbThreshold_GreenDoesNotMeetThreshold()
    {
        var hex = "#804D80";
        var alpha = 0.5;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestHexMeetsMinRgbThreshold_RedDoesNotMeetThreshold()
    {
        var hex = "#4D8080";
        var alpha = 0.5;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestHexMeetsMinRgbThresholdBytes_AllValuesEqualThreshold()
    {
        var hex = "#404040";
        var alpha = 0.4;
        byte thresholdRed = 64, thresholdGreen = 64, thresholdBlue = 64;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestHexMeetsMinRgbThresholdBytes_AllValuesMeetThreshold()
    {
        var hex = "#808080";
        var alpha = 0.5;
        byte thresholdRed = 64, thresholdGreen = 64, thresholdBlue = 64;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestHexMeetsMinRgbThresholdBytes_AlphaDoesNotMeetThreshold()
    {
        var hex = "#808080";
        var alpha = 0.3;
        byte thresholdRed = 64, thresholdGreen = 64, thresholdBlue = 64;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestHexMeetsMinRgbThresholdBytes_BlueDoesNotMeetThreshold()
    {
        var hex = "#80803F";
        var alpha = 0.5;
        byte thresholdRed = 64, thresholdGreen = 64, thresholdBlue = 64;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestHexMeetsMinRgbThresholdBytes_GreenDoesNotMeetThreshold()
    {
        var hex = "#803F80";
        var alpha = 0.5;
        byte thresholdRed = 64, thresholdGreen = 64, thresholdBlue = 64;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestHexMeetsMinRgbThresholdBytes_RedDoesNotMeetThreshold()
    {
        var hex = "#3F8080";
        var alpha = 0.5;
        byte thresholdRed = 64, thresholdGreen = 64, thresholdBlue = 64;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.HexMeetsMinRgbThreshold(hex, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHslThreshold_AllValuesEqualThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.4;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdLightness = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinHslThreshold_AllValuesMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.5;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdLightness = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinHslThreshold_AlphaDoesNotMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.3;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdLightness = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHslThreshold_HueDoesNotMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.5;
        double thresholdHue = 0.1, thresholdSaturation = 0.0, thresholdLightness = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHslThreshold_LightnessDoesNotMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.5;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdLightness = 0.6, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHslThreshold_SaturationDoesNotMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.5;
        double thresholdHue = 0.0, thresholdSaturation = 0.1, thresholdLightness = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHslThresholdBytes_AllValuesEqualThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.4;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdLightness = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinHslThresholdBytes_AllValuesMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.5;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdLightness = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinHslThresholdBytes_AlphaDoesNotMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.3;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdLightness = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHslThresholdBytes_HueDoesNotMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.5;
        double thresholdHue = 0.1, thresholdSaturation = 0.0, thresholdLightness = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHslThresholdBytes_LightnessDoesNotMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.5;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdLightness = 0.6, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHslThresholdBytes_SaturationDoesNotMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.5;
        double thresholdHue = 0.0, thresholdSaturation = 0.1, thresholdLightness = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHslThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdLightness, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHsvThreshold_AllValuesEqualThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.4;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdValue = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinHsvThreshold_AllValuesMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.5;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdValue = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinHsvThreshold_AlphaDoesNotMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.3;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdValue = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHsvThreshold_HueDoesNotMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.5;
        double thresholdHue = 0.1, thresholdSaturation = 0.0, thresholdValue = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHsvThreshold_SaturationDoesNotMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.5;
        double thresholdHue = 0.0, thresholdSaturation = 0.1, thresholdValue = 0.5, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHsvThreshold_ValueDoesNotMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.5;
        double thresholdHue = 0.0, thresholdSaturation = 0.0, thresholdValue = 0.6, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHsvThresholdBytes_AllValuesEqualThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.4;
        double thresholdHue = 0, thresholdSaturation = 0, thresholdValue = 0.5;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinHsvThresholdBytes_AllValuesMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.5;
        double thresholdHue = 0, thresholdSaturation = 0, thresholdValue = 0.5;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinHsvThresholdBytes_AlphaDoesNotMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.3;
        byte thresholdHue = 0, thresholdSaturation = 0, thresholdValue = 128;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHsvThresholdBytes_HueDoesNotMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.5;
        byte thresholdHue = 1, thresholdSaturation = 0, thresholdValue = 128;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHsvThresholdBytes_SaturationDoesNotMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.5;
        byte thresholdHue = 0, thresholdSaturation = 1, thresholdValue = 128;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinHsvThresholdBytes_ValueDoesNotMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.5;
        byte thresholdHue = 0, thresholdSaturation = 0, thresholdValue = 129;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinHsvThreshold(red, green, blue, alpha, thresholdHue, thresholdSaturation,
            thresholdValue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinRgbThreshold_AllValuesEqualThreshold()
    {
        double red = 0.4, green = 0.4, blue = 0.4, alpha = 0.4;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinRgbThreshold_AllValuesMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.5;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinRgbThreshold_AlphaDoesNotMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.5, alpha = 0.3;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinRgbThreshold_BlueDoesNotMeetThreshold()
    {
        double red = 0.5, green = 0.5, blue = 0.3, alpha = 0.5;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinRgbThreshold_GreenDoesNotMeetThreshold()
    {
        double red = 0.5, green = 0.3, blue = 0.5, alpha = 0.5;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinRgbThreshold_RedDoesNotMeetThreshold()
    {
        double red = 0.3, green = 0.5, blue = 0.5, alpha = 0.5;
        double thresholdRed = 0.4, thresholdGreen = 0.4, thresholdBlue = 0.4, thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinRgbThresholdBytes_AllValuesEqualThreshold()
    {
        byte red = 100, green = 100, blue = 100;
        var alpha = 0.4;
        byte thresholdRed = 100, thresholdGreen = 100, thresholdBlue = 100;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinRgbThresholdBytes_AllValuesMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.5;
        byte thresholdRed = 100, thresholdGreen = 100, thresholdBlue = 100;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestRgbMeetsMinRgbThresholdBytes_AlphaDoesNotMeetThreshold()
    {
        byte red = 128, green = 128, blue = 128;
        var alpha = 0.3;
        byte thresholdRed = 100, thresholdGreen = 100, thresholdBlue = 100;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinRgbThresholdBytes_BlueDoesNotMeetThreshold()
    {
        byte red = 128, green = 128, blue = 50;
        var alpha = 0.5;
        byte thresholdRed = 100, thresholdGreen = 100, thresholdBlue = 100;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinRgbThresholdBytes_GreenDoesNotMeetThreshold()
    {
        byte red = 128, green = 50, blue = 128;
        var alpha = 0.5;
        byte thresholdRed = 100, thresholdGreen = 100, thresholdBlue = 100;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestRgbMeetsMinRgbThresholdBytes_RedDoesNotMeetThreshold()
    {
        byte red = 50, green = 128, blue = 128;
        var alpha = 0.5;
        byte thresholdRed = 100, thresholdGreen = 100, thresholdBlue = 100;
        var thresholdAlpha = 0.4;
        var result = ColorThresholds.RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen,
            thresholdBlue, thresholdAlpha);
        Assert.That(result, Is.False);
    }
}
