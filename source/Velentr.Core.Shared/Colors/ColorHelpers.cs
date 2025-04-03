using Velentr.Core.Mathematics;
using Velentr.Core.Validation;
using Velentr.Helpers.Strings;

namespace Velentr.Core.FNA.Colors;

/// <summary>
/// Provides helper methods for color-related calculations.
/// </summary>
public class ColorHelpers
{
    public static bool ColorMeetsMinHslThreshold(Microsoft.Xna.Framework.Color? color, int hue, float saturation, float lightness, float alpha)
    {
        return ColorMeetsMinThreshold(color, GenerateColorFromHsl(hue, saturation, lightness, alpha));
    }

    public static bool ColorMeetsMinHsvThreshold(Microsoft.Xna.Framework.Color? color, int hue, float saturation, float value, float alpha)
    {
        return ColorMeetsMinThreshold(color, GenerateColorFromHsv(hue, saturation, value, alpha));
    }

    public static bool ColorMeetsMinThreshold(Microsoft.Xna.Framework.Color? color, byte r, byte g, byte b, byte a)
    {
        if (color == null)
        {
            return false;
        }

        return color.Value.R <= r && color.Value.G <= g && color.Value.B <= b && color.Value.A <= a;
    }

    public static bool ColorMeetsMinThreshold(Microsoft.Xna.Framework.Color? color, Microsoft.Xna.Framework.Color minColor)
    {
        if (color == null)
        {
            return false;
        }

        return color.Value.R <= minColor.R && color.Value.G <= minColor.G && color.Value.B <= minColor.B && color.Value.A <= minColor.A;
    }

    public static Microsoft.Xna.Framework.Color GenerateColorFromHsl(int hue, float saturation, float lightness, float alpha)
    {
        ConvertHslToRgb(hue, saturation, lightness, out byte r, out byte g, out byte b);

        return new Microsoft.Xna.Framework.Color(r, g, b, alpha);
    }

    public static Microsoft.Xna.Framework.Color GenerateColorFromHsv(int hue, float saturation, float value, float alpha)
    {
        ConvertHsvToRgb(hue, saturation, value, out byte r, out byte g, out byte b);
        
        return new Microsoft.Xna.Framework.Color(r, g, b, alpha);
    }
    
    private static readonly string[] HEX_REPLACEMENTS = { "#", "0x", "0X", " " };

    private const double TSL_LIGHTNESS_R_COMPONENT = 0.299d;

    private const double TSL_LIGHTNESS_R_RGB_COMPONENT = 0.185d;

    private const double TSL_LIGHTNESS_G_COMPONENT = 0.587d;

    private const double TSL_LIGHTNESS_G_RGB_COMPONENT = 0.473d;

    private const double TSL_LIGHTNESS_B_COMPONENT = 0.114d;

    public static void ConvertHexToRgb(string hex, out byte red, out byte green, out byte blue)
    {
        string cleanedHexCode = hex.ReplaceAny(string.Empty, HEX_REPLACEMENTS);
        int hexColor = Convert.ToInt32(cleanedHexCode, 16);
        int r = (hexColor >> 16) & 0xFF;
        int g = (hexColor >> 8) & 0xFF;
        int b = hexColor & 0xFF;

        red = (byte)Maths<int>.Clamp(r, 0, 255);
        green = (byte)Maths<int>.Clamp(g, 0, 255);
        blue = (byte)Maths<int>.Clamp(b, 0, 255);
    }

    public static void ConvertHexToHsl(string hex, out int hue, out double saturation, out double lightness)
    {
        ConvertHexToRgb(hex, out byte red, out byte green, out byte blue);
        ConvertRgbToHsl(red, green, blue, out hue, out saturation, out lightness);
    }

    public static void ConvertHexToHsv(string hex, out int hue, out double saturation, out double value)
    {
        ConvertHexToRgb(hex, out byte red, out byte green, out byte blue);
        ConvertRgbToHsv(red, green, blue, out hue, out saturation, out value);
    }

    public static void ConvertHexToTsl(string hex, out double tint, out double saturation, out double lightness)
    {
        ConvertHexToRgb(hex, out byte red, out byte green, out byte blue);
        ConvertRgbToTsl(red, green, blue, out tint, out saturation, out lightness);
    }

