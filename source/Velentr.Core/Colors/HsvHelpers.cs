using Velentr.Core.Mathematics;
using Velentr.Core.Validation;

namespace Velentr.Core.Colors;

/// <summary>
/// Provides helper methods for converting between RGB and HSV color spaces.
/// </summary>
public static class HsvHelpers
{
    /// <summary>
    /// Converts HSV color values to RGB color values.
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
        
        double actualHue = Maths<double>.CircularClamp(hue, 0, 360);
        double actualSaturation = Maths<double>.Clamp(saturation, 0, 1);
        double actualValue = Maths<double>.Clamp(value, 0, 1);

        red = 0;
        green = 0;
        blue = 0;
        if(actualSaturation == 0)
        {
            red = actualValue;
            green = actualValue;
            blue = actualValue;
        }
        else if(actualValue > 0)
        {
            double hf = actualHue / 60d;
            int i = (int)hf;
            double f = hf - i;
            double pv = actualValue * (1 - actualSaturation);
            double qv = actualValue * (1 - actualSaturation * f);
            double tv = actualValue * (1 - actualSaturation * (1 - f));
            switch(i)
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
    /// Converts HSV color values to RGB color values.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="value">The value component of the color (0-1).</param>
    /// <param name="red">The red component of the color (0-255).</param>
    /// <param name="green">The green component of the color (0-255).</param>
    /// <param name="blue">The blue component of the color (0-255).</param>
    public static void ConvertHsvToRgb(double hue, double saturation, double value, out byte red, out byte green, out byte blue)
    {
        ConvertHsvToRgb(hue, saturation, value, out double r, out double g, out double b);

        red = Maths<byte>.PercentageToByte(r);
        green = Maths<byte>.PercentageToByte(g);
        blue = Maths<byte>.PercentageToByte(b);
    }
    
    /// <summary>
    /// Converts HSV color values to RGB color values and returns them as a tuple.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="value">The value component of the color (0-1).</param>
    /// <returns>A tuple containing the red, green, and blue components of the color (0-1).</returns>
    public static (double red, double green, double blue) ConvertHsvToRgb(double hue, double saturation, double value)
    {
        ConvertHsvToRgb(hue, saturation, value, out double red, out double green, out double blue);
        return (red, green, blue);
    }
    
    /// <summary>
    /// Converts HSV color values to RGB color values and returns them as a tuple of bytes.
    /// </summary>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="value">The value component of the color (0-1).</param>
    /// <returns>A tuple containing the red, green, and blue components of the color (0-255).</returns>
    public static (byte red, byte green, byte blue) ConvertHsvToRgbBytes(double hue, double saturation, double value)
    {
        ConvertHsvToRgb(hue, saturation, value, out byte red, out byte green, out byte blue);
        return (red, green, blue);
    }

    public static void ConvertRgbToHsv(byte red, byte green, byte blue, out double hue, out double saturation,
        out double value)
    {
        double r = red / 255d;
        double g = green / 255d;
        double b = blue / 255d;
        ConvertRgbToHsv(r, g, b, out hue, out saturation, out value);
    }
    
    /// <summary>
    /// Converts RGB color values to HSV color values.
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
        double min = Maths<double>.Minimum(red, green, blue);
        double max = Maths<double>.Maximum(red, green, blue);
        double delta = max - min;
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
    /// Converts RGB color values to HSV color values.
    /// </summary>
    /// <param name="red">The red component of the color (0-1).</param>
    /// <param name="green">The green component of the color (0-1).</param>
    /// <param name="blue">The blue component of the color (0-1).</param>
    /// <param name="hue">The hue component of the color (0-360).</param>
    /// <param name="saturation">The saturation component of the color (0-1).</param>
    /// <param name="value">The value component of the color (0-1).</param>
    public static (double hue, double saturation, double value) ConvertRgbToHsv(double red, double green, double blue)
    {
        ConvertRgbToHsv(red, green, blue, out double hue, out double saturation, out double value);
        return (hue, saturation, value);
    }
    
    /// <summary>
    /// Converts RGB color values to HSV color values and returns them as a tuple.
    /// </summary>
    /// <param name="red">The red component of the color (0-1).</param>
    /// <param name="green">The green component of the color (0-1).</param>
    /// <param name="blue">The blue component of the color (0-1).</param>
    /// <returns>A tuple containing the hue, saturation, and value components of the color (0-360, 0-1, 0-1).</returns>
    public static (double hue, double saturation, double value) ConvertRgbToHsv(byte red, byte green, byte blue)
    {
        ConvertRgbToHsv(red, green, blue, out double hue, out double saturation, out double value);
        return (hue, saturation, value);
    }
}
