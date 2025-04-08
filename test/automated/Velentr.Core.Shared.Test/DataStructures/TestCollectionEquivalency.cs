using Velentr.Core.DataStructures;

namespace Velentr.Core.Test.DataStructures;

[TestFixture]
public class TestCollectionEquivalency
{
    [Test]
    public void CollectionsEquivalent_ShouldHandleEmptyCollections()
    {
        // Arrange
        List<int>? collectionA = new();
        List<int> collectionB = new();

        // Act
        var result = CollectionEquivalency.CollectionsEquivalent(collectionA, collectionB);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void CollectionsEquivalent_ShouldHandleSingleElementCollections()
    {
        // Arrange
        List<int>? collectionA = new() { 1 };
        List<int> collectionB = new() { 1 };

        // Act
        var result = CollectionEquivalency.CollectionsEquivalent(collectionA, collectionB);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void CollectionsEquivalent_ShouldReturnFalseForDifferentSizes()
    {
        // Arrange
        List<int>? collectionA = new() { 1, 2, 3 };
        List<int> collectionB = new() { 1, 2 };

        // Act
        var result = CollectionEquivalency.CollectionsEquivalent(collectionA, collectionB);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void CollectionsEquivalent_ShouldReturnFalseForDifferentElements()
    {
        // Arrange
        List<int>? collectionA = new() { 1, 2, 3 };
        List<int> collectionB = new() { 1, 2, 4 };

        // Act
        var result = CollectionEquivalency.CollectionsEquivalent(collectionA, collectionB);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void CollectionsEquivalent_ShouldHandleEquivalentCollections()
    {
        // Arrange
        List<int>? collectionA = new() { 1, 2, 3 };
        List<int> collectionB = new() { 1, 2, 3 };

        // Act
        var result = CollectionEquivalency.CollectionsEquivalent(collectionA, collectionB);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsEquivalent_ShouldHandleEmptyCollections()
    {
        // Arrange
        List<int>? collectionA = new();
        List<int> collectionB = new();

        // Act
        var result = collectionA.IsEquivalent(collectionB);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsEquivalent_ShouldHandleSingleElementCollections()
    {
        // Arrange
        List<int>? collectionA = new() { 1 };
        List<int> collectionB = new() { 1 };

        // Act
        var result = collectionA.IsEquivalent(collectionB);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsEquivalent_ShouldReturnFalseForDifferentSizes()
    {
        // Arrange
        List<int>? collectionA = new() { 1, 2, 3 };
        List<int> collectionB = new() { 1, 2 };

        // Act
        var result = collectionA.IsEquivalent(collectionB);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void IsEquivalent_ShouldReturnFalseForDifferentElements()
    {
        // Arrange
        List<int>? collectionA = new() { 1, 2, 3 };
        List<int> collectionB = new() { 1, 2, 4 };

        // Act
        var result = collectionA.IsEquivalent(collectionB);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void IsEquivalent_ShouldHandleEquivalentCollections()
    {
        // Arrange
        List<int>? collectionA = new() { 1, 2, 3 };
        List<int> collectionB = new() { 1, 2, 3 };

        // Act
        var result = collectionA.IsEquivalent(collectionB);

        // Assert
        Assert.That(result, Is.True);
    }
}
