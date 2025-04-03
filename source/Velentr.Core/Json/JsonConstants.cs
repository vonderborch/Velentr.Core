using System.Text.Json;
using System.Text.Json.Serialization;

namespace Velentr.Core.Json;

/// <summary>
///     Provides constants and default settings for JSON serialization and deserialization.
/// </summary>
public static class JsonConstants
{
    /// <summary>
    ///     Default options for JSON serialization, including indented formatting, enum conversion to strings, and field
    ///     inclusion.
    /// </summary>
    public static readonly JsonSerializerOptions JsonSerializeOptions = new()
        { WriteIndented = true, Converters = { new JsonStringEnumConverter() }, IncludeFields = true };
}
