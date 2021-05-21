using System;
using System.Collections.Generic;
using Homework3;

namespace GenericCollectionsLibrary
{
    public static class FibonacciSequence
    {
        public static IEnumerable<StringNumber> Fibonacci(int maxIndex)
        {
            if (maxIndex < 0)
            {
                throw new ArgumentException("MaxIndex shouldn't be less than 0");
            }

            var a = new StringNumber("0");
            var b = new StringNumber("1");
            
            yield return a;

            if (maxIndex > 0)
            {
                yield return b;
            }

            for (var i = 2; i <= maxIndex; i++)
            {
                var last = a.Plus(b);
                yield return last;
                a = b;
                b = last;
            }
        }
    }
}