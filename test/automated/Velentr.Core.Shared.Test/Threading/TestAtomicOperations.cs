using Velentr.Core.Threading;

namespace Velentr.Core.Test.Threading;

[TestFixture]
public class TestAtomicOperations
{
    [Test]
    public void TestCAS_Success()
    {
        var value = 10;
        var newValue = 20;
        var expectedValue = 10;

        var result = AtomicOperations.CAS(ref value, newValue, expectedValue);

        Assert.That(result, Is.True);
        Assert.That(value, Is.EqualTo(newValue));
    }

    [Test]
    public void TestCAS_Failure()
    {
        var value = 10;
        var newValue = 20;
        var expectedValue = 15;

        var result = AtomicOperations.CAS(ref value, newValue, expectedValue);

        Assert.That(result, Is.False);
        Assert.That(value, Is.EqualTo(10));
    }

    [Test]
    public void TestCAS_Double_Success()
    {
        var value = 10.5;
        var newValue = 20.5;
        var expectedValue = 10.5;

        var result = AtomicOperations.CAS(ref value, newValue, expectedValue);

        Assert.That(result, Is.True);
        Assert.That(value, Is.EqualTo(newValue));
    }

    [Test]
    public void TestCAS_Double_Failure()
    {
        var value = 10.5;
        var newValue = 20.5;
        var expectedValue = 15.5;

        var result = AtomicOperations.CAS(ref value, newValue, expectedValue);

        Assert.That(result, Is.False);
        Assert.That(value, Is.EqualTo(10.5));
    }

    [Test]
    public void TestCAS_ThreadSafety()
    {
        var value = 0;
        var newValue = 1;
        var expectedValue = 0;
        var threadCount = 100;
        Thread[] threads = new Thread[threadCount];
        var successCount = 0;

        for (var i = 0; i < threadCount; i++)
        {
            threads[i] = new Thread(() =>
            {
                if (AtomicOperations.CAS(ref value, newValue, expectedValue))
                {
                    Interlocked.Increment(ref successCount);
                }
            });
            threads[i].Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Assert.That(successCount, Is.EqualTo(1));
        Assert.That(value, Is.EqualTo(newValue));
    }
}
