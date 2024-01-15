using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.Messages
{
    public class SelectedAppointmentToEdit
    {
        public int PatientId { get; set; }
        public string? PayerName { get; set; }
        public string? Pesel { get; set; }
        public string? WorkList { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public string? Procedure { get; set; }
        public string? Priority { get; set; }
        public string? ContractingAuthorities { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public string? ReasonForAdmission { get; set; }
        public string? CodeICD { get; set; }
        public string? NFZContractNr { get; set; }


    }
}
