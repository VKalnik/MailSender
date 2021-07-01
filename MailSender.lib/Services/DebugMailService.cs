﻿using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using MailSender.Interfaces;

namespace MailSender.Services
{
    public class DebugMailService : IMailService
    {
        public IMailSender GetSender(string ServerAddress, int Port, bool UseSSL, string Login, string Password)
        {
            return new Sender(ServerAddress, Port, UseSSL, Login, Password);
        }


        private class Sender : IMailSender
        {
            private readonly string _ServerAddress;
            private readonly int _Port;
            private readonly bool _UseSsl;
            private readonly string _Login;
            private readonly string _Password;

            public Sender(string ServerAddress, int Port, bool UseSSL, string Login, string Password)
            {
                _ServerAddress = ServerAddress;
                _Port = Port;
                _UseSsl = UseSSL;
                _Login = Login;
                _Password = Password;
            }
            public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
            {
                Debug.WriteLine($"Отправка почты через {_ServerAddress}:{_Port} SSL:{_UseSsl}\r\n\t"
                    + $"from {SenderAddress} to {RecipientAddress}\r\n\t"
                    + $"msg ({Subject}):{Body}");
            }
        }
    }
}
