using Velentr.Core.Mathematics.Numerics;

namespace Velentr.Core.Test.Mathematics.Numerics;

[TestFixture]
public class TestBoundedNumber
{
    [Test]
    public void TestBoundedNumberInitialization()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        Assert.That(boundedNumber.Value, Is.EqualTo(7));
        Assert.That(boundedNumber.Minimum, Is.EqualTo(5));
        Assert.That(boundedNumber.Maximum, Is.EqualTo(10));
    }

    [Test]
    public void TestBoundedNumberInitializationWithClamping()
    {
        BoundedNumber<int> boundedNumber = new(4, 5, 10);
        Assert.That(boundedNumber.Value, Is.EqualTo(5));
    }

    [Test]
    public void TestSetMinimum()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        boundedNumber.Minimum = 6;
        Assert.That(boundedNumber.Minimum, Is.EqualTo(6));
        Assert.That(boundedNumber.Value, Is.EqualTo(7));
    }

    [Test]
    public void TestSetMaximum()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        boundedNumber.Maximum = 12;
        Assert.That(boundedNumber.Maximum, Is.EqualTo(12));
        Assert.That(boundedNumber.Value, Is.EqualTo(7));
    }

    [Test]
    public void TestSetValue()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        boundedNumber.Value = 9;
        Assert.That(boundedNumber.Value, Is.EqualTo(9));
    }

    [Test]
    public void TestSetValueWithClamping()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        boundedNumber.Value = 11;
        Assert.That(boundedNumber.Value, Is.EqualTo(10));
    }

    [Test]
    public void TestEquality()
    {
        BoundedNumber<int> boundedNumber1 = new(7, 5, 10);
        BoundedNumber<int> boundedNumber2 = new(7, 5, 10);
        BoundedNumber<int> boundedNumber3 = new(8, 5, 10);
        Assert.That(boundedNumber1 == boundedNumber2, Is.True);
        Assert.That(boundedNumber1 != boundedNumber3, Is.True);
    }

    [Test]
    public void TestImplicitConversion()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        int value = boundedNumber;
        Assert.That(value, Is.EqualTo(7));
    }

    [Test]
    public void TestAdditionOperator()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        BoundedNumber<int> result = boundedNumber + 2;
        Assert.That(result.Value, Is.EqualTo(9));
    }

    [Test]
    public void TestAdditionOperator_WithBoundedNumber()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        BoundedNumber<int> result = boundedNumber + new BoundedNumber<int>(2, 1, 3);
        Assert.That(result.Value, Is.EqualTo(9));
    }

    [Test]
    public void TestSubtractionOperator()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        BoundedNumber<int> result = boundedNumber - 2;
        Assert.That(result.Value, Is.EqualTo(5));
    }

    [Test]
    public void TestMultiplicationOperator()
    {
        BoundedNumber<int> boundedNumber = new(3, 1, 10);
        BoundedNumber<int> result = boundedNumber * 2;
        Assert.That(result.Value, Is.EqualTo(6));
    }

    [Test]
    public void TestDivisionOperator()
    {
        BoundedNumber<int> boundedNumber = new(8, 1, 10);
        BoundedNumber<int> result = boundedNumber / 2;
        Assert.That(result.Value, Is.EqualTo(4));
    }

    [Test]
    public void TestModulusOperator()
    {
        BoundedNumber<int> boundedNumber = new(8, 1, 10);
        BoundedNumber<int> result = boundedNumber % 3;
        Assert.That(result.Value, Is.EqualTo(2));
    }

    [Test]
    public void TestIncrementOperator()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        BoundedNumber<int> result = ++boundedNumber;
        Assert.That(result.Value, Is.EqualTo(8));
    }

    [Test]
    public void TestDecrementOperator()
    {
        BoundedNumber<int> boundedNumber = new(7, 5, 10);
        BoundedNumber<int> result = --boundedNumber;
        Assert.That(result.Value, Is.EqualTo(6));
    }

    [Test]
    public void TestEqualityOperator()
    {
        BoundedNumber<int> boundedNumber1 = new(7, 5, 10);
        BoundedNumber<int> boundedNumber2 = new(7, 5, 10);
        Assert.That(boundedNumber1 == boundedNumber2, Is.True);
    }

    [Test]
    public void TestInequalityOperator()
    {
        BoundedNumber<int> boundedNumber1 = new(7, 5, 10);
        BoundedNumber<int> boundedNumber2 = new(8, 5, 10);
        Assert.That(boundedNumber1 != boundedNumber2, Is.True);
    }

    [Test]
    public void TestLessThanOperator()
    {
        BoundedNumber<int> boundedNumber1 = new(7, 5, 10);
        BoundedNumber<int> boundedNumber2 = new(8, 5, 10);
        Assert.That(boundedNumber1 < boundedNumber2, Is.True);
    }

    [Test]
    public void TestLessThanOrEqualOperator()
    {
        BoundedNumber<int> boundedNumber1 = new(7, 5, 10);
        BoundedNumber<int> boundedNumber2 = new(7, 5, 10);
        Assert.That(boundedNumber1 <= boundedNumber2, Is.True);
    }

    [Test]
    public void TestGreaterThanOperator()
    {
        BoundedNumber<int> boundedNumber1 = new(8, 5, 10);
        BoundedNumber<int> boundedNumber2 = new(7, 5, 10);
        Assert.That(boundedNumber1 > boundedNumber2, Is.True);
    }

    [Test]
    public void TestGreaterThanOrEqualOperator()
    {
        BoundedNumber<int> boundedNumber1 = new(7, 5, 10);
        BoundedNumber<int> boundedNumber2 = new(7, 5, 10);
        Assert.That(boundedNumber1 >= boundedNumber2, Is.True);
    }
}
