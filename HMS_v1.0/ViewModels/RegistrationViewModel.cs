using HMS_v1._0.Commands;
using HMS_v1._0.models;
using HMS_v1._0.Views;
using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using HMS_v1._0.Messages;
using HMS_v1._0.Models;
using Repository.Models;
using AutoMapper;
using HMS_v1._0.ApiService;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.Text;

namespace HMS_v1._0.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly HttpClient httpClient;
        readonly IMapper mapper = MapperConfig.InitializeAutomapper();

        private ObservableCollection<string> _items = null!;
        private ObservableCollection<string> _payers = null!;
        private ObservableCollection<string> _contractingAuthorities = null!;
        private ObservableCollection<string> _admissionReasoning = null!;
        private ObservableCollection<string> _hours = null!;
        private ObservableCollection<string> _minutes = null!;

        private int _patientId;
        private string _priority = "KONTYNUACJA";
        private string _patientName = null!;
        private string _patientAge = null!;
        private string _pesel = null!;
        private string _procedure = "Wizyta poradnia dermatologiczna";
        private DateTime _time = DateTime.Now.Date; 
        private string _payerExtraNote = null!;
        private DateTime _dateOfIssue = DateTime.Now.Date;
        private string _reasonForAdmission = null!;
        private string _codeICD = null!;
        private string _codeICDName = null!;
        private string _nfzContractNr = null!;


        public RegistrationViewModel()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7057/")
            };

            Worklist = new ObservableCollection<string> { "Klaudiusz Sikora", "Robert Nowak", "Asia Szymczak", "Helena Sawicka" };
            Payers = new ObservableCollection<string> { "firma", "os. prywatna" };
            ContractingAuthorities = new ObservableCollection<string> { "\"ADAD\" Specjalistyczne Centrum Medyczne", "Adax-Med Centrum Alergii i Astmy",
                                                                        "Ambulatoryjna Opieka Specjalistyczna", "Carpe Diem Centrum Medycyny Estetycznej", 
                                                                        "Centrum Chirurgii Plastycznej", "CENTRUM MEDYCZNE BEMOWO" };
            AdmissionReasoning = new ObservableCollection<string> { "tryb nagły", "tryb planowy" };
            Hours = new ObservableCollection<string> { "7:", "8:", "9:", "10:", "11:","12", "13:", "14:", "15:" };
            Minutes = new ObservableCollection<string> { "00", "15", "30", "45" };


            Messenger.Default.Register<NewlyAddedPatientMessage>(this, OnPatientAdded);
            Messenger.Default.Register<ICD10sModel>(this, OnCodeSelected);

            RegisterAppointmentCommand = new RegisterAppointmentCommand(this);
            OpenAddNewPatientCommand = new OpenAddNewPatientCommand(this);
            OpenSearchPatientCommand = new OpenSearchPatientCommand(this);
            OpenSearchCodeCommand = new OpenSearchCodeCommand(this);
        }

        private void OnPatientAdded(NewlyAddedPatientMessage message)
        {
            
            PatientName = message.PatientName;
            PatientAge = message.PatientAge.ToString();
            Pesel = message.Pesel;
            PatientId =message.Id;

        }

        private void OnCodeSelected(ICD10sModel message)
        {
            CodeICDName = message.Description;
            CodeICD = message.Code;
        }

        #region
        //Properties for selected items from collections created above

        private string selectedItem;

        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private string selectedPayer;

        public string SelectedPayer
        {
            get { return selectedPayer; }
            set
            {
                if (selectedPayer != value)
                {
                    selectedPayer = value;
                    OnPropertyChanged(nameof(SelectedPayer));
                }
            }
        }

        private string selectedContractingAuthority;

        public string SelectedContractingAuthority
        {
            get { return selectedContractingAuthority; }
            set
            {
                if (selectedContractingAuthority != value)
                {
                    selectedContractingAuthority = value;
                    OnPropertyChanged(nameof(SelectedContractingAuthority));
                }
            }
        }

        private string selectedAdmissionReasoning;

        public string SelectedAdmissionReasoning
        {
            get { return selectedAdmissionReasoning; }
            set
            {
                if (selectedAdmissionReasoning != value)
                {
                    selectedAdmissionReasoning = value;
                    OnPropertyChanged(nameof(SelectedAdmissionReasoning));
                }
            }
        }

        private string selectedHours;

        public string SelectedHours
        {
            get { return selectedHours; }
            set
            {
                if (selectedHours != value)
                {
                    selectedHours = value;
                    OnPropertyChanged(nameof(SelectedHours));
                }
            }
        }

        private string selectedMinutes;

        public string SelectedMinutes
        {
            get { return selectedMinutes; }
            set
            {
                if (selectedMinutes != value)
                {
                    selectedMinutes = value;
                    OnPropertyChanged(nameof(SelectedMinutes));
                }
            }
        }

        #endregion

        public ObservableCollection<string> Worklist
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Worklist));
                }
            }
        }

        public ObservableCollection<string> Payers
        {
            get { return _payers; }
            set
            {
                if (_payers != value)
                {
                    _payers = value;
                    OnPropertyChanged(nameof(Payers));
                }
            }
        }

        public ObservableCollection<string> ContractingAuthorities
        {
            get { return _contractingAuthorities; }
            set
            {
                if (_contractingAuthorities != value)
                {
                    _contractingAuthorities = value;
                    OnPropertyChanged(nameof(ContractingAuthorities));
                }
            }
        }

        public ObservableCollection<string> AdmissionReasoning
        {
            get { return _admissionReasoning; }
            set
            {
                if (_admissionReasoning != value)
                {
                    _admissionReasoning = value;
                    OnPropertyChanged(nameof(AdmissionReasoning));
                }
            }
        }

        public ObservableCollection<string> Hours
        {
            get { return _hours; }
            set
            {
                if (_hours != value)
                {
                    _hours = value;
                    OnPropertyChanged(nameof(Hours));
                }
            }
        }

        public ObservableCollection<string> Minutes
        {
            get { return _minutes; }
            set
            {
                if (_minutes != value)
                {
                    _minutes = value;
                    OnPropertyChanged(nameof(Minutes));
                }
            }
        }

        public int PatientId
        {
            get
            {
                return _patientId;
            }
            set
            {
                if (_patientId != value)
                {
                    _patientId = value;
                    OnPropertyChanged("PatientId");
                    OnPropertyChanged(nameof(PatientId));
                }
            }
        }

        public string PatientName
        {
            get
            {
                return _patientName;
            }
            set
            {
                if (_patientName != value)
                {
                    _patientName = value;
                    OnPropertyChanged("PatientName");
                    OnPropertyChanged(nameof(PayerName));
                }
            }
        }

        
        public string PatientAge
        {
            get
            {
                return _patientAge;
            }
            set
            {
                if (_patientAge != value)
                {
                    _patientAge = value;
                    OnPropertyChanged("PatientAge");
                    OnPropertyChanged(nameof(AgeWithUnit));
                    OnPropertyChanged(nameof(PayerName));
                }
            }
        }

        public string AgeWithUnit
        {
            get { return $"{PatientAge} L."; }
        }



        
        public string Pesel
        {
            get
            {
                return _pesel;
            }
            set
            {
                if (_pesel != value)
                {
                    _pesel = value;
                    OnPropertyChanged("Pesel");
                    OnPropertyChanged(nameof(PayerName));
                }
            }
        }

        
        public string Procedure
        {
            get
            {
                return _procedure;
            }
            set
            {
                if (_procedure != value)
                {
                    _procedure = value;
                    OnPropertyChanged("Procedure");
                }
            }
        }

        
        public string Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged("Priority");
                }
            }
        }

       
        public DateTime Date
        {
            get { return _time; }
            set
            {
                if (_time != value)
                {
                    _time = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        public string PayerName
        { 
            get { return $"{PatientName}, {Pesel} ({PatientAge} L.)"; }
           
        }
       

        
        public string PayerExtraNote
        {
            get
            {
                return _payerExtraNote;
            }
            set
            {
                if (_payerExtraNote != value)
                {
                    _payerExtraNote = value;
                    OnPropertyChanged("PayerExtraNote");
                }
            }
        }

        
        public DateTime DateOfIssue
        {
            get { return _dateOfIssue; }
            set
            {
                if (_dateOfIssue != value)
                {
                    _dateOfIssue = value;
                    OnPropertyChanged(nameof(DateOfIssue));
                }
            }
        }

        
        public string ReasonForAdmission
        {
            get
            {
                return _reasonForAdmission;
            }
            set
            {
                if (_reasonForAdmission != value)
                {
                    _reasonForAdmission = value;
                    OnPropertyChanged("ReasonForAdmission");
                }
            }
        }

        
        public string CodeICD
        {
            get
            {
                return _codeICD;
            }
            set
            {
                if (_codeICD != value)
                {
                    _codeICD = value;
                    OnPropertyChanged("CodeICD");
                }
            }
        }

        
        public string CodeICDName
        {
            get
            {
                return _codeICDName;
            }
            set
            {
                if (_codeICDName != value)
                {
                    _codeICDName = value;
                    OnPropertyChanged("CodeICDName");
                }
            }
        }

        
        public string NFZContractNr
        {
            get
            {
                return _nfzContractNr;
            }
            set
            {
                if (_nfzContractNr != value)
                {
                    _nfzContractNr = value;
                    OnPropertyChanged("NFZContractNumber");
                }
            }
        }

        public RegisterAppointmentCommand RegisterAppointmentCommand { get; set; }
        public OpenAddNewPatientCommand OpenAddNewPatientCommand { get; set; }

        public OpenSearchPatientCommand OpenSearchPatientCommand { get; set; }
        
        public OpenSearchCodeCommand OpenSearchCodeCommand { get; set; }
       
   
        public void OpenWindow()
        {
            AddNewPatient addNewPatient = new();
            addNewPatient.Show();
        }

        public void OpenSearchWindow()
        {
            Search searchPatientWindow = new();
            searchPatientWindow.Show();
        }

        public void OpenSearchCodeWindow()
        {
            SearchCode searchCodeWindow = new();
            searchCodeWindow.Show();
        }

        public async void OnExecute()
        {
            string Time = SelectedHours + SelectedMinutes;
            RegistrationModel registration = new()
            {
                //PatientName =this.PatientName,
                //PatientAge = this.PatientAge,
                PatientId = this.PatientId,
                Pesel = this.Pesel,
                Procedure = this.Procedure,
                Priority = this.Priority,
                Worklist = this.SelectedItem,
                Date = this.Date,
                Time = Time,
                PayerName = this.PayerName,
                PayerExtraNote = this.PayerExtraNote,
                DateOfIssue = this.DateOfIssue,
                ContractingAuthorities = this.SelectedContractingAuthority,
                CodeICD = this.CodeICD,
                AdmissionReasoning = this.SelectedAdmissionReasoning,
                NFZContractNr = this.NFZContractNr
            };
            
            var registerAppointment = mapper.Map<RegistrationModel, RegisteredAppointment>(registration);
            await CallApiAsync(registerAppointment);
        }

        private async Task CallApiAsync(RegisteredAppointment appointment)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(appointment);
                var appointmentToAdd = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync("api/registeredAppointment", appointmentToAdd);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Dodano nową wizytę!");
                    //Messenger.Default.Send(new NewlyAddedPatientMessage { PatientName = Name, Pesel = Pesel, PatientAge = (int)((DateTime.Now - DateOfBirth).TotalDays / 365.242199) });
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
