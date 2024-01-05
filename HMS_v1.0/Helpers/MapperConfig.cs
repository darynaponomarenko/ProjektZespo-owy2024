using AutoMapper;
using HMS_v1._0.models;
using HMS_v1._0.Models;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.ApiService
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientModel>().ReverseMap()
                //.ForMember(dest => dest.Id, act => act.Ignore())
                //.ForMember(act => act.Id, dest => dest.Ignore())
                .ForMember(dest => dest.Addresses, act => act.Ignore())
                .ForMember(dest => dest.Appointment, act => act.Ignore())
                .ForMember(dest => dest.RegisteredAppointments, act => act.Ignore());

                cfg.CreateMap<ICD10, ICD10sModel>().ReverseMap()
               .ForMember(dest => dest.Id, act => act.Ignore());

                cfg.CreateMap<RegisteredAppointment, RegistrationModel>().ReverseMap()
                .ForMember(dest => dest.Id, act => act.Ignore());
                //.ForMember(dest => dest.Patient, act => act.Ignore())


                cfg.CreateMap<Doctor, DoctorModel>().ReverseMap();

                cfg.CreateMap<Appointment, AppointmentModel>().ReverseMap()
                .ForMember(dest => dest.Id, act => act.Ignore());

            });
            mapperConfig.AssertConfigurationIsValid();

            var mapper = new Mapper(mapperConfig);
            return mapper;
        }
    }
}
