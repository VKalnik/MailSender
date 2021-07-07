using System;
using System.Collections.Generic;
using System.Linq;
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


        public static async Task RunAsync()
        {
            var rnd = new Random(100);
            var messages = Enumerable
               .Range(1, 100)
               .Select(i => $"Message - {i}: {new string('*', rnd.Next(5, 31))}")
               .ToArray();

            //foreach (var msg in messages)
            //    ProcessMessage(msg);

            //return Task.CompletedTask;
            //return new Task(() => { });
            //return Task.Run(() => { });


            //foreach (var message in messages)
            //    await Task.Run(() => ProcessMessage(message));

            //foreach (var message in messages)
            //{
            //    var result = await Task.Run(() => ProcessMessage(message));
            //    Console.WriteLine($"Результат обработки {result}");
            //}

            //var tasks = new List<Task<string>>();
            //foreach (var message in messages)
            //    tasks.Add(Task.Run(() => ProcessMessage(message)));

            //Task.WaitAll(tasks.ToArray()); // Плохой тон!!!!! (Блокирует поток)

            //var first_task = await Task.WhenAny(tasks); //Дождаться первой из задач

            //var first_task_result = first_task.Result; //Так не надо!!!!
            //var first_task_result = await first_task; //Так надо. Не блокирует поток!

            //await Task.WhenAll(tasks);
            //var result = await Task.WhenAll(tasks);

            //var result = await Task.WhenAll(messages.Select(msg => Task.Run(() => ProcessMessage(msg))));

            //var procesing_tasks = messages.Select(msg => Task.Run(() => ProcessMessage(msg)));
            //var result = await Task.WhenAll(procesing_tasks);

            var procesing_tasks = messages.Select(msg => Task.Run(() => ProcessMessageAsync(msg)));
            var result = await Task.WhenAll(procesing_tasks);

        }

        private static string ProcessMessage(string msg)
        {
            Console.WriteLine($"Processing message {msg} started at ThID: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(500);
            Console.WriteLine($"Processing message {msg} completed at ThID: {Thread.CurrentThread.ManagedThreadId}");
            return $"Processing message {msg}";
        }
        private static async Task<string> ProcessMessageAsync(string msg)
        {
            Console.WriteLine($"Processing message {msg} started at ThID: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(500); // Аналог Thread.Sleep(); для асинхронных оперций
            Console.WriteLine($"Processing message {msg} completed at ThID: {Thread.CurrentThread.ManagedThreadId}");
            return $"Processing message {msg}";
        }
    }
}
