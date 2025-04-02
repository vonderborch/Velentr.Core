using System;
using System.IO;
using NUnit.Framework;
using Velentr.Core.IO;

namespace Velentr.Core.Test.IO;

[TestFixture]
public class TestFileHelpersDeleteFileIfExists
{
    private string testFile;

    [SetUp]
    public void SetUp()
    {
        var tempDir = Path.GetTempPath();
        this.testFile = Path.Combine(tempDir, Guid.NewGuid().ToString() + ".txt");
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(this.testFile))
        {
            File.Delete(this.testFile);
        }
    }

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
        using (var stream = new FileStream(this.testFile, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            // Act & Assert
            Assert.Throws<Exception>(() => FileHelpers.DeleteFileIfExists(this.testFile, maxRetries: 3, baseDelayMs: 10, maxDelayMs: 20, delayMultiplier: 1));
        }
    }

    [Test]
    public void TestDeleteFileIfExists_FileDeletedAfterRetries()
    {
        // Arrange
        File.WriteAllText(this.testFile, "Hello, World!");

        // Lock and unlock the file to simulate a temporary deletion failure
        using (var stream = new FileStream(this.testFile, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            // Act
            var deleteTask = Task.Run(() => 
            {
                Thread.Sleep(50); // Simulate delay before unlocking
                stream.Close();
            });

            FileHelpers.DeleteFileIfExists(this.testFile, maxRetries: 5, baseDelayMs: 10, maxDelayMs: 50, delayMultiplier: 1);
            deleteTask.Wait();
        }

        // Assert
        Assert.That(this.testFile, Does.Not.Exist);
    }
}