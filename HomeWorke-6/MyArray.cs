using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWorke_6
{

    internal static class MyArray
    {
        private static readonly Random rnd = new();

        public static int[,] GenerateRandomArray(int n, int m, int minValue, int maxValue)
        {
            var array = new int[ n, m];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    array[i, j] = rnd.Next(minValue, maxValue);
                }
            }
            return array;
        }

        public static void PrintArray(int[,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i,j],5}");
                }
                Console.WriteLine();
            }
        }

        private static int ArraValueMulti(int[,] arrayValue, int[,] array1, int[,] array2, int i, int j, out int thread_id)
        {
            arrayValue[i, j] = 0;
            for (int k = 0; k < array1.GetLength(0); k++)
            {
                arrayValue[i, j] += array1[i, k] * array2[k, j];
            }
            thread_id = Thread.CurrentThread.ManagedThreadId;
            return arrayValue[i, j];
        }

        private static void Progress(int i, int i0, int j0, int thread_id)
        {
            Console.WriteLine($"arrayResult[{i0}, {j0}] = {i} вычисленно в потоке {thread_id}");
        }
        public static async Task<int [,]> ArrayMultiAsync(int[,] array1, int[,] array2)
        {
            int[,] arrayResult = new int[array1.GetLength(0), array2.GetLength(1)];
            var tasks = new List<Task>();
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array2.GetLength(1); j++)
                {
                    int i0 = i;
                    int j0 = j;
                    tasks.Add(Task.Run(() =>
                    {
                        arrayResult[i0,j0] = ArraValueMulti(arrayResult, array1, array2, i0, j0, out int thread_id);
                        Progress(arrayResult[i0, j0], i0, j0, thread_id);
                    }));
                }
            }
            await Task.WhenAll(tasks).ConfigureAwait(false);
            return arrayResult;
        }
    }
}
