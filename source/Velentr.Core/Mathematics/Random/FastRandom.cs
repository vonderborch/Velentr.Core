using Velentr.Core.Threading;

namespace Velentr.Core.Mathematics.Random;

/// <summary>
/// A fast random number generator for .NET Colin Green, January 2005
///
/// September 4th 2005 Added NextBytesUnsafe() - commented out by default. Fixed bug in Reinitialise() - y,z and w
/// variables were not being reset.
///
/// Key points:
/// 1) Based on a simple and fast xor-shift pseudo random number generator (RNG) specified in: Marsaglia, George.
/// (2003). Xorshift RNGs. http://www.jstatsoft.org/v08/i14/xorshift.pdf
///
/// This particular implementation of xorshift has a period of 2^128-1. See the above paper to see how this can be
/// easily extened if you need a longer period. At the time of writing I could find no information on the period of
/// System.Random for comparison.
///
/// 2) Faster than System.Random. Up to 8x faster, depending on which methods are called.
///
/// 3) Direct replacement for System.Random. This class implements all of the methods that System.Random does plus
/// some additional methods. The like named methods are functionally equivalent.
///
/// 4) Allows fast re-initialisation with a seed, unlike System.Random which accepts a seed at construction time
/// which then executes a relatively expensive initialisation routine. This provides a vast speed improvement if you
/// need to reset the pseudo-random number sequence many times, e.g. if you want to re-generate the same sequence
/// many times. An alternative might be to cache random numbers in an array, but that approach is limited by memory
/// capacity and the fact that you may also want a large number of different sequences cached. Each sequence can
/// each be represented by a single seed value (int) when using FastRandom.
///
/// Notes. A further performance improvement can be obtained by declaring local variables as static, thus avoiding
/// re-allocation of variables on each call. However care should be taken if multiple instances of FastRandom are in
/// use or if being used in a multi-threaded environment.
/// 
/// SOURCED FROM https://www.codeproject.com/Articles/9187/A-fast-equivalent-for-System-Random All Credit to Colin Green
/// </summary>
public class FastRandom : ARandomGenerator
{
    private static long _sharedSeed = DateTime.Now.Ticks;
    
    /// <summary>
    /// Default seed values for the y, z, and w variables.
    /// </summary>
    const uint Y = 842502087, Z = 3579807591, W = 273326509;

    /// <summary>
    /// Internal state variables for the xorshift algorithm.
    /// </summary>
    private uint x, y, z, w;

    /// <summary>
    /// Initializes a new instance of the <see cref="FastRandom"/> class with the current time as the seed.
    /// </summary>
    public FastRandom() : this(DateTime.Now.Ticks)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FastRandom"/> class with a specified seed.
    /// </summary>
    /// <param name="seed">The seed value to initialize the random number generator.</param>
    public FastRandom(long seed) : base(seed)
    {
    }

    /// <summary>
    ///     The internal random generator instance.
    /// </summary>
    private static readonly ThreadLocal<FastRandom> InternalSharedRandom = new(CreateThreadLocalInstance);

    /// <summary>
    ///     Gets a thread-safe shared random generator instance.
    /// </summary>
#pragma warning disable CS8603 // Possible null reference return.
    public new static FastRandom SharedRandom => InternalSharedRandom.Value;
#pragma warning restore CS8603 // Possible null reference return.

    /// <summary>
    ///     Creates a thread-local instance of the random number generator.
    /// </summary>
    /// <returns>The thread-local random number generator instance.</returns>
    protected static FastRandom CreateThreadLocalInstance()
    {
        var newSharedSeed = _sharedSeed + 1;
        while (!AtomicOperations.CAS(ref _sharedSeed, newSharedSeed, _sharedSeed))
        {
            newSharedSeed = _sharedSeed + 1;
        }
        return new FastRandom(newSharedSeed);
    }

    /// <summary>
    /// Fills the provided buffer with random bytes.
    /// </summary>
    /// <param name="buffer">The buffer to fill with random bytes.</param>
    public override void NextBytes(Span<byte> buffer)
    {
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (byte)NextUInt();
        }
    }

    /// <summary>
    /// Generates a random integer in the range [0, Int32.MaxValue).
    /// </summary>
    /// <returns>A random integer.</returns>
    public new int Next()
    {
        uint t = this.x ^ (this.x << 11);
        this.x = this.y;
        this.y = this.z;
        this.z = this.w;
        return (int)(0x7FFFFFFF & (this.w = this.w ^ (this.w >> 19) ^ t ^ (t >> 8)));
    }

    /// <summary>
    /// Generates a random unsigned integer in the range [0, UInt32.MaxValue].
    /// </summary>
    /// <returns>A random unsigned integer.</returns>
    public override uint NextUInt()
    {
        uint t = this.x ^ (this.x << 11);
        this.x = this.y;
        this.y = this.z;
        this.z = this.w;
        return this.w = this.w ^ (this.w >> 19) ^ t ^ (t >> 8);
    }

    /// <summary>
    /// Generates a random unsigned long integer by combining two random unsigned integers.
    /// </summary>
    /// <returns>A random unsigned long integer.</returns>
    public override ulong NextULong()
    {
        // Combine two uint values to create a ulong
        uint high = NextUInt();
        uint low = NextUInt();
        return ((ulong)high << 32) | low;
    }

    /// <summary>
    /// Sets the seed for the random number generator.
    /// </summary>
    /// <param name="seed">The seed value to set.</param>
    /// <remarks>
    /// At least one of the internal state variables (x, y, z, w) must be non-zero.
    /// This method resets the x variable and uses default values for y, z, and w.
    /// </remarks>
    public override void SetSeed(long seed)
    {
        // The only stipulation stated for the xorshift RNG is that at least one of the seeds x,y,z,w is non-zero.
        // We fulfill that requirement by only allowing resetting of the x seed
        StartingSeed = seed;
        this.x = (uint)seed;
        this.y = Y;
        this.z = Z;
        this.w = W;
    }
    
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
}

