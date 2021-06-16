using System;
using System.Net;
using System.Net.Mail;
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
                //MessageBox.Show("Почта успешно отправлена", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);
                SendEndWindow sendEndWindow = new SendEndWindow();
                sendEndWindow.ShowDialog();
            }
            catch (SmtpException smtp_exception)
            {
                //MessageBox.Show(smtp_exception.Message, "Ошибка при отправке почты", MessageBoxButton.OK, MessageBoxImage.Error);
                SendErrorWindow sendErrorWindow = new SendErrorWindow();
                sendErrorWindow.ErrorMsg.Text = smtp_exception.Message;
                sendErrorWindow.ShowDialog();
            }
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
