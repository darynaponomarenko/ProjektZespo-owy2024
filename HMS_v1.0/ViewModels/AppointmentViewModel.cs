using HMS_v1._0.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.ViewModels
{
    public class AppointmentViewModel : ViewModelBase
    {

        readonly IView _view;

        public AppointmentViewModel(IView view)
        {
            _view = view;
        }

        private DelegateCommand _showWindow = null!;
        public DelegateCommand ShowWindow =>
        _showWindow ??= new DelegateCommand(ShowWindowCmd);

        void ShowWindowCmd()
        {
            _view.Open();
        }
    }
}
