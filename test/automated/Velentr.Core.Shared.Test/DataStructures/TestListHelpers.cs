using Velentr.Core.DataStructures;

namespace Velentr.Core.Test.DataStructures;

[TestFixture]
public class TestListHelpers
{
    [Test]
    public void TestAddItems()
    {
        List<int>? list = new() { 1, 2, 3 };
        list.AddItems(4, 5, 6);
        Assert.That(list, Is.EqualTo(new List<int> { 1, 2, 3, 4, 5, 6 }));
    }

    [Test]
    public void TestCompileListWithListsAndIndividuals()
    {
        List<int>? list1 = new() { 1, 2, 3 };
        List<int> list2 = new() { 4, 5, 6 };
        List<int> result = ListHelpers.CompileList(new[] { list1, list2 }, 7, 8, 9);
        Assert.That(result, Is.EqualTo(new List<int> { 7, 8, 9, 1, 2, 3, 4, 5, 6 }));
    }

    [Test]
    public void TestCompileListWithIndividualsOnly()
    {
        List<int>? result = ListHelpers.CompileList(1, 2, 3, 4, 5);
        Assert.That(result, Is.EqualTo(new List<int> { 1, 2, 3, 4, 5 }));
    }
}
