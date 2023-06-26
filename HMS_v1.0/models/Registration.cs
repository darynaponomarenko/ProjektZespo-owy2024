using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HMS_v1._0.models
{
    public class Registration : INotifyPropertyChanged
    {
        private string patientsID = null!;
        private string patientName = null!;
        private string patientAge = null!;
        private string pesel = null!;
        private string procedure = null!;
        private string priority = null!     ;
        private string worklist = null!;
        private TimeOnly time;
        private string payerName = null!;
        private string payerExtraNote = null!;
        private DateOnly dateOfIssue;
        private string contractingAuthority = null!;
        private string codeICD = null!;
        private string codeICDName = null!;
        private string admissionReasoning = null!;
        private string nfzContractNr = null!;
        private string workersID = null!;
        private string workersName = null!;

        public string PatientsID
        {
            get
            {
                return patientsID;
            }
            set
            {
                if (patientsID != value)
                {
                    patientsID = value;
                    OnPropertyChanged("PatientsID");
                }
            }
        }

        public string PatientName
        {
            get
            {
                return patientName;
            }
            set
            {
                if (patientName != value)
                {
                    patientName = value;
                    OnPropertyChanged("PatientsName");
                }
            }
        }

        public string PatientAge
        {
            get
            {
                return patientAge;
            }
            set
            {
                if (patientAge != value)
                {
                    patientAge = value;
                    OnPropertyChanged("PatientsAge");
                }
            }
        }

        public string Pesel
        {
            get
            {
                return pesel;
            }
            set
            {
                if (pesel != value)
                {
                    pesel = value;
                    OnPropertyChanged("PESEL");
                }
            }
        }

        public string Procedure
        {
            get
            {
                return procedure;
            }
            set
            {
                if (procedure != value)
                {
                    procedure = value;
                    OnPropertyChanged("Procedure");
                }
            }
        }

        public string Priority
        {
            get
            {
                return priority;
            }
            set
            {
                if (priority != value)
                {
                    priority = value;
                    OnPropertyChanged("Priority");
                }
            }
        }

        public string WorkList
        {
            get
            {
                return worklist;
            }
            set
            {
                if (worklist != value)
                {
                    worklist = value;
                    OnPropertyChanged("WorkList");
                }
            }
        }

        public TimeOnly Time
        {
            get
            {
                return time;
            }
            set
            {
                if (time != value)
                {
                    time = value;
                    OnPropertyChanged("Time");
                }
            }
        }

        public string PayerName
        {
            get
            {
                return payerName;
            }
            set
            {
                if (payerName != value)
                {
                    payerName = value;
                    OnPropertyChanged("PayerName");
                }
            }
        }

        public string PayerExtraNote
        {
            get
            {
                return payerExtraNote;
            }
            set
            {
                if (payerExtraNote != value)
                {
                    payerExtraNote = value;
                    OnPropertyChanged("PayerExtraNote");
                }
            }
        }

        public DateOnly DateOfIssue
        {
            get
            {
                return dateOfIssue;
            }
            set
            {
                if (dateOfIssue != value)
                {
                    dateOfIssue = value;
                    OnPropertyChanged("DateOfIssue");
                }
            }
        }

        public string ContractingAuthority
        {
            get
            {
                return contractingAuthority;
            }
            set
            {
                if (contractingAuthority != value)
                {
                    contractingAuthority = value;
                    OnPropertyChanged("ContractingAuthority");
                }
            }
        }

        public string CodeICD
        {
            get
            {
                return codeICD;
            }
            set
            {
                if (codeICD != value)
                {
                    codeICD = value;
                    OnPropertyChanged("CodeICD");
                }
            }
        }

        public string CodeICDName
        {
            get
            {
                return codeICDName;
            }
            set
            {
                if (codeICDName != value)
                {
                    codeICDName = value;
                    OnPropertyChanged("CodeICDName");
                }
            }
        }

        public string AdmissionReasoning
        {
            get
            {
                return admissionReasoning;
            }
            set
            {
                if (admissionReasoning != value)
                {
                    admissionReasoning = value;
                    OnPropertyChanged("AdmissionReasoning");
                }
            }
        }

        public string NFZContractNr
        {
            get
            {
                return nfzContractNr;
            }
            set
            {
                if (nfzContractNr != value)
                {
                    nfzContractNr = value;
                    OnPropertyChanged("NFZContractNumber");
                }
            }
        }

        public string WorkersID
        {
            get
            {
                return workersID;
            }
            set
            {
                if (workersID != value)
                {
                    workersID = value;
                    OnPropertyChanged("WorkersID");
                }
            }
        }

        public string WorkersName
        {
            get
            {
                return workersName;
            }
            set
            {
                if (workersName != value)
                {
                    workersName = value;
                    OnPropertyChanged("WorkersName");
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        
    }
}
