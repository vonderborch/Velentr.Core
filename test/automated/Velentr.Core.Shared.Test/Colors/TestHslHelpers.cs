using Velentr.Core.Colors;

namespace Velentr.Core.Test.Velentr.Core.Shared.Test.Colors
{
    public class TestHslHelpers
    {
        [Test]
        public void TestDoublesConvertHslToRgb_ValidHsl()
        {
            int hue = 18;
            double saturation = 0.9, lightness = 0.6;
            double red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.That(red, Is.EqualTo(0.959).Within(0.01));
            Assert.That(green, Is.EqualTo(0.456).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.239).Within(0.01));
        }

        [Test]
        public void TestDoublesConvertHslToRgb_MinHsl()
        {
            int hue = 0;
            double saturation = 0.0, lightness = 0.0;
            double red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.That(red, Is.EqualTo(0.0).Within(0.01));
            Assert.That(green, Is.EqualTo(0.0).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
        }

        [Test]
        public void TestDoublesConvertHslToRgb_MaxHsl()
        {
            int hue = 360;
            double saturation = 1.0, lightness = 1.0;
            double red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.That(red, Is.EqualTo(1.0).Within(0.01));
            Assert.That(green, Is.EqualTo(1.0).Within(0.01));
            Assert.That(blue, Is.EqualTo(1.0).Within(0.01));
        }

        [Test]
        public void TestDoublesConvertHslToRgb_MixedHsl()
        {
            int hue = 216;
            double saturation = 0.5, lightness = 0.5;
            double red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.That(red, Is.EqualTo(0.25).Within(0.01));
            Assert.That(green, Is.EqualTo(0.449).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.75).Within(0.01));
        }
        [Test]
        public void TestBytesConvertHslToRgb_ValidHsl()
        {
            int hue = 18;
            double saturation = 0.9, lightness = 0.6;
            byte red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.That(red, Is.EqualTo(245));
            Assert.That(green, Is.EqualTo(116));
            Assert.That(blue, Is.EqualTo(61));
        }

        [Test]
        public void TestBytesConvertHslToRgb_MinHsl()
        {
            int hue = 0;
            double saturation = 0.0, lightness = 0.0;
            byte red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.That(red, Is.EqualTo(0));
            Assert.That(green, Is.EqualTo(0));
            Assert.That(blue, Is.EqualTo(0));
        }

        [Test]
        public void TestBytesConvertHslToRgb_MaxHsl()
        {
            int hue = 360;
            double saturation = 1.0, lightness = 1.0;
            byte red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.That(red, Is.EqualTo(255));
            Assert.That(green, Is.EqualTo(255));
            Assert.That(blue, Is.EqualTo(255));
        }

