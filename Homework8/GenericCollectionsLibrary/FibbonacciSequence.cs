using System;
using System.Collections.Generic;

namespace GenericCollectionsLibrary
{
    public static class FibonacciSequence
    {
        public static IEnumerable<int> Fibonacci(int maxIndex)
        {
            if (maxIndex < 0)
            {
                throw new ArgumentException("MaxIndex shouldn't be less than 0");
            }

            yield return 0;

            if (maxIndex > 0)
            {
                yield return 1;
            }

            var a = 0;
            var b = 1;

            for (var i = 2; i <= maxIndex; i++)
            {
                var last = a + b;
                yield return last;
                a = b;
                b = last;
            }
        }
    }
}