namespace Velentr.Core.Strings.AsciiTables;

/// <summary>
///     Various modes for serializing a column.
/// </summary>
public enum AsciiColumnSerializationMode
{
    /// <summary>
    ///     Converts the object to a string using the ToString method.
    /// </summary>
    ToString = 1,

    /// <summary>
    ///     Converts the object to a string using JSON serialization.
    /// </summary>
    Serialize = 2,

    /// <summary>
    ///     Converts the object to a string using Velentr.Formatting.FormatString
    /// </summary>
    Formatted = 3
}
