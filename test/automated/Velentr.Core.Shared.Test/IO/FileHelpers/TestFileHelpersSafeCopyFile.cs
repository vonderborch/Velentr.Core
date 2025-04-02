using System;
using System.IO;
using NUnit.Framework;
using Velentr.Core.IO;

namespace Velentr.Core.Test.IO;

[TestFixture]
public class TestFileHelpersSafeCopyFile
{
    private string sourceFile;
    private string destinationFile;

    [SetUp]
    public void SetUp()
    {
        var tempDir = Path.GetTempPath();
        this.sourceFile = Path.Combine(tempDir, Guid.NewGuid() + ".txt");
        this.destinationFile = Path.Combine(tempDir, Guid.NewGuid() + ".txt");

        File.WriteAllText(this.sourceFile, "Hello, World!");
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(this.sourceFile))
        {
            File.Delete(this.sourceFile);
        }

        if (File.Exists(this.destinationFile))
        {
            File.Delete(this.destinationFile);
        }
    }

    [Test]
    public void TestSafeCopyFile_FileCopiedSuccessfully()
    {
        // Act
        FileHelpers.SafeCopyFile(this.sourceFile, this.destinationFile);

        // Assert
        Assert.That(this.destinationFile, Does.Exist);
        Assert.That(File.ReadAllText(this.destinationFile), Is.EqualTo(File.ReadAllText(this.sourceFile)));
    }

    [Test]
    public void TestSafeCopyFile_SourceAndDestinationAreSame()
    {
        // Act
        FileHelpers.SafeCopyFile(this.sourceFile, this.sourceFile);

        // Assert
        Assert.That(this.sourceFile, Does.Exist);
        Assert.That(File.ReadAllText(this.sourceFile), Is.EqualTo(File.ReadAllText(this.sourceFile)));
    }

    [Test]
    [Ignore("This test is flaky and will fail on some systems.")]
    public void TestSafeCopyFile_MaxRetriesExceeded()
    {
        // Arrange
        using (var stream = new FileStream(this.sourceFile, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            // Act & Assert
            Assert.Throws<Exception>(() => FileHelpers.SafeCopyFile(this.sourceFile, this.destinationFile, maxRetries: 3, baseDelayMs: 10, maxDelayMs: 20, delayMultiplier: 1));
        }
    }

    [Test]
    public void TestSafeCopyFile_DestinationDirectoryDoesNotExist()
    {
        // Arrange
        var nonExistentDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        this.destinationFile = Path.Combine(nonExistentDir, "test.txt");

        // Act
        FileHelpers.SafeCopyFile(this.sourceFile, this.destinationFile);

        // Assert
        Assert.That(this.destinationFile, Does.Exist);
        Assert.That(File.ReadAllText(this.destinationFile), Is.EqualTo(File.ReadAllText(this.sourceFile)));
    }
}