        [Test]
        public void TestBytesConvertHslToRgb_MixedHsl()
        {
            int hue = 216;
            double saturation = 0.5, lightness = 0.5;
            byte red, green, blue;
            HslHelpers.ConvertHslToRgb(hue, saturation, lightness, out red, out green, out blue);
            Assert.That(red, Is.EqualTo(64));
            Assert.That(green, Is.EqualTo(115));
            Assert.That(blue, Is.EqualTo(191));
        }
        [Test]
        public void TestConvertHslToRgb_ValidHsl()
        {
            int hue = 18;
            double saturation = 0.9, lightness = 0.6;
            (double red, double green, double blue) = HslHelpers.ConvertHslToRgb(hue, saturation, lightness);
            Assert.That(red, Is.EqualTo(0.959).Within(0.01));
            Assert.That(green, Is.EqualTo(0.456).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.239).Within(0.01));
        }

        [Test]
        public void TestConvertHslToRgb_MinHsl()
        {
            int hue = 0;
            double saturation = 0.0, lightness = 0.0;
            (double red, double green, double blue) = HslHelpers.ConvertHslToRgb(hue, saturation, lightness);
            Assert.That(red, Is.EqualTo(0.0).Within(0.01));
            Assert.That(green, Is.EqualTo(0.0).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
        }

        [Test]
        public void TestConvertHslToRgb_MaxHsl()
        {
            int hue = 360;
            double saturation = 1.0, lightness = 1.0;
            (double red, double green, double blue) = HslHelpers.ConvertHslToRgb(hue, saturation, lightness);
            Assert.That(red, Is.EqualTo(1.0).Within(0.01));
            Assert.That(green, Is.EqualTo(1.0).Within(0.01));
            Assert.That(blue, Is.EqualTo(1.0).Within(0.01));
        }

        [Test]
        public void TestConvertHslToRgb_MixedHsl()
        {
            int hue = 216;
            double saturation = 0.5, lightness = 0.5;
            (double red, double green, double blue) = HslHelpers.ConvertHslToRgb(hue, saturation, lightness);
            Assert.That(red, Is.EqualTo(0.25).Within(0.01));
            Assert.That(green, Is.EqualTo(0.449).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.75).Within(0.01));
        }
        
        [Test]
        public void TestConvertHslToRgbBytes_ValidHsl()
        {
            int hue = 18;
            double saturation = 0.9, lightness = 0.6;
            (byte red, byte green, byte blue) = HslHelpers.ConvertHslToRgbBytes(hue, saturation, lightness);
            Assert.That(red, Is.EqualTo(245));
            Assert.That(green, Is.EqualTo(116));
            Assert.That(blue, Is.EqualTo(61));
        }

        [Test]
        public void TestConvertHslToRgbBytes_MinHsl()
        {
            int hue = 0;
            double saturation = 0.0, lightness = 0.0;
            (byte red, byte green, byte blue) = HslHelpers.ConvertHslToRgbBytes(hue, saturation, lightness);
            Assert.That(red, Is.EqualTo(0));
            Assert.That(green, Is.EqualTo(0));
            Assert.That(blue, Is.EqualTo(0));
        }

        [Test]
        public void TestConvertHslToRgbBytes_MaxHsl()
        {
            int hue = 360;
            double saturation = 1.0, lightness = 1.0;
            (byte red, byte green, byte blue) = HslHelpers.ConvertHslToRgbBytes(hue, saturation, lightness);
            Assert.That(red, Is.EqualTo(255));
            Assert.That(green, Is.EqualTo(255));
            Assert.That(blue, Is.EqualTo(255));
        }

        [Test]
        public void TestConvertHslToRgbBytes_MixedHsl()
        {
            int hue = 216;
            double saturation = 0.5, lightness = 0.5;
            (byte red, byte green, byte blue) = HslHelpers.ConvertHslToRgbBytes(hue, saturation, lightness);
            Assert.That(red, Is.EqualTo(64));
            Assert.That(green, Is.EqualTo(115));
            Assert.That(blue, Is.EqualTo(191));
        }
        [Test]
        public void TestFromBytesConvertRgbToHsl_ValidRgb()
        {
            byte red = 255, green = 87, blue = 51;
            (double hue, double saturation, double lightness) = HslHelpers.ConvertRgbToHsl(red, green, blue);
            Assert.That(hue, Is.EqualTo(10.59).Within(0.01));
            Assert.That(saturation, Is.EqualTo(1).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.6).Within(0.01));
        }

        [Test]
        public void TestFromBytesConvertRgbToHsl_MinRgb()
        {
            byte red = 0, green = 0, blue = 0;
            (double hue, double saturation, double lightness) = HslHelpers.ConvertRgbToHsl(red, green, blue);
            Assert.That(hue, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.0).Within(0.01));
        }

        [Test]
        public void TestFromBytesConvertRgbToHsl_MaxRgb()
        {
            byte red = 255, green = 255, blue = 255;
            (double hue, double saturation, double lightness) = HslHelpers.ConvertRgbToHsl(red, green, blue);
            Assert.That(hue, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(1.0).Within(0.01));
        }

        [Test]
        public void TestFromBytesConvertRgbToHsl_MixedRgb()
        {
            byte red = 64, green = 191, blue = 191;
            (double hue, double saturation, double lightness) = HslHelpers.ConvertRgbToHsl(red, green, blue);
            Assert.That(hue, Is.EqualTo(180).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.498).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.5).Within(0.01));
        }
        
        [Test]
        public void TestFromDoublesConvertRgbToHsl_ValidRgb()
        {
            double red = 1.0, green = 0.34, blue = 0.2;
            (double hue, double saturation, double lightness) = HslHelpers.ConvertRgbToHsl(red, green, blue);
            Assert.That(hue, Is.EqualTo(10.5).Within(0.01));
            Assert.That(saturation, Is.EqualTo(1).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.6).Within(0.01));
        }

        [Test]
        public void TestFromDoublesConvertRgbToHsl_MinRgb()
        {
            double red = 0.0, green = 0.0, blue = 0.0;
            (double hue, double saturation, double lightness) = HslHelpers.ConvertRgbToHsl(red, green, blue);
            Assert.That(hue, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.0).Within(0.01));
        }

        [Test]
        public void TestFromDoublesConvertRgbToHsl_MaxRgb()
        {
            double red = 1.0, green = 1.0, blue = 1.0;
            (double hue, double saturation, double lightness) = HslHelpers.ConvertRgbToHsl(red, green, blue);
            Assert.That(hue, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(1.0).Within(0.01));
        }

        [Test]
        public void TestFromDoublesConvertRgbToHsl_MixedRgb()
        {
            double red = 0.25, green = 0.75, blue = 0.75;
            (double hue, double saturation, double lightness) = HslHelpers.ConvertRgbToHsl(red, green, blue);
            Assert.That(hue, Is.EqualTo(180).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.5).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.5).Within(0.01));
        }
        
        [Test]
        public void TestFromBytesOutConvertRgbToHsl_ValidRgb()
        {
            byte red = 255, green = 87, blue = 51;
            HslHelpers.ConvertRgbToHsl(red, green, blue, out double hue, out double saturation, out double lightness);
            Assert.That(hue, Is.EqualTo(10.589).Within(0.01));
            Assert.That(saturation, Is.EqualTo(1).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.6).Within(0.01));
        }

        [Test]
        public void TestFromBytesOutConvertRgbToHsl_MinRgb()
        {
            byte red = 0, green = 0, blue = 0;
            HslHelpers.ConvertRgbToHsl(red, green, blue, out double hue, out double saturation, out double lightness);
            Assert.That(hue, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.0).Within(0.01));
        }

        [Test]
        public void TestFromBytesOutConvertRgbToHsl_MaxRgb()
        {
            byte red = 255, green = 255, blue = 255;
            HslHelpers.ConvertRgbToHsl(red, green, blue, out double hue, out double saturation, out double lightness);
            Assert.That(hue, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(1.0).Within(0.01));
        }

        [Test]
        public void TestFromBytesOutConvertRgbToHsl_MixedRgb()
        {
            byte red = 64, green = 191, blue = 191;
            HslHelpers.ConvertRgbToHsl(red, green, blue, out double hue, out double saturation, out double lightness);
            Assert.That(hue, Is.EqualTo(180).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.5).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.5).Within(0.01));
        }
        
        
        [Test]
        public void TestConvertRgbToHsl_ValidRgb()
        {
            double red = 1.0, green = 0.34, blue = 0.2;
            HslHelpers.ConvertRgbToHsl(red, green, blue, out double hue, out double saturation, out double lightness);
            Assert.That(hue, Is.EqualTo(10.5).Within(0.01));
            Assert.That(saturation, Is.EqualTo(1).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.6).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToHsl_MinRgb()
        {
            double red = 0.0, green = 0.0, blue = 0.0;
            HslHelpers.ConvertRgbToHsl(red, green, blue, out double hue, out double saturation, out double lightness);
            Assert.That(hue, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.0).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToHsl_MaxRgb()
        {
            double red = 1.0, green = 1.0, blue = 1.0;
            HslHelpers.ConvertRgbToHsl(red, green, blue, out double hue, out double saturation, out double lightness);
            Assert.That(hue, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(1.0).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToHsl_MixedRgb()
        {
            double red = 0.25, green = 0.75, blue = 0.75;
            HslHelpers.ConvertRgbToHsl(red, green, blue, out double hue, out double saturation, out double lightness);
            Assert.That(hue, Is.EqualTo(180).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.5).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.5).Within(0.01));
        }
    }
}
