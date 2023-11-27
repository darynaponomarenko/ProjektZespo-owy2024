using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public string Status { get; set; } = null!;

        public string? Interview { get; set; }
        public string? Inspection { get; set; }
        public string? Diagnosis { get; set; }
        public string? TreatmentHistory { get; set; }
        public string? Recommendations { get; set; }

        public string? TreatmentContinuationMethod { get; set; }


        public ICD10? ICD10 { get; set; }


    }
}
