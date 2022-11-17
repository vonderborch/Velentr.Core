using System;
using System.Diagnostics;
using System.Drawing;

using Velentr.Core.Helpers.Math;

namespace Velentr.Core.Shapes
{
    /// <summary>
    ///     A rectangle using doubles internally.
    /// </summary>
    [DebuggerDisplay("(({X},{Y}),{Width}x{Height})")]
    public struct RectangleD
    {
        /// <summary>
        ///     (Immutable) the zero.
        /// </summary>
        public static readonly RectangleD Zero = new(0, 0, 0, 0);

        /// <summary>
        ///     (Immutable) the one.
        /// </summary>
        public static readonly RectangleD One = new(1, 1, 1, 1);

        /// <summary>
        ///     (Immutable) the maximum value.
        /// </summary>
        public static readonly RectangleD MaxValue = new(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);

        /// <summary>
        ///     (Immutable) the minimum value.
        /// </summary>
        public static readonly RectangleD MinValue = new(int.MinValue, int.MinValue, int.MinValue, int.MinValue);

        /// <summary>
        ///     The X coordinate.
        /// </summary>
        public double X;

        /// <summary>
        ///     The Y coordinate.
        /// </summary>
        public double Y;

        /// <summary>
        ///     The width.
        /// </summary>
        public double Width;

        /// <summary>
        ///     The height.
        /// </summary>
        public double Height;

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
        ///     Gets the width of the int.
        /// </summary>
        /// <value>
        ///     The width of the int.
        /// </value>
        public int IntWidth => (int) this.Width;

        /// <summary>
        ///     Gets the height of the int.
        /// </summary>
        /// <value>
        ///     The height of the int.
        /// </value>
        public int IntHeight => (int) this.Height;

        /// <summary>
        ///     Gets the left.
        /// </summary>
        /// <value>
        ///     The left.
        /// </value>
        public double Left => this.X;

        /// <summary>
        ///     Gets the int left.
        /// </summary>
        /// <value>
        ///     The int left.
        /// </value>
        public int IntLeft => (int) this.Left;

        /// <summary>
        ///     Gets the right.
        /// </summary>
        /// <value>
        ///     The right.
        /// </value>
        public double Right => this.X + this.Width;

        /// <summary>
        ///     Gets the int right.
        /// </summary>
        /// <value>
        ///     The int right.
        /// </value>
        public int IntRight => (int) this.Right;

        /// <summary>
        ///     Gets the top.
        /// </summary>
        /// <value>
        ///     The top.
        /// </value>
        public double Top => this.Y;

        /// <summary>
        ///     Gets the int top.
        /// </summary>
        /// <value>
        ///     The int top.
        /// </value>
        public int IntTop => (int) this.Top;

        /// <summary>
        ///     Gets the bottom.
        /// </summary>
        /// <value>
        ///     The bottom.
        /// </value>
        public double Bottom => this.Y + this.Height;

