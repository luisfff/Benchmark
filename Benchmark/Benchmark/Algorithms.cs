using System;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [MemoryDiagnoser]
    public class Algorithms
    {
        [Benchmark]
        public void MaxLinearSearchOption()
        {
            var array = GetRandomArray();

            FindMaxLinearSearch(array);
        }

        [Benchmark]
        public void MaxBinarySearchOption()
        {
            var array = GetRandomArray();

            FindMaxBinarySearchBubbleSort(array);
        }

        private int FindMaxLinearSearch(int[] array)
        {
            var max = array[0];
            for (var i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        private int FindMaxBinarySearchBubbleSort(int[] array)
        {
            BubbleSort(array);
            return array[array.Length - 1];
        }

        private void BubbleSort(int[] arr)
        {
            var swapped = true;
            while (swapped)
            {
                swapped = false;
                for (var i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        // Swap the elements
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
            }
        }

        private static int[] GetRandomArray()
        {
            Random random = new Random();
            int[] array = new int[1000];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 999999);
            }

            return array;
        }


    }
}