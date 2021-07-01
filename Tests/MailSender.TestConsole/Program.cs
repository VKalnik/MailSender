using System;
using System.Threading;

namespace MailSender.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadsIntro.Run();
            //CriticalSection.Run();
            ThreadSynchronization.Run();

            Console.WriteLine("Работа завершенна. Нажмите Enter для выхода.");
            Console.ReadLine();
        }
    }
}
