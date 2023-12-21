using HMS_v1._0.ViewModels;
using System;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    public class AddPatientCommand : ICommand
    {
        readonly NewPatientViewModel _newPatientViewModel;

        public AddPatientCommand(NewPatientViewModel viewModel)
        {
            _newPatientViewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public void Execute(object? parameter)
        {
            _newPatientViewModel.OnExecute();
        }
        
    }
}
