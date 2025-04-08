namespace Velentr.Core.Time;

/// <summary>
///     Provides helper methods for time-related calculations.
/// </summary>
public static class TimeHelpers
{
    /// <summary>
    ///     Calculates the elapsed time in milliseconds between two `TimeSpan` values.
    /// </summary>
    /// <param name="startTime">The start time.</param>
    /// <param name="endTime">The end time.</param>
    /// <returns>The elapsed time in milliseconds.</returns>
    public static double ElapsedMilliSeconds(TimeSpan startTime, TimeSpan endTime)
    {
        if (startTime == TimeSpan.MinValue)
        {
            return endTime.TotalMilliseconds;
        }

        return startTime > endTime ? (startTime - endTime).TotalMilliseconds : (endTime - startTime).TotalMilliseconds;
    }

    /// <summary>
    /// </summary>
    /// <param name="startTime">The start time.</param>
    /// <param name="endTime">The end time.</param>
    /// <returns>The elapsed time in seconds.</returns>
    public static double ElapsedSeconds(TimeSpan startTime, TimeSpan endTime)
    {
        if (startTime == TimeSpan.MinValue)
        {
            return endTime.TotalSeconds;
        }

        return startTime > endTime ? (startTime - endTime).TotalSeconds : (endTime - startTime).TotalSeconds;
    }
}
