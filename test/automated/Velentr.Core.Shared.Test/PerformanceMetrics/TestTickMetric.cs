using NUnit.Framework;
using System;
using Velentr.Core.PerformanceMetrics;

namespace Velentr.Core.Test.PerformanceMetrics;

[TestFixture]
public class TestTickMetric
{
    [Test]
    public void TestAddTick()
    {
        var tickMetric = new TickMetric(10);
        tickMetric.AddTick(TimeSpan.FromSeconds(1));
        Assert.That(tickMetric.AverageTicksPerSecond, Is.EqualTo(1).Within(0.0001));

        tickMetric.AddTick(TimeSpan.FromSeconds(0.5));
        Assert.That(tickMetric.AverageTicksPerSecond, Is.EqualTo(1.5).Within(0.0001));

        tickMetric.AddTick(TimeSpan.FromSeconds(2));
        Assert.That(tickMetric.AverageTicksPerSecond, Is.EqualTo(1.1667).Within(0.0001));
    }

    [Test]
    public void TestAverageTicksPerSecond()
    {
        var tickMetric = new TickMetric(5);
        tickMetric.AddTick(TimeSpan.FromSeconds(1));
        tickMetric.AddTick(TimeSpan.FromSeconds(1));
        tickMetric.AddTick(TimeSpan.FromSeconds(1));
        tickMetric.AddTick(TimeSpan.FromSeconds(1));
        tickMetric.AddTick(TimeSpan.FromSeconds(1));
        Assert.That(tickMetric.AverageTicksPerSecond, Is.EqualTo(1).Within(0.0001));

        tickMetric.AddTick(TimeSpan.FromSeconds(0.5));
        Assert.That(tickMetric.AverageTicksPerSecond, Is.EqualTo(1.2).Within(0.0001));
    }

    [Test]
    public void TestMaximumSamples()
    {
        var tickMetric = new TickMetric(3);
        tickMetric.AddTick(TimeSpan.FromSeconds(1));
        tickMetric.AddTick(TimeSpan.FromSeconds(1));
        tickMetric.AddTick(TimeSpan.FromSeconds(1));
        Assert.That(tickMetric.AverageTicksPerSecond, Is.EqualTo(1).Within(0.0001));

        tickMetric.AddTick(TimeSpan.FromSeconds(0.5));
        Assert.That(tickMetric.AverageTicksPerSecond, Is.EqualTo(1.3333).Within(0.0001));

        tickMetric.AddTick(TimeSpan.FromSeconds(0.5));
        Assert.That(tickMetric.AverageTicksPerSecond, Is.EqualTo(1.6667).Within(0.0001));
    }
}
