using HMS_v1._0.Commands;
using HMS_WebApi_v1._0.Services;
using Repository.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;

namespace HMS_v1._0.ViewModels
{
    public class NewPatientViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly IApiService<Patient> _genericApiService;
        Dictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();

        public NewPatientViewModel(IApiService<Patient> genericApiService)
        {
            _genericApiService = genericApiService;
        }
        public NewPatientViewModel()
        {
            AddPatientCommand = new AddPatientCommand(Submit, CanSubmit);
        }



        //beginning of data validation interface implementation
        public bool HasErrors => Errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (Errors.ContainsKey(propertyName))
            {
                return Errors[propertyName];
            }
            else
            {
                return Enumerable.Empty<string>();
            }
        }

        public void Validate(string propertyName, object propertyValue)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(propertyValue, new ValidationContext(this) { MemberName = propertyName }, results);

            if(results.Any())
            {
                Errors.Add(propertyName, results.Select(r => r.ErrorMessage).ToList());
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
            else
            {
                Errors.Remove(propertyName);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }

            AddPatientCommand.RaiseCanExecuteChanged();
        }
        //ending of data validation interface implementation

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

                Validate(nameof(Name), value);
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
                Validate(nameof(MiddleName), value);
            
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

                Validate(nameof(Surname), value);

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

                Validate(nameof(Pesel), value);

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

                Validate(nameof(PhoneNumber), value);

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

                Validate(nameof(Email), value);

            }
        }

        public AddPatientCommand AddPatientCommand { get; set; }
       
        private bool CanSubmit(object obj)
        {
            return Validator.TryValidateObject(this, new ValidationContext(this), null);
        }

        private void Submit(object obj)
        {
            MessageBox.Show("Dodano nowego pacjenta");
        }
    }
}
