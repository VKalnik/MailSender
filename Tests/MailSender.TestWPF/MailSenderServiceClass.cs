using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security;

namespace MailSender.TestWPF
{
    public class MailSenderServiceClass : IDisposable
    {
        private readonly string username;
        private readonly string smtpServer;
        private readonly int smtpServerPort;
        private readonly string sendersAddress;
        private readonly SecureString password;
        private readonly SmtpClient client;


        public MailSenderServiceClass(string username, SecureString password, string smtpServer, int smtpServerPort, string sendersAddress) 
        {
            this.username = username;
            this.password = password;
            this.smtpServer = smtpServer;
            this.smtpServerPort = smtpServerPort;
            this.sendersAddress = sendersAddress;
            client = new SmtpClient(smtpServer, smtpServerPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential
                {
                    UserName = username,
                    SecurePassword = password,
                }
            };
        }

        public void Send(string subject, string body, string recipientAddress)
        {
            using var message = new MailMessage(sendersAddress, recipientAddress);
            message.Subject = subject;
            message.Body = body;

            try
            {
                client.Send(message);
                MessageBox.Show("Почта успешно отправлена", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SmtpException smtp_exception)
            {
                MessageBox.Show(smtp_exception.Message, "Ошибка при отправке почты", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
