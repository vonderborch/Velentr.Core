using NUnit.Framework;
using Velentr.Core.Mathematics.Geometry;

namespace Velentr.Core.Test.Mathematics.Geometry;

[TestFixture]
public class TestGeometryMath
{
    [Test]
    public void TestDegreesToRadians_Double()
    {
        double degrees = 180.0;
        double expectedRadians = GeometryConstants.Pi;
        double actualRadians = GeometryMath.DegreesToRadians(degrees);
        Assert.That(actualRadians, Is.EqualTo(expectedRadians).Within(1e-10));
    }

    [Test]
    public void TestDegreesToRadians_Float()
    {
        float degrees = 180.0f;
        float expectedRadians = (float)GeometryConstants.Pi;
        float actualRadians = GeometryMath.DegreesToRadians(degrees);
        Assert.That(actualRadians, Is.EqualTo(expectedRadians).Within(1e-6f));
    }

    [Test]
    public void TestRadiansToDegrees_Double()
    {
        double radians = GeometryConstants.Pi;
        double expectedDegrees = 180.0;
        double actualDegrees = GeometryMath.RadiansToDegrees(radians);
        Assert.That(actualDegrees, Is.EqualTo(expectedDegrees).Within(1e-10));
    }

    [Test]
    public void TestRadiansToDegrees_Float()
    {
        float radians = (float)GeometryConstants.Pi;
        float expectedDegrees = 180.0f;
        float actualDegrees = GeometryMath.RadiansToDegrees(radians);
        Assert.That(actualDegrees, Is.EqualTo(expectedDegrees).Within(1e-6f));
    }
}