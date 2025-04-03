using NUnit.Framework;
using Velentr.Core.Mathematics;
using System.Numerics;

namespace Velentr.Core.Test.Mathematics;

[TestFixture]
public class TestNumericExtensions
{
    [Test]
    public void ToInt_ShouldHandleMinValue()
    {
        // Arrange
        var value = int.MinValue;

        // Act
        var result = value.ToInt();

        // Assert
        Assert.That(result, Is.EqualTo(int.MinValue));
    }

    [Test]
    public void ToInt_ShouldHandleMaxValue()
    {
        // Arrange
        var value = int.MaxValue;

        // Act
        var result = value.ToInt();

        // Assert
        Assert.That(result, Is.EqualTo(int.MaxValue));
    }

    [Test]
    public void ToLong_ShouldHandleMinValue()
    {
        // Arrange
        var value = long.MinValue;

        // Act
        var result = value.ToLong();

        // Assert
        Assert.That(result, Is.EqualTo(long.MinValue));
    }

    [Test]
    public void ToLong_ShouldHandleMaxValue()
    {
        // Arrange
        var value = long.MaxValue;

        // Act
        var result = value.ToLong();

        // Assert
        Assert.That(result, Is.EqualTo(long.MaxValue));
    }

    [Test]
    public void ToFloat_ShouldHandleMinValue()
    {
        // Arrange
        var value = float.MinValue;

        // Act
        var result = value.ToFloat();

        // Assert
        Assert.That(result, Is.EqualTo(float.MinValue));
    }

    [Test]
    public void ToFloat_ShouldHandleMaxValue()
    {
        // Arrange
        var value = float.MaxValue;

        // Act
        var result = value.ToFloat();

        // Assert
        Assert.That(result, Is.EqualTo(float.MaxValue));
    }

    [Test]
    public void ToDouble_ShouldHandleMinValue()
    {
        // Arrange
        var value = double.MinValue;

        // Act
        var result = value.ToDouble();

        // Assert
        Assert.That(result, Is.EqualTo(double.MinValue));
    }

    [Test]
    public void ToDouble_ShouldHandleMaxValue()
    {
        // Arrange
        var value = double.MaxValue;

        // Act
        var result = value.ToDouble();

        // Assert
        Assert.That(result, Is.EqualTo(double.MaxValue));
    }

    [Test]
    public void ToDecimal_ShouldHandleMinValue()
    {
        // Arrange
        var value = decimal.MinValue;

        // Act
        var result = value.ToDecimal();

        // Assert
        Assert.That(result, Is.EqualTo(decimal.MinValue));
    }

    [Test]
    public void ToDecimal_ShouldHandleMaxValue()
    {
        // Arrange
        var value = decimal.MaxValue;

        // Act
        var result = value.ToDecimal();

        // Assert
        Assert.That(result, Is.EqualTo(decimal.MaxValue));
    }

    [Test]
    public void ToBigInteger_ShouldHandleMinValue()
    {
        // Arrange
        var value = BigInteger.MinusOne;

        // Act
        var result = value.ToBigInteger();

        // Assert
        Assert.That(result, Is.EqualTo(BigInteger.MinusOne));
    }

    [Test]
    public void ToBigInteger_ShouldHandleMaxValue()
    {
        // Arrange
        var value = BigInteger.One;

        // Act
        var result = value.ToBigInteger();

        // Assert
        Assert.That(result, Is.EqualTo(BigInteger.One));
    }
    
    [Test]
    public void ToShort_ShouldHandleMinValue()
    {
        // Arrange
        var value = short.MinValue;

        // Act
        var result = value.ToShort();

        // Assert
        Assert.That(result, Is.EqualTo(short.MinValue));
    }

    [Test]
    public void ToShort_ShouldHandleMaxValue()
    {
        // Arrange
        var value = short.MaxValue;

        // Act
        var result = value.ToShort();

        // Assert
        Assert.That(result, Is.EqualTo(short.MaxValue));
    }

    [Test]
    public void ToByte_ShouldHandleMinValue()
    {
        // Arrange
        var value = byte.MinValue;

        // Act
        var result = value.ToByte();

        // Assert
        Assert.That(result, Is.EqualTo(byte.MinValue));
    }

    [Test]
    public void ToByte_ShouldHandleMaxValue()
    {
        // Arrange
        var value = byte.MaxValue;

        // Act
        var result = value.ToByte();

        // Assert
        Assert.That(result, Is.EqualTo(byte.MaxValue));
    }

    [Test]
    public void ToSByte_ShouldHandleMinValue()
    {
        // Arrange
        var value = sbyte.MinValue;

        // Act
        var result = value.ToSByte();

        // Assert
        Assert.That(result, Is.EqualTo(sbyte.MinValue));
    }

    [Test]
    public void ToSByte_ShouldHandleMaxValue()
    {
        // Arrange
        var value = sbyte.MaxValue;

        // Act
        var result = value.ToSByte();

        // Assert
        Assert.That(result, Is.EqualTo(sbyte.MaxValue));
    }

    [Test]
    public void ToUShort_ShouldHandleMinValue()
    {
        // Arrange
        var value = ushort.MinValue;

        // Act
        var result = value.ToUShort();

        // Assert
        Assert.That(result, Is.EqualTo(ushort.MinValue));
    }

    [Test]
    public void ToUShort_ShouldHandleMaxValue()
    {
        // Arrange
        var value = ushort.MaxValue;

        // Act
        var result = value.ToUShort();

        // Assert
        Assert.That(result, Is.EqualTo(ushort.MaxValue));
    }

    [Test]
    public void ToUInt_ShouldHandleMinValue()
    {
        // Arrange
        var value = uint.MinValue;

        // Act
        var result = value.ToUInt();

        // Assert
        Assert.That(result, Is.EqualTo(uint.MinValue));
    }

    [Test]
    public void ToUInt_ShouldHandleMaxValue()
    {
        // Arrange
        var value = uint.MaxValue;

        // Act
        var result = value.ToUInt();

        // Assert
        Assert.That(result, Is.EqualTo(uint.MaxValue));
    }

    [Test]
    public void ToULong_ShouldHandleMinValue()
    {
        // Arrange
        var value = ulong.MinValue;

        // Act
        var result = value.ToULong();

        // Assert
        Assert.That(result, Is.EqualTo(ulong.MinValue));
    }

    [Test]
    public void ToULong_ShouldHandleMaxValue()
    {
        // Arrange
        var value = ulong.MaxValue;

        // Act
        var result = value.ToULong();

        // Assert
        Assert.That(result, Is.EqualTo(ulong.MaxValue));
    }
}