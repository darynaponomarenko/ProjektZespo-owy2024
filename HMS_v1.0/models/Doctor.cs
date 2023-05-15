using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HMS_v1._0.models
{
    public class Doctor : INotifyPropertyChanged
    {
        public int Id;
        public string name=null!;
        public string surname = null!;
        public string specialization = null!;
        public string email = null!;
        public string phoneNumber = null!;
        List<string> addresses = new();

        /*public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                
            }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