        /// <summary>
        ///     Gets the int bottom.
        /// </summary>
        /// <value>
        ///     The int bottom.
        /// </value>
        public int IntBottom => (int) this.Bottom;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">        The x coordinate. </param>
        /// <param name="y">        The y coordinate. </param>
        /// <param name="width">    The width. </param>
        /// <param name="height">   The height. </param>
        public RectangleD(double x, double y, double width, double height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">        The x coordinate. </param>
        /// <param name="y">        The y coordinate. </param>
        /// <param name="width">    The width. </param>
        /// <param name="height">   The height. </param>
        public RectangleD(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">        The x coordinate. </param>
        /// <param name="y">        The y coordinate. </param>
        /// <param name="width">    The width. </param>
        /// <param name="height">   The height. </param>
        public RectangleD(float x, float y, float width, float height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">        The x coordinate. </param>
        /// <param name="y">        The y coordinate. </param>
        /// <param name="width">    The width. </param>
        /// <param name="height">   The height. </param>
        public RectangleD(long x, long y, long width, long height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Copy constructor.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        public RectangleD(RectangleD rectangle)
        {
            this.X = rectangle.X;
            this.Y = rectangle.Y;
            this.Width = rectangle.Width;
            this.Height = rectangle.Height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        public RectangleD(Rectangle rectangle)
        {
            this.X = rectangle.X;
            this.Y = rectangle.Y;
            this.Width = rectangle.Width;
            this.Height = rectangle.Height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public RectangleD(Point coordinates, int width, int height)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public RectangleD(Point coordinates, long width, long height)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public RectangleD(Point coordinates, float width, float height)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public RectangleD(Point coordinates, double width, double height)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public RectangleD(PointI coordinates, int width, int height)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public RectangleD(PointI coordinates, long width, long height)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public RectangleD(PointI coordinates, float width, float height)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public RectangleD(PointI coordinates, double width, double height)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="dimensions">   The dimensions. </param>
        public RectangleD(int x, int y, Dimensions dimensions)
        {
            this.X = x;
            this.Y = y;
            this.Width = dimensions.Width;
            this.Height = dimensions.Height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="dimensions">   The dimensions. </param>
        public RectangleD(long x, long y, Dimensions dimensions)
        {
            this.X = x;
            this.Y = y;
            this.Width = dimensions.Width;
            this.Height = dimensions.Height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="dimensions">   The dimensions. </param>
        public RectangleD(float x, float y, Dimensions dimensions)
        {
            this.X = x;
            this.Y = y;
            this.Width = dimensions.Width;
            this.Height = dimensions.Height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="dimensions">   The dimensions. </param>
        public RectangleD(double x, double y, Dimensions dimensions)
        {
            this.X = x;
            this.Y = y;
            this.Width = dimensions.Width;
            this.Height = dimensions.Height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="dimensions">   The dimensions. </param>
        public RectangleD(Point coordinates, Dimensions dimensions)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = dimensions.Width;
            this.Height = dimensions.Height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="dimensions">   The dimensions. </param>
        public RectangleD(PointI coordinates, Dimensions dimensions)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = dimensions.Width;
            this.Height = dimensions.Height;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static RectangleD operator +(RectangleD value1, RectangleD value2)
        {
            return new RectangleD(value1.X + value2.X, value1.Y + value2.Y, value1.Width + value2.Width, value1.Height + value2.Height);
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static RectangleD operator -(RectangleD value1, RectangleD value2)
        {
            return new RectangleD(value1.X - value2.X, value1.Y - value2.Y, value1.Width - value2.Width, value1.Height - value2.Height);
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="value1">   The first value to multiply. </param>
        /// <param name="value2">   The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static RectangleD operator *(RectangleD value1, RectangleD value2)
        {
            return new RectangleD(value1.X * value2.X, value1.Y * value2.Y, value1.Width * value2.Width, value1.Height * value2.Height);
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="value1">   The numerator. </param>
        /// <param name="value2">   The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static RectangleD operator /(RectangleD value1, RectangleD value2)
        {
            return new RectangleD(value1.X / value2.X, value1.Y / value2.Y, value1.Width / value2.Width, value1.Height / value2.Height);
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="value1">   The numerator. </param>
        /// <param name="value2">   The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static RectangleD operator %(RectangleD value1, RectangleD value2)
        {
            return new RectangleD(value1.X % value2.X, value1.Y % value2.Y, value1.Width % value2.Width, value1.Height % value2.Height);
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="value1">   The first instance to compare. </param>
        /// <param name="value2">   The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(RectangleD value1, RectangleD value2)
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
        public static bool operator !=(RectangleD value1, RectangleD value2)
        {
            return !value1.Equals(value2);
        }

        /// <summary>
        ///     Implicit cast that converts the given RectangleD to a string.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator string(RectangleD rectangle)
        {
            return rectangle.ToString();
        }

        #if (MONOGAME || FNA)
        /// <summary>
        ///     Implicit cast that converts the given Microsoft.Xna.Framework.Rectangle to a RectangleD.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator RectangleD(Microsoft.Xna.Framework.Rectangle rectangle)
        {
            return new RectangleD(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     Implicit cast that converts the given RectangleD to a Microsoft.Xna.Framework.Rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Microsoft.Xna.Framework.Rectangle(RectangleD rectangle)
        {
            return new Microsoft.Xna.Framework.Rectangle(rectangle.IntX, rectangle.IntY, rectangle.IntWidth, rectangle.IntHeight);
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
            return obj is RectangleD && Equals((RectangleD) obj);
        }

        /// <summary>
        ///     Tests if this RectangleD is considered equal to another.
        /// </summary>
        /// <param name="other">    The rectangle d to compare to this object. </param>
        /// <returns>
        ///     True if the objects are considered equal, false if they are not.
        /// </returns>
        public bool Equals(RectangleD other)
        {
            return other.X == this.X && other.Y == this.Y && other.Width == this.Width && other.Height == this.Height;
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
            return this.X.GetHashCode() ^ (this.Y.GetHashCode() * this.Width.GetHashCode()) ^ this.Height.GetHashCode();
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
            return $"(({this.X}, {this.Y}), {this.Width}x{this.Height})";
        }

        /// <summary>
        ///     Implicit cast that converts the given Rectangle to a RectangleD.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator RectangleD(Rectangle rectangle)
        {
            return new RectangleD(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     Query if this object contains the given rectangle.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        /// <returns>
        ///     True if the object is in this collection, false if not.
        /// </returns>
        public bool Contains(int x, int y)
        {
            return Contains(x, (double) y);
        }

        /// <summary>
        ///     Query if this object contains the given rectangle.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        /// <returns>
        ///     True if the object is in this collection, false if not.
        /// </returns>
        public bool Contains(long x, long y)
        {
            return Contains(x, (double) y);
        }

        /// <summary>
        ///     Query if this object contains the given rectangle.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        /// <returns>
        ///     True if the object is in this collection, false if not.
        /// </returns>
        public bool Contains(float x, float y)
        {
            return Contains(x, (double) y);
        }

        /// <summary>
        ///     Query if this object contains the given rectangle.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        /// <returns>
        ///     True if the object is in this collection, false if not.
        /// </returns>
        public bool Contains(double x, double y)
        {
            return this.X <= x && x < this.X + this.Width && this.Y <= y && y < this.Y + this.Height;
        }

        /// <summary>
        ///     Query if this object contains the given rectangle.
        /// </summary>
        /// <param name="point">    The point. </param>
        /// <returns>
        ///     True if the object is in this collection, false if not.
        /// </returns>
        public bool Contains(Point point)
        {
            return Contains(point.X, point.Y);
        }

        /// <summary>
        ///     Implicit cast that converts the given System.Drawing.Rectangle to a RectangleD.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator RectangleD(System.Drawing.Rectangle rectangle)
        {
            return new RectangleD(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     Implicit cast that converts the given System.Drawing.RectangleF to a RectangleD.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator RectangleD(RectangleF rectangle)
        {
            return new RectangleD(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     Implicit cast that converts the given RectangleD to a Rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator System.Drawing.Rectangle(RectangleD rectangle)
        {
            return new System.Drawing.Rectangle(rectangle.IntX, rectangle.IntY, rectangle.IntWidth, rectangle.IntHeight);
        }

        /// <summary>
        ///     Implicit cast that converts the given RectangleD to a RectangleF.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator RectangleF(RectangleD rectangle)
        {
            return new RectangleF((float) rectangle.X, (float) rectangle.Y, (float) rectangle.Width, (float) rectangle.Height);
        }

        /// <summary>
        ///     Query if this object contains the given rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     True if the object is in this collection, false if not.
        /// </returns>
        public bool Contains(RectangleD rectangle)
        {
            return this.X <= rectangle.X && rectangle.X + rectangle.Width <= this.X + this.Width && this.Y <= rectangle.Y && rectangle.Y + rectangle.Height <= this.Y + this.Height;
        }

        /// <summary>
        ///     Inflates.
        /// </summary>
        /// <param name="horizontalAmount"> The horizontal amount. </param>
        /// <param name="verticalAmount">   The vertical amount. </param>
        public void Inflate(int horizontalAmount, int verticalAmount)
        {
            this.X -= horizontalAmount;
            this.Y -= verticalAmount;
            this.Width += horizontalAmount * 2;
            this.Height += verticalAmount * 2;
        }

        /// <summary>
        ///     Inflates.
        /// </summary>
        /// <param name="horizontalAmount"> The horizontal amount. </param>
        /// <param name="verticalAmount">   The vertical amount. </param>
        public void Inflate(long horizontalAmount, long verticalAmount)
        {
            this.X -= horizontalAmount;
            this.Y -= verticalAmount;
            this.Width += horizontalAmount * 2;
            this.Height += verticalAmount * 2;
        }

        /// <summary>
        ///     Inflates.
        /// </summary>
        /// <param name="horizontalAmount"> The horizontal amount. </param>
        /// <param name="verticalAmount">   The vertical amount. </param>
        public void Inflate(float horizontalAmount, float verticalAmount)
        {
            this.X -= horizontalAmount;
            this.Y -= verticalAmount;
            this.Width += horizontalAmount * 2;
            this.Height += verticalAmount * 2;
        }

        /// <summary>
        ///     Inflates.
        /// </summary>
        /// <param name="horizontalAmount"> The horizontal amount. </param>
        /// <param name="verticalAmount">   The vertical amount. </param>
        public void Inflate(double horizontalAmount, double verticalAmount)
        {
            this.X -= horizontalAmount;
            this.Y -= verticalAmount;
            this.Width += horizontalAmount * 2;
            this.Height += verticalAmount * 2;
        }

        /// <summary>
        ///     Query if this object intersects the given rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public bool Intersects(RectangleD rectangle)
        {
            return rectangle.Left < this.Right && this.Left < rectangle.Right && rectangle.Top < this.Bottom && this.Top < rectangle.Bottom;
        }

        /// <summary>
        ///     Intersections.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <returns>
        ///     A RectangleD.
        /// </returns>
        public RectangleD Intersection(RectangleD value)
        {
            return Intersection(this, value);
        }

        /// <summary>
        ///     Intersections.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to add to it. </param>
        /// <returns>
        ///     A RectangleD.
        /// </returns>
        public static RectangleD Intersection(RectangleD value1, RectangleD value2)
        {
            if (value1.Intersects(value2))
            {
                var left = Math.Max(value1.X, value2.X);
                var top = Math.Max(value1.Y, value2.Y);

                return new Rectangle(left, top, Math.Min(value1.X + value1.Width, value2.X + value2.Width) - left, Math.Min(value1.Y + value1.Height, value2.Y + value2.Height) - top);
            }

            return Zero;
        }

        /// <summary>
        ///     Offsets the given point.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        public void Offset(int x, int y)
        {
            this.X += x;
            this.Y += y;
        }

        /// <summary>
        ///     Offsets the given point.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        public void Offset(long x, long y)
        {
            this.X += x;
            this.Y += y;
        }

        /// <summary>
        ///     Offsets the given point.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        public void Offset(float x, float y)
        {
            this.X += x;
            this.Y += y;
        }

        /// <summary>
        ///     Offsets the given point.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        public void Offset(double x, double y)
        {
            this.X += x;
            this.Y += y;
        }

        /// <summary>
        ///     Offsets the given point.
        /// </summary>
        /// <param name="point">    The point. </param>
        public void Offset(Point point)
        {
            this.X += point.X;
            this.Y += point.Y;
        }

        /// <summary>
        ///     Unions.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <returns>
        ///     A RectangleD.
        /// </returns>
        public RectangleD Union(RectangleD value)
        {
            var x = Math.Min(this.X, value.X);
            var y = Math.Min(this.Y, value.Y);

            return new RectangleD(x, y, Math.Max(this.Right, value.Right) - x, Math.Max(this.Bottom, value.Bottom) - y);
        }

        /// <summary>
        ///     Unions.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to add to it. </param>
        /// <returns>
        ///     A RectangleD.
        /// </returns>
        public static RectangleD Union(RectangleD value1, RectangleD value2)
        {
            var x = Math.Min(value1.X, value2.X);
            var y = Math.Min(value1.Y, value2.Y);

            return new RectangleD(x, y, Math.Max(value1.Right, value2.Right) - x, Math.Max(value1.Bottom, value2.Bottom) - y);
        }

        /// <summary>
        ///     A type deconstructor that extracts the individual members from this object.
        /// </summary>
        /// <param name="x">        [out] The x coordinate. </param>
        /// <param name="y">        [out] The y coordinate. </param>
        /// <param name="width">    [out] The width. </param>
        /// <param name="height">   [out] The height. </param>
        public void Deconstruct(out double x, out double y, out double width, out double height)
        {
            x = this.X;
            y = this.Y;
            width = this.Width;
            height = this.Height;
        }

        /// <summary>
        ///     A type deconstructor that extracts the individual members from this object.
        /// </summary>
        /// <returns>
        ///     A Tuple.
        /// </returns>
        public (double, double, double, double) Deconstruct()
        {
            return (this.X, this.Y, this.Width, this.Height);
        }

        /// <summary>
        ///     Query if this object intersects the given value.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public bool Intersects(CircleD value)
        {
            return Intersects(this, value);
        }

        /// <summary>
        ///     Query if this object intersects the given value.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <param name="circle">       The circle. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public static bool Intersects(RectangleD rectangle, CircleD circle)
        {
            var dx = circle.X - MathHelpers.Clamp(circle.X, rectangle.Left, rectangle.Right);
            var dy = circle.Y - MathHelpers.Clamp(circle.Y, rectangle.Top, rectangle.Bottom);

            return dx * dx + dy * dy <= circle.Radius;
        }
    }
}
