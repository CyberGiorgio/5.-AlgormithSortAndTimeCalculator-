using System;
using System.Timers;
namespace SortingAlgorithms
{
    static class Features
    {
        public static bool Try { get; private set; }
        public static int [] GenerateRandom()
        {
            Console.WriteLine("How many random numbers do you wish to sort?");
            int numbers = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[numbers];     //creation of array
            for(int i = 0; i < array.Length; i++)
            {
                Random rnd = new Random();  //random numbers between 0 and variable numbers
                array[i] = rnd.Next(0, numbers);
            }
            Console.WriteLine("Your random orginal array is : ");
            return array;
        }
        public static void PrintArray(int [] array)
        {
            if (array.Length > 100)
            {
                Array.Resize(ref array, 100);       // max no. of elements to be printed out
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " , ");
            }
            Console.WriteLine("\n");
        }
     
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {                   //time counter
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }
        static public bool TryAgain()                                      //end of game, press "y" to restart
        {
            Console.WriteLine("\nWould you like to try again? Press 'Y' or any other button to exit");
            Try = Console.ReadKey().Key == ConsoleKey.Y;
            if (Try == true)
            {
                return true;
            }
            else
            {
                Environment.Exit(0);
                return false;                                   //if !"Y" stop the program
            }
        }
        static public void Menu()
        {
            Console.WriteLine("Choose one of the following algorithms:\n" +
                       "[+] 1 BubbleSort\n" +
                       "[+] 2 InsertionSort\n" +
                       "[+] 3 MergeSort\n" +
                       "[+] 4 QuickSort\n" +
                       "[+] 5 SortVisualStudio\n" +
                       "   [-] 6 Exit");
        }
    }
}
