﻿using System.Diagnostics;
using System.Drawing;

using Velentr.Core.Helpers.Math;

namespace Velentr.Core.Shapes
{
    /// <summary>
    ///     A circle.
    /// </summary>
    [DebuggerDisplay("({X}, {Y})x{Radius}")]
    public struct Circle
    {
        /// <summary>
        ///     (Immutable) the zero.
        /// </summary>
        public static readonly Circle Zero = new(0, 0, 0);

        /// <summary>
        ///     (Immutable) the one.
        /// </summary>
        public static readonly Circle One = new(1, 1, 1);

        /// <summary>
        ///     (Immutable) the maximum value.
        /// </summary>
        public static readonly Circle MaxValue = new(int.MaxValue, int.MaxValue, int.MaxValue);

        /// <summary>
        ///     (Immutable) the minimum value.
        /// </summary>
        public static readonly Circle MinValue = new(int.MinValue, int.MinValue, int.MinValue);

        /// <summary>
        ///     The radius.
        /// </summary>
        public int Radius;

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
        /// <param name="x">        The x coordinate. </param>
        /// <param name="y">        The y coordinate. </param>
        /// <param name="Radius">   The radius. </param>
        public Circle(int x, int y, int Radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = Radius;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">        The x coordinate. </param>
        /// <param name="y">        The y coordinate. </param>
        /// <param name="Radius">   The radius. </param>
        public Circle(long x, long y, long Radius)
        {
            this.X = (int) x;
            this.Y = (int) y;
            this.Radius = (int) Radius;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">        The x coordinate. </param>
        /// <param name="y">        The y coordinate. </param>
        /// <param name="Radius">   The radius. </param>
        public Circle(float x, float y, float Radius)
        {
            this.X = (int) x;
            this.Y = (int) y;
            this.Radius = (int) Radius;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">        The x coordinate. </param>
        /// <param name="y">        The y coordinate. </param>
        /// <param name="Radius">   The radius. </param>
        public Circle(double x, double y, double Radius)
        {
            this.X = (int) x;
            this.Y = (int) y;
            this.Radius = (int) Radius;
        }

        /// <summary>
        ///     Copy constructor.
        /// </summary>
        /// <param name="circle">   The circle. </param>
        public Circle(Circle circle)
        {
            this.X = circle.X;
            this.Y = circle.Y;
            this.Radius = circle.Radius;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="Radius">       The radius. </param>
        public Circle(Point coordinates, int Radius)
        {
            this.X = coordinates.IntX;
            this.Y = coordinates.IntY;
            this.Radius = Radius;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="Radius">       The radius. </param>
        public Circle(Point coordinates, long Radius)
        {
            this.X = coordinates.IntX;
            this.Y = coordinates.IntY;
            this.Radius = (int) Radius;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="Radius">       The radius. </param>
        public Circle(Point coordinates, float Radius)
        {
            this.X = coordinates.IntX;
            this.Y = coordinates.IntY;
            this.Radius = (int) Radius;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="Radius">       The radius. </param>
        public Circle(Point coordinates, double Radius)
        {
            this.X = coordinates.IntX;
            this.Y = coordinates.IntY;
            this.Radius = (int) Radius;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="Radius">       The radius. </param>
        public Circle(PointI coordinates, int Radius)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Radius = Radius;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="Radius">       The radius. </param>
        public Circle(PointI coordinates, long Radius)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Radius = (int) Radius;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="Radius">       The radius. </param>
        public Circle(PointI coordinates, float Radius)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Radius = (int) Radius;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="Radius">       The radius. </param>
        public Circle(PointI coordinates, double Radius)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Radius = (int) Radius;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Circle operator +(Circle value1, Circle value2)
        {
            return new Circle(value1.X + value2.X, value1.Y + value2.Y, value1.Radius + value2.Radius);
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Circle operator -(Circle value1, Circle value2)
        {
            return new Circle(value1.X - value2.X, value1.Y - value2.Y, value1.Radius - value2.Radius);
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="value1">   The first value to multiply. </param>
        /// <param name="value2">   The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Circle operator *(Circle value1, Circle value2)
        {
            return new Circle(value1.X * value2.X, value1.Y * value2.Y, value1.Radius * value2.Radius);
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="value1">   The numerator. </param>
        /// <param name="value2">   The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Circle operator /(Circle value1, Circle value2)
        {
            return new Circle(value1.X / value2.X, value1.Y / value2.Y, value1.Radius / value2.Radius);
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="value1">   The numerator. </param>
        /// <param name="value2">   The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Circle operator %(Circle value1, Circle value2)
        {
            return new Circle(value1.X % value2.X, value1.Y % value2.Y, value1.Radius % value2.Radius);
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="value1">   The first instance to compare. </param>
        /// <param name="value2">   The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(Circle value1, Circle value2)
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
        public static bool operator !=(Circle value1, Circle value2)
        {
            return !value1.Equals(value2);
        }

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
            return obj is Circle && Equals((Circle) obj);
        }

        /// <summary>
        ///     Implicit cast that converts the given CircleD to a Circle.
        /// </summary>
        /// <param name="circle">   The circle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Circle(CircleD circle)
        {
            return new Circle(circle.X, circle.Y, circle.Radius);
        }

        /// <summary>
        ///     Implicit cast that converts the given CircleM to a Circle.
        /// </summary>
        /// <param name="circle">   The circle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Circle(CircleM circle)
        {
            return new Circle(circle.X, circle.Y, circle.Radius);
        }

        /// <summary>
        ///     Implicit cast that converts the given Point to a Circle.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Circle(Point point)
        {
            return new Circle(point, 1);
        }

        /// <summary>
        ///     Implicit cast that converts the given System.Drawing.Point to a Circle.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Circle(System.Drawing.Point point)
        {
            return new Circle((PointI) point, 1);
        }

        /// <summary>
        ///     Implicit cast that converts the given System.Drawing.PointF to a Circle.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Circle(PointF point)
        {
            return new Circle((PointI) point, 1);
        }

        #if (MONOGAME || FNA)
        /// <summary>
        ///     Implicit cast that converts the given Microsoft.Xna.Framework.Point to a Circle.
        /// </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static implicit operator Circle(Microsoft.Xna.Framework.Point point)
        {
            return new Circle((PointI)point, 1);
        }

        /// <summary>
        ///     Implicit cast that converts the given Microsoft.Xna.Framework.Vector2 to a Circle.
        /// </summary>
        ///
        /// <param name="vector">   The vector. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Circle(Microsoft.Xna.Framework.Vector2 vector)
        {
            return new Circle((PointI)vector, 1);
        }

        /// <summary>
        ///     Implicit cast that converts the given Microsoft.Xna.Framework.Vector3 to a Circle.
        /// </summary>
        ///
        /// <param name="vector">   The vector. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Circle(Microsoft.Xna.Framework.Vector3 vector)
        {
            return new Circle(vector.X, vector.Y, vector.Z);
        }

        #endif

        /// <summary>
        ///     Implicit cast that converts the given Circle to a string.
        /// </summary>
        /// <param name="circle">   The circle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator string(Circle circle)
        {
            return circle.ToString();
        }

        /// <summary>
        ///     Tests if this Circle is considered equal to another.
        /// </summary>
        /// <param name="other">    The circle to compare to this object. </param>
        /// <returns>
        ///     True if the objects are considered equal, false if they are not.
        /// </returns>
        public bool Equals(Circle other)
        {
            return other.X == this.X && other.Y == this.Y && other.Radius == this.Radius;
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
            return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Radius.GetHashCode();
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
            return $"({this.X}, {this.Y})x{this.Radius}";
        }

        /// <summary>
        ///     A type deconstructor that extracts the individual members from this object.
        /// </summary>
        /// <param name="x">        [out] The x coordinate. </param>
        /// <param name="y">        [out] The y coordinate. </param>
        /// <param name="radius">   [out] The radius. </param>
        public void Deconstruct(out int x, out int y, out int radius)
        {
            x = this.X;
            y = this.Y;
            radius = this.Radius;
        }

        /// <summary>
        ///     A type deconstructor that extracts the individual members from this object.
        /// </summary>
        /// <returns>
        ///     A Tuple.
        /// </returns>
        public (int, int, int) Deconstruct()
        {
            return (this.X, this.Y, this.Radius);
        }

        /// <summary>
        ///     Query if this object intersects the given value.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public bool Intersects(Circle value)
        {
            return Intersects(this, value);
        }

        /// <summary>
        ///     Query if this object intersects the given value.
        /// </summary>
        /// <param name="value1">   The first instance to compare. </param>
        /// <param name="value2">   The second instance to compare. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public static bool Intersects(Circle value1, Circle value2)
        {
            var dx = value2.X - value1.X;
            var dy = value2.Y - value1.Y;

            return dx * dx + dy * dy <= value1.Radius * value2.Radius;
        }

        /// <summary>
        ///     Query if this object intersects the given value.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public bool Intersects(Rectangle value)
        {
            return Intersects(this, value);
        }

        /// <summary>
        ///     Query if this object intersects the given value.
        /// </summary>
        /// <param name="circle">       The circle. </param>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public static bool Intersects(Circle circle, Rectangle rectangle)
        {
            var dx = circle.X - MathHelpers.Clamp(circle.X, rectangle.Left, rectangle.Right);
            var dy = circle.Y - MathHelpers.Clamp(circle.Y, rectangle.Top, rectangle.Bottom);

            return dx * dx + dy * dy <= circle.Radius;
        }
    }
}
