using Velentr.Core.Eventing;

namespace Velentr.Core.Test.Velentr.Core.Shared.Test.Eventing;

[TestFixture]
public class TestEvents
{
    [SetUp]
    public void SetUp()
    {
        this._events = new Event<TestEventArgs>();
        this._receivedMessage = string.Empty;
    }

    private class TestEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    private Event<TestEventArgs> _events;
    private string _receivedMessage;

    [Test]
    public void TestSubscribeAndTriggerEvent()
    {
        this._events.Events += OnTestEvent;

        TestEventArgs args = new() { Message = "Hello, World!" };
        this._events.Trigger(this, args);

        Assert.That(this._receivedMessage, Is.EqualTo("Hello, World!"));
    }

    [Test]
    public void TestUnsubscribeEvent()
    {
        this._events.Events += OnTestEvent;
        this._events.Events -= OnTestEvent;

        TestEventArgs args = new() { Message = "Hello, World!" };
        this._events.Trigger(this, args);

        Assert.That(this._receivedMessage, Is.EqualTo(string.Empty));
    }

    [Test]
    public void TestClearEventHandlers()
    {
        this._events.Events += OnTestEvent;
        this._events.Clear();

        TestEventArgs args = new() { Message = "Hello, World!" };
        this._events.Trigger(this, args);

        Assert.That(this._receivedMessage, Is.EqualTo(string.Empty));
    }

    [Test]
    public void TestOperatorAdd()
    {
        this._events += OnTestEvent;

        TestEventArgs args = new() { Message = "Hello, Operator!" };
        this._events.Trigger(this, args);

        Assert.That(this._receivedMessage, Is.EqualTo("Hello, Operator!"));
    }

    [Test]
    public void TestOperatorRemove()
    {
        this._events += OnTestEvent;
        this._events -= OnTestEvent;

        TestEventArgs args = new() { Message = "Hello, Operator!" };
        this._events.Trigger(this, args);

        Assert.That(this._receivedMessage, Is.EqualTo(string.Empty));
    }

    private void OnTestEvent(object sender, TestEventArgs e)
    {
        this._receivedMessage = e.Message;
    }
}
