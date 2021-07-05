using System;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.TestConsole
{
    internal static class TasksOverview
    {
        public static void Run()
        {
            new Thread(
                    () =>
                    {
                        Console.Title = DateTime.Now.ToLongTimeString();
                        Thread.Sleep(100);
                    })
                { IsBackground = true }.Start();


            Action<string> printer = str =>
            {
                Console.WriteLine($"Сообщение из потока id: {Thread.CurrentThread.ManagedThreadId} - {str}");
                Thread.Sleep(3000);
                Console.WriteLine($"Печать сообщения {str} из потока {Thread.CurrentThread.ManagedThreadId} завершена");
            };

            var task = Task.Run(() => printer("Hello world"));


            var calculate_task = new Task<int>(
                () =>
                {
                    printer("Calculate 42");
                    //throw new Exception("43");
                    return 42;
                });

            //calculate_task.ContinueWith(
            var continue_task = calculate_task.ContinueWith(
                t =>
                {
                    Console.WriteLine("Код, выполняемый по завершении основной задачи - значение результата {0}", t.Result);
                });
            ///continue_task.ContinueWith().ContinueWith().ContinueWith()...


            calculate_task.Start();

            calculate_task.Wait(); // Можно, но является признаком дурного тона!!!!!!!!!

            try
            {
                var result = calculate_task.Result; // Можно, но является признаком дурного тона!!!!!!!!!
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
