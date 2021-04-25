namespace ArrayHelper {
    public static class BubbleSort {
        public static void BubbleSortInt(ref int[] array, bool ascending = true) {
            if (array == null)
                throw new System.NullReferenceException();
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1; j++) {
                    if (ascending && array[j] > array[j + 1]
                    || !ascending && array[j] < array[j + 1]) {
                        //swap
                        int tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
        }
    }
}