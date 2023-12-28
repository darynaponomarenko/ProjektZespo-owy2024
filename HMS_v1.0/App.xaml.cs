using Autofac;
using AutoMapper;
using HMS_v1._0.ApiService;
using HMS_v1._0.models;
using HMS_v1._0.Models;
using HMS_v1._0.ViewModels;
using HMS_WebApi_v1._0.Services;
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

        public void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientModel>().ReverseMap()
                .ForMember(dest=>dest.Id, act=>act.Ignore())
                .ForMember(dest => dest.Addresses, act => act.Ignore())
                .ForMember(dest => dest.Appointment, act => act.Ignore());
                //cfg.CreateMap<RegistrationModel, RegisteredAppointment>().ReverseMap();
            });
            mapperConfig.AssertConfigurationIsValid();
            builder.RegisterInstance(mapperConfig.CreateMapper()).As<IMapper>().SingleInstance();
            //builder.RegisterType(typeof(ApiService<Patient>)).As(typeof(IApiService<Patient>));

            /*var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
            builder.RegisterInstance(configuration).As<IConfiguration>().SingleInstance();

            // Register HttpClient - adjust the registration based on your actual HttpClient setup
            var httpClient = new HttpClient();
            builder.RegisterInstance(httpClient).As<HttpClient>().SingleInstance();*/

            // Register ApiService with its dependencies
            builder.RegisterType<GenericApiService<Patient>>().As<IGenericApiService<Patient>>().SingleInstance();


            builder.RegisterType<NewPatientViewModel>();

            _container = builder.Build();

            NewPatientViewModel newPatientViewModel = _container.Resolve<NewPatientViewModel>();
            
        }
    }

}
