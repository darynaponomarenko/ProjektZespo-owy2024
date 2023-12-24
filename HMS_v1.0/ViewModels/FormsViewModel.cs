using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.ViewModels
{
    public class FormsViewModel : ViewModelBase
    {
        private ObservableCollection<string> _typeOfForm = null!;
    
        public FormsViewModel() 
        {
            TypeOfForm = new ObservableCollection<string> {"skierowanie"};
        }

        public ObservableCollection<string> TypeOfForm
        {
            get { return _typeOfForm; }
            set
            {
                if (_typeOfForm != value)
                {
                    _typeOfForm = value;
                    OnPropertyChanged(nameof(TypeOfForm));
                }
            }
        }
    }
}
