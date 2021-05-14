using System;
using NUnit.Framework;

namespace BubbleSort.Tests
{
    [TestFixture]
    public class BubbleSortTests
    {
        private static Func<int[], int[], bool>[] comparisons = new Func<int[], int[], bool>[]
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
        public void RowComparisons_ArrayIsNull_ArgumentNullExceptionThrown([ValueSource(nameof(comparisons))] Func<int[], int[], bool> comparison)
        {
            Assert.That(() => comparison(null, null), Throws.ArgumentNullException);
        }

        [Test]
        public void RowComparison_FirstIsBigger_ReturnedTrue([ValueSource(nameof(comparisons))] Func<int[], int[], bool> comparison)
        {
            var a = new int[] {1, 5, 4};
            var b = new int[] {0, 2, 2};
            const bool expected = true;
            
            var actual = comparison(a, b);
            
            Assert.That(actual, Is.EqualTo(expected));
        }
        
        [Test]
        public void RowComparison_FirstIsLesser_ReturnedFalse([ValueSource(nameof(comparisons))] Func<int[], int[], bool> comparison)
        {
            var a = new int[] {0, 5, 4};
            var b = new int[] {1, 9, 9};
            const bool expected = false;
            
            var actual = comparison(a, b);
            
            Assert.That(actual, Is.EqualTo(expected));
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
        public void BubbleSort_ArrayCorrect_ArrayIsSorted([ValueSource(nameof(comparisons))] Func<int[], int[], bool> comparison)
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