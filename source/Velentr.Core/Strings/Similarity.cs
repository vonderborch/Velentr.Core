using Velentr.Core.Mathematics;
using Velentr.Core.Validation;

namespace Velentr.Core.Strings;

/// <summary>
///     Provides methods for calculating string similarity.
/// </summary>
public static class Similarity
{
    /// <summary>
    ///     Computes the Damerau-Levenshtein distance between two strings.
    ///     Based on: https://stackoverflow.com/questions/6944056/c-sharp-compare-string-similarity
    /// </summary>
    /// <param name="stringA">The first string.</param>
    /// <param name="stringB">The second string.</param>
    /// <returns>The Damerau-Levenshtein distance between the two strings.</returns>
    /// <exception cref="ArgumentException">Thrown when either string is null or empty.</exception>
    public static int ComputeSimilarity(string stringA, string stringB)
    {
        Validations.NotNullCheck(stringA, nameof(stringA));
        Validations.NotNullCheck(stringB, nameof(stringB));

        // If one of the two strings is empty, return the length of the other string
        if (stringA.Length == 0)
        {
            return stringB.Length;
        }

        if (stringB.Length == 0)
        {
            return stringA.Length;
        }

        var previousCostArray = new int[stringA.Length + 1]; // 'previous' cost array, horizontally
        var costArray = new int[stringA.Length + 1]; // cost array, horizontally

        // indexes for strings stringA and stringB
        int i; // iterates through stringA
        int j; // iterates through stringB

        for (i = 0; i <= stringA.Length; i++)
        {
            previousCostArray[i] = i;
        }

        for (j = 1; j <= stringB.Length; j++)
        {
            var tJ = stringB[j - 1]; // jth character of t
            costArray[0] = j;

            for (i = 1; i <= stringA.Length; i++)
            {
                var cost = stringA[i - 1] == tJ ? 0 : 1; // cost

                // minimum of cell to the left+1, to the top+1, diagonally left and up +cost
                costArray[i] = Maths<int>.Minimum(costArray[i - 1] + 1, previousCostArray[i] + 1,
                    previousCostArray[i - 1] + cost);
            }

            // copy current distance counts to 'previous row' distance counts
            (previousCostArray, costArray) = (costArray, previousCostArray);
        }

        // our last action in the above loop was to switch d and p, so p now
        // actually has the most recent cost counts
        return previousCostArray[stringA.Length];
    }

    /// <summary>
    ///     Computes the similarity between two strings using the Damerau-Levenshtein distance.
    /// </summary>
    /// <param name="stringA">The first string.</param>
    /// <param name="stringB">The second string.</param>
    /// <returns>The Damerau-Levenshtein distance between the two strings.</returns>
    /// <exception cref="ArgumentException">Thrown when either string is null or empty.</exception>
    public static int SimilarityTo(this string stringA, string stringB)
    {
        return ComputeSimilarity(stringA, stringB);
    }
}
