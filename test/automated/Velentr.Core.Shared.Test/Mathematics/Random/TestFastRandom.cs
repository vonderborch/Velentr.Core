using System.Collections.Concurrent;
using Velentr.Core.Mathematics.Random;

namespace Velentr.Core.Test.Mathematics.Random;

[TestFixture]
public class TestFastRandom : TestRandomness<FastRandom>
{
    public override ARandomGenerator GetGenerator()
    {
        return new FastRandom();
    }

    [Test]
    public void TestDefaultConstructor()
    {
        FastRandom? rng = new();
        Assert.That(rng, Is.Not.Null);
    }

    [Test]
    public void TestSeedConstructor()
    {
        long seed = 123456789;
        FastRandom? rng = new(seed);
        Assert.That(rng.StartingSeed, Is.EqualTo(seed));
    }

    [Test]
    public void TestNextUInt()
    {
        FastRandom? rng = new();
        var value = rng.NextUInt();
        Assert.That(value, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void TestNextULong()
    {
        FastRandom? rng = new();
        var value = rng.NextULong();
        Assert.That(value, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void TestNextBytes()
    {
        FastRandom? rng = new();
        var buffer = new byte[10];
        rng.NextBytes(buffer);
        Assert.That(buffer.Any(b => b != 0), Is.True);
    }

    [Test]
    public void TestSetSeed()
    {
        DateTime startingTime = DateTime.Now;
        FastRandom? rng = new();
        long seed = 987654321;
        rng.SetSeed(seed);
        Assert.That(rng.StartingSeed, Is.EqualTo(seed));
    }

    [Test]
    public void TestSharedRandom()
    {
        ARandomGenerator? sharedRng = FastRandom.SharedRandom;
        Assert.That(sharedRng, Is.Not.Null);
    }

    [Test]
    public void TestSharedRandom_ThreadSafety()
    {
        ARandomGenerator? sharedRng = FastRandom.SharedRandom;
        Assert.That(sharedRng, Is.Not.Null);

        // Test that multiple threads each get their own seed
        var threadCount = 100;
        ConcurrentBag<long>? seeds = new();
        List<Thread> threads = new();

        for (var i = 0; i < threadCount; i++)
        {
            Thread thread = new(() =>
            {
                ARandomGenerator rng = FastRandom.SharedRandom;
                seeds.Add(rng.Seed);
            });
            threads.Add(thread);
            thread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Assert.That(seeds.Distinct().Count(), Is.EqualTo(threadCount));
    }
}
