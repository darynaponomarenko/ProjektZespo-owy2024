using HMS_v1._0.Commands;
using HMS_v1._0.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace HMS_v1._0.ViewModels
{
    class RegistrationViewModel : ViewModelBase
    {
        private ObservableCollection<string> _items;
        private ObservableCollection<string> _payers;
        private ObservableCollection<string> _contractingAuthorities;
        private ObservableCollection<string> _admissionReasoning;

       
        public RegistrationViewModel()
        {
            Items = new ObservableCollection<string> { "Klaudiusz Sikora", "Robert Nowak", "Asia Szymczak", "Helena Sawicka" };
            Payers = new ObservableCollection<string> { "firma", "os. prywatna" };
            ContractingAuthorities = new ObservableCollection<string> { "\"ADAD\" Specjalistyczne Centrum Medyczne", "Adax-Med Centrum Alergii i Astmy", "Ambulatoryjna Opieka Specjalistyczna", "Carpe Diem Centrum Medycyny Estetycznej", "Centrum Chirurgii Plastycznej", "CENTRUM MEDYCZNE BEMOWO" };
            AdmissionReasoning = new ObservableCollection<string> { "tryb nagły", "tryb planowy" };

            RegisterAppointmentCommand = new RegisterAppointmentCommand(this);
            OpenAddNewPatientCommand = new OpenAddNewPatientCommand(this);
        }

        public ObservableCollection<string> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Items));
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

        private string _patientName = null!;
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
                    OnPropertyChanged("PatientsName");
                }
            }
        }

        private string _patientAge = null!;
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
                    OnPropertyChanged("PatientsAge");
                }
            }
        }

        private string _pesel = null!;
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
                    OnPropertyChanged("PESEL");
                }
            }
        }

        private string _procedure = null!;
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

        private string _priority = null!;
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

        private DateTime _time = DateTime.Now;

        private string _payerName = null!;
        public string PayerName
        {
            get
            {
                return _payerName;
            }
            set
            {
                if (_payerName != value)
                {
                    _payerName = value;
                    OnPropertyChanged("PayerName");
                }
            }
        }

        private string _payerExtraNote = null!;
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

        private DateTime _dateOfIssue = DateTime.Today;

        private string _codeICD = null!;
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

        private string _codeICDName = null!;
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

        private string _nfzContractNr = null!;
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

        public void OpenWindow()
        {
            AddNewPatient addNewPatient = new AddNewPatient();
            addNewPatient.ShowDialog();
        }

        public void OnExecute()
        {
            
        }

    }
}
