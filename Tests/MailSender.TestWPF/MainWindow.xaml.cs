using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MailSender.TestWPF
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            using var message = new MailMessage(MailSenderTestWpfConfig.SendersAddress, MailSenderTestWpfConfig.RecipientAddress);
            message.Subject = MailSenderTestWpfConfig.MessageSubject;
            message.Body = MailSenderTestWpfConfig.MessageBody;

            using var client = new SmtpClient(MailSenderTestWpfConfig.SmtpServer, MailSenderTestWpfConfig.SmtpServerPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential
                {
                    UserName = LoginEdit.Text,
                    SecurePassword = PasswordEdit.SecurePassword,
                }
            };

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
    }
}
