using System.Collections.Generic;

namespace Velentr.Core.Helpers.DataStructures
{
    /// <summary>
    ///     Helpers when comparing if various collections are equivalent or not.
    /// </summary>
    public static class CollectionEquivalencyHelpers
    {
        /// <summary>
        ///     Lists equivalent.
        /// </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="a">    A List&lt;T&gt; to process. </param>
        /// <param name="b">    A List&lt;T&gt; to process. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public static bool ListsEquivalent<T>(List<T> a, List<T> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }

            for (var i = 0; i < a.Count && i < b.Count; i++)
            {
                if (!a[i].Equals(b[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
