using System.Linq;

namespace MailSender.Services
{
    public static class TextEncoder
    {
        public static string Encode(string srt, int Key = 1)
        {
            return new (srt.Select(c=>(char) (c + Key)).ToArray());
        }

        public static string Decode(string srt, int Key = 1)
        {
            return new(srt.Select(c => (char)(c - Key)).ToArray());
        }
    }
}
