using Microsoft.Xna.Framework;

namespace Velentr.Core.Time;

/// <summary>
///     Provides extended helper methods for time calculations.
/// </summary>
public static class TimeHelpersExtended
{
    /// <summary>
    ///     Calculates the elapsed milliseconds between the start time and the end time.
    /// </summary>
    /// <param name="startTime">The start time.</param>
    /// <param name="endTime">The end time represented as a <see cref="GameTime" /> object.</param>
    /// <returns>The elapsed milliseconds.</returns>
    public static double ElapsedMilliSeconds(TimeSpan startTime, GameTime endTime)
    {
        return TimeHelpers.ElapsedMilliSeconds(startTime, endTime.ElapsedGameTime);
    }

    /// <summary>
    ///     Calculates the elapsed seconds between the start time and the end time.
    /// </summary>
    /// <param name="startTime">The start time.</param>
    /// <param name="endTime">The end time represented as a <see cref="GameTime" /> object.</param>
    /// <returns>The elapsed seconds.</returns>
    public static double ElapsedSeconds(TimeSpan startTime, GameTime endTime)
    {
        return TimeHelpers.ElapsedSeconds(startTime, endTime.ElapsedGameTime);
    }
}
