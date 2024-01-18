using AutoMapper;
using GalaSoft.MvvmLight.Messaging;
using HMS_v1._0.ApiService;
using HMS_v1._0.Commands;
using HMS_v1._0.Messages;
using HMS_v1._0.models;
using HMS_v1._0.Views;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HMS_v1._0.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly HttpClient httpClient;
        readonly IMapper mapper = MapperConfig.InitializeAutomapper();

        

        public MainWindowViewModel()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7057/")
            };

            Messenger.Default.Register<NewAppointmentRegistered>(this,OnAppointmentAdded);
            Messenger.Default.Register<PatientHasArrived>(this, OnPatientArrived);
            Messenger.Default.Register<HideAppointmentFromList>(this, OnStatusChanged);

            OpenAppointmentViewCommand = new OpenAppointmentViewCommand(this);
            OpenRegistrationViewCommand = new OpenRegistrationViewCommand(this);
        }

       

        private void OnAppointmentAdded(NewAppointmentRegistered registered)
        {
            RegisteredAppointments.Add(registered.RegistrationModel);
            //await LoadAppointmentsAsync();
        }

        private void OnPatientArrived(PatientHasArrived Message)
        {
            Color = Message.Color;
        }

        private async void OnStatusChanged(HideAppointmentFromList hide)
        {
            IsActive = false;

            RegistrationModel model = new()
             { 
                Procedure = SelectedAppointment.Procedure,
                Priority = SelectedAppointment.Priority,
                Worklist = SelectedAppointment.Worklist,
                Date = SelectedAppointment.Date,
                Time = SelectedAppointment.Time,
                PayerExtraNote = SelectedAppointment.PayerExtraNote,
                DateOfIssue = SelectedAppointment.DateOfIssue,
                ContractingAuthorities = SelectedAppointment.ContractingAuthorities,
                ReasonForAdmission = SelectedAppointment.ReasonForAdmission,
                CodeICD = SelectedAppointment.CodeICD,
                NFZContractNr = SelectedAppointment.NFZContractNr,
                IsActive = this.IsActive
            };
            var updateModel = mapper.Map<RegistrationModel, RegisteredAppointment>(model);

           await UpdateAppointmentAsync(SelectedAppointment.Id, updateModel);
        }

        public bool _isActive;
        public bool IsActive
        {
            get {return _isActive; }
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }
        public SolidColorBrush _color;
        public SolidColorBrush Color
        {
            get { return _color; } 
            set 
            { 
                _color = value; 
                OnPropertyChanged(nameof(Color));
            
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

       

        private ObservableCollection<RegistrationModel> _registeredAppointments;
        public ObservableCollection<RegistrationModel> RegisteredAppointments
        {
            get { return _registeredAppointments; }
            set
            {
                if(_registeredAppointments != value)
                {
                    _registeredAppointments = value;
                    OnPropertyChanged(nameof(RegisteredAppointments));
                }
            }
        }


        private RegistrationModel _selectedAppointment = null!;
        public RegistrationModel SelectedAppointment
        {
            get { return _selectedAppointment; }
            set
            {
                if (_selectedAppointment != value)
                {
                    _selectedAppointment = value;
                    OnPropertyChanged(nameof(SelectedAppointment));
                    OnPropertyChanged(nameof(IsButtonEnabled));
                }
            }
        }


        public bool IsButtonEnabled
        {
            get { return SelectedAppointment != null; }
            
        }

        public bool IsFormsButtonEnabled
        {
            get { return SelectedAppointment != null; }
        }

        public OpenAppointmentViewCommand OpenAppointmentViewCommand { get; set; }
        public OpenRegistrationViewCommand OpenRegistrationViewCommand { get; set; }

        public void OpenWindow()
        {
            AppointmentView window = new();
            window.Show();
            Messenger.Default.Send(new AppointmentSelectedMessage { PayersName = SelectedAppointment.PayerName, Pesel = SelectedAppointment.Pesel, Time = SelectedAppointment.Time, WorkList = SelectedAppointment.Worklist, Code = SelectedAppointment.CodeICD, PatientId = SelectedAppointment.PatientId, NFZ = SelectedAppointment.NFZContractNr});
            
        }

        public void OpenRegistrationWindow()
        {
            Registration window = new();
            window.Show();
            if(SelectedAppointment != null)
            {
                Messenger.Default.Send(new SelectedAppointmentToEdit
                {
                    PatientId = SelectedAppointment.PatientId,
                    PayerName = SelectedAppointment.PayerName,
                    Pesel = SelectedAppointment.Pesel,
                    WorkList = SelectedAppointment.Worklist,
                    Date = SelectedAppointment.Date,
                    Time = SelectedAppointment.Time,
                    Procedure = SelectedAppointment.Procedure,
                    Priority = SelectedAppointment.Priority,
                    ContractingAuthorities = SelectedAppointment.ContractingAuthorities,
                    DateOfIssue = SelectedAppointment.DateOfIssue,
                    ReasonForAdmission = SelectedAppointment.ReasonForAdmission,
                    CodeICD = SelectedAppointment.CodeICD,
                    NFZContractNr = SelectedAppointment.NFZContractNr
                });
            }
           
        }

        public async Task LoadAppointmentsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("api/registeredAppointment");
                response.EnsureSuccessStatusCode();

                var appointmentsFromApi = await response.Content.ReadAsAsync<List<RegisteredAppointment>>();

                var registrationModel = appointmentsFromApi.Select(r => new RegistrationModel
                {
                    Id = r.Id,
                    PatientId = r.PatientId,
                    PayerName = r.PayerName,
                    Pesel = r.Pesel,
                    Worklist = r.Worklist,
                    Date = (DateTime)r.Date,
                    Time = r.Time,
                    Procedure = r.Procedure,
                    Priority = r.Priority,
                    ContractingAuthorities = r.ContractingAuthorities,
                    DateOfIssue = ((DateTime)r.DateOfIssue).Date,
                    ReasonForAdmission = r.ReasonForAdmission,
                    CodeICD = r.CodeICD,
                    NFZContractNr = r.NFZContractNr,
                    IsActive =(bool) r.IsActive
                }).ToList();

                var filteredAppointments = registrationModel.Where(a => a.IsActive == true);

                RegisteredAppointments = new ObservableCollection<RegistrationModel>(filteredAppointments);


                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public async Task UpdateAppointmentAsync(int appId, RegisteredAppointment appointment)
        {
            try
            {
                var jsonAppointment = JsonConvert.SerializeObject(appointment);
                var content = new StringContent(jsonAppointment, Encoding.UTF8, "application/json");
                var apiUrl = $"https://localhost:7057/api/registeredAppointment/api/registeredAppointment/{appId}";
                HttpResponseMessage response = await httpClient.PutAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Updated");
                    await LoadAppointmentsAsync();
                }
                else
                {
                    MessageBox.Show("API call failed. Status code: " + response.StatusCode);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
            
            
        
    }
}
