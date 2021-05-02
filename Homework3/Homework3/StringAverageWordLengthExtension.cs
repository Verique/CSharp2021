using System;
using System.Linq;

namespace Homework3
{
    public static class StringAverageWordLengthExtension
    {
        public static double AverageWordLength(this string str)
        {
            if (str == null)
                throw new NullReferenceException();
            
            var words = str.Split(' ');
            var lengthSum = 0;
            var wordsCount = 0;

            foreach (var word in words)
            {
                var wordLength = word.Count(char.IsLetter);

                if (wordLength != 0)
                {
                    wordsCount++;
                    lengthSum += wordLength;
                }
            }

            if (wordsCount == 0)
                throw new ArgumentException("There are no words in string");

            return (double)lengthSum / wordsCount;
        }
    }
}