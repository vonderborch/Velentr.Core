using System;
using System.IO;
using System.IO.Compression;
using NUnit.Framework;
using Velentr.Core.IO;

namespace Velentr.Core.Test.IO
{
    [TestFixture]
    public class TestArchiveHelpersExtractDirectory
    {
        private string sourceDirectory;
        private string archivePath;
        private string destinationDirectory;

        [SetUp]
        public void SetUp()
        {
            var tempDir = Path.GetTempPath();
            this.sourceDirectory = Path.Combine(tempDir, Guid.NewGuid().ToString());
            this.archivePath = Path.Combine(tempDir, Guid.NewGuid().ToString() + ".zip");
            this.destinationDirectory = Path.Combine(tempDir, Guid.NewGuid().ToString());

            Directory.CreateDirectory(this.sourceDirectory);
            File.WriteAllText(Path.Combine(this.sourceDirectory, "test.txt"), "Hello, World!");
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

            if (Directory.Exists(this.destinationDirectory))
            {
                Directory.Delete(this.destinationDirectory, true);
            }
        }

        [Test]
        public void TestExtractDirectory_Success()
        {
            // Act
            ArchiveHelpers.ExtractDirectory(this.archivePath, this.destinationDirectory);

            // Assert
            Assert.That(this.destinationDirectory, Does.Exist);
            Assert.That(Path.Combine(this.destinationDirectory, "test.txt"), Does.Exist);
        }

        [Test]
        public void TestExtractDirectory_DeleteExistingDestinationDirectory()
        {
            // Arrange
            Directory.CreateDirectory(this.destinationDirectory);
            File.WriteAllText(Path.Combine(this.destinationDirectory, "existing.txt"), "Existing file");

            // Act
            ArchiveHelpers.ExtractDirectory(this.archivePath, this.destinationDirectory, deleteExistingDestinationDirectory: true);

            // Assert
            Assert.That(this.destinationDirectory, Does.Exist);
            Assert.That(Path.Combine(this.destinationDirectory, "existing.txt"), Does.Not.Exist);
            Assert.That(Path.Combine(this.destinationDirectory, "test.txt"), Does.Exist);
        }

        [Test]
        public void TestExtractDirectory_DestinationDirectoryAlreadyExists()
        {
            // Arrange
            Directory.CreateDirectory(this.destinationDirectory);

            // Act & Assert
            var ex = Assert.Throws<IOException>(() => ArchiveHelpers.ExtractDirectory(this.archivePath, this.destinationDirectory));
            Assert.That(ex.Message, Is.EqualTo($"Directory already exists at {this.destinationDirectory}!"));
        }

        [Test]
        public void TestExtractDirectory_ArchiveFileNotFound()
        {
            // Arrange
            var nonExistentArchivePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".zip");

            // Act & Assert
            var ex = Assert.Throws<FileNotFoundException>(() => ArchiveHelpers.ExtractDirectory(nonExistentArchivePath, this.destinationDirectory));
            Assert.That(ex.Message, Is.EqualTo($"Archive file '{nonExistentArchivePath}' not found."));
        }
    }
}