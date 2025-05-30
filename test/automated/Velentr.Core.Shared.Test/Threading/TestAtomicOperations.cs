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

        var result = AtomicOperations.CompareAndSwap(ref value, newValue, expectedValue);

        Assert.That(result, Is.True);
        Assert.That(value, Is.EqualTo(newValue));
    }

    [Test]
    public void TestCAS_Failure()
    {
        var value = 10;
        var newValue = 20;
        var expectedValue = 15;

        var result = AtomicOperations.CompareAndSwap(ref value, newValue, expectedValue);

        Assert.That(result, Is.False);
        Assert.That(value, Is.EqualTo(10));
    }

    [Test]
    public void TestCAS_Double_Success()
    {
        var value = 10.5;
        var newValue = 20.5;
        var expectedValue = 10.5;

        var result = AtomicOperations.CompareAndSwap(ref value, newValue, expectedValue);

        Assert.That(result, Is.True);
        Assert.That(value, Is.EqualTo(newValue));
    }

    [Test]
    public void TestCAS_Double_Failure()
    {
        var value = 10.5;
        var newValue = 20.5;
        var expectedValue = 15.5;

        var result = AtomicOperations.CompareAndSwap(ref value, newValue, expectedValue);

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
                if (AtomicOperations.CompareAndSwap(ref value, newValue, expectedValue))
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

    [Test]
    public void TestCAS_WithOriginalValue_Success()
    {
        var value = 10;
        var newValue = 20;
        var expected = 10;
        var swapped = AtomicOperations.CompareAndSwap(ref value, newValue, expected, out var original);

        Assert.That(swapped, Is.True);
        Assert.That(original, Is.EqualTo(expected));
        Assert.That(value, Is.EqualTo(newValue));
    }

    [Test]
    public void TestCAS_WithOriginalValue_Failure()
    {
        var value = 10;
        var newValue = 20;
        var expected = 15;
        var swapped = AtomicOperations.CompareAndSwap(ref value, newValue, expected, out var original);

        Assert.That(swapped, Is.False);
        Assert.That(original, Is.EqualTo(10));
        Assert.That(value, Is.EqualTo(10));
    }

    [Test]
    public void TestDecrement_MonotonicAndStopAtMinimum()
    {
        var variable = 5;
        var min = 3;

        var first = AtomicOperations.Decrement(ref variable, min);
        var second = AtomicOperations.Decrement(ref variable, min);
        var third = AtomicOperations.Decrement(ref variable, min);

        Assert.That(first, Is.EqualTo(5));
        Assert.That(second, Is.EqualTo(4));
        Assert.That(third, Is.EqualTo(3));
        Assert.That(variable, Is.EqualTo(min));
    }

    [Test]
    public void TestDecrement_ResetsWhenBelowMinimum()
    {
        var variable = 1;
        var min = 3;

        var result = AtomicOperations.Decrement(ref variable, min);

        Assert.That(result, Is.EqualTo(min));
        Assert.That(variable, Is.EqualTo(min));
    }

    [Test]
    public void TestIncrement_MonotonicAndStopAtMaximum()
    {
        var variable = 2;
        var max = 4;

        var first = AtomicOperations.Increment(ref variable, max);
        var second = AtomicOperations.Increment(ref variable, max);
        var third = AtomicOperations.Increment(ref variable, max);

        Assert.That(first, Is.EqualTo(2));
        Assert.That(second, Is.EqualTo(3));
        Assert.That(third, Is.EqualTo(4));
        Assert.That(variable, Is.EqualTo(max));
    }

    [Test]
    public void TestIncrement_ResetsWhenAboveMaximum()
    {
        var variable = 6;
        var max = 4;

        var result = AtomicOperations.Increment(ref variable, max);

        Assert.That(result, Is.EqualTo(max));
        Assert.That(variable, Is.EqualTo(max));
    }
}
