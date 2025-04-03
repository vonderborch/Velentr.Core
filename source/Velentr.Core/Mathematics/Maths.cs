using System.Numerics;

namespace Velentr.Core.Mathematics;

public static class Maths<T> where T : INumber<T>
{
    public static bool ApproximatelyEqual(double a, double b, double maxDifference)
    {
        var difference = Math.Abs(a - b);
        return difference <= maxDifference;
    }

    public static bool ApproximatelyEqual(float a, float b, float maxDifference)
    {
        var difference = Math.Abs(a - b);
        return difference <= maxDifference;
    }

    public static double ByteToDoublePercentage(byte value)
    {
        return value / 255.0d;
    }

    public static float ByteToFloatPercentage(byte value)
    {
        return value / 255.0f;
    }

    public static T CircularClamp(T value, T min, T max)
    {
        var actualValue = value;

        var (actualMin, actualMax) = (min, max);
        if (min > max)
        {
            (actualMin, actualMax) = (max, min);
        }

        if (value >= actualMin && value < actualMax)
        {
            return value;
        }

        var negativeCorrection = T.Zero;
        if (min < T.Zero)
        {
            negativeCorrection = min;
            actualMin = T.Zero;
            actualMax = max - negativeCorrection;
            actualValue = value - negativeCorrection;
        }

        var difference = actualMax - actualMin;
        var remainder = actualValue % difference;

        var actualRemainder = remainder;
        if (remainder < T.Zero)
        {
            actualRemainder = remainder + difference;
        }

        var output = actualRemainder + actualMin + negativeCorrection;
        return output;
    }

    public static T Clamp(T value, T min, T max)
    {
        if (value < min)
        {
            return min;
        }

        if (value > max)
        {
            return max;
        }

        return value;
    }

    public static T DeltaClamp(T newValue, T currentValue, T deltaMin, T deltamax, T absoluteMin, T absoluteMax)
    {
        var delta = newValue - currentValue;
        var realDelta = Clamp(delta, deltaMin, deltamax);
        var newActualValue = currentValue + realDelta;
        var clampedValue = Clamp(newActualValue, absoluteMin, absoluteMax);
        return clampedValue;
    }

    public static T Maximum(params T[] values)
    {
        var max = values[0];
        for (var i = 1; i < values.Length; i++)
        {
            if (values[i] > max)
            {
                max = values[i];
            }
        }

        return max;
    }

    public static T Minimum(params T[] values)
    {
        var min = values[0];
        for (var i = 1; i < values.Length; i++)
        {
            if (values[i] < min)
            {
                min = values[i];
            }
        }

        return min;
    }

    public static T MinMaxDelta(params T[] numbers)
    {
        var min = Minimum(numbers);
        var max = Maximum(numbers);
        var delta = max - min;
        return delta;
    }

    public static byte PercentageToByte(double value)
    {
        if (value < 0)
        {
            return byte.MinValue;
        }

        if (value > 1)
        {
            return byte.MaxValue;
        }

        var output = (byte)Math.Round(value * byte.MaxValue);
        return output;
    }

    public static byte PercentageToByte(float value)
    {
        if (value < 0)
        {
            return byte.MinValue;
        }

        if (value > 1)
        {
            return byte.MaxValue;
        }

        var output = (byte)Math.Round(value * byte.MaxValue);
        return output;
    }
}
