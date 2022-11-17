#if FNA || MONOGAME
using Microsoft.Xna.Framework;

namespace Velentr.Core.Helpers.Extensions
{
    /// <summary>
    ///     Extensions when dealing with GameTime objects.
    /// </summary>
    public static class GameTimeExtensions
    {
        /// <summary>
        ///     A Velentr.Core.GameTime extension method that converts a source Velentr.Core.GameTime object to a
        ///     Microsoft.Xna.Framework.GameTime.
        /// </summary>
        /// <param name="source">   The source to act on. </param>
        /// <returns>
        ///     Source as a Microsoft.Xna.Framework.GameTime.
        /// </returns>
        public static Microsoft.Xna.Framework.GameTime ToXnaGameTime(this GameTime source)
        {
            return new Microsoft.Xna.Framework.GameTime(source.TotalGameTime, source.ElapsedGameTime, source.IsRunningSlowly);
        }

        /// <summary>
        ///     A Microsoft.Xna.Framework.GameTime extension method that converts a source Microsoft.Xna.Framework.GameTime object
        ///     to a Velentr.Core.GameTime.
        /// </summary>
        /// <param name="source">   The source to act on. </param>
        /// <returns>
        ///     Source as a Microsoft.Xna.Framework.GameTime.
        /// </returns>
        public static GameTime ToXnaGameTime(this Microsoft.Xna.Framework.GameTime source)
        {
            return new GameTime(source.TotalGameTime, source.ElapsedGameTime, source.IsRunningSlowly);
        }
    }
}

#endif
