using System;
using ReversePolishNotation;

namespace PolishNotationDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter an expression in Reverse Polish Notation : ");
            var input = Console.ReadLine();
            Console.WriteLine($"Result : {ReversePolishOperation.Calculate(input)}");
        }
    }
}