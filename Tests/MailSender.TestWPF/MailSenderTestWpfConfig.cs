using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.TestWPF
{
    public static class MailSenderTestWpfConfig
    {
        private static string sendersAddress = "viktor.kalnik@yandex.ru";
        private static string recipientAddress = "v.kalnik@mail.ru";
        private static string smtpServer = "smtp.yandex.ru";
        private static int smtpServerPort = 25;
        private static string messageSubject = "Тестовое сообщение от " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff") + " ";
        private static string messageBody = "Тело тестового сообщения " + DateTime.Now.ToString("F") + " ";

        public static string SendersAddress
        {
            get { return sendersAddress; }
            set
            {
                sendersAddress = value;
            }
        }

        public static string RecipientAddress
        {
            get { return recipientAddress; }
            set
            {
                recipientAddress = value;
            }
        }

        public static string SmtpServer
        {
            get { return smtpServer; }
            set
            {
                smtpServer = value;
            }
        }
        public static int SmtpServerPort
        {
            get { return smtpServerPort; }
            set
            {
                smtpServerPort = value;
            }
        }

        public static string MessageSubject
        {
            get { return messageSubject; }
            set
            {
                messageSubject = value;
            }
        }

        public static string MessageBody
        {
            get { return messageBody; }
            set
            {
                messageBody = value;
            }
        }
    }
}
