﻿using System;
using System.Windows;
using MailSender.Data;
using MailSender.Interfaces;
using MailSender.Models;
using MailSender.Services;
using MailSender.Services.InMemory;
using MailSender.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MailSender
{
    public partial class App
    {
        private static IHost __Hosting;

        public static IHost Hosting => __Hosting 
            ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] Args) => Host
           .CreateDefaultBuilder(Args)
           .ConfigureAppConfiguration(opt => opt.AddJsonFile("setting.json", true, true))
           .ConfigureLogging(opt => opt.AddDebug())
           .ConfigureServices(ConfigureServices)
        ;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddDbContext<MailSenderDB>(opt => opt.UseSqlServer(host.Configuration.GetConnectionString("SqlServer")));
            
            //services.AddSingleton<>();
            //services.AddScoped<>();
            //services.AddTransient<>();


            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<IStatistic, InMemoryStatisticService>();
            services.AddScoped<IMailScheduler, MailSchedulerTPL>();

            services.AddScoped<IMailService, DebugMailService>();
            //services.AddScoped<IMailService, SmtpMailService>();

            services.AddScoped<IRepository<Server>, InMemoryServersRepository>();
            services.AddScoped<IRepository<Sender>, InMemorySendersRepository>();
            services.AddScoped<IRepository<Recipient>, InMemoryRecipientsRepository>();
            services.AddScoped<IRepository<Message>, InMemoryMessagesRepository>();
            services.AddScoped<IRepository<SchedulerTask>, InMemorySchedulerTasksRepository>();
            services.AddScoped<IRepository<EmailsList>, InMemoryEmailsListsRepository>();

            services.AddScoped<IUserDialog, WindowUserDialogService>();

            services.AddScoped<IReportService, OpenXMLReportService>();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            Hosting.Start();
            base.OnStartup(e);

            //var services = new ServiceCollection();
            //services.AddSingleton<MainWindowViewModel>();

        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Hosting.Dispose();
        }
    }
}
