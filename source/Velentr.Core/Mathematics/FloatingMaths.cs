using System.Numerics;

namespace Velentr.Core.Mathematics;

public static class FloatingMaths<T> where T : IFloatingPoint<T>
{
    private static readonly T TwoFiftyFive = T.CreateChecked(255);
    
    public static bool ApproximatelyEqual(T a, T b, T maxDifference)
    {
        var difference = T.Abs(a - b);
        return difference <= maxDifference;
    }
    
    public static bool IsNegativeZero(T x, T maxDifference)
    {
        return ApproximatelyEqual(x, T.Zero, maxDifference) && T.IsNegativeInfinity(T.One / x);
    }
    
    public static T ByteToPercentage(byte value)
    {
        return T.One / TwoFiftyFive * T.CreateChecked(value);
    }
    
    public static byte PercentageToByte(T value)
    {
        T actualValue = T.Round(value * TwoFiftyFive);
        if (actualValue >= TwoFiftyFive)
        {
            return byte.MaxValue;
        }
        if (actualValue <= T.Zero)
        {
            return byte.MinValue;
        }

        byte final = byte.CreateChecked(actualValue);
        return final;
    }
}
