using Velentr.Core.Mathematics;
using Velentr.Core.Validation;

namespace Velentr.Core.Colors;

/// <summary>
///     Provides helper methods for converting between HSL and RGB color representations.
/// </summary>
public static class HslHelpers
{
    /// <summary>
    ///     Converts HSL color values to RGB double values.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="lightness">The lightness component of the color (0-1).</param>
    /// <param name="red">The red component of the color as a double.</param>
    /// <param name="green">The green component of the color as a double.</param>
    /// <param name="blue">The blue component of the color as a double.</param>
    public static void ConvertHslToRgb(int hue, double saturation, double lightness, out double red, out double green,
        out double blue)
    {
        Validations.ValidateRange(hue, nameof(hue), 0, 360);
        Validations.ValidateRange(saturation, nameof(saturation), 0, 1);
        Validations.ValidateRange(lightness, nameof(lightness), 0, 1);

        var actualHue = Maths<int>.CircularClamp(hue, 0, 360) / 360d;
        var actualSaturation = Maths<double>.Clamp(saturation, 0, 1);
        var actualLightness = Maths<double>.Clamp(lightness, 0, 1);

        red = 0;
        green = 0;
        blue = 0;
        if (actualSaturation == 0)
        {
            red = 1;
            green = 1;
            blue = 1;
        }
        else
        {
            double q = 0;
            if (q < 0.5d)
            {
                q = actualLightness * (1 + actualSaturation);
            }
            else
            {
                q = actualLightness + actualSaturation - actualLightness * actualSaturation;
            }

            var p = 2 * actualLightness - q;
            var third = 1 / 3d;
            red = GetHslColourComponent(p, q, actualHue + third);
            green = GetHslColourComponent(p, q, actualHue);
            blue = GetHslColourComponent(p, q, actualHue - third);
        }
    }

    /// <summary>
    ///     Converts HSL color values to RGB byte values.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="lightness">The lightness component of the color (0-1).</param>
    /// <param name="red">The red component of the color as a byte.</param>
    /// <param name="green">The green component of the color as a byte.</param>
    /// <param name="blue">The blue component of the color as a byte.</param>
    public static void ConvertHslToRgb(int hue, double saturation, double lightness, out byte red, out byte green,
        out byte blue)
    {
        ConvertHslToRgb(hue, saturation, lightness, out var r, out var g, out double b);
        red = Maths<byte>.PercentageToByte(r);
        green = Maths<byte>.PercentageToByte(g);
        blue = Maths<byte>.PercentageToByte(b);
    }

    /// <summary>
    ///     Converts HSL color values to a tuple of RGB double values.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="lightness">The lightness component of the color (0-1).</param>
    /// <returns>A tuple containing the red, green, and blue components of the color as doubles.</returns>
    public static (double red, double green, double blue) ConvertHslToRgb(int hue, double saturation, double lightness)
    {
        ConvertHslToRgb(hue, saturation, lightness, out var red, out var green, out double blue);
        return (red, green, blue);
    }

    /// <summary>
    ///     Converts HSL color values to a tuple of RGB byte values.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="lightness">The lightness component of the color (0-1).</param>
    /// <returns>A tuple containing the red, green, and blue components of the color as bytes.</returns>
    public static (byte red, byte green, byte blue) ConvertHslToRgbBytes(int hue, double saturation, double lightness)
    {
        ConvertHslToRgb(hue, saturation, lightness, out var red, out var green, out byte blue);
        return (red, green, blue);
    }

    /// <summary>
    ///     Converts RGB byte values to a tuple of HSL color values.
    /// </summary>
    /// <param name="red">The red component of the color as a byte.</param>
    /// <param name="green">The green component of the color as a byte.</param>
    /// <param name="blue">The blue component of the color as a byte.</param>
    /// <returns>A tuple containing the hue, saturation, and lightness components of the color.</returns>
    public static (int hue, double saturation, double lightness) ConvertRgbToHsl(byte red, byte green, byte blue)
    {
        ConvertRgbToHsl(red, green, blue, out var hue, out var saturation, out var lightness);
        return (hue, saturation, lightness);
    }

    /// <summary>
    ///     Converts RGB double values to a tuple of HSL color values.
    /// </summary>
    /// <param name="red">The red component of the color as a double.</param>
    /// <param name="green">The green component of the color as a double.</param>
    /// <param name="blue">The blue component of the color as a double.</param>
    /// <returns>A tuple containing the hue, saturation, and lightness components of the color.</returns>
    public static (int hue, double saturation, double lightness) ConvertRgbToHsl(double red, double green, double blue)
    {
        ConvertRgbToHsl(red, green, blue, out var hue, out var saturation, out var lightness);
        return (hue, saturation, lightness);
    }

    /// <summary>
    ///     Converts RGB byte values to HSL color values.
    /// </summary>
    /// <param name="red">The red component of the color as a byte.</param>
    /// <param name="green">The green component of the color as a byte.</param>
    /// <param name="blue">The blue component of the color as a byte.</param>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="lightness">The lightness component of the color (0-1).</param>
    public static void ConvertRgbToHsl(byte red, byte green, byte blue, out int hue, out double saturation,
        out double lightness)
    {
        var r = red / 255d;
        var g = green / 255d;
        var b = blue / 255d;

        ConvertRgbToHsl(r, g, b, out hue, out saturation, out lightness);
    }

    /// <summary>
    ///     Converts RGB double values to HSL color values.
    /// </summary>
    /// <param name="red">The red component of the color as a double.</param>
    /// <param name="green">The green component of the color as a double.</param>
    /// <param name="blue">The blue component of the color as a double.</param>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="lightness">The lightness component of the color (0-1).</param>
    public static void ConvertRgbToHsl(double red, double green, double blue, out int hue, out double saturation,
        out double lightness)
    {
        var min = Maths<double>.Minimum(red, green, blue);
        var max = Maths<double>.Maximum(red, green, blue);
        var delta = max - min;
        var minMaxSum = min + max;
        lightness = minMaxSum / 2d;
        if (lightness <= 0)
        {
            hue = 0;
            saturation = 0;
            lightness = 0;
            return;
        }

        double h = 0;
        if (delta == 0)
        {
            saturation = 0;
        }
        else
        {
            if (lightness < 0.5)
            {
                saturation = delta / minMaxSum;
            }
            else
            {
                saturation = delta / (2 - delta);
            }

            if (red == max)
            {
                h = (green - blue) / 6 / delta;
            }
            else if (green == max)
            {
                h = 1 / 3d + (blue - red) / 6 / delta;
            }
            else
            {
                h = 2 / 3d + (red - green) / 6 / delta;
            }

            if (h < 0)
            {
                h += 1;
            }

            if (h > 1)
            {
                h -= 1;
            }
        }

        hue = (int)Math.Round(h * 360);
    }

    /// <summary>
    ///     Gets the HSL color component.
    /// </summary>
    /// <param name="p">The first parameter.</param>
    /// <param name="q">The second parameter.</param>
    /// <param name="t">The third parameter.</param>
    /// <returns>The HSL color component.</returns>
    private static double GetHslColourComponent(double p, double q, double t)
    {
        var actualT = t;
        if (actualT < 0)
        {
            actualT += 1;
        }

        if (actualT > 1)
        {
            actualT -= 1;
        }

        if (actualT < 1d / 6)
        {
            return p + (q - p) * 6 * actualT;
        }

        if (actualT < 1d / 2)
        {
            return q;
        }

        if (actualT < 2d / 3)
        {
            return p + (q - p) * (2d / 3 - actualT) * 6;
        }

        return p;
    }
}
