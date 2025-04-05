using NUnit.Framework;
using System.Numerics;
using Velentr.Core.Mathematics.Numerics;

namespace Velentr.Core.Test.Mathematics.Numerics;

[TestFixture]
public class TestCircularBoundedNumber
{
    [Test]
    public void TestCircularBoundedNumberInitialization()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(7, 5, 10);
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(7));
        Assert.That(circularBoundedNumber.Minimum, Is.EqualTo(5));
        Assert.That(circularBoundedNumber.Maximum, Is.EqualTo(10));
    }

    [Test]
    public void TestCircularBoundedNumberInitializationWithClamping()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(11, 5, 10);
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(6));
    }

    [Test]
    public void TestSetMinimum()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(7, 5, 10);
        circularBoundedNumber.Minimum = 6;
        Assert.That(circularBoundedNumber.Minimum, Is.EqualTo(6));
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(7));
    }

    [Test]
    public void TestSetMaximum()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(7, 5, 10);
        circularBoundedNumber.Maximum = 12;
        Assert.That(circularBoundedNumber.Maximum, Is.EqualTo(12));
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(7));
    }

    [Test]
    public void TestSetValue()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(7, 5, 10);
        circularBoundedNumber.Value = 9;
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(9));
    }

    [Test]
    public void TestSetValueWithClamping()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(7, 5, 10);
        circularBoundedNumber.Value = 11;
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(6));
    }

    [Test]
    public void TestAdditionOperator()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(7, 5, 10);
        var result = circularBoundedNumber + 5;
        Assert.That(result.Value, Is.EqualTo(7));
    }

    [Test]
    public void TestSubtractionOperator()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(7, 5, 10);
        var result = circularBoundedNumber - 3;
        Assert.That(result.Value, Is.EqualTo(9));
    }

    [Test]
    public void TestMultiplicationOperator()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(3, 1, 10);
        var result = circularBoundedNumber * 4;
        Assert.That(result.Value, Is.EqualTo(4));
    }

    [Test]
    public void TestDivisionOperator()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(8, 1, 10);
        var result = circularBoundedNumber / 2;
        Assert.That(result.Value, Is.EqualTo(4));
    }

    [Test]
    public void TestModulusOperator()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(8, 1, 10);
        var result = circularBoundedNumber % 3;
        Assert.That(result.Value, Is.EqualTo(2));
    }

    [Test]
    public void TestIncrementOperator()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(7, 5, 10);
        var result = ++circularBoundedNumber;
        Assert.That(result.Value, Is.EqualTo(8));
    }

    [Test]
    public void TestDecrementOperator()
    {
        var circularBoundedNumber = new CircularBoundedNumber<int>(7, 5, 10);
        var result = --circularBoundedNumber;
        Assert.That(result.Value, Is.EqualTo(6));
    }

    [Test]
    public void TestEqualityOperator()
    {
        var circularBoundedNumber1 = new CircularBoundedNumber<int>(7, 5, 10);
        var circularBoundedNumber2 = new CircularBoundedNumber<int>(7, 5, 10);
        Assert.That(circularBoundedNumber1 == circularBoundedNumber2, Is.True);
    }

    [Test]
    public void TestInequalityOperator()
    {
        var circularBoundedNumber1 = new CircularBoundedNumber<int>(7, 5, 10);
        var circularBoundedNumber2 = new CircularBoundedNumber<int>(8, 5, 10);
        Assert.That(circularBoundedNumber1 != circularBoundedNumber2, Is.True);
    }

    [Test]
    public void TestLessThanOperator()
    {
        var circularBoundedNumber1 = new CircularBoundedNumber<int>(7, 5, 10);
        var circularBoundedNumber2 = new CircularBoundedNumber<int>(8, 5, 10);
        Assert.That(circularBoundedNumber1 < circularBoundedNumber2, Is.True);
    }

    [Test]
    public void TestLessThanOrEqualOperator()
    {
        var circularBoundedNumber1 = new CircularBoundedNumber<int>(7, 5, 10);
        var circularBoundedNumber2 = new CircularBoundedNumber<int>(7, 5, 10);
        Assert.That(circularBoundedNumber1 <= circularBoundedNumber2, Is.True);
    }

    [Test]
    public void TestGreaterThanOperator()
    {
        var circularBoundedNumber1 = new CircularBoundedNumber<int>(8, 5, 10);
        var circularBoundedNumber2 = new CircularBoundedNumber<int>(7, 5, 10);
        Assert.That(circularBoundedNumber1 > circularBoundedNumber2, Is.True);
    }

    [Test]
    public void TestGreaterThanOrEqualOperator()
    {
        var circularBoundedNumber1 = new CircularBoundedNumber<int>(7, 5, 10);
        var circularBoundedNumber2 = new CircularBoundedNumber<int>(7, 5, 10);
        Assert.That(circularBoundedNumber1 >= circularBoundedNumber2, Is.True);
    }
}