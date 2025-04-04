namespace Velentr.Core.Mathematics;
    
    /// <summary>
    /// Provides extension methods for floating-point mathematical operations.
    /// </summary>
    public static class FloatingMathsExtensions
    {
        /// <summary>
        /// Determines if two float numbers are approximately equal within a specified maximum difference.
        /// </summary>
        /// <param name="a">The first float number.</param>
        /// <param name="b">The second float number.</param>
        /// <param name="maxDifference">The maximum allowable difference between the two numbers. Default is 0.0001f.</param>
        /// <returns>True if the numbers are approximately equal, otherwise false.</returns>
        public static bool ApproximatelyEqualTo(this float a, float b, float maxDifference = 0.0001f)
        {
            return FloatingMaths<float>.ApproximatelyEqual(a, b, maxDifference);
        }
    
        /// <summary>
        /// Determines if two double numbers are approximately equal within a specified maximum difference.
        /// </summary>
        /// <param name="a">The first double number.</param>
        /// <param name="b">The second double number.</param>
        /// <param name="maxDifference">The maximum allowable difference between the two numbers. Default is 0.0001d.</param>
        /// <returns>True if the numbers are approximately equal, otherwise false.</returns>
        public static bool ApproximatelyEqualTo(this double a, double b, double maxDifference = 0.0001d)
        {
            return FloatingMaths<double>.ApproximatelyEqual(a, b, maxDifference);
        }
    }