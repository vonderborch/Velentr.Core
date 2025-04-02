using Velentr.Core.Validation;

namespace Velentr.Helpers.Strings;

/// <summary>
/// Provides methods for splitting strings by chunk size or new lines.
/// </summary>
public static class Splitting
{
    private static readonly string[] NewLineChars = ["\r\n", "\r", "\n"];

    /// <summary>
    /// Splits the string into chunks of the specified size.
    /// </summary>
    /// <param name="value">The string to split.</param>
    /// <param name="chunkSize">The size of each chunk.</param>
    /// <returns>An enumerable of string chunks.</returns>
    public static IEnumerable<string> SplitByChunkSize(this string value, int chunkSize)
    {
        return SplitStringByChunkSize(value, chunkSize);
    }

    /// <summary>
    /// Splits the string by new line characters.
    /// </summary>
    /// <param name="value">The string to split.</param>
    /// <returns>An enumerable of strings split by new lines.</returns>
    public static IEnumerable<string> SplitByNewLines(this string value)
    {
        return SplitStringByNewLines(value);
    }

    /// <summary>
    /// Splits the string into chunks of the specified size.
    /// </summary>
    /// <param name="str">The string to split.</param>
    /// <param name="chunkSize">The size of each chunk.</param>
    /// <returns>An enumerable of string chunks.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when chunkSize is less than 1.</exception>
    public static IEnumerable<string> SplitStringByChunkSize(string str, int chunkSize)
    {
        Validations.ValidateRange(chunkSize, nameof(chunkSize), 1, int.MaxValue);

        for (var i = 0; i < str.Length; i += chunkSize)
        {
            yield return str.Substring(i, Math.Min(chunkSize, str.Length - i));
        }
    }

    /// <summary>
    /// Splits the string by new line characters.
    /// </summary>
    /// <param name="str">The string to split.</param>
    /// <returns>An enumerable of strings split by new lines.</returns>
    public static IEnumerable<string> SplitStringByNewLines(string str)
    {
        return str.Split(NewLineChars, StringSplitOptions.None);
    }
}