using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LinqDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var resultsCollection = new StudentTestResults();
            resultsCollection.LoadFromJsonFile("../../input.json");
            
            Console.WriteLine("[ All students ]");
            WriteCollection(resultsCollection.Collection);
            
            Console.WriteLine("Input your criteria for search : ");
            var str = Console.ReadLine();
            
            Console.WriteLine("[ Search results ]");
            WriteCollection(resultsCollection.Search(str));
        }
        
        private static void WriteCollection(IEnumerable<TestResult> results)
        {
            if (results is null)
            {
                throw new ArgumentNullException(nameof(results));
            }
            
            Console.WriteLine("Name | TestName | Date | Mark");
            Console.WriteLine("-------------------------------");
            
            foreach (var testResult in results)
            {
                Console.WriteLine(testResult.ToString());
            }
        }
    }
}