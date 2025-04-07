/*
The MIT License (MIT)

Copyright (c) .NET Foundation and Contributors

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

/* SOURCE: https://www.codeproject.com/KB/recipes/SimpleRNG.aspx
Copyright 2008 John D. Cook

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System.Runtime.CompilerServices;
using System.Threading;
using Velentr.Core.Mathematics.FixedPoint;
using Velentr.Core.Validation;

namespace Velentr.Core.Mathematics.Random;

/// <summary>
/// Abstract base class for random number generators, based heavily on the .NET Random class, as well as John D. Cook's
/// SimpleRNG class.
/// </summary>
public abstract class ARandomGenerator : IRandomGenerator<ARandomGenerator>
{
    /// <summary>Gets all possible hex characters for the specified casing.</summary>
    protected static ReadOnlySpan<char> GetHexChoices(bool lowercase) => lowercase ? "0123456789abcdef" : "0123456789ABCDEF";

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="seed">The seed for the random number generator.</param>
    public ARandomGenerator(long seed)
    {
        this.Seed = seed;
        this.StartingSeed = seed;
        // ReSharper disable once VirtualMemberCallInConstructor
        SetSeed(seed);
    }
    
    /// <summary>
    /// Gets the current seed used for the random number generator.
    /// </summary>
    public long Seed { get; protected set; }
    
    /// <summary>
    /// Gets the starting seed used for the random number generator.
    /// </summary>
    public long StartingSeed { get; }

    /// <summary>
    /// Sets the seed for the random number generator.
    /// </summary>
    /// <param name="seed">The seed value to set.</param>
    public abstract void SetSeed(long seed);
    
    /// <summary>
    /// Returns a random unsigned integer.
    /// </summary>
    /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="uint.MaxValue"/>.</returns>
    public abstract uint NextUInt();

    /// <summary>
    /// Returns a random unsigned long integer.
    /// </summary>
    /// <returns>A 64-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ulong.MaxValue"/>.</returns>
    public abstract ulong NextULong();
    
    /// <summary>
    /// Returns a random unsigned integer that is less than the specified maximum.
    /// NextUInt algorithm based on https://arxiv.org/pdf/1805.10941.pdf and https://github.com/lemire/fastrange
    /// </summary>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated. <paramref name="maxValue"/> must be greater than 0.</param>
    /// <returns>
    /// A 32-bit unsigned integer that is greater than or equal to 0, and less than <paramref name="maxValue"/>; that is, the range of return values includes 0 but not <paramref name="maxValue"/>.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than or equal to 0.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint NextUInt(uint maxValue)
    {
        ulong randomProduct = (ulong)maxValue * NextUInt();
        uint lowPart = (uint)randomProduct;

        if (lowPart < maxValue)
        {
            uint remainder = (0u - maxValue) % maxValue;

            while (lowPart < remainder)
            {
                randomProduct = (ulong)maxValue * NextUInt();
                lowPart = (uint)randomProduct;
            }
        }

        return (uint)(randomProduct >> 32);
    }
    /// <summary>
    /// Returns a random unsigned long integer that is less than the specified maximum.
    /// NextULong algorithm based on https://arxiv.org/pdf/1805.10941.pdf and https://github.com/lemire/fastrange
    /// </summary>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated. <paramref name="maxValue"/> must be greater than 0.</param>
    /// <returns>
    /// A 64-bit unsigned integer that is greater than or equal to 0, and less than <paramref name="maxValue"/>; that is, the range of return values includes 0 but not <paramref name="maxValue"/>.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than or equal to 0.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ulong NextULong(ulong maxValue)
    {
        ulong randomProduct = Math.BigMul(maxValue, NextULong(), out ulong lowPart);

        if (lowPart < maxValue)
        {
            ulong remainder = (0ul - maxValue) % maxValue;

            while (lowPart < remainder)
            {
                randomProduct = Math.BigMul(maxValue, NextULong(), out lowPart);
            }
        }

        return randomProduct;
    }

    /// <summary>Returns a non-negative random integer.</summary>
    /// <returns>A 32-bit signed integer that is greater than or equal to 0 and less than <see cref="int.MaxValue"/>.</returns>
    public int Next()
    {
        while (true)
        {
            // Get top 31 bits to get a value in the range [0, int.MaxValue], but try again
            // if the value is actually int.MaxValue, as the method is defined to return a value
            // in the range [0, int.MaxValue).
            ulong result = NextULong() >> 33;
            if (result != int.MaxValue)
            {
                return (int)result;
            }
        }
    }
    
    /// <summary>Returns a non-negative random integer that is less than the specified maximum.</summary>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated. <paramref name="maxValue"/> must be greater than or equal to 0.</param>
    /// <returns>
    /// A 32-bit signed integer that is greater than or equal to 0, and less than <paramref name="maxValue"/>; that is, the range of return values ordinarily
    /// includes 0 but not <paramref name="maxValue"/>. However, if <paramref name="maxValue"/> equals 0, <paramref name="maxValue"/> is returned.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than 0.</exception>
    public int Next(int maxValue)
    {
        Validations.ValidateGreaterThan(maxValue, nameof(maxValue), 0);
        return (int)NextUInt((uint)maxValue);
    }
    
    /// <summary>Returns a random integer that is within a specified range.</summary>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
    /// <returns>
    /// A 32-bit signed integer greater than or equal to <paramref name="minValue"/> and less than <paramref name="maxValue"/>; that is, the range of return values includes <paramref name="minValue"/>
    /// but not <paramref name="maxValue"/>. If minValue equals <paramref name="maxValue"/>, <paramref name="minValue"/> is returned.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="minValue"/> is greater than <paramref name="maxValue"/>.</exception>
    public int Next(int minValue, int maxValue)
    {
        (minValue, maxValue) = (Math.Min(minValue, maxValue), Math.Max(minValue, maxValue));
        return (int)NextUInt((uint)(maxValue - minValue)) + minValue;
    }
    
    /// <summary>Returns a non-negative random integer.</summary>
    /// <returns>A 64-bit signed integer that is greater than or equal to 0 and less than <see cref="long.MaxValue"/>.</returns>
    public long NextLong()
    {
        while (true)
        {
            // Get top 63 bits to get a value in the range [0, long.MaxValue], but try again
            // if the value is actually long.MaxValue, as the method is defined to return a value
            // in the range [0, long.MaxValue).
            ulong result = NextULong() >> 1;
            if (result != long.MaxValue)
            {
                return (long)result;
            }
        }
    }
    
    /// <summary>Returns a non-negative random integer that is less than the specified maximum.</summary>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated. <paramref name="maxValue"/> must be greater than or equal to 0.</param>
    /// <returns>
    /// A 64-bit signed integer that is greater than or equal to 0, and less than <paramref name="maxValue"/>; that is, the range of return values ordinarily
    /// includes 0 but not <paramref name="maxValue"/>. However, if <paramref name="maxValue"/> equals 0, <paramref name="maxValue"/> is returned.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than 0.</exception>
    public long NextLong(long maxValue)
    {
        Validations.ValidateGreaterThan(maxValue, nameof(maxValue), 0L);
        return (long)NextULong((ulong)maxValue);
    }
    
    /// <summary>Returns a random integer that is within a specified range.</summary>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
    /// <returns>
    /// A 64-bit signed integer greater than or equal to <paramref name="minValue"/> and less than <paramref name="maxValue"/>; that is, the range of return values includes <paramref name="minValue"/>
    /// but not <paramref name="maxValue"/>. If minValue equals <paramref name="maxValue"/>, <paramref name="minValue"/> is returned.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="minValue"/> is greater than <paramref name="maxValue"/>.</exception>
    public long NextLong(long minValue, long maxValue)
    {
        (minValue, maxValue) = (Math.Min(minValue, maxValue), Math.Max(minValue, maxValue));
        return (long)NextULong((uint)(maxValue - minValue)) + minValue;
    }
    
    /// <summary>
    /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// As described in http://prng.di.unimi.it/:
    ///     "A standard double (32-bit) floating-point number in IEEE floating point format has 24 bits of significand,
    ///     plus an implicit bit at the left of the significand. Thus, the representation can actually store numbers
    ///     with 24 significant binary digits. Because of this fact, in C99 a 64-bit unsigned integer x should be
    ///     converted to a 32-bit double using the expression:
    ///     (x >> 11) * 0x1.0p-53"
    /// </summary>
    /// <returns>A single-precision floating point number that is greater than or equal to 0.0, and less than 1.0.</returns>
    public float NextSingle() => (NextULong() >> 40) * (1.0f / (1u << 24));
    
    /// <summary>
    /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// As described in http://prng.di.unimi.it/:
    ///     "A standard double (64-bit) floating-point number in IEEE floating point format has 52 bits of significand,
    ///     plus an implicit bit at the left of the significand. Thus, the representation can actually store numbers
    ///     with 53 significant binary digits. Because of this fact, in C99 a 64-bit unsigned integer x should be
    ///     converted to a 64-bit double using the expression:
    ///     (x >> 11) * 0x1.0p-53"
    /// </summary>
    /// <returns>A double-precision floating point number that is greater than or equal to 0.0, and less than 1.0.</returns>
    public double NextDouble() => (NextULong() >> 11) * (1.0 / (1ul << 53));
    
    /// <summary>Fills the elements of a specified array of bytes with random numbers.</summary>
    /// <param name="buffer">The array to be filled with random numbers.</param>
    public void NextBytes(byte[] buffer) => NextBytes((Span<byte>)buffer);

    /// <summary>
    /// Fills the elements of a specified span with random numbers.
    /// </summary>
    /// <param name="buffer">The span to be filled with random numbers.</param>
    public abstract void NextBytes(Span<byte> buffer);
    
    /// <summary>
    ///   Performs an in-place shuffle of an array.
    /// </summary>
    /// <param name="values">The array to shuffle.</param>
    /// <typeparam name="T">The type of array.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="values" /> is <see langword="null" />.</exception>
    /// <remarks>
    ///   This method uses <see cref="Next(int, int)" /> to choose values for shuffling.
    ///   This method is an O(n) operation.
    /// </remarks>
    public void Shuffle<T>(T[] values)
    {
        Validations.NotNullCheck(values, nameof(values));
        Shuffle(new Span<T>(values));
    }
    
    /// <summary>
    ///   Performs an in-place shuffle of a span.
    /// </summary>
    /// <param name="values">The span to shuffle.</param>
    /// <typeparam name="T">The type of span.</typeparam>
    /// <remarks>
    ///   This method uses <see cref="Next(int, int)" /> to choose values for shuffling.
    ///   This method is an O(n) operation.
    /// </remarks>
    public void Shuffle<T>(Span<T> values)
    {
        int n = values.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int j = Next(i, n);

            if (j != i)
            {
                (values[i], values[j]) = (values[j], values[i]);
            }
        }
    }
    
    /// <summary>
    ///   Creates an array populated with items chosen at random from the provided set of choices.
    /// </summary>
    /// <param name="choices">The items to use to populate the array.</param>
    /// <param name="length">The length of array to return.</param>
    /// <typeparam name="T">The type of array.</typeparam>
    /// <returns>An array populated with random items.</returns>
    /// <exception cref="ArgumentException"><paramref name="choices" /> is empty.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="choices" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///   <paramref name="length" /> is not zero or a positive number.
    /// </exception>
    /// <remarks>
    ///   The method uses <see cref="Next(int)" /> to select items randomly from <paramref name="choices" />
    ///   by index. This is used to populate a newly-created array.
    /// </remarks>
    public T[] GetItems<T>(T[] choices, int length)
    {
        return GetItems(new ReadOnlySpan<T>(choices), length);
    }
    
    /// <summary>
    ///   Creates an array populated with items chosen at random from the provided set of choices.
    /// </summary>
    /// <param name="choices">The items to use to populate the array.</param>
    /// <param name="length">The length of array to return.</param>
    /// <typeparam name="T">The type of array.</typeparam>
    /// <returns>An array populated with random items.</returns>
    /// <exception cref="ArgumentException"><paramref name="choices" /> is empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///   <paramref name="length" /> is not zero or a positive number.
    /// </exception>
    /// <remarks>
    ///   The method uses <see cref="Next(int)" /> to select items randomly from <paramref name="choices" />
    ///   by index. This is used to populate a newly-created array.
    /// </remarks>
    public T[] GetItems<T>(ReadOnlySpan<T> choices, int length)
    {
        T[] items = new T[length];
        GetItems(choices, items.AsSpan());
        return items;
    }
    
    /// <summary>
    ///   Fills the elements of a specified span with items chosen at random from the provided set of choices.
    /// </summary>
    /// <param name="choices">The items to use to populate the span.</param>
    /// <param name="destination">The span to be filled with items.</param>
    /// <typeparam name="T">The type of span.</typeparam>
    /// <exception cref="ArgumentException"><paramref name="choices" /> is empty.</exception>
    /// <remarks>
    ///   The method uses <see cref="Next(int)" /> to select items randomly from <paramref name="choices" />
    ///   by index and populate <paramref name="destination" />.
    /// </remarks>
    public void GetItems<T>(ReadOnlySpan<T> choices, Span<T> destination)
    {
        if (choices.IsEmpty)
        {
            throw new ArgumentException("Choices cannot be empty.", nameof(choices));
        }

        // Simple fallback: get each item individually, generating a new random Int32 for each
        // item. This is slower than the above, but it works for all types and sizes of choices.
        for (int i = 0; i < destination.Length; i++)
        {
            destination[i] = choices[Next(choices.Length)];
        }
    }
    
    /// <summary>Creates a string populated with characters chosen at random from <paramref name="choices"/>.</summary>
    /// <param name="choices">The characters to use to populate the string.</param>
    /// <param name="length">The length of string to return.</param>
    /// <returns>A string populated with items selected at random from <paramref name="choices"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="choices" /> is empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="length" /> is not zero or a positive number.</exception>
    /// <seealso cref="GetItems{T}(ReadOnlySpan{T}, Span{T})" />
    public string GetString(ReadOnlySpan<char> choices, int length)
    {
        if (choices.IsEmpty)
        {
            throw new ArgumentException("Choices cannot be empty.", nameof(choices));
        }

        if (length <= 0)
        {
            return string.Empty;
        }

        char[] destination = new char[length];
        GetItems(choices, destination.AsSpan());
        return new string(destination);
    }

    /// <summary>Creates a string filled with random hexadecimal characters.</summary>
    /// <param name="stringLength">The length of string to create.</param>
    /// <param name="lowercase">
    /// <see langword="true" /> if the hexadecimal characters should be lowercase; <see langword="false" /> if they should be uppercase.
    /// The default is <see langword="false" />.
    /// </param>
    /// <returns>A string populated with random hexadecimal characters.</returns>
    public string GetHexString(int stringLength, bool lowercase = false) => GetString(GetHexChoices(lowercase), stringLength);

    /// <summary>Fills a buffer with random hexadecimal characters.</summary>
    /// <param name="destination">The buffer to receive the characters.</param>
    /// <param name="lowercase">
    /// <see langword="true" /> if the hexadecimal characters should be lowercase; <see langword="false" /> if they should be uppercase.
    /// The default is <see langword="false" />.
    /// </param>
    public void GetHexString(Span<char> destination, bool lowercase = false) => GetItems(GetHexChoices(lowercase), destination);
    
    /// <summary>
    /// Returns a random fixed-point number between 0 and 1.
    /// </summary>
    /// <returns>A fixed-point number representing a percentage.</returns>
    // ReSharper disable once InconsistentNaming
    public T NextFixedPointPercentage<T>() where T : IFixedPoint<T>
    {
        return T.CreateFromDouble(NextDouble());
    }
    
    /// <summary>
    /// Returns a random fixed-point number between 0 and the maximum value.
    /// </summary>
    /// <param name="maxValue">The maximum value.</param>
    /// <returns>A fixed-point number between 0 and the maximum value.</returns>
    public T NextFixedPoint<T>(T maxValue) where T : IFixedPoint<T>
    {
        Validations.ValidateGreaterThan(maxValue, nameof(maxValue), T.Zero);
        return T.One * T.CreateFromDouble(Next(maxValue.ToInt()));
    }
    
    /// <summary>
    /// Returns a random fixed-point number between the minimum and maximum values.
    /// </summary>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <returns>A fixed-point number between the minimum and maximum values.</returns>
    public T NextFixedPoint<T>(T minValue, T maxValue) where T : struct, IFixedPoint<T>
    {
        Validations.ValidateRange(minValue, nameof(minValue), T.MinValue, T.MaxValue);
        Validations.ValidateRange(maxValue, nameof(maxValue), T.MinValue, T.MaxValue);
        (minValue, maxValue) = (FixedPointMath<T>.Min(minValue, maxValue), FixedPointMath<T>.Max(minValue, maxValue));

        return T.CreateFromDouble(NextDouble()) * (maxValue - minValue) + minValue;
    }
    
    /// <summary>
    /// Returns a random fixed-point number between 0 and the maximum possible value.
    /// </summary>
    /// <returns>A fixed-point number between 0 and the maximum possible value.</returns>
    public T NextFixedPoint<T>() where T : IFixedPoint<T>
    {
        return T.One * T.CreateFromDouble(NextLong(T.MaxValue.ToLong())) + T.CreateFromDouble(NextDouble());
    }

    /// <summary>
    /// Gets a thread-safe shared random generator instance.
    /// </summary>
    public static ARandomGenerator SharedRandom { get; }

    /// <summary>
    /// Gets a normally (Gaussian) distributed random number with mean 0 and standard deviation 1.
    /// </summary>
    /// <returns>The normally distributed random number.</returns>
    public double GetNormal()
    {
        double u1 = NextDouble();
        double u2 = NextDouble();
        double r = Math.Sqrt( -2.0*Math.Log(u1) );
        double theta = 2.0*Math.PI*u2;
        return r*Math.Sin(theta);
    }
    
    /// <summary>
    /// Gets a normally (Gaussian) distributed random number with the specified mean and standard deviation.
    /// </summary>
    /// <param name="mean">The mean for the distribution.</param>
    /// <param name="standardDeviation">The standard deviation for the distribution.</param>
    /// <returns>The normally distributed random number.</returns>
    public double GetNormal(double mean, double standardDeviation)
    {
        Validations.ValidateGreaterThan(standardDeviation, nameof(standardDeviation), 0.0);
        return mean + standardDeviation * GetNormal();
    }
    
    /// <summary>
    /// Gets an exponentially distributed random number with mean 1.
    /// </summary>
    /// <returns>The exponentially distributed random number.</returns>
    public double GetExponential()
    {
        return -Math.Log( NextDouble() );
    }

    /// <summary>
    /// Gets an exponentially distributed random number with the specified mean.
    /// </summary>
    /// <param name="mean">The mean for the distribution.</param>
    /// <returns>The exponentially distributed random number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the mean is less than or equal to 0.</exception>
    public double GetExponential(double mean)
    {
        Validations.ValidateGreaterThan(mean, nameof(mean), 0.0);
        return mean*GetExponential();
    }

    /// <summary>
    /// Gets a gamma distributed random number with the specified shape and scale.
    /// </summary>
    /// <param name="shape">The shape parameter for the distribution.</param>
    /// <param name="scale">The scale parameter for the distribution.</param>
    /// <returns>The gamma distributed random number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the shape is less than or equal to 0.</exception>
    public double GetGamma(double shape, double scale)
    {
        Validations.ValidateGreaterThan(shape, nameof(shape), 0.0);
        
        // Implementation based on "A Simple Method for Generating Gamma Variables"
        // by George Marsaglia and Wai Wan Tsang.  ACM Transactions on Mathematical Software
        // Vol 26, No 3, September 2000, pages 363-372.

        double d, c, x, xsquared, v, u;

        if (shape >= 1.0)
        {
            d = shape - 1.0/3.0;
            c = 1.0/Math.Sqrt(9.0*d);
            for (;;)
            {
                do
                {
                    x = GetNormal();
                    v = 1.0 + c*x;
                }
                while (v <= 0.0);
                v = v*v*v;
                u = NextDouble();
                xsquared = x*x;
                if (u < 1.0 -.0331*xsquared*xsquared || Math.Log(u) < 0.5*xsquared + d*(1.0 - v + Math.Log(v)))
                    return scale*d*v;
            }
        }

        double g = GetGamma(shape+1.0, 1.0);
        double w = NextDouble();
        return scale*g*Math.Pow(w, 1.0/shape);
    }

    /// <summary>
    /// Gets a chi-squared distributed random number with the specified degrees of freedom.
    /// </summary>
    /// <param name="degreesOfFreedom">The degrees of freedom for the distribution.</param>
    /// <returns>The chi-squared distributed random number.</returns>
    public double GetChiSquare(double degreesOfFreedom)
    {
        // A chi squared distribution with n degrees of freedom
        // is a gamma distribution with shape n/2 and scale 2.
        return GetGamma(0.5 * degreesOfFreedom, 2.0);
    }

    /// <summary>
    /// Gets an inverse gamma distributed random number with the specified shape and scale.
    /// </summary>
    /// <param name="shape">The shape parameter for the distribution.</param>
    /// <param name="scale">The scale parameter for the distribution.</param>
    /// <returns>The inverse gamma distributed random number.</returns>
    public double GetInverseGamma(double shape, double scale)
    {
        // If X is gamma(shape, scale) then
        // 1/Y is inverse gamma(shape, 1/scale)
        return 1.0 / GetGamma(shape, 1.0 / scale);
    }

    /// <summary>
    /// Gets a Weibull distributed random number with the specified shape and scale.
    /// </summary>
    /// <param name="shape">The shape parameter for the distribution.</param>
    /// <param name="scale">The scale parameter for the distribution.</param>
    /// <returns>The Weibull distributed random number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the shape or scale is less than or equal to 0.</exception>
    public double GetWeibull(double shape, double scale)
    {
        Validations.ValidateGreaterThan(shape, nameof(shape), 0.0);
        Validations.ValidateGreaterThan(scale, nameof(scale), 0.0);
        return scale * Math.Pow(-Math.Log(NextDouble()), 1.0 / shape);
    }

    /// <summary>
    /// Gets a Cauchy distributed random number with the specified median and scale.
    /// </summary>
    /// <param name="median">The median for the distribution.</param>
    /// <param name="scale">The scale parameter for the distribution.</param>
    /// <returns>The Cauchy distributed random number.</returns>
    /// <exception cref="ArgumentException">Thrown when the scale is less than or equal to 0.</exception>
    public double GetCauchy(double median, double scale)
    {
        Validations.ValidateGreaterThan(scale, nameof(scale), 0.0);

        double p = NextDouble();
        // Apply inverse of the Cauchy distribution function to a uniform
        return median + scale*Math.Tan(Math.PI*(p - 0.5));
    }

    /// <summary>
    /// Gets a Student's t-distributed random number with the specified degrees of freedom.
    /// </summary>
    /// <param name="degreesOfFreedom">The degrees of freedom for the distribution.</param>
    /// <returns>The Student's t-distributed random number.</returns>
    /// <exception cref="ArgumentException">Thrown when the degrees of freedom is less than or equal to 0.</exception>
    public double GetStudentT(double degreesOfFreedom)
    {
        Validations.ValidateGreaterThan(degreesOfFreedom, nameof(degreesOfFreedom), 0.0);

        // See Seminumerical Algorithms by Knuth
        double y1 = GetNormal();
        double y2 = GetChiSquare(degreesOfFreedom);
        return y1 / Math.Sqrt(y2 / degreesOfFreedom);
    }

    /// <summary>
    /// Gets a Laplace distributed random number with the specified mean and scale.
    /// </summary>
    /// <param name="mean">The mean for the distribution.</param>
    /// <param name="scale">The scale parameter for the distribution.</param>
    /// <returns>The Laplace distributed random number.</returns>
    public double GetLaplace(double mean, double scale)
    {
        double u = NextDouble();
        return (u < 0.5) ?
            mean + scale*Math.Log(2.0*u) :
            mean - scale*Math.Log(2*(1-u));
    }

    /// <summary>
    /// Gets a log-normal distributed random number with the specified mean and standard deviation.
    /// </summary>
    /// <param name="mu">The mean for the distribution.</param>
    /// <param name="sigma">The standard deviation for the distribution.</param>
    /// <returns>The log-normal distributed random number.</returns>
    public double GetLogNormal(double mu, double sigma)
    {
        return Math.Exp(GetNormal(mu, sigma));
    }

    /// <summary>
    /// Gets a beta distributed random number with the specified shape parameters.
    /// </summary>
    /// <param name="a">The first shape parameter for the distribution.</param>
    /// <param name="b">The second shape parameter for the distribution.</param>
    /// <returns>The beta distributed random number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when either shape parameter is less than or equal to 0.</exception>
    public double GetBeta(double a, double b)
    {
        Validations.ValidateGreaterThan(a, nameof(a), 0.0);
        Validations.ValidateGreaterThan(b, nameof(b), 0.0);

        // There are more efficient methods for generating beta samples.
        // However such methods are a little more efficient and much more complicated.
        // For an explanation of why the following method works, see
        // http://www.johndcook.com/distribution_chart.html#gamma_beta
        double u = GetGamma(a, 1.0);
        double v = GetGamma(b, 1.0);
        return u / (u + v);
    }

    /// <summary>
    /// Returns a random boolean value.
    /// </summary>
    /// <returns>A boolean value that is either true or false.</returns>
    public bool NextBool()
    {
        return NextUInt(2) == 0;
    }

    /// <summary>
    /// Simulates a coin flip and returns the result.
    /// </summary>
    /// <returns><see langword="true"/> for heads, <see langword="false"/> for tails.</returns>
    public bool NextCoinFlip()
    {
        return NextBool();
    }
    
    /// <summary>
    /// Simulates multiple coin flips and returns the results.
    /// </summary>
    /// <param name="count">The number of coin flips to simulate.</param>
    /// <returns>A list of boolean values representing the results of the coin flips.</returns>
    public List<bool> NextCoinFlips(uint count)
    {
        List<bool> flips = new List<bool>((int)count);
        for (uint i = 0; i < count; i++)
        {
            flips.Add(NextBool());
        }
        return flips;
    }
    
    /// <summary>
    /// Simulates multiple coin flips and returns the counts of heads and tails.
    /// </summary>
    /// <param name="count">The number of coin flips to simulate.</param>
    /// <returns>A tuple containing the counts of heads and tails.</returns>
    public (uint heads, uint tails) NextCoinFlipResults(uint count)
    {
        uint heads = 0;
        uint tails = 0;
        for (uint i = 0; i < count; i++)
        {
            if (NextBool())
            {
                heads++;
            }
            else
            {
                tails++;
            }
        }
        return (heads, tails);
    }

    /// <summary>
    /// Rolls a die with the specified number of faces a specified number of times.
    /// </summary>
    /// <param name="faces">The number of faces on the die.</param>
    /// <param name="numberOfDie">The number of times to roll the die.</param>
    /// <returns>The total result of all die rolls.</returns>
    public uint NextDieRoll(uint faces, int numberOfDie = 1)
    {
        if (faces == 0 || numberOfDie == 0)
        {
            return 0;
        }

        uint total = 0;
        for (int i = 0; i < numberOfDie; i++)
        {
            total += NextUInt(faces);
        }
        return total;
    }

    /// <summary>
    /// Rolls a die with the specified number of faces a specified number of times and returns the result of each roll.
    /// </summary>
    /// <param name="faces">The number of faces on the die.</param>
    /// <param name="numberOfDie">The number of times to roll the die.</param>
    /// <returns>A list of results for each die roll.</returns>
    public List<uint> NextDieRollPerDice(uint faces, int numberOfDie = 1)
    {
        var rolls = new List<uint>(numberOfDie);
        for (uint i = 0; i < numberOfDie; i++)
        {
            rolls.Add(NextUInt(faces));
        }
        return rolls;
    }

    /// <summary>
    /// Advances the generator by a specified number of steps.
    /// </summary>
    /// <param name="steps">The number of steps to advance the generator.</param>
    public void AdvanceGenerator(uint steps)
    {
        for (uint i = 0; i < steps; i++)
        {
            Next();
        }
    }
}

