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
using System.IO;
using System.Windows;

namespace HMS_v1._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; }
        public static IMapper Mapper { get; set; }

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

            var services = new ServiceCollection();

            services.AddHttpClient<IApiService<Patient>, ApiService<Patient>>();
            services.AddDbContext<DBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Data Source=DESKTOP-J7CUSB6\\SQLEXPRESS;Initial Catalog = HMSLocalDB; User id=sa; Password=test; TrustServerCertificate=True")));

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientModel, Patient>().ReverseMap();
                cfg.CreateMap<Registration, RegisteredAppointment>().ReverseMap();
            });

            services.AddSingleton<IMapper>(new Mapper(mapperConfig));

            ServiceProvider serviceProvider = services.BuildServiceProvider();


        }
    }

}
