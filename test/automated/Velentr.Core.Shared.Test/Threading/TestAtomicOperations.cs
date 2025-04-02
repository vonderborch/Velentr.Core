using Velentr.Core.Threading;

namespace Velentr.Core.Test.Threading;

[TestFixture]
public class TestAtomicOperations
{
    [Test]
    public void TestCAS_Success()
    {
        int value = 10;
        int newValue = 20;
        int expectedValue = 10;

        bool result = AtomicOperations.CAS(ref value, newValue, expectedValue);

        Assert.That(result, Is.True);
        Assert.That(value, Is.EqualTo(newValue));
    }

    [Test]
    public void TestCAS_Failure()
    {
        int value = 10;
        int newValue = 20;
        int expectedValue = 15;

        bool result = AtomicOperations.CAS(ref value, newValue, expectedValue);

        Assert.That(result, Is.False);
        Assert.That(value, Is.EqualTo(10));
    }

    [Test]
    public void TestCAS_Double_Success()
    {
        double value = 10.5;
        double newValue = 20.5;
        double expectedValue = 10.5;

        bool result = AtomicOperations.CAS(ref value, newValue, expectedValue);

        Assert.That(result, Is.True);
        Assert.That(value, Is.EqualTo(newValue));
    }

    [Test]
    public void TestCAS_Double_Failure()
    {
        double value = 10.5;
        double newValue = 20.5;
        double expectedValue = 15.5;

        bool result = AtomicOperations.CAS(ref value, newValue, expectedValue);

        Assert.That(result, Is.False);
        Assert.That(value, Is.EqualTo(10.5));
    }
    
    [Test]
    public void TestCAS_ThreadSafety()
    {
        int value = 0;
        int newValue = 1;
        int expectedValue = 0;
        int threadCount = 100;
        var threads = new Thread[threadCount];
        var successCount = 0;

        for (int i = 0; i < threadCount; i++)
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

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Assert.That(successCount, Is.EqualTo(1));
        Assert.That(value, Is.EqualTo(newValue));
    }
}
