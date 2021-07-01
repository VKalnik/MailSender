using System;

/*Кальник Виктор

 1. Написать приложение, считающее в раздельных потоках:
a. факториал числа N, которое вводится с клавиатуру;
b. сумму целых чисел до N, которое также вводится с клавиатуры.
 */

namespace HomeWork_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует программа расчёта факториала и суммы целого числа.");
            Console.Write("Введите целое число: ");
            int number = GetInt();

            var calculationFactorial = new CalculationFactorialTask(number);
            calculationFactorial.Start();

            var calculationSum = new CalculationSumTask(number);
            calculationSum.Start();

            Console.WriteLine($"\nФакториал числа {number} = {calculationFactorial.Result}");
            Console.WriteLine($"Сумма чисел от 1 до {number} = {calculationSum.Result}");
            
            Console.WriteLine("\nРабота завершенна. Нажмите Enter для выхода.");
            Console.ReadLine();
        }
        static int GetInt() //проверка ввода на число.
        {
            int x = 0;
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("Неверный ввод, введите число: ");
            }
            return x;
        }
    }
}
