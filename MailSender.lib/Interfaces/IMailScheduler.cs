using System;
using MailSender.Models;

namespace MailSender.Interfaces
{
    public interface IMailScheduler
    {
        void Start();
        
        void Stop();

        SchedulerTask AddRoPlan(
            DateTime Time,
            Sender Sender,
            EmailsList Recipients,
            Server Server,
            Message Message);
    }
}
