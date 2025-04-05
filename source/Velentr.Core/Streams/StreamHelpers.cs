using System.Text;

namespace Velentr.Core.Streams;

/// <summary>
///     Provides helper methods for working with streams.
/// </summary>
public class StreamHelpers
{
    /// <summary>
    ///     Reads the entire content of a stream and returns it as a byte array.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <returns>A byte array containing the content of the stream.</returns>
    public static byte[] ReadStream(Stream stream)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        byte[] output;
        using (MemoryStream? ms = new())
        {
            stream.CopyTo(ms);
            output = ms.ToArray();
        }

        return output;
    }

    /// <summary>
    ///     Reads the entire content of a stream and returns it as a string using the specified encoding.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <returns>A string containing the content of the stream.</returns>
    public static string ReadStream(Stream stream, Encoding encoding)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        return encoding.GetString(ReadStream(stream));
    }
}
