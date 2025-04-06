using System.Collections.Concurrent;
using NUnit.Framework;
using Velentr.Core.Mathematics.Random;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

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
        var rng = new MT19937();
        Assert.That(rng, Is.Not.Null);
    }

    [Test]
    public void TestSeedConstructor()
    {
        long seed = 123456789;
        var rng = new MT19937(seed);
        Assert.That(rng.StartingSeed, Is.EqualTo(seed));
    }

    [Test]
    public void TestNextUInt()
    {
        var rng = new MT19937();
        uint value = rng.NextUInt();
        Assert.That(value, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void TestNextULong()
    {
        var rng = new MT19937();
        ulong value = rng.NextULong();
        Assert.That(value, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void TestNextBytes()
    {
        var rng = new MT19937();
        byte[] buffer = new byte[10];
        rng.NextBytes(buffer);
        Assert.That(buffer.Any(b => b != 0), Is.True);
    }

    [Test]
    public void TestSetSeed()
    {
        DateTime startingTime = DateTime.Now;
        var rng = new MT19937();
        long seed = 987654321;
        rng.SetSeed(seed);
        Assert.That(rng.StartingSeed, Is.EqualTo(seed));
    }

    [Test]
    public void TestSharedRandom()
    {
        var sharedRng = MT19937.SharedRandom;
        Assert.That(sharedRng, Is.Not.Null);
    }

    [Test]
    public void TestSharedRandom_ThreadSafety()
    {
        var sharedRng = MT19937.SharedRandom;
        Assert.That(sharedRng, Is.Not.Null);

        // Test that multiple threads each get their own seed
        int threadCount = 100;
        var seeds = new ConcurrentBag<long>();
        var threads = new List<Thread>();

        for (int i = 0; i < threadCount; i++)
        {
            var thread = new Thread(() =>
            {
                var rng = MT19937.SharedRandom;
                seeds.Add(rng.StartingSeed);
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
