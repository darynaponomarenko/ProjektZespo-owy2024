using Autofac;
using AutoMapper;
using HMS_v1._0.models;
using HMS_v1._0.Models;
using HMS_v1._0.ViewModels;
using HMS_WebApi_v1._0.Services;
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
            builder.RegisterType<ApiService<PatientModel>>().As<IApiService<PatientModel>>().SingleInstance();


            builder.RegisterType<NewPatientViewModel>();

            _container = builder.Build();

            NewPatientViewModel newPatientViewModel = _container.Resolve<NewPatientViewModel>();
            
        }
    }

}
