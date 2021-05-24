using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace LinqDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var jsonText = File.ReadAllText("../../input.json");
            var resultsCollection = (JsonSerializer.Deserialize<IEnumerable<TestResult>>(jsonText) ?? throw new InvalidOperationException()).ToArray();

            StudentTestResults.WriteCollection(resultsCollection, "[ All students ]");
            
            Console.WriteLine("Input your criteria for search : ");
            var str = Console.ReadLine();
            
            StudentTestResults.WriteCollection(StudentTestResults.Search(resultsCollection, str), "[ Search results ]");
        }
    }
}