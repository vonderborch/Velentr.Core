using Velentr.Core.DataStructures;

namespace Velentr.Core.Test.DataStructures;

[TestFixture]
public class TestListQuickSort
{
    [Test]
    public void Sort_ShouldHandleEmptyList()
    {
        // Arrange
        List<int>? list = new();

        // Act
        ListQuickSort.Sort(list, (x, y) => x.CompareTo(y));

        // Assert
        Assert.That(list, Is.Empty);
    }

    [Test]
    public void Sort_ShouldHandleSingleElementList()
    {
        // Arrange
        List<int>? list = new() { 1 };

        // Act
        ListQuickSort.Sort(list, (x, y) => x.CompareTo(y));

        // Assert
        Assert.That(list, Is.EqualTo(new List<int> { 1 }));
    }

    [Test]
    public void Sort_ShouldSortListInAscendingOrder()
    {
        // Arrange
        List<int>? list = new() { 3, 1, 2 };

        // Act
        ListQuickSort.Sort(list, (x, y) => x.CompareTo(y));

        // Assert
        Assert.That(list, Is.EqualTo(new List<int> { 1, 2, 3 }));
    }

    [Test]
    public void Sort_ShouldSortListInDescendingOrder()
    {
        // Arrange
        List<int>? list = new() { 1, 3, 2 };

        // Act
        ListQuickSort.Sort(list, (x, y) => y.CompareTo(x));

        // Assert
        Assert.That(list, Is.EqualTo(new List<int> { 3, 2, 1 }));
    }

    [Test]
    public void QuickSort_ShouldHandleEmptyList()
    {
        // Arrange
        List<int>? list = new();

        // Act
        list.QuickSort((x, y) => x.CompareTo(y));

        // Assert
        Assert.That(list, Is.Empty);
    }

    [Test]
    public void QuickSort_ShouldHandleSingleElementList()
    {
        // Arrange
        List<int>? list = new() { 1 };

        // Act
        list.QuickSort((x, y) => x.CompareTo(y));

        // Assert
        Assert.That(list, Is.EqualTo(new List<int> { 1 }));
    }

    [Test]
    public void QuickSort_ShouldSortListInAscendingOrder()
    {
        // Arrange
        List<int>? list = new() { 3, 1, 2 };

        // Act
        list.QuickSort((x, y) => x.CompareTo(y));

        // Assert
        Assert.That(list, Is.EqualTo(new List<int> { 1, 2, 3 }));
    }

    [Test]
    public void QuickSort_ShouldSortListInDescendingOrder()
    {
        // Arrange
        List<int>? list = new() { 1, 3, 2 };

        // Act
        list.QuickSort((x, y) => y.CompareTo(x));

        // Assert
        Assert.That(list, Is.EqualTo(new List<int> { 3, 2, 1 }));
    }

    [Test]
    public void QuickSort_ShouldSortListWithDuplicateElements()
    {
        // Arrange
        List<int>? list = new() { 3, 1, 2, 1, 3 };

        // Act
        list.QuickSort((x, y) => x.CompareTo(y));

        // Assert
        Assert.That(list, Is.EqualTo(new List<int> { 1, 1, 2, 3, 3 }));
    }
}
