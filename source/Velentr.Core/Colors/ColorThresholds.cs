namespace Velentr.Core.Colors;

/// <summary>
///     Provides methods to check if RGB colors meet minimum threshold values in different color spaces.
/// </summary>
public static class ColorThresholds
{
    /// <summary>
    ///     Checks if the hex color meets the minimum RGB threshold values.
    /// </summary>
    /// <param name="hex">The hex representation of the color.</param>
    /// <param name="alpha">The alpha component of the color.</param>
    /// <param name="thresholdRed">The minimum red threshold value.</param>
    /// <param name="thresholdGreen">The minimum green threshold value.</param>
    /// <param name="thresholdBlue">The minimum blue threshold value.</param>
    /// <param name="thresholdAlpha">The minimum alpha threshold value.</param>
    /// <returns>True if the color meets the threshold values, otherwise false.</returns>
    public static bool HexMeetsMinRgbThreshold(string hex, double alpha, double thresholdRed, double thresholdGreen,
        double thresholdBlue, double thresholdAlpha)
    {
        var (red, green, blue) = HexHelpers.ConvertHexToRgb(hex);
        return RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
    }

    /// <summary>
    ///     Checks if the hex color meets the minimum RGB threshold values.
    /// </summary>
    /// <param name="hex">The hex representation of the color.</param>
    /// <param name="alpha">The alpha component of the color.</param>
    /// <param name="thresholdRed">The minimum red threshold value.</param>
    /// <param name="thresholdGreen">The minimum green threshold value.</param>
    /// <param name="thresholdBlue">The minimum blue threshold value.</param>
    /// <param name="thresholdAlpha">The minimum alpha threshold value.</param>
    /// <returns>True if the color meets the threshold values, otherwise false.</returns>
    public static bool HexMeetsMinRgbThreshold(string hex, double alpha, byte thresholdRed, byte thresholdGreen,
        byte thresholdBlue, double thresholdAlpha)
    {
        var (red, green, blue) = HexHelpers.ConvertHexToRgbBytes(hex);
        return RgbMeetsMinRgbThreshold(red, green, blue, alpha, thresholdRed, thresholdGreen, thresholdBlue,
            thresholdAlpha);
    }

    /// <summary>
    ///     Checks if the RGB color meets the minimum HSL threshold values.
    /// </summary>
    /// <param name="red">The red component of the color.</param>
    /// <param name="green">The green component of the color.</param>
    /// <param name="blue">The blue component of the color.</param>
    /// <param name="alpha">The alpha component of the color.</param>
    /// <param name="thresholdHue">The minimum hue threshold value.</param>
    /// <param name="thresholdSaturation">The minimum saturation threshold value.</param>
    /// <param name="thresholdLightness">The minimum lightness threshold value.</param>
    /// <param name="thresholdAlpha">The minimum alpha threshold value.</param>
    /// <returns>True if the color meets the threshold values, otherwise false.</returns>
    public static bool RgbMeetsMinHslThreshold(double red, double green, double blue, double alpha, double thresholdHue,
        double thresholdSaturation, double thresholdLightness, double thresholdAlpha)
    {
        var (hue, saturation, lightness) = HslHelpers.ConvertRgbToHsl(red, green, blue);
        return hue >= thresholdHue &&
               saturation >= thresholdSaturation &&
               lightness >= thresholdLightness &&
               alpha >= thresholdAlpha;
    }

    /// <summary>
    ///     Checks if the RGB color meets the minimum HSL threshold values.
    /// </summary>
    /// <param name="red">The red component of the color.</param>
    /// <param name="green">The green component of the color.</param>
    /// <param name="blue">The blue component of the color.</param>
    /// <param name="alpha">The alpha component of the color.</param>
    /// <param name="thresholdHue">The minimum hue threshold value.</param>
    /// <param name="thresholdSaturation">The minimum saturation threshold value.</param>
    /// <param name="thresholdLightness">The minimum lightness threshold value.</param>
    /// <param name="thresholdAlpha">The minimum alpha threshold value.</param>
    /// <returns>True if the color meets the threshold values, otherwise false.</returns>
    public static bool RgbMeetsMinHslThreshold(byte red, byte green, byte blue, double alpha, double thresholdHue,
        double thresholdSaturation, double thresholdLightness, double thresholdAlpha)
    {
        var (hue, saturation, lightness) = HslHelpers.ConvertRgbToHsl(red, green, blue);
        return hue >= thresholdHue &&
               saturation >= thresholdSaturation &&
               lightness >= thresholdLightness &&
               alpha >= thresholdAlpha;
    }

