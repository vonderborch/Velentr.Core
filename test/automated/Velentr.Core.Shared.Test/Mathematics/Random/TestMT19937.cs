using System.Collections.Concurrent;
using Velentr.Core.Mathematics.Random;

namespace Velentr.Core.Test.Mathematics.Random;

[TestFixture]
// ReSharper disable once InconsistentNaming
public class TestMT19937 : TestRandomness<MT19937>
{
    public override ARandomGenerator GetGenerator()
    {
        return new MT19937();
    }

    [Test]
    public void TestDefaultConstructor()
    {
        MT19937? rng = new();
        Assert.That(rng, Is.Not.Null);
    }

    [Test]
    public void TestSeedConstructor()
    {
        long seed = 123456789;
        MT19937? rng = new(seed);
        Assert.That(rng.StartingSeed, Is.EqualTo(seed));
    }

    [Test]
    public void TestNextUInt()
    {
        MT19937? rng = new();
        var value = rng.NextUInt();
        Assert.That(value, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void TestNextULong()
    {
        MT19937? rng = new();
        var value = rng.NextULong();
        Assert.That(value, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void TestNextBytes()
    {
        MT19937? rng = new();
        var buffer = new byte[10];
        rng.NextBytes(buffer);
        Assert.That(buffer.Any(b => b != 0), Is.True);
    }

    [Test]
    public void TestSetSeed()
    {
        DateTime startingTime = DateTime.Now;
        MT19937? rng = new();
        long seed = 987654321;
        rng.SetSeed(seed);
        Assert.That(rng.StartingSeed, Is.EqualTo(seed));
    }

    [Test]
    public void TestSharedRandom()
    {
        MT19937? sharedRng = MT19937.SharedRandom;
        Assert.That(sharedRng, Is.Not.Null);
    }

    [Test]
    public void TestSharedRandom_ThreadSafety()
    {
        MT19937? sharedRng = MT19937.SharedRandom;
        Assert.That(sharedRng, Is.Not.Null);

        // Test that multiple threads each get their own seed
        var threadCount = 100;
        ConcurrentBag<long>? seeds = new();
        List<Thread> threads = new();

        for (var i = 0; i < threadCount; i++)
        {
            Thread thread = new(() =>
            {
                MT19937 rng = MT19937.SharedRandom;
                seeds.Add(rng.StartingSeed);
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
