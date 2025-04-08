using Velentr.Core.Mathematics.Numerics;

namespace Velentr.Core.Test.Mathematics.Numerics;

[TestFixture]
public class TestCircularBoundedNumber
{
    [Test]
    public void TestCircularBoundedNumberInitialization()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(7, 5, 10);
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(7));
        Assert.That(circularBoundedNumber.Minimum, Is.EqualTo(5));
        Assert.That(circularBoundedNumber.Maximum, Is.EqualTo(10));
    }

    [Test]
    public void TestCircularBoundedNumberInitializationWithClamping()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(11, 5, 10);
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(6));
    }

    [Test]
    public void TestSetMinimum()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(7, 5, 10);
        circularBoundedNumber.Minimum = 6;
        Assert.That(circularBoundedNumber.Minimum, Is.EqualTo(6));
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(7));
    }

    [Test]
    public void TestSetMaximum()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(7, 5, 10);
        circularBoundedNumber.Maximum = 12;
        Assert.That(circularBoundedNumber.Maximum, Is.EqualTo(12));
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(7));
    }

    [Test]
    public void TestSetValue()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(7, 5, 10);
        circularBoundedNumber.Value = 9;
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(9));
    }

    [Test]
    public void TestSetValueWithClamping()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(7, 5, 10);
        circularBoundedNumber.Value = 11;
        Assert.That(circularBoundedNumber.Value, Is.EqualTo(6));
    }

    [Test]
    public void TestAdditionOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(7, 5, 10);
        CircularBoundedNumber<int> result = circularBoundedNumber + 5;
        Assert.That(result.Value, Is.EqualTo(7));
    }

    [Test]
    public void TestSubtractionOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(7, 5, 10);
        CircularBoundedNumber<int> result = circularBoundedNumber - 3;
        Assert.That(result.Value, Is.EqualTo(9));
    }

    [Test]
    public void TestMultiplicationOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(3, 1, 10);
        CircularBoundedNumber<int> result = circularBoundedNumber * 4;
        Assert.That(result.Value, Is.EqualTo(4));
    }

    [Test]
    public void TestDivisionOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(8, 1, 10);
        CircularBoundedNumber<int> result = circularBoundedNumber / 2;
        Assert.That(result.Value, Is.EqualTo(4));
    }

    [Test]
    public void TestModulusOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(8, 1, 10);
        CircularBoundedNumber<int> result = circularBoundedNumber % 3;
        Assert.That(result.Value, Is.EqualTo(2));
    }

    [Test]
    public void TestIncrementOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(7, 5, 10);
        CircularBoundedNumber<int> result = ++circularBoundedNumber;
        Assert.That(result.Value, Is.EqualTo(8));
    }

    [Test]
    public void TestDecrementOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber = new(7, 5, 10);
        CircularBoundedNumber<int> result = --circularBoundedNumber;
        Assert.That(result.Value, Is.EqualTo(6));
    }

    [Test]
    public void TestEqualityOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber1 = new(7, 5, 10);
        CircularBoundedNumber<int> circularBoundedNumber2 = new(7, 5, 10);
        Assert.That(circularBoundedNumber1 == circularBoundedNumber2, Is.True);
    }

    [Test]
    public void TestInequalityOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber1 = new(7, 5, 10);
        CircularBoundedNumber<int> circularBoundedNumber2 = new(8, 5, 10);
        Assert.That(circularBoundedNumber1 != circularBoundedNumber2, Is.True);
    }

    [Test]
    public void TestLessThanOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber1 = new(7, 5, 10);
        CircularBoundedNumber<int> circularBoundedNumber2 = new(8, 5, 10);
        Assert.That(circularBoundedNumber1 < circularBoundedNumber2, Is.True);
    }

    [Test]
    public void TestLessThanOrEqualOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber1 = new(7, 5, 10);
        CircularBoundedNumber<int> circularBoundedNumber2 = new(7, 5, 10);
        Assert.That(circularBoundedNumber1 <= circularBoundedNumber2, Is.True);
    }

    [Test]
    public void TestGreaterThanOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber1 = new(8, 5, 10);
        CircularBoundedNumber<int> circularBoundedNumber2 = new(7, 5, 10);
        Assert.That(circularBoundedNumber1 > circularBoundedNumber2, Is.True);
    }

    [Test]
    public void TestGreaterThanOrEqualOperator()
    {
        CircularBoundedNumber<int> circularBoundedNumber1 = new(7, 5, 10);
        CircularBoundedNumber<int> circularBoundedNumber2 = new(7, 5, 10);
        Assert.That(circularBoundedNumber1 >= circularBoundedNumber2, Is.True);
    }
}
