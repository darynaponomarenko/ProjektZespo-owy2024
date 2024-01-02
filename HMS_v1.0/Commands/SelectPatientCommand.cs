using HMS_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    public class SelectPatientCommand : ICommand
    {
        readonly SearchPatientViewModel searchPatientViewModel = null!;

        public SelectPatientCommand(SearchPatientViewModel searchPatientViewModel)
        {
            this.searchPatientViewModel = searchPatientViewModel;
        }

        public event EventHandler? CanExecuteChanged = null!;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            searchPatientViewModel.SelectPatient();
        }
    }
}
