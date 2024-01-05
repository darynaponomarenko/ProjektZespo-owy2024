using AutoMapper;
using GalaSoft.MvvmLight.Messaging;
using HMS_v1._0.ApiService;
using HMS_v1._0.Messages;
using HMS_v1._0.Models;
using Repository.Models;
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
                                                                        "Centrum Chirurgii Plastycznej", "CENTRUM MEDYCZNE BEMOWO" };

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

        private string _codeICD;
        public string CodeICD
        {
            get { return _codeICD; }
            set
            {
                _codeICD = value;
                OnPropertyChanged(nameof(CodeICD));
            }
        }

        private string _codeDescription;
        public string CodeDescription
        {
            get { return _codeDescription; }
            set
            {
                _codeDescription = value;
                OnPropertyChanged(nameof(CodeDescription));
            }
        }

        private string _doctor;
        public string Doctor
        {
            get { return _doctor; }
            set
            {
                _doctor = value;
                OnPropertyChanged(nameof(Doctor));
            }
        }

        
 

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

        private string _diagnosis;
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

        
        

    }
}
