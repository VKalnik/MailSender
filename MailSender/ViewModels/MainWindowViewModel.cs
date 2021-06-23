﻿using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MailSender.Commands;
using MailSender.Models;
using MailSender.Services;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly ServersRepository _ServersRepository;

        public MainWindowViewModel(ServersRepository ServersRepository) => _ServersRepository = ServersRepository;

        #region Title : TYPE - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Рассыльщик почты";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region Status : string - Статус

        /// <summary>Статус</summary>
        private string _Status = "Готов!";

        /// <summary>Статус</summary>
        public string Status { get => _Status; set => Set(ref _Status, value); }

        #endregion

        private ICommand _ExitCommand;

        public ICommand ExitCommand => _ExitCommand
            ??= new LambdaCommand(OnExitCommandExecuted);

        private static void OnExitCommandExecuted(object _)
        {
            Application.Current.Shutdown();
        }

        private ICommand _AboutCommand;

        public ICommand AboutCommand => _AboutCommand
            ??= new LambdaCommand(OnAboutCommandExecuted);

        private static void OnAboutCommandExecuted(object _)
        {
            MessageBox.Show("Рассыльщик почты", "О программе");
        }

        public ObservableCollection<Server> Servers { get; } = new ();

        #region Command LoadServersCommand - Загрузка списка серверов

        /// <summary>Загрузка списка серверов</summary>
        private LambdaCommand _LoadServersCommand;

        /// <summary>Загрузка списка серверов</summary>
        public ICommand LoadServersCommand => _LoadServersCommand
            ??= new(OnLoadServersCommandExecuted);

        /// <summary>Логика выполнения - Загрузка списка серверов</summary>
        private void OnLoadServersCommandExecuted(object p)
        {
            Servers.Clear();
            foreach (var server in _ServersRepository.GetAll())
                Servers.Add(server);
        }

        #endregion
    }
}
