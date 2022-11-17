using System.IO;
using System.Text;

namespace Velentr.Core.Helpers.Streams
{
    /// <summary>
    ///     Helpers for dealing with streams.
    /// </summary>
    public static class StreamHelpers
    {
        /// <summary>
        ///     Reads a stream.
        /// </summary>
        /// <param name="stream">   The stream. </param>
        /// <returns>
        ///     The stream.
        /// </returns>
        public static byte[] ReadStream(Stream stream)
        {
            byte[] output;
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                output = ms.ToArray();
            }

            return output;
        }

        /// <summary>
        ///     Reads a stream.
        /// </summary>
        /// <param name="stream">   The stream. </param>
        /// <param name="encoding"> The encoding. </param>
        /// <returns>
        ///     The stream.
        /// </returns>
        public static string ReadStream(Stream stream, Encoding encoding)
        {
            return encoding.GetString(ReadStream(stream));
        }
    }
}
