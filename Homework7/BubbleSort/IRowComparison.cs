using System;

namespace BubbleSort
{
    public interface IRowComparison
    {
         Func<int[], int[], bool> RowComparison { get; }
    }
}