using Velentr.Core.Mathematics.Random;

namespace Velentr.Core.Test.Mathematics.Random;

[TestFixture]
public abstract class TestRandomness<TSelf>
{
    public abstract ARandomGenerator GetGenerator();

    [Test]
    public void TestKolmogorovSmirnovDistribution()
    {
        ARandomGenerator? rng = GetGenerator();
        var sampleSize = 100000;
        var samples = new double[sampleSize];

        for (var i = 0; i < sampleSize; i++)
        {
            samples[i] = rng.NextDouble();
        }

        Array.Sort(samples);

        var d = 0.0;
        for (var i = 0; i < sampleSize; i++)
        {
            var cdf = (i + 1.0) / sampleSize;
            var diff = Math.Max(Math.Abs(cdf - samples[i]), Math.Abs(samples[i] - i / (double)sampleSize));
            if (diff > d)
            {
                d = diff;
            }
        }

        var criticalValue = 1.36 / Math.Sqrt(sampleSize);
        Assert.That(d, Is.LessThan(criticalValue).Within(0.0001), "Kolmogorov-Smirnov test failed.");
    }
}
