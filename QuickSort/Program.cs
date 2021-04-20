using System;
using System.Diagnostics;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfElements = 20000000;
            DataGenerator dataGenerator = new DataGenerator();
            dataGenerator.Generate(numberOfElements);

            for (int i = 0; i < 3; i++)
            {
                long[] numbers = dataGenerator.GetNumbers();
                var stopwatch = new Stopwatch();

                Console.WriteLine("QuickSort By Recursive Method - run # {0}", i);
                stopwatch.Reset();
                stopwatch.Start();
                QuickSortMultiThread.SerialQuicksort(numbers, 0, numberOfElements - 1);
                stopwatch.Stop();

                var singleThreadRuntime = stopwatch.ElapsedMilliseconds;

                System.Console.WriteLine("Single thread calculation runtime: {0} ms", singleThreadRuntime);
                Console.WriteLine(IsSorted(numbers));
            }
        }
        public static bool IsSorted(long[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

}
