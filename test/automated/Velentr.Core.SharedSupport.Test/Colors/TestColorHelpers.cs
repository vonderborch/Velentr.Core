using NUnit.Framework;
using Microsoft.Xna.Framework;
using Velentr.Core.FNA.Colors;

namespace Velentr.Core.Test.Colors
{
    [TestFixture]
    public class TestColorHelpers
    {
        [Test]
        public void ColorMeetsMinHslThreshold_ShouldReturnTrue()
        {
            // Arrange
            var color = new Color(100, 150, 200, 255);
            int hue = 200;
            float saturation = 0.5f;
            float lightness = 0.5f;
            float alpha = 1.0f;

            // Act
            var result = ColorHelpers.ColorMeetsMinHslThreshold(color, hue, saturation, lightness, alpha);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ColorMeetsMinHslThreshold_ShouldReturnFalse()
        {
            // Arrange
            var color = new Color(100, 150, 200, 255);
            int hue = 300;
            float saturation = 0.8f;
            float lightness = 0.8f;
            float alpha = 1.0f;

            // Act
            var result = ColorHelpers.ColorMeetsMinHslThreshold(color, hue, saturation, lightness, alpha);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ColorMeetsMinHsvThreshold_ShouldReturnTrue()
        {
            // Arrange
            var color = new Color(100, 150, 200, 255);
            int hue = 200;
            float saturation = 0.5f;
            float value = 0.5f;
            float alpha = 1.0f;

            // Act
            var result = ColorHelpers.ColorMeetsMinHsvThreshold(color, hue, saturation, value, alpha);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ColorMeetsMinHsvThreshold_ShouldReturnFalse()
        {
            // Arrange
            var color = new Color(100, 150, 200, 255);
            int hue = 300;
            float saturation = 0.8f;
            float value = 0.8f;
            float alpha = 1.0f;

            // Act
            var result = ColorHelpers.ColorMeetsMinHsvThreshold(color, hue, saturation, value, alpha);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ColorMeetsMinThreshold_ShouldReturnTrue()
        {
            // Arrange
            var color = new Color(100, 150, 200, 255);
            byte r = 100;
            byte g = 150;
            byte b = 200;
            byte a = 255;

            // Act
            var result = ColorHelpers.ColorMeetsMinThreshold(color, r, g, b, a);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ColorMeetsMinThreshold_ShouldReturnFalse()
        {
            // Arrange
            var color = new Color(100, 150, 200, 255);
            byte r = 50;
            byte g = 100;
            byte b = 150;
            byte a = 200;

            // Act
            var result = ColorHelpers.ColorMeetsMinThreshold(color, r, g, b, a);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void GenerateColorFromHsl_ShouldReturnCorrectColor()
        {
            // Arrange
            int hue = 200;
            float saturation = 0.5f;
            float lightness = 0.5f;
            float alpha = 1.0f;

            // Act
            var result = ColorHelpers.GenerateColorFromHsl(hue, saturation, lightness, alpha);

            // Assert
            Assert.That(result, Is.EqualTo(new Color(64, 191, 191, 255)));
        }

        [Test]
        public void GenerateColorFromHsv_ShouldReturnCorrectColor()
        {
            // Arrange
            int hue = 200;
            float saturation = 0.5f;
            float value = 0.5f;
            float alpha = 1.0f;

            // Act
            var result = ColorHelpers.GenerateColorFromHsv(hue, saturation, value, alpha);

            // Assert
            Assert.That(result, Is.EqualTo(new Color(64, 128, 128, 255)));
        }
    }
}