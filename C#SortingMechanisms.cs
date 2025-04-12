using System;
using System.Linq;

class SortingAlgorithms
{
    static void BubbleSort()
    {
        int[] packageWeight = { 55, 11, 68, 33, 28, 98, 55, 12 };
        int comparisonCount = 0;
        int swapCount = 0;

        Console.WriteLine("Bubble Sort:");

        for (int i = 0; i < packageWeight.Length - 1; i++)
        {
            for (int j = 0; j < packageWeight.Length - i - 1; j++)
            {
                comparisonCount++;
                if (packageWeight[j] > packageWeight[j + 1])
                {
                  
                    int temp = packageWeight[j];
                    packageWeight[j] = packageWeight[j + 1];
                    packageWeight[j + 1] = temp;
                    swapCount++;
                }
            }
        }

        Console.WriteLine("Sorted Weights: " + string.Join(" ", packageWeight));
        Console.WriteLine("Total Comparisons Made: " + comparisonCount);
        Console.WriteLine("Total Swaps Made: " + swapCount);
    }

    static void SelectionSort()
    {
        int[] packageWeight = { 55, 11, 68, 33, 28, 98, 55, 12 };
        int comparisonCount = 0;
        int selectionCount = 0;

        Console.WriteLine("Selection Sort:");

        for (int i = 0; i < packageWeight.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < packageWeight.Length; j++)
            {
                comparisonCount++;
                if (packageWeight[j] < packageWeight[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
               
                int temp = packageWeight[i];
                packageWeight[i] = packageWeight[minIndex];
                packageWeight[minIndex] = temp;
                selectionCount++;
            }
        }

        Console.WriteLine("Sorted Weights: " + string.Join(" ", packageWeight));
        Console.WriteLine("Total Comparisons Made: " + comparisonCount);
        Console.WriteLine("Total Selections Made: " + selectionCount);
    }

    static void InsertionSort()
    {
        int[] packageWeight = { 55, 11, 68, 33, 28, 98, 55, 12 };
        int splitCount = 0;
        int insertionCount = 0;

        Console.WriteLine("Insertion Sort:");

        for (int i = 1; i < packageWeight.Length; i++)
        {
            int key = packageWeight[i];
            int j = i;
            while (j > 0 && packageWeight[j - 1] > key)
            {
                packageWeight[j] = packageWeight[j - 1];
                j--;
                splitCount++;
            }
            packageWeight[j] = key;
            insertionCount++;
        }

        Console.WriteLine("Sorted Weights: " + string.Join(" ", packageWeight));
        Console.WriteLine("Total Splits: " + splitCount);
        Console.WriteLine("Total Insertions: " + insertionCount);
    }

    static void MergeSort()
    {
        int[] packageWeight = { 55, 11, 68, 33, 28, 98, 55, 12 };
        int splitCount = 0;
        int mergeCount = 0;

        Console.WriteLine("Merge Sort:");

    
        void Merge(int[] array, int left, int mid, int right)
        {
            int leftSize = mid - left + 1;
            int rightSize = right - mid;
            int[] leftArray = new int[leftSize];
            int[] rightArray = new int[rightSize];

            Array.Copy(array, left, leftArray, 0, leftSize);
            Array.Copy(array, mid + 1, rightArray, 0, rightSize);

            int i = 0, j = 0, k = left;

            while (i < leftSize && j < rightSize)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < leftSize)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < rightSize)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
            mergeCount++;
        }

    
        void MergeSortRec(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                splitCount++;

                MergeSortRec(array, left, mid);
                MergeSortRec(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        MergeSortRec(packageWeight, 0, packageWeight.Length - 1);

        Console.WriteLine("Sorted Weights: " + string.Join(" ", packageWeight));
        Console.WriteLine("Total Splits: " + splitCount);
        Console.WriteLine("Total Merges: " + mergeCount);
    }

    static void Main()
    {
        BubbleSort();
        Console.WriteLine("\n");
        SelectionSort();
        Console.WriteLine("\n");
        InsertionSort();
        Console.WriteLine("\n");
        MergeSort();
    }
}
