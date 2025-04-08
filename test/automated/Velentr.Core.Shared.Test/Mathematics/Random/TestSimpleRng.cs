using System.Collections.Concurrent;
using Velentr.Core.Mathematics.Random;

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
        SimpleRng? rng = new();
        Assert.That(rng, Is.Not.Null);
    }

    [Test]
    public void TestSeedConstructor()
    {
        long seed = 123456789;
        SimpleRng? rng = new(seed);
        Assert.That(rng.Seed, Is.EqualTo(seed));
    }

    [Test]
    public void TestNextUInt()
    {
        SimpleRng? rng = new();
        var value = rng.NextUInt();
        Assert.That(value, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void TestNextULong()
    {
        SimpleRng? rng = new();
        var value = rng.NextULong();
        Assert.That(value, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void TestNextBytes()
    {
        SimpleRng? rng = new();
        var buffer = new byte[10];
        rng.NextBytes(buffer);
        Assert.That(buffer.Any(b => b != 0), Is.True);
    }

    [Test]
    public void TestSetSeed()
    {
        DateTime startingTime = DateTime.Now;
        SimpleRng? rng = new();
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
        SimpleRng? rng = new();
        _ = rng.NextUInt(); // Call NextUInt to ensure the state is updated
        SimpleRng rng2 = new(rng.Seed);
        Assert.That(rng2.Seed, Is.EqualTo(rng.Seed));
        Assert.That(rng2.NextUInt(), Is.EqualTo(rng.NextUInt()));
    }

    [Test]
    public void TestSharedRandom()
    {
        ARandomGenerator? sharedRng = SimpleRng.SharedRandom;
        Assert.That(sharedRng, Is.Not.Null);
    }

    [Test]
    public void TestSharedRandom_ThreadSafety()
    {
        ARandomGenerator? sharedRng = SimpleRng.SharedRandom;
        Assert.That(sharedRng, Is.Not.Null);

        // Test that multiple threads each get their own seed
        var threadCount = 100;
        ConcurrentBag<long>? seeds = new();
        List<Thread> threads = new();

        for (var i = 0; i < threadCount; i++)
        {
            Thread thread = new(() =>
            {
                ARandomGenerator rng = SimpleRng.SharedRandom;
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
