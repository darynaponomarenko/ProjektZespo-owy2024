using HMS_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    public class LogUserCommand : ICommand
    {
        readonly LoginViewModel _loginViewModel = null!;

        public LogUserCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _loginViewModel.LogUser();
        }
    }
}
