namespace ListOfSortingAlgs
{
    public static class MySort
    {
        static void Swap(ref int leftValue, ref int rightValue)
        {
            (rightValue, leftValue) = (leftValue, rightValue);
        }

        public static void QuickSort(int[] inputArray, int minIndex, int maxIndex)
        {

            static int GetPivotIndex(int[] inputArray, int minIndex, int maxIndex)
            {
                int pivotIndex = minIndex - 1;
                for (int i = minIndex; i <= maxIndex; i++)
                {
                    if (inputArray[i] < inputArray[maxIndex])
                    {
                        pivotIndex++;
                        Swap(ref inputArray[i], ref inputArray[pivotIndex]);
                    }
                }
                pivotIndex++;
                Swap(ref inputArray[pivotIndex], ref inputArray[maxIndex]);
                return pivotIndex;
            }
            if (minIndex >= maxIndex) return;
            int pivot = GetPivotIndex(inputArray, minIndex, maxIndex);
            QuickSort(inputArray, minIndex, pivot - 1);
            QuickSort(inputArray, pivot + 1, minIndex);
            return;
        }

        public static void BoobleSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = 0; j < inputArray.Length - 1 - i; j++)
                {
                    if (inputArray[j] > inputArray[j + 1])
                        Swap(ref inputArray[j], ref inputArray[j + 1]);
                }
            }
        }

        public static void SelectionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[j] < inputArray[min]) min = j;
                }
                Swap(ref inputArray[i], ref inputArray[min]);
            }
        }

        public static void CountingSort(int[] inputArray)
        {
            int min = inputArray[0];
            int max = inputArray[0];
            foreach (int element in inputArray)
            {
                if (element > max) max = element;
                else if (element < min) min = element;
            }

            int correctionFactor = min != 0 ? -min : 0;
            max += correctionFactor;

            int[] count = new int[max + 1];
            for (int i = 0; i < inputArray.Length; i++)
            {
                count[inputArray[i] + correctionFactor]++;
            }
            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    inputArray[index] = i - correctionFactor;
                    index++;
                }
            }

        }
    }
}