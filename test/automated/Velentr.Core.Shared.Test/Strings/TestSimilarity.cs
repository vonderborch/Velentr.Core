using System;
using NUnit.Framework;
using Velentr.Helpers.Strings;

namespace Velentr.Core.Test.Strings;

[TestFixture]
public class TestSimilarity
{
    [Test]
    public void TestSimilarityTo_ValidStrings()
    {
        var result = "kitten".SimilarityTo("sitting");
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void TestSimilarityTo_EmptyFirstString()
    {
        var result = "".SimilarityTo("sitting");
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void TestSimilarityTo_EmptySecondString()
    {
        var result = "kitten".SimilarityTo("");
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void TestSimilarityTo_BothStringsEmpty()
    {
        var result = "".SimilarityTo("");
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void TestSimilarityTo_IdenticalStrings()
    {
        var result = "kitten".SimilarityTo("kitten");
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void TestSimilarityTo_NullFirstString()
    {
        string stringA = null;
        var ex = Assert.Throws<ArgumentNullException>(() => stringA.SimilarityTo("sitting"));
        Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'stringA')"));
    }

    [Test]
    public void TestSimilarityTo_NullSecondString()
    {
        string stringB = null;
        var ex = Assert.Throws<ArgumentNullException>(() => "kitten".SimilarityTo(stringB));
        Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'stringB')"));
    }
        
    [Test]
    public void TestComputeSimilarity_ValidStrings()
    {
        var result = Similarity.ComputeSimilarity("kitten", "sitting");
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void TestComputeSimilarity_EmptyFirstString()
    {
        var result = Similarity.ComputeSimilarity("", "sitting");
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void TestComputeSimilarity_EmptySecondString()
    {
        var result = Similarity.ComputeSimilarity("kitten", "");
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void TestComputeSimilarity_BothStringsEmpty()
    {
        var result = Similarity.ComputeSimilarity("", "");
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void TestComputeSimilarity_IdenticalStrings()
    {
        var result = Similarity.ComputeSimilarity("kitten", "kitten");
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void TestComputeSimilarity_NullFirstString()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => Similarity.ComputeSimilarity(null, "sitting"));
        Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'stringA')"));
    }

    [Test]
    public void TestComputeSimilarity_NullSecondString()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => Similarity.ComputeSimilarity("kitten", null));
        Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'stringB')"));
    }
}