using System.Runtime.CompilerServices;

namespace Velentr.Core.Strings;

/// <summary>
///     Provides extension methods for the String type, enabling null and whitespace checks without modifying the original
///     type.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    ///     Checks whether the specified string is null or empty.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>true if the value is null or empty; otherwise, false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(this string? value)
    {
        return string.IsNullOrEmpty(value);
    }

    /// <summary>
    ///     Checks whether the specified string is null or consists solely of white-space characters.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>true if the value is null or contains only whitespace; otherwise, false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrWhiteSpace(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    ///     Joins elements of a collection into a single string using the specified separator.
    /// </summary>
    /// <param name="separator">The string used to separate the elements in the resulting string.</param>
    /// <param name="values">The collection of items to join.</param>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <returns>A single string that contains the elements joined by the separator.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Join<T>(this string separator, IEnumerable<T> values)
    {
        IEnumerable<string> stringValues =
            values as IEnumerable<string> ?? values.Select(v => v?.ToString() ?? string.Empty);
        return string.Join(separator, stringValues);
    }

    /// <summary>
    ///     Joins elements of a collection into a single string using the specified separator.
    /// </summary>
    /// <param name="separator">The string used to separate the elements in the resulting string.</param>
    /// <param name="values">The collection of items to join.</param>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <returns>A single string that contains the elements joined by the separator.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Join<T>(this IEnumerable<T> values, string separator)
    {
        IEnumerable<string> stringValues =
            values as IEnumerable<string> ?? values.Select(v => v?.ToString() ?? string.Empty);
        return string.Join(separator, stringValues);
    }
}
