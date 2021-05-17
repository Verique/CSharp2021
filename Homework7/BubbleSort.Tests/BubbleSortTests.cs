using System;
using Moq;
using NUnit.Framework;

namespace BubbleSort.Tests
{
    [TestFixture]
    public class BubbleSortTests
    {
        private readonly int[,] array = new int[,]
        {
            {0, 1, 2},
            {1, 2, 3},
            {2, 3, 4}
        };

        [Test]
        public void BubbleSort_ArrayIsNull_ArgumentNullExceptionThrown()
        {
            var comparisonMock = new Mock<IRowComparison>();
            comparisonMock.Setup(comparison => comparison.RowComparison).Returns((a,b)=> (a[0] > b[0]));
            
            Assert.That(() => BubbleSort.BubbleSortMatrix(null, comparisonMock.Object), Throws.ArgumentNullException);
        }

        [Test]
        public void BubbleSort_ComparisonIsNull_ArgumentNullExceptionThrown()
        {
            Assert.That(() => array.BubbleSortMatrix(null), Throws.ArgumentNullException);
        }

        [Test]
        public void BubbleSort_ComparisonMethodIsNull_ArgumentExceptionThrown()
        {
            var comparisonMock = new Mock<IRowComparison>();
            comparisonMock.Setup(comparison => comparison.RowComparison).Returns((Func<int[], int[], bool>)null);
            
            Assert.That(() => array.BubbleSortMatrix(comparisonMock.Object), Throws.ArgumentException);
        }

        [Test]
        public void BubbleSort_ArrayCorrectCompareFirst_RowsAreReversed()
        {
            var comparisonMock = new Mock<IRowComparison>();
            comparisonMock.Setup(comparison => comparison.RowComparison).Returns((a,b)=> (a[0] > b[0]));
            var actual = array;
            var expected = new int[,]
            {
                {2, 3, 4},
                {1, 2, 3},
                {0, 1, 2}
            };
            
            actual.BubbleSortMatrix(comparisonMock.Object, false);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}