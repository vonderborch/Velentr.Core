using System.Collections.Concurrent;
using NUnit.Framework;
using Velentr.Core.Mathematics.Random;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace Velentr.Core.Test.Mathematics.Random;

[TestFixture]
// ReSharper disable once InconsistentNaming
public class TestSimpleRng : TestRandomness<SimpleRng>
{
    public override ARandomGenerator GetGenerator()
    {
        return new SimpleRng();
    }
    
    [Test]
    public void TestDefaultConstructor()
    {
        var rng = new SimpleRng();
        Assert.That(rng, Is.Not.Null);
    }

    [Test]
    public void TestSeedConstructor()
    {
        long seed = 123456789;
        var rng = new SimpleRng(seed);
        Assert.That(rng.Seed, Is.EqualTo(seed));
    }

    [Test]
    public void TestNextUInt()
    {
        var rng = new SimpleRng();
        uint value = rng.NextUInt();
        Assert.That(value, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void TestNextULong()
    {
        var rng = new SimpleRng();
        ulong value = rng.NextULong();
        Assert.That(value, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void TestNextBytes()
    {
        var rng = new SimpleRng();
        byte[] buffer = new byte[10];
        rng.NextBytes(buffer);
        Assert.That(buffer.Any(b => b != 0), Is.True);
    }

    [Test]
    public void TestSetSeed()
    {
        DateTime startingTime = DateTime.Now;
        var rng = new SimpleRng();
        long seed = 987654321;
        rng.SetSeed(seed);
        Assert.That(rng.Seed, Is.EqualTo(seed));
        _ = rng.NextUInt(); // Call NextUInt to ensure the state is updated
        Assert.That(rng.Seed, Is.Not.EqualTo(seed));
        Assert.That(rng.StartingSeed, Is.EqualTo(DateTime.Now.Ticks).Within((DateTime.Now - startingTime).Ticks));
        Assert.That(rng.Seed, Is.EqualTo(482433070));
    }

    [Test]
    public void TestSeedUpdate()
    {
        var rng = new SimpleRng();
        _ = rng.NextUInt(); // Call NextUInt to ensure the state is updated
        var rng2 = new SimpleRng(rng.Seed);
        Assert.That(rng2.Seed, Is.EqualTo(rng.Seed));
        Assert.That(rng2.NextUInt(), Is.EqualTo(rng.NextUInt()));
    }

    [Test]
    public void TestSharedRandom()
    {
        var sharedRng = SimpleRng.SharedRandom;
        Assert.That(sharedRng, Is.Not.Null);
    }

    [Test]
    public void TestSharedRandom_ThreadSafety()
    {
        var sharedRng = SimpleRng.SharedRandom;
        Assert.That(sharedRng, Is.Not.Null);

        // Test that multiple threads each get their own seed
        int threadCount = 100;
        var seeds = new ConcurrentBag<long>();
        var threads = new List<Thread>();

        for (int i = 0; i < threadCount; i++)
        {
            var thread = new Thread(() =>
            {
                var rng = SimpleRng.SharedRandom;
                seeds.Add(rng.Seed);
            });
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Assert.That(seeds.Distinct().Count(), Is.EqualTo(threadCount));
    }
}
