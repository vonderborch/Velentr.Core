/* SOURCE: https://www.codeproject.com/KB/recipes/SimpleRNG.aspx
Copyright 2008 John D. Cook
   
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */


namespace Velentr.Core.Mathematics.Random;

/// <summary>
/// SimpleRNG is a simple random number generator based on 
/// George Marsaglia's MWC (multiply with carry) generator.
/// Although it is very simple, it passes Marsaglia's DIEHARD
/// series of random number generator tests.
/// 
/// Written by John D. Cook 
/// http://www.johndcook.com
/// </summary>
public class SimpleRng : ARandomGenerator
{
    private static long _sharedSeed = DateTime.Now.Ticks;
    
    private uint stateA = 0;
    private uint stateB = 0;
    
    private const uint DefaultStateA = 521288629;
    private const uint DefaultStateB = 362436069;

    /// <summary>
    /// Initializes a new instance of the <see cref="SimpleRng"/> class with the current time as the seed.
    /// </summary>
    public SimpleRng() : this(DateTime.Now.Ticks)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SimpleRng"/> class with the specified seed.
    /// </summary>
    /// <param name="seed">The seed value.</param>
    public SimpleRng(long seed) : base(seed)
    {
    }
    
    /// <summary>
    /// The internal random generator instance.
    /// </summary>
    private static readonly ThreadLocal<SimpleRng> InternalSharedRandom = new(CreateThreadLocalInstance);
    
    /// <summary>
    /// Gets a thread-safe shared random generator instance.
    /// </summary>
#pragma warning disable CS8603 // Possible null reference return.
    public new static ARandomGenerator SharedRandom => InternalSharedRandom.Value;
#pragma warning restore CS8603 // Possible null reference return.
    
    /// <summary>
    /// Creates a thread-local instance of the random number generator.
    /// </summary>
    /// <returns>The thread-local random number generator instance.</returns>
    protected static SimpleRng CreateThreadLocalInstance()
    {
        long newSharedSeed = _sharedSeed++;
        Interlocked.Increment(ref _sharedSeed);
        return new SimpleRng(newSharedSeed);
    }

    /// <summary>
    /// Sets the seed for the random number generator.
    /// </summary>
    /// <param name="seed">The seed value.</param>
    public override void SetSeed(long seed)
    {
        this.Seed = seed;
        this.stateA = (uint)(seed & 0xFFFFFFFF);         // Take the low 32 bits
        this.stateB = (uint)((seed >> 32) & 0xFFFFFFFF); // Take the high 32 bits
        if (this.stateA == 0 && this.stateB == 0)
        {
            // These values are not magical, just the default values Marsaglia used.
            // Any pair of unsigned integers should be fine.
            this.stateA = DefaultStateA;
            this.stateB = DefaultStateB;
        }

        this.Seed = ((long)this.stateB << 32) | this.stateA;
    }

    /// <summary>
    /// Generates the next random unsigned integer.
    /// </summary>
    /// <returns>A random unsigned integer.</returns>
    public override uint NextUInt()
    {
        // This is the heart of the generator.
        // It uses George Marsaglia's MWC algorithm to produce an unsigned integer.
        // See http://www.bobwheeler.com/statistics/Password/MarsagliaPost.txt
        this.stateB = 36969 * (this.stateB & 65535) + (this.stateB >> 16);
        this.stateA = 18000 * (this.stateA & 65535) + (this.stateA >> 16);
        uint result = (this.stateB << 16) + this.stateA;
        
        // Update the seed
        this.Seed = ((long)this.stateB << 32) | this.stateA;
        
        return result;
    }

    /// <summary>
    /// Generates the next random unsigned long integer.
    /// </summary>
    /// <returns>A random unsigned long integer.</returns>
    public override ulong NextULong()
    {
        return ((ulong)NextUInt() << 32) | NextUInt();
    }

    /// <summary>
    /// Fills the specified buffer with random bytes.
    /// </summary>
    /// <param name="buffer">The buffer to fill with random bytes.</param>
    public override void NextBytes(Span<byte> buffer)
    {
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (byte)(NextUInt() % 256);
        }
    }
}

