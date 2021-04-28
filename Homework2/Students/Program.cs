using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Students
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var subjects = new string[] {"Maths", "PE", "Chemistry", "IT", "Literature", "French"};
            var student1c1 = new Student("alexander.verik@epam.com");
            var student2c1 = new Student("denis.kozak@epam.com");
            var student3c1 = new Student("elena.smirnova@epam.com");
            var student1c2 = new Student("Alexander", "Verik");
            var student2c2 = new Student("Denis", "Kozak");
            var student3c2 = new Student("Elena", "Smirnova");

            var dict = new Dictionary<Student, HashSet<string>>
            {
                [student1c1] = GetRandomSubjects(subjects),
                [student1c2] = GetRandomSubjects(subjects),
                [student2c1] = GetRandomSubjects(subjects),
                [student2c2] = GetRandomSubjects(subjects),
                [student3c1] = GetRandomSubjects(subjects),
                [student3c2] = GetRandomSubjects(subjects),
            };

            Console.WriteLine("Dictionary contains {0} students : ", dict.Keys.Count);
            foreach (var student in dict.Keys)
            {
                Console.WriteLine(student.ToString());
            }

        }

        private static HashSet<string> GetRandomSubjects(string[] subjects)
        {
            var rnd = new Random();
            var max = subjects.Length - 1;
            var result = new HashSet<string>();
            
            for (var i = 0; i < 3; i++)
                result.Add(subjects[rnd.Next(max)]);

            return result;
        }
    }
}