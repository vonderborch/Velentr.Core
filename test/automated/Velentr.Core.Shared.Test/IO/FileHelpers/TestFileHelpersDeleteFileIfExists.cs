using Velentr.Core.IO;

namespace Velentr.Core.Test.IO;

[TestFixture]
public class TestFileHelpersDeleteFileIfExists
{
    [SetUp]
    public void SetUp()
    {
        var tempDir = Path.GetTempPath();
        this.testFile = Path.Combine(tempDir, Guid.NewGuid() + ".txt");
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(this.testFile))
        {
            File.Delete(this.testFile);
        }
    }

    private string testFile;

    [Test]
    public void TestDeleteFileIfExists_FileExists()
    {
        // Arrange
        File.WriteAllText(this.testFile, "Hello, World!");

        // Act
        FileHelpers.DeleteFileIfExists(this.testFile);

        // Assert
        Assert.That(this.testFile, Does.Not.Exist);
    }

    [Test]
    public void TestDeleteFileIfExists_FileDoesNotExist()
    {
        // Act
        FileHelpers.DeleteFileIfExists(this.testFile);

        // Assert
        Assert.That(this.testFile, Does.Not.Exist);
    }

    [Test]
    [Ignore("This test is flaky and will fail on some systems.")]
    public void TestDeleteFileIfExists_MaxRetriesExceeded()
    {
        // Arrange
        File.WriteAllText(this.testFile, "Hello, World!");

        // Lock the file to simulate a deletion failure
        using (FileStream? stream = new(this.testFile, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            // Act & Assert
            Assert.Throws<Exception>(() => FileHelpers.DeleteFileIfExists(this.testFile, 3, 10, 20, 1));
        }
    }

    [Test]
    public void TestDeleteFileIfExists_FileDeletedAfterRetries()
    {
        // Arrange
        File.WriteAllText(this.testFile, "Hello, World!");

        // Lock and unlock the file to simulate a temporary deletion failure
        using (FileStream? stream = new(this.testFile, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            // Act
            Task deleteTask = Task.Run(() =>
            {
                Thread.Sleep(50); // Simulate delay before unlocking
                stream.Close();
            });

            FileHelpers.DeleteFileIfExists(this.testFile, 5, 10, 50, 1);
            deleteTask.Wait();
        }

        // Assert
        Assert.That(this.testFile, Does.Not.Exist);
    }
}
