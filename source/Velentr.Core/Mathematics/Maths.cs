using System.Numerics;

namespace Velentr.Core.Mathematics;

public static class Maths<T> where T : INumber<T>
{
    public static T Min(params T[] values)
    {
        T min = values[0];
        for (int i = 1; i < values.Length; i++)
        {
            if (values[i] < min)
            {
                min = values[i];
            }
        }

        return min;
    }
}