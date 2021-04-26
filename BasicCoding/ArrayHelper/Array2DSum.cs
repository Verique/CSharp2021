using System;
using System.Linq;

namespace ArrayHelper
{
    public static class Array2DSum
    {
        public static int SumOfPositivesIn2dArray(int[,] array)
        {
            if (array == null)
                throw new System.NullReferenceException();

            return (array.Cast<int>().Where(t => t > 0).Sum());
            
        }
    }
}