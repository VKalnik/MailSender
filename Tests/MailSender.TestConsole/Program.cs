using System;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //TasksOverview.Run();
            TPL_Overview.Run();

            Console.WriteLine("Работа завершена, нажмите Enter для выхода.");
            Console.ReadLine();
        }
    }
}
