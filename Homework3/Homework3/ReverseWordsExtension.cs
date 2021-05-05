using System;
using System.Linq;

namespace Homework3
{
    public static class ReverseWordsExtension
    {
        public static string ReverseWords(this string str)
        {
            if (str == null)
            {
                throw new NullReferenceException();
            }

            return string.Join(" ",str.Split(' ').Reverse());
        }
    }
}