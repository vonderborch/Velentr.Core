using System.IO.Compression;

namespace Velentr.Core.IO;

/// <summary>
///     Provides helper methods for archiving and extracting directories and files using zip compression.
/// </summary>
public static class ArchiveHelpers
{
    /// <summary>
    ///     Archives the specified directory into a zip file with optional settings for compression level,
    ///     inclusion of the base directory, and deletion of existing files or the source directory.
    /// </summary>
    /// <param name="sourceDirectory">The path of the directory to archive.</param>
    /// <param name="archivePath">The path where the archive file will be created.</param>
    /// <param name="compressionLevel">The level of compression to apply. Default is CompressionLevel.Optimal.</param>
    /// <param name="includeBaseDirectory">Whether to include the base directory in the archive. Default is false.</param>
    /// <param name="deleteExistingFile">Whether to delete the existing archive file if it exists. Default is false.</param>
    /// <param name="deleteSourceDirectory">Whether to delete the source directory after archiving. Default is false.</param>
    /// <exception cref="IOException">
    ///     Thrown if the archive file already exists and deleteExistingFile is false, or if the
    ///     destination directory already exists and deleteExistingDestinationDirectory is false.
    /// </exception>
    public static void ArchiveDirectory(string sourceDirectory, string archivePath,
        CompressionLevel compressionLevel = CompressionLevel.Optimal, bool includeBaseDirectory = false,
        bool deleteExistingFile = false, bool deleteSourceDirectory = false)
    {
        if (File.Exists(archivePath))
        {
            if (deleteExistingFile)
            {
                FileHelpers.DeleteFileIfExists(archivePath);
            }
            else
            {
                throw new IOException($"File already exists at {archivePath}!");
            }
        }

        ZipFile.CreateFromDirectory(sourceDirectory, archivePath, compressionLevel, includeBaseDirectory);

        if (deleteSourceDirectory)
        {
            DirectoryHelpers.DeleteDirectoryIfExists(sourceDirectory);
        }
    }

    /// <summary>
    ///     Extracts the contents of a zip archive to the specified destination directory, with an option to delete the
    ///     existing directory if it exists.
    /// </summary>
    /// <param name="archivePath">The path of the zip archive to extract.</param>
    /// <param name="destinationDirectory">The path where the contents of the archive will be extracted.</param>
    /// <param name="deleteExistingDestinationDirectory">
    ///     Whether to delete the existing destination directory if it exists.
    ///     Default is false.
    /// </param>
    /// <exception cref="IOException">
    ///     Thrown if the destination directory already exists and deleteExistingDestinationDirectory
    ///     is false.
    /// </exception>
    public static void ExtractDirectory(string archivePath, string destinationDirectory,
        bool deleteExistingDestinationDirectory = false)
    {
        if (Directory.Exists(destinationDirectory))
        {
            if (deleteExistingDestinationDirectory)
            {
                DirectoryHelpers.DeleteDirectoryIfExists(destinationDirectory);
            }
            else
            {
                throw new IOException($"Directory already exists at {destinationDirectory}!");
            }
        }

        if (!File.Exists(archivePath))
        {
            throw new FileNotFoundException($"Archive file '{archivePath}' not found.");
        }

        ZipFile.ExtractToDirectory(archivePath, destinationDirectory);
    }

    /// <summary>
    ///     Retrieves the contents of a specified file from a zip archive.
    /// </summary>
    /// <param name="archivePath">The path to the zip archive.</param>
    /// <param name="fileInArchive">The name of the file within the archive to retrieve.</param>
    /// <param name="bufferSize">The size of the buffer to use when reading the file. Default is 4096.</param>
    /// <returns>The contents of the specified file as a string.</returns>
    /// <exception cref="FileNotFoundException">Thrown if the specified file is not found in the archive.</exception>
    public static string GetFileContentsFromArchive(string archivePath, string fileInArchive, int bufferSize = 4096)
    {
        if (!File.Exists(archivePath))
        {
            throw new FileNotFoundException($"Archive file '{archivePath}' not found.");
        }

        using (ZipArchive archive = ZipFile.OpenRead(archivePath))
        {
            ZipArchiveEntry? entry = archive.GetEntry(fileInArchive);
            if (entry == null)
            {
                throw new FileNotFoundException($"File '{fileInArchive}' not found in archive '{archivePath}'.");
            }

            using (StreamReader reader = new(entry.Open(), bufferSize: bufferSize))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
