using AutoMapper;
using HMS_v1._0.Commands;
using HMS_v1._0.Models;
using HMS_WebApi_v1._0.Services;
using Repository.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace HMS_v1._0.ViewModels
{
    public class NewPatientViewModel : ViewModelBase
    {
        private readonly IApiService<Patient> _genericApiService;
        private readonly IMapper _mapper;

        public NewPatientViewModel() {

            AddPatientCommand = new AddPatientCommand(this);
        }
        public NewPatientViewModel(IApiService<Patient> genericApiService, IMapper mapper)
        {
            _genericApiService = genericApiService;
            _mapper = mapper;
        }
      

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
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
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
        [Required(ErrorMessage = "Pesel jest wymagany")]
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
        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
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
        [Required(ErrorMessage = "Email jest wymagany")]
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

        public AddPatientCommand AddPatientCommand { get; set; }
       
        public void OnExecute()
        {
            if(Name != null && Surname != null && DateOfBirth != DateTime.Today && Pesel != null && PhoneNumber != null && Email != null)
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

                var patientToAdd = _mapper.Map<Patient>(newPatient);
                _genericApiService.Add(patientToAdd);
                MessageBox.Show("Dodano nowego pacjenta!");
            }
            else
            {
                MessageBox.Show("Wszystkie pola wymagają uzupełnienia!");
            }
            
        }
    }
}
