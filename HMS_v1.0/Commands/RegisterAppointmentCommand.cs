using HMS_v1._0.ViewModels;
using System;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    internal class RegisterAppointmentCommand : ICommand
    {
        RegistrationViewModel _registrationViewModel;
        public RegisterAppointmentCommand(RegistrationViewModel viewModel)
        {
            _registrationViewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _registrationViewModel.OnExecute();
        }
    }
}
