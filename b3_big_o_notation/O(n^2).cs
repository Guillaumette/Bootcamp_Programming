// O(n^2)
int n = Convert.ToInt32(Console.ReadLine());
for (int i = 1; i <= n; i++)
{
    for (int j = 1; j <= n; j++)
    {
        System.Console.Write(i * j);
        System.Console.Write("\t");
    }
    System.Console.WriteLine();
}

// Как сократить время выполнения алгоритма - матрица (смежные таблицы, по диагонали зеркальны)
// Все еще O(n^2)
int[,] matrix = new int[n,n];
for (int i = 1; i <= n / 2; i++)
{
    for (int j = 1; j <= n / 2; j++)
    {
        if(i + j <= n)
        {
            matrix[i,j] = i * j;
            matrix[j,i] = i * j;
        }
    }
    System.Console.WriteLine();
}

//O(n^2 / 2)
for (int i = 1; i <= n / 2; i++)
{
    for (int j = 1; j <= n / 2; j++)
    {
        if(i + j <= n)
        {
            Console.Write(matrix[i,j]);
            Console.Write(" ");
        }
    }
    System.Console.WriteLine();
}

//В два раза меньше
for (int i = 0; i < n; i++)
{
    for (int j = i; j < n; j++)
    {

        matrix[i,j] = (i + 1) * (j + 1);
        matrix[j,i] = (i + 1) * (j + 1);
    }
    System.Console.WriteLine();
}
    
