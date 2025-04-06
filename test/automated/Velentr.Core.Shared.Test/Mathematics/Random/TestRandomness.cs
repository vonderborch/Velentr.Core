using Velentr.Core.Mathematics.Random;

namespace Velentr.Core.Test.Mathematics.Random;

[TestFixture]
public abstract class TestRandomness<TSelf>
{
    public abstract ARandomGenerator GetGenerator();

    [Test]
    public void TestKolmogorovSmirnovDistribution()
    {
        var rng = GetGenerator();
        int sampleSize = 100000;
        double[] samples = new double[sampleSize];

        for (int i = 0; i < sampleSize; i++)
        {
            samples[i] = rng.NextDouble();
        }

        Array.Sort(samples);

        double d = 0.0;
        for (int i = 0; i < sampleSize; i++)
        {
            double cdf = (i + 1.0) / sampleSize;
            double diff = Math.Max(Math.Abs(cdf - samples[i]), Math.Abs(samples[i] - (i / (double)sampleSize)));
            if (diff > d)
            {
                d = diff;
            }
        }

        double criticalValue = 1.36 / Math.Sqrt(sampleSize);
        Assert.That(d, Is.LessThan(criticalValue).Within(0.0001), "Kolmogorov-Smirnov test failed.");
    }
}
