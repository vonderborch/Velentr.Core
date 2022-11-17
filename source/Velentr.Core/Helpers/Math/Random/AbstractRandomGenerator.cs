/*

Portions taken from https://www.codeproject.com/Articles/25172/Simple-Random-Number-Generation
For the marked, (JDC 2008), portions, the below license applies. For all other portions the repo license applies

License:
Copyright 2008 John D. Cook

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*/

using System;
using System.Collections.Generic;

using Velentr.Core.Helpers.Math.FixedPointMath.Precision4;
using Velentr.Core.Helpers.Math.FixedPointMath.Precision6;

namespace Velentr.Core.Helpers.Math.Random
{
    /// <summary>
    ///     An abstract random generator.
    /// </summary>
    public abstract class AbstractRandomGenerator
    {
        /// <summary>
        ///     Gets a short.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The short.
        /// </returns>
        public virtual short GetShort(short minimum = short.MinValue, short maximum = short.MaxValue)
        {
            return Convert.ToInt16(GetNormal() * (maximum - minimum) + minimum);
        }

        /// <summary>
        ///     Gets u short.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The u short.
        /// </returns>
        public virtual ushort GetUShort(ushort minimum = ushort.MinValue, ushort maximum = ushort.MaxValue)
        {
            return Convert.ToUInt16(GetNormal() * (maximum - minimum) + minimum);
        }

        /// <summary>
        ///     Gets a byte.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The byte.
        /// </returns>
        public virtual byte GetByte(byte minimum = byte.MinValue, byte maximum = byte.MaxValue)
        {
            return Convert.ToByte(GetNormal() * (maximum - minimum) + minimum);
        }

        /// <summary>
        ///     Gets the bool.
        /// </summary>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public virtual bool GetBool()
        {
            return GetUniform() < 0.5d;
        }

        /// <summary>
        ///     Gets u int.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The u int.
        /// </returns>
        public virtual uint GetUInt(uint minimum = uint.MinValue, uint maximum = uint.MaxValue)
        {
            return Convert.ToUInt32(GetNormal() * (maximum - minimum) + minimum);
        }

        /// <summary>
        ///     Gets an int.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The int.
        /// </returns>
        public virtual int GetInt(int minimum = int.MinValue, int maximum = int.MaxValue)
        {
            return Convert.ToInt32(GetNormal() * (maximum - minimum) + minimum);
        }

        /// <summary>
        ///     Gets a long.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The long.
        /// </returns>
        public virtual long GetLong(long minimum = long.MinValue, long maximum = long.MaxValue)
        {
            return Convert.ToInt64(GetNormal() * (maximum - minimum) + minimum);
        }

        /// <summary>
        ///     Gets u long.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The u long.
        /// </returns>
        public virtual ulong GetULong(ulong minimum = ulong.MinValue, ulong maximum = ulong.MaxValue)
        {
            return Convert.ToUInt64(GetNormal() * (maximum - minimum) + minimum);
        }

        /// <summary>
        ///     Gets a double.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The double.
        /// </returns>
        public virtual double GetDouble(double minimum = double.MinValue, double maximum = double.MaxValue)
        {
            return Convert.ToDouble(GetNormal() * (maximum - minimum) + minimum);
        }

        /// <summary>
        ///     Gets a float.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The float.
        /// </returns>
        public virtual float GetFloat(float minimum = float.MinValue, float maximum = float.MaxValue)
        {
            return (float) Convert.ToDouble(GetNormal() * (maximum - minimum) + minimum);
        }

        /// <summary>
        ///     Gets fpl 4.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The fpl 4.
        /// </returns>
        public FPL4 GetFPL4(FPL4? minimum = null, FPL4? maximum = null)
        {
            minimum = minimum ?? FPL4.MinValue;
            maximum = maximum ?? FPL4.MaxValue;

            return Convert.ToDouble((GetNormal() * ((FPL4) maximum - (FPL4) minimum) + (FPL4) minimum).ToString());
        }

        /// <summary>
        ///     Gets fpl 6.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The fpl 6.
        /// </returns>
        public FPL6 GetFPL6(FPL6? minimum = null, FPL6? maximum = null)
        {
            minimum = minimum ?? FPL6.MinValue;
            maximum = maximum ?? FPL6.MaxValue;

            return Convert.ToDouble((GetNormal() * ((FPL6) maximum - (FPL6) minimum) + (FPL6) minimum).ToString());
        }

