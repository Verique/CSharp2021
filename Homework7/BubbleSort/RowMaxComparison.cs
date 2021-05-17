using System;

namespace BubbleSort
{
    public class RowMaxComparison : IRowComparison
    {
        public Func<int[], int[], bool> RowComparison => RowMaxCompare;

        private static bool RowMaxCompare(int[] row1, int[] row2) => (ArrayMax(row1) > ArrayMax(row2));

        private static int ArrayMax(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var max = array[0];

            for (var index = 1; index < array.Length; index++)
            {
                if (max < array[index])
                {
                    max = array[index];
                }
            }

            return max;
        }
    }
}