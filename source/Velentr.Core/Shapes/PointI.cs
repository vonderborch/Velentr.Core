using System.Diagnostics;
using System.Drawing;

namespace Velentr.Core.Shapes
{
    /// <summary>
    ///     A point in a 2D space that uses Ints.
    /// </summary>
    [DebuggerDisplay("({X}, {Y})")]
    public struct PointI
    {
        /// <summary>
        ///     (Immutable) the default precision.
        /// </summary>
        public static readonly double DefaultPrecision = 0.0000001;

        /// <summary>
        ///     (Immutable) the zero.
        /// </summary>
        public static readonly PointI Zero = new(0, 0);

        /// <summary>
        ///     (Immutable) the maximum point.
        /// </summary>
        public static readonly PointI MaxValue = new(double.MaxValue, double.MaxValue);

        /// <summary>
        ///     (Immutable) the minimum point.
        /// </summary>
        public static readonly PointI MinValue = new(double.MinValue, double.MinValue);

        /// <summary>
        ///     (Immutable) the one.
        /// </summary>
        public static readonly PointI One = new(1, 1);

        /// <summary>
        ///     The X coordinate.
        /// </summary>
        public int X;

        /// <summary>
        ///     The Y coordinate.
        /// </summary>
        public int Y;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        public PointI(double x, double y)
        {
            this.X = (int) x;
            this.Y = (int) y;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        public PointI(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        public PointI(float x, float y)
        {
            this.X = (int) x;
            this.Y = (int) y;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        public PointI(long x, long y)
        {
            this.X = (int) x;
            this.Y = (int) y;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="value">    The value. </param>
        public PointI(double value)
        {
            this.X = (int) value;
            this.Y = (int) value;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="value">    The value. </param>
        public PointI(int value)
        {
            this.X = value;
            this.Y = value;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="value">    The value. </param>
        public PointI(float value)
        {
            this.X = (int) value;
            this.Y = (int) value;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="value">    The value. </param>
        public PointI(long value)
        {
            this.X = (int) value;
            this.Y = (int) value;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="point">    The point. </param>
        public PointI(Point point)
        {
            this.X = point.IntX;
            this.Y = point.IntY;
        }

        /// <summary>
        ///     Copy constructor.
        /// </summary>
        /// <param name="point">    The point. </param>
        public PointI(PointI point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// ###
        /// <param name="precision">    (Optional) The precision. </param>
        public PointI(System.Drawing.Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// ###
        /// <param name="precision">    (Optional) The precision. </param>
        public PointI(PointF point)
        {
            this.X = (int) point.X;
            this.Y = (int) point.Y;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static PointI operator +(PointI value1, PointI value2)
        {
            return new PointI(value1.X + value2.X, value1.Y + value2.Y);
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static PointI operator -(PointI value1, PointI value2)
        {
            return new PointI(value1.X - value2.X, value1.Y - value2.Y);
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="value1">   The first value to multiply. </param>
        /// <param name="value2">   The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static PointI operator *(PointI value1, PointI value2)
        {
            return new PointI(value1.X * value2.X, value1.Y * value2.Y);
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="value1">   The numerator. </param>
        /// <param name="value2">   The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static PointI operator /(PointI value1, PointI value2)
        {
            return new PointI(value1.X / value2.X, value1.Y / value2.Y);
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="value1">   The first instance to compare. </param>
        /// <param name="value2">   The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(PointI value1, PointI value2)
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
        public static bool operator !=(PointI value1, PointI value2)
        {
            return !value1.Equals(value2);
        }

        /// <summary>
        ///     Implicit cast that converts the given IntPoint to a Point.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator System.Drawing.Point(PointI point)
        {
            return new System.Drawing.Point(point.X, point.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given IntPoint to a PointF.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator PointF(PointI point)
        {
            return new PointF(point.X, point.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given Point to a IntPoint.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator PointI(Point point)
        {
            return new PointI(point.IntX, point.IntY);
        }

        /// <summary>
        ///     Implicit cast that converts the given IntPoint to a string.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator string(PointI point)
        {
            return point.ToString();
        }

        /// <summary>
        ///     Implicit cast that converts the given System.Drawing.Point to a IntPoint.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator PointI(System.Drawing.Point point)
        {
            return new PointI(point.X, point.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given PointF to a IntPoint.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator PointI(PointF point)
        {
            return new PointI(point.X, point.Y);
        }

        #if (MONOGAME || FNA)
        /// <summary>
        ///     Implicit cast that converts the given Microsoft.Xna.Framework.Point to a PointI.
        /// </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator PointI(Microsoft.Xna.Framework.Point point)
        {
            return new PointI(point.X, point.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given PointI to a Microsoft.Xna.Framework.Point.
        /// </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Microsoft.Xna.Framework.Point(PointI point)
        {
            return new Microsoft.Xna.Framework.Point(point.X, point.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given Microsoft.Xna.Framework.Vector2 to a PointI.
        /// </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator PointI(Microsoft.Xna.Framework.Vector2 vector)
        {
            return new PointI(vector.X, vector.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given PointI to a Microsoft.Xna.Framework.Vector2.
        /// </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Microsoft.Xna.Framework.Vector2(PointI point)
        {
            return new Microsoft.Xna.Framework.Vector2(point.X, point.Y);
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
            return obj is PointI && Equals((PointI) obj);
        }

        /// <summary>
        ///     Tests if this IntPoint is considered equal to another.
        /// </summary>
        /// <param name="other">    The point to compare to this object. </param>
        /// <returns>
        ///     True if the objects are considered equal, false if they are not.
        /// </returns>
        public bool Equals(PointI other)
        {
            return other.X == this.X && other.Y == this.Y;
        }

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
        public void Deconstruct(out int x, out int y)
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
        public (int, int) Deconstruct()
        {
            return (this.X, this.Y);
        }
    }
}
