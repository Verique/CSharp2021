using System.Linq;
using NUnit.Framework;

namespace GenericCollectionsLibrary.Tests
{
    [TestFixture]
    public class FibonacciSequenceTests
    {
        [Test]
        public void Fibonacci_MaxIndexLessThan0_ThrownArgumentException()
        {
            var target = FibonacciSequence.Fibonacci(-5);
            Assert.That(target.Last, Throws.ArgumentException);
        }

        [Test]
        [TestCase(5, 5)]
        [TestCase(25, 75025)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(12, 144)]
        public void Fibonacci_CorrectIndex_LastElementEqualsExpected(int maxIndex, int expected)
        {
            var target = FibonacciSequence.Fibonacci(maxIndex);
            Assert.That(target.Last(), Is.EqualTo(expected));
        }
    }
}