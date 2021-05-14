using System;
using System.Linq;

namespace ConsoleApp
{
    public static class BubbleSort
    {
        private const int ColDimension = 0;
        private const int RowDimension = 1;

        public static Func<int[], int[], bool> ComparisonMethod { get; set; }

        public static void BubbleSortMatrix(this int[,] matrix, bool ascending = true)
        {
            if (ComparisonMethod is null)
            {
                throw new NullReferenceException();
            }

            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var rowCount = matrix.GetLength(ColDimension);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < rowCount - 1; j++)
                {
                    var row1 = GetRowFrom2D(matrix, j);
                    var row2 = GetRowFrom2D(matrix, j + 1);

                    if (!((ascending) ^ (ComparisonMethod(row1, row2))))
                    {
                        SwapRows2D(ref matrix, j, j + 1);
                    }
                }
            }
        }

        private static void SwapRows2D(ref int[,] array, int row1Index, int row2Index)
        {
            for (var i = 0; i < array.GetLength(RowDimension); i++)
            {
                var swap = array[row1Index, i];
                array[row1Index, i] = array[row2Index, i];
                array[row2Index, i] = swap;
            }
        }

        private static int[] GetRowFrom2D(int[,] array, int rowNum) => 
            Enumerable.Range(0, array.GetLength(RowDimension)).Select(x => array[rowNum, x]).ToArray(); 

        public static class Comparison
        {
            public static bool RowSumComparison(int[] row1, int[] row2) => (ArraySum(row1) > ArraySum(row2));
            public static bool RowMaxComparison(int[] row1, int[] row2) => (ArrayMax(row1) > ArrayMax(row2));
            public static bool RowMinComparison(int[] row1, int[] row2) => (ArrayMin(row1) > ArrayMin(row2));

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

            private static int ArrayMax(int[] array)
            {
                if (array is null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                var max = array[0];

                for (var index = 1; index < array.Length; index++)
                {
                    if (max > array[index])
                    {
                        max = array[index];
                    }
                }

                return max;
            }

            private static int ArrayMin(int[] array)
            {
                if (array is null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                var min = array[0];

                for (var index = 1; index < array.Length; index++)
                {
                    if (min < array[index])
                    {
                        min = array[index];
                    }
                }

                return min;
            }
        }
    }
}