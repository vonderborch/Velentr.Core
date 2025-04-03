using System.Numerics;
        
namespace Velentr.Core.Mathematics;

/// <summary>
/// Provides extension methods for numeric conversions.
/// </summary>
public static class NumericExtensions
{
    /// <summary>
    /// Converts the specified value to an integer.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted integer value.</returns>
    public static int ToInt<T>(this T value) where T : INumber<T>
    {
        return int.CreateChecked(value);
    }

    /// <summary>
    /// Converts the specified value to a long integer.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted long integer value.</returns>
    public static long ToLong<T>(this T value) where T : INumber<T>
    {
        return long.CreateChecked(value);
    }

    /// <summary>
    /// Converts the specified value to a float.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted float value.</returns>
    public static float ToFloat<T>(this T value) where T : INumber<T>
    {
        return float.CreateChecked(value);
    }

    /// <summary>
    /// Converts the specified value to a double.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted double value.</returns>
    public static double ToDouble<T>(this T value) where T : INumber<T>
    {
        return double.CreateChecked(value);
    }

    /// <summary>
    /// Converts the specified value to a decimal.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted decimal value.</returns>
    public static decimal ToDecimal<T>(this T value) where T : INumber<T>
    {
        return decimal.CreateChecked(value);
    }

    /// <summary>
    /// Converts the specified value to a BigInteger.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted BigInteger value.</returns>
    public static BigInteger ToBigInteger<T>(this T value) where T : INumber<T>
    {
        return BigInteger.CreateChecked(value);
    }

    /// <summary>
    /// Converts the specified value to a short integer.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted short integer value.</returns>
    public static short ToShort<T>(this T value) where T : INumber<T>
    {
        return short.CreateChecked(value);
    }

    /// <summary>
    /// Converts the specified value to a byte.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted byte value.</returns>
    public static byte ToByte<T>(this T value) where T : INumber<T>
    {
        return byte.CreateChecked(value);
    }

    /// <summary>
    /// Converts the specified value to a signed byte.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted signed byte value.</returns>
    public static sbyte ToSByte<T>(this T value) where T : INumber<T>
    {
        return sbyte.CreateChecked(value);
    }

    /// <summary>
    /// Converts the specified value to an unsigned short integer.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted unsigned short integer value.</returns>
    public static ushort ToUShort<T>(this T value) where T : INumber<T>
    {
        return ushort.CreateChecked(value);
    }

    /// <summary>
    /// Converts the specified value to an unsigned integer.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted unsigned integer value.</returns>
    public static uint ToUInt<T>(this T value) where T : INumber<T>
    {
        return uint.CreateChecked(value);
    }

    /// <summary>
    /// Converts the specified value to an unsigned long integer.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>The converted unsigned long integer value.</returns>
    public static ulong ToULong<T>(this T value) where T : INumber<T>
    {
        return ulong.CreateChecked(value);
    }
}