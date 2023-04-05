// оценка сложности - O(n^2) или O(n^2 / 2) - просто константами можно пренебречь
int[] SortSelection(int[] collection)
{
    int size = collection.Length;
    for (int i = 0; i < size - 1; i++)
    {
        int pos = i;
        for (int j = i + 1; j < size; j++)
        {
            if (collection[j] < collection[pos]) pos = j;
        }
        int temp = collection[i];
        collection[i] = collection[pos];
        collection[pos] = temp;
    }
    return collection;
}

var arr = new int[] {9, 6, 0, 5, 7, 3, 1, 2};
System.Console.WriteLine(string.Join(" ", arr));
SortSelection(arr);
System.Console.WriteLine(string.Join(" ", arr));