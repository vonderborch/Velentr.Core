using Velentr.Core.PerformanceMetrics;

namespace Velentr.Core.Test.PerformanceMetrics;

[TestFixture]
public class TestResourceMetrics
{
    [Test]
    public void TestUpdate()
    {
        ResourceMetrics resourceMetrics = new(5, 100);
        resourceMetrics.Update();
        Thread.Sleep(200); // Allow some time for the update thread to run

        Assert.That(resourceMetrics.AverageCpuPercent, Is.GreaterThanOrEqualTo(0));
        Assert.That(resourceMetrics.AverageMemoryUsageMb, Is.GreaterThanOrEqualTo(0));
        Assert.That(resourceMetrics.AverageGcMemoryUsageMb, Is.GreaterThanOrEqualTo(0));
        resourceMetrics.Dispose();
    }

    [Test]
    public void TestDispose()
    {
        ResourceMetrics resourceMetrics = new(5, 100);
        resourceMetrics.Update();
        Thread.Sleep(200); // Allow some time for the update thread to run

        resourceMetrics.Dispose();
        Assert.Throws<ObjectDisposedException>(() => resourceMetrics.Update());
    }

    [Test]
    public void TestMaximumSamples()
    {
        ResourceMetrics resourceMetrics = new(3, 100);
        resourceMetrics.Update();
        Thread.Sleep(400); // Allow some time for the update thread to run

        Assert.That(resourceMetrics.AverageCpuPercent, Is.GreaterThanOrEqualTo(0));
        Assert.That(resourceMetrics.AverageMemoryUsageMb, Is.GreaterThanOrEqualTo(0));
        Assert.That(resourceMetrics.AverageGcMemoryUsageMb, Is.GreaterThanOrEqualTo(0));
        resourceMetrics.Dispose();
    }
}
