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
using System.Security.Cryptography.Pkcs;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace HMS_v1._0.ViewModels
{
    public class NewPatientViewModel : ViewModelBase
    {
        private readonly HttpClient httpClient;
        readonly IMapper mapper = MapperConfig.InitializeAutomapper();

        public NewPatientViewModel()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7057/")
            };

            Addresses = new ObservableCollection<Address>();

            CloseAction = null!;
            AddPatientCommand = new AddPatientCommand(this);
        }

        public ObservableCollection<Address> Addresses { get; set; }

        private string _name = null!;
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

        private int _patientId;
        public int PatientId
        {
            get { return _patientId; }
            set
            {
                if (_patientId != value)
                {
                    _patientId = value;
                    OnPropertyChanged(nameof(PatientId));
                }


            }
        }


        private string _middleName = null!;
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

        
        private string _surname = null!;
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

       
        private string _pesel = null!;
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

        
        private string _phoneNumber = null!;
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

        
        private string _email = null!;
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

        private string _address1;
        public string Address1
        {
            get { return _address1; }
            set
            {
                if(_address1 != value)
                {
                    _address1 = value;
                    OnPropertyChanged(nameof(Address1));
                }
            
            }
        }

        private string _address2;
        public string Address2
        {
            get { return _address2; }
            set
            {
                if (_address2 != value)
                {
                    _address2 = value;
                    OnPropertyChanged(nameof(Address2));
                }

            }
        }




        public AddPatientCommand AddPatientCommand { get; set; }
        public Action CloseAction { get; set; }

        public async void OnExecute()
        {
            if(Name != null && Surname != null && DateOfBirth != DateTime.Today && Pesel != null && PhoneNumber != null && Email != null && Address1 != null)
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
                    AddAddresses(Pesel);
                    //CloseAction();
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

        public async void AddAddresses(string pesel)
        {
            GetPatientId(pesel);
            string[] adrs1 = Address1.Split("");
            AddressModel newAddress1 = new()
            {
                PatientId = this.PatientId,
                Street = adrs1[0],
                ApartmentNr = adrs1[1],
                State = adrs1[2],
                City = adrs1[3],
                Country = adrs1[4]

            };

            AddressModel newAddress2 = new();
            if (Address2 != null)
            {
                string[] adrs2 = Address2.Split("");

                newAddress2 = new()
                {
                    PatientId = this.PatientId,
                    Street = adrs2[0],
                    ApartmentNr = adrs2[1],
                    State = adrs2[2],
                    City = adrs2[3],
                    Country = adrs2[4]
                };
            }

            var adrs1ToAdd = mapper.Map<AddressModel, Address>(newAddress1);
            var adr21ToAdd = mapper.Map<AddressModel, Address>(newAddress2);
        }

        public async void GetPatientId(string pesel)
        {
            try
            {
                var response = await httpClient.GetAsync("api/patient/{pesel}");
                response.EnsureSuccessStatusCode();

                PatientId = await response.Content.ReadAsAsync<int>();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting patient id: {ex.Message}");
            }
        }

    }
}
