/// <file>
/// Velentr.Math\FixedPointMath\Precision6\FPL6.cs
/// </file>
///
/// <copyright file="FPL6.cs" company="">
/// Copyright (c) 2022 Christian Webber. All rights reserved.
/// </copyright>
///
/// <summary>
/// Implements the fpl 6 class.
/// </summary>

using System;

namespace Velentr.Core.Helpers.Math.FixedPointMath.Precision6
{
    /// <summary>
    ///     A fixed-point math struct that has precision to 4 decimal points.
    /// </summary>
    public struct FPL6
    {
        /// <summary>
        ///     The raw value.
        /// </summary>
        public long RawValue;

        /// <summary>
        ///     (Immutable) the shift.
        /// </summary>
        public const int Shift = 20;

        /// <summary>
        ///     (Immutable) the precision.
        /// </summary>
        public const int Precision = 6;

        public const long OneLong = 1 << Shift;

        /// <summary>
        ///     The one.
        /// </summary>
        public static FPL6 One = CreateFromLong(1);

        /// <summary>
        ///     The maximum value.
        /// </summary>
        public static FPL6 MaxValue = CreateFromLong(long.MaxValue, false);

        /// <summary>
        ///     The minimum value.
        /// </summary>
        public static FPL6 MinValue = CreateFromLong(long.MinValue, false);

        /// <summary>
        ///     Creates from string.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <returns>
        ///     The new from string.
        /// </returns>
        public static FPL6 CreateFromString(string value)
        {
            var hasDecimals = value.Contains(".");

            if (hasDecimals)
            {
                var decimalLocation = value.IndexOf('.');
                var pre = Convert.ToInt32(value.Substring(0, decimalLocation));
                var post = Convert.ToInt32(value.Substring(decimalLocation + 1));

                return CreateFromIntParts(pre, post);
            }

            return CreateFromLong(Convert.ToInt64(value));
        }

        /// <summary>
        ///     Creates from long.
        /// </summary>
        /// <param name="rawValue">         The raw value. </param>
        /// <param name="valueHasDecimals"> (Optional) True if value has decimals. </param>
        /// <returns>
        ///     The new from long.
        /// </returns>
        public static FPL6 CreateFromLong(long rawValue, bool valueHasDecimals = true)
        {
            FPL6 result;
            switch (valueHasDecimals)
            {
                case false:
                    result.RawValue = rawValue;

                    break;

                default:
                    result.RawValue = rawValue << Shift;

                    break;
            }

            return result;
        }

        /// <summary>
        ///     Creates from double.
        /// </summary>
        /// <exception cref="InvalidCastException">
        ///     Thrown when an object cannot be cast to a required
        ///     type.
        /// </exception>
        /// <param name="rawValue"> The raw value. </param>
        /// <returns>
        ///     The new from double.
        /// </returns>
        public static FPL6 CreateFromDouble(double rawValue)
        {
            FPL6 result;
            if (rawValue <= int.MaxValue && rawValue >= int.MinValue)
            {
                result.RawValue = (int) System.Math.Round(rawValue * OneLong);
            }
            else if (rawValue <= long.MaxValue << Shift && rawValue >= long.MinValue << Shift)
            {
                result.RawValue = (long) System.Math.Round(rawValue * OneLong);
            }
            else
            {
                throw new InvalidCastException("Unable to convert double to FPL6, out-of-range!");
            }

            return result;
        }

        /// <summary>
        ///     Creates from float.
        /// </summary>
        /// <exception cref="InvalidCastException">
        ///     Thrown when an object cannot be cast to a required
        ///     type.
        /// </exception>
        /// <param name="rawValue"> The raw value. </param>
        /// <returns>
        ///     The new from float.
        /// </returns>
        public static FPL6 CreateFromFloat(float rawValue)
        {
            FPL6 result;
            if (rawValue <= int.MaxValue && rawValue >= int.MinValue)
            {
                result.RawValue = (int) System.Math.Round(rawValue * OneLong);
            }
            else if (rawValue <= long.MaxValue << Shift && rawValue >= long.MinValue << Shift)
            {
                result.RawValue = (long) System.Math.Round(rawValue * OneLong);
            }
            else
            {
                throw new InvalidCastException("Unable to convert float to FPL6, out-of-range!");
            }

            return result;
        }

