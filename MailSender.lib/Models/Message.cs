using MailSender.Models.Base;

namespace MailSender.Models
{
    public class Message : Entity
    {
        public string Title { set; get; }

        public string Text { set; get; }
    }
}
