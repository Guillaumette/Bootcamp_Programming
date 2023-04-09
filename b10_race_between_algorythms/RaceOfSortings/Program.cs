using BenchmarkDotNet.Running;


namespace RaceOfSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Нажмите \n1) чтобы запустить тест Алгоритмов сортировки\n2) чтобы запустить тест многопоточности");

            _ = int.TryParse(Console.ReadLine(), out int select);

            if (select < 2)
            {
                BenchmarkRunner.Run<ListOfSortingBenchmark>();
            }
            else
            {
                BenchmarkRunner.Run<ListOfMatrixMulBenchmark>();
            }

            Console.ReadLine();
        

        }
    }
}