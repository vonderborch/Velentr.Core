using System;

namespace Velentr.Core
{
    /// <summary>
    ///     The time state of a game.
    /// </summary>
    public partial class GameTime
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public GameTime()
        {
            this.TotalGameTime = TimeSpan.Zero;
            this.ElapsedGameTime = TimeSpan.Zero;
            this.IsRunningSlowly = false;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="totalGameTime">    The total number of game time. </param>
        /// <param name="elapsedGameTime">  The elapsed game time. </param>
        public GameTime(TimeSpan totalGameTime, TimeSpan elapsedGameTime)
        {
            this.TotalGameTime = totalGameTime;
            this.ElapsedGameTime = elapsedGameTime;
            this.IsRunningSlowly = false;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="totalRealTime">    The total real time. </param>
        /// <param name="elapsedRealTime">  The elapsed real time. </param>
        /// <param name="isRunningSlowly">  True if this object is running slowly, false if not. </param>
        public GameTime(TimeSpan totalRealTime, TimeSpan elapsedRealTime, bool isRunningSlowly)
        {
            this.TotalGameTime = totalRealTime;
            this.ElapsedGameTime = elapsedRealTime;
            this.IsRunningSlowly = isRunningSlowly;
        }

        /// <summary>
        ///     Gets or sets the total number of game time.
        /// </summary>
        /// <value>
        ///     The total number of game time.
        /// </value>
        public TimeSpan TotalGameTime { get; set; }

        /// <summary>
        ///     Gets or sets the elapsed game time.
        /// </summary>
        /// <value>
        ///     The elapsed game time.
        /// </value>
        public TimeSpan ElapsedGameTime { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this object is running slowly.
        /// </summary>
        /// <value>
        ///     True if this object is running slowly, false if not.
        /// </value>
        public bool IsRunningSlowly { get; set; }
    }
}
