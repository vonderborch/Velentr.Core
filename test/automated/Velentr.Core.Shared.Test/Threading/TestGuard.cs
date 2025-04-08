using Velentr.Core.Threading;

namespace Velentr.Core.Test.Threading;

[TestFixture]
public class TestGuard
{
    [Test]
    public void TestInitialState()
    {
        Guard guard = new();
        Assert.That(guard.Check, Is.False);
    }

    [Test]
    public void TestCheckSet()
    {
        Guard guard = new();
        Assert.That(guard.CheckSet, Is.True);
        Assert.That(guard.Check, Is.True);
    }

    [Test]
    public void TestMarkChecked()
    {
        Guard guard = new();
        guard.MarkChecked();
        Assert.That(guard.Check, Is.True);
    }

    [Test]
    public void TestReset()
    {
        Guard guard = new();
        guard.MarkChecked();
        guard.Reset();
        Assert.That(guard.Check, Is.False);
    }

    [Test]
    public void TestConcurrentAccess()
    {
        Guard guard = new();
        Thread[] threads = new Thread[10];
        for (var i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(() => guard.MarkChecked());
            threads[i].Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Assert.That(guard.Check, Is.True);
    }
}
