using System;
using ArrayHelper;
using RectangleHelper;

namespace M01_BasicCoding {
    class Program {
        const int size = 10;
        const int maxValue = 100;
        static void Main(string[] args) {
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
            Console.WriteLine("Сумма всех положительных чисел в двумерном массиве : {0}\n", Array2DSum.SumOfPotistivesIn2dArray(input2DArray));

            var rng = new Random();
            int a = rng.Next(1, maxValue), b = rng.Next(1, maxValue);

            Console.WriteLine("Стороны прямоугольника : {0}, {1}", a, b);
            Console.WriteLine("Периметр прямоугольника : {0}", AreaPerimeter.Permiter(a, b));
            Console.WriteLine("Площадь прямоугольника : {0}", AreaPerimeter.Area(a, b));

        }

        static int[] InitInputArray() {
            var array = new int[size];
            var rng = new Random();
            for (int i = 0; i < size; i++) {
                array[i] = rng.Next(maxValue);
            }
            return array;
        }

        static int[,] InitInput2DArray() {
            var array = new int[size, size];
            var rng = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++) {
                    array[i, j] = rng.Next(-maxValue, maxValue);
                }
            return array;
        }

        static void OutputArray(int[] array) {
            Console.Write("[ ");
            foreach (var value in array)
                Console.Write("{0} ", value);
            Console.WriteLine("]");
        }

        static void Output2DArray(int[,] array) {
            Console.WriteLine("[");
            for (int i = 0; i < size; i++) {
                Console.Write("  [ ");
                for (int j = 0; j < size; j++) {
                    Console.Write("{0} ", array[i, j]);
                }
                Console.WriteLine("]");
            }
            Console.WriteLine("]");
        }
    }
}
