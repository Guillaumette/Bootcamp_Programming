using System.Diagnostics; // будем считать время выполнения каждого алгоритма
// Метод (unit-test), проверяющий, все ли корректно работает на каждой итерации
bool Check(int[] array)
{
    int size = array.Length;

    for (int i = 0; i < size - 1; i++)
    {
        if(array[i] > array[i + 1]) return false;
    }
    return true;
}

// флаг, нужно ли нам выводить массив (выводим, если все ок)
bool show = !true; // !, чтобы не печатать массив, а печатать только результат: отсортировался или нет

int n = 100_000;
int max = 100;

int[] array = new int[n];



for (int i = 0; i < n; i++) array[i] = Random.Shared.Next(max);
if (show) System.Console.WriteLine($"[{String.Join(',', array)}]");
int[] arr1 = new int[n];
int[] arr2 = new int[n];

Array.Copy(array, arr1, n); // делаем копии массивов, чтобы посчитать разными методами
Array.Copy(array, arr2, n); //  и увидеть разницу в эффективности алгоритмов

// // Циклом while можно более компактно оформить эту задачу, но количество действий такое же, как у for:
// int j = 0;
// while (j < n) System.Console.Write((array[j++] + " "));
// System.Console.WriteLine();

if (show) System.Console.WriteLine($"arr1: [{String.Join(',', arr1)}]"); // показываем неотсортированный первый
// засекаем время
Stopwatch sw = new Stopwatch();
sw.Start();

// Так как за прохождение первого раза мы гарантируем, что элемент ставится на свое место, в следующий раз можно его уже
// не проверять, то есть выполнять на одно действие меньше: n - 2 и т.д. Для этого можно во внутреннем цикле отнять k.

// Сложность: O(n^2/2), так как получается, что сначала n - 1 действий, потом n - 2... 3 2 1 ->
// 1 + 2 + 3 + ... + (n - 2) + (n - 1) -> (складываем первое с последним и т.д.) -> n * n/2 -> n^2 / 2
// в два раза эффективнее, чем n^2 - 2n + 1
for (int k = 0; k < n - 1; k++)
{
    for (int i = 0; i < n - 1 - k; i++)
    {
        if (arr1[i] > arr1[i + 1])
        {
            int temp = arr1[i];
            arr1[i] = arr1[i + 1];
            arr1[i + 1] = temp;
        }
    }
}
sw.Stop();
// проверяем 
System.Console.WriteLine($"arr1: {Check(arr1)} {sw.ElapsedMilliseconds}ms");

if (show) System.Console.WriteLine($"arr1: [{String.Join(',', arr1)}]"); // показываем первый, убеждаемся, что он отсортирован
if (show) System.Console.WriteLine($"arr2: [{String.Join(',', arr2)}]"); // показываем неотсортированный второй
// System.Console.ReadLine(); // искусственная задержка
sw.Reset(); // сбрасываем секундомер

sw.Start(); // запускаем по новой

// O(n^2 - 2n + 1), так как для массива размером n нужно n - 1 действий, чтобы поставить на место максимум,
// следовательно, чтобы отсортировать все, нужно (n - 1)(n - 1) -> (n - 1)^2
for (int k = 0; k < n - 1; k++)
{
    for (int i = 0; i < n - 1; i++)
    {
        if (arr2[i] > arr2[i + 1])
        {
            int temp = arr2[i];
            arr2[i] = arr2[i + 1];
            arr2[i + 1] = temp;
        }
    }
}
sw.Stop();

System.Console.WriteLine($"arr2: {Check(arr2)} {sw.ElapsedMilliseconds}ms");

if (show) System.Console.WriteLine($"arr2: [{String.Join(',', arr2)}]"); // показываем второй, убеждаемся, что он отсортирован