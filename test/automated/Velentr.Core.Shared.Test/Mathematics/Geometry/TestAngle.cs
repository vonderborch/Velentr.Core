using Velentr.Core.Mathematics.Geometry;

namespace Velentr.Core.Test.Mathematics.Geometry;

[TestFixture]
public class TestAngle
{
    [Test]
    public void TestAngleFromDegrees()
    {
        var degrees = 180.0;
        Angle angle = Angle.FromDegrees(degrees);
        Assert.That(angle.Degrees, Is.EqualTo(degrees).Within(1e-10));
        Assert.That(angle.Radians, Is.EqualTo(GeometryConstants.Pi).Within(1e-10));
    }

    [Test]
    public void TestAngleFromRadians()
    {
        var radians = GeometryConstants.Pi;
        Angle angle = Angle.FromRadians(radians);
        Assert.That(angle.Radians, Is.EqualTo(radians).Within(1e-10));
        Assert.That(angle.Degrees, Is.EqualTo(180.0).Within(1e-10));
    }

    [Test]
    public void TestAngleEquality()
    {
        Angle angle1 = Angle.FromDegrees(180.0);
        Angle angle2 = Angle.FromRadians(GeometryConstants.Pi);
        Assert.That(angle1, Is.EqualTo(angle2));
    }

    [Test]
    public void TestAngleInequality()
    {
        Angle angle1 = Angle.FromDegrees(180.0);
        Angle angle2 = Angle.FromDegrees(90.0);
        Assert.That(angle1, Is.Not.EqualTo(angle2));
    }

    [Test]
    public void TestAngleAddition()
    {
        Angle angle1 = Angle.FromDegrees(90.0);
        Angle angle2 = Angle.FromDegrees(90.0);
        Angle result = angle1 + angle2;
        Assert.That(result.Degrees, Is.EqualTo(180.0).Within(1e-10));
    }

    [Test]
    public void TestAngleSubtraction()
    {
        Angle angle1 = Angle.FromDegrees(180.0);
        Angle angle2 = Angle.FromDegrees(90.0);
        Angle result = angle1 - angle2;
        Assert.That(result.Degrees, Is.EqualTo(90.0).Within(1e-10));
    }

    [Test]
    public void TestAngleMultiplication()
    {
        Angle angle = Angle.FromDegrees(90.0);
        Angle result = angle * 2;
        Assert.That(result.Degrees, Is.EqualTo(180.0).Within(1e-10));
    }

    [Test]
    public void TestAngleDivision()
    {
        Angle angle = Angle.FromDegrees(180.0);
        Angle result = angle / 2;
        Assert.That(result.Degrees, Is.EqualTo(90.0).Within(1e-10));
    }

    [Test]
    public void TestAngleModulus()
    {
        Angle angle = Angle.FromDegrees(190.0);
        Angle result = angle % 180.0;
        Assert.That(result.Degrees, Is.EqualTo(10.0).Within(1e-10));
    }

    [Test]
    public void TestAngleIncrement()
    {
        Angle angle = Angle.FromDegrees(179.0);
        angle++;
        Assert.That(angle.Degrees, Is.EqualTo(180.0).Within(1e-10));
    }

    [Test]
    public void TestAngleDecrement()
    {
        Angle angle = Angle.FromDegrees(181.0);
        angle--;
        Assert.That(angle.Degrees, Is.EqualTo(180.0).Within(1e-10));
    }
}
