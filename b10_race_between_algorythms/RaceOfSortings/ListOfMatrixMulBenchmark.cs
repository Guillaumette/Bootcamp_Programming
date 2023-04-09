using BenchmarkDotNet.Attributes;
using ListOfMatrixMulAlgs;

namespace RaceOfSorting
{
    [MemoryDiagnoser]
    [RankColumn]
    public class ListOfMatrixMulBenchmark
    {
        const int N = 1000;
        private static int[,] firstMatrix;
        private static int[,] secondMatrix;
        private static int[,] serialResMatrix;
        private static int[,] parallelThreadResMatrix;
        private static int[,] parallelTaskResMatrix;
        //private static readonly Random _rand = new Random();

        public static int[,] MatrixGenerator(int rows, int columns)
        {
            Random _rand = new();
            int[,] res = new int[rows, columns];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    res[i, j] = _rand.Next(50);
                }
            }
            return res;
        }

        static ListOfMatrixMulBenchmark()
        {
            firstMatrix = MatrixGenerator(N, N);
            secondMatrix = MatrixGenerator(N, N);
            serialResMatrix = new int[N, N];
            parallelThreadResMatrix = new int[N, N];
            parallelTaskResMatrix = new int[N, N];
        }

        [Benchmark]
        public void TestSerialMul()
        {
            MyMatrixMult.MatrixMultiplication(firstMatrix, secondMatrix, serialResMatrix);
        }

        [Benchmark]
        public void TestParallelMulThread()
        {
            MyMatrixMult.GoParallelMulThread(firstMatrix, secondMatrix, parallelThreadResMatrix);
        }

        [Benchmark]
        public void TestParallelMulTask()
        {
            MyMatrixMult.GoParallelMulTask(firstMatrix, secondMatrix, parallelTaskResMatrix);
        }
    }
}