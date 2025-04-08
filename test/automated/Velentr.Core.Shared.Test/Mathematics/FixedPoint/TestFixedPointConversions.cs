using Velentr.Core.Mathematics.FixedPoint;

namespace Velentr.Core.Test.Mathematics.FixedPoint;

[TestFixture]
public class TestFixedPointConversions
{
    [Test]
    [Category("ToFixedPointPrecision2")]
    [TestCase(0.0)]
    [TestCase(1.23)]
    [TestCase(-4.56)]
    [TestCase(100.99)]
    public void ToFixedPointPrecision2_FromFixedPointPrecision2I_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP2I fp2i = FP2I.CreateFromDouble(value);

        // Act
        FP2 result = fp2i.ToFixedPointPrecision2();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(fp2i.ToDouble()).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision2")]
    [TestCase(0.0)]
    [TestCase(1.2345)]
    [TestCase(-4.5678)]
    [TestCase(100.9999)]
    public void ToFixedPointPrecision2_FromFixedPointPrecision4_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP4 fp4 = FP4.CreateFromDouble(value);

        // Act
        FP2 result = fp4.ToFixedPointPrecision2();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision2")]
    [TestCase(0.0)]
    [TestCase(1.234567)]
    [TestCase(-4.567890)]
    [TestCase(100.999999)]
    public void ToFixedPointPrecision2_FromFixedPointPrecision6_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP6 fp6 = FP6.CreateFromDouble(value);

        // Act
        FP2 result = fp6.ToFixedPointPrecision2();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision2")]
    [TestCase(0.0)]
    [TestCase(1.23456789)]
    [TestCase(-4.56789012)]
    [TestCase(100.99999999)]
    public void ToFixedPointPrecision2_FromFixedPointPrecision8_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP8 fp8 = FP8.CreateFromDouble(value);

        // Act
        FP2 result = fp8.ToFixedPointPrecision2();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision2I")]
    [TestCase(0.0)]
    [TestCase(1.23)]
    [TestCase(-4.56)]
    [TestCase(100.99)]
    public void ToFixedPointPrecision2I_FromFixedPointPrecision2_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP2 fp2 = FP2.CreateFromDouble(value);

        // Act
        FP2I result = fp2.ToFixedPointPrecision2I();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision2I")]
    [TestCase(0.0)]
    [TestCase(1.2345)]
    [TestCase(-4.5678)]
    [TestCase(100.9999)]
    public void ToFixedPointPrecision2I_FromFixedPointPrecision4_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP4 fp4 = FP4.CreateFromDouble(value);

        // Act
        FP2I result = fp4.ToFixedPointPrecision2I();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision2I")]
    [TestCase(0.0)]
    [TestCase(1.234567)]
    [TestCase(-4.567890)]
    [TestCase(100.999999)]
    public void ToFixedPointPrecision2I_FromFixedPointPrecision6_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP6 fp6 = FP6.CreateFromDouble(value);

        // Act
        FP2I result = fp6.ToFixedPointPrecision2I();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision2I")]
    [TestCase(0.0)]
    [TestCase(1.23456789)]
    [TestCase(-4.56789012)]
    [TestCase(100.99999999)]
    public void ToFixedPointPrecision2I_FromFixedPointPrecision8_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP8 fp8 = FP8.CreateFromDouble(value);

        // Act
        FP2I result = fp8.ToFixedPointPrecision2I();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision4")]
    [TestCase(0.0)]
    [TestCase(1.23)]
    [TestCase(-4.56)]
    [TestCase(100.99)]
    public void ToFixedPointPrecision4_FromFixedPointPrecision2_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP2 fp2 = FP2.CreateFromDouble(value);

        // Act
        FP4 result = fp2.ToFixedPointPrecision4();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision4")]
    [TestCase(0.0)]
    [TestCase(1.23)]
    [TestCase(-4.56)]
    [TestCase(100.99)]
    public void ToFixedPointPrecision4_FromFixedPointPrecision2I_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP2I fp2i = FP2I.CreateFromDouble(value);

        // Act
        FP4 result = fp2i.ToFixedPointPrecision4();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision4")]
    [TestCase(0.0)]
    [TestCase(1.234567)]
    [TestCase(-4.567890)]
    [TestCase(100.999999)]
    public void ToFixedPointPrecision4_FromFixedPointPrecision6_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP6 fp6 = FP6.CreateFromDouble(value);

