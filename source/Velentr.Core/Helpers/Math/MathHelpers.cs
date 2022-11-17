namespace Velentr.Core.Helpers.Math
{
    /// <summary>
    ///     Various mathematics helpers.
    /// </summary>
    public static class MathHelpers
    {
        /// <summary>
        ///     Tests if objects are considered equal.
        /// </summary>
        /// <param name="a">            Double to be compared. </param>
        /// <param name="b">            Double to be compared. </param>
        /// <param name="precision">    Double to be compared. </param>
        /// <returns>
        ///     True if the objects are considered equal, false if they are not.
        /// </returns>
        public static bool Equals(double a, double b, double precision)
        {
            return System.Math.Abs(a - b) <= precision;
        }

        /// <summary>
        ///     Clamp the given value.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <param name="minValue"> The minimum value. </param>
        /// <param name="maxValue"> The maximum value. </param>
        /// <returns>
        ///     A double.
        /// </returns>
        public static double Clamp(double value, double minValue, double maxValue)
        {
            return value < minValue
                       ? minValue
                       : value > maxValue
                           ? maxValue
                           : value;
        }

        /// <summary>
        ///     Clamp the given value.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <param name="minValue"> The minimum value. </param>
        /// <param name="maxValue"> The maximum value. </param>
        /// <returns>
        ///     A int.
        /// </returns>
        public static int Clamp(int value, int minValue, int maxValue)
        {
            return value < minValue
                       ? minValue
                       : value > maxValue
                           ? maxValue
                           : value;
        }

        /// <summary>
        ///     Clamp the given value.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <param name="minValue"> The minimum value. </param>
        /// <param name="maxValue"> The maximum value. </param>
        /// <returns>
        ///     A float.
        /// </returns>
        public static float Clamp(float value, float minValue, float maxValue)
        {
            return value < minValue
                       ? minValue
                       : value > maxValue
                           ? maxValue
                           : value;
        }

        /// <summary>
        ///     Clamp the given value.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <param name="minValue"> The minimum value. </param>
        /// <param name="maxValue"> The maximum value. </param>
        /// <returns>
        ///     A long.
        /// </returns>
        public static long Clamp(long value, long minValue, long maxValue)
        {
            return value < minValue
                       ? minValue
                       : value > maxValue
                           ? maxValue
                           : value;
        }
    }
}
