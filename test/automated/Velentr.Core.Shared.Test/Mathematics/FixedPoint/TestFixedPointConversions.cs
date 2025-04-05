using NUnit.Framework;
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
        var fp2i = FixedPointPrecision2I.CreateFromDouble(value);
            
        // Act
        var result = fp2i.ToFixedPointPrecision2();
            
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
        var fp4 = FixedPointPrecision4.CreateFromDouble(value);
            
        // Act
        var result = fp4.ToFixedPointPrecision2();
            
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
        var fp6 = FixedPointPrecision6.CreateFromDouble(value);
            
        // Act
        var result = fp6.ToFixedPointPrecision2();
            
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
        var fp8 = FixedPointPrecision8.CreateFromDouble(value);
            
        // Act
        var result = fp8.ToFixedPointPrecision2();
            
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
        var fp2 = FixedPointPrecision2.CreateFromDouble(value);
            
        // Act
        var result = fp2.ToFixedPointPrecision2I();
            
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
        var fp4 = FixedPointPrecision4.CreateFromDouble(value);
            
        // Act
        var result = fp4.ToFixedPointPrecision2I();
            
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
        var fp6 = FixedPointPrecision6.CreateFromDouble(value);
            
        // Act
        var result = fp6.ToFixedPointPrecision2I();
            
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
        var fp8 = FixedPointPrecision8.CreateFromDouble(value);
            
        // Act
        var result = fp8.ToFixedPointPrecision2I();
            
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
        var fp2 = FixedPointPrecision2.CreateFromDouble(value);
            
        // Act
        var result = fp2.ToFixedPointPrecision4();
            
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
        var fp2i = FixedPointPrecision2I.CreateFromDouble(value);
            
        // Act
        var result = fp2i.ToFixedPointPrecision4();
            
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
        var fp6 = FixedPointPrecision6.CreateFromDouble(value);
            
        // Act
        var result = fp6.ToFixedPointPrecision4();
            
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
        var fp8 = FixedPointPrecision8.CreateFromDouble(value);
            
        // Act
        var result = fp8.ToFixedPointPrecision4();
            
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
        var fp2 = FixedPointPrecision2.CreateFromDouble(value);
            
        // Act
        var result = fp2.ToFixedPointPrecision6();
            
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
        var fp2i = FixedPointPrecision2I.CreateFromDouble(value);
            
        // Act
        var result = fp2i.ToFixedPointPrecision6();
            
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
        var fp4 = FixedPointPrecision4.CreateFromDouble(value);
            
        // Act
        var result = fp4.ToFixedPointPrecision6();
            
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
        var fp8 = FixedPointPrecision8.CreateFromDouble(value);
            
        // Act
        var result = fp8.ToFixedPointPrecision6();
            
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
        var fp2 = FixedPointPrecision2.CreateFromDouble(value);
            
        // Act
        var result = fp2.ToFixedPointPrecision8();
            
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
        var fp2i = FixedPointPrecision2I.CreateFromDouble(value);
            
        // Act
        var result = fp2i.ToFixedPointPrecision8();
            
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
        var fp4 = FixedPointPrecision4.CreateFromDouble(value);
            
        // Act
        var result = fp4.ToFixedPointPrecision8();
            
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
        var fp6 = FixedPointPrecision6.CreateFromDouble(value);
            
        // Act
        var result = fp6.ToFixedPointPrecision8();
            
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
        var original = FixedPointPrecision2.CreateFromDouble(value);
            
        // Act
        var fp2i = original.ToFixedPointPrecision2I();
        var fp4 = fp2i.ToFixedPointPrecision4();
        var fp6 = fp4.ToFixedPointPrecision6();
        var fp8 = fp6.ToFixedPointPrecision8();
        var result = fp8.ToFixedPointPrecision2();
            
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
        var fp2Large = FixedPointPrecision2.CreateFromDouble(largeValue);
        var fp8Large = fp2Large.ToFixedPointPrecision8();
        Assert.That(fp8Large.ToDouble(), Is.EqualTo(largeValue).Within(0.01));
            
        // Small values
        var fp8Small = FixedPointPrecision8.CreateFromDouble(smallValue);
        var fp2Small = fp8Small.ToFixedPointPrecision2();
        // Here we expect limited precision due to the conversion
        Assert.That(fp2Small.ToDouble(), Is.EqualTo(0).Within(0.01));
    }
}