        // Act
        FP4 result = fp6.ToFixedPointPrecision4();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.0001));
    }

    [Test]
    [Category("ToFixedPointPrecision4")]
    [TestCase(0.0)]
    [TestCase(1.23456789)]
    [TestCase(-4.56789012)]
    [TestCase(100.99999999)]
    public void ToFixedPointPrecision4_FromFixedPointPrecision8_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP8 fp8 = FP8.CreateFromDouble(value);

        // Act
        FP4 result = fp8.ToFixedPointPrecision4();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.0001));
    }

    [Test]
    [Category("ToFixedPointPrecision6")]
    [TestCase(0.0)]
    [TestCase(1.23)]
    [TestCase(-4.56)]
    [TestCase(100.99)]
    public void ToFixedPointPrecision6_FromFixedPointPrecision2_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP2 fp2 = FP2.CreateFromDouble(value);

        // Act
        FP6 result = fp2.ToFixedPointPrecision6();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision6")]
    [TestCase(0.0)]
    [TestCase(1.23)]
    [TestCase(-4.56)]
    [TestCase(100.99)]
    public void ToFixedPointPrecision6_FromFixedPointPrecision2I_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP2I fp2i = FP2I.CreateFromDouble(value);

        // Act
        FP6 result = fp2i.ToFixedPointPrecision6();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision6")]
    [TestCase(0.0)]
    [TestCase(1.2345)]
    [TestCase(-4.5678)]
    [TestCase(100.9999)]
    public void ToFixedPointPrecision6_FromFixedPointPrecision4_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP4 fp4 = FP4.CreateFromDouble(value);

        // Act
        FP6 result = fp4.ToFixedPointPrecision6();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision6")]
    [TestCase(0.0)]
    [TestCase(1.23456789)]
    [TestCase(-4.56789012)]
    [TestCase(100.99999999)]
    public void ToFixedPointPrecision6_FromFixedPointPrecision8_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP8 fp8 = FP8.CreateFromDouble(value);

        // Act
        FP6 result = fp8.ToFixedPointPrecision6();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.000001));
    }

    [Test]
    [Category("ToFixedPointPrecision8")]
    [TestCase(0.0)]
    [TestCase(1.23)]
    [TestCase(-4.56)]
    [TestCase(100.99)]
    public void ToFixedPointPrecision8_FromFixedPointPrecision2_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP2 fp2 = FP2.CreateFromDouble(value);

        // Act
        FP8 result = fp2.ToFixedPointPrecision8();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision8")]
    [TestCase(0.0)]
    [TestCase(1.23)]
    [TestCase(-4.56)]
    [TestCase(100.99)]
    public void ToFixedPointPrecision8_FromFixedPointPrecision2I_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP2I fp2i = FP2I.CreateFromDouble(value);

        // Act
        FP8 result = fp2i.ToFixedPointPrecision8();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.01));
    }

    [Test]
    [Category("ToFixedPointPrecision8")]
    [TestCase(0.0)]
    [TestCase(1.2345)]
    [TestCase(-4.5678)]
    [TestCase(100.9999)]
    public void ToFixedPointPrecision8_FromFixedPointPrecision4_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP4 fp4 = FP4.CreateFromDouble(value);

        // Act
        FP8 result = fp4.ToFixedPointPrecision8();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.0001));
    }

    [Test]
    [Category("ToFixedPointPrecision8")]
    [TestCase(0.0)]
    [TestCase(1.234567)]
    [TestCase(-4.567890)]
    [TestCase(100.999999)]
    public void ToFixedPointPrecision8_FromFixedPointPrecision6_ShouldConvertCorrectly(double value)
    {
        // Arrange
        FP6 fp6 = FP6.CreateFromDouble(value);

        // Act
        FP8 result = fp6.ToFixedPointPrecision8();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(value).Within(0.000001));
    }

    [Test]
    [Category("RoundTrip")]
    [TestCase(0.0)]
    [TestCase(1.23)]
    [TestCase(-4.56)]
    [TestCase(100.99)]
    public void RoundTrip_FixedPointPrecision2_ThroughAllTypes_ShouldPreserveValue(double value)
    {
        // Arrange
        FP2 original = FP2.CreateFromDouble(value);

        // Act
        FP2I fp2i = original.ToFixedPointPrecision2I();
        FP4 fp4 = fp2i.ToFixedPointPrecision4();
        FP6 fp6 = fp4.ToFixedPointPrecision6();
        FP8 fp8 = fp6.ToFixedPointPrecision8();
        FP2 result = fp8.ToFixedPointPrecision2();

        // Assert
        Assert.That(result.ToDouble(), Is.EqualTo(original.ToDouble()).Within(0.01));
    }

    [Test]
    [Category("EdgeCases")]
    public void ConversionBetweenAllTypes_WithMaxValues_ShouldPreserveCorrectScale()
    {
        // Test with values near the edge of representation
        const double largeValue = 10000.99;
        const double smallValue = 0.000001;

        // Large values
        FP2 fp2Large = FP2.CreateFromDouble(largeValue);
        FP8 fp8Large = fp2Large.ToFixedPointPrecision8();
        Assert.That(fp8Large.ToDouble(), Is.EqualTo(largeValue).Within(0.01));

        // Small values
        FP8 fp8Small = FP8.CreateFromDouble(smallValue);
        FP2 fp2Small = fp8Small.ToFixedPointPrecision2();
        // Here we expect limited precision due to the conversion
        Assert.That(fp2Small.ToDouble(), Is.EqualTo(0).Within(0.01));
    }
}
