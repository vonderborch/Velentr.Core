using System;
using System.Diagnostics;
using System.Drawing;

using Velentr.Core.Helpers.Math;

namespace Velentr.Core.Shapes
{
    /// <summary>
    ///     A rectangle.
    /// </summary>
    [DebuggerDisplay("(({X},{Y}),{Width}x{Height})")]
    public struct Rectangle
    {
        /// <summary>
        ///     (Immutable) the zero.
        /// </summary>
        public static readonly Rectangle Zero = new(0, 0, 0, 0);

        /// <summary>
        ///     (Immutable) the one.
        /// </summary>
        public static readonly Rectangle One = new(1, 1, 1, 1);

        /// <summary>
        ///     (Immutable) the maximum value.
        /// </summary>
        public static readonly Rectangle MaxValue = new(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);

        /// <summary>
        ///     (Immutable) the minimum value.
        /// </summary>
        public static readonly Rectangle MinValue = new(int.MinValue, int.MinValue, int.MinValue, int.MinValue);

        /// <summary>
        ///     The X coordinate.
        /// </summary>
        public int X;

        /// <summary>
        ///     The Y coordinate.
        /// </summary>
        public int Y;

        /// <summary>
        ///     The width.
        /// </summary>
        public int Width;

        /// <summary>
        ///     The height.
        /// </summary>
        public int Height;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">        The x coordinate. </param>
        /// <param name="y">        The y coordinate. </param>
        /// <param name="width">    The width. </param>
        /// <param name="height">   The height. </param>
        public Rectangle(int x, int y, int width, int height)
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
        public Rectangle(double x, double y, double width, double height)
        {
            this.X = (int) x;
            this.Y = (int) y;
            this.Width = (int) width;
            this.Height = (int) height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">        The x coordinate. </param>
        /// <param name="y">        The y coordinate. </param>
        /// <param name="width">    The width. </param>
        /// <param name="height">   The height. </param>
        public Rectangle(float x, float y, float width, float height)
        {
            this.X = (int) x;
            this.Y = (int) y;
            this.Width = (int) width;
            this.Height = (int) height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">        The x coordinate. </param>
        /// <param name="y">        The y coordinate. </param>
        /// <param name="width">    The width. </param>
        /// <param name="height">   The height. </param>
        public Rectangle(long x, long y, long width, long height)
        {
            this.X = (int) x;
            this.Y = (int) y;
            this.Width = (int) width;
            this.Height = (int) height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public Rectangle(Point coordinates, int width, int height)
        {
            this.X = (int) coordinates.X;
            this.Y = (int) coordinates.Y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public Rectangle(Point coordinates, long width, long height)
        {
            this.X = (int) coordinates.X;
            this.Y = (int) coordinates.Y;
            this.Width = (int) width;
            this.Height = (int) height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public Rectangle(Point coordinates, float width, float height)
        {
            this.X = (int) coordinates.X;
            this.Y = (int) coordinates.Y;
            this.Width = (int) width;
            this.Height = (int) height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public Rectangle(Point coordinates, double width, double height)
        {
            this.X = (int) coordinates.X;
            this.Y = (int) coordinates.Y;
            this.Width = (int) width;
            this.Height = (int) height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public Rectangle(PointI coordinates, int width, int height)
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
        public Rectangle(PointI coordinates, long width, long height)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = (int) width;
            this.Height = (int) height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public Rectangle(PointI coordinates, float width, float height)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = (int) width;
            this.Height = (int) height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        public Rectangle(PointI coordinates, double width, double height)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = (int) width;
            this.Height = (int) height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="dimensions">   The dimensions. </param>
        public Rectangle(int x, int y, Dimensions dimensions)
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
        public Rectangle(long x, long y, Dimensions dimensions)
        {
            this.X = (int) x;
            this.Y = (int) y;
            this.Width = dimensions.Width;
            this.Height = dimensions.Height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="dimensions">   The dimensions. </param>
        public Rectangle(float x, float y, Dimensions dimensions)
        {
            this.X = (int) x;
            this.Y = (int) y;
            this.Width = dimensions.Width;
            this.Height = dimensions.Height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="dimensions">   The dimensions. </param>
        public Rectangle(double x, double y, Dimensions dimensions)
        {
            this.X = (int) x;
            this.Y = (int) y;
            this.Width = dimensions.Width;
            this.Height = dimensions.Height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="dimensions">   The dimensions. </param>
        public Rectangle(Point coordinates, Dimensions dimensions)
        {
            this.X = (int) coordinates.X;
            this.Y = (int) coordinates.Y;
            this.Width = dimensions.Width;
            this.Height = dimensions.Height;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="coordinates">  The coordinates. </param>
        /// <param name="dimensions">   The dimensions. </param>
        public Rectangle(PointI coordinates, Dimensions dimensions)
        {
            this.X = coordinates.X;
            this.Y = coordinates.Y;
            this.Width = dimensions.Width;
            this.Height = dimensions.Height;
        }

        /// <summary>
        ///     Copy constructor.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        public Rectangle(Rectangle rectangle)
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
        public Rectangle(RectangleD rectangle)
        {
            this.X = (int) rectangle.X;
            this.Y = (int) rectangle.Y;
            this.Width = (int) rectangle.Width;
            this.Height = (int) rectangle.Height;
        }

        /// <summary>
        ///     Gets the left.
        /// </summary>
        /// <value>
        ///     The left.
        /// </value>
        public int Left => this.X;

        /// <summary>
        ///     Gets the right.
        /// </summary>
        /// <value>
        ///     The right.
        /// </value>
        public int Right => this.X + this.Width;

        /// <summary>
        ///     Gets the top.
        /// </summary>
        /// <value>
        ///     The top.
        /// </value>
        public int Top => this.Y;

        /// <summary>
        ///     Gets the bottom.
        /// </summary>
        /// <value>
        ///     The bottom.
        /// </value>
        public int Bottom => this.Y + this.Height;

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Rectangle operator +(Rectangle value1, Rectangle value2)
        {
            return new Rectangle(value1.X + value2.X, value1.Y + value2.Y, value1.Width + value2.Width, value1.Height + value2.Height);
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Rectangle operator -(Rectangle value1, Rectangle value2)
        {
            return new Rectangle(value1.X - value2.X, value1.Y - value2.Y, value1.Width - value2.Width, value1.Height - value2.Height);
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="value1">   The first value to multiply. </param>
        /// <param name="value2">   The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Rectangle operator *(Rectangle value1, Rectangle value2)
        {
            return new Rectangle(value1.X * value2.X, value1.Y * value2.Y, value1.Width * value2.Width, value1.Height * value2.Height);
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="value1">   The numerator. </param>
        /// <param name="value2">   The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Rectangle operator /(Rectangle value1, Rectangle value2)
        {
            return new Rectangle(value1.X / value2.X, value1.Y / value2.Y, value1.Width / value2.Width, value1.Height / value2.Height);
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="value1">   The numerator. </param>
        /// <param name="value2">   The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Rectangle operator %(Rectangle value1, Rectangle value2)
        {
            return new Rectangle(value1.X % value2.X, value1.Y % value2.Y, value1.Width % value2.Width, value1.Height % value2.Height);
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="value1">   The first instance to compare. </param>
        /// <param name="value2">   The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(Rectangle value1, Rectangle value2)
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
        public static bool operator !=(Rectangle value1, Rectangle value2)
        {
            return !value1.Equals(value2);
        }

        /// <summary>
        ///     Implicit cast that converts the given RectangleD to a Rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Rectangle(RectangleD rectangle)
        {
            return new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     Implicit cast that converts the given Rectangle to a string.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator string(Rectangle rectangle)
        {
            return rectangle.ToString();
        }

        #if (MONOGAME || FNA)
        /// <summary>
        ///     Implicit cast that converts the given Microsoft.Xna.Framework.Rectangle to a Rectangle.
        /// </summary>
        ///
        /// <param name="rectangle">    The rectangle. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Rectangle(Microsoft.Xna.Framework.Rectangle rectangle)
        {
            return new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     Implicit cast that converts the given Rectangle to a Microsoft.Xna.Framework.Rectangle.
        /// </summary>
        ///
        /// <param name="rectangle">    The rectangle. </param>
        ///
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Microsoft.Xna.Framework.Rectangle(Rectangle rectangle)
        {
            return new Microsoft.Xna.Framework.Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
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
            return obj is Rectangle && Equals((Rectangle) obj);
        }

        /// <summary>
        ///     Tests if this Rectangle is considered equal to another.
        /// </summary>
        /// <param name="other">    The rectangle to compare to this object. </param>
        /// <returns>
        ///     True if the objects are considered equal, false if they are not.
        /// </returns>
        public bool Equals(Rectangle other)
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
        ///     Implicit cast that converts the given System.Drawing.Rectangle to a Rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Rectangle(System.Drawing.Rectangle rectangle)
        {
            return new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     Implicit cast that converts the given System.Drawing.RectangleF to a Rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator Rectangle(RectangleF rectangle)
        {
            return new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     Implicit cast that converts the given Rectangle to a Rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator System.Drawing.Rectangle(Rectangle rectangle)
        {
            return new System.Drawing.Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     Implicit cast that converts the given Rectangle to a RectangleF.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator RectangleF(Rectangle rectangle)
        {
            return new RectangleF(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        ///     Query if this object contains the given rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     True if the object is in this collection, false if not.
        /// </returns>
        public bool Contains(Rectangle rectangle)
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
            this.X -= (int) horizontalAmount;
            this.Y -= (int) verticalAmount;
            this.Width += (int) (horizontalAmount * 2);
            this.Height += (int) (verticalAmount * 2);
        }

        /// <summary>
        ///     Inflates.
        /// </summary>
        /// <param name="horizontalAmount"> The horizontal amount. </param>
        /// <param name="verticalAmount">   The vertical amount. </param>
        public void Inflate(float horizontalAmount, float verticalAmount)
        {
            this.X -= (int) horizontalAmount;
            this.Y -= (int) verticalAmount;
            this.Width += (int) (horizontalAmount * 2);
            this.Height += (int) (verticalAmount * 2);
        }

        /// <summary>
        ///     Inflates.
        /// </summary>
        /// <param name="horizontalAmount"> The horizontal amount. </param>
        /// <param name="verticalAmount">   The vertical amount. </param>
        public void Inflate(double horizontalAmount, double verticalAmount)
        {
            this.X -= (int) horizontalAmount;
            this.Y -= (int) verticalAmount;
            this.Width += (int) (horizontalAmount * 2);
            this.Height += (int) (verticalAmount * 2);
        }

        /// <summary>
        ///     Query if this object intersects the given rectangle.
        /// </summary>
        /// <param name="rectangle">    The rectangle. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public bool Intersects(Rectangle rectangle)
        {
            return rectangle.Left < this.Right && this.Left < rectangle.Right && rectangle.Top < this.Bottom && this.Top < rectangle.Bottom;
        }

        /// <summary>
        ///     Intersections.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <returns>
        ///     A Rectangle.
        /// </returns>
        public RectangleD Intersection(Rectangle value)
        {
            return Intersection(this, value);
        }

        /// <summary>
        ///     Intersections.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to add to it. </param>
        /// <returns>
        ///     A Rectangle.
        /// </returns>
        public static Rectangle Intersection(Rectangle value1, Rectangle value2)
        {
            if (value1.Intersects(value2))
            {
                var left = Math.Max(value1.X, value2.X);
                var top = Math.Max(value1.Y, value2.Y);

                return new Rectangle(left, top, Math.Min(value1.X + value1.Width, value2.X + value2.Width) - left, Math.Min(value1.Y + value1.Height, value2.Y + value2.Height) - top);
            }

            return RectangleD.Zero;
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
            this.X += (int) x;
            this.Y += (int) y;
        }

        /// <summary>
        ///     Offsets the given point.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        public void Offset(float x, float y)
        {
            this.X += (int) x;
            this.Y += (int) y;
        }

        /// <summary>
        ///     Offsets the given point.
        /// </summary>
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>
        public void Offset(double x, double y)
        {
            this.X += (int) x;
            this.Y += (int) y;
        }

        /// <summary>
        ///     Offsets the given point.
        /// </summary>
        /// <param name="point">    The point. </param>
        public void Offset(Point point)
        {
            this.X += point.IntX;
            this.Y += point.IntY;
        }

        /// <summary>
        ///     Unions.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <returns>
        ///     A Rectangle.
        /// </returns>
        public Rectangle Union(Rectangle value)
        {
            var x = Math.Min(this.X, value.X);
            var y = Math.Min(this.Y, value.Y);

            return new Rectangle(x, y, Math.Max(this.Right, value.Right) - x, Math.Max(this.Bottom, value.Bottom) - y);
        }

        /// <summary>
        ///     Unions.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to add to it. </param>
        /// <returns>
        ///     A Rectangle.
        /// </returns>
        public static Rectangle Union(Rectangle value1, Rectangle value2)
        {
            var x = Math.Min(value1.X, value2.X);
            var y = Math.Min(value1.Y, value2.Y);

            return new Rectangle(x, y, Math.Max(value1.Right, value2.Right) - x, Math.Max(value1.Bottom, value2.Bottom) - y);
        }

        /// <summary>
        ///     A type deconstructor that extracts the individual members from this object.
        /// </summary>
        /// <param name="x">        [out] The x coordinate. </param>
        /// <param name="y">        [out] The y coordinate. </param>
        /// <param name="width">    [out] The width. </param>
        /// <param name="height">   [out] The height. </param>
        public void Deconstruct(out int x, out int y, out int width, out int height)
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
        public (int, int, int, int) Deconstruct()
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
        public bool Intersects(Circle value)
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
        public static bool Intersects(Rectangle rectangle, Circle circle)
        {
            var dx = circle.X - MathHelpers.Clamp(circle.X, rectangle.Left, rectangle.Right);
            var dy = circle.Y - MathHelpers.Clamp(circle.Y, rectangle.Top, rectangle.Bottom);

            return dx * dx + dy * dy <= circle.Radius;
        }
    }
}
