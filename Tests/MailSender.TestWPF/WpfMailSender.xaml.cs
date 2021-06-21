using System;
using System.Windows;

namespace MailSender.TestWPF
{
    public partial class WpfMailSender
    {
        public WpfMailSender() => InitializeComponent();

        //private void SendButton_OnClick(object sender, RoutedEventArgs e)
        //{

        //    using (var mailSenderServiceClass = new MailSenderServiceClass(LoginEdit.Text, PasswordEdit.SecurePassword, MailSenderTestWpfConfig.SmtpServer, MailSenderTestWpfConfig.SmtpServerPort, MailSenderTestWpfConfig.SendersAddress))
        //    {
        //        mailSenderServiceClass.Send(SubjectEdit.Text + " Время отправки: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff"), BodyEdit.Text, MailSenderTestWpfConfig.RecipientAddress);
        //    };
        //}

        //private void Exit_OnClick(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}
    }
}
