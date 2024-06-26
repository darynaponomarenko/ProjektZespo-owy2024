using AutoMapper;
using GalaSoft.MvvmLight.Messaging;
using HMS_v1._0.ApiService;
using HMS_v1._0.Commands;
using HMS_v1._0.Messages;
using HMS_v1._0.Models;
using HMS_v1._0.Views;
using Newtonsoft.Json;
using Repository.Models;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HMS_v1._0.ViewModels
{
    public class FormsViewModel : ViewModelBase
    {
        private readonly HttpClient httpClient;
        readonly IMapper mapper = MapperConfig.InitializeAutomapper();

        private ObservableCollection<string> _typeOfForm = null!;
    
        public FormsViewModel() 
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7057/")
            };

            

            Messenger.Default.Register<SendDataToFormsMessage>(this, OnDataReceived);

            ComboBoxItems = new ObservableCollection<string>();
            TypeOfForm = new ObservableCollection<string> { "skierowanie" };
            ComboBoxDoctor = new ObservableCollection<string>();
            ContractingAuthorities = new ObservableCollection<string> { "\"ADAD\" Specjalistyczne Centrum Medyczne", "Adax-Med Centrum Alergii i Astmy",
                                                                        "Ambulatoryjna Opieka Specjalistyczna", "Carpe Diem Centrum Medycyny Estetycznej",
                                                                        "Centrum Chirurgii Plastycznej", "CENTRUM MEDYCZNE BEMOWO" 
            };

            OpenCodesFromFormsViewCommand = new OpenCodesFromFormsViewCommand(this);
            SaveReportCommand = new SaveReportCommand(this);

            Messenger.Default.Register<ICD10sModel>(this, OnCodeSelected);
            Messenger.Default.Register<LoggedWorkerMessage>(this, OnLoggedWorker);
        }

        private void OnCodeSelected(ICD10sModel message)
        {
            CodeDescription = message.Description;
            CodeICD  = message.Code;
        }

        private void OnLoggedWorker(LoggedWorkerMessage loggedWorkerMessage)
        {
            LoggedWorker = loggedWorkerMessage.WorkersId;
            OnPropertyChanged(nameof(LoggedWorker));
        }

        public void ShowLoggedWorker()
        {
            OnPropertyChanged(nameof(LoggedWorker));
        }

        private ObservableCollection<FormsData> _data;
        public ObservableCollection<FormsData> Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
        public void InitializeGridView()
        {
            Data = new ObservableCollection<FormsData>
            {
                new FormsData {Variable1 = DateTime.Now.ToString(), Variable2 =Doctor+", "+ NPWZ}
            };
        }


        private void OnDataReceived(SendDataToFormsMessage message)
        {
            PayersName = message.PayersName;
            Pesel = message.Pesel;
            CodeICD = message.CodeICD;
            CodeDescription = message.CodeDescription;
            Doctor = message.Doctor;
            NFZ = message.NFZ;
            NPWZ = message.NPWZ;
            InitializeItems();
            InitializeDoctor();
            InitializeGridView();
        }

        public void InitializeItems()
        {
            ComboBoxItems.Add("brak");
            ComboBoxItems.Add(NFZ);
        }

        public void InitializeDoctor()
        {
            string add = Doctor + ", " + NPWZ;
            ComboBoxDoctor.Add(add);
        }

        private ObservableCollection<string> _contractingAuthorities = null!;
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

        private string _selectedItem = null!;
        public string SelectedItem 
        {
            get { return _selectedItem; }
            set
            {
                if(_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
                
        }

        private string _loggedWorker = "6850524";
        public string LoggedWorker
        {
            get { return _loggedWorker; }
            set
            {
                if (_loggedWorker != value)
                {
                    _loggedWorker = value;
                    OnPropertyChanged(nameof(LoggedWorker));
                }
            }

        }

        private string _contractNr = null!;
        public string ContractNr
        {
            get { return _contractNr; }
            set
            {
                if (_contractNr != value)
                {
                    _contractNr = value;
                    OnPropertyChanged(nameof(ContractNr));
                }
            }

        }

        private string _selectedDoctor = null!;
        public string SelectedDoctor
        {
            get { return _selectedDoctor; }
            set
            {
                if (_selectedDoctor != value)
                {
                    _selectedDoctor = value;
                    OnPropertyChanged(nameof(SelectedDoctor));
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

        private ObservableCollection<string> _comboBoxItems;
        public ObservableCollection<string> ComboBoxItems
        {
            get => _comboBoxItems;
            set
            {
                if (_comboBoxItems != value)
                {
                    _comboBoxItems = value;
                    OnPropertyChanged(nameof(ComboBoxItems));
                }
            }
        }

        private ObservableCollection<string> _comboBoxDoctor;
        public ObservableCollection<string> ComboBoxDoctor
        {
            get => _comboBoxDoctor;
            set
            {
                if (_comboBoxDoctor != value)
                {
                    _comboBoxDoctor = value;
                    OnPropertyChanged(nameof(ComboBoxDoctor));
                }
            }
        }

        private bool _choice1RB;
        private bool _choice2RB;

        public bool IsOption1Selected
        {
            get { return _choice1RB; }
            set
            {
                if (_choice1RB != value)
                {
                    _choice1RB = value;
                    OnPropertyChanged(nameof(IsOption1Selected));
                }
            }
        }

        public bool IsOption2Selected
        {
            get { return _choice2RB; }
            set
            {
                if (_choice2RB != value)
                {
                    _choice2RB = value;
                    OnPropertyChanged(nameof(IsOption2Selected));
                }
            }
        }

        private DateTime _date = DateTime.Now.Date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public ObservableCollection<string> TypeOfForm
        {
            get { return _typeOfForm; }
            set
            {
                if (_typeOfForm != value)
                {
                    _typeOfForm = value;
                    OnPropertyChanged(nameof(TypeOfForm));
                }
            }
        }

        private string _payersName = null!;
        public string PayersName
        {
            get { return _payersName; }
            set
            {
                _payersName = value;
                OnPropertyChanged(nameof(PayersName));
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

        private string _codeICD = null!;
        public string CodeICD
        {
            get { return _codeICD; }
            set
            {
                _codeICD = value;
                OnPropertyChanged(nameof(CodeICD));
            }
        }

        private string _codeDescription = null!;
        public string CodeDescription
        {
            get { return _codeDescription; }
            set
            {
                _codeDescription = value;
                OnPropertyChanged(nameof(CodeDescription));
            }
        }

        private string _doctor = null!;
        public string Doctor
        {
            get { return _doctor; }
            set
            {
                _doctor = value;
                OnPropertyChanged(nameof(Doctor));
            }
        }

        
 

        private string _nfz = null!;
        public string NFZ 
        {
            get { return _nfz; }
            set
            {
                _nfz = value;
                OnPropertyChanged(nameof(NFZ));
            }
                
        }

        private string _npwz = null!;
        public string NPWZ
        {
            get { return _npwz; }
            set
            {
                _npwz = value;
                OnPropertyChanged(nameof(NPWZ));
            }
        }

        private string _diagnosis = null!;
        public string Diagnosis
        {
            get { return _diagnosis; }
            set
            {
                _diagnosis= value;
                OnPropertyChanged(nameof(Diagnosis));
            }
        }

        private string _purposeOfAdvice;
        public string PurposeOfAdvice
        {
            get { return _purposeOfAdvice; }
            set
            {
                _purposeOfAdvice = value;
                OnPropertyChanged(nameof(PurposeOfAdvice));
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

        public OpenCodesFromFormsViewCommand OpenCodesFromFormsViewCommand { get; set; }
        public SaveReportCommand SaveReportCommand { get; set; }

        public void OpenSearchCodeWindow()
        {
            SearchCode searchCodeWindow = new();
            searchCodeWindow.Show();
        }

        public async Task Skierowanie()
        {
            var reports = new StiReport();
            reports.Load(@"D:\Report.mrt");

            
            string name = PayersName.Split(',')[0];

            Report report = new()
            {
                PayersName = name,
                Pesel = this.Pesel,
                Diagnosis = this.Diagnosis,
                CodeICD = this.CodeICD,
                CodeDescription = this.CodeDescription,
                DoctorsData = this.SelectedDoctor
            };
            reports.RegBusinessObject("report_data", report);
            //reports.DesignV2WithWpf();
            reports.Show();
        }

        public void OnExecute()
        {
            string typeOfRefferal;
            if (IsOption1Selected == true)
            {
                typeOfRefferal = "option1";
            }
            else if (IsOption2Selected == true)
            {
                typeOfRefferal = "option2";
            }
            else
            {
                typeOfRefferal = null;
            }


            Report report = new()
            {
                PayersName = this.PayersName,
                Pesel = this.Pesel,
                TypeOfForm = this.SelectedItem,
                ContractNr = this.ContractNr,
                ContractingAuthority = this.SelectedContractingAuthority,
                TypeOfRefferal = typeOfRefferal,
                Diagnosis = this.Diagnosis,
                CodeICD = this.CodeICD,
                CodeDescription = this.CodeDescription,
                PurposeOfAdvice = this.PurposeOfAdvice,
                TreatmentHistory = this.TreatmentHistory,
                DoctorsData = this.SelectedDoctor
            };
            var saveReport = mapper.Map<Report, ReportEntityModel>(report);
            CallApiAsync(saveReport, report);
        }

        private async Task CallApiAsync(ReportEntityModel saveReport, Report report)
        {
            string jsonData = JsonConvert.SerializeObject(saveReport);
            var reportToAdd = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("api/reports", reportToAdd);
            if(response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Zapisano dane skierowania!");
                Skierowanie();
            }
            else
            {
                MessageBox.Show("API call failed. Status code: " + response.StatusCode);
            }
        }
        
        

    }
}