        /// <summary>
        ///     Creates from int parts.
        /// </summary>
        /// <param name="preDecimal">   The pre decimal. </param>
        /// <param name="postDecimal">  The post decimal. </param>
        /// <returns>
        ///     The new from int parts.
        /// </returns>
        public static FPL6 CreateFromIntParts(int preDecimal, int postDecimal)
        {
            var f = CreateFromLong(preDecimal);
            if (postDecimal >= 0)
            {
                f.RawValue += (CreateFromDouble(postDecimal) / 1000).RawValue;
            }

            return f;
        }

        /// <summary>
        ///     Converts this object to an int.
        /// </summary>
        /// <returns>
        ///     This object as an int.
        /// </returns>
        public int ToInt()
        {
            return (int) (this.RawValue >> Shift);
        }

        /// <summary>
        ///     Converts this object to a long.
        /// </summary>
        /// <returns>
        ///     This object as a long.
        /// </returns>
        public long ToLong()
        {
            return this.RawValue >> Shift;
        }

        /// <summary>
        ///     Converts this object to a double.
        /// </summary>
        /// <returns>
        ///     This object as a double.
        /// </returns>
        public double ToDouble()
        {
            return (double) this.RawValue / OneLong;
        }

        /// <summary>
        ///     Converts this object to a float.
        /// </summary>
        /// <returns>
        ///     This object as a float.
        /// </returns>
        public float ToFloat()
        {
            return (float) this.RawValue / OneLong;
        }

        /// <summary>
        ///     Gets the inverse.
        /// </summary>
        /// <value>
        ///     The inverse.
        /// </value>
        public FPL6 Inverse => CreateFromLong(-this.RawValue, false);

        /// <summary>
        ///     Implicit cast that converts the given FPL6 to an int.
        /// </summary>
        /// <param name="source">   Source for the. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator int(FPL6 source)
        {
            return (int) (source.RawValue >> Shift);
        }

        /// <summary>
        ///     Implicit cast that converts the given FPL6 to a long.
        /// </summary>
        /// <param name="source">   Source for the. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator long(FPL6 source)
        {
            return source.RawValue >> Shift;
        }

        /// <summary>
        ///     Implicit cast that converts the given FPL6 to a float.
        /// </summary>
        /// <param name="source">   Source for the. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator float(FPL6 source)
        {
            return source.RawValue / (float) OneLong;
        }

        /// <summary>
        ///     Implicit cast that converts the given FPL6 to a double.
        /// </summary>
        /// <param name="source">   Source for the. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator double(FPL6 source)
        {
            return source.RawValue / (double) OneLong;
        }

        /// <summary>
        ///     Implicit cast that converts the given FPL6 to a string.
        /// </summary>
        /// <param name="source">   Source for the. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator string(FPL6 source)
        {
            return source.ToString();
        }

        /// <summary>
        ///     Implicit cast that converts the given int to a FPL6.
        /// </summary>
        /// <param name="source">   Source for the. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator FPL6(int source)
        {
            return CreateFromLong(source);
        }

        /// <summary>
        ///     Implicit cast that converts the given long to a FPL6.
        /// </summary>
        /// <param name="source">   Source for the. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator FPL6(long source)
        {
            return CreateFromLong(source);
        }

        /// <summary>
        ///     Implicit cast that converts the given float to a FPL6.
        /// </summary>
        /// <param name="source">   Source for the. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator FPL6(float source)
        {
            return CreateFromFloat(source);
        }

