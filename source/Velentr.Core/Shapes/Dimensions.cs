using System.Diagnostics;

namespace Velentr.Core.Shapes
{
    /// <summary>
    ///     An object representing the width and height of something.
    /// </summary>
    [DebuggerDisplay("{Width}x{Height}")]
    public struct Dimensions
    {
        /// <summary>
        ///     (Immutable) the zero.
        /// </summary>
        public static readonly Dimensions Zero = new(0, 0);

        /// <summary>
        ///     (Immutable) the one.
        /// </summary>
        public static readonly Dimensions One = new(1, 1);

        /// <summary>
        ///     (Immutable) the maximum value.
        /// </summary>
        public static readonly Dimensions MaxValue = new(int.MaxValue, int.MaxValue);

        /// <summary>
        ///     (Immutable) the minimum value.
        /// </summary>
        public static readonly Dimensions MinValue = new(int.MinValue, int.MinValue);

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
        /// <param name="width">    The width. </param>
        /// <param name="height">   The height. </param>
        public Dimensions(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Copy constructor.
        /// </summary>
        /// <param name="dimensions">   The dimensions. </param>
        public Dimensions(Dimensions dimensions)
        {
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
        public static Dimensions operator +(Dimensions value1, Dimensions value2)
        {
            return new Dimensions(value1.Width + value2.Width, value1.Height + value2.Height);
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="value1">   The first value. </param>
        /// <param name="value2">   A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Dimensions operator -(Dimensions value1, Dimensions value2)
        {
            return new Dimensions(value1.Width - value2.Width, value1.Height - value2.Height);
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="value1">   The first value to multiply. </param>
        /// <param name="value2">   The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Dimensions operator *(Dimensions value1, Dimensions value2)
        {
            return new Dimensions(value1.Width * value2.Width, value1.Height * value2.Height);
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="value1">   The numerator. </param>
        /// <param name="value2">   The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Dimensions operator /(Dimensions value1, Dimensions value2)
        {
            return new Dimensions(value1.Width / value2.Width, value1.Height / value2.Height);
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="value1">   The numerator. </param>
        /// <param name="value2">   The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static Dimensions operator %(Dimensions value1, Dimensions value2)
        {
            return new Dimensions(value1.Width % value2.Width, value1.Height % value2.Height);
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="value1">   The first instance to compare. </param>
        /// <param name="value2">   The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(Dimensions value1, Dimensions value2)
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
        public static bool operator !=(Dimensions value1, Dimensions value2)
        {
            return !value1.Equals(value2);
        }

        /// <summary>
        ///     Implicit cast that converts the given Dimensions to a string.
        /// </summary>
        /// <param name="dimensions">   The dimensions. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator string(Dimensions dimensions)
        {
            return dimensions.ToString();
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
            return obj is Dimensions && Equals((Dimensions) obj);
        }

        /// <summary>
        ///     Tests if this Dimensions is considered equal to another.
        /// </summary>
        /// <param name="other">    The dimensions to compare to this object. </param>
        /// <returns>
        ///     True if the objects are considered equal, false if they are not.
        /// </returns>
        public bool Equals(Dimensions other)
        {
            return other.Width == this.Width && other.Height == this.Height;
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
            return this.Width.GetHashCode() ^ this.Height.GetHashCode();
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
            return $"{this.Width}x{this.Height}";
        }

        /// <summary>
        ///     A type deconstructor that extracts the individual members from this object.
        /// </summary>
        /// <param name="width">    [out] The width. </param>
        /// <param name="height">   [out] The height. </param>
        public void Deconstruct(out int width, out int height)
        {
            width = this.Width;
            height = this.Height;
        }

        /// <summary>
        ///     A type deconstructor that extracts the individual members from this object.
        /// </summary>
        /// <returns>
        ///     A Tuple.
        /// </returns>
        public (int, int) Deconstruct()
        {
            return (this.Width, this.Height);
        }
    }
}
