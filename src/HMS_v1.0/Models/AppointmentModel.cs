using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.Models
{
    public class AppointmentModel
    {
        public int DoctorID { get; set; }
        public DoctorModel? Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }

        public string Status { get; set; } = null!;

        public string? Interview { get; set; }
        public string? Inspection { get; set; }
        public string? Diagnosis { get; set; }
        public string? TreatmentHistory { get; set; }
        public string? Recommendations { get; set; }

        public string? TreatmentContinuationMethod { get; set; }


        public string ICD10 { get; set; }
    }
}
