using NUnit.Framework;
using Velentr.Core.Mathematics.Geometry;
using Microsoft.Xna.Framework;

namespace Velentr.Core.Test.Mathematics.Geometry;

[TestFixture]
public class TestAngleExtensions
{
    [Test]
    public void TestGetTransformationMatrixFromAngle()
    {
        Angle angle = Angle.FromDegrees(90.0);
        Matrix expectedMatrix = Matrix.CreateFromAxisAngle(Vector3.Zero, (float)angle.Radians);
        Matrix resultMatrix = angle.GetTransformationMatrix();
        Assert.That(resultMatrix, Is.EqualTo(expectedMatrix));
    }

    [Test]
    public void TestGetTransformationMatrixFromAngleAndAxis()
    {
        Angle angle = Angle.FromDegrees(90.0);
        Vector3 axis = new Vector3(1, 0, 0);
        Matrix expectedMatrix = Matrix.CreateFromAxisAngle(axis, (float)angle.Radians);
        Matrix resultMatrix = angle.GetTransformationMatrix(axis);
        Assert.That(resultMatrix, Is.EqualTo(expectedMatrix));
    }

    [Test]
    public void TestGetTransformationMatrixFromAngleAndCoordinates()
    {
        Angle angle = Angle.FromDegrees(90.0);
        Vector2 coordinates = new Vector2(1, 0);
        Vector3 axis = new Vector3(coordinates.X, coordinates.Y, 0);
        Matrix expectedMatrix = Matrix.CreateFromAxisAngle(axis, (float)angle.Radians);
        Matrix resultMatrix = angle.GetTransformationMatrix(coordinates);
        Assert.That(resultMatrix, Is.EqualTo(expectedMatrix));
    }

    [Test]
    public void TestGetTransformationMatrixFromAngleAndDoubleCoordinates()
    {
        Angle angle = Angle.FromDegrees(90.0);
        double x = 1.0;
        double y = 0.0;
        Vector3 axis = new Vector3((float)x, (float)y, 0);
        Matrix expectedMatrix = Matrix.CreateFromAxisAngle(axis, (float)angle.Radians);
        Matrix resultMatrix = angle.GetTransformationMatrix(x, y);
        Assert.That(resultMatrix, Is.EqualTo(expectedMatrix));
    }

    [Test]
    public void TestGetTransformationMatrixFromAngleAndIntCoordinates()
    {
        Angle angle = Angle.FromDegrees(90.0);
        int x = 1;
        int y = 0;
        Vector3 axis = new Vector3(x, y, 0);
        Matrix expectedMatrix = Matrix.CreateFromAxisAngle(axis, (float)angle.Radians);
        Matrix resultMatrix = angle.GetTransformationMatrix(x, y);
        Assert.That(resultMatrix, Is.EqualTo(expectedMatrix));
    }
}