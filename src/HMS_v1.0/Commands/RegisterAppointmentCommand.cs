using HMS_v1._0.ViewModels;
using System;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    public class RegisterAppointmentCommand : ICommand
    {
        readonly RegistrationViewModel _registrationViewModel = null!;
        public RegisterAppointmentCommand(RegistrationViewModel viewModel)
        {
            _registrationViewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged = null!;


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
