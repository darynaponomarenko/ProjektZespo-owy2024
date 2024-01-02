using HMS_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    public class OpenSearchPatientCommand : ICommand
    {
        readonly RegistrationViewModel _registrationViewModel = null!;

        public OpenSearchPatientCommand(RegistrationViewModel registrationViewModel)
        {
            _registrationViewModel = registrationViewModel;
        }

        public event EventHandler? CanExecuteChanged = null!;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _registrationViewModel.OpenSearchWindow();
        }
    }
}
