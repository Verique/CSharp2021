using System;
using System.Collections.Generic;

namespace GenericCollectionsLibrary
{
    public static class BinarySearch
    {
        public static int FindWithBinarySearch<T>(this T[] array, T element) where T : IComparable<T>
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (!array.IsSortedAscending<T>())
            {
                throw new ArgumentException("Array is not sorted");
            }

            var startIndex = 0;
            var lastIndex = array.Length - 1;
            var currentIndex = array.Length / 2;

            while (startIndex != lastIndex)
            {
                if (element.CompareTo(array[currentIndex]) == 0)
                {
                    return currentIndex;
                }

                if (element.CompareTo(array[currentIndex]) > 0)
                {
                    startIndex = currentIndex + 1;
                }
                else
                {
                    lastIndex = currentIndex - 1;
                }

                currentIndex = startIndex + (lastIndex - startIndex) / 2;
            }

            return (element.CompareTo(array[currentIndex]) == 0) ? currentIndex : -1;
        }

        private static bool IsSortedAscending<T>(this T[] array) where T : IComparable<T>
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                if (array[i].CompareTo(array[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}