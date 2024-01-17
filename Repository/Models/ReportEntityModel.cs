using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class ReportEntityModel
    {
        public int Id { get; set; }
        public string? PayersName { get; set; }
        public string? Pesel { get; set; }

        public string? TypeOfForm { get; set; }

        public string? ContractNr { get; set; }

        public string? ContractingAuthority { get; set; }

        public string? TypeOfRefferal { get; set; }

        public string? Diagnosis { get; set; }

        public string? CodeICD { get; set; }
        public string? CodeDescription { get; set; }

        public string? PurposeOfAdvice { get; set; }

        public string? TreatmentHistory { get; set; }

        public string? DoctorsData { get; set; }
    }
}
