﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading;
using MailSender.Interfaces;

namespace MailSender.Services
{
    public class SmtpMailService : IMailService
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
                using var client = new SmtpClient(_ServerAddress, _Port)
                {
                    EnableSsl = _UseSsl,
                    Credentials = new NetworkCredential
                    {
                        UserName = _Login,
                        Password = _Password,
                    }
                };

                using var message = new MailMessage(SenderAddress, RecipientAddress)
                {
                    Subject = Subject,
                    Body = Body,
                };

                client.Send(message);

            }

            public void Send(string SenderAddress, IEnumerable<string> RecipientAddress, string Subject, string Body)
            {
                foreach (var recipients_address in RecipientAddress)
                    Send(SenderAddress, recipients_address, Subject, Body);
            }

            public void SendParallel(string SenderAddress, IEnumerable<string> RecipientAddress, string Subject, string Body)
            {
                foreach (var recipients_address in RecipientAddress)
                    //ThreadPool.QueueUserWorkItem(_ => Send(SenderAddress, recipients_address, Subject, Body));
                    ThreadPool.QueueUserWorkItem(p => 
                        Send((string)((object[])p)[0], (string)((object[])p)[1], (string)((object[])p)[2], (string)((object[])p)[3]),
                        new [] { SenderAddress, recipients_address, Subject, Body });

            }
        }
    }
}