        /// <summary>
        ///     Implicit cast that converts the given double to a FPL6.
        /// </summary>
        /// <param name="source">   Source for the. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator FPL6(double source)
        {
            return CreateFromDouble(source);
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="left">     The first value to multiply. </param>
        /// <param name="right">    The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator *(FPL6 left, FPL6 right)
        {
            FPL6 result;
            result.RawValue = (left.RawValue * right.RawValue) >> Shift;

            return result;
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="left">     The first value to multiply. </param>
        /// <param name="right">    The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator *(FPL6 left, int right)
        {
            return left * (FPL6) right;
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="left">     The first value to multiply. </param>
        /// <param name="right">    The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator *(int left, FPL6 right)
        {
            return (FPL6) left * right;
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="left">     The first value to multiply. </param>
        /// <param name="right">    The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator *(FPL6 left, long right)
        {
            return left * (FPL6) right;
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="left">     The first value to multiply. </param>
        /// <param name="right">    The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator *(long left, FPL6 right)
        {
            return (FPL6) left * right;
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="left">     The first value to multiply. </param>
        /// <param name="right">    The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator *(FPL6 left, float right)
        {
            return left * (FPL6) right;
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="left">     The first value to multiply. </param>
        /// <param name="right">    The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator *(float left, FPL6 right)
        {
            return (FPL6) left * right;
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="left">     The first value to multiply. </param>
        /// <param name="right">    The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator *(FPL6 left, double right)
        {
            return left * (FPL6) right;
        }

        /// <summary>
        ///     Multiplication operator.
        /// </summary>
        /// <param name="left">     The first value to multiply. </param>
        /// <param name="right">    The second value to multiply. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator *(double left, FPL6 right)
        {
            return (FPL6) left * right;
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator /(FPL6 left, FPL6 right)
        {
            FPL6 result;
            result.RawValue = (left.RawValue << Shift) / right.RawValue;

            return result;
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator /(FPL6 left, int right)
        {
            return left / (FPL6) right;
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator /(int left, FPL6 right)
        {
            return (FPL6) left / right;
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator /(FPL6 left, long right)
        {
            return left / (FPL6) right;
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator /(long left, FPL6 right)
        {
            return (FPL6) left / right;
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator /(FPL6 left, float right)
        {
            return left / (FPL6) right;
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator /(float left, FPL6 right)
        {
            return (FPL6) left / right;
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator /(FPL6 left, double right)
        {
            return left / (FPL6) right;
        }

        /// <summary>
        ///     Division operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator /(double left, FPL6 right)
        {
            return (FPL6) left / right;
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator %(FPL6 left, FPL6 right)
        {
            FPL6 result;
            result.RawValue = left.RawValue % right.RawValue;

            return result;
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator %(FPL6 left, int right)
        {
            return left % (FPL6) right;
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator %(int left, FPL6 right)
        {
            return (FPL6) left % right;
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator %(FPL6 left, long right)
        {
            return left % (FPL6) right;
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator %(long left, FPL6 right)
        {
            return (FPL6) left % right;
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator %(FPL6 left, float right)
        {
            return left % (FPL6) right;
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator %(float left, FPL6 right)
        {
            return (FPL6) left % right;
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator %(FPL6 left, double right)
        {
            return left % (FPL6) right;
        }

        /// <summary>
        ///     Modulus operator.
        /// </summary>
        /// <param name="left">     The numerator. </param>
        /// <param name="right">    The denominator. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator %(double left, FPL6 right)
        {
            return (FPL6) left % right;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator +(FPL6 left, FPL6 right)
        {
            FPL6 result;
            result.RawValue = left.RawValue + right.RawValue;

            return result;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator +(FPL6 left, int right)
        {
            return left + (FPL6) right;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator +(int left, FPL6 right)
        {
            return (FPL6) left + right;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator +(FPL6 left, long right)
        {
            return left + (FPL6) right;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator +(long left, FPL6 right)
        {
            return (FPL6) left + right;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator +(FPL6 left, float right)
        {
            return left + (FPL6) right;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator +(float left, FPL6 right)
        {
            return (FPL6) left + right;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator +(FPL6 left, double right)
        {
            return left + (FPL6) right;
        }

        /// <summary>
        ///     Addition operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to add to it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator +(double left, FPL6 right)
        {
            return (FPL6) left + right;
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator -(FPL6 left, FPL6 right)
        {
            FPL6 result;
            result.RawValue = left.RawValue - right.RawValue;

            return result;
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator -(FPL6 left, int right)
        {
            return left - (FPL6) right;
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator -(int left, FPL6 right)
        {
            return (FPL6) left - right;
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator -(FPL6 left, long right)
        {
            return left - (FPL6) right;
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator -(long left, FPL6 right)
        {
            return (FPL6) left - right;
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator -(FPL6 left, float right)
        {
            return left - (FPL6) right;
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator -(float left, FPL6 right)
        {
            return (FPL6) left - right;
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator -(FPL6 left, double right)
        {
            return left - (FPL6) right;
        }

        /// <summary>
        ///     Subtraction operator.
        /// </summary>
        /// <param name="left">     The first value. </param>
        /// <param name="right">    A value to subtract from it. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator -(double left, FPL6 right)
        {
            return (FPL6) left - right;
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(FPL6 left, FPL6 right)
        {
            return left.RawValue == right.RawValue;
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(FPL6 left, int right)
        {
            return left == (FPL6) right;
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(int left, FPL6 right)
        {
            return (FPL6) left == right;
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(FPL6 left, long right)
        {
            return left == (FPL6) right;
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(long left, FPL6 right)
        {
            return (FPL6) left == right;
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(FPL6 left, float right)
        {
            return left == (FPL6) right;
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(float left, FPL6 right)
        {
            return (FPL6) left == right;
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(FPL6 left, double right)
        {
            return left == (FPL6) right;
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator ==(double left, FPL6 right)
        {
            return (FPL6) left == right;
        }

        /// <summary>
        ///     Inequality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator !=(FPL6 left, FPL6 right)
        {
            return left.RawValue != right.RawValue;
        }

        /// <summary>
        ///     Inequality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator !=(FPL6 left, int right)
        {
            return left != (FPL6) right;
        }

        /// <summary>
        ///     Inequality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator !=(int left, FPL6 right)
        {
            return (FPL6) left != right;
        }

        /// <summary>
        ///     Inequality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator !=(FPL6 left, long right)
        {
            return left != (FPL6) right;
        }

        /// <summary>
        ///     Inequality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator !=(long left, FPL6 right)
        {
            return (FPL6) left != right;
        }

        /// <summary>
        ///     Inequality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator !=(FPL6 left, float right)
        {
            return left != (FPL6) right;
        }

        /// <summary>
        ///     Inequality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator !=(float left, FPL6 right)
        {
            return (FPL6) left != right;
        }

        /// <summary>
        ///     Inequality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator !=(FPL6 left, double right)
        {
            return left != (FPL6) right;
        }

        /// <summary>
        ///     Inequality operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator !=(double left, FPL6 right)
        {
            return (FPL6) left != right;
        }

        /// <summary>
        ///     Greater-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >=(FPL6 left, FPL6 right)
        {
            return left.RawValue >= right.RawValue;
        }

        /// <summary>
        ///     Greater-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >=(FPL6 left, int right)
        {
            return left >= (FPL6) right;
        }

        /// <summary>
        ///     Greater-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >=(int left, FPL6 right)
        {
            return (FPL6) left >= right;
        }

        /// <summary>
        ///     Greater-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >=(FPL6 left, long right)
        {
            return left >= (FPL6) right;
        }

        /// <summary>
        ///     Greater-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >=(long left, FPL6 right)
        {
            return (FPL6) left >= right;
        }

        /// <summary>
        ///     Greater-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >=(FPL6 left, float right)
        {
            return left >= (FPL6) right;
        }

        /// <summary>
        ///     Greater-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >=(float left, FPL6 right)
        {
            return (FPL6) left >= right;
        }

        /// <summary>
        ///     Greater-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >=(FPL6 left, double right)
        {
            return left >= (FPL6) right;
        }

        /// <summary>
        ///     Greater-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >=(double left, FPL6 right)
        {
            return (FPL6) left >= right;
        }

        /// <summary>
        ///     Less-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <=(FPL6 left, FPL6 right)
        {
            return left.RawValue <= right.RawValue;
        }

        /// <summary>
        ///     Less-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <=(FPL6 left, int right)
        {
            return left <= (FPL6) right;
        }

        /// <summary>
        ///     Less-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <=(int left, FPL6 right)
        {
            return (FPL6) left <= right;
        }

        /// <summary>
        ///     Less-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <=(FPL6 left, long right)
        {
            return left <= (FPL6) right;
        }

        /// <summary>
        ///     Less-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <=(long left, FPL6 right)
        {
            return (FPL6) left <= right;
        }

        /// <summary>
        ///     Less-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <=(FPL6 left, float right)
        {
            return left <= (FPL6) right;
        }

        /// <summary>
        ///     Less-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <=(float left, FPL6 right)
        {
            return (FPL6) left <= right;
        }

        /// <summary>
        ///     Less-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <=(FPL6 left, double right)
        {
            return left <= (FPL6) right;
        }

        /// <summary>
        ///     Less-than-or-equal comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <=(double left, FPL6 right)
        {
            return (FPL6) left <= right;
        }

        /// <summary>
        ///     Greater-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >(FPL6 left, FPL6 right)
        {
            return left.RawValue > right.RawValue;
        }

        /// <summary>
        ///     Greater-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >(FPL6 left, int right)
        {
            return left > (FPL6) right;
        }

        /// <summary>
        ///     Greater-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >(int left, FPL6 right)
        {
            return (FPL6) left > right;
        }

        /// <summary>
        ///     Greater-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >(FPL6 left, long right)
        {
            return left > (FPL6) right;
        }

        /// <summary>
        ///     Greater-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >(long left, FPL6 right)
        {
            return (FPL6) left > right;
        }

        /// <summary>
        ///     Greater-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >(FPL6 left, float right)
        {
            return left > (FPL6) right;
        }

        /// <summary>
        ///     Greater-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >(float left, FPL6 right)
        {
            return (FPL6) left > right;
        }

        /// <summary>
        ///     Greater-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >(FPL6 left, double right)
        {
            return left > (FPL6) right;
        }

        /// <summary>
        ///     Greater-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator >(double left, FPL6 right)
        {
            return (FPL6) left > right;
        }

        /// <summary>
        ///     Less-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <(FPL6 left, FPL6 right)
        {
            return left.RawValue < right.RawValue;
        }

        /// <summary>
        ///     Less-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <(FPL6 left, int right)
        {
            return left < (FPL6) right;
        }

        /// <summary>
        ///     Less-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <(int left, FPL6 right)
        {
            return (FPL6) left < right;
        }

        /// <summary>
        ///     Less-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <(FPL6 left, long right)
        {
            return left < (FPL6) right;
        }

        /// <summary>
        ///     Less-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <(long left, FPL6 right)
        {
            return (FPL6) left < right;
        }

        /// <summary>
        ///     Less-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <(FPL6 left, float right)
        {
            return left < (FPL6) right;
        }

        /// <summary>
        ///     Less-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <(float left, FPL6 right)
        {
            return (FPL6) left < right;
        }

        /// <summary>
        ///     Less-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <(FPL6 left, double right)
        {
            return left < (FPL6) right;
        }

        /// <summary>
        ///     Less-than comparison operator.
        /// </summary>
        /// <param name="left">     The first instance to compare. </param>
        /// <param name="right">    The second instance to compare. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static bool operator <(double left, FPL6 right)
        {
            return (FPL6) left < right;
        }

        /// <summary>
        ///     Bitwise left shift operator.
        /// </summary>
        /// <param name="left">     The left. </param>
        /// <param name="right">    The right. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator <<(FPL6 left, int right)
        {
            return CreateFromLong(left.RawValue << right, false);
        }

        /// <summary>
        ///     Bitwise right shift operator.
        /// </summary>
        /// <param name="left">     The left. </param>
        /// <param name="right">    The right. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static FPL6 operator >> (FPL6 left, int right)
        {
            return CreateFromLong(left.RawValue >> right, false);
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
            return obj is FPL6 ? ((FPL6) obj).RawValue == this.RawValue : false;
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
            return this.RawValue.GetHashCode();
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
            return $"{System.Math.Round(ToDouble(), Precision)}";
        }
    }
}
