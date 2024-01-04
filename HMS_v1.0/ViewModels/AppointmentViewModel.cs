using AutoMapper;
using GalaSoft.MvvmLight.Messaging;
using HMS_v1._0.ApiService;
using HMS_v1._0.Commands;
using HMS_v1._0.Messages;
using HMS_v1._0.models;
using HMS_v1._0.Models;
using HMS_v1._0.Views;
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

            
        }

        private void OnAppointmentAdded(AppointmentSelectedMessage registered)
        {
            PayersName = registered.PayersName;
            Time = registered.Time;
            Pesel = registered.Pesel;
            Worklist = registered.WorkList;
            CodeICD = registered.Code;
            
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

        private string _code;
        public string CodeICD
        {
            get { return _code; }
            set
            {
                if(_code != value)
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
                if(_status != value)
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

        private ObservableCollection<object> gridVM;
        public ObservableCollection<object> GridViewData 
        {
            get { return gridVM; }
            set
            {
                gridVM = value;
                //OnPropertyChanged(nameof(GridViewData));
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
                        var row = new { Var1 = CodeICD, Var2 = CodeDescription};
                        GridViewData.Add(row);
                        OnPropertyChanged(nameof(GridViewData));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
