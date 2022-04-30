namespace DataStructuresAlgorithms
{
    public class Sorting
    {
        /// <summary>
        /// Time Complexity: O(n log n)
        /// Space Complexity: O(n)
        /// </summary>
        /// <param name="array">Array to be sorted</param>
        /// <returns>Sorted array</returns>
        public static void MergeSort(int[] array)
        {
            // Base Case: Will stop splitting the array once we have just one element
            if (array.Length <= 1)
                return;

            // Split the array into two halves, left and right by the middle
            int middle = array.Length / 2;

            int[] left = new int[middle];
            int[] right = new int[array.Length - middle];

            for (int l = 0; l < middle; ++l)
                left[l] = array[l];

            for (int r = middle; r < array.Length; ++r)
                right[r - middle] = array[r];

            // Recursively sorts the left and right arrays
            MergeSort(left);
            MergeSort(right);

            // Merge the left and right arrays to return final sorted array
            Merge(array, left, right);
        }

        /// <summary>
        /// MergeSort helper function to sort and merge left and right arrays
        /// </summary>
        /// <param name="array">Original unsorted array</param>
        /// <param name="left">Left array</param>
        /// <param name="right">Right array</param>
        /// <returns>Merged sorted arrays</returns>
        private static void Merge(int[] array, int[] left, int[] right)
        {
            // i is the current index of combined array, l and r are current indices of left and right arrays repectively
            int i = 0, l = 0, r = 0;

            // Compares the elements of the left array and the right array and adds the smaller value to the sorted array
            while (l < left.Length && r < right.Length)
            {
                if (left[l] < right[r])
                {
                    array[i] = left[l];
                    ++l;
                    ++i;
                }
                else
                {
                    array[i] = right[r];
                    ++r;
                    ++i;
                }
            }

            // Adds all remaining elements in left array if it was bigger
            while (l < left.Length)
            {
                array[i] = left[l];
                ++l;
                ++i;
            }

            // Adds all remaining elements of right array if it was bigger
            while (r < right.Length)
            {
                array[i] = right[r];
                ++r;
                ++i;
            }
        }

        public static void QuickSort(int[] array, int start, int end)
        {
            if (end <= start) 
                return;

            int pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end); 
        }

        private static int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; ++j)
            {
                if (array[j] < pivot)
                {
                    ++i;
                    Swap(array, i, j);
                }
            }

            ++i;
            Swap(array, i, end);

            return i;
        }

        public static void BubbleSort(int[] array)
        {
            bool isSorted = false;
            int max = array.Length - 1;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = 0; i < max; ++i)
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                        isSorted = false;
                    }

                --max;
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                int min = i;

                for (int j = i + 1; j < array.Length; ++j)
                    if (array[min] > array[j])
                        min = j;

                Swap(array, i, min);
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                int temp = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    --j;
                }

                array[j + 1] = temp;
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}