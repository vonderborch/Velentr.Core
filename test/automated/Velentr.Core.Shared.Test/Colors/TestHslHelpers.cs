using Velentr.Core.Colors;

namespace Velentr.Core.Test.Velentr.Core.Shared.Test.Colors
{
    public class TestHslHelpers
    {
        [Test]
        public void TestDoublesConvertHslToRgb_ValidHsl()
        {
            double hue = 0.05, saturation = 0.9, lightness = 0.6;
            double red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.AreEqual(1.0, red, 0.01);
            Assert.AreEqual(0.34, green, 0.01);
            Assert.AreEqual(0.2, blue, 0.01);
        }

        [Test]
        public void TestDoublesConvertHslToRgb_MinHsl()
        {
            double hue = 0.0, saturation = 0.0, lightness = 0.0;
            double red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.AreEqual(0.0, red, 0.01);
            Assert.AreEqual(0.0, green, 0.01);
            Assert.AreEqual(0.0, blue, 0.01);
        }

        [Test]
        public void TestDoublesConvertHslToRgb_MaxHsl()
        {
            double hue = 1.0, saturation = 1.0, lightness = 1.0;
            double red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.AreEqual(1.0, red, 0.01);
            Assert.AreEqual(1.0, green, 0.01);
            Assert.AreEqual(1.0, blue, 0.01);
        }

        [Test]
        public void TestDoublesConvertHslToRgb_MixedHsl()
        {
            double hue = 0.6, saturation = 0.5, lightness = 0.5;
            double red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.AreEqual(0.25, red, 0.01);
            Assert.AreEqual(0.75, green, 0.01);
            Assert.AreEqual(0.75, blue, 0.01);
        }
        [Test]
        public void TestBytesConvertHslToRgb_ValidHsl()
        {
            int hue = 18;
            double saturation = 0.9, lightness = 0.6;
            byte red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.AreEqual(255, red);
            Assert.AreEqual(87, green);
            Assert.AreEqual(51, blue);
        }

        [Test]
        public void TestBytesConvertHslToRgb_MinHsl()
        {
            int hue = 0;
            double saturation = 0.0, lightness = 0.0;
            byte red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.AreEqual(0, red);
            Assert.AreEqual(0, green);
            Assert.AreEqual(0, blue);
        }

        [Test]
        public void TestBytesConvertHslToRgb_MaxHsl()
        {
            int hue = 360;
            double saturation = 1.0, lightness = 1.0;
            byte red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.AreEqual(255, red);
            Assert.AreEqual(255, green);
            Assert.AreEqual(255, blue);
        }

        [Test]
        public void TestBytesConvertHslToRgb_MixedHsl()
        {
            int hue = 216;
            double saturation = 0.5, lightness = 0.5;
            byte red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.AreEqual(64, red);
            Assert.AreEqual(191, green);
            Assert.AreEqual(191, blue);
        }
    }
}
