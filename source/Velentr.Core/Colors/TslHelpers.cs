using Velentr.Core.Mathematics;

namespace Velentr.Core.Colors;

/// <summary>
/// Provides helper methods for converting between RGB and TSL color models.
/// </summary>
public static class TslHelpers
{
    private const double MaxTslDifference = 0.0001d;
    
    private const double TSL_LIGHTNESS_R_COMPONENT = 0.299d;

    private const double TSL_LIGHTNESS_R_RGB_COMPONENT = 0.185d;

    private const double TSL_LIGHTNESS_G_COMPONENT = 0.587d;

    private const double TSL_LIGHTNESS_G_RGB_COMPONENT = 0.473d;

    private const double TSL_LIGHTNESS_B_COMPONENT = 0.114d;
    
    /// <summary>
    /// Converts RGB color values to TSL color values.
    /// </summary>
    /// <param name="red">The red component of the color (0.0 to 1.0).</param>
    /// <param name="green">The green component of the color (0.0 to 1.0).</param>
    /// <param name="blue">The blue component of the color (0.0 to 1.0).</param>
    /// <param name="tint">The resulting tint value.</param>
    /// <param name="saturation">The resulting saturation value.</param>
    /// <param name="lightness">The resulting lightness value.</param>
    public static void ConvertRgbToTsl(double red, double green, double blue, out double tint, out double saturation, out double lightness)
    {
        if(red + green + blue == 0)
        {
            tint = 0;
            saturation = 0;
            lightness = 0;
            return;
        }
        double totalPercentage = red + green + blue;

        double r = red / totalPercentage;
        double g = green / totalPercentage;
        double rPrime = r - (1 / 3d);
        double rPrimeSquared = rPrime * rPrime;
        double gPrime = g - (1 / 3d);
        double gPrimeSquared = gPrime * gPrime;

        // Calculate the tint
        if(Maths<double>.ApproximatelyEqual(gPrime, 0, MaxTslDifference))
        {
            tint = 0;
        }
        else
        {
            tint = 0.5 - (Math.Atan2(gPrime, rPrime) / (2 * Math.PI));
        }

        // Calculate the saturation
        saturation = Math.Sqrt((9 / 5d) * (rPrimeSquared + gPrimeSquared));

        // Calculate the lightness
        double redComponent = TSL_LIGHTNESS_R_COMPONENT * red;
        double greenComponent = TSL_LIGHTNESS_G_COMPONENT * green;
        double blueComponent = TSL_LIGHTNESS_B_COMPONENT * blue;
        lightness = redComponent + greenComponent + blueComponent;
    }
    
    /// <summary>
    /// Converts RGB color values to TSL color values.
    /// </summary>
    /// <param name="red">The red component of the color (0 to 255).</param>
    /// <param name="green">The green component of the color (0 to 255).</param>
    /// <param name="blue">The blue component of the color (0 to 255).</param>
    /// <param name="tint">The resulting tint value.</param>
    /// <param name="saturation">The resulting saturation value.</param>
    /// <param name="lightness">The resulting lightness value.</param>
    public static void ConvertRgbToTsl(byte red, byte green, byte blue, out double tint, out double saturation, out double lightness)
    {
        double redPercentage = red / 255d;
        double greenPercentage = green / 255d;
        double bluePercentage = blue / 255d;
        ConvertRgbToTsl(redPercentage, greenPercentage, bluePercentage, out tint, out saturation, out lightness);
    }
    
    /// <summary>
    /// Converts RGB color values to TSL color values.
    /// </summary>
    /// <param name="red">The red component of the color (0 to 255).</param>
    /// <param name="green">The green component of the color (0 to 255).</param>
    /// <param name="blue">The blue component of the color (0 to 255).</param>
    /// <returns>A tuple containing the tint, saturation, and lightness values.</returns>
    public static (double tint, double saturation, double lightness) ConvertRgbToTsl(byte red, byte green, byte blue)
    {
        ConvertRgbToTsl(red, green, blue, out var tint, out var saturation, out var lightness);
        return (tint, saturation, lightness);
    }
    
