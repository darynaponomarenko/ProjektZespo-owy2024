using AutoMapper;
using GalaSoft.MvvmLight.Messaging;
using HMS_v1._0.ApiService;
using HMS_v1._0.Commands;
using HMS_v1._0.Messages;
using HMS_v1._0.models;
using HMS_v1._0.Models;
using HMS_v1._0.Views;
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

namespace HMS_v1._0.ViewModels
{
    public class AppointmentViewModel : ViewModelBase
    {
        private readonly HttpClient httpClient;
        readonly IMapper mapper = MapperConfig.InitializeAutomapper();

        private ObservableCollection<string> _status = null!;
        private ObservableCollection<string> _treatmentMethods = null!;

        public AppointmentViewModel()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7057/")
            };

            Status = new ObservableCollection<string> { "Odwołana", "Potwierdzona", "Zakończona" };
            TreatmentMethods = new ObservableCollection<string> { "Badania kontrolne", "Konsultacja specjalistyczna", "Procedura medyczna", "Dostosowanie leków" };

            Messenger.Default.Register<AppointmentSelectedMessage>(this, OnAppointmentAdded);

            SaveAppointmentCommand = new SaveAppointment(this);
            CloseActionCommand = new CloseActionCommand(this);
            OpenFormsWindow = new OpenFormsWindow(this);
            CloseAction = null!;
        }

        public Action CloseAction { get; set; }
        public SaveAppointment SaveAppointmentCommand { get; set; }
        public CloseActionCommand CloseActionCommand { get; set; }

        public OpenFormsWindow OpenFormsWindow { get; set; }

        private void OnAppointmentAdded(AppointmentSelectedMessage registered)
        {
            PayersName = registered.PayersName;
            Time = registered.Time;
            Pesel = registered.Pesel;
            Worklist = registered.WorkList;
            CodeICD = registered.Code;
            PatientId = registered.PatientId;
            NFZ = registered.NFZ;
        }
        #region
        //Selections
        private string _statusSelected;
        public string StatusSelected
        {
            get { return _statusSelected; }
            set
            {
                _statusSelected = value;
                OnPropertyChanged(nameof(StatusSelected));
            }
        }

        private string selectedDoctor = null!;
        public string SelectedDoctor
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

        private string _treatmentContinuationMethod;
        public string TreatmentContinuationMethod
        {
            get { return _treatmentContinuationMethod; }
            set
            {
                _treatmentContinuationMethod = value;
                OnPropertyChanged(nameof(TreatmentContinuationMethod));
            }
        }
        #endregion

        private string _nfz;
        public string NFZ
        {
            get { return _nfz; }
            set
            {
                _nfz = value;
                OnPropertyChanged(nameof(NFZ));
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
        private string _code;
        public string CodeICD
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged(nameof(CodeICD));
                }
            }
        }

        private string _codeDescription;
        public string CodeDescription
        {
            get { return _codeDescription; }
            set
            {
                if (_codeDescription != value)
                {
                    _codeDescription = value;
                    OnPropertyChanged(nameof(CodeDescription));
                }
            }
        }

        public ObservableCollection<string> Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public ObservableCollection<string> TreatmentMethods
        {
            get { return _treatmentMethods; }
            set
            {
                if (_treatmentMethods != value)
                {
                    _treatmentMethods = value;
                    OnPropertyChanged(nameof(TreatmentMethods));
                }
            }
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

        private string _pesel = null!;
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

        private ObservableCollection<PatientModel> _patients;
        public ObservableCollection<PatientModel> Patients
        {
            get { return _patients; }
            set
            {
                if (_patients != null)
                {
                    _patients = value;
                    OnPropertyChanged(nameof(Patients));
                }
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


        private ObservableCollection<string> surnames;

        public ObservableCollection<string> DoctorSurnames
        {
            get { return surnames; }
            set
            {
                if (surnames != value)
                {
                    surnames = value;
                    OnPropertyChanged(nameof(DoctorSurnames));
                }
            }
        }


        private string _interview;
        public string Interview
        {
            get { return _interview; }
            set
            {
                _interview = value;
                OnPropertyChanged(nameof(Interview));
            }
        }

        private string _inspection;
        public string Inspection
        {
            get { return _inspection; }
            set
            {
                _inspection = value;
                OnPropertyChanged(nameof(Inspection));
            }
        }

        private string _diagnosis;
        public string Diagnosis
        {
            get { return _diagnosis; }
            set
            {
                _diagnosis = value;
                OnPropertyChanged(nameof(Diagnosis));
            }
        }

        private string _treatmentHistory;
        public string TreatmentHistory
        {
            get { return _treatmentHistory; }
            set
            {
                _treatmentHistory = value;
                OnPropertyChanged(nameof(TreatmentHistory));
            }
        }

        private string _recommendations;
        public string Recommendations
        {
            get { return _recommendations; }
            set
            {
                _recommendations = value;
                OnPropertyChanged(nameof(Recommendations));
            }
        }

        private string _npwz;
        public string NPWZ
        {
            get { return _npwz; }
            set
            {
                _npwz = value;
                OnPropertyChanged(nameof(NPWZ));
            }
        }

        private bool _isButtonEnabled;

        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                if (_isButtonEnabled != value)
                {
                    _isButtonEnabled = value;
                    OnPropertyChanged(nameof(IsButtonEnabled));
                }
            }
        }


        private ObservableCollection<ICD10sModel> _codes;
        public ObservableCollection<ICD10sModel> Codes 
        {
            get { return _codes; }
            set
            {
                _codes = value;
                OnPropertyChanged(nameof(Codes));
            }
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
                    Id = d.Id
                }).ToList();
               
                Doctors = new ObservableCollection<DoctorModel>(doctorModel);
                DoctorSurnames = new ObservableCollection<string>(Doctors.Select(doctor => doctor.Surname));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public async void SearchForCodeDescription()
        {
            try
            {
                var response = await httpClient.GetAsync("api/codes");
                response.EnsureSuccessStatusCode();

                var codesFromApi = await response.Content.ReadAsAsync<List<ICD10>>();
                var icd10Codes = mapper.Map<List<ICD10sModel>>(codesFromApi);
                Codes = new ObservableCollection<ICD10sModel>(icd10Codes);
            
                if(CodeICD != null)
                {
                    var matchingCode = Codes.FirstOrDefault(code => code.Code == CodeICD);
                    
                    if(matchingCode != null)
                    {
                        CodeDescription = matchingCode.Description;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public async void GetSelectedDoctorID()
        {
            DoctorModel selectedDoctor = Doctors.FirstOrDefault(doctor => doctor.Surname == SelectedDoctor);

            if (selectedDoctor != null)
            {
                DoctorId = selectedDoctor.Id;
                NPWZ = selectedDoctor.NPWZ;
                OnPropertyChanged(nameof(DoctorId));
                OnPropertyChanged(nameof(NPWZ));
            }
        }


        //method that is executed when button "Zapisz" is pressed
        public async void OnAppointmentSaved()
        {
            GetSelectedDoctorID();
            AppointmentModel appointment = new()
                {
                    PatientId = this.PatientId,
                    DoctorID = this.DoctorId,
                    Date = DateTime.Now.Date,
                    Time = this.Time,
                    Status = this.StatusSelected,
                    Interview = this.Interview,
                    Inspection = this.Inspection,
                    Diagnosis = this.Diagnosis,
                    TreatmentHistory = this.TreatmentHistory,
                    Recommendations = this.Recommendations,
                    TreatmentContinuationMethod = this.TreatmentContinuationMethod,
                    ICD10 = CodeICD
            };
                var saveAppointment = mapper.Map<AppointmentModel, Appointment>(appointment);
                await CallApiAsync(saveAppointment, appointment);
            

           

        }

        private async Task CallApiAsync(Appointment appointment, AppointmentModel model )
        {
            string jsonData = JsonConvert.SerializeObject(appointment);
            var appointmentToAdd = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("api/appointment", appointmentToAdd);
            if(response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Zapisano dane wizyty!");
                IsButtonEnabled = true;
                SendMessage();
            }
            else
            {
                MessageBox.Show("API call failed. Status code: " + response.StatusCode);
            }
        }

        public void CallCloseWindow()
        {
            CloseAction();
        }

        public void OpenFormWindow()
        {
           
            Forms window = new();
            window.Show();
            SendMessage();
            
        }

        public async void SendMessage()
        {
            string doctor = selectedDoctor;
            string payersname = PayersName;
            string pesel = Pesel;
            string code = CodeICD;
            string description = CodeDescription;
            string nfz = NFZ;
            string npwz = NPWZ;

            Messenger.Default.Send(new SendDataToFormsMessage { Doctor = doctor, PayersName = payersname, Pesel = pesel, CodeICD = code, CodeDescription = description, NFZ = nfz, NPWZ = npwz });

        }

    }
    
}
