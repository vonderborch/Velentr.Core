namespace Velentr.Core.Helpers.Math.ByteConversion
{
    /// <summary>
    ///     Helpers when converting data sizes.
    /// </summary>
    public static class ConvertToSize
    {
        /// <summary>
        ///     A long extension method that converts this object to a size unit.
        /// </summary>
        /// <param name="value">        The value to act on. </param>
        /// <param name="unit">         The unit. </param>
        /// <param name="baseAmount">   (Optional) The base amount. </param>
        /// <returns>
        ///     The given data converted to a double in the specified size unit.
        /// </returns>
        public static double ToSizeUnit(this long value, SizeUnits unit, short baseAmount = 1024)
        {
            return value / System.Math.Pow(baseAmount, (long) unit);
        }
    }
}
