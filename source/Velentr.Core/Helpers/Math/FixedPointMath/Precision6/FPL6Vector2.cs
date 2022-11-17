/// <file>
/// Velentr.Math\FixedPointMath\Precision6\FPL6Vector2.cs
/// </file>
///
/// <copyright file="FPL6Vector2.cs" company="MyCompany.com">
/// Copyright (c) 2022 MyCompany.com. All rights reserved.
/// </copyright>
///
/// <summary>
/// Implements the fpl 6 vector 2 class.
/// </summary>

namespace Velentr.Core.Helpers.Math.FixedPointMath.Precision6
{
    /// <summary>
    ///     A fpl 6 vector 2.
    /// </summary>
    public struct FPL6Vector2
    {
        /// <summary>
        ///     A FPL6 to process.
        /// </summary>
        public FPL6 X;

        /// <summary>
        ///     A FPL6 to process.
        /// </summary>
        public FPL6 Y;

        /// <summary>
        ///     Creates a new FPL6Vector2.
        /// </summary>
        /// <param name="X">    A FPL6 to process. </param>
        /// <param name="Y">    A FPL6 to process. </param>
        /// <returns>
        ///     A FPL6Vector2.
        /// </returns>
        public static FPL6Vector2 Create(FPL6 X, FPL6 Y)
        {
            FPL6Vector2 result;
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
        ///     A FPL6Vector2.
        /// </returns>
        public static FPL6Vector2 Add(FPL6Vector2 inputA, FPL6Vector2 inputB)
        {
            FPL6Vector2 result;
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
        ///     A FPL6Vector2.
        /// </returns>
        public static FPL6Vector2 Subtract(FPL6Vector2 inputA, FPL6Vector2 inputB)
        {
            FPL6Vector2 result;
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
        ///     A FPL6Vector2.
        /// </returns>
        public static FPL6Vector2 Multiply(FPL6Vector2 inputA, FPL6Vector2 inputB)
        {
            FPL6Vector2 result;
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
        ///     A FPL6Vector2.
        /// </returns>
        public static FPL6Vector2 Divide(FPL6Vector2 inputA, FPL6Vector2 inputB)
        {
            FPL6Vector2 result;
            result.X = inputA.X / inputB.X;
            result.Y = inputA.Y / inputB.Y;

            return result;
        }
    }
}
