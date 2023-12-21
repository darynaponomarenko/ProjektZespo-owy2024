using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HMS_v1._0.models
{
    public class RegistrationModel 
    {
        public string? PatientName { get; set; }
        public string? PatientAge { get; set; }
        public string? Pesel { get; set; }
        public string? Procedure { get; set; }
        public string? Priority { get; set; }
        public string? Worklist { get; set; }
        public DateTime Time { get; set; }
        public string? PayerName { get; set; }
        public string? PayerExtraNote { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string? ContractingAuthority { get; set; }
        public string? CodeICD { get; set; }
        public string? CodeICDName { get; set; }
        public string? AdmissionReasoning { get; set; }
    }
}
