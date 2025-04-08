using System.Diagnostics;
using System.Text.Json.Serialization;
using Velentr.Core.Mathematics.Numerics;

namespace Velentr.Core.Mathematics.Geometry;

/// <summary>
///     Represents an angle with properties and methods for conversion between degrees and radians.
/// </summary>
[DebuggerDisplay("{ToString()}")]
public struct Angle : IEquatable<Angle>
{
    /// <summary>
    ///     Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        return obj is Angle other && Equals(other);
    }

    /// <summary>
    ///     Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.degrees, this.radians);
    }

    /// <summary>
    ///     Represents an angle of zero degrees.
    /// </summary>
    public static readonly Angle Zero = new(0d);

    private CircularBoundedNumber<double> degrees;

    [JsonIgnore] private CircularBoundedNumber<double> radians;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Angle" /> struct with the specified degrees.
    /// </summary>
    /// <param name="degrees">The angle in degrees.</param>
    [JsonConstructor]
    public Angle(double degrees)
    {
        this.degrees =
            new CircularBoundedNumber<double>(degrees, GeometryConstants.MinDegrees, GeometryConstants.MaxDegrees);
        this.radians = new CircularBoundedNumber<double>(degrees * GeometryConstants.Pi / GeometryConstants.HalfDegrees,
            GeometryConstants.ZeroPi, GeometryConstants.TwoPi);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Angle" /> struct with the specified angle.
    /// </summary>
    /// <param name="angle">The angle to copy.</param>
    public Angle(Angle angle) : this(angle.degrees.Value)
    {
    }

    /// <summary>
    ///     Gets or sets the angle in degrees.
    /// </summary>
    [JsonPropertyName("degrees")]
    public double Degrees
    {
        get => this.degrees.Value;
        set
        {
            this.degrees.Value = value;
            this.radians.Value = GeometryMath.DegreesToRadians(value);
        }
    }

    /// <summary>
    ///     Gets or sets the angle in radians.
    /// </summary>
    [JsonIgnore]
    public double Radians
    {
        get => this.radians.Value;
        set
        {
            this.radians.Value = value;
            this.degrees.Value = GeometryMath.RadiansToDegrees(value);
        }
    }

    /// <summary>
    ///     Creates a new <see cref="Angle" /> from the specified degrees.
    /// </summary>
    /// <param name="degrees">The angle in degrees.</param>
    /// <returns>A new <see cref="Angle" /> instance.</returns>
    public static Angle FromDegrees(double degrees)
    {
        return new Angle(degrees);
    }

    /// <summary>
    ///     Creates a new <see cref="Angle" /> from the specified radians.
    /// </summary>
    /// <param name="radians">The angle in radians.</param>
    /// <returns>A new <see cref="Angle" /> instance.</returns>
    public static Angle FromRadians(double radians)
    {
        var degrees = GeometryMath.RadiansToDegrees(radians);
        return new Angle(degrees);
    }

    /// <summary>
    ///     Creates a new <see cref="Angle" /> from the specified angle.
    /// </summary>
    /// <param name="angle">The angle to copy.</param>
    /// <returns>A new <see cref="Angle" /> instance.</returns>
    public static Angle FromAngle(Angle angle)
    {
        return new Angle(angle);
    }

    /// <summary>
    ///     Determines whether two specified instances of <see cref="Angle" /> are equal.
    /// </summary>
    /// <param name="left">The first angle to compare.</param>
    /// <param name="right">The second angle to compare.</param>
    /// <returns>true if the two angles are equal; otherwise, false.</returns>
    public static bool operator ==(Angle left, Angle right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///     Determines whether two specified instances of <see cref="Angle" /> are not equal.
    /// </summary>
    /// <param name="left">The first angle to compare.</param>
    /// <param name="right">The second angle to compare.</param>
    /// <returns>true if the two angles are not equal; otherwise, false.</returns>
    public static bool operator !=(Angle left, Angle right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    ///     Adds two specified <see cref="Angle" /> instances.
    /// </summary>
    /// <param name="left">The first angle to add.</param>
    /// <param name="right">The second angle to add.</param>
    /// <returns>The sum of the two angles.</returns>
    public static Angle operator +(Angle left, Angle right)
    {
        return new Angle(left.Degrees + right.Degrees);
    }

    /// <summary>
    ///     Subtracts one specified <see cref="Angle" /> from another.
    /// </summary>
    /// <param name="left">The angle to subtract from.</param>
    /// <param name="right">The angle to subtract.</param>
    /// <returns>The difference of the two angles.</returns>
    public static Angle operator -(Angle left, Angle right)
    {
        return new Angle(left.Degrees - right.Degrees);
    }

    /// <summary>
    ///     Multiplies two specified <see cref="Angle" /> instances.
    /// </summary>
    /// <param name="left">The first angle to multiply.</param>
    /// <param name="right">The second angle to multiply.</param>
    /// <returns>The product of the two angles.</returns>
    public static Angle operator *(Angle left, Angle right)
    {
        return new Angle(left.Degrees * right.Degrees);
    }

    /// <summary>
    ///     Divides one specified <see cref="Angle" /> by another.
    /// </summary>
    /// <param name="left">The angle to divide.</param>
    /// <param name="right">The angle to divide by.</param>
    /// <returns>The quotient of the two angles.</returns>
    public static Angle operator /(Angle left, Angle right)
    {
        return new Angle(left.Degrees / right.Degrees);
    }

    /// <summary>
    ///     Computes the remainder of dividing one specified <see cref="Angle" /> by another.
    /// </summary>
    /// <param name="left">The angle to divide.</param>
    /// <param name="right">The angle to divide by.</param>
    /// <returns>The remainder of the division.</returns>
    public static Angle operator %(Angle left, Angle right)
    {
        return new Angle(left.Degrees % right.Degrees);
    }

    /// <summary>
    ///     Increments the specified <see cref="Angle" /> by one degree.
    /// </summary>
    /// <param name="angle">The angle to increment.</param>
    /// <returns>The incremented angle.</returns>
    public static Angle operator ++(Angle angle)
    {
        return new Angle(angle.Degrees + 1);
    }

    /// <summary>
    ///     Multiplies the specified <see cref="Angle" /> instance by an amount.
    /// </summary>
    /// <param name="angle">The first angle to multiply.</param>
    /// <param name="amount">The second angle to multiply.</param>
    /// <returns>The product.</returns>
    public static Angle operator *(Angle angle, double amount)
    {
        return new Angle(angle.Degrees * amount);
    }

    /// <summary>
    ///     Divides one specified <see cref="Angle" /> by an amount.
    /// </summary>
    /// <param name="angle">The angle to divide.</param>
    /// <param name="amount">The angle to divide by.</param>
    /// <returns>The quotient.</returns>
    public static Angle operator /(Angle angle, double amount)
    {
        return new Angle(angle.Degrees / amount);
    }

    /// <summary>
    ///     Computes the remainder of dividing one specified <see cref="Angle" /> by an amount.
    /// </summary>
    /// <param name="angle">The angle to divide.</param>
    /// <param name="amount">The angle to divide by.</param>
    /// <returns>The remainder of the division.</returns>
    public static Angle operator %(Angle angle, double amount)
    {
        return new Angle(angle.Degrees % amount);
    }

    /// <summary>
    ///     Decrements the specified <see cref="Angle" /> by one degree.
    /// </summary>
    /// <param name="angle">The angle to decrement.</param>
    /// <returns>The decremented angle.</returns>
    public static Angle operator --(Angle angle)
    {
        return new Angle(angle.Degrees - 1);
    }

    /// <summary>
    ///     Adds the specified degrees to the specified angle.
    /// </summary>
    /// <param name="degrees">The degrees to add.</param>
    /// <returns>The resulting angle.</returns>
    public Angle AddDegrees(double degrees)
    {
        return new Angle(this.Degrees + degrees);
    }

    /// <summary>
    ///     Adds the specified degrees to the current angle.
    /// </summary>
    /// <param name="degrees">The degrees to add.</param>
    public void AddDegreesToSelf(double degrees)
    {
        this.Degrees += degrees;
    }

    /// <summary>
    ///     Subtracts the specified degrees from the current angle.
    /// </summary>
    /// <param name="degrees">The degrees to subtract.</param>
    public void SubtractDegreesToSelf(double degrees)
    {
        this.Degrees -= degrees;
    }

    /// <summary>
    ///     Multiplies the current angle by the specified degrees.
    /// </summary>
    /// <param name="degrees">The degrees to multiply by.</param>
    public void MultiplyDegreesToSelf(double degrees)
    {
        this.Degrees *= degrees;
    }

    /// <summary>
    ///     Divides the current angle by the specified degrees.
    /// </summary>
    /// <param name="degrees">The degrees to divide by.</param>
    public void DivideDegreesToSelf(double degrees)
    {
        this.Degrees /= degrees;
    }

    /// <summary>
    ///     Computes the remainder of dividing the current angle by the specified degrees.
    /// </summary>
    /// <param name="degrees">The degrees to divide by.</param>
    public void ModulusDegreesToSelf(double degrees)
    {
        this.Degrees %= degrees;
    }

    /// <summary>
    ///     Subtracts the specified degrees from the specified angle.
    /// </summary>
    /// <param name="degrees">The degrees to subtract.</param>
    /// <returns>The resulting angle.</returns>
    public Angle SubtractDegrees(double degrees)
    {
        return new Angle(this.Degrees - degrees);
    }

    /// <summary>
    ///     Multiplies the specified angle by the specified degrees.
    /// </summary>
    /// <param name="degrees">The degrees to multiply by.</param>
    /// <returns>The resulting angle.</returns>
    public Angle MultiplyDegrees(double degrees)
    {
        return new Angle(this.Degrees * degrees);
    }

    /// <summary>
    ///     Divides the specified angle by the specified degrees.
    /// </summary>
    /// <param name="degrees">The degrees to divide by.</param>
    /// <returns>The resulting angle.</returns>
    public Angle DivideDegrees(double degrees)
    {
        return new Angle(this.Degrees / degrees);
    }

    /// <summary>
    ///     Computes the remainder of dividing the specified angle by the specified degrees.
    /// </summary>
    /// <param name="degrees">The degrees to divide by.</param>
    /// <returns>The resulting angle.</returns>
    public Angle ModulusDegrees(double degrees)
    {
        return new Angle(this.Degrees % degrees);
    }

    /// <summary>
    ///     Adds the specified radians to the specified angle.
    /// </summary>
    /// <param name="radians">The radians to add.</param>
    /// <returns>The resulting angle.</returns>
    public Angle AddRadians(double radians)
    {
        return FromRadians(this.Radians + radians);
    }

    /// <summary>
    ///     Adds the specified radians to the current angle.
    /// </summary>
    /// <param name="radians">The radians to add.</param>
    public void AddRadiansToSelf(double radians)
    {
        this.Radians += radians;
    }

    /// <summary>
    ///     Subtracts the specified radians from the current angle.
    /// </summary>
    /// <param name="radians">The radians to subtract.</param>
    public void SubtractRadiansToSelf(double radians)
    {
        this.Radians -= radians;
    }

    /// <summary>
    ///     Multiplies the current angle by the specified radians.
    /// </summary>
    /// <param name="radians">The radians to multiply by.</param>
    public void MultiplyRadiansToSelf(double radians)
    {
        this.Radians *= radians;
    }

    /// <summary>
    ///     Divides the current angle by the specified radians.
    /// </summary>
    /// <param name="radians">The radians to divide by.</param>
    public void DivideRadiansToSelf(double radians)
    {
        this.Radians /= radians;
    }

    /// <summary>
    ///     Computes the remainder of dividing the current angle by the specified radians.
    /// </summary>
    /// <param name="radians">The radians to divide by.</param>
    public void ModulusRadiansToSelf(double radians)
    {
        this.Radians %= radians;
    }

    /// <summary>
    ///     Subtracts the specified radians from the specified angle.
    /// </summary>
    /// <param name="radians">The radians to subtract.</param>
    /// <returns>The resulting angle.</returns>
    public Angle SubtractRadians(double radians)
    {
        return FromRadians(this.Radians - radians);
    }

    /// <summary>
    ///     Multiplies the specified angle by the specified radians.
    /// </summary>
    /// <param name="radians">The radians to multiply by.</param>
    /// <returns>The resulting angle.</returns>
    public Angle MultiplyRadians(double radians)
    {
        return FromRadians(this.Radians * radians);
    }

    /// <summary>
    ///     Divides the specified angle by the specified radians.
    /// </summary>
    /// <param name="radians">The radians to divide by.</param>
    /// <returns>The resulting angle.</returns>
    public Angle DivideRadians(double radians)
    {
        return FromRadians(this.Radians / radians);
    }

    /// <summary>
    ///     Computes the remainder of dividing the specified angle by the specified radians.
    /// </summary>
    /// <param name="radians">The radians to divide by.</param>
    /// <returns>The resulting angle.</returns>
    public Angle ModulusRadians(double radians)
    {
        return FromRadians(this.Radians % radians);
    }

    /// <summary>
    ///     Converts the angle to degrees.
    /// </summary>
    /// <returns>The angle in degrees.</returns>
    public double ToDegrees()
    {
        return this.degrees.Value;
    }

    /// <summary>
    ///     Converts the angle to radians.
    /// </summary>
    /// <returns>The angle in radians.</returns>
    public double ToRadians()
    {
        return this.radians.Value;
    }

    /// <summary>
    ///     Determines whether the specified <see cref="Angle" /> is equal to the current <see cref="Angle" />.
    /// </summary>
    /// <param name="other">The angle to compare with the current angle.</param>
    /// <returns>true if the specified angle is equal to the current angle; otherwise, false.</returns>
    public bool Equals(Angle other)
    {
        return this.Degrees.Equals(other.Degrees);
    }
}
