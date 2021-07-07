using System;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //TasksOverview.Run();
            //TPL_Overview.Run();
            //TasksOverview.RunAsync().Wait();
            //await TasksOverview.RunAsync();
            await ReadingFileTest.RunAsync();


            Console.WriteLine("Работа завершена, нажмите Enter для выхода.");
            Console.ReadLine();
        }
    }
}
