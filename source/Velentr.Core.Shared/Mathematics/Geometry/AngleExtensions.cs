using Microsoft.Xna.Framework;

namespace Velentr.Core.Mathematics.Geometry;

/// <summary>
///     Provides extension methods for the <see cref="Angle" /> struct to create transformation matrices.
/// </summary>
public static class AngleExtensions
{
    /// <summary>
    ///     Creates a transformation matrix from the specified angle.
    /// </summary>
    /// <param name="angle">The angle to create the transformation matrix from.</param>
    /// <returns>A transformation matrix representing the rotation by the specified angle.</returns>
    public static Matrix GetTransformationMatrix(this Angle angle)
    {
        Matrix output = Matrix.CreateFromAxisAngle(Vector3.Zero, (float)angle.Radians);
        return output;
    }

    /// <summary>
    ///     Creates a transformation matrix from the specified angle and axis.
    /// </summary>
    /// <param name="angle">The angle to create the transformation matrix from.</param>
    /// <param name="axis">The axis to rotate around.</param>
    /// <returns>A transformation matrix representing the rotation by the specified angle around the specified axis.</returns>
    public static Matrix GetTransformationMatrix(this Angle angle, Vector3 axis)
    {
        Matrix output = Matrix.CreateFromAxisAngle(axis, (float)angle.Radians);
        return output;
    }

    /// <summary>
    ///     Creates a transformation matrix from the specified angle and 2D coordinates.
    /// </summary>
    /// <param name="angle">The angle to create the transformation matrix from.</param>
    /// <param name="coordinates">The 2D coordinates to define the axis of rotation.</param>
    /// <returns>
    ///     A transformation matrix representing the rotation by the specified angle around the axis defined by the 2D
    ///     coordinates.
    /// </returns>
    public static Matrix GetTransformationMatrix(this Angle angle, Vector2 coordinates)
    {
        Vector3 axis = new(coordinates.X, coordinates.Y, 0);
        return GetTransformationMatrix(angle, axis);
    }

    /// <summary>
    ///     Creates a transformation matrix from the specified angle and 2D coordinates.
    /// </summary>
    /// <param name="angle">The angle to create the transformation matrix from.</param>
    /// <param name="x">The X coordinate to define the axis of rotation.</param>
    /// <param name="y">The Y coordinate to define the axis of rotation.</param>
    /// <returns>
    ///     A transformation matrix representing the rotation by the specified angle around the axis defined by the 2D
    ///     coordinates.
    /// </returns>
    public static Matrix GetTransformationMatrix(this Angle angle, double x, double y)
    {
        Vector3 axis = new((float)x, (float)y, 0);
        return GetTransformationMatrix(angle, axis);
    }

    /// <summary>
    ///     Creates a transformation matrix from the specified angle and 2D coordinates.
    /// </summary>
    /// <param name="angle">The angle to create the transformation matrix from.</param>
    /// <param name="x">The X coordinate to define the axis of rotation.</param>
    /// <param name="y">The Y coordinate to define the axis of rotation.</param>
    /// <returns>
    ///     A transformation matrix representing the rotation by the specified angle around the axis defined by the 2D
    ///     coordinates.
    /// </returns>
    public static Matrix GetTransformationMatrix(this Angle angle, int x, int y)
    {
        Vector3 axis = new(x, y, 0);
        return GetTransformationMatrix(angle, axis);
    }
}
