/*

Copyright 2008 John D. Cook
https://www.codeproject.com/Articles/25172/Simple-Random-Number-Generation

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

 */

using System;

namespace Velentr.Core.Helpers.Math.Random
{
    /// <summary>
    ///     SimpleRNG is a simple random number generator based on George Marsaglia's MWC (multiply with
    ///     carry) generator. Although it is very simple, it passes Marsaglia's DIEHARD series of random
    ///     number generator tests.
    ///     Written by John D. Cook (http://www.johndcook.com), Lightly modified by Christian Webber
    /// </summary>
    /// <seealso cref="AbstractRandomGenerator" />
    public class SimpleRng : AbstractRandomGenerator
    {
        /// <summary>
        ///     The state a.
        /// </summary>
        private uint state_a;

        /// <summary>
        ///     The state b.
        /// </summary>
        private uint state_b;

        /// <summary>
        ///     Default constructor.
        /// </summary>
        public SimpleRng()
        {
            // These values are not magical, just the default values Marsaglia used.
            // Any pair of unsigned integers should be fine.
            this.state_a = 521288629;
            this.state_b = 362436069;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one or more arguments are outside
        ///     the required range.
        /// </exception>
        /// <param name="state_a">  (Optional) The state a. </param>
        /// <param name="state_b">  (Optional) The state b. </param>
        public SimpleRng(uint state_a = 521288629, uint state_b = 362436069)
        {
            if (state_a == 0 && state_b == 0)
            {
                throw new ArgumentOutOfRangeException($"At least one of {nameof(state_a)} and {nameof(state_b)} must be greater than 0! Received u={state_a} and v={state_b}.");
            }

            this.state_a = state_a == 0 ? 521288629 : state_a;
            this.state_b = state_b == 0 ? 362436069 : state_b;
        }

        /// <summary>
        ///     Sets a seed.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one or more arguments are outside
        ///     the required range.
        /// </exception>
        /// <param name="state_a">  (Optional) The state a. </param>
        /// <param name="state_b">  (Optional) The state b. </param>
        public void SetSeed(uint state_a = 521288629, uint state_b = 362436069)
        {
            if (state_a == 0 && state_b == 0)
            {
                throw new ArgumentOutOfRangeException($"At least one of {nameof(state_a)} and {nameof(state_b)} must be greater than 0! Received u={state_a} and v={state_b}.");
            }

            this.state_a = state_a == 0 ? 521288629 : state_a;
            this.state_b = state_b == 0 ? 362436069 : state_b;
        }

        /// <summary>
        ///     Sets seed from system time.
        /// </summary>
        public void SetSeedFromSystemTime()
        {
            var x = DateTime.Now.ToFileTime();
            SetSeed((uint) (x >> 16), (uint) (x % 4294967296));
        }

        /// <summary>
        ///     Returns a random uint.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     A random uint.
        /// </returns>
        public override uint GetUInt(uint minimum = uint.MinValue, uint maximum = uint.MaxValue)
        {
            if (minimum != uint.MinValue || maximum != uint.MaxValue)
            {
                return Convert.ToUInt32(GetNormal() * (maximum - minimum) + minimum);
            }

            /// This is the heart of the generator.
            /// It uses George Marsaglia's MWC algorithm to produce an unsigned integer.
            /// See http://www.bobwheeler.com/statistics/Password/MarsagliaPost.txt

            this.state_b = 36969 * (this.state_b & 65535) + (this.state_b >> 16);
            this.state_a = 18000 * (this.state_a & 65535) + (this.state_a >> 16);

            return (this.state_b << 16) + this.state_a;
        }
    }
}
