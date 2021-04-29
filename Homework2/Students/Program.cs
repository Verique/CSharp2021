using System;
using System.Collections.Generic;

namespace Students
{
    internal class Program
    { 
        static Random rnd = new Random();
        public static void Main(string[] args)
        {
            var subjects = new string[] {"Maths", "PE", "Chemistry", "IT", "Literature", "French"};
            var student1C1 = new Student("alexander.verik@epam.com");
            var student2C1 = new Student("denis.kozak@epam.com");
            var student3C1 = new Student("elena.smirnova@epam.com");
            var student1C2 = new Student("Alexander", "Verik");
            var student2C2 = new Student("Denis", "Kozak");
            var student3C2 = new Student("Elena", "Smirnova");

            var dict = new Dictionary<Student, HashSet<string>>
            {
                [student1C1] = GetRandomSubjects(subjects),
                [student1C2] = GetRandomSubjects(subjects),
                [student2C1] = GetRandomSubjects(subjects),
                [student2C2] = GetRandomSubjects(subjects),
                [student3C1] = GetRandomSubjects(subjects),
                [student3C2] = GetRandomSubjects(subjects),
            };

            Console.WriteLine("Dictionary contains {0} students : ", dict.Keys.Count);
            
            foreach (var entry in dict)
            {
                Console.Write("{0}, Subjects : ", entry.Key.ToString());

                foreach (var subject in  entry.Value)
                    Console.Write("{0} ", subject);
                
                Console.WriteLine();
            }
        }

        private static HashSet<string> GetRandomSubjects(string[] subjects)
        {
            var max = subjects.Length;
            var result = new HashSet<string>();

            while (result.Count < 3)
                result.Add(subjects[rnd.Next(max)]);

            return result;
        }
    }
}