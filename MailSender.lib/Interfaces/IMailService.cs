namespace MailSender.Interfaces
{
    public interface IMailService
    {
        //void SendEmail(string From, string To, string Title, string Body);
        IMailSender GetSender(string ServerAddress, int Port, bool UseSSL, string Login, string Password);
    }

    public interface IMailSender
    {
        void Send(string SenderAddress, string RecipientAddress, string Subject, string Body);
    }
}
