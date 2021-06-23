using System;

namespace MailSender.Interfaces
{
    public interface IStatistic
    {
        int SendedMailCount { get; }

        int SendersCount { get; }

        int RecipientsCount { get; }

        TimeSpan UpTime { get; }
        
        void MessageSended();
    }
}
