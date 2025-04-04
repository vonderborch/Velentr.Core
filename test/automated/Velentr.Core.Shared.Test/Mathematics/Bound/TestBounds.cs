using NUnit.Framework;
using System.Numerics;
using Velentr.Core.Mathematics.Bound;

namespace Velentr.Core.Test.Mathematics.Bound
{
    [TestFixture]
    public class TestBounds
    {
        [Test]
        public void TestBoundsInitialization()
        {
            var bounds = new Bounds<int>(5, 10);
            Assert.That(bounds.Minimum, Is.EqualTo(5));
            Assert.That(bounds.Maximum, Is.EqualTo(10));
        }

        [Test]
        public void TestBoundsInitializationWithSwappedValues()
        {
            var bounds = new Bounds<int>(10, 5);
            Assert.That(bounds.Minimum, Is.EqualTo(5));
            Assert.That(bounds.Maximum, Is.EqualTo(10));
        }

        [Test]
        public void TestBoundsCopyConstructor()
        {
            var original = new Bounds<int>(5, 10);
            var copy = new Bounds<int>(original);
            Assert.That(copy.Minimum, Is.EqualTo(5));
            Assert.That(copy.Maximum, Is.EqualTo(10));
        }

        [Test]
        public void TestSetMinimum()
        {
            var bounds = new Bounds<int>(5, 10);
            bounds.Minimum = 7;
            Assert.That(bounds.Minimum, Is.EqualTo(7));
            Assert.That(bounds.Maximum, Is.EqualTo(10));
        }

        [Test]
        public void TestSetMaximum()
        {
            var bounds = new Bounds<int>(5, 10);
            bounds.Maximum = 12;
            Assert.That(bounds.Minimum, Is.EqualTo(5));
            Assert.That(bounds.Maximum, Is.EqualTo(12));
        }

        [Test]
        public void TestClampValue()
        {
            var bounds = new Bounds<int>(5, 10);
            Assert.That(bounds.ClampValue(4), Is.EqualTo(5));
            Assert.That(bounds.ClampValue(6), Is.EqualTo(6));
            Assert.That(bounds.ClampValue(11), Is.EqualTo(10));
        }

        [Test]
        public void TestCircularClampValue()
        {
            var bounds = new Bounds<int>(5, 10);
            Assert.That(bounds.CircularClampValue(4), Is.EqualTo(9));
            Assert.That(bounds.CircularClampValue(6), Is.EqualTo(6));
            Assert.That(bounds.CircularClampValue(10), Is.EqualTo(5));
        }

        [Test]
        public void TestEquality()
        {
            var bounds1 = new Bounds<int>(5, 10);
            var bounds2 = new Bounds<int>(5, 10);
            var bounds3 = new Bounds<int>(6, 10);
            Assert.That(bounds1 == bounds2, Is.True);
            Assert.That(bounds1 != bounds3, Is.True);
        }
    }
}