using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.TestConsole
{
    internal static class ReadingFileTest
    {
        public static async Task RunAsync()
        {
            const string file_name1 = "Data/Vojna-i-mir-Tom-1.txt";
            const string file_name2 = "Data/Vojna-i-mir-Tom-2.txt";
            const string file_name3 = "Data/Vojna-i-mir-Tom-3.txt";
            const string file_name4 = "Data/Vojna-i-mir-Tom-4.txt";

            var start_thread_id = Thread.CurrentThread.ManagedThreadId;

            var progress = new Progress<double>(p => Console.WriteLine($"Прогресс операции {p:p2}")); //работает с потоком, номер которого считал при создании (в асинхронном может не верно выводить, при смене потока), Удобно работать с интерфейсом пользователя

            var count_words_task1 = GetWordsCountAsync(file_name1, progress);
            var count_words_task2 = GetWordsCountAsync(file_name2);
            var count_words_task3 = GetWordsCountAsync(file_name3);
            var count_words_task4 = GetWordsCountAsync(file_name4);

            //var count = await count_words_task1.ConfigureAwait(false);

            var counts = await Task.WhenAll(
                count_words_task1,
                count_words_task2,
                count_words_task3,
                count_words_task4
            ).ConfigureAwait(false);

            var end_thread_id = Thread.CurrentThread.ManagedThreadId;
        }

        private static async Task<int> GetWordsCountAsync(
            string FileName, 
            IProgress<double> Progress = null, 
            CancellationToken Cancel = default)
        {
            Cancel.ThrowIfCancellationRequested();

            using var reader = File.OpenText(FileName);
            var file_length = reader.BaseStream.Length;

            var start_thread_id = Thread.CurrentThread.ManagedThreadId;

                var words_count = 0;
            while (!reader.EndOfStream && !Cancel.IsCancellationRequested)
            {
                var line = await reader.ReadLineAsync().ConfigureAwait(false);
                //var line = await Task.Run(() => reader.ReadLineAsync()); // В данном случае не имеет смысла, так как поток выполняет не процессор а переферия (работа с файлами, сетью....)

                if (line.Length == 0) continue;

                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                words_count += words.Length;

                var thread_id = Thread.CurrentThread.ManagedThreadId;

                var position = reader.BaseStream.Position;
                Progress?.Report((double)position / file_length);

            }
            Cancel.ThrowIfCancellationRequested();
            //if(Cancel.IsCancellationRequested) new OperationCanceledException(Cancel); так тоже можно

            return words_count;
        }
    }
}
