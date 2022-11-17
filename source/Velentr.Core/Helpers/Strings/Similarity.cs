using System;

namespace Velentr.Core.Helpers.Strings
{
    /// <summary>
    ///     Helpers for dealing with string similarity.
    /// </summary>
    public static class Similarity
    {
        /// <summary>
        ///     Calculates the levenshtein distance. Pulled from
        ///     https://stackoverflow.com/questions/6944056/c-sharp-compare-string-similarity.
        /// </summary>
        /// <param name="s">    The string. </param>
        /// <param name="t">    A string to process. </param>
        /// <returns>
        ///     The calculated levenshtein distance.
        /// </returns>
        [Obsolete("Use the ComputeDamerauLevenshteinDistance instead!")]
        public static int ComputeLevenshteinDistance(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                {
                    return 0;
                }

                return t.Length;
            }

            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }

            var n = s.Length;
            var m = t.Length;
            var d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (var i = 0; i <= n; d[i, 0] = i++)
            {
                ;
            }

            for (var j = 1; j <= m; d[0, j] = j++)
            {
                ;
            }

            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= m; j++)
                {
                    var cost = t[j - 1] == s[i - 1] ? 0 : 1;
                    var min1 = d[i - 1, j] + 1;
                    var min2 = d[i, j - 1] + 1;
                    var min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = System.Math.Min(System.Math.Min(min1, min2), min3);
                }
            }

            return d[n, m];
        }

        /// <summary>
        ///     Calculates the damerau levenshtein distance. Pulled from
        ///     https://stackoverflow.com/questions/6944056/c-sharp-compare-string-similarity.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="s">    The string. </param>
        /// <param name="t">    A string to process. </param>
        /// <returns>
        ///     The calculated damerau levenshtein distance.
        /// </returns>
        public static int ComputeDamerauLevenshteinDistance(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(s, "String Cannot Be Null Or Empty");
            }

            if (string.IsNullOrEmpty(t))
            {
                throw new ArgumentNullException(t, "String Cannot Be Null Or Empty");
            }

            var n = s.Length; // length of s
            var m = t.Length; // length of t

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            var p = new int[n + 1]; //'previous' cost array, horizontally
            var d = new int[n + 1]; // cost array, horizontally

            // indexes into strings s and t
            int i; // iterates through s
            int j; // iterates through t

            for (i = 0; i <= n; i++)
            {
                p[i] = i;
            }

            for (j = 1; j <= m; j++)
            {
                var tJ = t[j - 1]; // jth character of t
                d[0] = j;

                for (i = 1; i <= n; i++)
                {
                    var cost = s[i - 1] == tJ ? 0 : 1; // cost

                    // minimum of cell to the left+1, to the top+1, diagonally left and up +cost
                    d[i] = System.Math.Min(System.Math.Min(d[i - 1] + 1, p[i] + 1), p[i - 1] + cost);
                }

                // copy current distance counts to 'previous row' distance counts
                var dPlaceholder = p; //placeholder to assist in swapping p and d
                p = d;
                d = dPlaceholder;
            }

            // our last action in the above loop was to switch d and p, so p now
            // actually has the most recent cost counts
            return p[n];
        }
    }
}
