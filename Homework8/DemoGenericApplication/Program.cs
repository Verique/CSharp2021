using System;
using System.Linq;
using GenericCollectionsLibrary;

namespace DemoGenericApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Fibonacci sequence, first 10 : ");
            var fibonacci = FibonacciSequence.Fibonacci(9).ToArray();

            foreach (var number in fibonacci)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Is 83 in first 10 fibonacci numbers? {fibonacci.FindWithBinarySearch(83) > 0}");
            Console.WriteLine($"Is 21 in first 10 fibonacci numbers? {fibonacci.FindWithBinarySearch(21) > 0}");
            Console.WriteLine($"21 index : {fibonacci.FindWithBinarySearch(21)}");

            var queue = new GenericQueue<int>();
            Console.WriteLine("Adding Fibonacci to the queue...");

            foreach (var number in fibonacci)
            {
                queue.Push(number);
            }

            Console.WriteLine("Outputting fibonacci through myIterator : ");
            var iter = queue.GetIterator();

            do
            {
                Console.Write($"{iter.Current} ");
            } 
            while (iter.MoveNext());
        }
    }
}