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

            using (var mailSenderServiceClass = new MailSenderServiceClass(LoginEdit.Text, PasswordEdit.SecurePassword, MailSenderTestWpfConfig.SmtpServer, MailSenderTestWpfConfig.SmtpServerPort, MailSenderTestWpfConfig.SendersAddress))
            {
                mailSenderServiceClass.Send(MailSenderTestWpfConfig.MessageSubject, MailSenderTestWpfConfig.MessageBody, MailSenderTestWpfConfig.RecipientAddress);
            };
        }
    }
}
