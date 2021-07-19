﻿using System;
using System.Diagnostics;
using MailSender.Data;
using MailSender.Interfaces;

namespace MailSender.Services
{
    class InMemoryStatisticService : IStatistic
    {
        private int _SendedMailsCount;

        public int SendedMailsCount => _SendedMailsCount;
        public event EventHandler SendedMailsCountChanged;

        public int SendersCount => TestData.Senders.Count;

        public int RecipientsCount => TestData.Recipients.Count;

        private readonly Stopwatch _Timer = Stopwatch.StartNew();
        public TimeSpan UpTime => _Timer.Elapsed;

        public int ServersCount => TestData.Servers.Count;

        public void MessageSended()
        {
            _SendedMailsCount++;
            SendedMailsCountChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
