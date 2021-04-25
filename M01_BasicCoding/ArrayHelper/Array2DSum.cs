using System.Linq;
namespace ArrayHelper {
    public static class Array2DSum {
        public static int SumOfPotistivesIn2dArray(int[,] array) {
            if (array == null)
                throw new System.NullReferenceException();
            return (from int value in array where (value > 0) select value).Sum();
        }
    }
}