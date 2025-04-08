using Velentr.Core.IO;

namespace Velentr.Core.Test.IO;

[TestFixture]
public class TestArchiveHelpersGetFileContentsFromArchive
{
    [SetUp]
    public void SetUp()
    {
        var tempDir = Path.GetTempPath();
        this.sourceDirectory = Path.Combine(tempDir, Guid.NewGuid().ToString());
        this.archivePath = Path.Combine(tempDir, Guid.NewGuid() + ".zip");
        this.fileName = "test.txt";
        this.fileContent = "Hello, World!";

        Directory.CreateDirectory(this.sourceDirectory);
        File.WriteAllText(Path.Combine(this.sourceDirectory, this.fileName), this.fileContent);
        ArchiveHelpers.ArchiveDirectory(this.sourceDirectory, this.archivePath);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(this.sourceDirectory))
        {
            Directory.Delete(this.sourceDirectory, true);
        }

        if (File.Exists(this.archivePath))
        {
            File.Delete(this.archivePath);
        }
    }

    private string sourceDirectory;
    private string archivePath;
    private string fileName;
    private string fileContent;

    [Test]
    public void TestGetFileContentsFromArchive_Success()
    {
        // Act
        var content = ArchiveHelpers.GetFileContentsFromArchive(this.archivePath, this.fileName);

        // Assert
        Assert.That(content, Is.EqualTo(this.fileContent));
    }

    [Test]
    public void TestGetFileContentsFromArchive_FileNotFound()
    {
        // Act & Assert
        FileNotFoundException? ex = Assert.Throws<FileNotFoundException>(() =>
            ArchiveHelpers.GetFileContentsFromArchive(this.archivePath, "nonexistent.txt"));
        Assert.That(ex.Message, Is.EqualTo($"File 'nonexistent.txt' not found in archive '{this.archivePath}'."));
    }

    [Test]
    public void TestGetFileContentsFromArchive_ArchiveFileNotFound()
    {
        // Arrange
        var nonExistentArchivePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".zip");

        // Act & Assert
        FileNotFoundException? ex = Assert.Throws<FileNotFoundException>(() =>
            ArchiveHelpers.GetFileContentsFromArchive(nonExistentArchivePath, this.fileName));
        Assert.That(ex.Message, Is.EqualTo($"Archive file '{nonExistentArchivePath}' not found."));
    }

    [Test]
    public void TestGetFileContentsFromArchive_EmptyFile()
    {
        // Arrange
        var emptyFileName = "empty.txt";
        File.WriteAllText(Path.Combine(this.sourceDirectory, emptyFileName), string.Empty);
        ArchiveHelpers.ArchiveDirectory(this.sourceDirectory, this.archivePath, deleteExistingFile: true);

        // Act
        var content = ArchiveHelpers.GetFileContentsFromArchive(this.archivePath, emptyFileName);

        // Assert
        Assert.That(content, Is.EqualTo(string.Empty));
    }
}
