using System;
using NUnit.Framework;

namespace BubbleSort.Tests
{
    [TestFixture]
    public class BubbleSortTests
    {
        private Func<int[], int[], bool>[] comparisons = new Func<int[], int[], bool>[]
        {
            BubbleSort.Comparison.RowMaxComparison,
            BubbleSort.Comparison.RowMinComparison,
            BubbleSort.Comparison.RowSumComparison
        };

        private int[,] array = new int[,]
        {
            {0, 1, 2},
            {1, 2, 3},
            {2, 3, 4}
        };

        [Test]
        public void RowComparisons_ArrayIsNull_ArgumentNullExceptionThrown()
        {
            foreach (var comparison in comparisons)
            {
                Assert.That(() => comparison(null, null), Throws.ArgumentNullException);
            }
        }

        [Test]
        [TestCase(new int[] {1, 5, 4}, new int[] {0, 2, 2}, true)]
        [TestCase(new int[] {0, 5, 4}, new int[] {1, 9, 9}, false)]
        public void RowComparison_ArraysAreCorrect_ReturnedExpected(int[] a, int[] b, bool expected)
        {
            foreach (var comparison in comparisons)
            {
                var actual = comparison(a, b);
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void BubbleSort_ArrayIsNull_ArgumentNullExceptionThrown()
        {
            BubbleSort.ComparisonMethod = BubbleSort.Comparison.RowMaxComparison;

            Assert.That(() => BubbleSort.BubbleSortMatrix(null), Throws.ArgumentNullException);
        }

        [Test]
        public void BubbleSort_ComparisonMethodIsNull_NullReferenceExceptionThrown()
        {
            BubbleSort.ComparisonMethod = null;

            Assert.That(() => array.BubbleSortMatrix(), Throws.Exception.TypeOf<NullReferenceException>());
        }

        [Test]
        public void BubbleSort_ArrayCorrect_ArrayIsSorted()
        {
            foreach (var comparison in comparisons)
            {
                var actual = array;
                var expected = new int[,]
                {
                    {2, 3, 4},
                    {1, 2, 3},
                    {0, 1, 2}
                };
                BubbleSort.ComparisonMethod = comparison;

                actual.BubbleSortMatrix(false);

                Assert.That(actual, Is.EqualTo(expected));
            }
        }
    }
}