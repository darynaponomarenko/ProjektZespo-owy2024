using Microsoft.Extensions.DependencyInjection.Extensions;
using Repository.Repo;
using System.Text.Json.Serialization;

namespace HMS_WebApi_v1._0.Bootstraps
{
    public static class LogicServiceBootstraps
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddScoped<IPatientRepo, PatientRepo>();
            services.TryAddScoped<IAppointmentRepo, AppointmentRepo>();
            services.TryAddScoped<IRegisteredAppointment, RegisteredAppointmentRepo>();
            services.TryAddScoped<ICodesRepo, CodesRepo>();
            services.TryAddScoped<IDoctorRepo, DoctorRepo>();
            services.TryAddScoped<IAddress, AddressRepo>();
            services.TryAddScoped<IReportRepo, ReportRepo>();
            services.TryAddScoped<ILoginDataRepo, LoginDataRepo>();
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            return services;
        }
    }
}
