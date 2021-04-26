using System;
using ArrayHelper;
using RectangleHelper;

namespace ConsoleApp {
    class Program {
        private const int Size = 10;
        private const int MaxValue = 100;
        private static void Main(string[] args) {
            var inputArray = InitInputArray();
            Console.WriteLine("Массив : ");
            OutputArray(inputArray);

            BubbleSort.BubbleSortInt(ref inputArray);
            Console.Write("После сортировки в порядке возрастания : ");
            OutputArray(inputArray);

            BubbleSort.BubbleSortInt(ref inputArray, false);
            Console.Write("После сортировки в порядке убывания : ");
            OutputArray(inputArray);

            var input2DArray = InitInput2DArray();
            Output2DArray(input2DArray);
            Console.WriteLine("Сумма всех положительных чисел в двумерном массиве : {0}\n", Array2DSum.SumOfPositivesIn2dArray(input2DArray));

            var rng = new Random();
            int a = rng.Next(1, MaxValue), b = rng.Next(1, MaxValue);

            Console.WriteLine("Стороны прямоугольника : {0}, {1}", a, b);
            Console.WriteLine("Периметр прямоугольника : {0}", AreaPerimeter.Perimeter(a, b));
            Console.WriteLine("Площадь прямоугольника : {0}", AreaPerimeter.Area(a, b));

        }

        private static int[] InitInputArray() {
            var array = new int[Size];
            var rng = new Random();
            for (var i = 0; i < Size; i++) {
                array[i] = rng.Next(MaxValue);
            }
            return array;
        }

        private static int[,] InitInput2DArray() {
            var array = new int[Size, Size];
            var rng = new Random();
            for (var i = 0; i < Size; i++)
                for (var j = 0; j < Size; j++) {
                    array[i, j] = rng.Next(-MaxValue, MaxValue);
                }
            return array;
        }

        private static void OutputArray(int[] array) {
            Console.Write("[ ");
            foreach (var value in array)
                Console.Write("{0} ", value);
            Console.WriteLine("]");
        }

        private static void Output2DArray(int[,] array) {
            Console.WriteLine("[");
            for (var i = 0; i < Size; i++) {
                Console.Write("  [ ");
                for (var j = 0; j < Size; j++) {
                    Console.Write("{0} ", array[i, j]);
                }
                Console.WriteLine("]");
            }
            Console.WriteLine("]");
        }
    }
}
