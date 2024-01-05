using HMS_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    public class OpenFormsWindow : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public AppointmentViewModel _appointmentVM = null!;


        public OpenFormsWindow(AppointmentViewModel appointmentViewModel)
        {
            _appointmentVM= appointmentViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _appointmentVM.OpenFormWindow();
        }
    }
}
