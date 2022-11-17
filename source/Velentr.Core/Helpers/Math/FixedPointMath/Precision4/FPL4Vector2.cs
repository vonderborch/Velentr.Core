/// <file>
/// Velentr.Math\FixedPointMath\Precision4\FPL4Vector2.cs
/// </file>
///
/// <copyright file="FPL4Vector2.cs" company="MyCompany.com">
/// Copyright (c) 2022 MyCompany.com. All rights reserved.
/// </copyright>
///
/// <summary>
/// Implements the fpl 4 vector 2 class.
/// </summary>

namespace Velentr.Core.Helpers.Math.FixedPointMath.Precision4
{
    /// <summary>
    ///     A fpl 4 vector 2.
    /// </summary>
    public struct FPL4Vector2
    {
        /// <summary>
        ///     A FPL4 to process.
        /// </summary>
        public FPL4 X;

        /// <summary>
        ///     A FPL4 to process.
        /// </summary>
        public FPL4 Y;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="X">    A FPL4 to process. </param>
        /// <param name="Y">    A FPL4 to process. </param>
        public FPL4Vector2(FPL4 X, FPL4 Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        ///     Creates a new FPL4Vector2.
        /// </summary>
        /// <param name="X">    A FPL4 to process. </param>
        /// <param name="Y">    A FPL4 to process. </param>
        /// <returns>
        ///     A FPL4Vector2.
        /// </returns>
        public static FPL4Vector2 Create(FPL4 X, FPL4 Y)
        {
            FPL4Vector2 result;
            result.X = X;
            result.Y = Y;

            return result;
        }

        /// <summary>
        ///     Adds inputA.
        /// </summary>
        /// <param name="inputA">   The input a. </param>
        /// <param name="inputB">   The input b. </param>
        /// <returns>
        ///     A FPL4Vector2.
        /// </returns>
        public static FPL4Vector2 Add(FPL4Vector2 inputA, FPL4Vector2 inputB)
        {
            FPL4Vector2 result;
            result.X = inputA.X + inputB.X;
            result.Y = inputA.Y + inputB.Y;

            return result;
        }

        /// <summary>
        ///     Subtracts.
        /// </summary>
        /// <param name="inputA">   The input a. </param>
        /// <param name="inputB">   The input b. </param>
        /// <returns>
        ///     A FPL4Vector2.
        /// </returns>
        public static FPL4Vector2 Subtract(FPL4Vector2 inputA, FPL4Vector2 inputB)
        {
            FPL4Vector2 result;
            result.X = inputA.X - inputB.X;
            result.Y = inputA.Y - inputB.Y;

            return result;
        }

        /// <summary>
        ///     Multiplies.
        /// </summary>
        /// <param name="inputA">   The input a. </param>
        /// <param name="inputB">   The input b. </param>
        /// <returns>
        ///     A FPL4Vector2.
        /// </returns>
        public static FPL4Vector2 Multiply(FPL4Vector2 inputA, FPL4Vector2 inputB)
        {
            FPL4Vector2 result;
            result.X = inputA.X * inputB.X;
            result.Y = inputA.Y * inputB.Y;

            return result;
        }

        /// <summary>
        ///     Divides.
        /// </summary>
        /// <param name="inputA">   The input a. </param>
        /// <param name="inputB">   The input b. </param>
        /// <returns>
        ///     A FPL4Vector2.
        /// </returns>
        public static FPL4Vector2 Divide(FPL4Vector2 inputA, FPL4Vector2 inputB)
        {
            FPL4Vector2 result;
            result.X = inputA.X / inputB.X;
            result.Y = inputA.Y / inputB.Y;

            return result;
        }
    }
}
