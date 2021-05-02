using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework3
{
    public static class PhoneNumberFinder
    {
        public static List<string> FindPhoneNumbers()
        {
            var numbersList = new List<string>();
            var regex = new Regex(@"\d \d{3} \d{3}-\d{2}-\d{2}|\+\d{3} \(\d{2}\) \d{3}-\d{4}|\+\d \(\d{3}\) \d{3}-\d{2}-\d{2}");
            
            using (var sr = new StreamReader("../../text.txt"))
                while (!sr.EndOfStream)
                {
                    var input = sr.ReadLine();

                    if (input == null)
                        throw new InvalidOperationException();

                    foreach (Match match in regex.Matches(input))
                        numbersList.Add(match.Value);
                }

            using (var sw = new StreamWriter("../../numbers.txt"))
                foreach (var number in numbersList)
                    sw.WriteLine(number);

            return numbersList;
        }
    }
}