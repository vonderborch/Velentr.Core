namespace Velentr.Core.PerformanceMetrics;

/// <summary>
/// Represents a metric for tracking ticks per second over a specified number of samples.
/// </summary>
/// <remarks>
/// This class maintains a collection of tick samples and calculates the average ticks per second.
/// It is useful for performance monitoring and ensuring consistent tick/frame rates in applications.
/// </remarks>
public class TickMetric
{
    /// <summary>
    /// The samples.
    /// </summary>
    private readonly Dictionary<int, double> samples;

    /// <summary>
    /// The current index.
    /// </summary>
    private int currentIndex;

    /// <summary>
    /// The maximum number of samples to keep.
    /// </summary>
    private readonly int maximumSamples;

    /// <summary>
    /// Initializes a new instance of the <see cref="TickMetric"/> class.
    /// </summary>
    /// <param name="maximumSamples">The maximum number of samples to keep.</param>
    public TickMetric(int maximumSamples)
    {
        this.maximumSamples = maximumSamples;
        this.samples = new Dictionary<int, double>(maximumSamples);
    }

    /// <summary>
    /// The average ticks per second.
    /// </summary>
    public double AverageTicksPerSecond { get; private set; }

    /// <summary>
    /// Records a tick.
    /// </summary>
    /// <param name="timeSpan">The timespan since the last instance.</param>
    public void AddTick(TimeSpan timeSpan)
    {
        this.samples[this.currentIndex] = 1d / timeSpan.TotalSeconds;
        this.AverageTicksPerSecond = this.samples.Average(pair => pair.Value);
        this.currentIndex = (this.currentIndex + 1) % this.maximumSamples;
    }
}
