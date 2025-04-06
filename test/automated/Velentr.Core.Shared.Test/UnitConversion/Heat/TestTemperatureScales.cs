using NUnit.Framework;
using Velentr.Core.UnitConversion.Heat;

namespace Velentr.Core.Test.UnitConversion.Heat
{
    public class TestTemperatureScales
    {
        [TestCase(0, 0)]
        [TestCase(100, 100)]
        [TestCase(-40, -40)]
        public void TestCelsiusToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Celsius.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(100, 100)]
        [TestCase(-40, -40)]
        public void TestCelsiusFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Celsius.FromCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(32, 0)]
        [TestCase(212, 100)]
        [TestCase(-40, -40)]
        public void TestFahrenheitToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Fahrenheit.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 32)]
        [TestCase(100, 212)]
        [TestCase(-40, -40)]
        public void TestFahrenheitFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Fahrenheit.FromCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(273.15, 0)]
        [TestCase(373.15, 100)]
        [TestCase(233.15, -40)]
        public void TestKelvinToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Kelvin.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 273.15)]
        [TestCase(100, 373.15)]
        [TestCase(-40, 233.15)]
        public void TestKelvinFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Kelvin.FromCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(33, 100)]
        [TestCase(-13.2, -40)]
        public void TestNewtonToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Newton.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(100, 33)]
        [TestCase(-40, -13.2)]
        public void TestNewtonFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Newton.FromCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(491.67, 0)]
        [TestCase(671.67, 100)]
        [TestCase(419.67, -40)]
        public void TestRankineToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Rankine.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 491.67)]
        [TestCase(100, 671.67)]
        [TestCase(-40, 419.67)]
        public void TestRankineFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Rankine.FromCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(80, 100)]
        [TestCase(-32, -40)]
        public void TestRéaumurToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Réaumur.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(100, 80)]
        [TestCase(-40, -32)]
        public void TestRéaumurFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Réaumur.FromCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(150, 0)]
        [TestCase(-50, 100)]
        [TestCase(180, -40)]
        public void TestDelisleToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Delisle.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 150)]
        [TestCase(100, -50)]
        [TestCase(-40, 180)]
        public void TestDelisleFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Delisle.FromCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(7.5, 0)]
        [TestCase(60, 100)]
        [TestCase(-31.5, -40)]
        public void TestRømerToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Rømer.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 7.5)]
        [TestCase(100, 60)]
        [TestCase(-40, -31.5)]
        public void TestRømerFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Rømer.FromCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(1, 134)]
        [TestCase(9, 250)]
        [TestCase(0, 120)]
        public void TestGasMarkToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.GasMark.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(134, 1)]
        [TestCase(250, 9)]
        [TestCase(120, 0)]
        public void TestGasMarkFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.GasMark.FromCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(33, 100)]
        [TestCase(-13.2, -40)]
        public void TestLeidenToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Leiden.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(100, 33)]
        [TestCase(-40, -13.2)]
        public void TestLeidenFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Leiden.FromCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(1.416808e-32, 0)]
        [TestCase(1.416808e-30, 100)]
        [TestCase(1.416808e-32 * 233.15, -40)]
        public void TestPlanckToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Planck.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 1.416808e-32)]
        [TestCase(100, 1.416808e-30)]
        [TestCase(-40, 1.416808e-32 * 233.15)]
        public void TestPlanckFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Planck.FromCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(33, 100)]
        [TestCase(-13.2, -40)]
        public void TestWedgwoodToCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Wedgwood.ToCelsius(input), Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(100, 33)]
        [TestCase(-40, -13.2)]
        public void TestWedgwoodFromCelsius(double input, double expected)
        {
            Assert.That(TemperatureScale.Wedgwood.FromCelsius(input), Is.EqualTo(expected));
        }
    }
}
