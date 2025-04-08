using Microsoft.Xna.Framework;
using Velentr.Core.FNA.Colors;

namespace Velentr.Core.Test.Colors;

[TestFixture]
public class TestColorConvertors
{
    [Test]
    public void TestColorFromHex()
    {
        Color color = ColorConvertors.ColorFromHex("#FF5733");
        Assert.That(color, Is.EqualTo(new Color(1f, 0.345f, 0.2f, 1f)));
    }

    [Test]
    public void TestColorFromHsv()
    {
        Color color = ColorConvertors.ColorFromHsv(0f, 1f, 1f);
        Assert.That(color, Is.EqualTo(new Color(1f, 0f, 0f, 1f)));
    }

    [Test]
    public void TestColorFromHsl()
    {
        Color color = ColorConvertors.ColorFromHsl(0f, 1f, 0.5f);
        Assert.That(color, Is.EqualTo(new Color(1f, 0f, 0f, 1f)));
    }

    [Test]
    public void TestColorToHsv()
    {
        var (hue, saturation, value) = ColorConvertors.ColorToHsv(new Color(1f, 0f, 0f, 1f));
        Assert.That(hue, Is.EqualTo(0f));
        Assert.That(saturation, Is.EqualTo(1f));
        Assert.That(value, Is.EqualTo(1f));
    }

    [Test]
    public void TestColorToHsl()
    {
        var (hue, saturation, lightness) = ColorConvertors.ColorToHsl(new Color(1f, 0f, 0f, 1f));
        Assert.That(hue, Is.EqualTo(0f));
        Assert.That(saturation, Is.EqualTo(1f));
        Assert.That(lightness, Is.EqualTo(0.5f));
    }

    [Test]
    public void TestColorToHex()
    {
        var hex = ColorConvertors.ColorToHex(new Color(1f, 0f, 0f, 1f));
        Assert.That(hex, Is.EqualTo("#FF0000"));
    }
}
