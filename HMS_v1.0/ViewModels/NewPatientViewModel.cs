using AutoMapper;
using HMS_v1._0.ApiService;
using HMS_v1._0.Commands;
using HMS_v1._0.Models;
using Newtonsoft.Json;
using Repository.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using HMS_v1._0.Messages;

namespace HMS_v1._0.ViewModels
{
    public class NewPatientViewModel : ViewModelBase
    {
        private readonly HttpClient httpClient;
        IMapper mapper = MapperConfig.InitializeAutomapper();

        public NewPatientViewModel()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7057/");
            
            AddPatientCommand = new AddPatientCommand(this);
        }

        private string _name = "Ana";
        public string Name
        {
            get { return _name; }
            set {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

       

        private string _middleName = "Maria";
        public string MiddleName
        {
            get { return _middleName; }
            set {
                if (_middleName != value)
                {
                    _middleName = value;
                    OnPropertyChanged(nameof(MiddleName));
                }
                
            
            }
        }

        
        private string _surname = "Hartvig";
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                }

            }
        }

        private DateTime _dateOfBirth = DateTime.Now.Date;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set {
                if (_dateOfBirth != value)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged(nameof(DateOfBirth));
                }
            }
        }

       
        private string _pesel = "72615928001";
        public string Pesel
        {
            get { return _pesel; }
            set
            {
                if (_pesel != value)
                {
                    _pesel = value;
                    OnPropertyChanged(nameof(Pesel));
                }
            }
        }

        
        private string _phoneNumber = "+48886313189";
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }

            }
        }

        
        private string _email = "anahartvig@gmail.com";
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }

            }
        }

        public AddPatientCommand AddPatientCommand { get; set; }
       
        public async void OnExecute()
        {
            if(Name != null && Surname != null && DateOfBirth != DateTime.Today && Pesel != null && PhoneNumber != null && Email != null)
            {
                PatientModel newPatient = new()
                { 
                    Name = this.Name,
                    MiddleName = this.MiddleName,
                    Surname = this.Surname,
                    DateOfBirth = this.DateOfBirth,
                    Email = this.Email,
                    PhoneNumber = this.PhoneNumber,
                    Pesel = this.Pesel
                };
                var patientToAdd = mapper.Map<PatientModel, Patient>(newPatient);
                await CallApiAsync(patientToAdd);
            }
            else
            {
                MessageBox.Show("Wszystkie pola wymagają uzupełnienia!");
            }
            
        }
         private async Task CallApiAsync(Patient patient)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(patient);
                var patientToAdd = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync("api/patient", patientToAdd);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Dodano nowego pacjenta!");
                    Messenger.Default.Send(new NewlyAddedPatientMessage { PatientName = Name, Pesel = Pesel, PatientAge = (int)((DateTime.Now - DateOfBirth).TotalDays / 365.242199) });
                }
                else
                {
                    MessageBox.Show("API call failed. Status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}
