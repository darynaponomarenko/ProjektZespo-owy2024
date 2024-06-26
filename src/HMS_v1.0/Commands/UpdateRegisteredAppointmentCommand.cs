using HMS_v1._0.ViewModels;
using System;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    public class UpdateRegisteredAppointmentCommand : ICommand
    {
        readonly RegistrationViewModel _registrationViewModel = null!;
        public event EventHandler? CanExecuteChanged;

        public UpdateRegisteredAppointmentCommand(RegistrationViewModel registrationViewModel)
        {
            _registrationViewModel = registrationViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _registrationViewModel.UpdateAppointment();
        }
    }
}
