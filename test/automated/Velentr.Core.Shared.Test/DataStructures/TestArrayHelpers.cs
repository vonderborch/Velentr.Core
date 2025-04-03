using NUnit.Framework;
using Velentr.Core.DataStructures;

namespace Velentr.Core.Test.DataStructures;

[TestFixture]
public class TestArrayHelpers
{
    [Test]
    public void Convert1DArrayTo2DArray_ShouldHandleEmptyArray()
    {
        // Arrange
        var baseArray = new int[0];

        // Act
        var result = ArrayHelpers.Convert1DArrayTo2DArray(baseArray, 0, 0);

        // Assert
        Assert.That(result.Length, Is.EqualTo(0));
    }

    [Test]
    public void Convert1DArrayTo2DArray_ShouldHandleSingleElementArray()
    {
        // Arrange
        var baseArray = new[] { 1 };

        // Act
        var result = ArrayHelpers.Convert1DArrayTo2DArray(baseArray, 1, 1);

        // Assert
        Assert.That(result[0, 0], Is.EqualTo(1));
    }

    [Test]
    public void Convert1DArrayTo2DArray_ShouldThrowForInvalidDimensions()
    {
        // Arrange
        var baseArray = new[] { 1, 2, 3, 4 };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => ArrayHelpers.Convert1DArrayTo2DArray(baseArray, 3, 2));
    }

    [Test]
    public void Convert2DArrayTo1DArray_ShouldHandleEmptyArray()
    {
        // Arrange
        var baseArray = new int[0, 0];

        // Act
        var result = ArrayHelpers.Convert2DArrayTo1DArray(baseArray, 0, 0);

        // Assert
        Assert.That(result.Length, Is.EqualTo(0));
    }

    [Test]
    public void Convert2DArrayTo1DArray_ShouldHandleSingleElementArray()
    {
        // Arrange
        var baseArray = new int[1, 1] { { 1 } };

        // Act
        var result = ArrayHelpers.Convert2DArrayTo1DArray(baseArray, 1, 1);

        // Assert
        Assert.That(result[0], Is.EqualTo(1));
    }

    [Test]
    public void Convert2DArrayTo1DArray_ShouldThrowForInvalidDimensions()
    {
        // Arrange
        var baseArray = new int[2, 2] { { 1, 2 }, { 3, 4 } };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => ArrayHelpers.Convert2DArrayTo1DArray(baseArray, 3, 2));
    }

    [Test]
    public void Convert1DArrayTo2DArray_ShouldHandleNonSquareDimensions()
    {
        // Arrange
        var baseArray = new[] { 1, 2, 3, 4, 5, 6 };

        // Act
        var result = ArrayHelpers.Convert1DArrayTo2DArray(baseArray, 2, 3);

        // Assert
        Assert.That(result[0, 0], Is.EqualTo(1));
        Assert.That(result[1, 2], Is.EqualTo(6));
    }

    [Test]
    public void Convert2DArrayTo1DArray_ShouldHandleNonSquareDimensions()
    {
        // Arrange
        var baseArray = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

        // Act
        var result = ArrayHelpers.Convert2DArrayTo1DArray(baseArray, 2, 3);

        // Assert
        Assert.That(result[0], Is.EqualTo(1));
        Assert.That(result[5], Is.EqualTo(6));
    }
    [Test]
    public void ConvertTo2DArray_ShouldHandleEmptyArray()
    {
        // Arrange
        var baseArray = new int[0];

        // Act
        var result = baseArray.ConvertTo2DArray(0, 0);

        // Assert
        Assert.That(result.Length, Is.EqualTo(0));
    }

    [Test]
    public void ConvertTo2DArray_ShouldHandleSingleElementArray()
    {
        // Arrange
        var baseArray = new[] { 1 };

        // Act
        var result = baseArray.ConvertTo2DArray(1, 1);

        // Assert
        Assert.That(result[0, 0], Is.EqualTo(1));
    }

    [Test]
    public void ConvertTo2DArray_ShouldThrowForInvalidDimensions()
    {
        // Arrange
        var baseArray = new[] { 1, 2, 3, 4 };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => baseArray.ConvertTo2DArray(3, 2));
    }

    [Test]
    public void ConvertTo2DArray_ShouldHandleNonSquareDimensions()
    {
        // Arrange
        var baseArray = new[] { 1, 2, 3, 4, 5, 6 };

        // Act
        var result = baseArray.ConvertTo2DArray(2, 3);

        // Assert
        Assert.That(result[0, 0], Is.EqualTo(1));
        Assert.That(result[1, 2], Is.EqualTo(6));
    }

    [Test]
    public void ConvertTo2DArray_ShouldHandleLargerArray()
    {
        // Arrange
        var baseArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        // Act
        var result = baseArray.ConvertTo2DArray(3, 4);

        // Assert
        Assert.That(result[0, 0], Is.EqualTo(1));
        Assert.That(result[2, 3], Is.EqualTo(12));
    }
    [Test]
    public void ConvertTo1DArray_ShouldHandleEmptyArray()
    {
        // Arrange
        var baseArray = new int[0, 0];

        // Act
        var result = baseArray.ConvertTo1DArray(0, 0);

        // Assert
        Assert.That(result.Length, Is.EqualTo(0));
    }

    [Test]
    public void ConvertTo1DArray_ShouldHandleSingleElementArray()
    {
        // Arrange
        var baseArray = new int[1, 1] { { 1 } };

        // Act
        var result = baseArray.ConvertTo1DArray(1, 1);

        // Assert
        Assert.That(result[0], Is.EqualTo(1));
    }

    [Test]
    public void ConvertTo1DArray_ShouldThrowForInvalidDimensions()
    {
        // Arrange
        var baseArray = new int[2, 2] { { 1, 2 }, { 3, 4 } };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => baseArray.ConvertTo1DArray(3, 2));
    }

    [Test]
    public void ConvertTo1DArray_ShouldHandleNonSquareDimensions()
    {
        // Arrange
        var baseArray = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

        // Act
        var result = baseArray.ConvertTo1DArray(2, 3);

        // Assert
        Assert.That(result[0], Is.EqualTo(1));
        Assert.That(result[5], Is.EqualTo(6));
    }

    [Test]
    public void ConvertTo1DArray_ShouldHandleLargerArray()
    {
        // Arrange
        var baseArray = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };

        // Act
        var result = baseArray.ConvertTo1DArray(3, 4);

        // Assert
        Assert.That(result[0], Is.EqualTo(1));
        Assert.That(result[11], Is.EqualTo(12));
    }
}