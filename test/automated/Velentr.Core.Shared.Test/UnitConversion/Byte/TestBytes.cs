using NUnit.Framework;
using Velentr.Core.UnitConversion;
using Velentr.Core.UnitConversion.Byte;

namespace Velentr.Core.Test.UnitConversion.Byte;

[TestFixture]
public class BytesTests
{
    [Test]
    public void Constructor_ShouldInitializeCorrectly()
    {
        // Arrange & Act
        var bytes = new Bytes(1024, ByteUnits.KB);

        // Assert
        Assert.That(bytes.Value, Is.EqualTo(1024));
        Assert.That(bytes.Unit, Is.EqualTo(ByteUnits.KB));
        Assert.That(bytes.BaseSize, Is.EqualTo(1024));
    }

    [Test]
    public void AsUnit_ShouldConvertCorrectly()
    {
        // Arrange
        var bytes = new Bytes(1, ByteUnits.GB);

        // Act
        var result = bytes.AsUnit(ByteUnits.MB);

        // Assert
        Assert.That(result, Is.EqualTo(1024));
    }

    [Test]
    public void ToUnit_ShouldReturnNewInstanceWithConvertedValue()
    {
        // Arrange
        var bytes = new Bytes(1, ByteUnits.GB);

        // Act
        var result = bytes.ToUnit(ByteUnits.MB);

        // Assert
        Assert.That(result.Value, Is.EqualTo(1024));
        Assert.That(result.Unit, Is.EqualTo(ByteUnits.MB));
    }

    [Test]
    public void ToUnit_ShouldReturnNewInstanceWithConvertedValue_Alternate()
    {
        // Arrange
        var bytes = new Bytes(1, ByteUnits.TB);

        // Act
        var result = bytes.ToUnit(ByteUnits.MB);

        // Assert
        Assert.That(result.Value, Is.EqualTo(1024 * 1024));
        Assert.That(result.Unit, Is.EqualTo(ByteUnits.MB));
    }

    [Test]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        // Arrange
        var bytes = new Bytes(1024, ByteUnits.KB);

        // Act
        var result = bytes.ToString();

        // Assert
        Assert.That(result, Is.EqualTo("1024 KB"));
    }

    [Test]
    public void Equals_ShouldReturnTrueForEqualInstances()
    {
        // Arrange
        var bytes1 = new Bytes(1024, ByteUnits.KB);
        var bytes2 = new Bytes(1024, ByteUnits.KB);

        // Act & Assert
        Assert.That(bytes1.Equals(bytes2), Is.True);
    }

    [Test]
    public void Equals_ShouldReturnFalseForDifferentInstances()
    {
        // Arrange
        var bytes1 = new Bytes(1024, ByteUnits.KB);
        var bytes2 = new Bytes(2048, ByteUnits.KB);

        // Act & Assert
        Assert.That(bytes1.Equals(bytes2), Is.False);
    }

    [Test]
    public void OperatorPlus_ShouldAddValuesCorrectly()
    {
        // Arrange
        var bytes1 = new Bytes(1024, ByteUnits.KB);
        var bytes2 = new Bytes(1, ByteUnits.MB);

        // Act
        var result = bytes1 + bytes2;

        // Assert
        Assert.That(result.Value, Is.EqualTo(2048));
        Assert.That(result.Unit, Is.EqualTo(ByteUnits.KB));
    }

    [Test]
    public void OperatorMinus_ShouldSubtractValuesCorrectly()
    {
        // Arrange
        var bytes1 = new Bytes(2048, ByteUnits.KB);
        var bytes2 = new Bytes(1, ByteUnits.MB);

        // Act
        var result = bytes1 - bytes2;

        // Assert
        Assert.That(result.Value, Is.EqualTo(1024));
        Assert.That(result.Unit, Is.EqualTo(ByteUnits.KB));
    }

    [Test]
    public void OperatorMultiply_ShouldMultiplyValuesCorrectly()
    {
        // Arrange
        var bytes1 = new Bytes(2, ByteUnits.MB);
        var bytes2 = new Bytes(2, ByteUnits.MB);

        // Act
        var result = bytes1 * bytes2;

        // Assert
        Assert.That(result.Value, Is.EqualTo(4));
        Assert.That(result.Unit, Is.EqualTo(ByteUnits.MB));
    }

    [Test]
    public void OperatorDivide_ShouldDivideValuesCorrectly()
    {
        // Arrange
        var bytes1 = new Bytes(4, ByteUnits.MB);
        var bytes2 = new Bytes(2, ByteUnits.MB);

        // Act
        var result = bytes1 / bytes2;

        // Assert
        Assert.That(result.Value, Is.EqualTo(2));
        Assert.That(result.Unit, Is.EqualTo(ByteUnits.MB));
    }

    [Test]
    public void OperatorModulus_ShouldReturnCorrectRemainder()
    {
        // Arrange
        var bytes1 = new Bytes(5, ByteUnits.MB);
        var bytes2 = new Bytes(2, ByteUnits.MB);

        // Act
        var result = bytes1 % bytes2;

        // Assert
        Assert.That(result.Value, Is.EqualTo(1));
        Assert.That(result.Unit, Is.EqualTo(ByteUnits.MB));
    }

    [Test]
    public void OperatorIncrement_ShouldIncrementValueCorrectly()
    {
        // Arrange
        var bytes = new Bytes(1024, ByteUnits.KB);

        // Act
        bytes++;

        // Assert
        Assert.That(bytes.Value, Is.EqualTo(1025));
    }

    [Test]
    public void OperatorDecrement_ShouldDecrementValueCorrectly()
    {
        // Arrange
        var bytes = new Bytes(1024, ByteUnits.KB);

        // Act
        bytes--;

        // Assert
        Assert.That(bytes.Value, Is.EqualTo(1023));
    }
}
