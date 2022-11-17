// ORIGNAL COMMENTS
/*
   A C-program for MT19937, with initialization improved 2002/1/26.
   Coded by Takuji Nishimura and Makoto Matsumoto.

   Before using, initialize the state by using init_genrand(seed)
   or init_by_array(init_key, key_length).

   Copyright (C) 1997 - 2002, Makoto Matsumoto and Takuji Nishimura,
   All rights reserved.

   Redistribution and use in source and binary forms, with or without
   modification, are permitted provided that the following conditions
   are met:

     1. Redistributions of source code must retain the above copyright
        notice, this list of conditions and the following disclaimer.

     2. Redistributions in binary form must reproduce the above copyright
        notice, this list of conditions and the following disclaimer in the
        documentation and/or other materials provided with the distribution.

     3. The names of its contributors may not be used to endorse or promote
        products derived from this software without specific prior written
        permission.

   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
   A PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL THE COPYRIGHT OWNER OR
   CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
   EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
   PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
   PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
   LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
   NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
   SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

   Any feedback is very welcome.
   http://www.math.keio.ac.jp/matumoto/emt.html
   email: matumoto@math.keio.ac.jp
*/
//  Originally converted to C# by Dave Loeser, https://www.codeproject.com/Articles/5147/A-C-Mersenne-Twister-class

using System;

namespace Velentr.Core.Helpers.Math.Random
{
    /// <summary>
    ///     A mt 19937.
    /// </summary>
    /// <seealso cref="AbstractRandomGenerator" />
    public class MT19937 : AbstractRandomGenerator
    {
        /// <summary>
        ///     (Immutable) Period parameters.
        /// </summary>
        private const ulong N = 624;

        /// <summary>
        ///     (Immutable) an ulong to process.
        /// </summary>
        private const ulong M = 397;

        /// <summary>
        ///     (Immutable) constant vector a.
        /// </summary>
        private const ulong MATRIX_A = 0x9908B0DFUL;

        /// <summary>
        ///     (Immutable) most significant w-r bits.
        /// </summary>
        private const ulong UPPER_MASK = 0x80000000UL;

        /// <summary>
        ///     (Immutable) least significant r bits.
        /// </summary>
        private const ulong LOWER_MASK = 0X7FFFFFFFUL;

        /// <summary>
        ///     (Immutable) the default seed.
        /// </summary>
        private const uint DEFAULT_SEED = 4357;

        /// <summary>
        ///     The array for the state vector.
        /// </summary>
        private static readonly ulong[] mt = new ulong[N + 1];

        /// <summary>
        ///     Mti==N+1 means mt[N] is not initialized.
        /// </summary>
        private static ulong mti = N + 1;

        /// <summary>
        ///     Default constructor.
        /// </summary>
        public MT19937()
        {
            var init = new ulong[4];
            init[0] = 0x123;
            init[1] = 0x234;
            init[2] = 0x345;
            init[3] = 0x456;
            ulong length = 4;
            SetSeed(init, length);
            SetSeed(5489UL);
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="s">    An ulong to process. </param>
        public MT19937(ulong s)
        {
            var init = new ulong[4];
            init[0] = 0x123;
            init[1] = 0x234;
            init[2] = 0x345;
            init[3] = 0x456;
            ulong length = 4;
            SetSeed(init, length);
            SetSeed(s);
        }

        /// <summary>
        ///     initializes mt[N] with a seed.
        /// </summary>
        /// <param name="s">    An ulong to process. </param>
        private void SetSeed(ulong s)
        {
            mt[0] = s & 0xffffffffUL;
            for (mti = 1; mti < N; mti++)
            {
                mt[mti] = 1812433253UL * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + mti;
                /* See Knuth TAOCP Vol2. 3rd Ed. P.106 for multiplier. */
                /* In the previous versions, MSBs of the seed affect   */
                /* only MSBs of the array mt[].                        */
                /* 2002/01/09 modified by Makoto Matsumoto             */
                mt[mti] &= 0xffffffffUL;
                /* for >32 bit machines */
            }
        }

        /// <summary>
        ///     initialize by an array with array-length init_key is the array for initializing keys
        ///     key_length is its length.
        /// </summary>
        /// <param name="init_key">     The initialize key. </param>
        /// <param name="key_length">   Length of the key. </param>
        public void SetSeed(ulong[] init_key, ulong key_length)
        {
            ulong i, j, k;
            SetSeed(19650218UL);
            i = 1;
            j = 0;
            k = N > key_length ? N : key_length;
            for (; k > 0; k--)
            {
                mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1664525UL)) + init_key[j] + j; // non linear
                mt[i] &= 0xffffffffUL;                                                             // for WORDSIZE > 32 machines
                i++;
                j++;
                if (i >= N)
                {
                    mt[0] = mt[N - 1];
                    i = 1;
                }

                if (j >= key_length)
                {
                    j = 0;
                }
            }

            for (k = N - 1; k > 0; k--)
            {
                mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1566083941UL)) - i; // non linear
                mt[i] &= 0xffffffffUL;                                                  // for WORDSIZE > 32 machines
                i++;
                if (i >= N)
                {
                    mt[0] = mt[N - 1];
                    i = 1;
                }
            }

            mt[0] = 0x80000000UL; // MSB is 1; assuring non-zero initial array
        }

        /// <summary>
        ///     Gets u int.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The u int.
        /// </returns>
        /// <seealso cref="AbstractRandomGenerator.GetUInt(uint,uint)" />
        public override uint GetUInt(uint minimum = 0, uint maximum = uint.MaxValue)
        {
            return (uint) base.GetULong(minimum, maximum);
        }

        /// <summary>
        ///     Gets u long.
        /// </summary>
        /// <param name="minimum">  (Optional) </param>
        /// <param name="maximum">  (Optional) </param>
        /// <returns>
        ///     The u long.
        /// </returns>
        /// <seealso cref="AbstractRandomGenerator.GetULong(ulong,ulong)" />
        public override ulong GetULong(ulong minimum = 0, ulong maximum = ulong.MaxValue)
        {
            if (minimum != 0 || maximum != ulong.MaxValue)
            {
                return Convert.ToUInt64(GetNormal() * (maximum - minimum) + minimum);
            }

            ulong y = 0;
            var mag01 = new ulong[2];
            mag01[0] = 0x0UL;
            mag01[1] = MATRIX_A;
            /* mag01[x] = x * MATRIX_A  for x=0,1 */

            if (mti >= N)
            {
                // generate N words at one time
                ulong kk;

                for (kk = 0; kk < N - M; kk++)
                {
                    y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                    mt[kk] = mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1UL];
                }

                for (; kk < N - 1; kk++)
                {
                    y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);

                    //mt[kk] = mt[kk+(M-N)] ^ (y >> 1) ^ mag01[y & 0x1UL];
                    mt[kk] = mt[kk - 227] ^ (y >> 1) ^ mag01[y & 0x1UL];
                }

                y = (mt[N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
                mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1UL];

                mti = 0;
            }

            y = mt[mti++];

            /* Tempering */
            y ^= y >> 11;
            y ^= (y << 7) & 0x9d2c5680UL;
            y ^= (y << 15) & 0xefc60000UL;
            y ^= y >> 18;

            return y;
        }
    }
}
