using AutoMapper;
using HMS_v1._0.ApiService;
using HMS_v1._0.Commands;
using System;
using System.Net.Http;
using System.Windows;
using System.Security.Cryptography;
using HMS_v1._0.Models;
using Repository.Models;
using System.Threading.Tasks;
using Azure;
using Newtonsoft.Json;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using HMS_v1._0.Views;

namespace HMS_v1._0.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly HttpClient httpClient;
        readonly IMapper mapper = MapperConfig.InitializeAutomapper();

        public LoginViewModel()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7057/")
            };

            AddNewUserLogin = new AddNewUserLogin(this);
            LogUserCommand = new LogUserCommand(this);
           
        }

        private string _workersNr = null!;
        public string WorkersNr
        {
            get { return _workersNr; }
            set
            {
                if (_workersNr != value)
                {
                    _workersNr = value;
                    OnPropertyChanged(nameof(WorkersNr));
                }
            }
        }

        private string _password = null!;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
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

        private ObservableCollection<LoginService> _logData;

        public ObservableCollection<LoginService> LogData
        {
            get { return _logData; }
            set
            {
                if (_logData != value)
                {
                    _logData = value;
                    OnPropertyChanged(nameof(LogData));
                }
            }
        }

        private int _doctorId;
        public int DoctorId
        {
            get { return _doctorId; }
            set
            {
                if (_doctorId != value)
                {
                    _doctorId = value;
                    OnPropertyChanged(nameof(DoctorId));
                }
            }
        }

        private bool _passIsEqual;
        public bool PassIsEqual
        {
            get { return _passIsEqual; }
            set
            {
                _passIsEqual = value;
                OnPropertyChanged(nameof(PassIsEqual));
            }
        }


        public AddNewUserLogin AddNewUserLogin { get; set; }
        public LogUserCommand LogUserCommand { get; set; }

        public async void AddNewUserLoginData()
        {
            if(string.IsNullOrEmpty(WorkersNr) && string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Podaj swój numer pracowniczy oraz hasło!");
            }
            
            if(!string.IsNullOrEmpty(WorkersNr) && !string.IsNullOrEmpty(Password))
            {

                await LoadLoginData();

                LoginService log = LogData.FirstOrDefault(l => l.WorkersId == WorkersNr);
                if(log != null)
                {
                    MessageBox.Show("Użytkownik o podanym numerze pracowniczym już istnieje!");
                    WorkersNr = string.Empty;
                    Password = string.Empty;
                }
                else
                {
                    await LoadDoctorsAsync();

                    DoctorModel doctorLogin = Doctors.FirstOrDefault(doctor => doctor.NPWZ == WorkersNr);
                    if (doctorLogin != null)
                    {
                        DoctorId = doctorLogin.Id;
                    }
                    else
                    {
                        MessageBox.Show("Pracowik z podanym numerem pracowniczym nie został odnaleziony.");
                        WorkersNr = string.Empty;
                        Password = string.Empty;
                    }

                    await HashPassword(Password);

                    LoginService login = new()
                    {
                        WorkersId = WorkersNr,
                        Password = Password,
                        DoctorId = DoctorId,
                        //Doctor = doctorLogin,
                    };

                    var newLoginDataSet = mapper.Map<LoginService, LoginData>(login);
                    await CallApiAsyncPostLoginData(newLoginDataSet);
                }

                

            }
            else
            {
                MessageBox.Show("Wszystkie pola wymagają uzupełnienia!");
            }


        }


        public async void LogUser()
        {
            if(!string.IsNullOrEmpty(WorkersNr) && !string.IsNullOrEmpty(Password))
            {
                await LoadLoginData();
                LoginService log = LogData.FirstOrDefault(l => l.WorkersId == WorkersNr);
                if (log != null)
                {
                    await ArePasswordsEqual(Password, log.Password);

                    if(PassIsEqual == true)
                    {
                        WorkersNr = string.Empty;
                        Password = string.Empty;
                        MainWindow window = new MainWindow();
                        window.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wpisane dane są błędne, spróbuj ponownie!");
                    }
                }
                else
                {
                    MessageBox.Show("Użytkownik o podanym numerze pracowniczym nie istnieje, należy wybrać opcję <<Pierwsze logowanie>>");
                }
                
            }
            

        }


        private async Task CallApiAsyncPostLoginData(LoginData loginData)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(loginData);
                var loginDataToAdd = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync("api/login", loginDataToAdd);
                if(response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Login i hasło zostały zapisane pomyślnie!");
                    WorkersNr = string.Empty;
                    Password = string.Empty;
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

        public async Task LoadDoctorsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("api/doctors");
                response.EnsureSuccessStatusCode();

                var doctorsFromApi = await response.Content.ReadAsAsync<List<Doctor>>();
                var doctorModel = doctorsFromApi.Select(d => new DoctorModel
                {
                    DoctorId = d.Id,
                    Name = d.Name,
                    MiddleName = d.MiddleName,
                    Surname = d.Surname,
                    Email = d.Email,
                    PhoneNumber = d.PhoneNumber,
                    Pesel = d.PhoneNumber,
                    DateOfBirth = d.DateOfBirth,
                    NPWZ = d.NPWZ,
                    Id = d.Id
                }).ToList();

                Doctors = new ObservableCollection<DoctorModel>(doctorModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public async Task LoadLoginData()
        {
            try
            {
                var response = await httpClient.GetAsync("api/login");
                response.EnsureSuccessStatusCode();

                var dataFromApi = await response.Content.ReadAsAsync<List<LoginData>>();
                var loginData = dataFromApi.Select(d => new LoginService
                {
                    Password = d.Password,
                    WorkersId = d.WorkersId
                }).ToList();

                LogData = new ObservableCollection<LoginService>(loginData);

            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private async Task HashPassword(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 16, 10000))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] key = deriveBytes.GetBytes(32); 

                
                byte[] hash = new byte[salt.Length + key.Length];
                Buffer.BlockCopy(salt, 0, hash, 0, salt.Length);
                Buffer.BlockCopy(key, 0, hash, salt.Length, key.Length);

                Password = Convert.ToBase64String(hash);
            }
        }

        public async Task ArePasswordsEqual(string password, string hashedPassword)
        {
            byte[] storedHashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[16];
            Buffer.BlockCopy(storedHashBytes, 0, salt, 0, salt.Length);
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000)) 
            {
                byte[] newHashBytes = deriveBytes.GetBytes(storedHashBytes.Length - salt.Length);

                
                bool hashesAreEqual = true;
                for (int i = 0; i < newHashBytes.Length; i++)
                {
                    if (newHashBytes[i] != storedHashBytes[salt.Length + i])
                    {
                        hashesAreEqual = false;
                        break;
                    }
                }

                PassIsEqual = true;
                //return hashesAreEqual;
            }
        }
    }
}
