using System;
using System.Text;

namespace Homework3
{
    public static class DoubleLettersExtension
    {
        public static string DoubleLetters(this string to, string from)
        {
            if ((to == null) || (from == null))
                throw new NullReferenceException();

            var strBuilder = new StringBuilder();
            
            foreach (var ch in to)
            {
                strBuilder.Append(ch);
                
                if ((char.IsLetter(ch)) && (from.Contains(ch.ToString())))
                    strBuilder.Append(ch);
            }
            
            return strBuilder.ToString();
        }
    }
}