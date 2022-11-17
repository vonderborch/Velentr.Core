using System;

namespace Velentr.Core.Helpers.Time
{
    /// <summary>
    ///     Helpers when dealing with time.
    /// </summary>
    public static class TimeHelpers
    {
        /// <summary>
        ///     Elapsed milli seconds.
        /// </summary>
        /// <param name="startTime">    The start time. </param>
        /// <param name="endTime">      The end time. </param>
        /// <returns>
        ///     A double.
        /// </returns>
        public static double ElapsedMilliSeconds(TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime == TimeSpan.MinValue)
            {
                return endTime.TotalMilliseconds;
            }

            return startTime > endTime ? (startTime - endTime).TotalMilliseconds : (endTime - startTime).TotalMilliseconds;
        }

        /// <summary>
        ///     Elapsed seconds.
        /// </summary>
        /// <param name="startTime">    The start time. </param>
        /// <param name="endTime">      The end time. </param>
        /// <returns>
        ///     A double.
        /// </returns>
        public static double ElapsedSeconds(TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime == TimeSpan.MinValue)
            {
                return endTime.TotalSeconds;
            }

            return startTime > endTime ? (startTime - endTime).TotalSeconds : (endTime - startTime).TotalSeconds;
        }
    }
}
