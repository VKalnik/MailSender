using System;
using System.Threading.Tasks;

namespace HomeWorke_6
{
    class Program
    {
        private static int minValue = 0;
        private static int maxValue = 11;
        private static int arraySize = 100;
        
        static async Task Main(string[] args)
        {
            var array1 = MyArray.GenerateRandomArray(arraySize, arraySize, minValue, maxValue);
            var array2 = MyArray.GenerateRandomArray(arraySize, arraySize, minValue, maxValue);
            var arrayResult = await MyArray.ArrayMultiAsync(array1, array2);

            //MyArray.PrintArray(array1);
            //MyArray.PrintArray(array2);
            //MyArray.PrintArray(arrayResult);

            Console.WriteLine("Работа завершена, нажмите Enter для выхода.");
            Console.ReadLine();
        }
    }
}