        /// <summary>
        ///     Produce a uniform random sample from the open interval (0, 1). The method will not return
        ///     either end point.
        /// </summary>
        /// <returns>
        ///     A random number between 0 and 1.
        /// </returns>
        public double GetUniform()
        {
            // 0 <= u < 2^32
            var u = GetUInt();

            // The magic number below is 1/(2^32 + 2).
            // The result is strictly between 0 and 1.
            return (u + 1.0) * 2.328306435454494e-10;
        }

        /// <summary>
        ///     Get normal (Gaussian) random sample with specified mean and standard deviation.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one or more arguments are outside
        ///     the required range.
        /// </exception>
        /// <param name="mean">                 (Optional) </param>
        /// <param name="standardDeviation">    (Optional) </param>
        /// <returns>
        ///     The normal.
        /// </returns>
        public double GetNormal(double mean = 0, double standardDeviation = 1)
        {
            if (standardDeviation <= 0.0)
            {
                throw new ArgumentOutOfRangeException($"Shape must be positive. Received {standardDeviation}.");
            }

            var u1 = GetUniform();
            var u2 = GetUniform();
            var r = System.Math.Sqrt(-2.0 * System.Math.Log(u1));
            var theta = 2.0 * System.Math.PI * u2;

            return mean + standardDeviation * r * System.Math.Sin(theta);
        }

        /// <summary>
        ///     Get exponential random sample with specified mean.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one or more arguments are outside
        ///     the required range.
        /// </exception>
        /// <param name="mean"> (Optional) </param>
        /// <returns>
        ///     The exponential.
        /// </returns>
        public double GetExponential(double mean = 1)
        {
            if (mean <= 0.0)
            {
                var msg = string.Format("Mean must be positive. Received {0}.", mean);

                throw new ArgumentOutOfRangeException(msg);
            }

            return mean * -System.Math.Log(GetUniform());
        }

        /// <summary>
        ///     Implementation based on "A Simple Method for Generating Gamma Variables" by George Marsaglia
        ///     and Wai Wan Tsang.  ACM Transactions on Mathematical Software Vol 26, No 3, September 2000,
        ///     pages 363-372.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one or more arguments are outside
        ///     the required range.
        /// </exception>
        /// <param name="shape">    . </param>
        /// <param name="scale">    . </param>
        /// <returns>
        ///     The gamma.
        /// </returns>
        public double GetGamma(double shape, double scale)
        {
            if (shape <= 0.0)
            {
                throw new ArgumentOutOfRangeException($"Shape must be positive. Received {shape}.");
            }

            double d, c, x, xsquared, v, u;

            if (shape >= 1.0)
            {
                d = shape - 1.0 / 3.0;
                c = 1.0 / System.Math.Sqrt(9.0 * d);
                for (;;)
                {
                    do
                    {
                        x = GetNormal();
                        v = 1.0 + c * x;
                    } while (v <= 0.0);

                    v = v * v * v;
                    u = GetUniform();
                    xsquared = x * x;
                    if (u < 1.0 - .0331 * xsquared * xsquared || System.Math.Log(u) < 0.5 * xsquared + d * (1.0 - v + System.Math.Log(v)))
                    {
                        return scale * d * v;
                    }
                }
            }

            var g = GetGamma(shape + 1.0, 1.0);
            var w = GetUniform();

            return scale * g * System.Math.Pow(w, 1.0 / shape);
        }

        /// <summary>
        ///     A chi squared distribution with n degrees of freedom is a gamma distribution with shape n/2
        ///     and scale 2.
        /// </summary>
        /// <param name="degreesOfFreedom"> . </param>
        /// <returns>
        ///     The chi square.
        /// </returns>
        public double GetChiSquare(double degreesOfFreedom)
        {
            return GetGamma(0.5 * degreesOfFreedom, 2.0);
        }

        /// <summary>
        ///     If X is gamma(shape, scale) then
        ///     1/Y is inverse gamma(shape, 1/scale)
        /// </summary>
        /// <param name="shape">    . </param>
        /// <param name="scale">    . </param>
        /// <returns>
        ///     The inverse gamma.
        /// </returns>
        public double GetInverseGamma(double shape, double scale)
        {
            return 1.0 / GetGamma(shape, 1.0 / scale);
        }

