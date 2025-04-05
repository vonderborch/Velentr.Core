using NUnit.Framework;
using System.Numerics;
using Velentr.Core.Mathematics.Numerics;

namespace Velentr.Core.Test.Mathematics.Numerics;

[TestFixture]
public class TestBoundedNumber
{
    [Test]
    public void TestBoundedNumberInitialization()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        Assert.That(boundedNumber.Value, Is.EqualTo(7));
        Assert.That(boundedNumber.Minimum, Is.EqualTo(5));
        Assert.That(boundedNumber.Maximum, Is.EqualTo(10));
    }

    [Test]
    public void TestBoundedNumberInitializationWithClamping()
    {
        var boundedNumber = new BoundedNumber<int>(4, 5, 10);
        Assert.That(boundedNumber.Value, Is.EqualTo(5));
    }

    [Test]
    public void TestSetMinimum()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        boundedNumber.Minimum = 6;
        Assert.That(boundedNumber.Minimum, Is.EqualTo(6));
        Assert.That(boundedNumber.Value, Is.EqualTo(7));
    }

    [Test]
    public void TestSetMaximum()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        boundedNumber.Maximum = 12;
        Assert.That(boundedNumber.Maximum, Is.EqualTo(12));
        Assert.That(boundedNumber.Value, Is.EqualTo(7));
    }

    [Test]
    public void TestSetValue()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        boundedNumber.Value = 9;
        Assert.That(boundedNumber.Value, Is.EqualTo(9));
    }

    [Test]
    public void TestSetValueWithClamping()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        boundedNumber.Value = 11;
        Assert.That(boundedNumber.Value, Is.EqualTo(10));
    }

    [Test]
    public void TestEquality()
    {
        var boundedNumber1 = new BoundedNumber<int>(7, 5, 10);
        var boundedNumber2 = new BoundedNumber<int>(7, 5, 10);
        var boundedNumber3 = new BoundedNumber<int>(8, 5, 10);
        Assert.That(boundedNumber1 == boundedNumber2, Is.True);
        Assert.That(boundedNumber1 != boundedNumber3, Is.True);
    }

    [Test]
    public void TestImplicitConversion()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        int value = boundedNumber;
        Assert.That(value, Is.EqualTo(7));
    }
        
    [Test]
    public void TestAdditionOperator()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        var result = boundedNumber + 2;
        Assert.That(result.Value, Is.EqualTo(9));
    }
        
    [Test]
    public void TestAdditionOperator_WithBoundedNumber()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        var result = boundedNumber + new BoundedNumber<int>(2, 1, 3);
        Assert.That(result.Value, Is.EqualTo(9));
    }

    [Test]
    public void TestSubtractionOperator()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        var result = boundedNumber - 2;
        Assert.That(result.Value, Is.EqualTo(5));
    }

    [Test]
    public void TestMultiplicationOperator()
    {
        var boundedNumber = new BoundedNumber<int>(3, 1, 10);
        var result = boundedNumber * 2;
        Assert.That(result.Value, Is.EqualTo(6));
    }

    [Test]
    public void TestDivisionOperator()
    {
        var boundedNumber = new BoundedNumber<int>(8, 1, 10);
        var result = boundedNumber / 2;
        Assert.That(result.Value, Is.EqualTo(4));
    }

    [Test]
    public void TestModulusOperator()
    {
        var boundedNumber = new BoundedNumber<int>(8, 1, 10);
        var result = boundedNumber % 3;
        Assert.That(result.Value, Is.EqualTo(2));
    }

    [Test]
    public void TestIncrementOperator()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        var result = ++boundedNumber;
        Assert.That(result.Value, Is.EqualTo(8));
    }

    [Test]
    public void TestDecrementOperator()
    {
        var boundedNumber = new BoundedNumber<int>(7, 5, 10);
        var result = --boundedNumber;
        Assert.That(result.Value, Is.EqualTo(6));
    }

    [Test]
    public void TestEqualityOperator()
    {
        var boundedNumber1 = new BoundedNumber<int>(7, 5, 10);
        var boundedNumber2 = new BoundedNumber<int>(7, 5, 10);
        Assert.That(boundedNumber1 == boundedNumber2, Is.True);
    }

    [Test]
    public void TestInequalityOperator()
    {
        var boundedNumber1 = new BoundedNumber<int>(7, 5, 10);
        var boundedNumber2 = new BoundedNumber<int>(8, 5, 10);
        Assert.That(boundedNumber1 != boundedNumber2, Is.True);
    }

    [Test]
    public void TestLessThanOperator()
    {
        var boundedNumber1 = new BoundedNumber<int>(7, 5, 10);
        var boundedNumber2 = new BoundedNumber<int>(8, 5, 10);
        Assert.That(boundedNumber1 < boundedNumber2, Is.True);
    }

    [Test]
    public void TestLessThanOrEqualOperator()
    {
        var boundedNumber1 = new BoundedNumber<int>(7, 5, 10);
        var boundedNumber2 = new BoundedNumber<int>(7, 5, 10);
        Assert.That(boundedNumber1 <= boundedNumber2, Is.True);
    }

    [Test]
    public void TestGreaterThanOperator()
    {
        var boundedNumber1 = new BoundedNumber<int>(8, 5, 10);
        var boundedNumber2 = new BoundedNumber<int>(7, 5, 10);
        Assert.That(boundedNumber1 > boundedNumber2, Is.True);
    }

    [Test]
    public void TestGreaterThanOrEqualOperator()
    {
        var boundedNumber1 = new BoundedNumber<int>(7, 5, 10);
        var boundedNumber2 = new BoundedNumber<int>(7, 5, 10);
        Assert.That(boundedNumber1 >= boundedNumber2, Is.True);
    }
}