using Microsoft.Xna.Framework;
using Velentr.Core.Colors;

namespace Velentr.Core.FNA.Colors;

/// <summary>
/// Provides methods to convert colors between different formats.
/// </summary>
public static class ColorConvertors
{
    /// <summary>
    /// Converts a hexadecimal color string to an XNA Color object.
    /// </summary>
    /// <param name="hex">The hexadecimal color string.</param>
    /// <param name="alpha">The alpha component of the color.</param>
    /// <returns>An XNA Color object.</returns>
    public static Color ColorFromHex(string hex, float alpha = 1f)
    {
        var color = HexHelpers.ConvertHexToRgb(hex);
        return new Color((float)color.red, (float)color.green, (float)color.blue, alpha);
    }

    /// <summary>
    /// Converts HSV values to an XNA Color object.
    /// </summary>
    /// <param name="hue">The hue component of the color.</param>
    /// <param name="saturation">The saturation component of the color.</param>
    /// <param name="value">The value component of the color.</param>
    /// <param name="alpha">The alpha component of the color.</param>
    /// <returns>An XNA Color object.</returns>
    public static Color ColorFromHsv(float hue, float saturation, float value, float alpha = 1f)
    {
        var color = HsvHelpers.ConvertHsvToRgb(hue, saturation, value);
        return new Color((float)color.red, (float)color.green, (float)color.blue, alpha);
    }

    /// <summary>
    /// Converts HSL values to an XNA Color object.
    /// </summary>
    /// <param name="hue">The hue component of the color.</param>
    /// <param name="saturation">The saturation component of the color.</param>
    /// <param name="lightness">The lightness component of the color.</param>
    /// <param name="alpha">The alpha component of the color.</param>
    /// <returns>An XNA Color object.</returns>
    public static Color ColorFromHsl(float hue, float saturation, float lightness, float alpha = 1f)
    {
        var color = HslHelpers.ConvertHslToRgb(hue, saturation, lightness);
        return new Color((float)color.red, (float)color.green, (float)color.blue, alpha);
    }

    /// <summary>
    /// Converts an XNA Color object to HSV values.
    /// </summary>
    /// <param name="color">The XNA Color object.</param>
    /// <returns>A tuple containing the HSV values.</returns>
    public static (double red, double green, double blue) ColorToHsv(Color color)
    {
        return HsvHelpers.ConvertRgbToHsv(color.R, color.G, color.B);
    }

    /// <summary>
    /// Converts an XNA Color object to HSL values.
    /// </summary>
    /// <param name="color">The XNA Color object.</param>
    /// <returns>A tuple containing the HSL values.</returns>
    public static (double red, double green, double blue) ColorToHsl(Color color)
    {
        return HslHelpers.ConvertRgbToHsl(color.R, color.G, color.B);
    }

    /// <summary>
    /// Converts an XNA Color object to a hexadecimal color string.
    /// </summary>
    /// <param name="color">The XNA Color object.</param>
    /// <returns>The hexadecimal color string.</returns>
    public static string ColorToHex(Color color)
    {
        return HexHelpers.ConvertRgbToHex(color.R, color.G, color.B);
    }
}