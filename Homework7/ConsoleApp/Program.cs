using System;
using System.Diagnostics;

namespace ConsoleApp
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
            
            Console.WriteLine("Array :");
            OutputMatrix(testArray);
            
            Console.WriteLine("Array after row sum sort : ");
            BubbleSort.ComparisonMethod = BubbleSort.Comparison.RowSumComparison;
            testArray.BubbleSortMatrix();
            OutputMatrix(testArray);
            
            Console.WriteLine("Array after row min sort : ");
            BubbleSort.ComparisonMethod = BubbleSort.Comparison.RowMinComparison;
            testArray.BubbleSortMatrix();
            OutputMatrix(testArray);
            
            Console.WriteLine("Array after row min descending sort : ");
            testArray.BubbleSortMatrix(false);
            OutputMatrix(testArray);
            
            Console.WriteLine("Array after row max sort : ");
            BubbleSort.ComparisonMethod = BubbleSort.Comparison.RowMaxComparison;
            testArray.BubbleSortMatrix();
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