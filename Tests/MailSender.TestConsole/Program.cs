using System;
using System.Net;
using System.Net.Mail;

namespace MailSender.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using var message = new MailMessage("kalnik.victor@yandex.ru", "kalnik.victor@yandex.ru");

            using var client = new SmtpClient("smtp.yandex.ru", 25);

            client.EnableSsl = true;
            client.Credentials = new NetworkCredential
            {
                UserName = "kalnik.victor",
                Password = "123"
            };

            client.Send(message);
        }
    }
}
