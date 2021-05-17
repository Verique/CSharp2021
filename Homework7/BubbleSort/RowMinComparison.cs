using System;

namespace BubbleSort
{
    public class RowMinComparison : IRowComparison
    {
        public Func<int[], int[], bool> RowComparison => RowMinCompare; 

        private static bool RowMinCompare(int[] row1, int[] row2) => (ArrayMin(row1) > ArrayMin(row2));

        private static int ArrayMin(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var min = array[0];

            for (var index = 1; index < array.Length; index++)
            {
                if (min > array[index])
                {
                    min = array[index];
                }
            }

            return min;
        }
    }
}