using System;
using System.IO;
using NUnit.Framework;
using Velentr.Core.IO;

namespace Velentr.Core.Test.IO;

[TestFixture]
public class TestDirectoryHelpersCopyDirectory
{
    private string sourceDir;
    private string destDir;

    [SetUp]
    public void SetUp()
    {
        this.sourceDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        this.destDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(this.sourceDir);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(this.sourceDir))
        {
            Directory.Delete(this.sourceDir, true);
        }

        if (Directory.Exists(this.destDir))
        {
            Directory.Delete(this.destDir, true);
        }
    }

    [Test]
    public void TestCopyDirectory_ValidDirectories()
    {
        // Arrange
        var filePath = Path.Combine(this.sourceDir, "test.txt");
        File.WriteAllText(filePath, "Hello, World!");

        // Act
        DirectoryHelpers.CopyDirectory(this.sourceDir, this.destDir);

        // Assert
        Assert.That(this.destDir, Does.Exist);
        Assert.That(Path.Combine(this.destDir, "test.txt"), Does.Exist);
        Assert.That(File.ReadAllText(Path.Combine(this.destDir, "test.txt")), Is.EqualTo("Hello, World!"));
    }

    [Test]
    public void TestCopyDirectory_EmptySourceDirectory()
    {
        // Act
        DirectoryHelpers.CopyDirectory(this.sourceDir, this.destDir);

        // Assert
        Assert.That(this.destDir, Does.Exist);
        Assert.That(Directory.GetFiles(this.destDir), Is.Empty);
        Assert.That(Directory.GetDirectories(this.destDir), Is.Empty);
    }

    [Test]
    public void TestCopyDirectory_SourceDirectoryDoesNotExist()
    {
        // Arrange
        Directory.Delete(this.sourceDir);

        // Act & Assert
        Assert.Throws<DirectoryNotFoundException>(() => DirectoryHelpers.CopyDirectory(this.sourceDir, this.destDir));
    }

    [Test]
    public void TestCopyDirectory_DestinationDirectoryAlreadyExists()
    {
        // Arrange
        Directory.CreateDirectory(this.destDir);
        var filePath = Path.Combine(this.sourceDir, "test.txt");
        File.WriteAllText(filePath, "Hello, World!");

        // Act
        DirectoryHelpers.CopyDirectory(this.sourceDir, this.destDir);

        // Assert
        Assert.That(this.destDir, Does.Exist);
        Assert.That(Path.Combine(this.destDir, "test.txt"), Does.Exist);
        Assert.That(File.ReadAllText(Path.Combine(this.destDir, "test.txt")), Is.EqualTo("Hello, World!"));
    }

    [Test]
    public void TestCopyDirectory_Subdirectories()
    {
        // Arrange
        var subDir = Path.Combine(this.sourceDir, "subdir");
        Directory.CreateDirectory(subDir);
        var filePath = Path.Combine(subDir, "test.txt");
        File.WriteAllText(filePath, "Hello, World!");

        // Act
        DirectoryHelpers.CopyDirectory(this.sourceDir, this.destDir);

        // Assert
        Assert.That(this.destDir, Does.Exist);
        Assert.That(Path.Combine(this.destDir, "subdir", "test.txt"), Does.Exist);
        Assert.That(File.ReadAllText(Path.Combine(this.destDir, "subdir", "test.txt")), Is.EqualTo("Hello, World!"));
    }
}