        /// <summary>
        ///     Gets a weibull.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one or more arguments are outside
        ///     the required range.
        /// </exception>
        /// <param name="shape">    . </param>
        /// <param name="scale">    . </param>
        /// <returns>
        ///     The weibull.
        /// </returns>
        public double GetWeibull(double shape, double scale)
        {
            if (shape <= 0.0 || scale <= 0.0)
            {
                throw new ArgumentOutOfRangeException($"Shape and scale parameters must be positive. Recieved shape {shape} and scale {scale}.");
            }

            return scale * System.Math.Pow(-System.Math.Log(GetUniform()), 1.0 / shape);
        }

        /// <summary>
        ///     Gets a cauchy.
        /// </summary>
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or
        ///     illegal values.
        /// </exception>
        /// <param name="median">   . </param>
        /// <param name="scale">    . </param>
        /// <returns>
        ///     The cauchy.
        /// </returns>
        public double GetCauchy(double median, double scale)
        {
            if (scale <= 0)
            {
                throw new ArgumentException($"Scale must be positive. Received {scale}.");
            }

            var p = GetUniform();

            // Apply inverse of the Cauchy distribution function to a uniform
            return median + scale * System.Math.Tan(System.Math.PI * (p - 0.5));
        }

        /// <summary>
        ///     See Seminumerical Algorithms by Knuth.
        /// </summary>
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or
        ///     illegal values.
        /// </exception>
        /// <param name="degreesOfFreedom"> . </param>
        /// <returns>
        ///     The student.
        /// </returns>
        public double GetStudentT(double degreesOfFreedom)
        {
            if (degreesOfFreedom <= 0)
            {
                throw new ArgumentException($"Degrees of freedom must be positive. Received {degreesOfFreedom}.");
            }

            var y1 = GetNormal();
            var y2 = GetChiSquare(degreesOfFreedom);

            return y1 / System.Math.Sqrt(y2 / degreesOfFreedom);
        }

        /// <summary>
        ///     The Laplace distribution is also known as the double exponential distribution.
        /// </summary>
        /// <param name="mean">     . </param>
        /// <param name="scale">    . </param>
        /// <returns>
        ///     The laplace.
        /// </returns>
        public double GetLaplace(double mean, double scale)
        {
            var u = GetUniform();

            return u < 0.5 ? mean + scale * System.Math.Log(2.0 * u) : mean - scale * System.Math.Log(2 * (1 - u));
        }

        /// <summary>
        ///     Get a random normally distributed log.
        /// </summary>
        /// <param name="mu">       . </param>
        /// <param name="sigma">    . </param>
        /// <returns>
        ///     The log normal.
        /// </returns>
        public double GetLogNormal(double mu, double sigma)
        {
            return System.Math.Exp(GetNormal(mu, sigma));
        }

        /// <summary>
        ///     Generate a beta sample.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one or more arguments are outside
        ///     the required range.
        /// </exception>
        /// <param name="a">    . </param>
        /// <param name="b">    . </param>
        /// <returns>
        ///     The beta.
        /// </returns>
        public double GetBeta(double a, double b)
        {
            if (a <= 0.0 || b <= 0.0)
            {
                throw new ArgumentOutOfRangeException($"Beta parameters must be positive. Received {a} and {b}.");
            }

            // There are more efficient methods for generating beta samples.
            // However such methods are a little more efficient and much more complicated.
            // For an explanation of why the following method works, see
            // http://www.johndcook.com/distribution_chart.html#gamma_beta

            var u = GetGamma(a, 1.0);
            var v = GetGamma(b, 1.0);

            return u / (u + v);
        }

        /// <summary>
        ///     Advance a certain number of steps in the random generator.
        /// </summary>
        /// <param name="steps">    The number of steps to advance. </param>
        public void Advance(uint steps)
        {
            for (var i = 0; i < steps; i++)
            {
                GetInt();
            }
        }

        /// <summary>
        ///     Returns the results of a coin flip, where Heads is True and Tails is False.
        /// </summary>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public bool GetCoinFlip()
        {
            return GetBool();
        }

