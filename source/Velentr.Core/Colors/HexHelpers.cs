using Velentr.Core.Mathematics;
using Velentr.Core.Validation;
using Velentr.Helpers.Strings;

namespace Velentr.Core.Colors;

/// <summary>
///     Provides helper methods for converting between hexadecimal and RGB color representations.
/// </summary>
public static class HexHelpers
{
    private static readonly string[] HexReplacements = ["#", "0x", "0X", " "];

    /// <summary>
    ///     Converts a hexadecimal color string to RGB byte values.
    /// </summary>
    /// <param name="hex">The hexadecimal color string.</param>
    /// <param name="red">The red component of the color.</param>
    /// <param name="green">The green component of the color.</param>
    /// <param name="blue">The blue component of the color.</param>
    public static void ConvertHexToRgb(string hex, out byte red, out byte green, out byte blue)
    {
        Validations.NotNullOrEmptyCheck(hex, nameof(hex));
        var cleanedHexCode = hex.ReplaceAny(string.Empty, HexReplacements);
        Validations.ValidateRange(cleanedHexCode.Length, nameof(hex), 6, 6);
        
        var hexColor = Convert.ToInt32(cleanedHexCode, 16);
        var r = (hexColor >> 16) & 0xFF;
        var g = (hexColor >> 8) & 0xFF;
        var b = hexColor & 0xFF;

        red = (byte)Maths<int>.Clamp(r, 0, 255);
        green = (byte)Maths<int>.Clamp(g, 0, 255);
        blue = (byte)Maths<int>.Clamp(b, 0, 255);
    }

    /// <summary>
    ///     Converts a hexadecimal color string to RGB double values.
    /// </summary>
    /// <param name="hex">The hexadecimal color string.</param>
    /// <param name="red">The red component of the color as a double.</param>
    /// <param name="green">The green component of the color as a double.</param>
    /// <param name="blue">The blue component of the color as a double.</param>
    public static void ConvertHexToRgb(string hex, out double red, out double green, out double blue)
    {
        ConvertHexToRgb(hex, out var r, out var g, out byte b);
        red = FloatingMaths<double>.ByteToPercentage(r);
        green = FloatingMaths<double>.ByteToPercentage(g);
        blue = FloatingMaths<double>.ByteToPercentage(b);
    }

    /// <summary>
    ///     Converts a hexadecimal color string to a tuple of RGB double values.
    /// </summary>
    /// <param name="hex">The hexadecimal color string.</param>
    /// <returns>A tuple containing the red, green, and blue components of the color as doubles.</returns>
    public static (double red, double green, double blue) ConvertHexToRgb(string hex)
    {
        ConvertHexToRgb(hex, out var red, out var green, out double blue);
        return (red, green, blue);
    }

    /// <summary>
    ///     Converts a hexadecimal color string to a tuple of RGB byte values.
    /// </summary>
    /// <param name="hex">The hexadecimal color string.</param>
    /// <returns>A tuple containing the red, green, and blue components of the color.</returns>
    public static (byte red, byte green, byte blue) ConvertHexToRgbBytes(string hex)
    {
        ConvertHexToRgb(hex, out var red, out var green, out byte blue);
        return (red, green, blue);
    }

    /// <summary>
    ///     Converts RGB byte values to a hexadecimal color string.
    /// </summary>
    /// <param name="red">The red component of the color.</param>
    /// <param name="green">The green component of the color.</param>
    /// <param name="blue">The blue component of the color.</param>
    /// <param name="hex">The resulting hexadecimal color string.</param>
    public static void ConvertRgbToHex(byte red, byte green, byte blue, out string hex)
    {
        hex = $"#{red:X2}{green:X2}{blue:X2}";
    }

    /// <summary>
    ///     Converts RGB byte values to a hexadecimal color string.
    /// </summary>
    /// <param name="red">The red component of the color.</param>
    /// <param name="green">The green component of the color.</param>
    /// <param name="blue">The blue component of the color.</param>
    /// <returns>The resulting hexadecimal color string.</returns>
    public static string ConvertRgbToHex(byte red, byte green, byte blue)
    {
        ConvertRgbToHex(red, green, blue, out var hex);
        return hex;
    }

    /// <summary>
    ///     Converts RGB double values to a hexadecimal color string.
    /// </summary>
    /// <param name="red">The red component of the color as a double.</param>
    /// <param name="green">The green component of the color as a double.</param>
    /// <param name="blue">The blue component of the color as a double.</param>
    /// <param name="hex">The resulting hexadecimal color string.</param>
    public static void ConvertRgbToHex(double red, double green, double blue, out string hex)
    {
        var r = FloatingMaths<double>.PercentageToByte(red);
        var g = FloatingMaths<double>.PercentageToByte(green);
        var b = FloatingMaths<double>.PercentageToByte(blue);
        ConvertRgbToHex(r, g, b, out hex);
    }

    /// <summary>
    ///     Converts RGB double values to a hexadecimal color string.
    /// </summary>
    /// <param name="red">The red component of the color as a double.</param>
    /// <param name="green">The green component of the color as a double.</param>
    /// <param name="blue">The blue component of the color as a double.</param>
    /// <returns>The resulting hexadecimal color string.</returns>
    public static string ConvertRgbToHex(double red, double green, double blue)
    {
        ConvertRgbToHex(red, green, blue, out var hex);
        return hex;
    }
}
