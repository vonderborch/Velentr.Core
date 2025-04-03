namespace Velentr.Core.IO;

/// <summary>
///     Provides helper methods for file operations such as copying and deleting files with retry logic.
/// </summary>
public static class FileHelpers
{
    /// <summary>
    ///     Deletes a file at the specified path if it exists, with retry logic.
    /// </summary>
    /// <param name="filePath">The path of the file to delete.</param>
    /// <param name="maxRetries">The maximum number of retry attempts if the deletion fails. Default is 10.</param>
    /// <param name="baseDelayMs">The base delay in milliseconds before retrying. Default is 50ms.</param>
    /// <param name="maxDelayMs">The maximum delay in milliseconds between retries. Default is 500ms.</param>
    /// <param name="delayMultiplier">The multiplier for the exponential backoff delay. Default is 2.</param>
    /// <exception cref="Exception">Thrown if the file could not be deleted after the specified number of retries.</exception>
    public static void DeleteFileIfExists(string filePath, int maxRetries = 10, int baseDelayMs = 50,
        int maxDelayMs = 500, double delayMultiplier = 2)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        for (var attempt = 0; attempt < maxRetries; attempt++)
        {
            try
            {
                File.Delete(filePath);
                return;
            }
            catch
            {
                if (attempt == maxRetries - 1)
                {
                    throw;
                }

                // Exponential backoff: 100ms, 200ms, 400ms, 800ms, 1600ms, etc.
                var delayMs = baseDelayMs * (int)Math.Pow(delayMultiplier, attempt);
                delayMs = Math.Min(delayMs, maxDelayMs);
                Thread.Sleep(delayMs);
            }
        }

        throw new Exception($"Could not delete file '{filePath}'");
    }

    /// <summary>
    ///     Copies a file from the source path to the destination path with retry logic.
    /// </summary>
    /// <param name="source">The path of the source file.</param>
    /// <param name="destination">The path of the destination file.</param>
    /// <param name="maxRetries">The maximum number of retry attempts if the copy fails. Default is 10.</param>
    /// <param name="baseDelayMs">The base delay in milliseconds before retrying. Default is 50ms.</param>
    /// <param name="maxDelayMs">The maximum delay in milliseconds between retries. Default is 500ms.</param>
    /// <param name="delayMultiplier">The multiplier for the exponential backoff delay. Default is 2.</param>
    /// <exception cref="Exception">Thrown if the file could not be copied after the specified number of retries.</exception>
    public static void SafeCopyFile(string source, string destination, int maxRetries = 10, int baseDelayMs = 50,
        int maxDelayMs = 500, double delayMultiplier = 2)
    {
        if (source == destination)
        {
            return;
        }

        var destinationDirectory = Path.GetDirectoryName(destination);
        if (!string.IsNullOrWhiteSpace(destinationDirectory))
        {
            DirectoryHelpers.CreateDirectoryIfNotExists(destinationDirectory);
        }

        for (var attempt = 0; attempt < maxRetries; attempt++)
        {
            try
            {
                File.Copy(source, destination, true);
                return;
            }
            catch
            {
                if (attempt == maxRetries - 1)
                {
                    throw;
                }

                // Exponential backoff: 100ms, 200ms, 400ms, 800ms, 1600ms, etc.
                var delayMs = baseDelayMs * (int)Math.Pow(delayMultiplier, attempt);
                delayMs = Math.Min(delayMs, maxDelayMs);
                Thread.Sleep(delayMs);
            }
        }

        throw new Exception($"Could not copy file '{source}' to destination '{destination}'");
    }
}
