using System;
using System.Linq;
using System.Text;

namespace Homework3
{
    public static class SumOfTwoNumberStringsExtension
    {
        public static string SumOfTwoNumberStrings(this string first, string second)
        {
            if ((first == null) || (second == null))
                throw new NullReferenceException();

            if ((!first.All(char.IsDigit)) || (!second.All(char.IsDigit)))
                throw new ArgumentException();

            var overflow = false;
            var strBuilder = new StringBuilder();
            var a = first.ReverseString();
            var b = second.ReverseString();

            if (a.Length < b.Length)
            {
                var tmp = a;
                a = b;
                b = tmp;
            }

            for (var i = 0; i < a.Length; i++)
            {
                var digitToSum = (i < b.Length) ? b[i] : '0';
                strBuilder.Append(SumOfTwoDigits(a[i], digitToSum, ref overflow));
            }

            if (overflow)
                strBuilder.Append('1');

            return strBuilder.ToString().ReverseString();
        }

        private static string ReverseString(this string str)
        {
            return new string(str.Reverse().ToArray());
        }

        private static char SumOfTwoDigits(char a, char b, ref bool overflow)
        {
            const string digits = "0123456789";
            
            if ((!digits.Contains(a)) || (!digits.Contains(b)))
                throw new ArgumentException();

            var aIndex = digits.IndexOf(a);
            var bIndex = digits.IndexOf(b);

            if (overflow)
                aIndex++;
            
            var resultIndex = (aIndex + bIndex) % digits.Length;
            overflow = (aIndex + bIndex > digits.Length - 1);
            
            return digits[resultIndex];
        }

    }
}