using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.ViewModels
{
    public class NewPatientViewModel : ViewModelBase
    {
        public string _name = null!;
        public string Name 
        {
            get 
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }

            }
        }

        public DateTime _dateOfBirth;

        public DateTime DateOfBirth 
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public static int CalculateAge()
        {
            return 0;
        }

    }
}
