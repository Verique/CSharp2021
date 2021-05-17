using System;

namespace BubbleSort
{
    public class RowSumComparison : IRowComparison
    {
        public Func<int[], int[], bool> RowComparison => RowSumCompare;

        private static bool RowSumCompare(int[] row1, int[] row2) => (ArraySum(row1) > ArraySum(row2));

        private static int ArraySum(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var sum = 0;

            foreach (var t in array)
            {
                sum += t;
            }

            return sum;
        }
    }
}