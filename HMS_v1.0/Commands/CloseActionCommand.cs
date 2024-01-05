using HMS_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    public class CloseActionCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public AppointmentViewModel _appointmentVM = null!;

        public CloseActionCommand(AppointmentViewModel appointmentVM)
        {
            _appointmentVM = appointmentVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _appointmentVM.CallCloseWindow();
        }
    }
}
