using NUnit.Framework;
using System.Collections.Generic;
using Velentr.Core.DataStructures;

namespace Velentr.Core.Test.DataStructures;

[TestFixture]
public class TestListHelpers
{
    [Test]
    public void TestAddItems()
    {
        var list = new List<int> { 1, 2, 3 };
        list.AddItems(4, 5, 6);
        Assert.That(list, Is.EqualTo(new List<int> { 1, 2, 3, 4, 5, 6 }));
    }

    [Test]
    public void TestCompileListWithListsAndIndividuals()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 4, 5, 6 };
        var result = ListHelpers.CompileList(new[] { list1, list2 }, 7, 8, 9);
        Assert.That(result, Is.EqualTo(new List<int> { 7, 8, 9, 1, 2, 3, 4, 5, 6 }));
    }

    [Test]
    public void TestCompileListWithIndividualsOnly()
    {
        var result = ListHelpers.CompileList(1, 2, 3, 4, 5);
        Assert.That(result, Is.EqualTo(new List<int> { 1, 2, 3, 4, 5 }));
    }
}