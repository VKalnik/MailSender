namespace MailSender.TestWPF
{
    public static class MailSenderTestWpfConfig
    {
        private static string sendersAddress = "viktor.kalnik@yandex.ru";
        private static string recipientAddress = "v.kalnik@mail.ru";
        private static string smtpServer = "smtp.yandex.ru";
        private static int smtpServerPort = 25;

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
    }
}
