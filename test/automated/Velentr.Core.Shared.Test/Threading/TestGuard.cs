using Velentr.Core.Threading;

namespace Velentr.Core.Test.Threading;

[TestFixture]
public class TestGuard
{
    [Test]
    public void TestInitialState()
    {
        var guard = new Guard();
        Assert.That(guard.Check, Is.False);
    }

    [Test]
    public void TestCheckSet()
    {
        var guard = new Guard();
        Assert.That(guard.CheckSet, Is.True);
        Assert.That(guard.Check, Is.True);
    }

    [Test]
    public void TestMarkChecked()
    {
        var guard = new Guard();
        guard.MarkChecked();
        Assert.That(guard.Check, Is.True);
    }

    [Test]
    public void TestReset()
    {
        var guard = new Guard();
        guard.MarkChecked();
        guard.Reset();
        Assert.That(guard.Check, Is.False);
    }

    [Test]
    public void TestConcurrentAccess()
    {
        var guard = new Guard();
        var threads = new Thread[10];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(() => guard.MarkChecked());
            threads[i].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Assert.That(guard.Check, Is.True);
    }
}
