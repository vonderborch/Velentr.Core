using System.Numerics;

namespace Velentr.Core.Mathematics;

/// <summary>
/// Provides mathematical helper methods for various operations.
/// </summary>
/// <typeparam name="T">The numeric type.</typeparam>
public static class Maths<T> where T : INumber<T>
{
    /// <summary>
    /// Clamps a value within a circular range.
    /// </summary>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <returns>The clamped value within the circular range.</returns>
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

    /// <summary>
    /// Clamps a value within a specified range.
    /// </summary>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <returns>The clamped value within the specified range.</returns>
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

    /// <summary>
    /// Clamps a new value based on the delta from the current value and specified delta and absolute ranges.
    /// </summary>
    /// <param name="newValue">The new value to clamp.</param>
    /// <param name="currentValue">The current value.</param>
    /// <param name="deltaMin">The minimum delta value.</param>
    /// <param name="deltamax">The maximum delta value.</param>
    /// <param name="absoluteMin">The minimum absolute value.</param>
    /// <param name="absoluteMax">The maximum absolute value.</param>
    /// <returns>The clamped value based on the delta and absolute ranges.</returns>
    public static T DeltaClamp(T newValue, T currentValue, T deltaMin, T deltamax, T absoluteMin, T absoluteMax)
    {
        var delta = newValue - currentValue;
        var realDelta = Clamp(delta, deltaMin, deltamax);
        var newActualValue = currentValue + realDelta;
        var clampedValue = Clamp(newActualValue, absoluteMin, absoluteMax);
        return clampedValue;
    }

    /// <summary>
    /// Returns the maximum value from a set of values.
    /// </summary>
    /// <param name="values">The set of values.</param>
    /// <returns>The maximum value.</returns>
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

    /// <summary>
    /// Returns the minimum value from a set of values.
    /// </summary>
    /// <param name="values">The set of values.</param>
    /// <returns>The minimum value.</returns>
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

    /// <summary>
    /// Returns the difference between the maximum and minimum values from a set of values.
    /// </summary>
    /// <param name="numbers">The set of values.</param>
    /// <returns>The difference between the maximum and minimum values.</returns>
    public static T MinMaxDelta(params T[] numbers)
    {
        var min = Minimum(numbers);
        var max = Maximum(numbers);
        var delta = max - min;
        return delta;
    }
}
