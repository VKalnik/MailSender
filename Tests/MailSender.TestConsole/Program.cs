using System;
using System.Threading;

namespace MailSender.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var time_thread = new Thread(TimeThreadMethod);
            time_thread.Name = "Поток часов";
            time_thread.IsBackground = true;
            time_thread.Priority = ThreadPriority.Lowest;
            time_thread.Start();

            var message1 = "Messsage 1";
            var printer1 = new Thread(() => PrintMessage(message1, 20));
           
            var message2 = "Messsage 2";
            var printer2 = new Thread(() => PrintMessage(message2, 20));

            var message3 = "Messsage 3";
            var printer3 = new Thread(PrintMessageParameter);

            var calculation = new CalculationSumTask(5000);
            calculation.Start();

            //calculation.Join();


            //printer1.Start();
            //printer1.Join();

            //printer2.Start();
            //printer3.Start(message3);

            Console.WriteLine($"Сумма чисел от 1 до 5000 = {calculation.Result}");

            Console.WriteLine("Работа завершенна. Нажмите Enter для выхода.");
            Console.ReadLine();
        }

        private static void TimeThreadMethod()
        {
            while (true)
            {
                Console.Title = DateTime.Now.ToString("HH:mm:ss:fff");
                Thread.Sleep(100);
            }
        }


        private static void PrintMessageParameter(object p) => PrintMessage((string) p, 20);

        private static void PrintMessage(string Message, int Count, int Timeout = 300)
        {
            var thread_id = Thread.CurrentThread.ManagedThreadId;
            
            for (var i = 1; i <= Count; i++)
            {
                Console.Write(thread_id);
                Console.Write(" - ");
                Console.Write(i);
                Console.Write(" ");
                Console.WriteLine(Message);
                Thread.Sleep(Timeout);
            }

            Console.WriteLine($"{thread_id} - Print message {Message} completed.");

        }
    }

    internal class CalculationSumTask
    {
        private readonly Thread _Thread;
        private readonly int _Number;

        private int _Result;

        public int Result
        {
            get
            {
                Join();
                return _Result;
            }
            private set => _Result = value;
        }

        public CalculationSumTask(int Number)
        {
            _Number = Number;
            _Thread = new Thread(Calculation);
        }

        public void Start() => _Thread.Start();

        private void Calculation()
        {
            var sum = 0;
            for (var i = 1; i < _Number; i++)
            {
                sum += i;
            }

            _Result = sum;
        }

        public void Join() => _Thread.Join();
    }
}
