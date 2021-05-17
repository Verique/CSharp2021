using System;

namespace BubbleSort
{
    internal class Program
    {
        const int sizeX = 5;
        const int sizeY = 6;

        public static void Main(string[] args)
        {
            var rnd = new Random();

            var testArray = new int[sizeY, sizeX];

            for (var i = 0; i < sizeY; i++)
            {
                for (var j = 0; j < sizeX; j++)
                {
                    testArray[i, j] = rnd.Next(-100, 100);
                }
            }

            var rowMaxComparison = new RowMaxComparison();
            var rowMinComparison = new RowMinComparison();
            var rowSumComparison = new RowSumComparison();
            
            Console.WriteLine("Array :");
            OutputMatrix(testArray);
            
            Console.WriteLine("Array after row sum sort : ");
            testArray.BubbleSortMatrix(rowSumComparison);
            OutputMatrix(testArray);
            
            Console.WriteLine("Array after row min sort : ");
            testArray.BubbleSortMatrix(rowMinComparison);
            OutputMatrix(testArray);
            
            Console.WriteLine("Array after row min descending sort : ");
            testArray.BubbleSortMatrix(rowMinComparison, false);
            OutputMatrix(testArray);
            
            Console.WriteLine("Array after row max sort : ");
            testArray.BubbleSortMatrix(rowMaxComparison);
            OutputMatrix(testArray);

        }

        private static void OutputMatrix(int[,] array)
        {
            Console.WriteLine("[");

            for (var i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("  [ ");

                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0} ", array[i, j]);
                }

                Console.WriteLine("]");
            }

            Console.WriteLine("]");
        }
    }
}