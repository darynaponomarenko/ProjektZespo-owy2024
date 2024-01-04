using HMS_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    public class OpenAppointmentViewCommand : ICommand
    {
        readonly MainWindowViewModel _viewModel = null!;

        public OpenAppointmentViewCommand(MainWindowViewModel MainWindowViewModel)
        {
            _viewModel = MainWindowViewModel;
        }

        public event EventHandler? CanExecuteChanged = null;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.OpenWindow();
        }
    }
}
