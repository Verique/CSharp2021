using System;
using System.Linq;
using System.Text;

namespace Homework3
{
    public static class SumOfTwoNumberStringsExtension
    {
        public static string SumOfTwoNumberStrings(this string first, string second)
        {
            if (string.IsNullOrWhiteSpace(first) || (string.IsNullOrWhiteSpace(second)))
            {
                throw new ArgumentException();
            }

            return (new StringNumber(first).Plus(new StringNumber(second))).ToString();
        }

        public static string ReverseString(this string str)
        {
            return new string(str.Reverse().ToArray());
        }
    }
}