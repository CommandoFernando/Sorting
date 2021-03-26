using System;
/// <summary>
/// CIS 575 Alortithm analysis
/// 3 sorts implemented Insertion, Heap, Quick
/// </summary>
namespace Sorting
{
    public class Sorting
    {
        public static void Main(string[] args)
        {
            int[] arr = { 15, 48, 59, 17, 29, 32, 13, 25 };
            var watch = new System.Diagnostics.Stopwatch();
            long runningTime = 0;
            int numItems = 0;
            int numberOfSorts = 0;
            ///Run HERE///Delete print statements if needed
            Console.WriteLine("8");
            Console.WriteLine("Insertion");
            InsertionSortInator(arr);
            printInfoInator();
            Console.WriteLine("Heap");
            heapSortInator(arr);
            printInfoInator();
            Console.WriteLine("Quick");
            QuickSortInator(arr, 0, arr.Length-1);
            watch.Start();
            printInfoInator();
            Console.WriteLine("100");
            ///Random 100
            Console.WriteLine("Insertion ");
            InsertionSortInator(TestInator(100));
            printInfoInator();
            Console.WriteLine("Heap ");
            heapSortInator(TestInator(100));
            printInfoInator();
            Console.WriteLine("Quick ");
            QuickSortInator(TestInator(100), 0, 99);
            watch.Start();
            printInfoInator();
            Console.WriteLine("1000");
            ///Random 1000
            Console.WriteLine("Insertion");
            InsertionSortInator(TestInator(1000));
            printInfoInator();
            Console.WriteLine("Heap");
            heapSortInator(TestInator(1000));
            printInfoInator();
            Console.WriteLine("Quick");
            QuickSortInator(TestInator(1000), 0, 999);
            watch.Start();
            printInfoInator();


            void InsertionSortInator(int[] sortMe)
            {
                watch.Start();
                numItems = sortMe.Length;
                for(int i = 1; i < numItems ; i++)
                {
                    int CurrentNum = sortMe[i];
                    int j = i - 1;
                    while (j >= 0 && sortMe[j] > CurrentNum)
                    {
                        sortMe[j + 1] = sortMe[j];
                        j--;
                        numberOfSorts++;
                    }
                    sortMe[j + 1] = CurrentNum;
                }
                watch.Stop();
                runningTime = watch.ElapsedMilliseconds;
            }

            void heapSortInator(int[] sortMe)
            {
                watch.Start();
                arrayToHeapInator(sortMe);
                for (int i = sortMe.Length - 1; i > 0; i--)
                {
                    int temp = sortMe[0];
                    sortMe[0] = sortMe[i];
                    sortMe[i] = temp;
                    numberOfSorts++;
                }
                watch.Stop();
                runningTime = watch.ElapsedMilliseconds;
            }

            void QuickSortInator(int[] sortMe, int lo, int hi)
            {
                if (lo < hi)
                {
                    numberOfSorts++;
                    int pivotPosition = PivotInator(sortMe, lo, hi);
                    QuickSortInator(sortMe, lo, pivotPosition - 1);
                    QuickSortInator(sortMe, pivotPosition + 1, hi);
                }
            }

            void printInfoInator()
            {
                Console.WriteLine($"Number of Sorts: {numberOfSorts} \n Run Time: {watch.Elapsed.TotalMilliseconds*1000} us \n");
                numberOfSorts = 0;
                watch.Reset();
            }
            void arrayToHeapInator(int[] heapMe)
            {
                int n = heapMe.Length;
                for (int i = n / 2 - 1; i >= 0; i--)
                    heapInator(heapMe, n, i);
            }
            void heapInator(int[] arr, int n, int i)
            {
                int largest = i; // Initialize largest as root
                int l = 2 * i + 1; // left = 2*i + 1
                int r = 2 * i + 2; // right = 2*i + 2

                // If left child is larger than root
                if (l < n && arr[l] > arr[largest])
                    largest = l;

                // If right child is larger than largest so far
                if (r < n && arr[r] > arr[largest])
                    largest = r;

                // If largest is not root
                if (largest != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = swap;

                    // Recursively heapify the affected sub-tree
                    heapInator(arr, n, largest);
                }
            }
            // A utility function to swap two elements
            static void SwapInator(int[] arr, int i, int j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
            static int PivotInator(int[] arr, int low, int high)
            {

                // pivot
                int pivot = arr[high];

                // Index of smaller element and
                // indicates the right position
                // of pivot found so far
                int i = (low - 1);

                for (int j = low; j <= high - 1; j++)
                {

                    // If current element is smaller
                    // than the pivot
                    if (arr[j] < pivot)
                    {

                        // Increment index of
                        // smaller element
                        i++;
                        SwapInator(arr, i, j);
                    }
                }
                SwapInator(arr, i + 1, high);
                return (i + 1);
            }
            static int[] TestInator(int n)
            {
                int[] randoArray = new int[n];
                for(int i = 0; i < n; i++)
                {
                    randoArray[i] = (37 * i) % n;
                }
                return randoArray;
            }
        }
    }
}
