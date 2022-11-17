using System;
using System.Runtime.CompilerServices;

namespace Velentr.Core.Helpers.Validation
{
    /// <summary>
    ///     Various validations.
    /// </summary>
    public static class Validations
    {
        /// <summary>
        ///     Nots the null or empty check.
        /// </summary>
        /// <exception cref="ArgumentException">    . </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotNullOrEmptyCheck(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"{parameterName} can not be null or empty.");
            }
        }

        /// <summary>
        ///     Nots the null or white space check.
        /// </summary>
        /// <exception cref="ArgumentException">    . </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotNullOrWhiteSpaceCheck(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{parameterName} can not be null, empty, or contain only white space.");
            }
        }

        /// <summary>
        ///     Validates the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The parameter [{parameterName}] is out of the
        ///     range (min: {minValue}, max:{maxValue})!
        /// </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        /// <param name="minValue">         (Optional) The minimum value. </param>
        /// <param name="maxValue">         (Optional) The maximum value. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateRange(int value, string parameterName, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            if (minValue > value || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
            }
        }

        /// <summary>
        ///     Validates the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The parameter [{parameterName}] is out of the
        ///     range (min: {minValue}, max:{maxValue})!
        /// </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        /// <param name="minValue">         (Optional) The minimum value. </param>
        /// <param name="maxValue">         (Optional) The maximum value. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateRange(long value, string parameterName, long minValue = long.MinValue, long maxValue = long.MaxValue)
        {
            if (minValue > value || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
            }
        }

        /// <summary>
        ///     Validates the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The parameter [{parameterName}] is out of the
        ///     range (min: {minValue}, max:{maxValue})!
        /// </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        /// <param name="minValue">         (Optional) The minimum value. </param>
        /// <param name="maxValue">         (Optional) The maximum value. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateRange(short value, string parameterName, short minValue = short.MinValue, short maxValue = short.MaxValue)
        {
            if (minValue > value || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
            }
        }

        /// <summary>
        ///     Validates the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The parameter [{parameterName}] is out of the
        ///     range (min: {minValue}, max:{maxValue})!
        /// </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        /// <param name="minValue">         (Optional) The minimum value. </param>
        /// <param name="maxValue">         (Optional) The maximum value. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateRange(uint value, string parameterName, uint minValue = uint.MinValue, uint maxValue = uint.MaxValue)
        {
            if (minValue > value || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
            }
        }

        /// <summary>
        ///     Validates the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The parameter [{parameterName}] is out of the
        ///     range (min: {minValue}, max:{maxValue})!
        /// </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        /// <param name="minValue">         (Optional) The minimum value. </param>
        /// <param name="maxValue">         (Optional) The maximum value. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateRange(ulong value, string parameterName, ulong minValue = ulong.MinValue, ulong maxValue = ulong.MaxValue)
        {
            if (minValue > value || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
            }
        }

        /// <summary>
        ///     Validates the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The parameter [{parameterName}] is out of the
        ///     range (min: {minValue}, max:{maxValue})!
        /// </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        /// <param name="minValue">         (Optional) The minimum value. </param>
        /// <param name="maxValue">         (Optional) The maximum value. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateRange(ushort value, string parameterName, ushort minValue = ushort.MinValue, ushort maxValue = ushort.MaxValue)
        {
            if (minValue > value || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
            }
        }

        /// <summary>
        ///     Validates the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The parameter [{parameterName}] is out of the
        ///     range (min: {minValue}, max:{maxValue})!
        /// </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        /// <param name="minValue">         (Optional) The minimum value. </param>
        /// <param name="maxValue">         (Optional) The maximum value. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateRange(float value, string parameterName, float minValue = float.MinValue, float maxValue = float.MaxValue)
        {
            if (minValue > value || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
            }
        }

        /// <summary>
        ///     Validates the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The parameter [{parameterName}] is out of the
        ///     range (min: {minValue}, max:{maxValue})!
        /// </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        /// <param name="minValue">         (Optional) The minimum value. </param>
        /// <param name="maxValue">         (Optional) The maximum value. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateRange(double value, string parameterName, double minValue = double.MinValue, double maxValue = double.MaxValue)
        {
            if (minValue > value || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
            }
        }

        /// <summary>
        ///     Validates the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The parameter [{parameterName}] is out of the
        ///     range (min: {minValue}, max:{maxValue})!
        /// </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        /// <param name="minValue">         (Optional) The minimum value. </param>
        /// <param name="maxValue">         (Optional) The maximum value. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateRange(decimal value, string parameterName, decimal minValue = decimal.MinValue, decimal maxValue = decimal.MaxValue)
        {
            if (minValue > value || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
            }
        }

        /// <summary>
        ///     Validates the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The parameter [{parameterName}] is out of the
        ///     range (min: {minValue}, max:{maxValue})!
        /// </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        /// <param name="minValue">         (Optional) The minimum value. </param>
        /// <param name="maxValue">         (Optional) The maximum value. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateRange(byte value, string parameterName, byte minValue = byte.MinValue, byte maxValue = byte.MaxValue)
        {
            if (minValue > value || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
            }
        }

        /// <summary>
        ///     Validates the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The parameter [{parameterName}] is out of the
        ///     range (min: {minValue}, max:{maxValue})!
        /// </exception>
        /// <param name="value">            The value. </param>
        /// <param name="parameterName">    Name of the parameter. </param>
        /// <param name="minValue">         (Optional) The minimum value. </param>
        /// <param name="maxValue">         (Optional) The maximum value. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateRange(sbyte value, string parameterName, sbyte minValue = sbyte.MinValue, sbyte maxValue = sbyte.MaxValue)
        {
            if (minValue > value || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
            }
        }
    }
}