        /// <summary>
        ///     Gets coin flips.
        /// </summary>
        /// <param name="number">   . </param>
        /// <returns>
        ///     The coin flips.
        /// </returns>
        public List<bool> GetCoinFlips(uint number)
        {
            var output = new List<bool>();

            for (var i = 0; i < number; i++)
            {
                output.Add(GetBool());
            }

            return output;
        }

        /// <summary>
        ///     Gets coin flip results.
        /// </summary>
        /// <param name="number">   . </param>
        /// <returns>
        ///     The coin flip results.
        /// </returns>
        public Tuple<int, int> GetCoinFlipResults(uint number)
        {
            var heads = 0;
            var tails = 0;

            for (var i = 0; i < number; i++)
            {
                var result = GetBool();
                if (result)
                {
                    heads++;
                }
                else
                {
                    tails++;
                }
            }

            return new Tuple<int, int>(heads, tails);
        }

        /// <summary>
        ///     Gets dice roll.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one or more arguments are outside
        ///     the required range.
        /// </exception>
        /// <param name="faces">        The faces. </param>
        /// <param name="numberOfDie">  Number of dies. </param>
        /// <returns>
        ///     The dice roll.
        /// </returns>
        public int GetDiceRoll(int faces, int numberOfDie)
        {
            if (faces == 0 || numberOfDie == 0)
            {
                return 0;
            }

            if (numberOfDie < 0 || faces < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(numberOfDie)} and {nameof(faces)} must be at least 0. Provided numberOfDie={numberOfDie} and faces={faces}");
            }

            var total = 0;
            for (var i = 0; i < numberOfDie; i++)
            {
                total += GetInt(0, faces);
            }

            return total;
        }

        /// <summary>
        ///     Gets dice roll per dice.
        /// </summary>
        /// <param name="faces">        The faces. </param>
        /// <param name="numberOfDie">  Number of dies. </param>
        /// <returns>
        ///     The dice roll per dice.
        /// </returns>
        public List<int> GetDiceRollPerDice(int faces, int numberOfDie)
        {
            var rolls = new List<int>();
            for (var i = 0; i < numberOfDie; i++)
            {
                rolls.Add(GetDiceRoll(faces, numberOfDie));
            }

            return rolls;
        }

        /// <summary>
        ///     Gets d 6.
        /// </summary>
        /// <param name="numberOfDie">  Number of dies. </param>
        /// <returns>
        ///     The d 6.
        /// </returns>
        public int GetD6(int numberOfDie)
        {
            return GetDiceRoll(6, numberOfDie);
        }

        /// <summary>
        ///     Gets d 8.
        /// </summary>
        /// <param name="numberOfDie">  Number of dies. </param>
        /// <returns>
        ///     The d 8.
        /// </returns>
        public int GetD8(int numberOfDie)
        {
            return GetDiceRoll(8, numberOfDie);
        }

        /// <summary>
        ///     Gets d 10.
        /// </summary>
        /// <param name="numberOfDie">  Number of dies. </param>
        /// <returns>
        ///     The d 10.
        /// </returns>
        public int GetD10(int numberOfDie)
        {
            return GetDiceRoll(10, numberOfDie);
        }

        /// <summary>
        ///     Gets d 12.
        /// </summary>
        /// <param name="numberOfDie">  Number of dies. </param>
        /// <returns>
        ///     The d 12.
        /// </returns>
        public int GetD12(int numberOfDie)
        {
            return GetDiceRoll(12, numberOfDie);
        }

        /// <summary>
        ///     Gets d 20.
        /// </summary>
        /// <param name="numberOfDie">  Number of dies. </param>
        /// <returns>
        ///     The d 20.
        /// </returns>
        public int GetD20(int numberOfDie)
        {
            return GetDiceRoll(20, numberOfDie);
        }

        /// <summary>
        ///     Gets d 25.
        /// </summary>
        /// <param name="numberOfDie">  Number of dies. </param>
        /// <returns>
        ///     The d 25.
        /// </returns>
        public int GetD25(int numberOfDie)
        {
            return GetDiceRoll(25, numberOfDie);
        }

        /// <summary>
        ///     Gets d 99.
        /// </summary>
        /// <param name="numberOfDie">  Number of dies. </param>
        /// <returns>
        ///     The d 99.
        /// </returns>
        public int GetD99(int numberOfDie)
        {
            return GetDiceRoll(99, numberOfDie);
        }
    }
}
