namespace Velentr.Core.Mathematics.Geometry;

/// <summary>
/// Provides commonly used geometric constants (in radians and degrees).
/// </summary>
public static class GeometryConstants
{
    /// <summary>
    /// The ratio of a circle's circumference to its diameter (π).
    /// </summary>
    public const double Pi = Math.PI;

    /// <summary>
    /// Two times π (one full circle in radians).
    /// </summary>
    public const double TwoPi = Math.PI * 2;

    /// <summary>
    /// Half of π (90 degrees in radians).
    /// </summary>
    public const double HalfPi = Math.PI / 2;

    /// <summary>
    /// Quarter of π (45 degrees in radians).
    /// </summary>
    public const double QuarterPi = Math.PI / 4;

    /// <summary>
    /// Zero radians.
    /// </summary>
    public const double ZeroPi = 0d;

    /// <summary>
    /// The minimum degree value (0°).
    /// </summary>
    public const double MinDegrees = 0d;

    /// <summary>
    /// The maximum degree value (360°).
    /// </summary>
    public const double MaxDegrees = 360d;

    /// <summary>
    /// Half of a full circle in degrees (180°).
    /// </summary>
    public const double HalfDegrees = 180d;

    /// <summary>
    /// Quarter of a full circle in degrees (90°).
    /// </summary>
    public const double QuarterDegrees = 90d;
}
