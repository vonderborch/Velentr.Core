namespace Velentr.Core.DataStructures;

/// <summary>
///     Provides helper methods for converting between 1D and 2D arrays.
/// </summary>
public static class ArrayHelpers
{
    /// <summary>
    ///     Converts a 1D array to a 2D array with the specified width and height.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="baseArray">The 1D array to convert.</param>
    /// <param name="width">The width of the 2D array.</param>
    /// <param name="height">The height of the 2D array.</param>
    /// <returns>A 2D array containing the elements of the 1D array.</returns>
    public static T[,] Convert1DArrayTo2DArray<T>(T[] baseArray, int width, int height)
    {
        if (baseArray.Length != width * height)
        {
            throw new ArgumentException("The provided dimensions do not match the length of the 1D array.");
        }

        T[,]? array = new T[width, height];
        Buffer.BlockCopy(baseArray, 0, array, 0, Buffer.ByteLength(baseArray));
        return array;
    }

    /// <summary>
    ///     Converts a 2D array to a 1D array with the specified width and height.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="baseArray">The 2D array to convert.</param>
    /// <param name="height">The height of the 2D array.</param>
    /// <returns>A 1D array containing the elements of the 2D array.</returns>
    public static T[] Convert2DArrayTo1DArray<T>(T[,] baseArray, int width, int height)
    {
        if (baseArray.GetLength(0) != width || baseArray.GetLength(1) != height)
        {
            throw new ArgumentException("The provided dimensions do not match the actual dimensions of the 2D array.");
        }

        T[] array = new T[width * height];
        Buffer.BlockCopy(baseArray, 0, array, 0, Buffer.ByteLength(baseArray));
        return array;
    }

    /// <summary>
    ///     Converts a 2D array to a 1D array with the specified width and height.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="baseArray">The 2D array to convert.</param>
    /// <param name="width">The width of the 2D array.</param>
    /// <param name="height">The height of the 2D array.</param>
    /// <returns>A 1D array containing the elements of the 2D array.</returns>
    public static T[] ConvertTo1DArray<T>(this T[,] baseArray, int width, int height)
    {
        return Convert2DArrayTo1DArray(baseArray, width, height);
    }

    /// <summary>
    ///     Converts a 1D array to a 2D array with the specified width and height.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="baseArray">The 1D array to convert.</param>
    /// <param name="width">The width of the 2D array.</param>
    /// <param name="height">The height of the 2D array.</param>
    /// <returns>A 2D array containing the elements of the 1D array.</returns>
    public static T[,] ConvertTo2DArray<T>(this T[] baseArray, int width, int height)
    {
        return Convert1DArrayTo2DArray(baseArray, width, height);
    }
}
