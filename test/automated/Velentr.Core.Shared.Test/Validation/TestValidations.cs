using Velentr.Core.Validation;

namespace Velentr.Core.Test.Validation;

[TestFixture]
public class TestValidations
{
    [Test]
    public void TestNotNullCheck_NullString()
    {
        string actual = null;
        var ex = Assert.Throws<ArgumentNullException>(() => Validations.NotNullCheck(actual, "testParam"));
        Assert.That(ex.ParamName, Is.EqualTo("testParam"));
    }

    [Test]
    public void TestNotNullCheck_NonNullString()
    {
        Assert.DoesNotThrow(() => Validations.NotNullCheck("validString", "testParam"));
    }
    
    [Test]
    public void TestNotNullOrEmptyCheck_ValidString()
    {
        Assert.DoesNotThrow(() => Validations.NotNullOrEmptyCheck("valid", "testParam"));
    }

    [Test]
    public void TestNotNullOrEmptyCheck_NullString()
    {
        var ex = Assert.Throws<ArgumentException>(() => Validations.NotNullOrEmptyCheck(null, "testParam"));
        Assert.That(ex.Message, Is.EqualTo("testParam can not be null or empty."));
    }

    [Test]
    public void TestNotNullOrEmptyCheck_EmptyString()
    {
        var ex = Assert.Throws<ArgumentException>(() => Validations.NotNullOrEmptyCheck("", "testParam"));
        Assert.That(ex.Message, Is.EqualTo("testParam can not be null or empty."));
    }

    [Test]
    public void TestNotNullOrWhiteSpaceCheck_ValidString()
    {
        Assert.DoesNotThrow(() => Validations.NotNullOrWhiteSpaceCheck("valid", "testParam"));
    }

    [Test]
    public void TestNotNullOrWhiteSpaceCheck_NullString()
    {
        var ex = Assert.Throws<ArgumentException>(() => Validations.NotNullOrWhiteSpaceCheck(null, "testParam"));
        Assert.That(ex.Message, Is.EqualTo("testParam can not be null, empty, or contain only white space."));
    }

    [Test]
    public void TestNotNullOrWhiteSpaceCheck_EmptyString()
    {
        var ex = Assert.Throws<ArgumentException>(() => Validations.NotNullOrWhiteSpaceCheck("", "testParam"));
        Assert.That(ex.Message, Is.EqualTo("testParam can not be null, empty, or contain only white space."));
    }

    [Test]
    public void TestNotNullOrWhiteSpaceCheck_WhiteSpaceString()
    {
        var ex = Assert.Throws<ArgumentException>(() => Validations.NotNullOrWhiteSpaceCheck("   ", "testParam"));
        Assert.That(ex.Message, Is.EqualTo("testParam can not be null, empty, or contain only white space."));
    }

    [Test]
    public void TestValidateRange_WithinRange()
    {
        Assert.DoesNotThrow(() => Validations.ValidateRange(5, "testParam", 1, 10));
    }

    [Test]
    public void TestValidateRange_EqualToMinValue()
    {
        Assert.DoesNotThrow(() => Validations.ValidateRange(1, "testParam", 1, 10));
    }

    [Test]
    public void TestValidateRange_EqualToMaxValue()
    {
        Assert.DoesNotThrow(() => Validations.ValidateRange(10, "testParam", 1, 10));
    }

    [Test]
    public void TestValidateRange_BelowRange()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Validations.ValidateRange(0, "testParam", 1, 10));
        Assert.That(ex.Message, Is.EqualTo("The parameter [testParam] is out of the range (min: 1, max:10)! (Parameter 'testParam')"));
    }

    [Test]
    public void TestValidateRange_AboveRange()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Validations.ValidateRange(11, "testParam", 1, 10));
        Assert.That(ex.Message, Is.EqualTo("The parameter [testParam] is out of the range (min: 1, max:10)! (Parameter 'testParam')"));
    }

    [Test]
    public void TestValidateRange_MinValueGreaterThanMaxValue()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Validations.ValidateRange(5, "testParam", 10, 1));
        Assert.That(ex.Message, Is.EqualTo("The parameter [testParam] is out of the range (min: 10, max:1)! (Parameter 'testParam')"));
    }
}
