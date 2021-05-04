using System;
using System.Linq;

namespace Homework3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           string input, secondInput;

           Console.Write("Input a string to count average word length in it : ");
           input = Console.ReadLine();
           Console.WriteLine("Average word length = {0:F}", input.AverageWordLength());
           Console.WriteLine();
           
           Console.Write("Input a string to double the letters from second string : ");
           input = Console.ReadLine();
           Console.Write("Input a second string : ");
           secondInput = Console.ReadLine();
           Console.WriteLine("First string with letters doubled = {0}", input.DoubleLetters(secondInput));
           Console.WriteLine();

           Console.Write("Input a number-string to add with another number-string: ");
           input = Console.ReadLine();
           Console.Write("Input another number-string : ");
           secondInput = Console.ReadLine();
           Console.WriteLine("Sum of two string-numbers = {0}", input.SumOfTwoNumberStrings(secondInput));
           Console.WriteLine();
           
           Console.Write("Input a string to reverse words in it : ");
           input = Console.ReadLine();
           Console.WriteLine("Word-reversed string = {0}", input.ReverseWords());
           Console.WriteLine();
           
           Console.WriteLine("Finding numbers in text.txt...");
           var numbers = PhoneNumberFinder.FindPhoneNumbers();
           Console.WriteLine("Numbers are :");

           foreach (var number in numbers)
           {
               Console.WriteLine(number);
           }
        }
    }
}