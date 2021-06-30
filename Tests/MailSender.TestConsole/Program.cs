using System;
using System.Threading;

namespace MailSender.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadsIntro.Run();

            Console.WriteLine("Работа завершенна. Нажмите Enter для выхода.");
            Console.ReadLine();
        }
    }
}
