using System;
using System.Linq;

namespace BubbleSort
{
    public static class BubbleSort
    {
        private const int ColDimension = 0;
        private const int RowDimension = 1;

        public static void BubbleSortMatrix(this int[,] matrix, IRowComparison comparison, bool ascending = true)
        {
            if (comparison is null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            if (comparison.RowComparison is null)
            {
                throw new ArgumentException("Comparison method is null");
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

                    if (!((ascending) ^ (comparison.RowComparison(row1, row2))))
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
    }
}