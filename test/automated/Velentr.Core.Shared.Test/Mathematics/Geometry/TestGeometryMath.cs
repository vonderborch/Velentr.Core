using Velentr.Core.Mathematics.Geometry;

namespace Velentr.Core.Test.Mathematics.Geometry;

[TestFixture]
public class TestGeometryMath
{
    [Test]
    public void TestDegreesToRadians_Double()
    {
        var degrees = 180.0;
        var expectedRadians = GeometryConstants.Pi;
        var actualRadians = GeometryMath.DegreesToRadians(degrees);
        Assert.That(actualRadians, Is.EqualTo(expectedRadians).Within(1e-10));
    }

    [Test]
    public void TestDegreesToRadians_Float()
    {
        var degrees = 180.0f;
        var expectedRadians = (float)GeometryConstants.Pi;
        var actualRadians = GeometryMath.DegreesToRadians(degrees);
        Assert.That(actualRadians, Is.EqualTo(expectedRadians).Within(1e-6f));
    }

    [Test]
    public void TestRadiansToDegrees_Double()
    {
        var radians = GeometryConstants.Pi;
        var expectedDegrees = 180.0;
        var actualDegrees = GeometryMath.RadiansToDegrees(radians);
        Assert.That(actualDegrees, Is.EqualTo(expectedDegrees).Within(1e-10));
    }

    [Test]
    public void TestRadiansToDegrees_Float()
    {
        var radians = (float)GeometryConstants.Pi;
        var expectedDegrees = 180.0f;
        var actualDegrees = GeometryMath.RadiansToDegrees(radians);
        Assert.That(actualDegrees, Is.EqualTo(expectedDegrees).Within(1e-6f));
    }
}
