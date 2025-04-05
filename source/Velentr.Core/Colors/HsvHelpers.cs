using Velentr.Core.Mathematics;
using Velentr.Core.Validation;

namespace Velentr.Core.Colors;

/// <summary>
///     Provides helper methods for converting between RGB and HSV color spaces.
/// </summary>
public static class HsvHelpers
{
    /// <summary>
    ///     Converts HSV color values to RGB color values.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="value">The value component of the color (0-1).</param>
    /// <param name="red">The red component of the color (0-1).</param>
    /// <param name="green">The green component of the color (0-1).</param>
    /// <param name="blue">The blue component of the color (0-1).</param>
    public static void ConvertHsvToRgb(double hue, double saturation, double value, out double red, out double green,
        out double blue)
    {
        Validations.ValidateRange(hue, nameof(hue), 0, 360);
        Validations.ValidateRange(saturation, nameof(saturation), 0, 1);
        Validations.ValidateRange(value, nameof(value), 0, 1);

        var actualHue = Maths<double>.CircularClamp(hue, 0, 360);
        var actualSaturation = Maths<double>.Clamp(saturation, 0, 1);
        var actualValue = Maths<double>.Clamp(value, 0, 1);

        red = 0;
        green = 0;
        blue = 0;
        if (actualSaturation == 0)
        {
            red = actualValue;
            green = actualValue;
            blue = actualValue;
        }
        else if (actualValue > 0)
        {
            var hf = actualHue / 60d;
            var i = (int)hf;
            var f = hf - i;
            var pv = actualValue * (1 - actualSaturation);
            var qv = actualValue * (1 - actualSaturation * f);
            var tv = actualValue * (1 - actualSaturation * (1 - f));
            switch (i)
            {
                // Red is dominant
                case 0:
                    red = actualValue;
                    green = tv;
                    blue = pv;
                    break;

                case 5:
                    red = actualValue;
                    green = pv;
                    blue = qv;
                    break;

                // Green is dominant
                case 1:
                    red = qv;
                    green = actualValue;
                    blue = pv;
                    break;

                case 2:
                    red = pv;
                    green = actualValue;
                    blue = tv;
                    break;

                // Blue is dominant
                case 3:
                    red = pv;
                    green = qv;
                    blue = actualValue;
                    break;

                case 4:
                    red = tv;
                    green = pv;
                    blue = actualValue;
                    break;

                // Boundary Protection
                case 6:
                    red = actualValue;
                    green = tv;
                    blue = pv;
                    break;

                case -1:
                    red = actualValue;
                    green = pv;
                    blue = qv;
                    break;

                default:
                    red = actualValue;
                    green = actualValue;
                    blue = actualValue;
                    break;
            }
        }
    }

    /// <summary>
    ///     Converts HSV color values to RGB color values.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="value">The value component of the color (0-1).</param>
    /// <param name="red">The red component of the color (0-255).</param>
    /// <param name="green">The green component of the color (0-255).</param>
    /// <param name="blue">The blue component of the color (0-255).</param>
    public static void ConvertHsvToRgb(double hue, double saturation, double value, out byte red, out byte green,
        out byte blue)
    {
        ConvertHsvToRgb(hue, saturation, value, out var r, out var g, out double b);

        red = FloatingMaths<double>.PercentageToByte(r);
        green = FloatingMaths<double>.PercentageToByte(g);
        blue = FloatingMaths<double>.PercentageToByte(b);
    }

    /// <summary>
    ///     Converts HSV color values to RGB color values and returns them as a tuple.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="value">The value component of the color (0-1).</param>
    /// <returns>A tuple containing the red, green, and blue components of the color (0-1).</returns>
    public static (double red, double green, double blue) ConvertHsvToRgb(double hue, double saturation, double value)
    {
        ConvertHsvToRgb(hue, saturation, value, out var red, out var green, out double blue);
        return (red, green, blue);
    }

    /// <summary>
    ///     Converts HSV color values to RGB color values and returns them as a tuple of bytes.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="value">The value component of the color (0-1).</param>
    /// <returns>A tuple containing the red, green, and blue components of the color (0-255).</returns>
    public static (byte red, byte green, byte blue) ConvertHsvToRgbBytes(double hue, double saturation, double value)
    {
        ConvertHsvToRgb(hue, saturation, value, out var red, out var green, out byte blue);
        return (red, green, blue);
    }

    public static void ConvertRgbToHsv(byte red, byte green, byte blue, out double hue, out double saturation,
        out double value)
    {
        var r = red / 255d;
        var g = green / 255d;
        var b = blue / 255d;
        ConvertRgbToHsv(r, g, b, out hue, out saturation, out value);
    }

    /// <summary>
    ///     Converts RGB color values to HSV color values.
    /// </summary>
    /// <param name="red">The red component of the color (0-255).</param>
    /// <param name="green">The green component of the color (0-255).</param>
    /// <param name="blue">The blue component of the color (0-255).</param>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="value">The value component of the color (0-1).</param>
    public static void ConvertRgbToHsv(double red, double green, double blue, out double hue, out double saturation,
        out double value)
    {
        var min = Maths<double>.Minimum(red, green, blue);
        var max = Maths<double>.Maximum(red, green, blue);
        var delta = max - min;
        value = max;

        double h = 0;
        if (max == 0)
        {
            saturation = 0;
        }
        else
        {
            saturation = delta / max;

            if (red == max)
            {
                h = (green - blue) / delta;
            }
            else if (green == max)
            {
                h = 2 + (blue - red) / delta;
            }
            else
            {
                h = 4 + (red - green) / delta;
            }

            h *= 60;
            if (h < 0)
            {
                h += 360;
            }
        }

        if (double.IsNaN(h))
        {
            hue = 0;
        }
        else
        {
            hue = h;
        }
    }

    /// <summary>
    ///     Converts RGB color values to HSV color values.
    /// </summary>
    /// <param name="red">The red component of the color (0-1).</param>
    /// <param name="green">The green component of the color (0-1).</param>
    /// <param name="blue">The blue component of the color (0-1).</param>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="value">The value component of the color (0-1).</param>
    public static (double hue, double saturation, double value) ConvertRgbToHsv(double red, double green, double blue)
    {
        ConvertRgbToHsv(red, green, blue, out var hue, out var saturation, out var value);
        return (hue, saturation, value);
    }

    /// <summary>
    ///     Converts RGB color values to HSV color values and returns them as a tuple.
    /// </summary>
    /// <param name="red">The red component of the color (0-1).</param>
    /// <param name="green">The green component of the color (0-1).</param>
    /// <param name="blue">The blue component of the color (0-1).</param>
    /// <returns>A tuple containing the hue, saturation, and value components of the color (0-360, 0-1, 0-1).</returns>
    public static (double hue, double saturation, double value) ConvertRgbToHsv(byte red, byte green, byte blue)
    {
        ConvertRgbToHsv(red, green, blue, out var hue, out var saturation, out var value);
        return (hue, saturation, value);
    }
}
