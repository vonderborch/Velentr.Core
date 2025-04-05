using System.Diagnostics;

namespace Velentr.Core.PerformanceMetrics;


/// <summary>
/// A class that represents CPU and Memory metrics.
/// </summary>
public class ResourceMetrics : IDisposable
{
    /// <summary>
    /// The process.
    /// </summary>
    private Process process;

    /// <summary>
    /// The garbage collection memory samples.
    /// </summary>
    private readonly Dictionary<int, long> gcMemorySamples;

    /// <summary>
    /// The memory samples.
    /// </summary>
    private readonly Dictionary<int, long> memorySamples;

    /// <summary>
    /// The CPU samples.
    /// </summary>
    private readonly Dictionary<int, double> cpuSamples;

    /// <summary>
    /// The current index.
    /// </summary>
    private int currentIndex;

    /// <summary>
    /// The previous time.
    /// </summary>
    private DateTime previousTime;

    /// <summary>
    /// The previous processor time.
    /// </summary>
    private TimeSpan previousProcessorTime;

    /// <summary>
    /// The sleep time in milliseconds.
    /// </summary>
    private readonly int sleepTimeMilliseconds;

    /// <summary>
    /// The cancellation token.
    /// </summary>
    private CancellationTokenSource cancellationToken;

    /// <summary>
    /// The update thread.
    /// </summary>
    private Task updateThread;

    /// <summary>
    /// The maximum number of samples to keep.
    /// </summary>
    private readonly int maximumSamples;

    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceMetrics"/> class.
    /// </summary>
    /// <param name="maximumSamples">The maximum samples to keep.</param>
    /// <param name="sleepTimeMilliseconds">The update thead sleep time in milliseconds.</param>
    public ResourceMetrics(int maximumSamples, int sleepTimeMilliseconds = 500)
    {
        this.process = Process.GetCurrentProcess();
        this.previousProcessorTime = this.process.TotalProcessorTime;
        this.previousTime = DateTime.Now;

        this.maximumSamples = maximumSamples;
        this.memorySamples = new Dictionary<int, long>(maximumSamples);
        this.gcMemorySamples = new Dictionary<int, long>(maximumSamples);
        this.cpuSamples = new Dictionary<int, double>(maximumSamples);
        this.cancellationToken = new CancellationTokenSource();
        this.sleepTimeMilliseconds = sleepTimeMilliseconds;
        this.updateThread = new Task(UpdateTask, this.cancellationToken.Token);
        this.updateThread.Start();
    }

    /// <summary>
    /// The average memory usage in MB.
    /// </summary>
    public double AverageMemoryUsageMb { get; private set; }

    /// <summary>
    /// The average garbage collection memory usage in MB.
    /// </summary>
    public double AverageGcMemoryUsageMb { get; private set; }

    /// <summary>
    /// The average CPU percent.
    /// </summary>
    public double AverageCpuPercent { get; private set; }

    /// <summary>
    /// The update method.
    /// </summary>
    public void Update()
    {
        if (this.updateThread.IsCompleted)
        {
            this.updateThread = new Task(UpdateTask, this.cancellationToken.Token);
            this.updateThread.Start();
        }
        else if (this.updateThread.IsFaulted)
        {
            this.cancellationToken = new CancellationTokenSource();
            this.updateThread = new Task(UpdateTask, this.cancellationToken.Token);
            this.updateThread.Start();
        }
    }

    /// <summary>
    /// The update task.
    /// </summary>
    private void UpdateTask()
    {
        while (!this.cancellationToken.Token.IsCancellationRequested)
        {
            this.process.Refresh();
            var newTime = DateTime.Now;
            var newProcessorTime = this.process.TotalProcessorTime;

            this.gcMemorySamples[this.currentIndex] = GC.GetTotalMemory(false);
            this.memorySamples[this.currentIndex] = this.process.WorkingSet64;

            var cpuUsedMilliseconds = (newProcessorTime - this.previousProcessorTime).TotalMilliseconds;
            var totalMilliseconds = (newTime - this.previousTime).TotalMilliseconds;
            this.cpuSamples[this.currentIndex] =
                cpuUsedMilliseconds / (Environment.ProcessorCount * totalMilliseconds) * 100d;

            this.AverageGcMemoryUsageMb = this.gcMemorySamples.Average(pair => pair.Value) / 1024d / 1024d;
            this.AverageMemoryUsageMb = this.memorySamples.Average(pair => pair.Value) / 1024d / 1024d;
            this.AverageCpuPercent = this.cpuSamples.Average(pair => pair.Value);

            this.currentIndex = (this.currentIndex + 1) % this.maximumSamples;
            this.previousTime = newTime;
            this.previousProcessorTime = newProcessorTime;
            Thread.Sleep(this.sleepTimeMilliseconds);
        }
    }

    /// <summary>
    /// Disposes of the object.
    /// </summary>
    public void Dispose()
    {
        this.cancellationToken.Cancel();
        this.updateThread.Wait();
        this.cancellationToken.Dispose();
    }
}
