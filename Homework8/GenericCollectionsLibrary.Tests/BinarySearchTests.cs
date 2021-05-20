using System;
using NUnit.Framework;

namespace GenericCollectionsLibrary.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public void BinarySearch_ArrayIsNull_ThrownArgumentNullException()
        {
            int[] target = null;
            Assert.That(() => target.FindWithBinarySearch(1), Throws.ArgumentNullException);
        }

        [Test]
        public void BinarySearch_ElementIsNull_ThrownArgumentNullException()
        {
            var target = new[] {"", "2"};
            Assert.That(() => target.FindWithBinarySearch(null), Throws.ArgumentNullException);
        }

        [Test]
        public void BinarySearch_ArrayIsNotSorted_ThrownArgumentException()
        {
            var target = new[] {6, 5, 3, 9};
            Assert.That(() => target.FindWithBinarySearch(3), Throws.ArgumentException);
        }

        [Test]
        [TestCase(new int[] {1, 6, 20, 46, 80, 223, 1000}, 6, 1)]
        [TestCase(new int[] {1, 6, 20, 46, 80, 223, 1000}, 80, 4)]
        [TestCase(new int[] {1, 6, 11, 20, 46, 80, 223, 1000}, 6, 1)]
        [TestCase(new int[] {1, 6, 11, 20, 46, 80, 223, 1000}, 80, 5)]
        [TestCase(new int[] {1, 6, 11, 20, 46, 80, 223, 1000}, 223, 6)]
        [TestCase(new int[] {1, 6, 11, 20, 46, 80, 223, 1000}, 14, -1)]
        [TestCase(new int[] {1, 6, 20, 46, 80, 223, 1000}, 14, -1)]
        public void BinarySearch_ArrayIsSorted_ReturnedExpected(int[] array, int element, int expected)
        {
            Assert.That(array.FindWithBinarySearch(element), Is.EqualTo(expected));
        }
    }
}