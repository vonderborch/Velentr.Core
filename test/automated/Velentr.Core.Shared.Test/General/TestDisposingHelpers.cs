using NUnit.Framework;
using System;
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
            IsDisposed = true;
        }
    }

    [Test]
    public void DisposeIfPossible_ShouldDisposeDisposableObject()
    {
        // Arrange
        var disposable = new TestDisposable();

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
        Assert.DoesNotThrow(() => DisposingHelpers.DisposeIfPossible(nonDisposable));
    }

    [Test]
    public void DisposeIfPossible_ShouldDisposeDisposableObject_ExtensionMethod()
    {
        // Arrange
        var disposable = new TestDisposable();

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