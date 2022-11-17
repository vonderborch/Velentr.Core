namespace Velentr.Core.Helpers.DataStructures
{
    /// <summary>
    ///     Helpers when dealing with Arrays.
    /// </summary>
    public static class ArrayHelpers
    {
        /// <summary>
        ///     Convert 1 d array to 2D array.
        /// </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="baseArray">    Array of bases. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        /// <returns>
        ///     The 1 converted d array to 2D array.
        /// </returns>
        public static T[,] Convert1DArrayTo2DArray<T>(T[] baseArray, int width, int height)
        {
            var array = new T[width, height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    array[x, y] = baseArray[x + y * width];
                }
            }

            return array;
        }

        /// <summary>
        ///     Convert 2D array to 1 d array.
        /// </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="baseArray">    Array of bases. </param>
        /// <param name="width">        The width. </param>
        /// <param name="height">       The height. </param>
        /// <returns>
        ///     The 2D converted array to 1 d array.
        /// </returns>
        public static T[] Convert2DArrayTo1DArray<T>(T[,] baseArray, int width, int height)
        {
            var array = new T[width * height];

            var i = 0;
            var xMax = baseArray.GetUpperBound(0);
            var yMax = baseArray.GetUpperBound(1);
            for (var x = 0; x < xMax; x++)
            {
                for (var y = 0; y < yMax; y++)
                {
                    array[i++] = baseArray[x, y];
                }
            }

            return array;
        }
    }
}
