using AutoMapper;
using HMS_v1._0.Commands;
using HMS_WebApi_v1._0.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using HMS_v1._0.Models;

namespace HMS_v1._0.ViewModels
{
    public class NewPatientViewModel : ViewModelBase
    {
        private readonly IApiService<Patient> _genericApiService;

        public NewPatientViewModel() { }
        public NewPatientViewModel(IApiService<Patient> genericApiService)
        {
            _genericApiService = genericApiService;
            AddPatientCommand = new AddPatientCommand(Submit, CanSubmit);
        }
       /* public NewPatientViewModel()
        {
            AddPatientCommand = new AddPatientCommand(Submit, CanSubmit);
        }
*/

        private string _name = null!;
        
        [Required(ErrorMessage ="Imię jest wymagane")]
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

        public AddPatientCommand AddPatientCommand { get;}
       
        private bool CanSubmit(object obj)
        {
            return true;
        }

        private void Submit(object obj)
        {
            if (_genericApiService != null)
            {
                var patient = App.Mapper.Map<Patient>(this);
                _genericApiService.Add(patient);
                MessageBox.Show("Dodano nowego pacjenta");
                InitializeNewActions();
            }
        }

        private void InitializeNewActions()
        {

        }
    }
}
