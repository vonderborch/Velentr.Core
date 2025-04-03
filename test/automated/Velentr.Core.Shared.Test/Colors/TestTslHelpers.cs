using Velentr.Core.Colors;

namespace Velentr.Core.Test.Velentr.Core.Shared.Test.Colors
{
    public class TestTslHelpers
    {
        [Test]
        public void TestConvertRgbToTsl_ValidRgb()
        {
            byte red = 255, green = 128, blue = 0;
            TslHelpers.ConvertRgbToTsl(red, green, blue, out double tint, out double saturation, out double lightness);
            Assert.That(tint, Is.EqualTo(0.5).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.45).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.59).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTsl_MinRgb()
        {
            byte red = 0, green = 0, blue = 0;
            TslHelpers.ConvertRgbToTsl(red, green, blue, out double tint, out double saturation, out double lightness);
            Assert.That(tint, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTsl_MaxRgb()
        {
            byte red = 255, green = 255, blue = 255;
            TslHelpers.ConvertRgbToTsl(red, green, blue, out double tint, out double saturation, out double lightness);
            Assert.That(tint, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(1).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTsl_MixedRgb()
        {
            byte red = 128, green = 255, blue = 128;
            TslHelpers.ConvertRgbToTsl(red, green, blue, out double tint, out double saturation, out double lightness);
            Assert.That(tint, Is.EqualTo(0.176).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.25).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.79).Within(0.01));
        }
        [Test]
        public void TestConvertRgbToTslDoubles_ValidRgb()
        {
            double red = 1.0, green = 0.5, blue = 0.0;
            TslHelpers.ConvertRgbToTsl(red, green, blue, out double tint, out double saturation, out double lightness);
            Assert.That(tint, Is.EqualTo(0d).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.45).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.59).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTslDoubles_MinRgb()
        {
            double red = 0.0, green = 0.0, blue = 0.0;
            TslHelpers.ConvertRgbToTsl(red, green, blue, out double tint, out double saturation, out double lightness);
            Assert.That(tint, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTslDoubles_MaxRgb()
        {
            double red = 1.0, green = 1.0, blue = 1.0;
            TslHelpers.ConvertRgbToTsl(red, green, blue, out double tint, out double saturation, out double lightness);
            Assert.That(tint, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(1).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTslDoubles_MixedRgb()
        {
            double red = 0.5, green = 1.0, blue = 0.5;
            TslHelpers.ConvertRgbToTsl(red, green, blue, out double tint, out double saturation, out double lightness);
            Assert.That(tint, Is.EqualTo(0.176).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.25).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.793).Within(0.01));
        }
        [Test]
        public void TestConvertRgbToTslDoublesDoubles_ValidRgb()
        {
            double red = 1.0, green = 0.5, blue = 0.0;
            (double tint, double saturation, double lightness) = TslHelpers.ConvertRgbToTsl(red, green, blue);
            Assert.That(tint, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.447).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.593).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTslDoublesDoubles_MinRgb()
        {
            double red = 0.0, green = 0.0, blue = 0.0;
            (double tint, double saturation, double lightness) = TslHelpers.ConvertRgbToTsl(red, green, blue);
            Assert.That(tint, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTslDoublesDoubles_MaxRgb()
        {
            double red = 1.0, green = 1.0, blue = 1.0;
            (double tint, double saturation, double lightness) = TslHelpers.ConvertRgbToTsl(red, green, blue);
            Assert.That(tint, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(1).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTslDoublesDoubles_MixedRgb()
        {
            double red = 0.5, green = 1.0, blue = 0.5;
            (double tint, double saturation, double lightness) = TslHelpers.ConvertRgbToTsl(red, green, blue);
            Assert.That(tint, Is.EqualTo(0.176).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.25).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.793).Within(0.01));
        }
        [Test]
        public void TestConvertRgbToTslBytes_ValidRgb()
        {
            byte red = 255, green = 128, blue = 0;
            (double tint, double saturation, double lightness) = TslHelpers.ConvertRgbToTsl(red, green, blue);
            Assert.That(tint, Is.EqualTo(0.5).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.447).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.593).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTslBytes_MinRgb()
        {
            byte red = 0, green = 0, blue = 0;
            (double tint, double saturation, double lightness) = TslHelpers.ConvertRgbToTsl(red, green, blue);
            Assert.That(tint, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTslBytes_MaxRgb()
        {
            byte red = 255, green = 255, blue = 255;
            (double tint, double saturation, double lightness) = TslHelpers.ConvertRgbToTsl(red, green, blue);
            Assert.That(tint, Is.EqualTo(0).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0).Within(0.01));
            Assert.That(lightness, Is.EqualTo(1).Within(0.01));
        }

        [Test]
        public void TestConvertRgbToTslBytes_MixedRgb()
        {
            byte red = 128, green = 255, blue = 128;
            (double tint, double saturation, double lightness) = TslHelpers.ConvertRgbToTsl(red, green, blue);
            Assert.That(tint, Is.EqualTo(0.176).Within(0.01));
            Assert.That(saturation, Is.EqualTo(0.25).Within(0.01));
            Assert.That(lightness, Is.EqualTo(0.793).Within(0.01));
        }
        
        [Test]
        public void TestConvertTslToRgbDoubles_ValidTsl()
        {
            double tint = 0.5, saturation = 0.45, lightness = 0.59;
            TslHelpers.ConvertTslToRgb(tint, saturation, lightness, out double red, out double green, out double blue);
            Assert.That(red, Is.EqualTo(1.0).Within(0.01));
            Assert.That(green, Is.EqualTo(0.5).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
        }

        [Test]
        public void TestConvertTslToRgbDoubles_MinTsl()
        {
            double tint = 0, saturation = 0, lightness = 0;
            TslHelpers.ConvertTslToRgb(tint, saturation, lightness, out double red, out double green, out double blue);
            Assert.That(red, Is.EqualTo(0.0).Within(0.01));
            Assert.That(green, Is.EqualTo(0.0).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
        }

        [Test]
        public void TestConvertTslToRgbDoubles_MaxTsl()
        {
            double tint = 0, saturation = 0, lightness = 1;
            TslHelpers.ConvertTslToRgb(tint, saturation, lightness, out double red, out double green, out double blue);
            Assert.That(red, Is.EqualTo(1.0).Within(0.01));
            Assert.That(green, Is.EqualTo(1.0).Within(0.01));
            Assert.That(blue, Is.EqualTo(1.0).Within(0.01));
        }

        [Test]
        public void TestConvertTslToRgbDoubles_MixedTsl()
        {
            double tint = 0.176, saturation = 0.25, lightness = 0.79;
            TslHelpers.ConvertTslToRgb(tint, saturation, lightness, out double red, out double green, out double blue);
            Assert.That(red, Is.EqualTo(0.5).Within(0.01));
            Assert.That(green, Is.EqualTo(1.0).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.5).Within(0.01));
        }

        [Test]
        public void TestConvertTslToRgbDoublesDoubles_MinTsl()
        {
            double tint = 0, saturation = 0, lightness = 0;
            (double red, double green, double blue) = TslHelpers.ConvertTslToRgb(tint, saturation, lightness);
            Assert.That(red, Is.EqualTo(0.0).Within(0.01));
            Assert.That(green, Is.EqualTo(0.0).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
        }

        [Test]
        public void TestConvertTslToRgbDoublesDoubles_MaxTsl()
        {
            double tint = 0, saturation = 0, lightness = 1;
            (double red, double green, double blue) = TslHelpers.ConvertTslToRgb(tint, saturation, lightness);
            Assert.That(red, Is.EqualTo(1.0).Within(0.01));
            Assert.That(green, Is.EqualTo(1.0).Within(0.01));
            Assert.That(blue, Is.EqualTo(1.0).Within(0.01));
        }

        [Test]
        public void TestConvertTslToRgbDoublesDoubles_MixedTsl()
        {
            double tint = 0.176, saturation = 0.25, lightness = 0.79;
            (double red, double green, double blue) = TslHelpers.ConvertTslToRgb(tint, saturation, lightness);
            Assert.That(red, Is.EqualTo(0.5).Within(0.01));
            Assert.That(green, Is.EqualTo(1.0).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.5).Within(0.01));
        }
        
        [Test]
        public void TestConvertTslToRgbDoublesDoubles_ValidTsl()
        {
            double tint = 0.5, saturation = 0.45, lightness = 0.59;
            (double red, double green, double blue) = TslHelpers.ConvertTslToRgb(tint, saturation, lightness);
            Assert.That(red, Is.EqualTo(1.0).Within(0.01));
            Assert.That(green, Is.EqualTo(0.5).Within(0.01));
            Assert.That(blue, Is.EqualTo(0.0).Within(0.01));
        }
        
        [Test]
        public void TestConvertTslToRgbBytes_ValidTsl()
        {
            double tint = 0.5, saturation = 0.45, lightness = 0.59;
            TslHelpers.ConvertTslToRgb(tint, saturation, lightness, out byte red, out byte green, out byte blue);
            Assert.That(red, Is.EqualTo(254));
            Assert.That(green, Is.EqualTo(127));
            Assert.That(blue, Is.EqualTo(0));
        }

        [Test]
        public void TestConvertTslToRgbBytes_MinTsl()
        {
            double tint = 0, saturation = 0, lightness = 0;
            TslHelpers.ConvertTslToRgb(tint, saturation, lightness, out byte red, out byte green, out byte blue);
            Assert.That(red, Is.EqualTo(0));
            Assert.That(green, Is.EqualTo(0));
            Assert.That(blue, Is.EqualTo(0));
        }

        [Test]
        public void TestConvertTslToRgbBytes_MaxTsl()
        {
            double tint = 0, saturation = 0, lightness = 1;
            TslHelpers.ConvertTslToRgb(tint, saturation, lightness, out byte red, out byte green, out byte blue);
            Assert.That(red, Is.EqualTo(255));
            Assert.That(green, Is.EqualTo(255));
            Assert.That(blue, Is.EqualTo(255));
        }

        [Test]
        public void TestConvertTslToRgbBytes_MixedTsl()
        {
            double tint = 0.176, saturation = 0.25, lightness = 0.79;
            TslHelpers.ConvertTslToRgb(tint, saturation, lightness, out byte red, out byte green, out byte blue);
            Assert.That(red, Is.EqualTo(127));
            Assert.That(green, Is.EqualTo(254));
            Assert.That(blue, Is.EqualTo(127));
        }
        
        [Test]
        public void TestConvertTslToRgbBytesBytes_ValidTsl()
        {
            double tint = 0.5, saturation = 0.45, lightness = 0.59;
            (byte red, byte green, byte blue) = TslHelpers.ConvertTslToRgbBytes(tint, saturation, lightness);
            Assert.That(red, Is.EqualTo(254));
            Assert.That(green, Is.EqualTo(127));
            Assert.That(blue, Is.EqualTo(0));
        }

        [Test]
        public void TestConvertTslToRgbBytesBytes_MinTsl()
        {
            double tint = 0, saturation = 0, lightness = 0;
            (byte red, byte green, byte blue) = TslHelpers.ConvertTslToRgbBytes(tint, saturation, lightness);
            Assert.That(red, Is.EqualTo(0));
            Assert.That(green, Is.EqualTo(0));
            Assert.That(blue, Is.EqualTo(0));
        }

        [Test]
        public void TestConvertTslToRgbBytesBytes_MaxTsl()
        {
            double tint = 0, saturation = 0, lightness = 1;
            (byte red, byte green, byte blue) = TslHelpers.ConvertTslToRgbBytes(tint, saturation, lightness);
            Assert.That(red, Is.EqualTo(255));
            Assert.That(green, Is.EqualTo(255));
            Assert.That(blue, Is.EqualTo(255));
        }

        [Test]
        public void TestConvertTslToRgbBytesBytes_MixedTsl()
        {
            double tint = 0.176, saturation = 0.25, lightness = 0.79;
            (byte red, byte green, byte blue) = TslHelpers.ConvertTslToRgbBytes(tint, saturation, lightness);
            Assert.That(red, Is.EqualTo(127));
            Assert.That(green, Is.EqualTo(254));
            Assert.That(blue, Is.EqualTo(127));
        }
    }
}
