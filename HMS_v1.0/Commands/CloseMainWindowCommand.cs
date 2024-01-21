using HMS_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HMS_v1._0.Commands
{
    public class CloseMainWindowCommand : ICommand
    {
        public MainWindowViewModel _viewModel = null!;
        public event EventHandler? CanExecuteChanged;

        public CloseMainWindowCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.CallCloseWindow();
        }
    }
}
