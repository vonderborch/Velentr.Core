using System;
using System.Diagnostics;
using System.Drawing;

using Velentr.Core.Helpers.Math;

namespace Velentr.Core.Shapes
{
    /// <summary>
    ///     A point in a 2D space.
    /// </summary>
    [DebuggerDisplay("({X}, {Y})")]
    public struct Point
    {
        /// <summary>
        ///     (Immutable) the default precision.
        /// </summary>
        public static readonly double DefaultPrecision = 0.0000001;

        /// <summary>
        ///     (Immutable) the zero.
        /// </summary>
        public static readonly Point Zero = new(0, 0);

        /// <summary>
        ///     (Immutable) the maximum point.
        /// </summary>
        public static readonly Point MaxValue = new(double.MaxValue, double.MaxValue);

        /// <summary>
        ///     (Immutable) the minimum point.
        /// </summary>
        public static readonly Point MinValue = new(double.MinValue, double.MinValue);

        /// <summary>
        ///     (Immutable) the one.
        /// </summary>
        public static readonly Point One = new(1, 1);

        /// <summary>
        ///     The X coordinate.
        /// </summary>
        public double X;

        /// <summary>
        ///     The Y coordinate.
        /// </summary>
        public double Y;

        /// <summary>
        ///     The precision.
        /// </summary>
        public double Precision;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="precision">    (Optional) The precision. </param>
        public Point(double x, double y, double? precision = null)
        {
            this.X = x;
            this.Y = y;
            this.Precision = precision ?? DefaultPrecision;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="precision">    (Optional) The precision. </param>
        public Point(int x, int y, double? precision = null)
        {
            this.X = x;
            this.Y = y;
            this.Precision = precision ?? DefaultPrecision;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="precision">    (Optional) The precision. </param>
        public Point(float x, float y, double? precision = null)
        {
            this.X = x;
            this.Y = y;
            this.Precision = precision ?? DefaultPrecision;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="precision">    (Optional) The precision. </param>
        public Point(long x, long y, double? precision = null)
        {
            this.X = x;
            this.Y = y;
            this.Precision = precision ?? DefaultPrecision;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="value">        The value. </param>
        /// <param name="precision">    (Optional) The precision. </param>
        public Point(double value, double? precision = null)
        {
            this.X = value;
            this.Y = value;
            this.Precision = precision ?? DefaultPrecision;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="value">        The value. </param>
        /// <param name="precision">    (Optional) The precision. </param>
        public Point(int value, double? precision = null)
        {
            this.X = value;
            this.Y = value;
            this.Precision = precision ?? DefaultPrecision;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="value">        The value. </param>
        /// <param name="precision">    (Optional) The precision. </param>
        public Point(float value, double? precision = null)
        {
            this.X = value;
            this.Y = value;
            this.Precision = precision ?? DefaultPrecision;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="value">        The value. </param>
        /// <param name="precision">    (Optional) The precision. </param>
        public Point(long value, double? precision = null)
        {
            this.X = value;
            this.Y = value;
            this.Precision = precision ?? DefaultPrecision;
        }

        /// <summary>
        ///     Copy constructor.
        /// </summary>
        /// <param name="point">    The point. </param>
        public Point(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
            this.Precision = point.Precision;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="point">        The point. </param>
        /// <param name="precision">    (Optional) The precision. </param>
        public Point(System.Drawing.Point point, double? precision = null)
        {
            this.X = point.X;
            this.Y = point.Y;
            this.Precision = precision ?? DefaultPrecision;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="point">        The point. </param>
        /// <param name="precision">    (Optional) The precision. </param>
        public Point(PointF point, double? precision = null)
        {
            this.X = point.X;
            this.Y = point.Y;
            this.Precision = precision ?? DefaultPrecision;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Point operator +(Point value1, Point value2)
        {
            return new Point(value1.X + value2.X, value1.Y + value2.Y);
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Point operator -(Point value1, Point value2)
        {
            return new Point(value1.X - value2.X, value1.Y - value2.Y);
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="value1">   The first value to multiply. </param>
        /// <param name="value2">   The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Point operator *(Point value1, Point value2)
        {
            return new Point(value1.X * value2.X, value1.Y * value2.Y);
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="value1">   The numerator. </param>
        /// <param name="value2">   The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Point operator /(Point value1, Point value2)
        {
            return new Point(value1.X / value2.X, value1.Y / value2.Y);
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="value1">   The first instance to compare. </param>
        /// <param name="value2">   The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(Point value1, Point value2)
        {
            return value1.Equals(value2);
        }

        /// <summary>
        ///     Inequality operator.
        /// </summary>
        /// <param name="value1">   The first instance to compare. </param>
        /// <param name="value2">   The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator !=(Point value1, Point value2)
        {
            return !value1.Equals(value2);
        }

        /// <summary>
        ///     Implicit cast that converts the given Point to a Point.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator System.Drawing.Point(Point point)
        {
            return new System.Drawing.Point((int) point.X, (int) point.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given Point to a PointF.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator PointF(Point point)
        {
            return new PointF((float) point.X, (float) point.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given Point to a string.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator string(Point point)
        {
            return point.ToString();
        }

        /// <summary>
        ///     Implicit cast that converts the given System.Drawing.Point to a Point.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Point(System.Drawing.Point point)
        {
            return new Point(point.X, point.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given PointF to a Point.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Point(PointF point)
        {
            return new Point(point.X, point.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given IntPoint to a Point.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Point(PointI point)
        {
            return new Point(point.X, point.Y);
        }

        #if (MONOGAME || FNA)
        /// <summary>
        ///     Implicit cast that converts the given Microsoft.Xna.Framework.Point to a Point.
        /// </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Point(Microsoft.Xna.Framework.Point point)
        {
            return new Point(point.X, point.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given Point to a Microsoft.Xna.Framework.Point.
        /// </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Microsoft.Xna.Framework.Point(Point point)
        {
            return new Microsoft.Xna.Framework.Point(point.IntX, point.IntY);
        }

        /// <summary>
        ///     Implicit cast that converts the given Microsoft.Xna.Framework.Vector2 to a Point.
        /// </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Point(Microsoft.Xna.Framework.Vector2 vector)
        {
            return new Point(vector.X, vector.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given Point to a Microsoft.Xna.Framework.Vector2.
        /// </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Microsoft.Xna.Framework.Vector2(Point point)
        {
            return new Microsoft.Xna.Framework.Vector2((float)point.X, (float)point.Y);
        }

        #endif

        /// <summary>
        ///     Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">  The object to compare with the current instance. </param>
        /// <returns>
        ///     true if <paramref name="obj">obj</paramref> and this instance are the same type and represent
        ///     the same value; otherwise, false.
        /// </returns>
        /// <seealso cref="System.ValueType.Equals(object)" />
        public override bool Equals(object obj)
        {
            return obj is Point && Equals((Point) obj);
        }

        /// <summary>
        ///     Tests if this Point is considered equal to another.
        /// </summary>
        /// <param name="other">    The point to compare to this object. </param>
        /// <returns>
        ///     True if the objects are considered equal, false if they are not.
        /// </returns>
        public bool Equals(Point other)
        {
            return MathHelpers.Equals(this.X, other.X, Math.Max(this.Precision, other.Precision)) && MathHelpers.Equals(this.Y, other.Y, Math.Max(this.Precision, other.Precision));
        }

        /// <summary>
        ///     Gets the int x coordinate.
        /// </summary>
        /// <value>
        ///     The int x coordinate.
        /// </value>
        public int IntX => (int) this.X;

        /// <summary>
        ///     Gets the int y coordinate.
        /// </summary>
        /// <value>
        ///     The int y coordinate.
        /// </value>
        public int IntY => (int) this.Y;

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        /// <seealso cref="System.ValueType.GetHashCode()" />
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

        /// <summary>
        ///     Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        ///     The fully qualified type name.
        /// </returns>
        /// <seealso cref="System.ValueType.ToString()" />
        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }

        /// <summary>
        ///     A type deconstructor that extracts the individual members from this object.
        /// </summary>
        /// <param name="x">    [out] The x coordinate. </param>
        /// <param name="y">    [out] The y coordinate. </param>
        public void Deconstruct(out double x, out double y)
        {
            x = this.X;
            y = this.Y;
        }

        /// <summary>
        ///     A type deconstructor that extracts the individual members from this object.
        /// </summary>
        /// <returns>
        ///     A Tuple.
        /// </returns>
        public (double, double) Deconstruct()
        {
            return (this.X, this.Y);
        }
    }
}
