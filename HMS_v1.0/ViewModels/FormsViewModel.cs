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

            TypeOfForm = new ObservableCollection<string> {"skierowanie"};

            Messenger.Default.Register<SendDataToFormsMessage>(this, OnDataReceived);
        }

        private void OnDataReceived(SendDataToFormsMessage message)
        {
            PayersName = message.PayersName;
            Pesel = message.Pesel;
            CodeICD = message.CodeICD;
            CodeDescription = message.CodeDescription;
            Doctor = message.Doctor;
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
