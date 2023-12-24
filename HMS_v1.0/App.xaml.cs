using Autofac;
using AutoMapper;
using HMS_v1._0.models;
using HMS_v1._0.Models;
using HMS_v1._0.ViewModels;
using HMS_WebApi_v1._0.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.DataAccess;
using Repository.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Windows;
using IContainer = Autofac.IContainer;

namespace HMS_v1._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer _container;

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
            ConfigureContainer();

        }

        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientModel, Patient>().ReverseMap();
                cfg.CreateMap<RegistrationModel, RegisteredAppointment>().ReverseMap();
            });
            builder.RegisterInstance(mapperConfig.CreateMapper()).As<IMapper>().SingleInstance();
            //builder.RegisterType(typeof(ApiService<Patient>)).As(typeof(IApiService<Patient>));

            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
            builder.RegisterInstance(configuration).As<IConfiguration>().SingleInstance();

            // Register HttpClient - adjust the registration based on your actual HttpClient setup
            var httpClient = new HttpClient();
            builder.RegisterInstance(httpClient).As<HttpClient>().SingleInstance();

            // Register ApiService with its dependencies
            builder.RegisterGeneric(typeof(ApiService<>)).As(typeof(IApiService<>));


            builder.RegisterType<NewPatientViewModel>();

            IContainer _container = builder.Build();

            NewPatientViewModel newPatientViewModel = _container.Resolve<NewPatientViewModel>();
            
        }
    }

}
