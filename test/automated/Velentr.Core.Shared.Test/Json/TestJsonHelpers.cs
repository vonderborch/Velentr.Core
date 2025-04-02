using System.IO;
using System.Text.Json;
using NUnit.Framework;
using Velentr.Core.Json;

namespace Velentr.Core.Test.Json
{
    [TestFixture]
    public class JsonHelpersTests
    {
        private class TestClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [Test]
        public void DeserializeFromFile_ShouldReturnObject_WhenFileExists()
        {
            // Arrange
            var path = "test.json";
            var expected = new TestClass { Id = 1, Name = "Test" };
            File.WriteAllText(path, JsonSerializer.Serialize(expected));

            // Act
            var result = JsonHelpers.DeserializeFromFile<TestClass>(path);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(expected.Id));
            Assert.That(result.Name, Is.EqualTo(expected.Name));

            // Cleanup
            File.Delete(path);
        }

        [Test]
        public void DeserializeFromFile_ShouldReturnDefault_WhenFileDoesNotExist()
        {
            // Arrange
            var path = "nonexistent.json";

            // Act
            var result = JsonHelpers.DeserializeFromFile<TestClass>(path);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void SerializeToFile_ShouldCreateFile_WithSerializedContent()
        {
            // Arrange
            var path = "test.json";
            var obj = new TestClass { Id = 1, Name = "Test" };

            // Act
            JsonHelpers.SerializeToFile(path, obj);

            // Assert
            Assert.That(path, Does.Exist);
            var content = File.ReadAllText(path);
            var deserialized = JsonSerializer.Deserialize<TestClass>(content);
            Assert.That(deserialized, Is.Not.Null);
            Assert.That(deserialized.Id, Is.EqualTo(obj.Id));
            Assert.That(deserialized.Name, Is.EqualTo(obj.Name));

            // Cleanup
            File.Delete(path);
        }

        [Test]
        public void SerializeToString_ShouldReturnJsonString()
        {
            // Arrange
            var obj = new TestClass { Id = 1, Name = "Test" };

            // Act
            var jsonString = JsonHelpers.SerializeToString(obj);

            // Assert
            Assert.That(string.IsNullOrWhiteSpace(jsonString), Is.False);
            var deserialized = JsonSerializer.Deserialize<TestClass>(jsonString);
            Assert.That(deserialized, Is.Not.Null);
            Assert.That(deserialized.Id, Is.EqualTo(obj.Id));
            Assert.That(deserialized.Name, Is.EqualTo(obj.Name));
        }
    }
}