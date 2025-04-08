using System.IO.Compression;
using Velentr.Core.IO;

namespace Velentr.Core.Test.IO;

[TestFixture]
public class TestArchiveHelpers
{
    [SetUp]
    public void SetUp()
    {
        var tempDir = Path.GetTempPath();
        this.sourceDirectory = Path.Combine(tempDir, Guid.NewGuid().ToString());
        this.archivePath = Path.Combine(tempDir, Guid.NewGuid() + ".zip");
        this.extractedDirectory = Path.Combine(tempDir, Guid.NewGuid().ToString());

        Directory.CreateDirectory(this.sourceDirectory);
        File.WriteAllText(Path.Combine(this.sourceDirectory, "test.txt"), "Hello, World!");
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

        if (Directory.Exists(this.extractedDirectory))
        {
            Directory.Delete(this.extractedDirectory, true);
        }
    }

    private string sourceDirectory;
    private string archivePath;
    private string extractedDirectory;

    [Test]
    public void TestArchiveDirectory_Success()
    {
        // Act
        ArchiveHelpers.ArchiveDirectory(this.sourceDirectory, this.archivePath);

        // Assert
        Assert.That(this.archivePath, Does.Exist);
    }

    [Test]
    public void TestArchiveDirectory_IncludeBaseDirectory()
    {
        // Act
        ArchiveHelpers.ArchiveDirectory(this.sourceDirectory, this.archivePath, includeBaseDirectory: true);
        ZipFile.ExtractToDirectory(this.archivePath, this.extractedDirectory);

        // Assert
        Assert.That(Path.Combine(this.extractedDirectory, Path.GetFileName(this.sourceDirectory)), Does.Exist);
    }

    [Test]
    public void TestArchiveDirectory_DeleteExistingFile()
    {
        // Arrange
        File.WriteAllText(this.archivePath, "Existing file");

        // Act
        ArchiveHelpers.ArchiveDirectory(this.sourceDirectory, this.archivePath, deleteExistingFile: true);

        // Assert
        Assert.That(this.archivePath, Does.Exist);
        using (ZipArchive? archive = ZipFile.OpenRead(this.archivePath))
        {
            Assert.That(archive.GetEntry("test.txt"), Is.Not.Null);
        }
    }

    [Test]
    public void TestArchiveDirectory_DeleteSourceDirectory()
    {
        // Act
        ArchiveHelpers.ArchiveDirectory(this.sourceDirectory, this.archivePath, deleteSourceDirectory: true);

        // Assert
        Assert.That(this.sourceDirectory, Does.Not.Exist);
        Assert.That(this.archivePath, Does.Exist);
    }
}