    /// <summary>
    ///     Checks if the RGB color meets the minimum HSV threshold values.
    /// </summary>
    /// <param name="red">The red component of the color.</param>
    /// <param name="green">The green component of the color.</param>
    /// <param name="blue">The blue component of the color.</param>
    /// <param name="alpha">The alpha component of the color.</param>
    /// <param name="thresholdHue">The minimum hue threshold value.</param>
    /// <param name="thresholdSaturation">The minimum saturation threshold value.</param>
    /// <param name="thresholdValue">The minimum value threshold value.</param>
    /// <param name="thresholdAlpha">The minimum alpha threshold value.</param>
    /// <returns>True if the color meets the threshold values, otherwise false.</returns>
    public static bool RgbMeetsMinHsvThreshold(double red, double green, double blue, double alpha, double thresholdHue,
        double thresholdSaturation, double thresholdValue, double thresholdAlpha)
    {
        var (hue, saturation, value) = HsvHelpers.ConvertRgbToHsv(red, green, blue);
        return hue >= thresholdHue &&
               saturation >= thresholdSaturation &&
               value >= thresholdValue &&
               alpha >= thresholdAlpha;
    }

    /// <summary>
    ///     Checks if the RGB color meets the minimum HSV threshold values.
    /// </summary>
    /// <param name="red">The red component of the color.</param>
    /// <param name="green">The green component of the color.</param>
    /// <param name="blue">The blue component of the color.</param>
    /// <param name="alpha">The alpha component of the color.</param>
    /// <param name="thresholdHue">The minimum hue threshold value.</param>
    /// <param name="thresholdSaturation">The minimum saturation threshold value.</param>
    /// <param name="thresholdValue">The minimum value threshold value.</param>
    /// <param name="thresholdAlpha">The minimum alpha threshold value.</param>
    /// <returns>True if the color meets the threshold values, otherwise false.</returns>
    public static bool RgbMeetsMinHsvThreshold(byte red, byte green, byte blue, double alpha, double thresholdHue,
        double thresholdSaturation, double thresholdValue, double thresholdAlpha)
    {
        var (hue, saturation, value) = HsvHelpers.ConvertRgbToHsv(red, green, blue);
        return hue >= thresholdHue &&
               saturation >= thresholdSaturation &&
               value >= thresholdValue &&
               alpha >= thresholdAlpha;
    }

    /// <summary>
    ///     Checks if the RGB color meets the minimum RGB threshold values.
    /// </summary>
    /// <param name="red">The red component of the color.</param>
    /// <param name="green">The green component of the color.</param>
    /// <param name="blue">The blue component of the color.</param>
    /// <param name="alpha">The alpha component of the color.</param>
    /// <param name="thresholdRed">The minimum red threshold value.</param>
    /// <param name="thresholdGreen">The minimum green threshold value.</param>
    /// <param name="thresholdAlpha">The minimum alpha threshold value.</param>
    /// <returns>True if the color meets the threshold values, otherwise false.</returns>
    public static bool RgbMeetsMinRgbThreshold(double red, double green, double blue, double alpha, double thresholdRed,
        double thresholdGreen, double thresholdBlue, double thresholdAlpha)
    {
        return red >= thresholdRed &&
               green >= thresholdGreen &&
               blue >= thresholdBlue &&
               alpha >= thresholdAlpha;
    }

    /// <summary>
    ///     Checks if the RGB color meets the minimum RGB threshold values.
    /// </summary>
    /// <param name="red">The red component of the color.</param>
    /// <param name="green">The green component of the color.</param>
    /// <param name="blue">The blue component of the color.</param>
    /// <param name="alpha">The alpha component of the color.</param>
    /// <param name="thresholdRed">The minimum red threshold value.</param>
    /// <param name="thresholdGreen">The minimum green threshold value.</param>
    /// <param name="thresholdBlue">The minimum blue threshold value.</param>
    /// <param name="thresholdAlpha">The minimum alpha threshold value.</param>
    /// <returns>True if the color meets the threshold values, otherwise false.</returns>
    public static bool RgbMeetsMinRgbThreshold(byte red, byte green, byte blue, double alpha, byte thresholdRed,
        byte thresholdGreen, byte thresholdBlue, double thresholdAlpha)
    {
        return red >= thresholdRed &&
               green >= thresholdGreen &&
               blue >= thresholdBlue &&
               alpha >= thresholdAlpha;
    }
}
