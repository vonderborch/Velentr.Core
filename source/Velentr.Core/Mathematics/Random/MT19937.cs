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

namespace Velentr.Core.Mathematics.Random;

/// <summary>
///     A Mersenne Twister random number generator (MT19937).
/// </summary>
// ReSharper disable once InconsistentNaming
public class MT19937 : ARandomGenerator
{
    private const ushort N = 624;
    private const ushort M = 397;
    private const uint MatrixA = 0x9908b0dfU;
    private const uint UpperMask = 0x80000000U;
    private const uint LowerMask = 0x7fffffffU;
    private static long _sharedSeed = DateTime.Now.Ticks;

    /// <summary>
    ///     The internal random generator instance.
    /// </summary>
    private static readonly ThreadLocal<MT19937> InternalSharedRandom = new(CreateThreadLocalInstance);

    private readonly uint[] mt = new uint[N];
    private ushort mti = N + 1;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MT19937" /> class with a default seed.
    /// </summary>
    public MT19937() : this(DateTime.Now.Ticks)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="MT19937" /> class with the specified seed.
    /// </summary>
    /// <param name="seed">The seed value.</param>
    public MT19937(long seed) : base(seed)
    {
    }

    /// <summary>
    ///     Gets a thread-safe shared random generator instance.
    /// </summary>
#pragma warning disable CS8603 // Possible null reference return.
    public new static MT19937 SharedRandom => InternalSharedRandom.Value;
#pragma warning restore CS8603 // Possible null reference return.

    /// <summary>
    ///     Gets the current seed used for the random number generator.
    /// </summary>
    public new long Seed
    {
        get => throw new NotSupportedException("Use StartingSeed instead.");
        set => _ = value; // This is a placeholder to prevent setting the seed directly.
    }

    /// <summary>
    ///     Gets the starting seed used for the random number generator.
    /// </summary>
    public new long StartingSeed { get; protected set; }

    /// <summary>
    ///     Creates a thread-local instance of the random number generator.
    /// </summary>
    /// <returns>The thread-local random number generator instance.</returns>
    protected static MT19937 CreateThreadLocalInstance()
    {
        var newSharedSeed = _sharedSeed++;
        Interlocked.Increment(ref _sharedSeed);
        return new MT19937(newSharedSeed);
    }

    /// <summary>
    ///     Fills the elements of a specified span with random numbers.
    /// </summary>
    /// <param name="buffer">The span to be filled with random numbers.</param>
    public override void NextBytes(Span<byte> buffer)
    {
        for (var i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (byte)NextUInt();
        }
    }

    /// <summary>
    ///     Returns a random unsigned integer.
    /// </summary>
    /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="uint.MaxValue" />.</returns>
    public override uint NextUInt()
    {
        uint y;
        var mag01 = new[] { 0x0U, MatrixA };

        if (this.mti >= N)
        {
            int kk;

            for (kk = 0; kk < N - M; kk++)
            {
                y = (this.mt[kk] & UpperMask) | (this.mt[kk + 1] & LowerMask);
                this.mt[kk] = this.mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1U];
            }

            for (; kk < N - 1; kk++)
            {
                y = (this.mt[kk] & UpperMask) | (this.mt[kk + 1] & LowerMask);
                this.mt[kk] = this.mt[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 0x1U];
            }

            y = (this.mt[N - 1] & UpperMask) | (this.mt[0] & LowerMask);
            this.mt[N - 1] = this.mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1U];

            this.mti = 0;
        }

        y = this.mt[this.mti++];

        y ^= y >> 11;
        y ^= (y << 7) & 0x9d2c5680U;
        y ^= (y << 15) & 0xefc60000U;
        y ^= y >> 18;

        return y;
    }

    /// <summary>
    ///     Returns a random unsigned long integer.
    /// </summary>
    /// <returns>A 64-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ulong.MaxValue" />.</returns>
    public override ulong NextULong()
    {
        return ((ulong)NextUInt() << 32) | NextUInt();
    }

    /// <summary>
    ///     Sets the seed for the random number generator.
    /// </summary>
    /// <param name="seed">The seed value to set.</param>
    public override void SetSeed(long seed)
    {
        this.StartingSeed = seed;
        this.mt[0] = unchecked((uint)(seed >> 32) ^ (uint)seed);
        for (this.mti = 1; this.mti < N; this.mti++)
        {
            this.mt[this.mti] = 1812433253U * (this.mt[this.mti - 1] ^ (this.mt[this.mti - 1] >> 30)) + this.mti;
        }
    }
}
