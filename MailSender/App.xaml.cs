﻿using System;
using System.Windows;
using MailSender.Services;
using MailSender.ViewModels;
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
            services.AddTransient<MainWindowViewModel>();
            services.AddSingleton<ServersRepository>();
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
