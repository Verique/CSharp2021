using NUnit.Framework;

namespace BubbleSort.Tests
{
    [TestFixture]
    public class RowSumComparisonTests
    {
        [Test]
        public void RowComparison_ArrayIsNull_ThrownArgumentNullException()
        {
            var target = new RowSumComparison();
            Assert.That(() => target.RowComparison(null, null), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase(new int[] {0, 1, 2}, new int[] {1, 2, 3}, false)]
        [TestCase(new int[] {5, 6, 7}, new int[] {3, 4, 5}, true)]
        public void RowComparison_ArrayIsCorrect_ReturnedExpected(int[] a, int[] b, bool expected)
        {
            var target = new RowSumComparison();
            Assert.That(target.RowComparison(a, b), Is.EqualTo(expected));
        }
    }
}