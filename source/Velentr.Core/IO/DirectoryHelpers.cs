namespace Velentr.Core.IO;

/// <summary>
///     Provides helper methods for directory operations such as copying, creating, and deleting directories with retry
///     logic.
/// </summary>
public static class DirectoryHelpers
{
    /// <summary>
    ///     Copies the contents of a source directory to a destination directory.
    /// </summary>
    /// <param name="source">The path of the source directory.</param>
    /// <param name="destination">The path of the destination directory.</param>
    /// <remarks>
    ///     This method will create the destination directory if it does not exist.
    ///     It will copy all files and subdirectories from the source to the destination.
    /// </remarks>
    /// <exception cref="IOException">Thrown when an I/O error occurs during copying.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when the caller does not have the required permission.</exception>
    public static void CopyDirectory(string source, string destination)
    {
        CreateDirectoryIfNotExists(destination);

        // Copy over items
        var files = Directory.GetFiles(source);
        foreach (var file in files)
        {
            var path = Path.Combine(destination, Path.GetFileName(file));

            FileHelpers.SafeCopyFile(file, path);
        }

        // Copy over sub-directories
        var directories = Directory.GetDirectories(source);
        foreach (var directory in directories)
        {
            var dirName = Path.GetFileName(directory);
            var path = Path.Combine(destination, dirName);
            CopyDirectory(directory, path);
        }
    }

    /// <summary>
    ///     Creates the specified directory if it does not already exist.
    /// </summary>
    /// <param name="directory">The path of the directory to create.</param>
    public static void CreateDirectoryIfNotExists(string directory)
    {
        if (!Directory.Exists(directory))
        {
            _ = Directory.CreateDirectory(directory);
        }
    }

    /// <summary>
    ///     Deletes the specified directory if it exists, with retry logic.
    /// </summary>
    /// <param name="directory">The path of the directory to delete.</param>
    /// <param name="maxRetries">The maximum number of retry attempts if the deletion fails. Default is 10.</param>
    /// <param name="baseDelayMs">The base delay in milliseconds before retrying. Default is 50ms.</param>
    /// <param name="maxDelayMs">The maximum delay in milliseconds between retries. Default is 500ms.</param>
    /// <param name="delayMultiplier">The multiplier for the exponential backoff delay. Default is 2.</param>
    /// <exception cref="Exception">Thrown if the directory could not be deleted after the specified number of retries.</exception>
    public static void DeleteDirectoryIfExists(string directory, int maxRetries = 10, int baseDelayMs = 50,
        int maxDelayMs = 500, double delayMultiplier = 2)
    {
        if (!Directory.Exists(directory))
        {
            return;
        }

        for (var attempt = 0; attempt < maxRetries; attempt++)
        {
            try
            {
                Directory.Delete(directory, true);
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

        throw new Exception($"Could not delete directory: {directory}");
    }
}
