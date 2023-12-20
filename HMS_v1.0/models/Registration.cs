using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HMS_v1._0.models
{
    public class Registration 
    {
        private string? PatientName { get; set; }
        private string? PatientAge { get; set; }
        private string? Pesel { get; set; }
        private string? Procedure { get; set; }
        private string? Priority { get; set; }
        private string? Worklist { get; set; }
        private TimeOnly? Time { get; set; }
        private string? PayerName { get; set; }
        private string? PayerExtraNote { get; set; }
        private DateOnly? DateOfIssue { get; set; }
        private string? ContractingAuthority { get; set; }
        private string? CodeICD { get; set; }
        private string? CodeICDName { get; set; }
        private string? AdmissionReasoning { get; set; }
    }
}
