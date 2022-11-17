/// <file>
/// Velentr.Math\FixedPointMath\Precision6\FPL6Vector3.cs
/// </file>
///
/// <copyright file="FPL6Vector3.cs" company="MyCompany.com">
/// Copyright (c) 2022 MyCompany.com. All rights reserved.
/// </copyright>
///
/// <summary>
/// Implements the fpl 6 vector 3 class.
/// </summary>

namespace Velentr.Core.Helpers.Math.FixedPointMath.Precision6
{
    /// <summary>
    ///     A fpl 6 vector 3.
    /// </summary>
    public struct FPL6Vector3
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
        ///     A FPL6 to process.
        /// </summary>
        public FPL6 Z;

        /// <summary>
        ///     Creates a new FPL6Vector3.
        /// </summary>
        /// <param name="X">    A FPL6 to process. </param>
        /// <param name="Y">    A FPL6 to process. </param>
        /// <param name="Z">    A FPL6 to process. </param>
        /// <returns>
        ///     A FPL6Vector3.
        /// </returns>
        public static FPL6Vector3 Create(FPL6 X, FPL6 Y, FPL6 Z)
        {
            FPL6Vector3 result;
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
        ///     A FPL6Vector3.
        /// </returns>
        public static FPL6Vector3 Add(FPL6Vector3 inputA, FPL6Vector3 inputB)
        {
            FPL6Vector3 result;
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
        ///     A FPL6Vector3.
        /// </returns>
        public static FPL6Vector3 Subtract(FPL6Vector3 inputA, FPL6Vector3 inputB)
        {
            FPL6Vector3 result;
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
        ///     A FPL6Vector3.
        /// </returns>
        public static FPL6Vector3 Multiply(FPL6Vector3 inputA, FPL6Vector3 inputB)
        {
            FPL6Vector3 result;
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
        ///     A FPL6Vector3.
        /// </returns>
        public static FPL6Vector3 Divide(FPL6Vector3 inputA, FPL6Vector3 inputB)
        {
            FPL6Vector3 result;
            result.X = inputA.X / inputB.X;
            result.Y = inputA.Y / inputB.Y;
            result.Z = inputA.Z / inputB.Z;

            return result;
        }
    }
}
