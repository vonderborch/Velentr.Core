using Velentr.Core.Validation;

namespace Velentr.Core.Strings;

/// <summary>
///     Provides helper methods for string replacements.
/// </summary>
public static class Replacement
{
    /// <summary>
    ///     Replaces any occurrence of the specified strings in the input string with the given replacement string.
    /// </summary>
    /// <param name="str">The input string.</param>
    /// <param name="replacement">The replacement string.</param>
    /// <param name="stringsToReplace">The strings to be replaced.</param>
    /// <returns>The modified string with replacements.</returns>
    public static string ReplaceAny(this string str, string replacement, params string[] stringsToReplace)
    {
        Validations.NotNullOrEmptyCheck(str, nameof(str));
        Validations.NotNullCheck(replacement, nameof(replacement));
        Validations.NotNullCheck(stringsToReplace, nameof(stringsToReplace));

        var output = str;
        for (var i = 0; i < stringsToReplace.Length; i++)
        {
            output = output.Replace(stringsToReplace[i], replacement);
        }

        return output;
    }
}
