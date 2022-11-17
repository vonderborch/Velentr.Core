/// <file>
/// Velentr.Math\FixedPointMath\Precision4\FPL4Vector3.cs
/// </file>
///
/// <copyright file="FPL4Vector3.cs" company="MyCompany.com">
/// Copyright (c) 2022 MyCompany.com. All rights reserved.
/// </copyright>
///
/// <summary>
/// Implements the fpl 4 vector 3 class.
/// </summary>

namespace Velentr.Core.Helpers.Math.FixedPointMath.Precision4
{
    /// <summary>
    ///     A fpl 4 vector 3.
    /// </summary>
    public struct FPL4Vector3
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
        ///     A FPL4 to process.
        /// </summary>
        public FPL4 Z;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="X">    A FPL4 to process. </param>
        /// <param name="Y">    A FPL4 to process. </param>
        /// <param name="Z">    A FPL4 to process. </param>
        public FPL4Vector3(FPL4 X, FPL4 Y, FPL4 Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        /// <summary>
        ///     Creates a new FPL4Vector3.
        /// </summary>
        /// <param name="X">    A FPL4 to process. </param>
        /// <param name="Y">    A FPL4 to process. </param>
        /// <param name="Z">    A FPL4 to process. </param>
        /// <returns>
        ///     A FPL4Vector3.
        /// </returns>
        public static FPL4Vector3 Create(FPL4 X, FPL4 Y, FPL4 Z)
        {
            FPL4Vector3 result;
            result.X = X;
            result.Y = Y;
            result.Z = Z;

            return result;
        }

        /// <summary>
        ///     Adds inputA.
        /// </summary>
        /// <param name="inputA">   The input a. </param>
        /// <param name="inputB">   The input b. </param>
        /// <returns>
        ///     A FPL4Vector3.
        /// </returns>
        public static FPL4Vector3 Add(FPL4Vector3 inputA, FPL4Vector3 inputB)
        {
            FPL4Vector3 result;
            result.X = inputA.X + inputB.X;
            result.Y = inputA.Y + inputB.Y;
            result.Z = inputA.Z + inputB.Z;

            return result;
        }

        /// <summary>
        ///     Subtracts.
        /// </summary>
        /// <param name="inputA">   The input a. </param>
        /// <param name="inputB">   The input b. </param>
        /// <returns>
        ///     A FPL4Vector3.
        /// </returns>
        public static FPL4Vector3 Subtract(FPL4Vector3 inputA, FPL4Vector3 inputB)
        {
            FPL4Vector3 result;
            result.X = inputA.X - inputB.X;
            result.Y = inputA.Y - inputB.Y;
            result.Z = inputA.Z - inputB.Z;

            return result;
        }

        /// <summary>
        ///     Multiplies.
        /// </summary>
        /// <param name="inputA">   The input a. </param>
        /// <param name="inputB">   The input b. </param>
        /// <returns>
        ///     A FPL4Vector3.
        /// </returns>
        public static FPL4Vector3 Multiply(FPL4Vector3 inputA, FPL4Vector3 inputB)
        {
            FPL4Vector3 result;
            result.X = inputA.X * inputB.X;
            result.Y = inputA.Y * inputB.Y;
            result.Z = inputA.Z * inputB.Z;

            return result;
        }

        /// <summary>
        ///     Divides.
        /// </summary>
        /// <param name="inputA">   The input a. </param>
        /// <param name="inputB">   The input b. </param>
        /// <returns>
        ///     A FPL4Vector3.
        /// </returns>
        public static FPL4Vector3 Divide(FPL4Vector3 inputA, FPL4Vector3 inputB)
        {
            FPL4Vector3 result;
            result.X = inputA.X / inputB.X;
            result.Y = inputA.Y / inputB.Y;
            result.Z = inputA.Z / inputB.Z;

            return result;
        }
    }
}
