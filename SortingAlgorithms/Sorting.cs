using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SortingAlgorithms
{
    static class Sorting
    {
        public static void SortVisualStudio(int[] array)
        {
            var wtc = new Stopwatch();
            wtc.Start();            //timer starts
            Array.Sort(array);      //sorting function
            wtc.Stop();     //stop timer at the end of algorithm

            Console.WriteLine("\nTime elapsed: {0:ss\\:fffffff} seconds", wtc.Elapsed); //time printer
            Console.WriteLine("\nThe sorted array is:");
        }
        public static void BubbleSort(int[] array)
        {
            var wtc = new Stopwatch();
            wtc.Start();                    //timer starts
            for (int partIndex = 0; partIndex < array.Length; partIndex++)  //first loop starts at first element
            {
                for (int i = 0; i < array.Length - 1; i++) //second loop looking for greater numbers
                {
                    if (array[i] > array[i + 1])    //if first element greater than the second one swap()
                    {
                        Swap(array, i, i + 1);      //swap function
                    }
                }
            }
            wtc.Stop();     //stop timer at the end of algorithm
            
            Console.WriteLine("\nTime elapsed: {0:ss\\:fffffff} seconds", wtc.Elapsed); //time printer
            Console.WriteLine("\nThe sorted array is:");
        }

        private static void Swap(int[] array, int i, int j)
        {
            if (i == j)         //if this condition is met do nothing
                return;
            int temp = array[i];    //else store element at array[i] into temp
            array[i] = array[j];    //store in array[i] element from array[j]
            array[j] = temp;        //override element at array[j] with temp
        }

        public static void InsertionSort(int[] array)
        {
            var wtc = new Stopwatch();
            wtc.Start();        //timer starts
            for (int partIndex = 1; partIndex < array.Length; partIndex++)
            {           //first loop starting at array[1]
                int curUnsorted = array[partIndex]; // array[1] stored into a variable
                int i = 0;
                for (i = partIndex; i > 0 && array[i - 1] > curUnsorted; i--)
                {      //second loop looking for smaller elements moving back and swap
                    array[i] = array[i - 1];
                }
                array[i] = curUnsorted;
            }
            wtc.Stop();              //stop timer at the end of algorithm
            Console.WriteLine("\nTime elapsed: {0:ss\\:fffffff} seconds", wtc.Elapsed); //time printer
            Console.WriteLine("\nThe sorted array is:");
        }

        public static void QuickSort(int[] array)
        {
            var wtc = new Stopwatch();
            wtc.Start();        //timer starts
            Sort(0, array.Length - 1);

            void Sort(int low, int high) //private function to Sort
            {
                if (high <= low)
                    return;
                int j = Partition(low, high);
                Sort(low, j - 1);   // sort left side
                Sort(j + 1, high);  // sort right side
            }

            int Partition(int low, int high) //private function to divide
            {
                int i = low;    //starting element
                int j = high + 1;   //end element

                int pivot = array[low]; //pit chosen first element(may be quicker if random)
                while (true)
                {
                    while (array[++i] < pivot)  //compare < element to pivot
                    {
                        if (i == high)
                            break;
                    }

                    while (pivot < array[--j]) //compare < element to pivot
                    {
                        if (j == low)
                            break;
                    }

                    if (i >= j) //break condition or Swap()
                        break;

                    Swap(array, i, j);
                }
                Swap(array, low, j);    //reposition of pivot 
                return j;       //new boundary at j position
            }
            wtc.Stop(); //timer stop
            Console.WriteLine("\nTime elapsed: {0:ss\\:fffffff} seconds", wtc.Elapsed); //print time
            Console.WriteLine("\nThe sorted array is:");
        }

        public static void MergeSort(int[] array)
        {
            var wtc = new Stopwatch();
            wtc.Start();        //timer starts
            int[] aux = new int[array.Length];  //new array to store the sorted array
            Sort(0, array.Length - 1);  //execution of Sort

            void Sort(int low, int high) //private function to sort
            {
                if (high <= low)    //in this case stop
                    return;

                int mid = (high + low) / 2; //middle element
                Sort(low, mid);     //split left side
                Sort(mid + 1, high);    //split right side
                Merge(low, mid, high);  //merge the array
            }

            void Merge(int low, int mid, int high)  //private function to merge
            {
                if (array[mid] <= array[mid + 1])    //if already sorted stop
                    return;

                int i = low;    //starting element left array
                int j = mid + 1;    //starting element right array

                Array.Copy(array, low, aux, low, high - low + 1);
                //copy orgininal array into aux array
                for (int k = low; k <= high; k++)
                {
                    if (i > mid) array[k] = aux[j++]; //left array exhausted
                    else if (j > high)      //right array exausted
                        array[k] = aux[i++];
                    else if (aux[j] < aux[i]) //right key < left key
                        array[k] = aux[j++];    //take from the right
                    else
                        array[k] = aux[i++]; //take from the left
                }
            }
            wtc.Stop();     //stop timer
            Console.WriteLine("\nTime elapsed: {0:ss\\:fffffff} seconds", wtc.Elapsed); //print time
            Console.WriteLine("\nThe sorted array is:");
        }
    }
}
