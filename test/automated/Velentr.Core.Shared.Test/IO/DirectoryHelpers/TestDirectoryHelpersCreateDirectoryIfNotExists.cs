using Velentr.Core.IO;

namespace Velentr.Core.Test.IO;

[TestFixture]
public class TestDirectoryHelpersCreateDirectoryIfNotExists
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
    public void TestCreateDirectoryIfNotExists_DirectoryDoesNotExist()
    {
        // Act
        DirectoryHelpers.CreateDirectoryIfNotExists(this.testDir);

        // Assert
        Assert.That(this.testDir, Does.Exist);
    }

    [Test]
    public void TestCreateDirectoryIfNotExists_DirectoryAlreadyExists()
    {
        // Arrange
        Directory.CreateDirectory(this.testDir);

        // Act
        DirectoryHelpers.CreateDirectoryIfNotExists(this.testDir);

        // Assert
        Assert.That(this.testDir, Does.Exist);
    }
}
