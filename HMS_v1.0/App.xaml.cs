using AutoMapper;
using HMS_v1._0.ApiService;
using HMS_v1._0.models;
using HMS_v1._0.Models;
using HMS_v1._0.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Models;
using System.IO;
using System.Net.Http;
using System.Windows;

namespace HMS_v1._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       

        public IConfiguration Configuration { get; }

        public App()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = configBuilder.Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            

        }

       
    }

}
