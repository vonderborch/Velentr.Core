using System.Runtime.CompilerServices;

namespace Velentr.Core.Mathematics.Geometry;

/// <summary>
///     Provides mathematical methods for geometry-related calculations.
/// </summary>
public static class GeometryMath
{
    /// <summary>
    ///     Converts an angle from degrees to radians.
    /// </summary>
    /// <param name="degrees">The angle in degrees.</param>
    /// <returns>The angle in radians.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double DegreesToRadians(double degrees)
    {
        return degrees * GeometryConstants.Pi / GeometryConstants.HalfDegrees;
    }

    /// <summary>
    ///     Converts an angle from degrees to radians.
    /// </summary>
    /// <param name="degrees">The angle in degrees.</param>
    /// <returns>The angle in radians.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float DegreesToRadians(float degrees)
    {
        return (float)DegreesToRadians((double)degrees);
    }

    /// <summary>
    ///     Converts an angle from radians to degrees.
    /// </summary>
    /// <param name="radians">The angle in radians.</param>
    /// <returns>The angle in degrees.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double RadiansToDegrees(double radians)
    {
        return radians * GeometryConstants.HalfDegrees / GeometryConstants.Pi;
    }

    /// <summary>
    ///     Converts an angle from radians to degrees.
    /// </summary>
    /// <param name="radians">The angle in radians.</param>
    /// <returns>The angle in degrees.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float RadiansToDegrees(float radians)
    {
        return (float)RadiansToDegrees((double)radians);
    }
}
