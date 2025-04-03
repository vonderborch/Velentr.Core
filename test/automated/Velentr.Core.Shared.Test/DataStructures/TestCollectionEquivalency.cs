using NUnit.Framework;
using Velentr.Core.DataStructures;
using System.Collections.Generic;

namespace Velentr.Core.Test.DataStructures;

[TestFixture]
public class TestCollectionEquivalency
{
    [Test]
    public void CollectionsEquivalent_ShouldHandleEmptyCollections()
    {
        // Arrange
        var collectionA = new List<int>();
        var collectionB = new List<int>();

        // Act
        var result = CollectionEquivalency.CollectionsEquivalent(collectionA, collectionB);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void CollectionsEquivalent_ShouldHandleSingleElementCollections()
    {
        // Arrange
        var collectionA = new List<int> { 1 };
        var collectionB = new List<int> { 1 };

        // Act
        var result = CollectionEquivalency.CollectionsEquivalent(collectionA, collectionB);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void CollectionsEquivalent_ShouldReturnFalseForDifferentSizes()
    {
        // Arrange
        var collectionA = new List<int> { 1, 2, 3 };
        var collectionB = new List<int> { 1, 2 };

        // Act
        var result = CollectionEquivalency.CollectionsEquivalent(collectionA, collectionB);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void CollectionsEquivalent_ShouldReturnFalseForDifferentElements()
    {
        // Arrange
        var collectionA = new List<int> { 1, 2, 3 };
        var collectionB = new List<int> { 1, 2, 4 };

        // Act
        var result = CollectionEquivalency.CollectionsEquivalent(collectionA, collectionB);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void CollectionsEquivalent_ShouldHandleEquivalentCollections()
    {
        // Arrange
        var collectionA = new List<int> { 1, 2, 3 };
        var collectionB = new List<int> { 1, 2, 3 };

        // Act
        var result = CollectionEquivalency.CollectionsEquivalent(collectionA, collectionB);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsEquivalent_ShouldHandleEmptyCollections()
    {
        // Arrange
        var collectionA = new List<int>();
        var collectionB = new List<int>();

        // Act
        var result = collectionA.IsEquivalent(collectionB);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsEquivalent_ShouldHandleSingleElementCollections()
    {
        // Arrange
        var collectionA = new List<int> { 1 };
        var collectionB = new List<int> { 1 };

        // Act
        var result = collectionA.IsEquivalent(collectionB);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsEquivalent_ShouldReturnFalseForDifferentSizes()
    {
        // Arrange
        var collectionA = new List<int> { 1, 2, 3 };
        var collectionB = new List<int> { 1, 2 };

        // Act
        var result = collectionA.IsEquivalent(collectionB);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void IsEquivalent_ShouldReturnFalseForDifferentElements()
    {
        // Arrange
        var collectionA = new List<int> { 1, 2, 3 };
        var collectionB = new List<int> { 1, 2, 4 };

        // Act
        var result = collectionA.IsEquivalent(collectionB);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void IsEquivalent_ShouldHandleEquivalentCollections()
    {
        // Arrange
        var collectionA = new List<int> { 1, 2, 3 };
        var collectionB = new List<int> { 1, 2, 3 };

        // Act
        var result = collectionA.IsEquivalent(collectionB);

        // Assert
        Assert.That(result, Is.True);
    }
}