    public static void ConvertHslToRgb(int hue, double saturation, double lightness, out byte red, out byte green, out byte blue)
    {
        Validations.ValidateRange(hue, nameof(hue), 0, 360);
        Validations.ValidateRange(saturation, nameof(saturation), 0, 1);
        Validations.ValidateRange(lightness, nameof(lightness), 0, 1);
        
        double actualHue = Maths<int>.CircularClamp(hue, 0, 360) / 360d;
        double actualSaturation = Maths<double>.Clamp(saturation, 0, 1);
        double actualLightness = Maths<double>.Clamp(lightness, 0, 1);

        double r = 0;
        double g = 0;
        double b = 0;
        if(actualSaturation == 0)
        {
            r = 1;
            g = 1;
            b = 1;
        }
        else
        {
            double q = 0;
            if(q < 0.5d)
            {
                q = actualLightness * (1 + actualSaturation);
            }
            else
            {
                q = actualLightness + actualSaturation - actualLightness * actualSaturation;
            }

            double p = 2 * actualLightness - q;
            double third = 1 / 3d;
            r = GetHslColourComponent(p, q, actualHue + third);
            g = GetHslColourComponent(p, q, actualHue);
            b = GetHslColourComponent(p, q, actualHue - third);
        }

        red = DoubleToByte(r);
        green = DoubleToByte(g);
        blue = DoubleToByte(b);
    }

    public static void ConvertHsvToRgb(int hue, double saturation, double value, out byte red, out byte green, out byte blue)
    {
        Validations.ValidateRange(hue, nameof(hue), 0, 360);
        Validations.ValidateRange(saturation, nameof(saturation), 0, 1);
        Validations.ValidateRange(value, nameof(value), 0, 1);
        
        double actualHue = Maths<double>.CircularClamp(hue, 0, 360);
        double actualSaturation = Maths<double>.Clamp(saturation, 0, 1);
        double actualValue = Maths<double>.Clamp(value, 0, 1);

        double r = 0;
        double g = 0;
        double b = 0;
        if(actualSaturation == 0)
        {
            r = actualValue;
            g = actualValue;
            b = actualValue;
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
                    r = actualValue;
                    g = tv;
                    b = pv;
                    break;

                case 5:
                    r = actualValue;
                    g = pv;
                    b = qv;
                    break;

                // Green is dominant
                case 1:
                    r = qv;
                    g = actualValue;
                    b = pv;
                    break;

                case 2:
                    r = pv;
                    g = actualValue;
                    b = tv;
                    break;

                // Blue is dominant
                case 3:
                    r = pv;
                    g = qv;
                    b = actualValue;
                    break;

                case 4:
                    r = tv;
                    g = pv;
                    b = actualValue;
                    break;

                // Boundary Protection
                case 6:
                    r = actualValue;
                    g = tv;
                    b = pv;
                    break;

                case -1:
                    r = actualValue;
                    g = pv;
                    b = qv;
                    break;

                default:
                    r = actualValue;
                    g = actualValue;
                    b = actualValue;
                    break;
            }
        }

