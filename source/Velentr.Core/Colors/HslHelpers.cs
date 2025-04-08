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
    public static void ConvertHslToRgb(double hue, double saturation, double lightness, out double red,
        out double green,
        out double blue)
    {
        Validations.ValidateRange(hue, nameof(hue), 0, 360);
        Validations.ValidateRange(saturation, nameof(saturation), 0, 1);
        Validations.ValidateRange(lightness, nameof(lightness), 0, 1);

        hue = Maths<double>.CircularClamp(hue, 0, 360);
        saturation = Maths<double>.Clamp(saturation, 0, 1);
        lightness = Maths<double>.Clamp(lightness, 0, 1);

        red = 0;
        green = 0;
        blue = 0;
        if (saturation == 0)
        {
            red = green = blue = lightness; // achromatic
        }
        else
        {
            var q = lightness < 0.5 ? lightness * (1 + saturation) : lightness + saturation - lightness * saturation;
            var p = 2 * lightness - q;
            var hk = hue / 360.0;

            var t = new double[3];
            t[0] = hk + 1.0 / 3.0; // red
            t[1] = hk; // green
            t[2] = hk - 1.0 / 3.0; // blue

            for (var i = 0; i < 3; i++)
            {
                if (t[i] < 0)
                {
                    t[i] += 1;
                }

                if (t[i] > 1)
                {
                    t[i] -= 1;
                }

                if (t[i] < 1.0 / 6.0)
                {
                    t[i] = p + (q - p) * 6 * t[i];
                }
                else if (t[i] < 1.0 / 2.0)
                {
                    t[i] = q;
                }
                else if (t[i] < 2.0 / 3.0)
                {
                    t[i] = p + (q - p) * (2.0 / 3.0 - t[i]) * 6;
                }
                else
                {
                    t[i] = p;
                }
            }

            red = t[0];
            green = t[1];
            blue = t[2];
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
    public static void ConvertHslToRgb(double hue, double saturation, double lightness, out byte red, out byte green,
        out byte blue)
    {
        ConvertHslToRgb(hue, saturation, lightness, out var r, out var g, out double b);
        red = FloatingMaths<double>.PercentageToByte(r);
        green = FloatingMaths<double>.PercentageToByte(g);
        blue = FloatingMaths<double>.PercentageToByte(b);
    }

    /// <summary>
    ///     Converts HSL color values to a tuple of RGB double values.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="lightness">The lightness component of the color (0-1).</param>
    /// <returns>A tuple containing the red, green, and blue components of the color as doubles.</returns>
    public static (double red, double green, double blue) ConvertHslToRgb(double hue, double saturation,
        double lightness)
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
    public static (byte red, byte green, byte blue) ConvertHslToRgbBytes(double hue, double saturation,
        double lightness)
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
    public static (double hue, double saturation, double lightness) ConvertRgbToHsl(byte red, byte green, byte blue)
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
    public static (double hue, double saturation, double lightness) ConvertRgbToHsl(double red, double green,
        double blue)
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
    public static void ConvertRgbToHsl(byte red, byte green, byte blue, out double hue, out double saturation,
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
    public static void ConvertRgbToHsl(double red, double green, double blue, out double hue, out double saturation,
        out double lightness)
    {
        var min = Maths<double>.Minimum(red, green, blue);
        var max = Maths<double>.Maximum(red, green, blue);
        var delta = max - min;

        lightness = (max + min) / 2.0;

        if (delta == 0)
        {
            hue = 0;
            saturation = 0;
        }
        else
        {
            saturation = lightness < 0.5 ? delta / (max + min) : delta / (2.0 - max - min);

            if (red == max)
            {
                hue = 60 * ((green - blue) / delta % 6);
            }
            else if (green == max)
            {
                hue = 60 * ((blue - red) / delta + 2);
            }
            else
            {
                hue = 60 * ((red - green) / delta + 4);
            }

            if (hue < 0)
            {
                hue += 360;
            }
        }
    }
}
