using HMS_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    public class OpenSearchCodeCommand : ICommand
    {
        readonly RegistrationViewModel _registrationViewModel;

        public OpenSearchCodeCommand(RegistrationViewModel registrationViewModel)
        {
            _registrationViewModel = registrationViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _registrationViewModel.OpenSearchCodeWindow();
        }
    }
}