        red = DoubleToByte(r);
        green = DoubleToByte(g);
        blue = DoubleToByte(b);
    }

    public static void ConvertRgbToHsl(byte red, byte green, byte blue, out int hue, out double saturation, out double lightness)
    {
        double r = red / 255d;
        double g = green / 255d;
        double b = blue / 255d;

        double min = Maths<double>.Minimum(r, g, b);
        double max = Maths<double>.Maximum(r, g, b);
        double delta = max - min;
        double minMaxSum = min + max;
        lightness = minMaxSum / 2d;
        if(lightness <= 0)
        {
            hue = 0;
            saturation = 0;
            lightness = 0;
            return;
        }

        double h = 0;
        if(delta == 0)
        {
            saturation = 0;
        }
        else
        {
            if(lightness < 0.5)
            {
                saturation = delta / minMaxSum;
            }
            else
            {
                saturation = delta / (2 - delta);
            }

            if(r == max)
            {
                h = (g - b) / 6 / delta;
            }
            else if(g == max)
            {
                h = (1 / 3d) + ((b - r) / 6 / delta);
            }
            else
            {
                h = (2 / 3d) + ((r - g) / 6 / delta);
            }

            if(h < 0)
            {
                h += 1;
            }
            if(h > 1)
            {
                h -= 1;
            }
        }

        hue = (int)Math.Round(h * 360);
    }

    public static void ConvertRgbToHsv(byte red, byte green, byte blue, out int hue, out double saturation, out double value)
    {
        double r = red / 255d;
        double g = green / 255d;
        double b = blue / 255d;

        double min = Maths<double>.Minimum(r, g, b);
        double max = Maths<double>.Maximum(r, g, b);
        double delta = max - min;
        value = max;

        double h = 0;
        if(max == 0)
        {
            saturation = 0;
        }
        else
        {
            saturation = delta / max;

            if(r == max)
            {
                h = (g - b) / delta;
            }
            else if(g == max)
            {
                h = 2 + (b - r) / delta;
            }
            else
            {
                h = 4 + (r - g) / delta;
            }

            h *= 60;
            if(h < 0)
            {
                h += 360;
            }
        }

        hue = (int)Math.Round(h);
    }

    public static void ConvertRgbToTsl(byte red, byte green, byte blue, out double tint, out double saturation, out double lightness)
    {
        if(red + green + blue == 0)
        {
            tint = 0;
            saturation = 0;
            lightness = 0;
            return;
        }
        double redPercentage = red / 255d;
        double greenPercentage = green / 255d;
        double bluePercentage = blue / 255d;
        double totalPercentage = redPercentage + greenPercentage + bluePercentage;

        double r = redPercentage / totalPercentage;
        double g = greenPercentage / totalPercentage;
        double rPrime = r - (1 / 3d);
        double rPrimeSquared = rPrime * rPrime;
        double gPrime = g - (1 / 3d);
        double gPrimeSquared = gPrime * gPrime;

        // Calculate the tint
        if(ApproximatelyEqual(gPrime, 0, 0.0001))
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
        double redComponent = TSL_LIGHTNESS_R_COMPONENT * redPercentage;
        double greenComponent = TSL_LIGHTNESS_G_COMPONENT * greenPercentage;
        double blueComponent = TSL_LIGHTNESS_B_COMPONENT * bluePercentage;
        lightness = redComponent + greenComponent + blueComponent;
    }

    public static void ConvertTslToRgb(double tint, double saturation, double lightness, out byte red, out byte green, out byte blue)
    {
        if(ApproximatelyEqual(lightness, 0, 0.0001))
        {
            red = 0;
            green = 0;
            blue = 0;
            return;
        }

        double rPrime = 0;
        double gPrime = 0;
        if(IsNegativeZero(tint))
        {
            rPrime = -Math.Sqrt(5d) / 3d * saturation;
        }
        else if(ApproximatelyEqual(tint, 0, 0.0001))
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

        double redDouble = k * r;
        double greenDouble = k * g;
        double blueDouble = k * b;

        red = DoubleToByte(redDouble);
        green = DoubleToByte(greenDouble);
        blue = DoubleToByte(blueDouble);
    }

    private static bool ApproximatelyEqual(double a, double b, double maxDifference)
    {
        double difference = Math.Abs(a - b);
        return difference <= maxDifference;
    }

    private static byte DoubleToByte(double value)
    {
        if(value < 0)
        {
            return byte.MinValue;
        }
        if(value > 1)
        {
            return byte.MaxValue;
        }
        byte output = (byte)Math.Round(value * byte.MaxValue);
        return output;
    }

    private static double GetHslColourComponent(double p, double q, double t)
    {
        double actualT = t;
        if(actualT < 0)
        {
            actualT += 1;
        }
        if(actualT > 1)
        {
            actualT -= 1;
        }
        if(actualT < 1d / 6)
        {
            return p + (q - p) * 6 * actualT;
        }
        if(actualT < 1d / 2)
        {
            return q;
        }
        if(actualT < 2d / 3)
        {
            return p + (q - p) * (2d / 3 - actualT) * 6;
        }
        return p;
    }

    private static bool IsNegativeZero(double x)
    {
        return ApproximatelyEqual(x, 0, 0.0001) && double.IsNegativeInfinity(1d / x);
    }
}