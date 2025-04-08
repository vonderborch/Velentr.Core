using Velentr.Core.General;

namespace Velentr.Core.Test.General;

[TestFixture]
public class TestDisposingHelpers
{
    private class TestDisposable : IDisposable
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            this.IsDisposed = true;
        }
    }

    [Test]
    public void DisposeIfPossible_ShouldDisposeDisposableObject()
    {
        // Arrange
        TestDisposable? disposable = new();

        // Act
        DisposingHelpers.DisposeIfPossible(disposable);

        // Assert
        Assert.That(disposable.IsDisposed, Is.True);
    }

    [Test]
    public void DisposeIfPossible_ShouldNotThrowForNonDisposableObject()
    {
        // Arrange
        var nonDisposable = new object();

        // Act & Assert
        Assert.DoesNotThrow(() => nonDisposable.DisposeIfPossible());
    }

    [Test]
    public void DisposeIfPossible_ShouldDisposeDisposableObject_ExtensionMethod()
    {
        // Arrange
        TestDisposable? disposable = new();

        // Act
        disposable.DisposeIfPossible();

        // Assert
        Assert.That(disposable.IsDisposed, Is.True);
    }

    [Test]
    public void DisposeIfPossible_ShouldNotThrowForNonDisposableObject_ExtensionMethod()
    {
        // Arrange
        var nonDisposable = new object();

        // Act & Assert
        Assert.DoesNotThrow(() => nonDisposable.DisposeIfPossible());
    }
}
