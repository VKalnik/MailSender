using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MailSender.TestConsole
{
    internal static class TPL_Overview
    {

        public static void Run()
        {
            var opt = new ParallelOptions {MaxDegreeOfParallelism = 2};

            //Parallel.Invoke(
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    () => Console.WriteLine("123"));

            //var methods = Enumerable.Repeat(new Action(ParallelInvokeMethod), 100).ToArray();
            //Parallel.Invoke(new ParallelOptions {MaxDegreeOfParallelism = 2}, methods);

            //Parallel.For(0, 100, opt, i => ParallelInvokeMethod($"Message - {i}"));

            //var result = Parallel.For(0, 100, (i, state) =>
            //{
            //    if(i >= 20)
            //        state.Break();
            //    ParallelInvokeMethod($"Message - {i}");
            //});
            //Console.WriteLine(result.LowestBreakIteration);

            var rnd = new Random(100);
            var message = Enumerable
               .Range(1, 100)
               .Select(i => $"Message - {i}: {new string('*', rnd.Next(5, 31))}")
               .ToArray();

            //Parallel.ForEach(message, msg => ParallelInvokeMethod(msg));

            //var foreach_result = Parallel.ForEach(message, (msg, state) =>
            //{
            //    if(msg.EndsWith("36"))
            //        state.Break();
            //    ParallelInvokeMethod(msg);
            //});

            //Console.WriteLine(foreach_result.LowestBreakIteration);

            static int GetMessageLenght(string msg)
            {
                Thread.Sleep(200);
                return msg.Length;
            }

            var timer = Stopwatch.StartNew();
            var messages_sum = message
               .AsParallel()
               .WithDegreeOfParallelism(20)
               .Select(GetMessageLenght)
               .AsSequential()
               .Sum();

            var result = timer.Elapsed;

        }

        private static void ParallelInvokeMethod()
        {
            var thread_id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"ThreadId:{thread_id} - started");
            Thread.Sleep(250);
            Console.WriteLine($"ThreadId:{thread_id} - completed");
        }

        private static void ParallelInvokeMethod(string Message)
        {
            var thread_id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"ThreadId:{thread_id} - started :: {Message}");
            Thread.Sleep(250);
            Console.WriteLine($"ThreadId:{thread_id} - completed :: {Message}");
        }
    }
}
