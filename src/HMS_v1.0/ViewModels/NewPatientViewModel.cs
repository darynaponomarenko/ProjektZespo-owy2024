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

        //properties for address model fields

        private string _street = null!;
        public string Street
        {
            get { return _street; }
            set
            {
                if(_street != value)
                {
                    _street = value;
                    OnPropertyChanged(nameof(Street));
                }
            }
        }

        private string _apartmentNr = null!;
        public string ApartmentNr
        {
            get { return _apartmentNr; }
            set
            {
                if (_apartmentNr != value)
                {
                    _apartmentNr = value;
                    OnPropertyChanged(nameof(ApartmentNr));
                }
            }
        }

        private string _country = null!;
        public string Country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }

        private string _city = null!;
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }


        private string _state = null!;
        public string State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }

        private string _zipcode = null!;
        public string Zipcode
        {
            get { return _zipcode; }
            set
            {
                if (_zipcode != value)
                {
                    _zipcode = value;
                    OnPropertyChanged(nameof(Zipcode));
                }
            }
        }




        public AddPatientCommand AddPatientCommand { get; set; }
        public Action CloseAction { get; set; }

        public async void OnExecute()
        {
            if(Name != null && Surname != null && DateOfBirth != DateTime.Today && Pesel != null && PhoneNumber != null && Email != null && Street != null && City != null && ApartmentNr != null && Country != null && Zipcode != null)
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
                await AddAddresses(Pesel);



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
                   // MessageBox.Show("Dodano nowego pacjenta!");
                    Messenger.Default.Send(new NewlyAddedPatientMessage { PatientName = Name, Pesel = Pesel, PatientAge = (DateTime.Now.Year - DateOfBirth.Year)});
                    
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

        public async Task AddAddresses(string pesel)
        {
            try
            {
                var apiUrl = $"https://localhost:7057/api/patient/api/patient/{pesel}";
                var response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                PatientId = await response.Content.ReadAsAsync<int>();


                if (Street != null && ApartmentNr != null && Country != null && City != null && Zipcode != null)
                {
                    AddressModel newAddress = new()
                    {
                        PatientId = this.PatientId,
                        Street = this.Street,
                        ApartmentNr = this.ApartmentNr,
                        Country = this.Country,
                        City = this.City,
                        State = this.State,
                        Zipcode = this.Zipcode
                    };
                    var addressToAdd = mapper.Map<AddressModel, Address>(newAddress);
                    await CallAddressPostAsync(addressToAdd);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting patient id: {ex.Message}");
            }




        }

        private async Task CallAddressPostAsync(Address address)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(address);
                var addressToAdd = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync("api/address", addressToAdd);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Dodano nowego pacjenta!");
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