    /// <summary>
    /// Converts RGB color values to TSL color values.
    /// </summary>
    /// <param name="red">The red component of the color (0.0 to 1.0).</param>
    /// <param name="green">The green component of the color (0.0 to 1.0).</param>
    /// <param name="blue">The blue component of the color (0.0 to 1.0).</param>
    /// <returns>A tuple containing the tint, saturation, and lightness values.</returns>
    public static (double tint, double saturation, double lightness) ConvertRgbToTsl(double red, double green, double blue)
    {
        ConvertRgbToTsl(red, green, blue, out var tint, out var saturation, out var lightness);
        return (tint, saturation, lightness);
    }

    /// <summary>
    /// Converts TSL color values to RGB color values.
    /// </summary>
    /// <param name="tint">The tint value.</param>
    /// <param name="saturation">The saturation value.</param>
    /// <param name="lightness">The lightness value.</param>
    /// <param name="red">The resulting red component of the color (0.0 to 1.0).</param>
    /// <param name="green">The resulting green component of the color (0.0 to 1.0).</param>
    /// <param name="blue">The resulting blue component of the color (0.0 to 1.0).</param>
    public static void ConvertTslToRgb(double tint, double saturation, double lightness, out double red, out double green, out double blue)
    {
        if(Maths<double>.ApproximatelyEqual(lightness, 0, MaxTslDifference))
        {
            red = 0;
            green = 0;
            blue = 0;
            return;
        }

        double rPrime = 0;
        double gPrime = 0;
        if(Maths<double>.IsNegativeZero(tint, MaxTslDifference))
        {
            rPrime = -Math.Sqrt(5d) / 3d * saturation;
        }
        else if(Maths<double>.ApproximatelyEqual(tint, 0, MaxTslDifference))
        {
            rPrime = Math.Sqrt(5d) / 3d * saturation;
        }
        else
        {
            double x = -1d / Math.Tan(2 * Math.PI * tint);
            gPrime = Math.Sqrt(5d / (1 + x * x)) / 3d * saturation;
            if(tint > 0.5)
            {
                gPrime = -gPrime;
            }
            rPrime = x * gPrime;
        }

        double r = rPrime + 1 / 3d;
        double g = gPrime + 1 / 3d;
        double b = 1 - r - g;
        double kRed = TSL_LIGHTNESS_R_RGB_COMPONENT * r;
        double kGreen = TSL_LIGHTNESS_G_RGB_COMPONENT * g;
        double k = lightness / (kRed + kGreen + TSL_LIGHTNESS_B_COMPONENT);

        red = k * r;
        green = k * g;
        blue = k * b;
    }
    
    /// <summary>
    /// Converts TSL color values to RGB color values.
    /// </summary>
    /// <param name="tint">The tint value.</param>
    /// <param name="saturation">The saturation value.</param>
    /// <param name="lightness">The lightness value.</param>
    /// <returns>A tuple containing the red, green, and blue components of the color (0.0 to 1.0).</returns>
    public static (double red, double green, double blue) ConvertTslToRgb(double tint, double saturation, double lightness)
    {
        ConvertTslToRgb(tint, saturation, lightness, out double red, out double green, out double blue);
        return (red, green, blue);
    }
    
    /// <summary>
    /// Converts TSL color values to RGB color values.
    /// </summary>
    /// <param name="tint">The tint value.</param>
    /// <param name="saturation">The saturation value.</param>
    /// <param name="lightness">The lightness value.</param>
    /// <param name="red">The resulting red component of the color (0 to 255).</param>
    /// <param name="green">The resulting green component of the color (0 to 255).</param>
    /// <param name="blue">The resulting blue component of the color (0 to 255).</param>
    public static void ConvertTslToRgb(double tint, double saturation, double lightness, out byte red, out byte green, out byte blue)
    {
        ConvertTslToRgb(tint, saturation, lightness, out double r, out double g, out double b);
        red = Maths<byte>.PercentageToByte(r);
        green = Maths<byte>.PercentageToByte(g);
        blue = Maths<byte>.PercentageToByte(b);
    }
    
    /// <summary>
    /// Converts TSL color values to RGB color values.
    /// </summary>
    /// <param name="tint">The tint value.</param>
    /// <param name="saturation">The saturation value.</param>
    /// <param name="lightness">The lightness value.</param>
    /// <returns>A tuple containing the red, green, and blue components of the color (0 to 255).</returns>
    public static (byte red, byte green, byte blue) ConvertTslToRgbBytes(double tint, double saturation, double lightness)
    {
        ConvertTslToRgb(tint, saturation, lightness, out byte red, out byte green, out byte blue);
        return (red, green, blue);
    }
}
