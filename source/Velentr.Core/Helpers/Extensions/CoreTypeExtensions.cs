using System;

namespace Velentr.Core.Helpers.Extensions
{
    /// <summary>
    ///     Extensions for ints, floats, etc.
    /// </summary>
    public static class CoreTypeExtensions
    {
        /// <summary>
        ///     A byte extension method that converts a value to an int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an int.
        /// </returns>
        public static int ToInt(this float value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an int.
        /// </returns>
        public static int ToInt(this double value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an int.
        /// </returns>
        public static int ToInt(this long value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an int.
        /// </returns>
        public static int ToInt(this uint value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an int.
        /// </returns>
        public static int ToInt(this ulong value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an int.
        /// </returns>
        public static int ToInt(this ushort value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an int.
        /// </returns>
        public static int ToInt(this short value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an int.
        /// </returns>
        public static int ToInt(this byte value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an uint.
        /// </returns>
        public static uint ToUnsignedInt(this float value)
        {
            return Convert.ToUInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an uint.
        /// </returns>
        public static uint ToUnsignedInt(this double value)
        {
            return Convert.ToUInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an uint.
        /// </returns>
        public static uint ToUnsignedInt(this long value)
        {
            return Convert.ToUInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an uint.
        /// </returns>
        public static uint ToUnsignedInt(this int value)
        {
            return Convert.ToUInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an uint.
        /// </returns>
        public static uint ToUnsignedInt(this ulong value)
        {
            return Convert.ToUInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an uint.
        /// </returns>
        public static uint ToUnsignedInt(this ushort value)
        {
            return Convert.ToUInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an uint.
        /// </returns>
        public static uint ToUnsignedInt(this short value)
        {
            return Convert.ToUInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an uint.
        /// </returns>
        public static uint ToUnsignedInt(this byte value)
        {
            return Convert.ToUInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ushort.
        /// </returns>
        public static ushort ToUnsignedShort(this float value)
        {
            return Convert.ToUInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ushort.
        /// </returns>
        public static ushort ToUnsignedShort(this double value)
        {
            return Convert.ToUInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ushort.
        /// </returns>
        public static ushort ToUnsignedShort(this long value)
        {
            return Convert.ToUInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ushort.
        /// </returns>
        public static ushort ToUnsignedShort(this int value)
        {
            return Convert.ToUInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ushort.
        /// </returns>
        public static ushort ToUnsignedShort(this ulong value)
        {
            return Convert.ToUInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ushort.
        /// </returns>
        public static ushort ToUnsignedShort(this uint value)
        {
            return Convert.ToUInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ushort.
        /// </returns>
        public static ushort ToUnsignedShort(this short value)
        {
            return Convert.ToUInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ushort.
        /// </returns>
        public static ushort ToUnsignedShort(this byte value)
        {
            return Convert.ToUInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ulong.
        /// </returns>
        public static ulong ToUnsignedLong(this float value)
        {
            return Convert.ToUInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ulong.
        /// </returns>
        public static ulong ToUnsignedLong(this double value)
        {
            return Convert.ToUInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ulong.
        /// </returns>
        public static ulong ToUnsignedLong(this long value)
        {
            return Convert.ToUInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ulong.
        /// </returns>
        public static ulong ToUnsignedLong(this int value)
        {
            return Convert.ToUInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ulong.
        /// </returns>
        public static ulong ToUnsignedLong(this uint value)
        {
            return Convert.ToUInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ulong.
        /// </returns>
        public static ulong ToUnsignedLong(this ushort value)
        {
            return Convert.ToUInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ulong.
        /// </returns>
        public static ulong ToUnsignedLong(this short value)
        {
            return Convert.ToUInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ulong.
        /// </returns>
        public static ulong ToUnsignedLong(this byte value)
        {
            return Convert.ToUInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a long.
        /// </returns>
        public static long ToLong(this float value)
        {
            return Convert.ToInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a long.
        /// </returns>
        public static long ToLong(this double value)
        {
            return Convert.ToInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a long.
        /// </returns>
        public static long ToLong(this ulong value)
        {
            return Convert.ToInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a long.
        /// </returns>
        public static long ToLong(this int value)
        {
            return Convert.ToInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a long.
        /// </returns>
        public static long ToLong(this uint value)
        {
            return Convert.ToInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a long.
        /// </returns>
        public static long ToLong(this ushort value)
        {
            return Convert.ToInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a long.
        /// </returns>
        public static long ToLong(this short value)
        {
            return Convert.ToInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a long.
        /// </returns>
        public static long ToLong(this byte value)
        {
            return Convert.ToInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a short.
        /// </returns>
        public static short ToShort(this float value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a short.
        /// </returns>
        public static short ToShort(this double value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a short.
        /// </returns>
        public static short ToShort(this ulong value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a short.
        /// </returns>
        public static short ToShort(this int value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a short.
        /// </returns>
        public static short ToShort(this uint value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a short.
        /// </returns>
        public static short ToShort(this ushort value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a short.
        /// </returns>
        public static short ToShort(this long value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a short.
        /// </returns>
        public static short ToShort(this byte value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a float.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a float.
        /// </returns>
        public static float ToFloat(this short value)
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a float.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a float.
        /// </returns>
        public static float ToFloat(this double value)
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a float.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a float.
        /// </returns>
        public static float ToFloat(this ulong value)
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a float.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a float.
        /// </returns>
        public static float ToFloat(this int value)
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a float.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a float.
        /// </returns>
        public static float ToFloat(this uint value)
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a float.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a float.
        /// </returns>
        public static float ToFloat(this ushort value)
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a float.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a float.
        /// </returns>
        public static float ToFloat(this long value)
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a float.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a float.
        /// </returns>
        public static float ToFloat(this byte value)
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a double.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a double.
        /// </returns>
        public static double ToDouble(this short value)
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a double.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a double.
        /// </returns>
        public static double ToDouble(this float value)
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a double.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a double.
        /// </returns>
        public static double ToDouble(this ulong value)
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a double.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a double.
        /// </returns>
        public static double ToDouble(this int value)
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a double.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a double.
        /// </returns>
        public static double ToDouble(this uint value)
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a double.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a double.
        /// </returns>
        public static double ToDouble(this ushort value)
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a double.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a double.
        /// </returns>
        public static double ToDouble(this long value)
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a double.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a double.
        /// </returns>
        public static double ToDouble(this byte value)
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        ///     A double extension method that converts a value to a byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a byte.
        /// </returns>
        public static byte ToByte(this short value)
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        ///     A double extension method that converts a value to a byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a byte.
        /// </returns>
        public static byte ToByte(this float value)
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        ///     A double extension method that converts a value to a byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a byte.
        /// </returns>
        public static byte ToByte(this ulong value)
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        ///     A double extension method that converts a value to a byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a byte.
        /// </returns>
        public static byte ToByte(this int value)
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        ///     A double extension method that converts a value to a byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a byte.
        /// </returns>
        public static byte ToByte(this uint value)
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        ///     A double extension method that converts a value to a byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a byte.
        /// </returns>
        public static byte ToByte(this ushort value)
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        ///     A double extension method that converts a value to a byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a byte.
        /// </returns>
        public static byte ToByte(this long value)
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        ///     A double extension method that converts a value to a byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a byte.
        /// </returns>
        public static byte ToByte(this double value)
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an int.
        /// </returns>
        public static int ToInt(this decimal value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an uint.
        /// </returns>
        public static uint ToUnsignedInt(this decimal value)
        {
            return Convert.ToUInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ulong.
        /// </returns>
        public static ulong ToUnsignedLong(this decimal value)
        {
            return Convert.ToUInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ushort.
        /// </returns>
        public static ushort ToUnsignedShort(this decimal value)
        {
            return Convert.ToUInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a long.
        /// </returns>
        public static long ToLong(this decimal value)
        {
            return Convert.ToInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a short.
        /// </returns>
        public static short ToShort(this decimal value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        ///     A double extension method that converts a value to a byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a byte.
        /// </returns>
        public static byte ToByte(this decimal value)
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a double.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a double.
        /// </returns>
        public static double ToDouble(this decimal value)
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a float.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a float.
        /// </returns>
        public static float ToFloat(this decimal value)
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an int.
        /// </returns>
        public static int ToInt(this sbyte value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned int.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an uint.
        /// </returns>
        public static uint ToUnsignedInt(this sbyte value)
        {
            return Convert.ToUInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ulong.
        /// </returns>
        public static ulong ToUnsignedLong(this sbyte value)
        {
            return Convert.ToUInt64(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to an unsigned short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as an ushort.
        /// </returns>
        public static ushort ToUnsignedShort(this sbyte value)
        {
            return Convert.ToUInt16(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a long.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a long.
        /// </returns>
        public static long ToLong(this sbyte value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a short.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a short.
        /// </returns>
        public static short ToShort(this sbyte value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        ///     A double extension method that converts a value to a byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a byte.
        /// </returns>
        public static byte ToByte(this sbyte value)
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a double.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a double.
        /// </returns>
        public static double ToDouble(this sbyte value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a float.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a float.
        /// </returns>
        public static float ToFloat(this sbyte value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a signed byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a sbyte.
        /// </returns>
        public static sbyte ToSignedByte(this short value)
        {
            return Convert.ToSByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a signed byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a sbyte.
        /// </returns>
        public static sbyte ToSignedByte(this float value)
        {
            return Convert.ToSByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a signed byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a sbyte.
        /// </returns>
        public static sbyte ToSignedByte(this ulong value)
        {
            return Convert.ToSByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a signed byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a sbyte.
        /// </returns>
        public static sbyte ToSignedByte(this int value)
        {
            return Convert.ToSByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a signed byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a sbyte.
        /// </returns>
        public static sbyte ToSignedByte(this uint value)
        {
            return Convert.ToSByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a signed byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a sbyte.
        /// </returns>
        public static sbyte ToSignedByte(this ushort value)
        {
            return Convert.ToSByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a signed byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a sbyte.
        /// </returns>
        public static sbyte ToSignedByte(this long value)
        {
            return Convert.ToSByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a signed byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a sbyte.
        /// </returns>
        public static sbyte ToSignedByte(this double value)
        {
            return Convert.ToSByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a signed byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a sbyte.
        /// </returns>
        public static sbyte ToSignedByte(this decimal value)
        {
            return Convert.ToSByte(value);
        }

        /// <summary>
        ///     A byte extension method that converts a value to a signed byte.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a sbyte.
        /// </returns>
        public static sbyte ToSignedByte(this byte value)
        {
            return Convert.ToSByte(value);
        }

        /// <summary>
        ///     A sbyte extension method that converts a value to a decimal.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a decimal.
        /// </returns>
        public static decimal ToDecimal(this short value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        ///     A sbyte extension method that converts a value to a decimal.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a decimal.
        /// </returns>
        public static decimal ToDecimal(this float value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        ///     A sbyte extension method that converts a value to a decimal.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a decimal.
        /// </returns>
        public static decimal ToDecimal(this ulong value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        ///     A sbyte extension method that converts a value to a decimal.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a decimal.
        /// </returns>
        public static decimal ToDecimal(this int value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        ///     A sbyte extension method that converts a value to a decimal.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a decimal.
        /// </returns>
        public static decimal ToDecimal(this uint value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        ///     A sbyte extension method that converts a value to a decimal.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a decimal.
        /// </returns>
        public static decimal ToDecimal(this ushort value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        ///     A sbyte extension method that converts a value to a decimal.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a decimal.
        /// </returns>
        public static decimal ToDecimal(this long value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        ///     A sbyte extension method that converts a value to a decimal.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a decimal.
        /// </returns>
        public static decimal ToDecimal(this double value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        ///     A sbyte extension method that converts a value to a decimal.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a decimal.
        /// </returns>
        public static decimal ToDecimal(this byte value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        ///     A sbyte extension method that converts a value to a decimal.
        /// </summary>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     Value as a decimal.
        /// </returns>
        public static decimal ToDecimal(this sbyte value)
        {
            return Convert.ToDecimal(value);
        }
    }
}
