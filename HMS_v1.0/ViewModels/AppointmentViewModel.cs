using AutoMapper;
using GalaSoft.MvvmLight.Messaging;
using HMS_v1._0.ApiService;
using HMS_v1._0.Messages;
using HMS_v1._0.models;
using HMS_v1._0.Models;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Windows;

namespace HMS_v1._0.ViewModels
{
    public class AppointmentViewModel : ViewModelBase
    {
        private readonly HttpClient httpClient;
        readonly IMapper mapper = MapperConfig.InitializeAutomapper();
        public AppointmentViewModel() 
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7057/")
            };

            Messenger.Default.Register<AppointmentSelectedMessage>(this, OnAppointmentAdded);
        }

        private void OnAppointmentAdded(AppointmentSelectedMessage registered)
        {
            PayersName = registered.PayersName;
            Time = registered.Time;
            Pesel = registered.Pesel;
            Worklist = registered.WorkList;
            
        }

        private string _payersName;
        public string PayersName
        {
            get { return _payersName; } 
            set
            {
                _payersName = value;
                OnPropertyChanged(nameof(PayersName));
            }
        }

        private string _time;
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        private string _pesel;
        public string Pesel
        {
            get { return _pesel; }
            set
            {
                _pesel = value;
                OnPropertyChanged(nameof(Pesel));
            }
        }

        private string _workList;
        public string Worklist
        {
            get { return _workList; }
            set
            {
                _workList = value;
                OnPropertyChanged(nameof(Worklist));
            }
        }


        private RegistrationModel _registrationModel;
        public RegistrationModel RegistrationModel
        {
            get { return _registrationModel; }
            set
            {
                if (_registrationModel != value)
                {
                    _registrationModel = value;
                    OnPropertyChanged(nameof(RegistrationModel));
                }
            }
        }

        private ObservableCollection<DoctorModel> doctors;

        public ObservableCollection<DoctorModel> Doctors
        {
            get { return doctors; }
            set
            {
                if (doctors != value)
                {
                    doctors = value;
                    OnPropertyChanged(nameof(Doctors));
                }
            }
        }

        private DoctorModel selectedDoctor = null!;
        public DoctorModel SelectedDoctor
        {
            get { return selectedDoctor; }
            set
            {
                if (selectedDoctor != value)
                {
                    selectedDoctor = value;
                    OnPropertyChanged(nameof(SelectedDoctor));
                }
            }
        }

        public ObservableCollection<string> DoctorSurnames
        {
            get { return new ObservableCollection<string>(Doctors.Select(doctor => doctor.Surname)); }
        }


        public async void LoadDoctorsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("api/doctors");
                response.EnsureSuccessStatusCode();

                var doctorsFromApi = await response.Content.ReadAsAsync<List<Doctor>>();
                var doctorModel = doctorsFromApi.Select(d => new DoctorModel
                {
                    //Name = d.Name,
                    Surname = d.Surname,
                    NPWZ = d.NPWZ,
                    //Id = d.Id
                }).ToList();
               
                Doctors = new ObservableCollection<DoctorModel>(doctorModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
