using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue;
            int[] array;
            do
            {
                isTrue = false;
                try
                {
                    array = Features.GenerateRandom();
                    Features.PrintArray(array);
                    Features.Menu();

                    switch (Convert.ToInt32(Console.ReadLine()))
                    {               //choose sorting algorithm
                        case 1:
                            Sorting.BubbleSort(array);
                            Features.PrintArray(array);
                            break;
                        case 2:
                            Sorting.InsertionSort(array);
                            Features.PrintArray(array);
                            break;
                        case 3:
                            Sorting.MergeSort(array);
                            Features.PrintArray(array);
                            break;
                        case 4:
                            Sorting.QuickSort(array);
                            Features.PrintArray(array);
                            break;
                        case 5:
                            Sorting.SortVisualStudio(array);
                            Features.PrintArray(array);
                            break;
                        case 6:
                            isTrue = true;
                            System.Environment.Exit(0);
                            break;
                    }
                } catch (FormatException e)
                {
                    Console.WriteLine("Input error");
                }
                if (Features.TryAgain() == true)            // play again 'Y' or 'N'?   
                {
                    Console.Clear();                        //if press "Y" clear screen
                }
            } while (!isTrue);
        }
    }
}
