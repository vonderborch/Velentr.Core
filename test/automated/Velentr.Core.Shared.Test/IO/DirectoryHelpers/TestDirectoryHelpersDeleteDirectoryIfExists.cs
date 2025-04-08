using Velentr.Core.IO;

namespace Velentr.Core.Test.IO;

[TestFixture]
public class TestDirectoryHelpersDeleteDirectoryIfExists
{
    [SetUp]
    public void SetUp()
    {
        this.testDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(this.testDir))
        {
            Directory.Delete(this.testDir, true);
        }
    }

    private string testDir;

    [Test]
    public void TestDeleteDirectoryIfExists_DirectoryExists()
    {
        // Arrange
        Directory.CreateDirectory(this.testDir);

        // Act
        DirectoryHelpers.DeleteDirectoryIfExists(this.testDir);

        // Assert
        Assert.That(this.testDir, Does.Not.Exist);
    }

    [Test]
    public void TestDeleteDirectoryIfExists_DirectoryDoesNotExist()
    {
        // Act
        DirectoryHelpers.DeleteDirectoryIfExists(this.testDir);

        // Assert
        Assert.That(this.testDir, Does.Not.Exist);
    }

    [Test]
    public void TestDeleteDirectoryIfExists_WithFiles()
    {
        // Arrange
        Directory.CreateDirectory(this.testDir);
        var filePath = Path.Combine(this.testDir, "test.txt");
        File.WriteAllText(filePath, "Hello, World!");

        // Act
        DirectoryHelpers.DeleteDirectoryIfExists(this.testDir);

        // Assert
        Assert.That(this.testDir, Does.Not.Exist);
    }

    [Test]
    public void TestDeleteDirectoryIfExists_WithSubdirectories()
    {
        // Arrange
        Directory.CreateDirectory(this.testDir);
        var subDir = Path.Combine(this.testDir, "subdir");
        Directory.CreateDirectory(subDir);
        var filePath = Path.Combine(subDir, "test.txt");
        File.WriteAllText(filePath, "Hello, World!");

        // Act
        DirectoryHelpers.DeleteDirectoryIfExists(this.testDir);

        // Assert
        Assert.That(this.testDir, Does.Not.Exist);
    }

    [Test]
    [Ignore("This test is flaky and will fail on some systems.")]
    public void TestDeleteDirectoryIfExists_MaxRetriesExceeded()
    {
        // Arrange
        Directory.CreateDirectory(this.testDir);
        var filePath = Path.Combine(this.testDir, "test.txt");
        File.WriteAllText(filePath, "Hello, World!");

        // Lock the file to simulate a deletion failure
        using (FileStream? stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            // Act & Assert
            Exception? ex =
                Assert.Throws<Exception>(() => DirectoryHelpers.DeleteDirectoryIfExists(this.testDir, 3, 10, 20, 1));
            Assert.That(ex.Message, Is.EqualTo("Failed to delete directory after maximum retries."));
        }
    }
}
