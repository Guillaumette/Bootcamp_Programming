// O(log2(n) + 1)
// int n = Random.Shared.Next(10000000);
// double s = 0;
// int i = 0;
// while (i > 0)
// {
//     s += i;
//     i = i / 2;
// }

// // O(n*log2(n)) 
// for (int j = 2; j < n / 2; j++) // n/2 - 2
// {
//     while (i > 0)
//     {
//         s += i;
//         i = i / 2;
//     }
// }
// // (n/2 - 2) * (log2(n) + 1)
// // n/2 * log2(n) + n/2 - 2log2(n) - 2
// // O(n*log2(n))