using BenchmarkDotNet.Attributes;
using ListOfSortingAlgs;

namespace RaceOfSorting
{
    [MemoryDiagnoser]
    [RankColumn]
    public class ListOfSortingBenchmark
    {
        private static readonly int[] arr = new int[1000];
        private static readonly Random rnd = new Random();

        static ListOfSortingBenchmark()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 1000);
            }
        }

        public int[] GetArr()
        {
            int[] res = new int[arr.Length];
            Array.Copy(arr, res, arr.Length);
            return res;
        }

        [Benchmark]
        public void TestQuickSort()
        {
            int[] testArr = GetArr();
            MySort.QuickSort(testArr, 0, testArr.Length - 1);
        }

        [Benchmark]
        public void TestBoobleSort()
        {
            int[] testArr = GetArr();
            MySort.BoobleSort(testArr);
        }

        [Benchmark]
        public void TestSelectionSort()
        {
            int[] testArr = GetArr();
            MySort.SelectionSort(testArr);
        }

        [Benchmark]
        public void TestCountingSort()
        {
            int[] testArr = GetArr();
            MySort.CountingSort(testArr);
        }

        [Benchmark]
        public void TestDotnetSort()
        {
            int[] testArr = GetArr();
            Array.Sort(testArr);
        }
    }
}