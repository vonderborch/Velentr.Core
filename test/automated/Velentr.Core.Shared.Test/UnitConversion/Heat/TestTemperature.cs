using NUnit.Framework;
using Velentr.Core.UnitConversion.Heat;

namespace Velentr.Core.Test.UnitConversion.Heat;

public class TestTemperature
{
    [Test]
    public void TestTemperatureInitialization()
    {
        var temp = new Temperature(100, TemperatureScale.Celsius);
        Assert.That(temp.Value, Is.EqualTo(100));
        Assert.That(temp.Scale, Is.EqualTo(TemperatureScale.Celsius));
    }

    [Test]
    public void TestTemperatureConversion()
    {
        var tempCelsius = new Temperature(100, TemperatureScale.Celsius);
        var tempFahrenheit = tempCelsius.ToScale(TemperatureScale.Fahrenheit);
        Assert.That(tempFahrenheit.Value, Is.EqualTo(212).Within(0.01));
        Assert.That(tempFahrenheit.Scale, Is.EqualTo(TemperatureScale.Fahrenheit));
    }

    [Test]
    public void TestTemperatureEquality()
    {
        var temp1 = new Temperature(100, TemperatureScale.Celsius);
        var temp2 = new Temperature(100, TemperatureScale.Celsius);
        Assert.That(temp1, Is.EqualTo(temp2));
    }

    [Test]
    public void TestTemperatureInequality()
    {
        var temp1 = new Temperature(100, TemperatureScale.Celsius);
        var temp2 = new Temperature(212, TemperatureScale.Fahrenheit);
        Assert.That(temp1, Is.Not.EqualTo(temp2));
    }

    [Test]
    public void TestTemperatureAddition()
    {
        var temp1 = new Temperature(100, TemperatureScale.Celsius);
        var temp2 = new Temperature(100, TemperatureScale.Celsius);
        var result = temp1 + temp2;
        Assert.That(result.Value, Is.EqualTo(200));
        Assert.That(result.Scale, Is.EqualTo(TemperatureScale.Celsius));
    }

    [Test]
    public void TestTemperatureSubtraction()
    {
        var temp1 = new Temperature(100, TemperatureScale.Celsius);
        var temp2 = new Temperature(50, TemperatureScale.Celsius);
        var result = temp1 - temp2;
        Assert.That(result.Value, Is.EqualTo(50));
        Assert.That(result.Scale, Is.EqualTo(TemperatureScale.Celsius));
    }

    [Test]
    public void TestTemperatureMultiplication()
    {
        var temp = new Temperature(100, TemperatureScale.Celsius);
        var result = temp * 2;
        Assert.That(result.Value, Is.EqualTo(200));
        Assert.That(result.Scale, Is.EqualTo(TemperatureScale.Celsius));
    }

    [Test]
    public void TestTemperatureDivision()
    {
        var temp = new Temperature(100, TemperatureScale.Celsius);
        var result = temp / 2;
        Assert.That(result.Value, Is.EqualTo(50));
        Assert.That(result.Scale, Is.EqualTo(TemperatureScale.Celsius));
    }
}
