using System.Collections.Generic;

using Velentr.Core.Helpers.Strings;

namespace Velentr.Core.Helpers.Extensions
{
    /// <summary>
    ///     Extensions for lists.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Enumerates split by new line in this collection.
        /// </summary>
        /// <param name="str">  The str to act on. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process split by new line in this collection.
        /// </returns>
        public static IEnumerable<string> SplitByNewLine(this string str)
        {
            return StringHelpers.SplitStringByNewLines(str);
        }

        /// <summary>
        ///     Enumerates split by chunk size in this collection.
        /// </summary>
        /// <param name="str">          The str to act on. </param>
        /// <param name="chunkSize">    Size of the chunk. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process split by chunk size in this
        ///     collection.
        /// </returns>
        public static IEnumerable<string> SplitByChunkSize(this string str, int chunkSize)
        {
            return StringHelpers.SplitStringByChunkSize(str, chunkSize);
        }

        /// <summary>
        ///     A string extension method that formats.
        /// </summary>
        /// <param name="str">          The str to act on. </param>
        /// <param name="parameters">   A variable-length parameters list containing parameters. </param>
        /// <returns>
        ///     The formatted value.
        /// </returns>
        public static string Format(this string str, params object[] parameters)
        {
            return StringHelpers.FormatString(str, parameters);
        }

        /// <summary>
        ///     A string extension method that calculates the similarity.
        /// </summary>
        /// <param name="str">      The str to act on. </param>
        /// <param name="other">    The other. </param>
        /// <returns>
        ///     The calculated similarity.
        /// </returns>
        public static int ComputeSimilarity(this string str, string other)
        {
            return Similarity.ComputeDamerauLevenshteinDistance(str, other);
        }
    }
}
