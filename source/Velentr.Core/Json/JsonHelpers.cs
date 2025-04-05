using System.Text.Json;
using Velentr.Core.IO;

namespace Velentr.Core.Json;

/// <summary>
///     Provides helper methods for JSON serialization and deserialization, including operations with files and archives.
/// </summary>
public static class JsonHelpers
{
    /// <summary>
    ///     Deserializes JSON content from a file within an archive into an object of type <typeparamref name="T" />.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
    /// <param name="archive">The path of the archive containing the file.</param>
    /// <param name="file">The name of the file within the archive.</param>
    /// <returns>The deserialized object, or default if the file does not exist or is empty.</returns>
    public static T? DeserializeFromArchivedFile<T>(string archive, string file)
    {
        var contents = ArchiveHelpers.GetFileContentsFromArchive(archive, file);
        if (string.IsNullOrWhiteSpace(contents))
        {
            return default;
        }

        return DeserializeString<T>(contents);
    }

    /// <summary>
    ///     Deserializes JSON content from a file into an object of type <typeparamref name="TValue" />.
    /// </summary>
    /// <typeparam name="TValue">The type of the object to deserialize to.</typeparam>
    /// <param name="path">The path of the file containing the JSON content.</param>
    /// <param name="options">Optional JSON serializer options.</param>
    /// <returns>The deserialized object, or default if the file does not exist or is empty.</returns>
    public static TValue? DeserializeFromFile<TValue>(string path, JsonSerializerOptions? options = null)
    {
        if (!File.Exists(path))
        {
            return default;
        }

        var rawContents = File.ReadAllText(path);
        if (string.IsNullOrWhiteSpace(rawContents))
        {
            return default;
        }

        return DeserializeString<TValue>(rawContents, options);
    }

    /// <summary>
    ///     Deserializes JSON content from a string into an object of type <typeparamref name="TValue" />.
    /// </summary>
    /// <typeparam name="TValue">The type of the object to deserialize to.</typeparam>
    /// <param name="contents">The JSON content as a string.</param>
    /// <param name="options">Optional JSON serializer options.</param>
    /// <param name="raiseError">Indicates whether to raise an error if deserialization fails.</param>
    /// <returns>The deserialized object, or default if the content is empty or deserialization fails.</returns>
    public static TValue? DeserializeString<TValue>(string contents, JsonSerializerOptions? options = null,
        bool raiseError = false)
    {
        if (string.IsNullOrWhiteSpace(contents))
        {
            return default;
        }

        JsonSerializerOptions? actualOptions = options ?? JsonConstants.JsonSerializeOptions;

        try
        {
            return JsonSerializer.Deserialize<TValue>(contents, actualOptions);
        }
        catch
        {
            if (raiseError)
            {
                throw;
            }

            return default;
        }
    }

    /// <summary>
    ///     Serializes an object to JSON and writes it to a file.
    /// </summary>
    /// <param name="path">The path of the file to write to.</param>
    /// <param name="obj">The object to serialize.</param>
    /// <param name="options">Optional JSON serializer options.</param>
    public static void SerializeToFile(string path, object obj, JsonSerializerOptions? options = null)
    {
        var actualPath = Path.GetDirectoryName(path);
        if (!string.IsNullOrWhiteSpace(actualPath))
        {
            DirectoryHelpers.CreateDirectoryIfNotExists(actualPath);
        }

        var contents = SerializeToString(obj, options);
        File.WriteAllText(path, contents);
    }

    /// <summary>
    ///     Serializes an object to a JSON string.
    /// </summary>
    /// <param name="obj">The object to serialize.</param>
    /// <param name="options">Optional JSON serializer options.</param>
    /// <returns>The JSON string representation of the object.</returns>
    public static string SerializeToString(object obj, JsonSerializerOptions? options = null)
    {
        JsonSerializerOptions? actualOptions = options ?? JsonConstants.JsonSerializeOptions;
        var contents = JsonSerializer.Serialize(obj, actualOptions);

        return contents;
    }
}
